import { memo, useEffect, useRef, useState, useCallback } from 'react';
import { type IkonUiComponentResolver, type UiComponentRendererProps, useUiNode } from '@ikonai/sdk-react-ui';
import * as pdfjs from 'pdfjs-dist';

// Configure the worker
pdfjs.GlobalWorkerOptions.workerSrc = `//cdnjs.cloudflare.com/ajax/libs/pdf.js/${pdfjs.version}/pdf.worker.min.mjs`;

// ── Highlight Theme (change colors here) ──
const HIGHLIGHT_THEME = {
    rect: 'rgba(253, 224, 71, 0.45)',       // highlight rectangle fill
    rectBorder: 'rgba(234, 179, 8, 0.7)',   // highlight rectangle underline
    activeRect: 'rgba(249, 154, 22, 0.6)',  // active (focused) match fill
    activeRectBorder: 'rgba(249, 154, 22, 0.9)', // active match underline
    badgeBg: 'rgba(253, 224, 71, 0.15)',    // match count badge background
    badgeBorder: 'rgba(253, 224, 71, 0.4)', // match count badge border
};

// ── Types ──

interface TextItem {
    str: string;
    transform: number[];
    width: number;
    fontName: string;
}

interface MappedChar {
    itemIndex: number;
    charOffset: number;
}

interface PositionedItem {
    str: string;
    x: number;
    y: number;       // top of the glyph box (baseline - fontSize)
    fontSize: number;
    scaledWidth: number;
    height: number;
}

interface HighlightRect {
    x: number;
    y: number;
    width: number;
    height: number;
    pageIndex: number;
}

interface PageData {
    positioned: PositionedItem[];
    flatText: string;
    charMap: MappedChar[];
}

// ── Component ──

const INITIAL_SCALE = 1.5;

const ProofPointRenderer = memo(function ProofPointRenderer({ nodeId, context, className }: UiComponentRendererProps) {
    const node = useUiNode(context.store, nodeId);
    if (!node) return null;

    const pdfUrl = node.props?.['pdfUrl'] as string | undefined;
    const pdfData = node.props?.['pdfData'] as string | undefined;
    const initialSearchText = node.props?.['searchText'] as string | undefined;
    const onSearchContentActionId = node.props?.['onSearchContent'] as string | undefined;

    const [pdf, setPdf] = useState<pdfjs.PDFDocumentProxy | null>(null);
    const [numPages, setNumPages] = useState(0);
    const [searchText, setSearchText] = useState(initialSearchText || '');
    const [highlights, setHighlights] = useState<HighlightRect[]>([]);
    const [matchCount, setMatchCount] = useState(0);
    const [currentMatchIndex, setCurrentMatchIndex] = useState(-1);
    const [pagesReady, setPagesReady] = useState(0);

    // Track last synced prop to detect changes
    const lastSyncedProp = useRef(initialSearchText || '');

    // Sync searchText prop from server → internal state
    useEffect(() => {
        const incoming = initialSearchText ?? '';
        if (incoming !== lastSyncedProp.current) {
            lastSyncedProp.current = incoming;
            setSearchText(incoming);
            setCurrentMatchIndex(incoming.length >= 2 ? 0 : -1);
        }
    }, [initialSearchText]);

    const containerRef = useRef<HTMLDivElement>(null);
    const canvasRefs = useRef<(HTMLCanvasElement | null)[]>([]);
    const textLayerRefs = useRef<(HTMLDivElement | null)[]>([]);
    const highlightLayerRefs = useRef<(HTMLDivElement | null)[]>([]);
    const pageDataRefs = useRef<(PageData | null)[]>([]);
    const renderedPages = useRef<Set<number>>(new Set());

    // ── Phase 0: Load PDF ──
    useEffect(() => {
        const loadPdf = async () => {
            try {
                let loadingTask;
                if (pdfUrl) {
                    loadingTask = pdfjs.getDocument(pdfUrl);
                } else if (pdfData) {
                    const binaryData = atob(pdfData);
                    const uint8Array = new Uint8Array(binaryData.length);
                    for (let i = 0; i < binaryData.length; i++) {
                        uint8Array[i] = binaryData.charCodeAt(i);
                    }
                    loadingTask = pdfjs.getDocument({ data: uint8Array });
                } else {
                    return;
                }

                const pdfDoc = await loadingTask.promise;
                setPdf(pdfDoc);
                setNumPages(pdfDoc.numPages);
                renderedPages.current.clear();
                pageDataRefs.current = [];
                setPagesReady(0);
            } catch (error) {
                console.error('Error loading PDF:', error);
            }
        };

        loadPdf();
    }, [pdfUrl, pdfData]);

    // ── Phase 1 & 2: Render canvas + extract text map ──
    const renderPage = useCallback(async (pageNum: number) => {
        if (!pdf || renderedPages.current.has(pageNum)) return;

        try {
            const page = await pdf.getPage(pageNum);
            const canvas = canvasRefs.current[pageNum];
            const textLayerDiv = textLayerRefs.current[pageNum];

            if (!canvas || !textLayerDiv) return;
            renderedPages.current.add(pageNum);

            const viewport = page.getViewport({ scale: INITIAL_SCALE });

            // ── Phase 1: High-fidelity canvas rendering with DPI awareness ──
            const outputScale = window.devicePixelRatio || 1;
            canvas.width = Math.floor(viewport.width * outputScale);
            canvas.height = Math.floor(viewport.height * outputScale);
            canvas.style.width = Math.floor(viewport.width) + 'px';
            canvas.style.height = Math.floor(viewport.height) + 'px';

            const ctx = canvas.getContext('2d')!;
            const transform: [number, number, number, number, number, number] | undefined =
                outputScale !== 1 ? [outputScale, 0, 0, outputScale, 0, 0] : undefined;

            await page.render({
                canvasContext: ctx,
                viewport,
                transform,
            }).promise;

            // ── Phase 2: Extract the text map ──
            const textContent = await page.getTextContent();
            const items = textContent.items as TextItem[];

            const positioned: PositionedItem[] = [];
            const charMap: MappedChar[] = [];
            let flatText = '';

            for (let itemIndex = 0; itemIndex < items.length; itemIndex++) {
                const item = items[itemIndex];
                if (!item.str) continue;

                // Phase 3: Mathematical alignment
                // Convert PDF coordinates (bottom-left origin) to viewport coordinates (top-left)
                const [x, y] = viewport.convertToViewportPoint(item.transform[4], item.transform[5]);

                // Font size from the transformation matrix
                const fontSize = Math.sqrt(
                    item.transform[2] ** 2 + item.transform[3] ** 2
                ) * viewport.scale;

                // Scaled width of the text run
                const scaledWidth = item.width * viewport.scale;

                // Baseline offset: y from convertToViewportPoint is the baseline,
                // so subtract fontSize to get the top of the glyph box
                const top = y - fontSize;

                positioned.push({
                    str: item.str,
                    x,
                    y: top,
                    fontSize,
                    scaledWidth,
                    height: fontSize * 1.2, // slight padding for descenders
                });

                // Build flat text and character map
                for (let charOffset = 0; charOffset < item.str.length; charOffset++) {
                    charMap.push({ itemIndex: positioned.length - 1, charOffset });
                    flatText += item.str[charOffset];
                }
            }

            pageDataRefs.current[pageNum] = { positioned, flatText, charMap };

            // ── Phase 3 continued: Render invisible text layer for selection ──
            textLayerDiv.innerHTML = '';
            textLayerDiv.style.width = Math.floor(viewport.width) + 'px';
            textLayerDiv.style.height = Math.floor(viewport.height) + 'px';

            for (const posItem of positioned) {
                const span = document.createElement('span');
                span.textContent = posItem.str;
                span.style.position = 'absolute';
                span.style.left = `${posItem.x}px`;
                span.style.top = `${posItem.y}px`;
                span.style.fontSize = `${posItem.fontSize}px`;
                span.style.fontFamily = 'sans-serif';
                span.style.whiteSpace = 'pre';
                span.style.color = 'transparent';
                span.style.cursor = 'text';
                span.style.transformOrigin = '0% 0%';

                // Scale span width to match actual PDF glyph width
                const naturalWidth = getTextWidth(posItem.str, posItem.fontSize);
                if (naturalWidth > 0 && posItem.scaledWidth > 0) {
                    const scaleX = posItem.scaledWidth / naturalWidth;
                    span.style.transform = `scaleX(${scaleX})`;
                }

                textLayerDiv.appendChild(span);
            }

            // Signal that this page's text data is ready for searching
            setPagesReady(prev => prev + 1);
        } catch (error) {
            console.error('Error rendering page:', error);
        }
    }, [pdf]);

    // Render all pages
    useEffect(() => {
        if (pdf) {
            for (let i = 1; i <= numPages; i++) {
                renderPage(i);
            }
        }
    }, [pdf, numPages, renderPage]);

    // ── Phase 4: Precise search highlighting ──
    useEffect(() => {
        if (!searchText || searchText.length < 2) {
            setHighlights([]);
            setMatchCount(0);
            return;
        }

        const allHighlights: HighlightRect[] = [];

        // Normalize: collapse whitespace, strip currency symbols and commas for flexible matching
        const normalize = (s: string) => s
            .replace(/[\u20AC\u00A3\$,]/g, '')   // strip €, £, $, commas
            .replace(/\s+/g, ' ')                // collapse whitespace
            .toLowerCase();

        const normalizedSearch = normalize(searchText).trim();
        if (normalizedSearch.length < 2) {
            setHighlights([]);
            setMatchCount(0);
            return;
        }
        const escapedSearch = normalizedSearch.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
        const regex = new RegExp(escapedSearch, 'gi');

        for (let pageNum = 1; pageNum <= numPages; pageNum++) {
            const pageData = pageDataRefs.current[pageNum];
            if (!pageData) continue;

            const { flatText, charMap, positioned } = pageData;

            // Build normalized flat text with a mapping back to original indices
            const normText: string[] = [];
            const normToOrigIdx: number[] = [];
            for (let i = 0; i < flatText.length; i++) {
                const ch = flatText[i];
                const normalized = normalize(ch);
                for (const nc of normalized) {
                    normText.push(nc);
                    normToOrigIdx.push(i);
                }
            }
            const normalizedFlat = normText.join('');

            let match: RegExpExecArray | null;
            while ((match = regex.exec(normalizedFlat)) !== null) {
                // Map normalized match positions back to original char positions
                const origStart = normToOrigIdx[match.index];
                const origEnd = normToOrigIdx[match.index + match[0].length - 1];
                const matchStart = origStart;
                const matchEnd = origEnd + 1;

                // Group consecutive chars by their source item
                let currentItemIdx = charMap[matchStart].itemIndex;
                let segStart = charMap[matchStart].charOffset;

                for (let ci = matchStart; ci <= matchEnd; ci++) {
                    const isEnd = ci === matchEnd;
                    const nextItemIdx = isEnd ? -1 : charMap[ci].itemIndex;

                    if (isEnd || nextItemIdx !== currentItemIdx) {
                        const item = positioned[currentItemIdx];
                        const segLen = (isEnd && nextItemIdx === currentItemIdx)
                            ? charMap[ci - 1].charOffset - segStart + 1
                            : (ci === matchStart ? 0 : charMap[ci - 1].charOffset - segStart + 1);

                        if (item && segLen > 0) {
                            const charWidth = item.str.length > 0 ? item.scaledWidth / item.str.length : 0;
                            const highlightX = item.x + segStart * charWidth;
                            const highlightWidth = segLen * charWidth;

                            allHighlights.push({
                                x: highlightX,
                                y: item.y,
                                width: highlightWidth,
                                height: item.height,
                                pageIndex: pageNum,
                            });
                        }

                        if (!isEnd) {
                            currentItemIdx = nextItemIdx;
                            segStart = charMap[ci].charOffset;
                        }
                    }
                }
            }
        }

        setHighlights(allHighlights);
        setMatchCount(allHighlights.length);
        setCurrentMatchIndex(allHighlights.length > 0 ? 0 : -1);
    }, [searchText, numPages, pagesReady]);

    // Scroll to current active match
    useEffect(() => {
        if (currentMatchIndex >= 0 && currentMatchIndex < highlights.length) {
            const hl = highlights[currentMatchIndex];
            const hlLayer = highlightLayerRefs.current[hl.pageIndex];
            if (hlLayer) {
                const rects = hlLayer.querySelectorAll('.pp-hl-rect');
                // Find the rect that corresponds to the global index within this page
                const pageHighlights = highlights.filter(h => h.pageIndex === hl.pageIndex);
                const localIdx = pageHighlights.indexOf(hl);
                if (localIdx >= 0 && rects[localIdx]) {
                    rects[localIdx].scrollIntoView({ behavior: 'smooth', block: 'center' });
                }
            }
        }
    }, [currentMatchIndex, highlights]);

    // Search handler
    const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const text = e.target.value;
        setSearchText(text);
        if (onSearchContentActionId) {
            context.dispatchAction(onSearchContentActionId, { text });
        }
    };

    // Enter key to navigate matches (Shift+Enter goes backward)
    const handleSearchKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
        if (e.key === 'Enter' && matchCount > 0) {
            e.preventDefault();
            if (e.shiftKey) {
                setCurrentMatchIndex(prev => (prev - 1 + matchCount) % matchCount);
            } else {
                setCurrentMatchIndex(prev => (prev + 1) % matchCount);
            }
        }
    };

    return (
        <div className={`proof-point-root ${className || ''}`} ref={containerRef}
            style={{ display: 'flex', flexDirection: 'column', overflow: 'hidden', height: '100%' }}>

            {/* Search Bar */}
            <div style={{
                display: 'flex', alignItems: 'center', gap: '8px',
                padding: '10px 16px',
                backgroundColor: 'var(--background, #fff)',
                borderBottom: '1px solid var(--border, #e5e7eb)',
                flexShrink: 0,
            }}>
                <div style={{ position: 'relative', flex: 1 }}>
                    <input
                        type="search"
                        value={searchText}
                        onChange={handleSearchChange}
                        onKeyDown={handleSearchKeyDown}
                        placeholder="Search in document..."
                        style={{
                            width: '100%',
                            padding: '8px 12px 8px 36px',
                            borderRadius: '8px',
                            border: '1px solid var(--border, #d1d5db)',
                            backgroundColor: 'var(--input, #f9fafb)',
                            color: 'var(--foreground, #111)',
                            fontSize: '14px',
                            fontFamily: 'inherit',
                            outline: 'none',
                            transition: 'border-color 0.15s, box-shadow 0.15s',
                        }}
                        onFocus={e => {
                            e.currentTarget.style.borderColor = '#3b82f6';
                            e.currentTarget.style.boxShadow = '0 0 0 3px rgba(59, 130, 246, 0.15)';
                        }}
                        onBlur={e => {
                            e.currentTarget.style.borderColor = 'var(--border, #d1d5db)';
                            e.currentTarget.style.boxShadow = 'none';
                        }}
                    />
                    <div style={{
                        position: 'absolute', left: '11px', top: '50%', transform: 'translateY(-50%)',
                        color: 'var(--muted-foreground, #9ca3af)', display: 'flex', pointerEvents: 'none',
                    }}>
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><circle cx="11" cy="11" r="8" /><path d="m21 21-4.3-4.3" /></svg>
                    </div>
                </div>
                {matchCount > 0 && (
                    <span style={{
                        fontSize: '12px', color: 'var(--muted-foreground, #6b7280)',
                        whiteSpace: 'nowrap', flexShrink: 0, padding: '4px 10px',
                        backgroundColor: HIGHLIGHT_THEME.badgeBg,
                        border: `1px solid ${HIGHLIGHT_THEME.badgeBorder}`,
                        borderRadius: '6px', fontWeight: 500,
                    }}>
                        {currentMatchIndex + 1} / {matchCount}
                    </span>
                )}
            </div>

            {/* PDF Pages */}
            <div className="pp-scroll-area" style={{
                flex: 1, overflowY: 'auto', padding: '20px 16px',
                display: 'flex', flexDirection: 'column', alignItems: 'center', gap: '24px',
                backgroundColor: 'rgba(0,0,0,0.04)',
            }}>
                {Array.from({ length: numPages }, (_, i) => i + 1).map(pageNum => {
                    const pageHighlights = highlights.filter(h => h.pageIndex === pageNum);
                    return (
                        <div key={pageNum} style={{
                            position: 'relative',
                            boxShadow: '0 4px 24px rgba(0,0,0,0.12), 0 1px 4px rgba(0,0,0,0.08)',
                            backgroundColor: '#fff',
                            border: '1px solid #e5e7eb',
                            borderRadius: '3px',
                            width: 'fit-content',
                        }}>
                            {/* Layer 1: Canvas (bottom) */}
                            <canvas
                                ref={el => { canvasRefs.current[pageNum] = el; }}
                                style={{ display: 'block' }}
                            />

                            {/* Layer 2: Highlight overlay (middle) */}
                            <div
                                ref={el => { highlightLayerRefs.current[pageNum] = el; }}
                                style={{
                                    position: 'absolute', inset: 0,
                                    pointerEvents: 'none', zIndex: 10,
                                    overflow: 'hidden',
                                }}
                            >
                                {pageHighlights.map((hl, idx) => {
                                    const globalIdx = highlights.indexOf(hl);
                                    const isActive = globalIdx === currentMatchIndex;
                                    return (
                                        <div
                                            key={idx}
                                            className="pp-hl-rect"
                                            style={{
                                                position: 'absolute',
                                                left: `${hl.x}px`,
                                                top: `${hl.y}px`,
                                                width: `${hl.width}px`,
                                                height: `${hl.height}px`,
                                                backgroundColor: isActive ? HIGHLIGHT_THEME.activeRect : HIGHLIGHT_THEME.rect,
                                                borderBottom: `2px solid ${isActive ? HIGHLIGHT_THEME.activeRectBorder : HIGHLIGHT_THEME.rectBorder}`,
                                                borderRadius: '1px',
                                                mixBlendMode: 'multiply',
                                                transition: 'background-color 0.2s, border-color 0.2s',
                                                boxShadow: isActive ? '0 0 8px rgba(249, 115, 22, 0.4)' : 'none',
                                            }}
                                        />
                                    );
                                })}
                            </div>

                            {/* Layer 3: Invisible text layer (top) */}
                            <div
                                ref={el => { textLayerRefs.current[pageNum] = el; }}
                                style={{
                                    position: 'absolute', inset: 0,
                                    overflow: 'hidden', zIndex: 20,
                                    lineHeight: 1.0,
                                }}
                            />
                        </div>
                    );
                })}
                {numPages === 0 && (
                    <div style={{
                        display: 'flex', flexDirection: 'column', alignItems: 'center',
                        justifyContent: 'center', height: '256px',
                        color: 'var(--muted-foreground, #9ca3af)',
                    }}>
                        <svg xmlns="http://www.w3.org/2000/svg" width="48" height="48" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="1" strokeLinecap="round" strokeLinejoin="round" style={{ marginBottom: '16px', animation: 'ppPulse 2s infinite' }}><path d="M14.5 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7.5L14.5 2z" /><polyline points="14 2 14 8 20 8" /></svg>
                        <p style={{ fontSize: '14px' }}>Loading document...</p>
                    </div>
                )}
            </div>

            <style dangerouslySetInnerHTML={{
                __html: `
                @keyframes ppPulse {
                    0%, 100% { opacity: 1; }
                    50% { opacity: 0.4; }
                }
                .pp-scroll-area::-webkit-scrollbar { width: 8px; }
                .pp-scroll-area::-webkit-scrollbar-track { background: transparent; }
                .pp-scroll-area::-webkit-scrollbar-thumb { background: rgba(128,128,128,0.25); border-radius: 20px; }
                .pp-scroll-area::-webkit-scrollbar-thumb:hover { background: rgba(128,128,128,0.45); }
            `}} />
        </div>
    );
});

// ── Utility: measure text width using an off-screen canvas ──
let measureCanvas: HTMLCanvasElement | null = null;
function getTextWidth(text: string, fontSize: number): number {
    if (!measureCanvas) {
        measureCanvas = document.createElement('canvas');
    }
    const ctx = measureCanvas.getContext('2d')!;
    ctx.font = `${fontSize}px sans-serif`;
    return ctx.measureText(text).width;
}

export function createProofPointResolver(): IkonUiComponentResolver {
    return (node) => {
        if (node.type !== 'proof-point') return undefined;
        return ProofPointRenderer;
    };
}
