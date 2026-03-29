# Ikon.Crosswind Public API

namespace Ikon.Crosswind
  enum ArgType
    Length
    Color
    Time
    Angle
    Fraction
    Keyword
    Unknown
  class ArgValue : IEquatable<ArgValue>
    ctor(string Raw, string Value, Unit Unit, ArgType Type)
    string Raw { get;  init; }
    ArgType Type { get;  init; }
    Unit Unit { get;  init; }
    string Value { get;  init; }
    bool IsColor()
    bool IsKeyword()
    bool IsLength()
    bool IsUnit()
    bool IsUnknown()
  sealed class CanvasDesignTokenDocument
    ctor()
    Dictionary<string, CanvasTokenValue<string>> BackdropBlur { get;  init; }
    Dictionary<string, Dictionary<string, CanvasTokenValue<string>>> ColorScales { get;  init; }
    CanvasEffectTokens Effects { get;  init; }
    List<string> Guidelines { get;  init; }
    Dictionary<string, string> Metadata { get;  init; }
    string Name { get;  init; }
    Dictionary<string, CanvasTokenValue<string>> Radii { get;  init; }
    CanvasSemanticColorTokens SemanticColors { get;  init; }
    CanvasTypographyTokens Typography { get;  init; }
    string Version { get;  init; }
    void Validate()
  static class CanvasDesignTokenLoader
    static CanvasDesignTokenDocument Load(Stream stream)
    static CanvasDesignTokenDocument Load(string json)
    static CanvasDesignTokenDocument LoadFromFile(string path)
  sealed class CanvasEffectTokens
    ctor()
    CanvasModeTokenSet BoxShadows { get;  init; }
    CanvasModeTokenSet FocusRing { get;  init; }
    CanvasModeTokenSet ShadowPalette { get;  init; }
    IEnumerable<KeyValuePair<string, CanvasModeTokenSet>> Enumerate()
    void Validate()
  sealed class CanvasModeTokenSet
    ctor()
    Dictionary<string, CanvasTokenValue<string>> Dark { get;  init; }
    Dictionary<string, CanvasTokenValue<string>> Light { get;  init; }
    void Validate(string category)
  sealed class CanvasSemanticColorTokens
    ctor()
    CanvasModeTokenSet Background { get;  init; }
    CanvasModeTokenSet Border { get;  init; }
    CanvasModeTokenSet Foreground { get;  init; }
    CanvasModeTokenSet Text { get;  init; }
    IEnumerable<KeyValuePair<string, CanvasModeTokenSet>> Enumerate()
    void Validate()
  sealed class CanvasTokenValue<T>
    ctor()
    string Description { get;  init; }
    T Value { get;  init; }
  sealed class CanvasTypographyScale
    ctor()
    string Description { get;  init; }
    string FontFamily { get;  init; }
    string FontSize { get;  init; }
    string LetterSpacing { get;  init; }
    string LineHeight { get;  init; }
    void Validate(string tokenName)
  sealed class CanvasTypographyTokens
    ctor()
    Dictionary<string, CanvasTypographyScale> Display { get;  init; }
    Dictionary<string, CanvasTokenValue<string>> FontFamilies { get;  init; }
    Dictionary<string, CanvasTokenValue<int>> FontWeights { get;  init; }
    Dictionary<string, CanvasTypographyScale> Text { get;  init; }
    void Validate()
  class CompileResult : IEquatable<CompileResult>
    ctor(List<CssRule> Rules, List<string> ExtraCss, List<MotionBindingMetadata> MotionBindings)
    List<string> ExtraCss { get;  init; }
    List<MotionBindingMetadata> MotionBindings { get;  init; }
    List<CssRule> Rules { get;  init; }
  sealed class CompiledStyle : IEquatable<CompiledStyle>
    ctor(string Css, IReadOnlyList<MotionBindingMetadata> MotionBindings)
    string Css { get;  init; }
    IReadOnlyList<MotionBindingMetadata> MotionBindings { get;  init; }
  class ContainerVariant : IEquatable<ContainerVariant>
    ctor(string Name, string Query, string Breakpoint)
    string Breakpoint { get;  init; }
    string Name { get;  init; }
    string Query { get;  init; }
    bool WantsBreakpoint { get; }
    ContainerVariant WithBreakpoint(string breakpoint)
  static class CssEmitter
    static string Emit(CompileResult result)
  static class CssProcessor
    static string GetCss(string tailwindDeclaration, string classId)
    static CompiledStyle GetStyle(string tailwindDeclaration, string classId)
  class CssRule : IEquatable<CssRule>
    ctor(string AtRule, string Selector, Dictionary<string, string> Decls)
    string AtRule { get;  init; }
    Dictionary<string, string> Decls { get;  init; }
    string Selector { get;  init; }
  enum DarkModeStrategy
    Media
    Class
  sealed class MotionBindingMetadata : IEquatable<MotionBindingMetadata>
    ctor(string Source, string Min, string Max, string Clamp, bool Reverse, string Ease, string Map, string TargetId)
    string Clamp { get;  init; }
    string Ease { get;  init; }
    string Map { get;  init; }
    string Max { get;  init; }
    string Min { get;  init; }
    bool Reverse { get;  init; }
    string Source { get;  init; }
    string TargetId { get;  init; }
  static class SelectorComposer
    static IReadOnlyDictionary<string, string> BreakpointMap { get; }
    static string DarkClassSelector { get;  set; }
    static DarkModeStrategy DarkMode { get;  set; }
    static bool EnableThemeVariant { get;  set; }
    static string GroupClassSelector { get;  set; }
    static string PeerClassSelector { get;  set; }
    static ThemeSelectorStrategy ThemeStrategy { get;  set; }
    static string Compose(string baseSelector, IReadOnlyList<string> variants, string track, ContainerVariant container = null)
    static ValueTuple<string, string> ComposeTemplate(IReadOnlyList<string> variants, string track, ContainerVariant container = null)
  static class TW
    static string FormatLength(ArgValue a)
    static string FractionToPercent(string frac)
    static string MaybeNegate(bool negative, string val)
    static string ResolveColor(string raw, TailwindColorContext context = Generic)
    static string ResolveFontFamily(string token)
    static string ResolveFontWeight(string token)
    static string ResolveLetterSpacing(string tokenOrLength)
    static string ResolveLineHeight(string tokenOrLength)
    static string ResolveOpacity(string token)
    static string ResolveRadius(string tokenOrLength)
    static string ResolveShadow(string token)
    static string ResolveTextAlign(string token)
    static ValueTuple<string, string> ResolveTextSize(string tokenOrLength)
    static string SpacingTokenToLength(string token)
    static string UnitToSuffix(Unit u)
  enum TailwindColorContext
    Generic
    Background
    Foreground
    Text
    Border
  sealed class TailwindColorDefinitions
    ctor()
    ctor(IReadOnlyDictionary<string, string> background, IReadOnlyDictionary<string, string> foreground, IReadOnlyDictionary<string, string> text, IReadOnlyDictionary<string, string> border)
    IReadOnlyDictionary<string, string> Background { get;  init; }
    IReadOnlyDictionary<string, string> Border { get;  init; }
    IReadOnlyDictionary<string, string> Foreground { get;  init; }
    IReadOnlyDictionary<string, string> Text { get;  init; }
    void Validate()
  static class TailwindCompiler
    static CompileResult CompileRules(string baseSelector, string classAttr)
  static class TailwindCssBaseline
    static string AdditionalCss { get; }
    static IReadOnlyDictionary<string, string> DarkVariables { get; }
    static IReadOnlyDictionary<string, string> LightVariables { get; }
    static string GetFullBaseline()
  sealed class TailwindCssVariables
    ctor(IDictionary<string, string> light, IDictionary<string, string> dark, string darkThemeName = "dark")
    IReadOnlyDictionary<string, string> Dark { get; }
    string DarkThemeName { get; }
    IReadOnlyDictionary<string, string> Light { get; }
    string EmitDark()
    string EmitLight()
  static class TailwindCustomStyleRegistry
    static bool IsFontFamilyToken(string name)
    static bool IsFontWeightToken(string name)
    static void MergeDefinitions(TailwindStyleDefinitions definitions)
    static void SetDefinitions(TailwindStyleDefinitions definitions)
    static bool TryResolve(string name, TailwindColorContext context, out string value)
    static bool TryResolveFontFamily(string name, out string value)
    static bool TryResolveFontWeight(string name, out string value)
  static class TailwindDedup
    static List<TailwindDescription> Deduplicate(List<TailwindDescription> classes)
  class TailwindDescription : IEquatable<TailwindDescription>
    ctor(List<string> Variants, string Track, string Utility, List<ArgValue> Args, bool Important, bool Negative, ContainerVariant Container = null, bool HasBracketArg = false)
    List<ArgValue> Args { get;  init; }
    ContainerVariant Container { get;  init; }
    bool HasBracketArg { get;  init; }
    bool Important { get;  init; }
    bool Negative { get;  init; }
    string Track { get;  init; }
    string TrackKey { get; }
    string Utility { get;  init; }
    List<string> Variants { get;  init; }
  sealed class TailwindDesignTokenResult
    ctor(TailwindCssVariables cssVariables, TailwindThemeDefinition theme, TailwindStyleDefinitions styleDefinitions)
    TailwindCssVariables CssVariables { get; }
    TailwindStyleDefinitions StyleDefinitions { get; }
    TailwindThemeDefinition Theme { get; }
  sealed class TailwindFontDefinitions
    ctor()
    ctor(IReadOnlyDictionary<string, string> family, IReadOnlyDictionary<string, string> weight)
    IReadOnlyDictionary<string, string> Family { get;  init; }
    IReadOnlyDictionary<string, string> Weight { get;  init; }
    void Validate()
  sealed class TailwindFontSize
    ctor(string size, string lineHeight, string letterSpacing)
    string LetterSpacing { get; }
    string LineHeight { get; }
    string Size { get; }
  static class TailwindNormalizer
    static TailwindDescription Normalize(TailwindDescription tw)
  static class TailwindParser
    static List<TailwindDescription> ParseManyRaw(string inputLine)
    static TailwindDescription ParseRaw(string input)
    static ValueTuple<List<string>, string, ContainerVariant> SplitVariants(List<string> variants)
  static class TailwindStyleDefinitionLoader
    static Task<TailwindStyleDefinitions> Load(AssetUri assetUri)
    static TailwindStyleDefinitions LoadFromCss(string css)
    static TailwindStyleDefinitions LoadFromFile(string path)
    static TailwindStyleDefinitions LoadFromJson(string json)
    static TailwindStyleDefinitions LoadFromStream(Stream stream)
  sealed class TailwindStyleDefinitions
    ctor()
    ctor(TailwindColorDefinitions colors, TailwindFontDefinitions fonts = null)
    TailwindColorDefinitions Colors { get;  init; }
    TailwindFontDefinitions Fonts { get;  init; }
    void Validate()
  sealed class TailwindThemeDefinition
    ctor(IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> colorScales, IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> colors, IReadOnlyDictionary<string, string> boxShadow, IReadOnlyDictionary<string, string> shadowPalette, IReadOnlyDictionary<string, string> focusRing, IReadOnlyDictionary<string, string> borderRadius, IReadOnlyDictionary<string, string> backdropBlur, IReadOnlyDictionary<string, string> fontFamily, IReadOnlyDictionary<string, string> fontWeight, IReadOnlyDictionary<string, TailwindFontSize> fontSize)
    IReadOnlyDictionary<string, string> BackdropBlur { get; }
    IReadOnlyDictionary<string, string> BorderRadius { get; }
    IReadOnlyDictionary<string, string> BoxShadow { get; }
    IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> ColorScales { get; }
    IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> Colors { get; }
    IReadOnlyDictionary<string, string> FocusRing { get; }
    IReadOnlyDictionary<string, string> FontFamily { get; }
    IReadOnlyDictionary<string, TailwindFontSize> FontSize { get; }
    IReadOnlyDictionary<string, string> FontWeight { get; }
    IReadOnlyDictionary<string, string> ShadowPalette { get; }
  static class ThemeEmitter
    static string Emit(IDictionary<string, string> vars, string themeName = null)
  enum ThemeSelectorStrategy
    Attribute
    Class
  static class ThemeToTailwindConverter
    static TailwindDesignTokenResult Convert(CanvasDesignTokenDocument document)
  static class ThemeVars
    static bool VariableFallbacksEnabled { get;  set; }
    static string Var(string name, string fallback = null)
  static class TransformCombiner
    static List<TailwindDescription> Combine(List<TailwindDescription> classes)
    static Dictionary<string, string> ComposeForMotion(List<TailwindDescription> classes)
  enum Unit
    Px
    Rem
    Em
    Percent
    Vw
    Vh
    Vmin
    Vmax
    Svw
    Svh
    Lvw
    Lvh
    Dvw
    Dvh
    Cqw
    Cqh
    Cqi
    Cqb
    Cqmin
    Cqmax
    Svb
    Svi
    Lvb
    Lvi
    Dvb
    Dvi
    Svmin
    Svmax
    Lvmin
    Lvmax
    Dvmin
    Dvmax
    Ch
    Ex
    Cm
    Mm
    In
    Pt
    Pc
    Ms
    S
    Deg
    Rad
    Turn
    None
    Unknown
  static class Utilities
    static Dictionary<string, Dictionary<string, string>> Accent(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> AccentColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Align(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> AlignContent(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> AlignItems(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> AlignSelf(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Animate(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Antialiased(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Appearance(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Aspect(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> AutoCols(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> AutoRows(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BackdropBlur(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BackdropBrightness(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BackdropContrast(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BackdropFilter(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BackdropFilterNone(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BackdropGrayscale(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BackdropHueRotate(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BackdropInvert(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BackdropOpacity(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BackdropSaturate(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BackdropSepia(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BackgroundBlend(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BackgroundColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Basis(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BgAuto(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgBottom(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgCenter(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgClipBorder(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgClipContent(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgClipPadding(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgClipText(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgContain(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgCover(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgFixed(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgGradientToB(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BgGradientToBl(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BgGradientToBr(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BgGradientToL(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BgGradientToR(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BgGradientToT(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BgGradientToTl(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BgGradientToTr(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BgImage(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BgLeft(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgLeftBottom(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgLeftTop(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgLinear(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BgLinearToB(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgLinearToBl(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgLinearToBr(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgLinearToL(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgLinearToR(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgLinearToT(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgLinearToTl(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgLinearToTr(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgLocal(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgNoRepeat(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgOriginBorder(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgOriginContent(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgOriginPadding(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgPosition(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BgRepeat(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgRepeatRound(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgRepeatSpace(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgRepeatX(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgRepeatY(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgRight(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgRightBottom(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgRightTop(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgScroll(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BgSize(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BgTop(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Block(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Blur(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Border(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderB(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderBColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderCollapse(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BorderColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderE(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderEColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderL(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderLColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderR(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderRColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderRadius(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderS(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderSColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderSeparate(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> BorderSpacing(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderSpacingX(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderSpacingY(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderStyle(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderT(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderTColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderWidth(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderX(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderXColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderY(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BorderYColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Bottom(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BoxDecoration(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BoxSizing(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Break(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BreakAfter(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BreakBefore(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> BreakInside(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Brightness(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Capitalize(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> CaptionBottom(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> CaptionTop(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Caret(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> CaretColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Clear(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Collapse(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> ColorScheme(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Columns(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Container(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Content(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Contents(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Contrast(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Cursor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> DecorationColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> DecorationNone(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> DecorationStyle(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> DecorationThickness(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Delay(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> DiagonalFractions(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> DivideColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> DivideStyle(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> DivideX(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> DivideXReverse(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> DivideY(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> DivideYReverse(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> DropShadow(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Duration(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Ease(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> End(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> FieldSizing(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Fill(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Filter(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> FilterNone(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Flex1(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> FlexAuto(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> FlexCol(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> FlexColReverse(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> FlexDisplay(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> FlexInitial(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> FlexNoWrap(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> FlexNone(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> FlexRow(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> FlexRowReverse(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> FlexWrap(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> FlexWrapReverse(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Float(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> FlowRoot(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> FontFamily(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> FontPalette(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> FontPaletteValues(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> FontSize(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> FontStretch(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> FontWeight(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ForcedColorAdjust(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Gap(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GapX(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GapY(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GradientFrom(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GradientTo(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GradientVia(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GradientViaNone(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Grayscale(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GridCols(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GridColumn(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GridColumnEnd(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GridColumnSpan(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GridColumnStart(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GridDisplay(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> GridFlow(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GridRow(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GridRowEnd(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GridRowSpan(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GridRowStart(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> GridRows(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Grow(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Grow0(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Height(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Hidden(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> HueRotate(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Hyphens(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Indent(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Inline(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> InlineBlock(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> InlineFlex(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> InlineGrid(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> InlineTable(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Inset(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> InsetBlock(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> InsetBlockEnd(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> InsetBlockStart(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> InsetInline(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> InsetInlineEnd(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> InsetInlineStart(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> InsetRing(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> InsetX(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> InsetY(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Invert(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Invisible(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Isolate(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> IsolationAuto(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Italic(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> JustifyContent(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> JustifyItems(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> JustifySelf(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Left(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> LetterSpacing(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> LineClamp(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> LineHeight(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> LineThrough(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> LiningNums(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> List(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ListImage(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ListItem(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Lowercase(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> M(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MaskClip(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MaskComposite(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MaskImage(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MaskNoRepeat(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> MaskOrigin(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MaskPosition(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MaskRepeat(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MaskRepeatRound(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MaskRepeatSpace(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MaskRepeatX(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> MaskRepeatY(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> MaskSize(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MaxHeight(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MaxWidth(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Mb(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Me(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MinHeight(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MinWidth(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MixBlend(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Ml(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Motion(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionBind(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionBindEase(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionBindReverse(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> MotionComposition(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionDelay(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionDuration(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionEase(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionFill(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionLetterDelay(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionLoop(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionMap(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionOnce(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerChildren(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerLetter(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerLetterLoop(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerLetterPingPong(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerLetterReverse(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerLetterReverseLoop(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerLine(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerLineLoop(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerLinePingPong(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerLineReverse(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerLineReverseLoop(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerParagraph(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerWord(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerWordLoop(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerWordPingPong(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerWordReverse(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPerWordReverseLoop(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPingPong(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPlayState(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionPriority(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionRange(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionRangeEnd(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionRangeStart(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionRate(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> MotionTimeline(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Mr(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Ms(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Mt(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Mx(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> My(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> NoUnderline(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> NormalCase(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> NormalNums(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> NotItalic(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> NotSrOnly(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Object(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> OldstyleNums(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Opacity(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Order(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Ordinal(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Outline(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> OutlineColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> OutlineNone(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> OutlineOffset(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> OutlineStyle(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> OutlineWidth(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Overflow(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> OverflowX(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> OverflowY(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Overline(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Overscroll(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> OverscrollX(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> OverscrollY(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> P(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Pb(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Pe(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Pl(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> PlaceContent(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> PlaceItems(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> PlaceSelf(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> PointerEvents(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> PosAbsolute(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> PosFixed(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> PosRelative(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> PosStatic(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> PosSticky(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Pr(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ProportionalNums(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Ps(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Pt(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Px(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Py(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Resize(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Right(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Ring(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RingInset(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> RingOffset(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Rotate(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RotateX(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RotateY(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedB(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedBl(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedBr(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedE(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedEe(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedEs(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedL(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedR(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedS(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedSe(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedSs(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedT(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedTl(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> RoundedTr(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Saturate(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Scale(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScaleX(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScaleY(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollBehavior(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollM(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollMb(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollMe(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollMl(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollMr(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollMs(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollMt(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollMx(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollMy(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollP(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollPb(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollPe(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollPl(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollPr(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollPs(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollPt(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollPx(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollPy(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ScrollTimeline(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Select(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Sepia(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Shadow(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Shrink(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Shrink0(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Size(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> SkewX(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> SkewY(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> SlashedZero(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> SnapAlign(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> SnapAxis(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> SnapStop(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> SnapStrictness(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> SpaceX(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> SpaceXReverse(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> SpaceY(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> SpaceYReverse(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> SrOnly(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> StackedFractions(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Start(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Stroke(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> StrokeDasharray(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> StrokeDashoffset(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> StrokeJoin(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> SubpixelAntialiased(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Table(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TableAuto(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TableCaption(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TableCell(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TableColumn(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TableColumnGroup(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TableFixed(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TableFooterGroup(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TableHeaderGroup(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TableRow(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TableRowGroup(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TabularNums(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TextAlign(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> TextClip(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TextColor(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> TextEllipsis(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> TextShadow(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> TextSize(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> TextWrap(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Top(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Touch(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> TouchPan(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> TouchPinch(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Transform(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> TransformNone(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> TransformOrigin(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Transition(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> TransitionBehavior(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> TransitionNone(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Translate(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> TranslateX(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> TranslateY(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> TranslateZ(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Truncate(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Underline(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> UnderlineOffset(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Uppercase(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Visible(TailwindDescription _)
    static Dictionary<string, Dictionary<string, string>> Whitespace(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> Width(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> WillChange(TailwindDescription cls)
    static Dictionary<string, Dictionary<string, string>> ZIndex(TailwindDescription cls)
  class UtilityAttribute : Attribute
    ctor(string prefix)
    string Prefix { get; }
  static class UtilityExec
    static bool HasUtility(string prefix)
    static Dictionary<string, Dictionary<string, string>> Run(TailwindDescription tw)
