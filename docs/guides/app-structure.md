# App Structure

## Minimal App Template

```csharp
return await App.Run(args);

public record SessionIdentity(string UserId);
public record ClientParameters(string Name = "Ikon");

[App]
public class MyApp(IApp<SessionIdentity, ClientParameters> app)
{
    private UI UI { get; } = new(app, new Theme());
    private Audio Audio { get; } = new(host);

    // Shared state — same value for all clients
    private readonly Reactive<List<string>> _messages = new([]);

    // Per-client state — each client has its own value
    private readonly ClientReactive<string> _input = new("");

    public async Task Main()
    {
        UI.Root([Page.Default], content: view =>
        {
            // h-screen keeps the app within the viewport — never let the page grow beyond the screen
            view.Column(["h-screen"], content: view =>
            {
                view.Text([Text.H2, "p-4 flex-shrink-0"], "Hello!");

                // ScrollArea for unbounded content (chat, lists, feeds)
                view.ScrollArea(rootStyle: ["flex-1 min-h-0 px-4"], content: view =>
                {
                    foreach (var msg in _messages.Value)
                    {
                        view.Text([Text.Body], msg);
                    }
                });

                view.Row(["p-4 gap-2 flex-shrink-0"], content: view =>
                {
                    view.TextField([Input.Default, "flex-1"], placeholder: "Type a message...",
                        value: _input.Value,
                        onValueChange: async v => _input.Value = v,
                        onSubmit: async _ =>
                        {
                            if (!string.IsNullOrWhiteSpace(_input.Value))
                            {
                                _messages.Value.Add(_input.Value);
                                _messages.NotifyUpdate();
                                _input.Value = "";
                            }
                        },
                        clearOnSubmit: true);
                    view.Button([Button.PrimaryMd], label: "Send", onClick: async () =>
                    {
                        if (!string.IsNullOrWhiteSpace(_input.Value))
                        {
                            _messages.Value.Add(_input.Value);
                            _messages.NotifyUpdate();
                            _input.Value = "";
                        }
                    });
                });
            });
        });
    }
}
```

## Viewport Layout

Apps must fit within the browser viewport — never let the page grow beyond the screen and rely on the browser scrollbar. The root layout should use `h-screen` (or `min-h-screen` with `overflow-hidden`) so the app fills exactly the viewport.

Use `ScrollArea` for content that can grow unboundedly (chat messages, lists, logs, feeds). The surrounding container must have a bounded height (e.g. `flex-1 min-h-0`) so the scroll area knows when to scroll.

```csharp
// WRONG — page grows forever, browser scrollbar appears
view.Column(["min-h-screen"], content: view =>
{
    RenderHeader(view);
    foreach (var msg in _messages.Value) { RenderMessage(view, msg); }  // unbounded
    RenderInput(view);
});

// CORRECT — fixed viewport, chat area scrolls internally
view.Column(["h-screen"], content: view =>
{
    RenderHeader(view);                                           // flex-shrink-0
    view.ScrollArea(rootStyle: ["flex-1 min-h-0"], content: view =>
    {
        foreach (var msg in _messages.Value) { RenderMessage(view, msg); }
    });
    RenderInput(view);                                            // flex-shrink-0
});
```

### Auto-scrolling live content

For `ScrollArea` showing live-updating content (chat, logs, streaming), add polite auto-scroll:

    view.ScrollArea(
        autoScroll: true,
        autoScrollKey: messages.Count.ToString(),
        rootStyle: ["flex-1 min-h-0"],
        content: view => { ... });

`autoScroll: true` scrolls to bottom when `autoScrollKey` changes, but respects user scroll position — if the user scrolled up, it won't force them down. Do not use on static scroll areas.

## App File Structure

Key elements:

- `return await App.Run(args);` - Required entry point at the top of the file
- `[App]` attribute - Mandatory, must appear exactly once. Marks the class whose `Main()` method will be executed. Do NOT explicitly implement `: IApp<>` — the `[App]` attribute handles interface implementation via source generation
- `IApp<SessionIdentity, ClientParameters> host` - Must specify types for SessionIdentity and ClientParameters. Passed as a primary constructor parameter, not implemented as an interface
- `private UI UI { get; } = new(app, new Theme());` - Initialize UI with host and theme
- `Reactive<T>` - Reactive state that triggers UI updates when changed
- `public async Task Main()` - App entry point. Declares UI shape and returns quickly. All work code goes in callbacks

### Partial Class Pattern

For larger apps, split into partial classes by feature area:

```
MyApp.cs          - Main class, reactive state, Main() entry
MyApp.UI.cs       - Render methods
MyApp.Audio.cs    - Audio handlers
MyApp.Video.cs    - Video handlers
MyApp.Chat.cs     - Chat feature
```

All files use `public partial class MyApp` and share the same constructor-injected fields.

### GlobalUsings.cs

Reduce `using` clutter with a GlobalUsings file:

```csharp
global using Ikon.AI.Emergence;
global using Ikon.AI.Kernel;
global using Ikon.AI.LLM;
global using Ikon.App;
global using Ikon.Common.Core.Reactive;
global using Ikon.Common.Core.Scope;
global using Ikon.Common.Core;
global using Ikon.Common;
global using Ikon.Parallax.Components.Standard;
global using Ikon.Parallax.Themes.Default;
global using Ikon.Parallax;
global using Ikon.Server;
```

## SessionIdentity & ClientParameters

### SessionIdentity - Controls App Instance Creation

SessionIdentity properties determine which users share the same app instance:

- All property values are hashed together to calculate sessionId
- If sessionId matches a running app instance, user connects to it; otherwise a new instance is created
- `UserId` is special: cloud provides it automatically
- Other properties get values from URL query params (property name = query param key)
- Available in app via `app.SessionIdentity`

Examples:

- `SessionIdentity(string UserId)` - each user gets their own app instance
- `SessionIdentity()` (empty) - everyone connects to same app instance
- `SessionIdentity(string Mode)` - `?mode=value1` users share one app instance, `?mode=value2` users share another

### ClientParameters - Per-Client Data

- URL query params auto-mapped if property names and types match
- Each connected client has their own ClientParameters
- Available via `app.Clients[clientId].Parameters`

### URL Format

- `/s/[sessionId]` - direct session ID, bypasses SessionIdentity calculation
- Query params (`?key=value`) - mapped to SessionIdentity and ClientParameters

## Host Services & Lifecycle

### Lifecycle Events

```csharp
app.StartingAsync += async args => { /* app starting */ };
app.StoppingAsync += async args => { /* app stopping, cleanup */ };
app.ClientJoinedAsync += async args =>
{
    // args.ClientSessionId, args.ClientContext (Theme, Timezone, UserId, ClientType, InitialPath, ViewportWidth)
    var client = app.Clients[args.ClientSessionId];
};
app.ClientLeftAsync += async args => { /* cleanup client state */ };
```

### Navigation

```csharp
// Listen for path changes
app.Navigation.PathChangedAsync += async args =>
{
    var path = args.Path.TrimStart('/');
    _activeTab.Value = path;
};

// Change path programmatically
await app.Navigation.SetPathAsync($"/{tab}");
await app.Navigation.SetPathAsync(args.ClientSessionId, $"/{tab}", replace: true);
```

### App Data and Public Folders

- **`app/Data/` folder**: Files placed here are included in the app bundle. Available at runtime via `app.DataDirectory` for reading from the C# app
- **`frontend-node/public/` folder**: Files placed here are included in the app bundle and served by the frontend. Accessible by the browser (e.g., for images, fonts, static assets)

### Other Host Services

```csharp
app.GlobalState.SpaceId           // Current space ID
app.GlobalState.ChannelId         // Current channel ID
app.GlobalState.SessionId         // Server session ID
app.GlobalState.ChannelUrl        // Channel access URL
app.GlobalState.SessionChannelUrl // Session-specific access URL
app.GlobalState.PrimaryUserId     // Static user ID of session owner
app.GlobalState.FirstUserId       // First human user who joined (dynamically reassigned)
app.GlobalState.GetClientContext(clientSessionId)  // Get client context
app.DataDirectory                 // Path to app's Data directory
app.Endpoints                     // Custom endpoint info (see Endpoints section)
app.Databases                     // Database connection info (see Databases section)
app.SessionIdentity               // Current session identity
app.Clients[clientId].Parameters  // Client parameters
app.ReactiveGlobalState.Clients   // Reactive client state
```

### Join URL & QR Code

The session join URL allows other users to connect. Display it as a QR code for easy scanning.

```csharp
// Get the shareable join URL
var joinUrl = app.ReactiveGlobalState.ChannelUrl.Value;
// or session-specific:
var sessionUrl = app.ReactiveGlobalState.SessionChannelUrl.Value;

// Render as QR code
view.QR(["w-48 h-48"], value: joinUrl);

// Or display as text
view.Text([Text.Body, "text-primary underline"], joinUrl);
```

### BackgroundWork

Prevents the server from idle-shutdown while background processing is active. Returns an `IAsyncDisposable` scope; multiple concurrent scopes are ref-counted.

```csharp
await using var work = await app.BackgroundWork.StartAsync();
await LongRunningTask();
// work.DisposeAsync() signals completion automatically
```

### ClientFunctions

Programmatic client-side actions (no user gesture required):

```csharp
// Parameterless overloads auto-resolve the client via ReactiveScope.ClientId
await ClientFunctions.SetThemeAsync("dark");               // persist: true by default
await ClientFunctions.GetThemeAsync();
await ClientFunctions.GetMediaDevicesAsync();
await ClientFunctions.StartAudioCaptureAsync(options);     // returns streamId
await ClientFunctions.StartVideoCaptureAsync(source, options); // returns streamId
await ClientFunctions.StopCaptureAsync(streamId);
await ClientFunctions.CaptureImageAsync(options);          // returns ClientImageCapture
await ClientFunctions.KeepScreenAwakeAsync(true);
await ClientFunctions.GetLanguageAsync();
await ClientFunctions.GetTimezoneAsync();
await ClientFunctions.GetUrlAsync();
await ClientFunctions.SetUrlAsync("/path");                // replace: false, preserveQueryParams: false
await ClientFunctions.GetVisibilityAsync();                // page visibility state
await ClientFunctions.GetBatteryLevelAsync();              // 0-100
await ClientFunctions.GetNetworkTypeAsync();               // connection type
await ClientFunctions.VibrateAsync("200");
await ClientFunctions.ScrollToAsync(x: 0, y: 0, smooth: true);
await ClientFunctions.PlaySoundAsync(url, volume: 0.8, loop: false);
await ClientFunctions.PlaySoundAsync(data, mimeType, volume: 0.8, loop: false); // from bytes
await ClientFunctions.StopSoundAsync(playbackId);
await ClientFunctions.RequestFullscreenAsync();
await ClientFunctions.ExitFullscreenAsync();
await ClientFunctions.LogoutAsync();

// Explicit targetId overloads also available for all functions:
await ClientFunctions.SetThemeAsync(targetId, "dark");
```

### Messages

```csharp
app.MessageReceivedAsync += async args => { /* args.Message.Opcode, args.Message.TrackId */ };
await app.SendMessageAsync(ProtocolMessage.Create(app.ClientContext.SessionId, new RequestIdrVideoFrame(),
    trackId: trackId, targetIds: [clientSessionId]));
```

## Common Patterns

### Loading State

```csharp
private readonly Reactive<bool> _isLoading = new(false);

view.Button([Button.PrimaryMd], _isLoading.Value ? "Loading..." : "Submit",
    disabled: _isLoading.Value,
    onClick: async () =>
    {
        _isLoading.Value = true;
        try { await DoWork(); }
        finally { _isLoading.Value = false; }
    });
```

### Conditional Rendering

```csharp
if (_imageData.Value != null)
{
    view.Image(["max-w-full"], data: _imageData.Value, mimeType: _imageMime.Value);
}
```

### Error Handling in Callbacks

```csharp
onClick: async () =>
{
    try { await RiskyOperation(); }
    catch (Exception ex) { Log.Instance.Warning($"Operation failed: {ex.Message}"); }
}
```
