<!-- This file is automatically updated by ikon tool commands. User edits are preserved only below the ikon-user-content-below marker. -->

# Ikon AI App Development Guidelines

**Detailed API references are in docs/guides/. See the guide index at the bottom of this document.**

## Architecture

Ikon AI App is a cloud-native platform for building interactive, AI-powered multi-user experiences.

**App structure:** C# app runs in the cloud, streams reactive UI to browser clients via WebSocket. The app persists even when all clients disconnect. Multiple clients connect to the same app instance for real-time collaboration, games, and shared experiences.

**AI services (no setup required — the platform handles all API keys and connections):**
- `Emerge.Run<T>()` — LLM text generation and structured JSON output (Claude, GPT, Gemini, Grok, and more)
- `new ImageGenerator(model)` — AI image generation (Gemini, DALL-E, Flux, etc.)
- `new SpeechGenerator(model)` — text-to-speech (ElevenLabs, Azure, OpenAI, Google)
- `new SpeechRecognizer(model)` — speech-to-text (Whisper)
- `new VideoGenerator(model)`, `new EmbeddingGenerator(model)`, `new WebSearcher(model)` — other AI services

**UI system:** Declared in C# inside `UI.Root(content: view => { ... })`. The `view` parameter (`UIView`) provides component methods: `view.Text()`, `view.Button()`, `view.ScrollArea()`, `view.TextField()`, etc. Nested content lambdas receive their own `view` parameter.

**State:** `Reactive<T>` (shared across all clients), `ClientReactive<T>` (per-client), `UserReactive<T>` (per-user). Changes automatically trigger UI updates — only the diff is streamed to clients.

**Styling:** Crosswind — Tailwind-like utility classes in C# string arrays, with a motion animation system for declarative keyframe animations (`motion-[...]`).

**Audio:** `private Audio Audio { get; } = new(host);` — audio synthesis (Ikon.Resonance), effects, playback, and client microphone/camera capture.

**Namespaces:** All Ikon namespaces are auto-imported via `GlobalUsings.cs` — no manual `using` statements needed for Ikon types.

## Development Focus

- Most development happens in the C# app, including styling
- LLM text generation uses `Emerge.Run<T>()`. Other AI services (image, speech, video) are standalone classes instantiated directly
- UI is declared inside `UI.Root([Page.Default], content: view => { ... })` — components are methods on the `view` lambda parameter
- Crosswind styling: Tailwind-like syntax in style arrays, with motion animation system
- `Reactive<T>` for shared state, `ClientReactive<T>` for per-client state — changes trigger UI updates automatically
- All Ikon namespaces are auto-imported via `GlobalUsings.cs`
- Only modify frontend-node when integrating custom React UI components
- Developers can freely add any NuGet packages to C# app or npm packages to frontend

## API Reference Guides

Detailed API docs are available in `docs/guides/`. Each guide covers a specific topic:

- **app-structure** (`docs/guides/app-structure.md`): app file structure, session identity, client parameters, partial class, global usings, lifecycle, host services, navigation, background work, client functions, messages, minimal app template, viewport layout, auto-scroll, QR code, join URL, multi-user session, invite link
- **app-api-reference** (`docs/guides/app-api-reference.md`): IApp, host services, server API, navigation, session, common utilities
- **reactive-state** (`docs/guides/reactive-state.md`): reactive, client reactive, user reactive, persistent reactive, reactive scope, value mutation
- **ui-components** (`docs/guides/ui-components.md`): layout, overlays, inputs, display, navigation, drag-and-drop, text, button, dialog, tabs, accordion, scroll area, toast, popover, chat interface, message bubbles
- **ui-api-reference** (`docs/guides/ui-api-reference.md`): parallax, UI components API, method signatures, component parameters, props
- **styling-and-motion** (`docs/guides/styling-and-motion.md`): crosswind, tailwind, theme constants, style arrays, motion, animation, UI guidelines, theme customization
- **styling-guide** (`docs/guides/styling-guide.md`): crosswind guide, UI design patterns, common pitfalls, sophisticated UI, layout patterns, gradient, overlay, CRT, scanline
- **motion-reference** (`docs/guides/motion-reference.md`): motion spec, keyframe, animation, timing, staggered text, 3D transform, filter animation, animatable properties, motion syntax grammar
- **tailwind-reference** (`docs/guides/tailwind-reference.md`): tailwind spec, utility classes, layout, flexbox, grid, spacing, typography, backgrounds, borders, effects, shadows, transitions
- **emergence** (`docs/guides/emergence.md`): emergence, emerge run, structured output, json, tools, agent, bestof, mapreduce, taskgraph, patterns, cancellation, timeout
- **emergence-patterns** (`docs/guides/emergence-patterns.md`): mapreduce, taskgraph, treesearch, tree of thought, solver critic, debate, refine, plan and execute, router, ensemble, swarm, advanced patterns
- **ai-models** (`docs/guides/ai-models.md`): LLM model, model selection, Claude, Gemini, GPT, Grok, model enum, KernelContext, AI connection
- **ai-image** (`docs/guides/ai-image.md`): image generation, ImageGenerator, AI image, photo, generate image, ImageGeneratorConfig
- **ai-speech-and-audio** (`docs/guides/ai-speech-and-audio.md`): speech, TTS, STT, voice, transcribe, whisper, sound effect, SpeechGenerator, SpeechRecognizer, SoundEffectGenerator
- **ai-video** (`docs/guides/ai-video.md`): video generation, video enhancement, AI video, VideoGenerator, VideoEnhancer
- **ai-web-and-data** (`docs/guides/ai-web-and-data.md`): web search, scrape, crawl, classify, OCR, embedding, vector, retrieve, rerank, file convert, WebSearcher, EmbeddingGenerator
- **ai-advanced** (`docs/guides/ai-advanced.md`): database AI, vector store, AI policy, storage
- **audio-video** (`docs/guides/audio-video.md`): audio, video, capture, speech, stream, effects, reverb, delay, mixer, synthesizer, oscillator, filter
- **asset-system** (`docs/guides/asset-system.md`): asset, cloud file, local file, cloud json, storage, metadata, URI, optimistic concurrency
- **endpoints-databases** (`docs/guides/endpoints-databases.md`): endpoints, HTTP, HTTPS, WebSocket, databases, PostgreSQL
- **function-registry** (`docs/guides/function-registry.md`): function registry, registration, attribute, visibility, LLM tools, callable functions
- **logging** (`docs/guides/logging.md`): log, logging, debug, warning, error, diagnostics
- **pipelines** (`docs/guides/pipelines.md`): pipeline, background processing, transform, processor, scheduled, cron
- **pipelines-reference** (`docs/guides/pipelines-reference.md`): pipeline API, transform, processor, pipeline guide
- **frontend-fundamentals** (`docs/guides/frontend-fundamentals.md`): frontend, SDK, auth, connection, i18n, styling, query params, custom UI component, module, resolver, React
- **config-and-cli** (`docs/guides/config-and-cli.md`): ikon-config.toml, CLI commands, build, deploy, run, auth, activation, targets


<!-- ikon-user-content-below -->
