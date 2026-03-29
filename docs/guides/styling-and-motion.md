# Styling & Motion

## Styling

Style UI with Crosswind (Tailwind-like) utility classes in C# string arrays. Animate with `motion-[keyframes]` syntax for fade-in, slide, glow, shimmer, and per-letter effects. Components are called on the `view` parameter inside `UI.Root()` — no namespace import needed.

```csharp
view.Button([Button.PrimaryMd, "mt-2 w-fit self-center"], label: "Submit");
view.Box([Card.Default, "p-6 mb-4"], content: view => { ... });
```

### Theme Constants & UI Guidelines

**Always use theme constants from `IkonTheme.cs` instead of raw Tailwind utilities.** Never use raw hex colors, Tailwind palette classes (`text-purple-500`, `bg-blue-100`), or hardcoded spacing/shadows/radius values when a theme constant exists.

For the full list of every available constant, see the **Ikon Theme Constants** reference. Key categories:

- **Text**: `Text.Display`, `Text.H1`–`Text.H4`, `Text.Body`, `Text.BodySm`, `Text.BodyStrong`, `Text.Label`, `Text.Caption`, `Text.Muted`, `Text.Small`, `Text.Code`, `Text.Link`, `Text.Overline`, `Text.Numeric`, `Text.Tabular`
- **Button**: `Button.PrimarySm/Md/Lg`, `Button.SolidSm/Md/Lg`, `Button.OutlineSm/Md/Lg`, `Button.GhostSm/Md/Lg`, `Button.NeutralSm/Md/Lg`, `Button.ErrorSm/Md/Lg`, `Button.SuccessSm/Md/Lg`, `Button.WarningSm/Md/Lg`, `Button.InfoSm/Md/Lg`, `Button.LinkSm/Md/Lg`, `Button.Size.Icon`, `Button.IconLeft`, `Button.IconRight`
- **Card**: `Card.Default`, `Card.Subtle`, `Card.Elevated`, `Card.Strong`, `Card.Outline`, `Card.Flat`, `Card.Interactive`, `Card.InteractiveFill`, `Card.Selected`, `Card.Ghost`, `Card.Glass`, `Card.GlassSubtle`, `Card.Header`, `Card.Content`, `Card.Footer`, `Card.HeaderRow`
- **Layout**: `Layout.Row.Xs/Sm/Md/Lg/Xl`, `Layout.Row.SpaceBetween`, `Layout.Column.Xs/Sm/Md/Lg/Xl`, `Layout.Grid.Cols2/Cols3/Cols4`, `Layout.Split.*`, `Layout.Page`, `Layout.Section`, `Layout.SectionHeader`, `Layout.Center`, `Layout.Stretch`
- **Page**: `Page.Default`, `Page.Plain`, `Page.Gradient`
- **Container**: `Container.Xs` through `Container.Xl7`, `Container.Full`, `Container.Prose`, `Container.Screen`
- **Input**: `Input.Default`, `Input.DefaultSm`, `Input.DefaultLg`, `Input.Ghost`, `Input.GhostSm`, `Input.GhostLg`, `Input.Invalid`, `Input.Success`, `Input.Warning`, `Input.Error`
- **Badge**: `Badge.Grey/Brand/Success/Warning/Error/Info` (with Sm/Md/Lg sizes), `Badge.Outline*` variants
- **Icon**: `Icon.Default`, `Icon.Size.Xs/Sm/Md/Lg`, `Icon.Spinner`, `Icon.SpinnerSm`, `Icon.SpinnerLg`
- **Nav**: `NavPanel.*`, `NavSection.*`, `NavItem.*` (with size and state variants)
- **Data**: `DataTable.*`, `StatCard.*`, `EmptyState.*`, `Progress.*`, `Skeleton.*`
- **State**: `State.Focusable`, `State.Disabled`, `State.Pressable`, `State.Loading`, `State.Selected`, `State.Invalid`, `State.Readonly`
- **Tokens**: `Tokens.Radius.*`, `Tokens.Shadow.*`, `Tokens.Duration.*`
- **Transition**: `Transition.Fast/Normal/Slow/Slower`, `Transition.Property.*`
- **Overlay styles**: `Dialog.*`, `AlertDialog.*`, `Popover.*`, `Tooltip.*`, `HoverCard.*`, `Toast.*`, `Sheet.*`, `Drawer.*`
- **Form**: `FormField.Root`, `FormField.Label`, `FormField.LabelRequired`, `FormField.HelpText`, `FormField.ErrorText`
- **Other**: `Tabs.*`, `Slider.*`, `Select.*`, `RadioGroup.*`, `Checkbox.*`, `Switch.*`, `Alert.*`, `Separator.*`, `Avatar.*`

Use semantic color tokens (`text-primary`, `bg-card`, `border-secondary`) — never raw hex values. Follow the 60-30-10 rule: 60% `bg-background`, 30% `bg-card`/`bg-secondary`, 10% brand accents.

For complete UI decision rules, see the **Ikon UI Guidelines** doc. For theme customization (brand colors, fonts, radius, design personalities), see the **Ikon Theme Customization** guide.

### Motion Syntax

Motion animations use `motion-[keyframes]` with percentage steps. Combine with `motion-duration-Xms`, `motion-loop`, `motion-per-letter`.

```csharp
// Fade in
view.Box(["motion-[0:opacity-0,100:opacity-100] motion-duration-500ms"], content: view =>
{
    view.Text([Text.Body], "I fade in!");
});

// Slide up + fade in
view.Box(["motion-[0:opacity-0_translate-y-[20px],100:opacity-100_translate-y-0] motion-duration-700ms"]);

// Glow pulse (looping)
view.Box(["motion-[0:shadow-none,50:shadow-[0_0_20px_rgba(168,85,247,0.6)],100:shadow-none] motion-duration-2000ms motion-loop"]);

// Per-letter wave animation (each letter animates independently)
view.Text(["wave:motion-[0:translate-y-0,50:translate-y-[-10px],100:translate-y-0] wave:motion-duration-2500ms wave:motion-per-letter wave:motion-loop"], "Hello");

// Per-letter fade-in with stagger delay (letters appear one by one)
view.Text(["motion-[0:opacity-0,100:opacity-100] motion-duration-300ms motion-per-letter motion-letter-delay-60ms"], "Appearing!");

// Per-word animation
view.Text(["motion-[0:opacity-0_translate-y-[10px],100:opacity-100_translate-y-0] motion-duration-500ms motion-per-word motion-letter-delay-100ms"], "Each word slides in");
```

Key: steps are `percentage:utilities`, separated by commas. Within a step, multiple utilities are joined with underscores (`_`). Track prefixes (e.g. `wave:`) scope animations to named tracks.

```csharp
// Shimmer/loading effect — translate a gradient overlay
view.Box(["w-full h-4 rounded bg-muted relative overflow-hidden " +
    "before:content-[''] before:absolute before:inset-0 " +
    "before:bg-[linear-gradient(90deg,transparent,rgba(255,255,255,0.5),transparent)] " +
    "before:w-[200%] " +
    "before:shimmer:motion-[0:translate-x-[-50%],100:translate-x-[0%]] " +
    "before:shimmer:motion-duration-1000ms before:shimmer:motion-ease-linear before:shimmer:motion-loop"]);

// Scale + blur entrance
view.Box(["motion-[0:opacity-0_scale-[0.5]_blur-[4px],100:opacity-100_scale-100_blur-0] motion-duration-500ms"]);
```

All motion styles are applied inside `UI.Root(content: view => { ... })` — the `view` parameter is a `UIView` builder, not a separate namespace. Example in app context:

```csharp
public async Task Main()
{
    UI.Root([Page.Default], content: view =>
    {
        view.Column(["h-screen items-center justify-center gap-4"], content: view =>
        {
            // Animated heading with fade-in + slide
            view.Text([Text.H2, "motion-[0:opacity-0_translate-y-[20px],100:opacity-100_translate-y-0] motion-duration-700ms"], "Welcome!");

            // Pulsing glow button
            view.Button([Button.PrimaryMd, "motion-[0:shadow-none,50:shadow-[0_0_20px_rgba(168,85,247,0.6)],100:shadow-none] motion-duration-2000ms motion-loop"],
                label: "Click me");
        });
    });
}
```

### Style Organization

For large apps, organize styles in a static class:

```csharp
internal static class Styles
{
    public static readonly string[] PageContainer = [Container.Xl2, "py-8 px-4 min-h-screen"];
    public static readonly string[] MainCard = [Card.Default, Layout.Column.Lg, "p-10 w-full"];
}
```
