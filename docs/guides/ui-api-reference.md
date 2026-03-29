# UI API Reference

## UI Component API Reference

Full API reference for all Ikon.Parallax UI components.

---

# Ikon.Parallax Public API

namespace Ikon.Parallax
  sealed class ActionArgs<T>
    ctor()
    Context ClientContext
    T Value
  sealed class ProfileHistory
    ctor(int maxSamples)
    IReadOnlyList<string> Names { get; }
    long SampleCount { get; }
    ProfileStats GetStats(string name)
    string GetSummary()
    ProfileStats GetTotalStats()
    void Reset()
  struct ProfileScope : IDisposable
    void Dispose()
  sealed class ProfileSession
    ctor()
    IReadOnlyList<string> Names { get; }
    IReadOnlyDictionary<string, double> Timings { get; }
    double TotalMs { get; }
    string GetBreakdown()
    double GetTiming(string name)
    void LogResults()
  struct ProfileStats : IEquatable<ProfileStats>
    ctor(double Avg, double Min, double Max, double Median, double P95, double P99)
    double Avg { get;  init; }
    double Max { get;  init; }
    double Median { get;  init; }
    double Min { get;  init; }
    double P95 { get;  init; }
    double P99 { get;  init; }
  static class Profiler
    static ProfileSession Current { get; }
    static ProfileHistory History { get; }
    static bool IsHistoryPaused { get; }
    static void DisableHistory()
    static void EnableHistory(int maxSamples = 1000)
    static ProfileScope Measure(string name)
    static void PauseHistory()
    static void ResetHistory()
    static void ResumeHistory()
  class UI
    ctor(IAppBase host, ITheme theme)
    bool EnableProfiling { get;  set; }
    bool EnableSubtreeCaching { get;  set; }
    void Root(string[] style = null, Action<UIView> content = null, string styleId = null)
  class UIView
    string DefaultIconLibrary { get; }
    void AddNode(string type, Dictionary<string, object> props, List<UIViewNode> children = null, string key = null, string[] style = null, string styleId = null, string file = "", int line = 0)
    string CreateAction<T>(Func<ActionArgs<T>, Task> callback)
    string RegisterPayload(byte[] data, string mimeType)
  sealed class UIViewNode
    ctor(string type, Guid viewId, Dictionary<string, object> props, List<UIViewNode> children = null, string key = null, IReadOnlyList<string> styleIds = null, ulong parentPathHash = 0, IReadOnlyCollection<IReadOnlyList<string>> styleIdProps = null, string file = "", int line = 0)
    List<UIViewNode> Children { get; }
    string ContentFingerprint { get; }
    string Id { get; }
    int IdHash { get; }
    static bool IncludeSourceMarkers { get;  set; }
    Dictionary<string, object> Props { get; }
    string SourceMarker { get; }
    string StableHint { get; }
    IReadOnlyList<string> StyleIds { get; }
    string Type { get; }

namespace Ikon.Parallax.Components.Charts
  class AxisConfig
    ctor()
    string Legend { get;  set; }
    int? LegendOffset { get;  set; }
    int? TickPadding { get;  set; }
    int? TickRotation { get;  set; }
    int? TickSize { get;  set; }
  enum BarGroupMode
    Stacked
    Grouped
  enum BarLayout
    Vertical
    Horizontal
  class ChartAxisStyle : IEquatable<ChartAxisStyle>
    ctor()
    string DomainColor { get;  init; }
    ChartTextStyle Legend { get;  init; }
    string TickColor { get;  init; }
    ChartTextStyle TickLabel { get;  init; }
  class ChartClickArgs
    ctor()
    string Id { get;  set; }
    string IndexValue { get;  set; }
    string SerieId { get;  set; }
    object Value { get;  set; }
  enum ChartColorScheme
    Nivo
    Category10
    Accent
    Dark2
    Paired
    Pastel1
    Pastel2
    Set1
    Set2
    Set3
    Tableau10
    BrownBlueGreen
    PurpleRedGreen
    PinkYellowGreen
    PurpleOrange
    RedBlue
    RedGrey
    RedYellowBlue
    RedYellowGreen
    Spectral
    Blues
    Greens
    Greys
    Oranges
    Purples
    Reds
    BlueGreen
    BluePurple
    GreenBlue
    OrangeRed
    PurpleBlueGreen
    PurpleBlue
    PurpleRed
    RedPurple
    YellowGreenBlue
    YellowGreen
    YellowOrangeBrown
    YellowOrangeRed
  class ChartCrosshairStyle : IEquatable<ChartCrosshairStyle>
    ctor()
    string LineColor { get;  init; }
    string LineDashArray { get;  init; }
    int? LineWidth { get;  init; }
  static class ChartExtensions
    static void BarChart(UIView view, string[] style = null, IEnumerable<Dictionary<string, object>> data = null, IEnumerable<string> keys = null, string indexBy = null, BarGroupMode? groupMode = null, BarLayout? layout = null, ScaleType? valueScale = null, ScaleType? indexScale = null, bool? reverse = null, double? minValue = null, double? maxValue = null, double? padding = null, double? innerPadding = null, ChartMargin margin = null, AxisConfig axisTop = null, AxisConfig axisRight = null, AxisConfig axisBottom = null, AxisConfig axisLeft = null, bool? enableGridX = null, bool? enableGridY = null, bool? enableLabel = null, string labelTextColor = null, IEnumerable<LegendConfig> legends = null, IEnumerable<string> colors = null, ChartColorScheme? colorScheme = null, ChartTheme theme = null, string borderColor = null, double? borderRadius = null, double? borderWidth = null, bool? isInteractive = null, Func<ChartClickArgs, Task> onClick = null, string styleId = null, string key = null, string file = "", int line = 0)
    static void LineChart(UIView view, string[] style = null, IEnumerable<LineChartSeries> data = null, ScaleType? xScaleType = null, ScaleType? yScaleType = null, double? yScaleMin = null, double? yScaleMax = null, bool? yScaleStacked = null, ChartMargin margin = null, AxisConfig axisTop = null, AxisConfig axisRight = null, AxisConfig axisBottom = null, AxisConfig axisLeft = null, bool? enableGridX = null, bool? enableGridY = null, bool? enablePoints = null, int? pointSize = null, string pointColor = null, string pointBorderColor = null, int? pointBorderWidth = null, bool? enableArea = null, double? areaOpacity = null, double? areaBaselineValue = null, bool? enableCrosshair = null, CrosshairType? crosshairType = null, LineCurve? curve = null, IEnumerable<LegendConfig> legends = null, IEnumerable<string> colors = null, ChartColorScheme? colorScheme = null, ChartTheme theme = null, double? lineWidth = null, bool? isInteractive = null, bool? useMesh = null, Func<ChartClickArgs, Task> onClick = null, string styleId = null, string key = null, string file = "", int line = 0)
    static void PieChart(UIView view, string[] style = null, IEnumerable<PieChartDatum> data = null, double? innerRadius = null, double? padAngle = null, double? cornerRadius = null, double? startAngle = null, double? endAngle = null, bool? sortByValue = null, ChartMargin margin = null, bool? enableArcLabels = null, string arcLabelsTextColor = null, double? arcLabelsSkipAngle = null, bool? enableArcLinkLabels = null, string arcLinkLabelsTextColor = null, double? arcLinkLabelsSkipAngle = null, double? arcLinkLabelsThickness = null, string arcLinkLabelsColor = null, double? activeOuterRadiusOffset = null, IEnumerable<LegendConfig> legends = null, IEnumerable<string> colors = null, ChartColorScheme? colorScheme = null, ChartTheme theme = null, string borderColor = null, double? borderWidth = null, bool? isInteractive = null, Func<ChartClickArgs, Task> onClick = null, string styleId = null, string key = null, string file = "", int line = 0)
  class ChartGridStyle : IEquatable<ChartGridStyle>
    ctor()
    string LineColor { get;  init; }
    string LineDashArray { get;  init; }
    int? LineWidth { get;  init; }
  class ChartLabelsStyle : IEquatable<ChartLabelsStyle>
    ctor()
    ChartTextStyle Text { get;  init; }
  class ChartLegendStyle : IEquatable<ChartLegendStyle>
    ctor()
    ChartTextStyle Text { get;  init; }
    ChartTextStyle Title { get;  init; }
  class ChartMargin
    ctor()
    int? Bottom { get;  set; }
    int? Left { get;  set; }
    int? Right { get;  set; }
    int? Top { get;  set; }
  class ChartTextStyle : IEquatable<ChartTextStyle>
    ctor()
    string Color { get;  init; }
    string FontFamily { get;  init; }
    int? FontSize { get;  init; }
  class ChartTheme : IEquatable<ChartTheme>
    ctor()
    ChartAxisStyle Axis { get;  init; }
    ChartColorScheme? ColorScheme { get;  init; }
    string[] Colors { get;  init; }
    ChartCrosshairStyle Crosshair { get;  init; }
    ChartGridStyle Grid { get;  init; }
    ChartLabelsStyle Labels { get;  init; }
    ChartLegendStyle Legends { get;  init; }
    ChartTextStyle Text { get;  init; }
    ChartTooltipStyle Tooltip { get;  init; }
  static class ChartThemes
    static ChartTheme DefaultDark { get; }
    static ChartTheme DefaultLight { get; }
  class ChartTooltipStyle : IEquatable<ChartTooltipStyle>
    ctor()
    string BackgroundColor { get;  init; }
    string BorderColor { get;  init; }
    int? BorderRadius { get;  init; }
    ChartTextStyle Text { get;  init; }
  enum CrosshairType
    X
    Y
    TopLeft
    Top
    TopRight
    Right
    BottomRight
    Bottom
    BottomLeft
    Left
    Cross
  class LegendConfig
    ctor()
    string Anchor { get;  set; }
    string Direction { get;  set; }
    int? ItemHeight { get;  set; }
    int? ItemWidth { get;  set; }
    int? ItemsSpacing { get;  set; }
    int? SymbolSize { get;  set; }
    int? TranslateX { get;  set; }
    int? TranslateY { get;  set; }
  class LineChartPoint
    object X { get;  set; }
    object Y { get;  set; }
  class LineChartSeries
    string Color { get;  set; }
    IEnumerable<LineChartPoint> Data { get;  set; }
    string Id { get;  set; }
  enum LineCurve
    Linear
    MonotoneX
    Step
    StepBefore
    StepAfter
    Cardinal
    Basis
  class PieChartDatum
    string Color { get;  set; }
    string Id { get;  set; }
    string Label { get;  set; }
    double Value { get;  set; }
  enum ScaleType
    Point
    Linear
    Time
    Log

namespace Ikon.Parallax.Components.DataTable
  class Cell : IEquatable<Cell>
    ctor()
    string ActionId { get;  init; }
    CellAction[] Actions { get;  init; }
    bool? Disabled { get;  init; }
    string Label { get;  init; }
    string[] Style { get;  init; }
    string Type { get;  init; }
    string Value { get;  init; }
    string Variant { get;  init; }
    static Cell Action(string label, string actionId, string[] style = null)
    static Cell ActionGroup(CellAction[] actions)
    static Cell Badge(string value, string variant = null, string[] style = null)
    static Cell Checkbox(bool checked, string actionId, string[] style = null, bool disabled = false)
    static Cell Text(string value, string[] style = null)
  class CellAction : IEquatable<CellAction>
    ctor(string Label, string ActionId, string[] Style = null, string Icon = null)
    string ActionId { get;  init; }
    string Icon { get;  init; }
    string Label { get;  init; }
    string[] Style { get;  init; }
  class DataTableColumn : IEquatable<DataTableColumn>
    ctor(string Header, string Width = null, int Flex = 0, ColumnAlign Align = Left, string MinWidth = null, bool Wrap = false)
    ColumnAlign Align { get;  init; }
    int Flex { get;  init; }
    string Header { get;  init; }
    string MinWidth { get;  init; }
    string Width { get;  init; }
    bool Wrap { get;  init; }
  static class DataTableExtensions
    static void DataTable(UIView view, DataTableColumn[] columns, DataTableRow[] rows, int totalCount, int pageIndex, int pageSize, Func<int, Task> onPageChange = null, Func<string, Task> onRowClick = null, Func<string, Task> onActionClick = null, Action<UIView> emptyContent = null, int[] columnWidths = null, Func<string, Task> onColumnResize = null, string[] style = null, string[] headerStyle = null, string[] rowStyle = null, string[] cellStyle = null, string[] headerCellStyle = null, string[] dataCellStyle = null, string[] paginationStyle = null, string[] paginationButtonStyle = null, string[] pageNumberStyle = null, string[] pageNumberActiveStyle = null, string[] emptyStyle = null, string[] actionButtonStyle = null, string prevLabel = null, string nextLabel = null, string pageLabel = null, string key = null, string file = "", int line = 0)
  class DataTableRow : IEquatable<DataTableRow>
    ctor(string Id, Cell[] Cells)
    Cell[] Cells { get;  init; }
    string Id { get;  init; }

namespace Ikon.Parallax.Components.ImageEditor
  static class ImageEditorExtensions
    static void ImageEditorCanvas(UIView view, string[] style = null, string src = null, int? brushWidth = null, string brushColor = null, string tool = null, double? zoom = null, Func<ImageEditorSaveArgs, Task> onSave = null, Func<ImageEditorHistoryArgs, Task> onHistoryChange = null, int? triggerSave = null, int? triggerUndo = null, int? triggerRedo = null, string styleId = null, string key = null, string file = "", int line = 0)
  sealed class ImageEditorHistoryArgs : IEquatable<ImageEditorHistoryArgs>
    ctor(bool CanUndo, bool CanRedo)
    bool CanRedo { get;  init; }
    bool CanUndo { get;  init; }
  sealed class ImageEditorSaveArgs : IEquatable<ImageEditorSaveArgs>
    ctor(string ImageData)
    string ImageData { get;  init; }

namespace Ikon.Parallax.Components.Rive
  enum RiveAlignment
    Center
    TopLeft
    TopCenter
    TopRight
    CenterLeft
    CenterRight
    BottomLeft
    BottomCenter
    BottomRight
  sealed class RiveColor
    ctor()
    int B { get;  init; }
    int G { get;  init; }
    int R { get;  init; }
  sealed class RiveEventData
    ctor()
    double? Delay { get;  init; }
    string Name { get;  init; }
    Dictionary<string, JsonElement> Properties { get;  init; }
    RiveEventProperties Props { get; }
    string Target { get;  init; }
    int? Type { get;  init; }
    string Url { get;  init; }
  sealed class RiveEventProperties
    ctor(Dictionary<string, JsonElement> properties)
    bool GetBool(string key, bool defaultValue = false)
    double GetDouble(string key, double defaultValue = 0)
    int GetInt(string key, int defaultValue = 0)
    string GetString(string key, string defaultValue = "")
  static class RiveExtensions
    static void RiveCanvas(UIView view, string[] style = null, string source = null, IEnumerable<string> stateMachines = null, RiveViewModel viewModel = null, IEnumerable<RiveTrigger> triggers = null, Func<RiveEventData, Task> onEvent = null, RiveFit? layoutFit = null, RiveAlignment? layoutAlignment = null, bool? autoplay = null, bool? useOffscreenRenderer = null, bool? autoBind = null, bool? enableMultiTouch = null, bool? dispatchPointerExit = null, bool? isTouchScrollEnabled = null, bool? shouldDisableRiveListeners = null, IEnumerable<RiveKeyboardBinding> keyboardBindings = null, string backgroundColor = null, string width = null, string height = null, string styleId = null, string key = null, string file = "", int line = 0)
  enum RiveFit
    Contain
    Cover
    Fill
    FitWidth
    FitHeight
    None
    ScaleDown
    Layout
  static class RiveKeyboard
    static RiveKeyboardBinding Boolean(RiveKeyboardKey key, string inputName)
    static RiveKeyboardBinding Trigger(RiveKeyboardKey key, string inputName)
  sealed class RiveKeyboardBinding
    ctor()
    string InputName { get;  init; }
    RiveKeyboardKey Key { get;  init; }
    RiveKeyboardBindingKind Kind { get;  init; }
  enum RiveKeyboardBindingKind
    Boolean
    Trigger
  enum RiveKeyboardKey
    ArrowUp
    ArrowDown
    ArrowLeft
    ArrowRight
  sealed class RiveTrigger
    ctor(string name)
    string Name { get; }
    long Sequence { get; }
    void Fire()
  sealed class RiveViewModel
    ctor()
    RiveViewModel Boolean(string name, bool? value)
    RiveViewModel Color(string name, int r, int g, int b)
    RiveViewModel Enum(string name, int? value)
    RiveViewModel Number(string name, double? value)
    RiveViewModel String(string name, string value)

namespace Ikon.Parallax.Components.Standard
  static class AccessibilityExtensions
    static void AccessibleIcon(UIView view, string[] style = null, string label = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void VisuallyHidden(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
  class ActionEvent : IEquatable<ActionEvent>
    ctor(string ActionType, bool Success)
    string ActionType { get;  init; }
    bool Success { get;  init; }
  class ActionEventConverter : JsonConverter<ActionEvent>
    ctor()
    override ActionEvent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    override void Write(Utf8JsonWriter writer, ActionEvent value, JsonSerializerOptions options)
  enum ActionKind
    Unknown
    CaptureImage
    CopyToClipboard
    DownloadFile
    ExitFullscreen
    GetLocation
    PickContacts
    RequestFullscreen
    Share
    ShowNotification
  abstract class ActionOptions : IEquatable<ActionOptions>
  enum ActivationMode
    Automatic
    Manual
  enum Align
    Start
    Center
    End
  sealed class CaptureImageActionOptions : ActionOptions, IEquatable<CaptureImageActionOptions>
    ctor()
    CaptureImageConstraints Constraints { get;  init; }
    ClientImageCaptureFormat? Format { get;  init; }
    int? Height { get;  init; }
    double? Quality { get;  init; }
    int? Width { get;  init; }
  sealed class CaptureImageConstraints : IEquatable<CaptureImageConstraints>
    ctor()
    string DeviceId { get;  init; }
  enum CheckedState
    Unchecked
    Checked
    Indeterminate
  enum CollisionDetection
    ClosestCenter
    ClosestCorners
    RectIntersection
    PointerWithin
  enum ColumnAlign
    Left
    Center
    Right
  sealed class ContactsActionEvent : ActionEvent, IEquatable<ContactsActionEvent>
    ctor(bool Success, IReadOnlyList<ClientContact> Contacts)
    IReadOnlyList<ClientContact> Contacts { get;  init; }
  static class ContainerExtensions
    static void Box(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<Task> onClick = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Column(UIView view, string[] style = null, string styleId = null, string key = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Flex(UIView view, string[] style = null, string styleId = null, string key = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Grid(UIView view, string[] style = null, string styleId = null, string key = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Layer(UIView view, string[] style = null, string styleId = null, string key = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Row(UIView view, string[] style = null, string styleId = null, string key = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Stack(UIView view, string[] style = null, string styleId = null, string key = null, Action<UIView> content = null, string file = "", int line = 0)
  class ContentGridColumn : IEquatable<ContentGridColumn>
    ctor(string Header, string Width = null, int Flex = 0, ColumnAlign Align = Left)
    ColumnAlign Align { get;  init; }
    int Flex { get;  init; }
    string Header { get;  init; }
    string Width { get;  init; }
  static class ContentGridExtensions
    static void ContentGrid(UIView view, ContentGridColumn[] columns, Action<UIView> content = null, string[] style = null, string[] headerStyle = null, string key = null, string file = "", int line = 0)
  sealed class CopyToClipboardActionOptions : ActionOptions, IEquatable<CopyToClipboardActionOptions>
    string Text { get;  init; }
  static class CoreExtensions
    static void ActionButton(UIView view, string[] style = null, ActionKind action = Unknown, string label = null, ActionOptions options = null, bool? disabled = null, string className = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<ActionEvent, Task> onActionComplete = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Button(UIView view, string[] style = null, string text = null, string label = null, bool? disabled = null, string href = null, string type = null, string target = null, string rel = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<Task> onClick = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Heading(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Icon(UIView view, string[] style = null, string name = null, string library = null, string className = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Markdown(UIView view, string[] style = null, string content = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, string file = "", int line = 0)
    static void Text(UIView view, string[] style = null, string text = null, string href = null, string target = null, string rel = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Toggle(UIView view, string[] style = null, bool? pressed = null, bool? defaultPressed = null, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<bool, Task> onPressedChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void ToggleGroupItem(UIView view, string[] style = null, string value = null, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void ToggleGroupMultiple(UIView view, string[] style = null, IReadOnlyList<string> value = null, IReadOnlyList<string> defaultValue = null, bool? rovingFocus = true, bool loop = true, Orientation orientation = Horizontal, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<IReadOnlyList<string>, Task> onValueChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void ToggleGroupSingle(UIView view, string[] style = null, string value = null, string defaultValue = null, bool? rovingFocus = true, bool loop = true, Orientation orientation = Horizontal, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<string, Task> onValueChange = null, Action<UIView> content = null, string file = "", int line = 0)
  enum Dir
    Ltr
    Rtl
  static class DisclosureExtensions
    static void AccordionContent(UIView view, string[] style = null, bool? forceMount = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void AccordionHeader(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void AccordionItem(UIView view, string[] style = null, string value = null, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void AccordionMultiple(UIView view, string[] style = null, IReadOnlyList<string> value = null, IReadOnlyList<string> defaultValue = null, Orientation orientation = Vertical, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<IReadOnlyList<string>, Task> onValueChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void AccordionSingle(UIView view, string[] style = null, string value = null, string defaultValue = null, bool? collapsible = null, Orientation orientation = Vertical, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<string, Task> onValueChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void AccordionTrigger(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Collapsible(UIView view, string[] style = null, bool? open = null, bool? defaultOpen = null, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<bool, Task> onOpenChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void CollapsibleContent(UIView view, string[] style = null, bool? forceMount = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void CollapsibleTrigger(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
  sealed class DownloadFileActionOptions : ActionOptions, IEquatable<DownloadFileActionOptions>
    ctor()
    byte[] Data { get;  init; }
    string Filename { get;  init; }
    string MimeType { get;  init; }
    string Url { get;  init; }
  static class DragAndDropExtensions
    static void DndContext(UIView view, string[] style = null, CollisionDetection collisionDetection = ClosestCenter, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<DragStartArgs, Task> onDragStart = null, Func<DragMoveArgs, Task> onDragMove = null, Func<DragOverArgs, Task> onDragOver = null, Func<DragEndArgs, Task> onDragEnd = null, Func<Task> onDragCancel = null, Action<UIView> content = null, string file = "", int line = 0)
    static void DragOverlay(UIView view, string[] style = null, bool? dropAnimation = true, string activeDragId = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Draggable(UIView view, string[] style = null, string id = null, bool? disabled = null, bool? hideOnDrag = null, object data = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Droppable(UIView view, string[] style = null, string id = null, bool? disabled = null, object data = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void SortableContext(UIView view, string[] style = null, IReadOnlyList<string> items = null, SortStrategy strategy = VerticalList, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void SortableItem(UIView view, string[] style = null, string id = null, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void SortableList(UIView view, IReadOnlyList<string> items = null, SortStrategy strategy = VerticalList, CollisionDetection collisionDetection = ClosestCenter, Func<SortableReorderArgs, Task> onReorder = null, Func<DragStartArgs, Task> onDragStart = null, Action<UIView, string> itemContent = null, string[] listStyle = null, string[] itemStyle = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, string file = "", int line = 0)
  sealed class DragCancelArgs : IEquatable<DragCancelArgs>
    ctor(string ActiveId)
    string ActiveId { get;  init; }
  sealed class DragEndArgs : IEquatable<DragEndArgs>
    ctor(string ActiveId, string OverId)
    string ActiveId { get;  init; }
    string OverId { get;  init; }
  sealed class DragMoveArgs : IEquatable<DragMoveArgs>
    ctor(string ActiveId, double DeltaX, double DeltaY)
    string ActiveId { get;  init; }
    double DeltaX { get;  init; }
    double DeltaY { get;  init; }
  sealed class DragOverArgs : IEquatable<DragOverArgs>
    ctor(string ActiveId, string OverId)
    string ActiveId { get;  init; }
    string OverId { get;  init; }
  sealed class DragStartArgs : IEquatable<DragStartArgs>
    ctor(string ActiveId)
    string ActiveId { get;  init; }
  sealed class EscapeKeyDownArgs : IEquatable<EscapeKeyDownArgs>
    ctor()
  static class FileUploadExtensions
    static void FileUpload(UIView view, string[] style = null, string[] accept = null, bool? multiple = null, long? maxFileSize = null, bool? disabled = null, bool? allowPaste = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<FileUploadPreStartArgs, Task<FileUploadPreStartResult>> onUploadPreStart = null, Func<FileUploadStartArgs, Task<FileUploadStartResult>> onUploadStart = null, Func<FileUploadProgressArgs, Task> onUploadProgress = null, Func<FileUploadCompleteArgs, Task> onUploadComplete = null, Func<FileUploadErrorArgs, Task> onUploadError = null, Func<FileUploadChunkArgs, Task> onChunkReceived = null, Action<UIView> content = null, string file = "", int line = 0)
    static void FileUploadZone(UIView view, string[] accept = null, bool? multiple = null, long? maxFileSize = null, bool? disabled = null, bool? allowPaste = null, Func<FileUploadPreStartArgs, Task<FileUploadPreStartResult>> onUploadPreStart = null, Func<FileUploadStartArgs, Task<FileUploadStartResult>> onUploadStart = null, Func<FileUploadProgressArgs, Task> onUploadProgress = null, Func<FileUploadCompleteArgs, Task> onUploadComplete = null, Func<FileUploadErrorArgs, Task> onUploadError = null, Func<FileUploadChunkArgs, Task> onChunkReceived = null, Func<bool, Task> onDragActiveChange = null, Action<UIView> content = null, string[] zoneStyle = null, string[] activeStyle = null, string activeStyleId = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, string file = "", int line = 0)
  static class FocusHintExtensions
    static void FocusHint(UIView view, FocusHintProps props, string key = null, Guid? targetViewId = null)
  sealed class FocusHintProps : IEquatable<FocusHintProps>
    ctor()
    TimeSpan? Cooldown { get;  init; }
    bool FocusOnly { get;  init; }
    FocusPriority Priority { get;  init; }
    int Ranking { get;  init; }
  sealed class FocusOutsideArgs : IEquatable<FocusOutsideArgs>
    ctor(string TargetId)
    string TargetId { get;  init; }
  enum FocusPriority
    Polite
    Assertive
  static class FormExtensions
    static void Checkbox(UIView view, string[] style = null, bool? checked = null, bool? defaultChecked = null, bool? required = null, bool? disabled = null, string name = null, string value = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<bool, Task> onCheckedChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Checkbox(UIView view, string[] style = null, CheckedState? checkedState = null, CheckedState? defaultCheckedState = null, bool? required = null, bool? disabled = null, string name = null, string value = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<CheckedState, Task> onCheckedStateChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void CheckboxIndicator(UIView view, string[] style = null, bool? forceMount = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Form(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<Task> onClearServerErrors = null, Action<UIView> content = null, string file = "", int line = 0)
    static void FormControl(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void FormField(UIView view, string[] style = null, string name = null, bool? serverInvalid = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void FormLabel(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void FormMessage(UIView view, string[] style = null, FormMessageMatch? match = null, bool? forceMatch = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void FormSubmit(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Label(UIView view, string[] style = null, string htmlFor = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void RadioGroup(UIView view, string[] style = null, string value = null, string defaultValue = null, bool? required = null, bool? disabled = null, bool loop = true, Orientation orientation = Vertical, string name = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<string, Task> onValueChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void RadioGroupIndicator(UIView view, string[] style = null, bool? forceMount = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void RadioGroupItem(UIView view, string[] style = null, string value = null, bool? disabled = null, bool? required = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Slider(UIView view, string[] style = null, IReadOnlyList<double> value = null, IReadOnlyList<double> defaultValue = null, double? min = null, double? max = null, double? step = null, int? minStepsBetweenThumbs = null, Orientation orientation = Horizontal, bool? disabled = null, bool? inverted = null, string name = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<IReadOnlyList<double>, Task> onValueChange = null, Func<IReadOnlyList<double>, Task> onValueCommit = null, Action<UIView> content = null, string file = "", int line = 0)
    static void SliderRange(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, string file = "", int line = 0)
    static void SliderThumb(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, string file = "", int line = 0)
    static void SliderTrack(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Switch(UIView view, string[] style = null, bool? checked = null, bool? defaultChecked = null, bool? required = null, bool? disabled = null, string name = null, string value = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<bool, Task> onCheckedChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void SwitchThumb(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
  enum FormMessageMatch
    ValueMissing
    TypeMismatch
    TooShort
    TooLong
    PatternMismatch
    RangeUnderflow
    RangeOverflow
    StepMismatch
    BadInput
    CustomError
  sealed class ImageCaptureActionEvent : ActionEvent, IEquatable<ImageCaptureActionEvent>
    ctor(bool Success, string Mime, int Width, int Height, string Data)
    string Data { get;  init; }
    int Height { get;  init; }
    string Mime { get;  init; }
    int Width { get;  init; }
  static class ImageExtensions
    static void Avatar(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void AvatarFallback(UIView view, string[] style = null, int? delayMs = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void AvatarImage(UIView view, string[] style = null, string src = null, string alt = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<Task> onLoadingStatusChange = null, string file = "", int line = 0)
    static void Image(UIView view, string[] style = null, string src = null, AssetUri? assetUri = null, string alt = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<Task> onClick = null, string file = "", int line = 0)
    static void Image(UIView view, string[] style = null, byte[] data = null, string mimeType = null, string alt = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<Task> onClick = null, string file = "", int line = 0)
  static class InputExtensions
    static void OtpField(UIView view, string[] style = null, string value = null, int? maxLength = null, bool autoSubmit = false, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<string, Task> onValueChange = null, Func<Task> onAutoSubmit = null, Action<UIView> content = null, string file = "", int line = 0)
    static void OtpFieldInput(UIView view, string[] style = null, int index = 0, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, string file = "", int line = 0)
    static void PasswordToggleField(UIView view, string[] style = null, bool? visible = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<bool, Task> onVisibilityChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void PasswordToggleFieldIcon(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> visibleIcon = null, Action<UIView> hiddenIcon = null, string file = "", int line = 0)
    static void PasswordToggleFieldInput(UIView view, string[] style = null, string autoComplete = null, string placeholder = null, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, string file = "", int line = 0)
    static void PasswordToggleFieldToggle(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void TextArea(UIView view, string[] style = null, string value = null, string defaultValue = null, string placeholder = null, bool? disabled = null, int? rows = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<string, Task> onValueChange = null, Func<string, Task> onSubmit = null, Func<Context, Task> onSubmitWithContext = null, bool? clearOnSubmit = null, Action<UIView> content = null, string file = "", int line = 0)
    static void TextField(UIView view, string[] style = null, string value = null, string defaultValue = null, string placeholder = null, bool? disabled = null, string type = null, string step = null, string min = null, string max = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<string, Task> onValueChange = null, Func<string, Task> onSubmit = null, bool? clearOnSubmit = null, Action<UIView> content = null, string file = "", int line = 0)
  sealed class InteractOutsideArgs : IEquatable<InteractOutsideArgs>
    ctor(string TargetId)
    string TargetId { get;  init; }
  static class Key
    static string Alt
    static string ArrowDown
    static string ArrowLeft
    static string ArrowRight
    static string ArrowUp
    static string Backspace
    static string Control
    static string Delete
    static string End
    static string Enter
    static string Escape
    static string F1
    static string F10
    static string F11
    static string F12
    static string F2
    static string F3
    static string F4
    static string F5
    static string F6
    static string F7
    static string F8
    static string F9
    static string Home
    static string Meta
    static string PageDown
    static string PageUp
    static string Shift
    static string Space
    static string Tab
  sealed class KeyboardEventArgs : IEquatable<KeyboardEventArgs>
    ctor(string Key, string Code, bool AltKey, bool CtrlKey, bool MetaKey, bool ShiftKey, bool Repeat)
    bool AltKey { get;  init; }
    string Code { get;  init; }
    bool CtrlKey { get;  init; }
    string Key { get;  init; }
    bool MetaKey { get;  init; }
    bool Repeat { get;  init; }
    bool ShiftKey { get;  init; }
  static class KeyboardExtensions
    static void KeyboardListener(UIView view, Func<KeyboardEventArgs, Task> onKeyDown = null, Func<KeyboardEventArgs, Task> onKeyUp = null, IReadOnlyList<string> keys = null, bool? global = true, bool? preventDefault = null, bool? stopPropagation = null, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
  static class LayoutExtensions
    static void AspectRatio(UIView view, string[] style = null, double ratio = 1, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void DirectionProvider(UIView view, string[] style = null, Dir dir = Ltr, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void InfiniteScrollView(UIView view, int threshold = 200, int debounceMs = 100, bool loading = false, bool hasMore = true, ScrollDirection direction = Down, ScrollAreaScrollbars scrollbars = Vertical, Action<UIView> loadingIndicator = null, Func<ScrollNearEndArgs, Task> onNearEnd = null, Action<UIView> content = null, string[] viewportStyle = null, string[] scrollbarStyle = null, string[] thumbStyle = null, string[] rootStyle = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, string file = "", int line = 0)
    static void Progress(UIView view, double? value = null, double? max = null, string variant = null, bool indeterminate = false, Func<double?, string> getValueLabel = null, string[] rootStyle = null, string[] indicatorStyle = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, string file = "", int line = 0)
    static void ScrollArea(UIView view, ScrollAreaScrollbars scrollbars = Vertical, ScrollAreaType type = Hover, int? scrollHideDelay = null, Dir dir = Ltr, bool autoScroll = false, string autoScrollKey = null, Action<UIView> content = null, string[] viewportStyle = null, string[] scrollbarStyle = null, string[] thumbStyle = null, string[] cornerStyle = null, string[] rootStyle = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, string file = "", int line = 0)
    static void Separator(UIView view, string[] style = null, Orientation orientation = Horizontal, bool decorative = true, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, string file = "", int line = 0)
  sealed class LocationActionEvent : ActionEvent, IEquatable<LocationActionEvent>
    ctor(bool Success, double? Latitude, double? Longitude, double? Accuracy)
    double? Accuracy { get;  init; }
    double? Latitude { get;  init; }
    double? Longitude { get;  init; }
  enum MediaCaptureButtonMode
    Hold
    Toggle
  sealed class MediaCaptureEvent : IEquatable<MediaCaptureEvent>
    ctor(string StreamId, string Kind)
    string Kind { get;  init; }
    string StreamId { get;  init; }
  enum MediaCaptureKind
    Audio
    Camera
    Screen
  static class MediaExtensions
    static void AudioUrlPlayer(UIView view, string[] style = null, string url = null, bool? controls = null, bool? autoplay = null, bool? loop = null, bool? muted = null, string preload = null, string className = null, string styleId = null, string key = null, string file = "", int line = 0)
    static void CaptureButton(UIView view, string[] style = null, MediaCaptureKind kind = Audio, string label = null, MediaCaptureButtonMode captureMode = Hold, ClientAudioCaptureOptions audioOptions = null, ClientVideoCaptureOptions videoOptions = null, int? holdReleaseDelayMs = null, bool? disabled = null, string className = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<MediaCaptureEvent, Task> onCaptureStart = null, Func<MediaCaptureEvent, Task> onCaptureStop = null, Action<UIView> content = null, string file = "", int line = 0)
    static void VideoStreamCanvas(UIView view, string[] style = null, string streamId = null, int? width = null, int? height = null, string className = null, string styleId = null, string key = null, string file = "", int line = 0)
    static void VideoUrlPlayer(UIView view, string[] style = null, string url = null, bool? controls = null, bool? autoplay = null, bool? loop = null, bool? muted = null, bool? playsInline = null, string poster = null, int? width = null, int? height = null, string className = null, string styleId = null, string key = null, string file = "", int line = 0)
  static class NavigationExtensions
    static void Menubar(UIView view, string[] style = null, string value = null, string defaultValue = null, Dir dir = Ltr, bool loop = true, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<string, Task> onValueChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void MenubarCheckboxItem(UIView view, string[] style = null, CheckedState checked = Unchecked, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<CheckedState, Task> onCheckedChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void MenubarContent(UIView view, string[] style = null, bool loop = true, Side side = Bottom, Align align = Start, double? sideOffset = null, double? alignOffset = null, bool? forceMount = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void MenubarItem(UIView view, string[] style = null, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<Task> onSelect = null, Action<UIView> content = null, string file = "", int line = 0)
    static void MenubarItemIndicator(UIView view, string[] style = null, bool? forceMount = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void MenubarMenu(UIView view, string[] style = null, string value = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void MenubarRadioGroup(UIView view, string[] style = null, string value = null, string defaultValue = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<string, Task> onValueChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void MenubarRadioItem(UIView view, string[] style = null, string value = null, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void MenubarSeparator(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, string file = "", int line = 0)
    static void MenubarSub(UIView view, string[] style = null, bool? open = null, bool? defaultOpen = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<bool?, Task> onOpenChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void MenubarSubContent(UIView view, string[] style = null, bool loop = true, Side side = Right, Align align = Start, double? sideOffset = null, double? alignOffset = null, bool? forceMount = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void MenubarSubTrigger(UIView view, string[] style = null, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void MenubarTrigger(UIView view, string[] style = null, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void NavigationMenu(UIView view, string[] style = null, string value = null, string defaultValue = null, Orientation orientation = Horizontal, int? delayDuration = null, int? skipDelayDuration = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<string, Task> onValueChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void NavigationMenuContent(UIView view, string[] style = null, bool? forceMount = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void NavigationMenuIndicator(UIView view, string[] style = null, bool? forceMount = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void NavigationMenuItem(UIView view, string[] style = null, string value = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void NavigationMenuLink(UIView view, string[] style = null, bool? active = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<Task> onSelect = null, Action<UIView> content = null, string file = "", int line = 0)
    static void NavigationMenuList(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void NavigationMenuTrigger(UIView view, string[] style = null, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void NavigationMenuViewport(UIView view, string[] style = null, bool? forceMount = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void Toolbar(UIView view, string[] style = null, Orientation orientation = Horizontal, Dir dir = Ltr, bool loop = true, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void ToolbarButton(UIView view, string[] style = null, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<Task> onClick = null, Action<UIView> content = null, string file = "", int line = 0)
    static void ToolbarLink(UIView view, string[] style = null, string href = null, string target = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
    static void ToolbarSeparator(UIView view, string[] style = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, string file = "", int line = 0)
    static void ToolbarToggleGroupMultiple(UIView view, string[] style = null, IReadOnlyList<string> value = null, IReadOnlyList<string> defaultValue = null, bool? rovingFocus = true, bool loop = true, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<IReadOnlyList<string>, Task> onValueChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void ToolbarToggleGroupSingle(UIView view, string[] style = null, string value = null, string defaultValue = null, bool? rovingFocus = true, bool loop = true, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<string, Task> onValueChange = null, Action<UIView> content = null, string file = "", int line = 0)
    static void ToolbarToggleItem(UIView view, string[] style = null, string value = null, bool? disabled = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Action<UIView> content = null, string file = "", int line = 0)
  enum Orientation
    Horizontal
    Vertical
  static class OverlayExtensions
    static void AlertDialog(UIView view, bool? open = null, bool? defaultOpen = null, string title = null, string description = null, string cancelLabel = null, string actionLabel = null, Func<Task> onAction = null, Action<UIView> trigger = null, Action<UIView> contentSlot = null, string[] overlayStyle = null, string overlayStyleId = null, string[] contentStyle = null, string contentStyleId = null, string[] titleStyle = null, string[] descriptionStyle = null, string[] footerStyle = null, string[] cancelStyle = null, string[] actionStyle = null, string[] rootStyle = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<bool?, Task> onOpenChange = null, string file = "", int line = 0)
    static void Dialog(UIView view, bool? open = null, bool? defaultOpen = null, bool? modal = null, Action<UIView> trigger = null, Action<UIView> contentSlot = null, Action<UIView> content = null, string[] overlayStyle = null, string overlayStyleId = null, string[] contentStyle = null, string contentStyleId = null, string[] rootStyle = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<bool?, Task> onOpenChange = null, string file = "", int line = 0)
    static void HoverCard(UIView view, bool? open = null, bool? defaultOpen = null, int? openDelay = null, int? closeDelay = null, Action<UIView> trigger = null, Action<UIView> contentSlot = null, Action<UIView> content = null, string[] contentStyle = null, string contentStyleId = null, string[] rootStyle = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<bool?, Task> onOpenChange = null, string file = "", int line = 0)
    static void Popover(UIView view, bool? open = null, bool? defaultOpen = null, bool? modal = null, Action<UIView> trigger = null, Action<UIView> contentSlot = null, Action<UIView> content = null, string[] contentStyle = null, string contentStyleId = null, string[] rootStyle = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<bool?, Task> onOpenChange = null, string file = "", int line = 0)
    static void Toast(UIView view, ToastType type = Foreground, bool? open = null, bool? defaultOpen = null, int? durationMs = null, bool? forceMount = null, ToastSwipeDirection swipeDirection = Right, int? swipeThreshold = null, string title = null, string description = null, bool? showClose = null, string closeLabel = null, Action<UIView> content = null, string[] toastStyle = null, string[] viewportStyle = null, string[] titleStyle = null, string[] descriptionStyle = null, string[] closeStyle = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<bool?, Task> onOpenChange = null, Func<Task> onEscapeKeyDown = null, Func<Task> onPause = null, Func<Task> onResume = null, Func<ToastSwipeArgs, Task> onSwipeStart = null, Func<ToastSwipeArgs, Task> onSwipeMove = null, Func<ToastSwipeArgs, Task> onSwipeEnd = null, Func<ToastSwipeArgs, Task> onSwipeCancel = null, string file = "", int line = 0)
    static void Tooltip(UIView view, bool? open = null, bool? defaultOpen = null, double? delayDuration = null, double? skipDelayDuration = null, bool? disableHoverableContent = null, Action<UIView> trigger = null, Action<UIView> contentSlot = null, Action<UIView> content = null, string[] contentStyle = null, string contentStyleId = null, string[] rootStyle = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<bool?, Task> onOpenChange = null, string file = "", int line = 0)
  sealed class PickContactsActionOptions : ActionOptions, IEquatable<PickContactsActionOptions>
    ctor()
    bool Multiple { get;  init; }
  sealed class PointerDownOutsideArgs : IEquatable<PointerDownOutsideArgs>
    ctor(string TargetId)
    string TargetId { get;  init; }
  static class QrCodeExtensions
    static void QR(UIView view, string[] style = null, string value = null, int size = 256, string key = null, string file = "", int line = 0)
  static class RoleGatedExtensions
    static void ForAdmin(UIView view, ClientProfiles profiles, Context clientContext, Action<UIView> content)
    static void ForModerator(UIView view, ClientProfiles profiles, Context clientContext, Action<UIView> content)
    static void ForRole(UIView view, ClientProfiles profiles, Context clientContext, UserRole role, Action<UIView> content)
    static void ForRole(UIView view, ClientProfiles profiles, Context clientContext, string role, Action<UIView> content)
    static void ForRoles(UIView view, ClientProfiles profiles, Context clientContext, IEnumerable<UserRole> roles, Action<UIView> content)
  enum ScrollAreaScrollbars
    None
    Vertical
    Horizontal
    Both
  enum ScrollAreaType
    Auto
    Always
    Scroll
    Hover
  enum ScrollDirection
    Down
    Up
  sealed class ScrollNearEndArgs : IEquatable<ScrollNearEndArgs>
    ctor(double ScrollTop, double ScrollHeight, double ClientHeight, string Direction)
    double ClientHeight { get;  init; }
    string Direction { get;  init; }
    double ScrollHeight { get;  init; }
    double ScrollTop { get;  init; }
  static class SelectExtensions
    static void Select(UIView view, IReadOnlyList<SelectOption> options = null, IReadOnlyList<SelectOptionGroup> groups = null, string value = null, string defaultValue = null, string placeholder = null, bool? disabled = null, bool? required = null, bool? open = null, string name = null, string[] triggerStyle = null, string[] contentStyle = null, string[] itemStyle = null, string[] itemIndicatorStyle = null, string indicatorIconName = "check", string[] rootStyle = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<string, Task> onValueChange = null, Func<bool?, Task> onOpenChange = null, string file = "", int line = 0)
  sealed class SelectOption : IEquatable<SelectOption>
    ctor(string Value, string Label, bool Disabled = false)
    bool Disabled { get;  init; }
    string Label { get;  init; }
    string Value { get;  init; }
  sealed class SelectOptionGroup : IEquatable<SelectOptionGroup>
    ctor(string Label, IReadOnlyList<SelectOption> Options)
    string Label { get;  init; }
    IReadOnlyList<SelectOption> Options { get;  init; }
  struct ShaderUniform
    string Type { get; }
    object Value { get; }
    static ShaderUniform Bool(bool value)
    static ShaderUniform Float(float value)
    static ShaderUniform Int(int value)
    static ShaderUniform Vec2(float x, float y)
    static ShaderUniform Vec3(float x, float y, float z)
    static ShaderUniform Vec4(float x, float y, float z, float w)
  static class ShadertoyExtensions
    static void ShadertoyCanvas(UIView view, string[] style = null, string shaderSource = null, int? fps = null, IReadOnlyDictionary<string, ShaderUniform> uniforms = null, bool? enableMouse = null, int? width = null, int? height = null, string styleId = null, string key = null, string file = "", int line = 0)
  sealed class ShareActionOptions : ActionOptions, IEquatable<ShareActionOptions>
    ctor()
    string Text { get;  init; }
    string Title { get;  init; }
    string Url { get;  init; }
  sealed class ShowNotificationActionOptions : ActionOptions, IEquatable<ShowNotificationActionOptions>
    string Body { get;  init; }
    string Icon { get;  init; }
    string Title { get;  init; }
  enum Side
    Top
    Right
    Bottom
    Left
  enum SortStrategy
    VerticalList
    HorizontalList
  sealed class SortableReorderArgs : IEquatable<SortableReorderArgs>
    ctor(string ActiveId, string OverId, int OldIndex, int NewIndex, IReadOnlyList<string> NewOrder)
    string ActiveId { get;  init; }
    int NewIndex { get;  init; }
    IReadOnlyList<string> NewOrder { get;  init; }
    int OldIndex { get;  init; }
    string OverId { get;  init; }
  enum Sticky
    Partial
    Always
  class TabItem : IEquatable<TabItem>
    ctor(string Value, string Label, Action<UIView> Content, bool Disabled = false)
    Action<UIView> Content { get;  init; }
    bool Disabled { get;  init; }
    string Label { get;  init; }
    string Value { get;  init; }
  static class TabsExtensions
    static void Tabs(UIView view, string value = null, string defaultValue = null, Orientation orientation = Horizontal, ActivationMode activationMode = Automatic, IEnumerable<TabItem> tabs = null, string[] listContainerStyle = null, string[] listStyle = null, string[] triggerStyle = null, string[] disabledTriggerStyle = null, string[] contentContainerStyle = null, string[] contentStyle = null, string[] rootStyle = null, string styleId = null, string key = null, IReadOnlyDictionary<string, object> props = null, Func<string, Task> onValueChange = null, string file = "", int line = 0)
  sealed class ToastSwipeArgs : IEquatable<ToastSwipeArgs>
    ctor(ToastSwipeDirection Direction, double DeltaX, double DeltaY)
    double DeltaX { get;  init; }
    double DeltaY { get;  init; }
    ToastSwipeDirection Direction { get;  init; }
  enum ToastSwipeDirection
    Left
    Right
    Up
    Down
  enum ToastType
    Foreground
    Background

namespace Ikon.Parallax.Themes
  interface ITheme
    string Css { get; }
    string DefaultIconLibrary { get; }

namespace Ikon.Parallax.Themes.Default
  static class Accessibility
    static string RequiredLabel(string baseLabel)
    static string NotScreenReaderOnly
    static string ScreenReaderOnly
    static string SkipLink
  static class Accordion
    static string ChevronIcon
    static string Content
    static string ContentInner
    static string Default
    static string Header
    static string Item
    static string Root
    static string Trigger
  static class Alert
    static string Base
    static string Danger
    static string Default
    static string Description
    static string Info
    static string Success
    static string Title
    static string Warning
  static class AlertDialog
    static string Action
    static string Cancel
    static string Content
    static string Default
    static string Description
    static string Footer
    static string Header
    static string Overlay
    static string Title
  static class Accessibility.Aria
    static string Busy
    static string Checked
    static string CurrentPage
    static string CurrentStep
    static string Disabled
    static string Expanded
    static string Invalid
    static string Required
    static string Selected
  static class AspectRatio
    static string Base
    static string Default
    static string PlaceholderContent
  static class Avatar
    static string Base
    static string Default
    static string Fallback
    static string Image
    static string Root
  static class Badge
    static string Base
    static string Danger
    static string Default
    static string DefaultLg
    static string DefaultMd
    static string DefaultSm
    static string Outline
    static string Secondary
    static string Subtle
  static class Tokens.Blur
    static string Lg
    static string Md
    static string Sm
  static class Breadcrumb
    static string Ellipsis
    static string Item
    static string Link
    static string List
    static string Page
    static string Root
    static string Separator
  static class Button
    static string Base
    static string DangerLg
    static string DangerMd
    static string DangerSm
    static string Default
    static string GhostLg
    static string GhostMd
    static string GhostSm
    static string LinkLg
    static string LinkMd
    static string LinkSm
    static string OutlineLg
    static string OutlineMd
    static string OutlineSm
    static string PrimaryLg
    static string PrimaryMd
    static string PrimarySm
    static string SecondaryLg
    static string SecondaryMd
    static string SecondarySm
  static class Card
    static string Base
    static string Content
    static string Default
    static string Elevated
    static string Footer
    static string Glass
    static string GlassSubtle
    static string Header
    static string HeaderRow
    static string Interactive
    static string Lg
    static string Md
    static string Sm
  static class OnSurface.Card
    static string Caption
    static string Muted
    static string Subtle
    static string Text
  static class Chart
    static string Container
    static string ContainerLg
    static string ContainerMd
    static string ContainerSm
    static string ContainerXl
    static string Default
  static class Checkbox
    static string Default
    static string Indicator
    static string Root
  static class Collapsible
    static string Content
    static string Default
    static string Root
    static string Trigger
    static string TriggerIcon
  static class Layout.Column
    static string Center
    static string Default
    static string Lg
    static string Md
    static string Sm
    static string Xl
    static string Xs
  static class Command
    static string Default
    static string Dialog
    static string Empty
    static string Group
    static string GroupHeading
    static string Input
    static string InputWrapper
    static string Item
    static string List
    static string Root
    static string Separator
    static string Shortcut
  static class Container
    static string Full
    static string Lg
    static string Md
    static string Prose
    static string Screen
    static string Sm
    static string Xl
    static string Xl2
    static string Xl3
    static string Xl4
    static string Xl5
    static string Xl6
    static string Xl7
    static string Xs
  static class ContentGrid
    static string Bordered
    static string Cell
    static string CellMuted
    static string Default
    static string Header
  static class DataTable
    static string Cell
    static string DataCell
    static string Default
    static string EmptyState
    static string Header
    static string HeaderCell
    static string PageNumber
    static string PageNumberActive
    static string Pagination
    static string PaginationButton
    static string Row
    static string RowClickable
  static class OnSurface.Default
    static string Caption
    static string Muted
    static string Subtle
    static string Text
  static class Dialog
    static string CloseButton
    static string Content
    static string Description
    static string Footer
    static string Header
    static string Overlay
    static string Title
  static class DragDrop
    static string Container
    static string ContainerHorizontal
    static string DropZone
    static string DropZoneActive
    static string Overlay
    static string OverlayContent
  static class DragDrop.Draggable
    static string Base
    static string Dashed
    static string Default
    static string Disabled
  static class Drawer
    static string Content
    static string Default
    static string Description
    static string Footer
    static string Handle
    static string Header
    static string Overlay
    static string Title
  static class DropdownMenu
    static string CheckboxItem
    static string Content
    static string Group
    static string Item
    static string Label
    static string RadioItem
    static string Separator
    static string Shortcut
    static string SubContent
    static string SubTrigger
  static class DragDrop.Droppable
    static string Base
    static string Default
    static string Disabled
    static string Info
    static string Success
  static class Tokens.Duration
    static string Fast
    static string Instant
    static string Normal
    static string Slow
    static string Slower
  static class Transition.Ease
    static string In
    static string InOut
    static string Linear
    static string Out
  static class FileUpload
    static string FileItem
    static string FileList
    static string FileName
    static string FileSize
    static string RemoveButton
    static string TypeIcon
  static class Accessibility.Focus
    static string HighContrast
    static string None
    static string Sentinel
    static string Within
  static class Tokens.FocusRing
    static string Default
    static string Strong
    static string Subtle
  static class FormField
    static string ErrorText
    static string HelpText
    static string Label
    static string LabelRequired
    static string ParamRow
    static string Root
    static string SuccessText
    static string WarningText
  static class Layout.Grid
    static string Cols2
    static string Cols3
    static string Cols4
  static class Select.Group
    static string Label
    static string Root
  static class Helper
    static string Join(params string[] parts)
  static class HoverCard
    static string Content
    static string Default
  static class Icon
    static string Default
    static string Spinner
    static string SpinnerLg
    static string SpinnerSm
  static class FileUpload.Icon
    static string Base
    static string Brand
    static string Disabled
    static string Error
    static string Info
    static string Success
  static class Input
    static string Base
    static string Default
    static string DefaultLg
    static string DefaultSm
    static string Ghost
    static string Invalid
    static string InvalidLg
    static string InvalidSm
  static class Interaction
    static string HoverCard
    static string HoverGlow
    static string HoverLift
  static class DragDrop.Item
    static string Base
    static string Dashed
    static string Default
    static string Disabled
    static string Dragging
  static class Label
    static string Base
    static string Default
    static string Error
    static string Optional
    static string Required
  static class Layout
    static string Center
    static string Page
    static string RowWrap
    static string Section
    static string SectionBody
    static string SectionHeader
    static string Stretch
  static class Media
    static string CanvasFill
    static string Default
    static string EmptyState
    static string Fill
    static string ImageEmptyState
    static string Mirror
    static string PlaceholderHint
    static string PlaceholderIcon
    static string PlaceholderText
    static string VideoContainer
  static class Menubar
    static string Content
    static string Default
    static string Item
    static string Root
    static string Separator
    static string Trigger
  static class Accessibility.Motion
    static string Reduce
    static string ReduceFade
    static string Respectful
    static string Safe
  static class NavigationMenu
    static string Content
    static string ContentNarrow
    static string ContentPopover
    static string ContentPopoverSide
    static string ContentWide
    static string Default
    static string Indicator
    static string Link
    static string LinkCompact
    static string List
    static string ListVertical
    static string Root
    static string Trigger
    static string TriggerIcon
    static string TriggerIconRotate180
    static string TriggerIconRotate90
  static class OnSurface
  static class Tokens.Opacity
    static string GlassLg
    static string GlassMd
    static string GlassSm
    static string O10
    static string O15
    static string O20
    static string O25
    static string O30
    static string O40
    static string O5
    static string O50
  static class Separator.Orientation
    static string Horizontal
    static string Vertical
  static class OtpField
    static string Default
    static string Input
    static string Root
  static class Page
    static string Base
    static string Default
    static string Gradient
    static string Plain
  static class Pagination
    static string Active
    static string Disabled
    static string Ellipsis
    static string IconStyle
    static string Item
    static string List
    static string Next
    static string Previous
    static string Root
  static class Panel
    static string Fill
    static string Side
    static string Sidebar
    static string SidebarNarrow
    static string Wide
  static class Input.Password
    static string Input
    static string Toggle
    static string Wrapper
  static class Popover
    static string Content
    static string Default
  static class OnSurface.Popover
    static string Caption
    static string Muted
    static string Subtle
    static string Text
  static class Progress
    static string ComposeIndicator(string variant = null, bool indeterminate = false, params string[] overrides)
    static string IndicatorTransform(double value)
    static string Base
    static string Default
    static string Indeterminate
    static string Indicator
    static string Root
  static class Transition.Property
    static string All
    static string Colors
    static string Opacity
    static string Shadow
    static string Transform
  static class RadioGroup
    static string Default
    static string Indicator
    static string Item
    static string Root
    static string RootHorizontal
  static class Tokens.Radius
    static string Full
    static string Lg
    static string Md
    static string None
    static string Sm
    static string Xl
    static string Xl2
  static class AspectRatio.Ratio
    static string Photo
    static string Portrait
    static string Square
    static string Video
    static string Wide
  static class Responsive
    static string CenterToEnd
    static string CenterToLeft
    static string CenterToSpaceBetween
    static string CenterToStart
    static string ColToRow
    static string ColToRowMd
    static string HiddenDesktop
    static string HiddenMobile
    static string HiddenTablet
    static string LeftToCenter
    static string RowToCol
    static string VisibleMobile
    static string VisibleTablet
  static class Layout.Row
    static string Default
    static string InlineCenter
    static string Lg
    static string Md
    static string Sm
    static string SpaceBetween
    static string Xl
    static string Xs
  static class ScrollArea
    static string Bordered
    static string Default
    static string Root
    static string Scrollbar
    static string Thumb
    static string Viewport
  static class Select
    static string Content
    static string Default
    static string Item
    static string ItemIndicator
    static string Label
    static string ScrollButton
    static string Separator
    static string Trigger
    static string TriggerBase
  static class Separator
    static string Base
    static string Horizontal
    static string Vertical
  static class Tokens.Shadow
    static string Lg
    static string Md
    static string None
    static string Sm
    static string Xl
    static string Xl2
  static class Avatar.Shape
    static string Circle
    static string Square
  static class Skeleton.Shape
    static string Circle
    static string Rectangle
    static string Square
  static class Sheet
    static string Base
    static string CloseButton
    static string Default
    static string Description
    static string Footer
    static string Header
    static string Overlay
    static string Title
  static class Sheet.Side
    static string Bottom
    static string Left
    static string Right
    static string Top
  static class Icon.Size
    static string Lg
    static string Md
    static string Sm
    static string Xs
  static class Button.Size
    static string Icon
    static string Lg
    static string Md
    static string Sm
  static class Input.Size
    static string Lg
    static string Md
    static string Sm
  static class Textarea.Size
    static string Lg
    static string Md
    static string Sm
  static class Badge.Size
    static string Lg
    static string Md
    static string Sm
  static class Toggle.Size
    static string Lg
    static string Md
    static string Sm
  static class Select.Size
    static string Lg
    static string Md
    static string Sm
  static class Progress.Size
    static string Lg
    static string Md
    static string Sm
    static string Xs
  static class Avatar.Size
    static string Lg
    static string Md
    static string Sm
    static string Xl
    static string Xl2
    static string Xs
  static class Skeleton.Size
    static string Lg
    static string Md
    static string Sm
    static string Xl
    static string Xs
  static class Skeleton
    static string Avatar
    static string AvatarLg
    static string AvatarSm
    static string Base
    static string Button
    static string Card
    static string Default
    static string Input
    static string Text
    static string TextLg
    static string TextSm
  static class Slider
    static string Default
    static string Range
    static string Root
    static string RootVertical
    static string Thumb
    static string Track
    static string TrackVertical
  static class Drawer.Snap
    static string Full
    static string Half
    static string Quarter
    static string ThreeQuarter
  static class State
    static string Checked
    static string Disabled
    static string Empty
    static string Focusable
    static string Indeterminate
    static string Invalid
    static string Loading
    static string Pending
    static string Pressable
    static string Readonly
    static string Selected
    static string Success
    static string Validating
    static string Warning
  static class Surface
    static string Background
    static string Card
    static string CardElevated
    static string Floating
    static string Glass
    static string GlassCard
    static string Overlay
    static string Popover
  static class Switch
    static string Default
    static string Root
    static string Thumb
  static class Tabs
    static string Content
    static string List
    static string ListVertical
    static string Trigger
    static string TriggerDisabled
  static class Text
    static string Body
    static string BodyStrong
    static string Caption
    static string Code
    static string Display
    static string H1
    static string H2
    static string H3
    static string H4
    static string Label
    static string Link
    static string Muted
    static string Small
  static class Textarea
    static string Base
    static string Default
    static string DefaultLg
    static string DefaultSm
    static string Invalid
  sealed class Theme : ITheme
    ctor()
    string Css { get; }
    string DefaultIconLibrary { get; }
  static class Toast
    static string Action
    static string Base
    static string Close
    static string Default
    static string Description
    static string Title
    static string Viewport
    static string ViewportBottomCenter
  static class Toggle
    static string Base
    static string Default
    static string DefaultLg
    static string DefaultMd
    static string DefaultSm
  static class Tokens
  static class Tone
    static string Danger
    static string Ghost
    static string Info
    static string Link
    static string Muted
    static string Outline
    static string Primary
    static string Secondary
    static string Subtle
    static string Success
    static string Warning
  static class Toolbar
    static string Button
    static string Default
    static string IconStyle
    static string Root
    static string Separator
    static string ToggleGroup
    static string ToggleItem
  static class Tooltip
    static string Content
    static string Default
  static class Transition
    static string Fast
    static string None
    static string Normal
    static string Slow
    static string Slower
  static class Separator.Variant
    static string Default
    static string Strong
    static string Subtle
  static class Button.Variant
    static string Danger
    static string Ghost
    static string Link
    static string Outline
    static string Primary
    static string Secondary
  static class Input.Variant
    static string Default
    static string Error
    static string Success
    static string Warning
  static class Textarea.Variant
    static string Default
    static string Error
    static string Success
    static string Warning
  static class Card.Variant
    static string Default
    static string Elevated
    static string Ghost
    static string Glass
    static string GlassSubtle
    static string Interactive
    static string Outline
    static string Strong
  static class Badge.Variant
    static string Danger
    static string Default
    static string Outline
    static string Secondary
    static string Subtle
  static class Alert.Variant
    static string Danger
    static string Default
    static string Info
    static string Success
    static string Warning
  static class Toggle.Variant
    static string Default
  static class Progress.Variant
    static string Default
    static string Error
    static string Success
    static string Warning
  static class Tokens.Width
    static string Dialog
    static string DialogLg
    static string DialogMd
    static string DialogSm
    static string DialogXl
    static string Drawer
    static string Popover
    static string Sheet
    static string Toast
  static class ZIndex
    static string Dropdown
    static string Modal
    static string Popover
    static string Sticky
    static string Toast
    static string Tooltip
  static class FileUpload.Zone
    static string Active
    static string ActiveRing
    static string Base
    static string Code
    static string Compact
    static string Default
    static string Disabled
    static string Documents
    static string DragOverlay
    static string Images
    static string Wrapper


---

# Ikon.Parallax Library Overview

## Introduction

Ikon.Parallax is a server-driven, reactive UI library for building interactive applications in C#. The library provides a declarative API for constructing user interfaces where all logic runs on the server, clients act as lightweight renderers, and the framework automatically handles efficient UI updates through intelligent diffing.

The name "Parallax" reflects the library's core capability: different clients can receive different views of the same underlying UI based on reactive scopes, similar to how parallax creates different viewpoints of the same scene.

## Core Concepts

### Reactive UI Updates

Ikon.Parallax uses the reactive system from `Ikon.Common.Core.Reactive`. When a `Reactive<T>` value changes, only the UI components that depend on that value are re-rendered. The framework tracks dependencies automatically during rendering.

```csharp
private readonly Reactive<int> _count = new(0);
private readonly Reactive<string> _message = new("Hello");

// When _count.Value changes, only UI that reads _count.Value re-renders
// When _message.Value changes, only UI that reads _message.Value re-renders
```

### Server-Side Diffing

The UI tree is constructed and diffed entirely on the server. When changes occur:

1. The reactive system detects which values changed
2. Affected UI components re-render on the server
3. The framework computes a minimal diff
4. Only the diff is sent to clients

This architecture means clients can be thin renderers with minimal logic.

### Scoped Reactive Values

Reactive values can be scoped to specific contexts (per-client, per-user, etc.). This enables sending different UI to different clients from the same codebase:

```csharp
// A value that is unique per client
private readonly Reactive<int, ClientScope> _clientCounter = new(0);

// A value that is unique per user
private readonly Reactive<string, UserScope> _userPreference = new("");
```

### Crosswind Styling

Styling uses Crosswind, a Tailwind-compatible utility class system. Styles are defined as string constants and support:

- Standard Tailwind utility classes (`flex`, `gap-4`, `bg-white`, etc.)
- Extended motion and animation classes
- Built-in theme style constants (via `Ikon.Parallax.Themes.Default`)

```csharp
private const string ButtonStyle =
    "px-4 py-2 rounded-lg bg-blue-500 hover:bg-blue-600 text-white transition";

view.Button(style: [ButtonStyle], label: "Click me", onClick: async () => { });
```

## Basic Usage

### Setting Up a UI

Create a `UI` instance with the app host and call `Root` to define the UI tree:

```csharp
using Ikon.Parallax;
using Ikon.Parallax.Themes.Default;

[App]
public class MyApp(IApp<SessionIdentity, ClientParams> host)
{
    private UI UI { get; } = new(host, new Theme());

    private readonly Reactive<int> _counter = new(0);

    public async Task Main()
    {
        UI.Root(style: ["min-h-screen bg-slate-950 text-white"], content: view =>
        {
            view.Column(style: ["flex flex-col items-center gap-4 p-6"], content: view =>
            {
                view.Text(style: ["text-2xl font-bold"], text: "Counter App");
                view.Text(style: ["text-lg"], text: $"Count: {_counter.Value}");
                view.Button(
                    style: ["px-4 py-2 bg-blue-500 rounded hover:bg-blue-600"],
                    label: "Increment",
                    onClick: async () => _counter.Value++);
            });
        });
    }
}
```

When `_counter.Value` changes, only the Text displaying the count re-renders, and only that diff is sent to clients.

### Component Methods

The `UIView` class provides extension methods for common UI components:

**Layout:**
- `view.Row()` - Horizontal flex container
- `view.Column()` - Vertical flex container
- `view.ScrollArea()` - Scrollable container with optional smart auto-scroll
- `view.InfiniteScrollView()` - Scroll area with near-end callbacks for lazy loading

**Display:**
- `view.Text()` - Text content
- `view.Button()` - Clickable button
- `view.Switch()` - Toggle switch
- `view.TextField()` - Text input
- `view.Slider()` - Range slider

**Overlays:**
- `view.Dialog()` - Modal dialog
- `view.Popover()` - Popover content
- `view.Tooltip()` - Tooltip on hover

**Navigation:**
- `view.Tabs()` - Tabbed interface
- `view.AccordionSingle()` / `view.AccordionMultiple()` - Collapsible sections

### ScrollArea and Auto-Scroll

ScrollArea provides a scrollable container with smart auto-scroll support, ideal for chat interfaces and live feeds:

```csharp
view.ScrollArea(
    rootStyle: ["h-[400px]"],
    autoScroll: true,
    autoScrollKey: _messages.Value.Count.ToString(),
    content: view =>
    {
        foreach (var msg in _messages.Value)
        {
            view.Text([Text.Body], msg);
        }
    });
```

**Auto-scroll behavior (Polite priority):**
- At bottom: new content auto-scrolls into view
- Scrolled away: auto-scroll is suppressed, a floating indicator appears to notify the user
- Clicking the indicator or scrolling back to bottom resumes auto-scroll

For forced scrolling (always scroll regardless of position), use `FocusHint` with `FocusPriority.Assertive`:

```csharp
anchor.FocusHint(new FocusHintProps { Priority = FocusPriority.Assertive },
    key: $"scroll-{version}");
```

## Example: Interactive Form

```csharp
private readonly Reactive<string> _name = new("");
private readonly Reactive<bool> _subscribed = new(false);
private readonly Reactive<int> _volume = new(50);

public async Task Main()
{
    UI.Root(style: ["p-8 bg-neutral-900 text-white"], content: view =>
    {
        view.Column(style: ["flex flex-col gap-4 max-w-md"], content: view =>
        {
            // Text input (use value: for controlled mode — clears reliably when set to "")
            view.TextField(
                style: ["px-3 py-2 bg-neutral-800 rounded border border-neutral-700"],
                value: _name.Value,
                onValueChange: value =>
                {
                    _name.Value = value;
                    return Task.CompletedTask;
                });

            // Switch
            view.Row(style: ["flex items-center gap-3"], content: view =>
            {
                view.Switch(
                    style: ["w-10 h-5 rounded-full bg-neutral-700 data-[state=checked]:bg-blue-500"],
                    @checked: _subscribed.Value,
                    onCheckedChange: value =>
                    {
                        _subscribed.Value = value;
                        return Task.CompletedTask;
                    },
                    content: view =>
                    {
                        view.SwitchThumb(style: ["block w-4 h-4 rounded-full bg-white transition data-[state=checked]:translate-x-5"]);
                    });
                view.Text(text: "Subscribe to newsletter");
            });

            // Slider
            view.Slider(
                style: ["w-full"],
                value: [_volume.Value],
                onValueChange: values =>
                {
                    _volume.Value = (int)values[0];
                    return Task.CompletedTask;
                },
                content: view =>
                {
                    view.SliderTrack(style: ["h-2 bg-neutral-700 rounded-full"], content: view =>
                    {
                        view.SliderRange(style: ["h-full bg-blue-500 rounded-full"]);
                    });
                    view.SliderThumb(style: ["w-4 h-4 bg-white rounded-full"]);
                });
            view.Text(style: ["text-sm text-neutral-400"], text: $"Volume: {_volume.Value}%");

            // Display current state
            view.Text(style: ["mt-4 text-neutral-400"],
                text: $"Name: {_name.Value}, Subscribed: {_subscribed.Value}");
        });
    });
}
```

## Styling with Crosswind

Styles are organized into reusable constants. Applications typically define a styles class:

```csharp
public static class AppStyles
{
    public static class Button
    {
        public const string Primary =
            "px-4 py-2 rounded-lg font-medium " +
            "bg-blue-500 hover:bg-blue-600 active:bg-blue-700 " +
            "text-white transition-colors";

        public const string Secondary =
            "px-4 py-2 rounded-lg font-medium " +
            "bg-neutral-700 hover:bg-neutral-600 " +
            "text-white transition-colors";
    }

    public static class Input
    {
        public const string Default =
            "px-3 py-2 rounded-lg " +
            "bg-neutral-800 border border-neutral-700 " +
            "focus:border-blue-500 focus:outline-none " +
            "text-white placeholder:text-neutral-500";
    }

    public static class Card
    {
        public const string Default =
            "p-4 rounded-xl " +
            "bg-neutral-900 border border-neutral-800";
    }
}
```

The library includes a built-in `Default` theme that provides a complete style system:

```csharp
using Ikon.Parallax.Themes.Default;

// Use theme style constants
view.Button(style: [Button.PrimaryMd], label: "Submit");
view.TextField(style: [Input.Default], value: _text.Value, onValueChange: async v => _text.Value = v);
```

## Per-Client UI with Scopes

The reactive scope system enables different clients to see different UI:

```csharp
// Counter that is unique per client
private readonly Reactive<int, ClientScope> _clientCounter = new(0);

public async Task Main()
{
    UI.Root(content: view =>
    {
        // Each client sees their own counter value
        view.Text(text: $"Your count: {_clientCounter.Value}");
        view.Button(
            label: "Increment",
            onClick: async () => _clientCounter.Value++);
    });
}
```

Without scopes, all clients share the same value. With `ClientScope`, each client has an independent value. This is the "parallax" effect: the same UI code produces different views for different clients.

## Architecture Summary

1. **Server-side logic**: All UI logic, state, and event handlers run on the server
2. **Reactive updates**: Changes to `Reactive<T>` values trigger targeted re-renders
3. **Differential sync**: Only UI diffs are sent to clients
4. **Scoped state**: `Reactive<T, TScope>` enables per-client or per-user state
5. **Lightweight clients**: Clients render the UI tree and forward events to the server
6. **Crosswind styling**: Tailwind-compatible utility classes with motion extensions
