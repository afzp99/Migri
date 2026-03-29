# Reactive State

## Reactive State Management

### Basic Reactive Types

```csharp
// Shared across all clients (global state)
private readonly Reactive<int> _count = new(0);

// Per-client state (each connected client sees their own value)
private readonly ClientReactive<string> _theme = new("light");

// Per-user state (shared across a user's multiple client sessions)
// If a user connects from phone and desktop, both clients share the same UserReactive values
private readonly UserReactive<string> _userPref = new("");

// Persisted across app restarts (saved to cloud storage automatically)
private readonly PersistentReactive<int> _totalVisits = new(0);
```

`PersistentReactive<T>` values survive app restarts by persisting to cloud storage. Use for counters, settings, or any state that should not reset on redeployment.

### Scope Requirements

**Never access `ClientReactive` or `UserReactive` values outside `UI.Root()`.** `Main()` runs before any client/user scope exists. All reads and writes of scoped reactive values must happen inside `UI.Root()` or inside event callbacks (onClick, onSubmit, etc.) which run within a scope. For background tasks, use `ReactiveScope.Use()` to enter a scope explicitly.

```csharp
// WRONG — crashes at startup, no user scope active
public async Task Main()
{
    if (_hasJoined.Value) { ... }  // UserReactive — throws InvalidOperationException
    RenderTavern();
}

// CORRECT — branch inside UI.Root() where scopes are active
public async Task Main()
{
    UI.Root([Page.Default], content: view =>
    {
        if (_hasJoined.Value) { RenderTavern(view); }  // OK — inside UI.Root()
        else { RenderEntry(view); }
    });
}
```

### Value Mutation

```csharp
// Simple assignment
_count.Value = 42;

// List mutation (mutate in place and notify)
_items.Value.Add(newItem);
_items.NotifyUpdate();

// Record mutation
_config.Value = _config.Value with { Theme = "dark" };
```

### Complete Example: Shared Messages + Per-Client Input

```csharp
// Shared state — all clients see the same messages
private readonly Reactive<List<string>> _messages = new([]);

// Per-client state — each client has their own input
private readonly ClientReactive<string> _input = new("");

public async Task Main()
{
    UI.Root([Page.Default], content: view =>
    {
        view.Column(["h-screen"], content: view =>
        {
            // All clients see the same messages
            view.ScrollArea(autoScroll: true, autoScrollKey: _messages.Value.Count.ToString(),
                rootStyle: ["flex-1 min-h-0 px-4"], content: view =>
            {
                foreach (var msg in _messages.Value)
                {
                    view.Text([Text.Body, "py-1"], msg);
                }
            });

            // Each client has their own input
            view.Row(["p-4 gap-2 flex-shrink-0"], content: view =>
            {
                view.TextField([Input.Default, "flex-1"],
                    value: _input.Value,
                    onValueChange: async v => _input.Value = v,
                    onSubmit: async _ =>
                    {
                        _messages.Value.Add(_input.Value);
                        _messages.NotifyUpdate(); // Required for in-place list mutation
                    },
                    clearOnSubmit: true);
            });
        });
    });
}
```

### ReactiveScope Context

Inside UI callbacks, access the current client/user context. `host` does not have a `ClientId` property. Always use `ReactiveScope.ClientId` inside UI callbacks.

```csharp
var clientId = ReactiveScope.ClientId;

// Manually set scope (e.g., in background tasks)
using var _ = ReactiveScope.Use(new ClientScope(clientSessionId));
_clientTheme.Value = "dark"; // Now targets the specified client
```

---

# Ikon.Common.Core Public API
namespace Ikon.Common.Core.Reactive
  static class ClientReactive
    static ClientReactive<T> Create<T>(Func<int, T> factory, string file = "", string member = "")
  class ClientReactive<T> : Reactive<T, ClientScope>
    ctor(T initialValue, string file = "", string member = "")
  sealed class ReactiveManager.Handle
    string DebugDescription { get;  set; }
    int? GroupId { get;  set; }
    Guid Id { get; }
    bool IsUpdate { get; }
    DateTime? UpdatedAt { get; }
    void StopTracking(bool isUpdating)
    override string ToString()
  sealed class HotReloadStateStore : AsyncLocalInstance<HotReloadStateStore>
    ctor()
    Dictionary<string, StoredReactiveState> CaptureAllForHotReload()
    Dictionary<string, StoredReactiveState> CaptureForStorage()
    void Clear()
    void LoadHotReloadStates(Dictionary<string, StoredReactiveState> states)
    void LoadStorageStates(Dictionary<string, StoredReactiveState> states)
    void Register(string stableId, IReactiveWithState reactive, bool persistent)
  interface IReactive
    long Version { get; }
  interface IReactiveWithState
    string StableId { get; }
    abstract StoredReactiveState CaptureState()
    abstract void RestoreState(StoredReactiveState state)
  static class Reactive
    static void Run<T>(Reactive<T> reactiveValue, Func<Task<T>> action, Action<Exception> onError = null, CancellationToken token = null)
    static void Run<T>(Reactive<T> reactiveValue, Func<CancellationToken, Task<T>> action, Action<Exception> onError = null, CancellationToken token = null)
  class ReactiveManager : IDisposable
    ctor(string category)
    string Category { get; }
    int UpdatedHandleCount { get; }
    void DecrementUICreationOngoing()
    void Dispose()
    void IncrementUICreationOngoing()
    void OnDeleted(Guid id)
    void Reactive(Action<ReactiveManager.Handle> callback)
    Task ReactiveAsync(Func<ReactiveManager.Handle, Task> callback)
    void StopTrackingAll()
    Task UpdateAsync()
    event EventHandler<Guid> Deleted
    event EventHandler ReactiveObjectUpdated
    event EventHandler<Guid> Updating
  static class ReactiveScope
    static int ClientId { get; }
    static int? ClientIdOrNull { get; }
    static IList<IScopeKey> Current { get; }
    static string UserId { get; }
    static string UserIdOrNull { get; }
    static void Add(IScopeKey scope)
    static TScope Get<TScope>()
    static IScopeKey GetByName(string name)
    static TScope? TryGet<TScope>()
    static bool TryGet<TScope>(out TScope scope)
    static IScopeKey TryGetByName(string name)
    static IDisposable Use(IScopeKey scope)
    static IDisposable Use(params IScopeKey[] scopes)
  static class ReactiveScopeRestorer
    static IDisposable Activate(IReadOnlyList<IScopeKey> scopes)
    static IScopeKey[] CaptureCurrent()
    static IScopeKey[] CopyInRestorableOrder(IList<IScopeKey> scopes)
  class Reactive<T> : IReactive, IReactiveWithState
    ctor(UseDefault _ = null, string file = "", string member = "")
    ctor(T initialValue, string file = "", string member = "")
    T Peek { get; }
    string StableId { get; }
    T Value { get;  set; }
    long Version { get; }
    StoredReactiveState CaptureState()
    void NotifyUpdate()
    void RestoreState(StoredReactiveState state)
    override string ToString()
    event Action<T> ValueChanged
    event Func<T, Task> ValueChangedAsync
  class Reactive<T, TScope> : Reactive<T> where TScope : IScopeKey
    ctor(T initialValue, string file = "", string member = "")
    ctor(Func<T> initialValue, string file = "", string member = "")
  class Signal<T> : IReactive
    ctor(T initial)
    T Peek { get; }
    T Value { get;  set; }
    long Version { get; }
    void NotifyUpdate()
    event Action<T> ValueChanged
    event Func<T, Task> ValueChangedAsync
  class StoredReactiveState
    ctor()
    ctor(string typeName, string memberName, int ordinal, Dictionary<int, string> sessionValues)
    string MemberName { get;  set; }
    int Ordinal { get;  set; }
    Dictionary<int, string> SessionValues { get;  set; }
    string TypeName { get;  set; }
  struct UseDefault
  class UserReactive<T> : Reactive<T, UserScope>
    ctor(T initialValue, string file = "", string member = "")
    ctor(Func<string, T> initialValue, string file = "", string member = "")

namespace Ikon.Common.Core.Scope
  struct BackendTokenScope : IScopeKey
    ctor(string token)
    string Id { get; }
    string Name { get; }
  struct ClientScope : IScopeKey
    ctor(int sessionId)
    ctor(Context context)
    int Id { get; }
    string Name { get; }
  struct CustomScope : IScopeKey
    ctor(string name, string id)
    string Id { get; }
    string Name { get; }
  interface IScopeKey
    object Id { get; }
    string Name { get; }
  struct OperationScope : IScopeKey
    ctor()
    ctor(Guid id)
    Guid Id { get; }
    string Name { get; }
  struct RunScope : IScopeKey
    ctor()
    ctor(Guid id)
    Guid Id { get; }
    string Name { get; }
  class ScopeRestorer
    ctor(ScopeStack scopeStack)
    IDisposable Activate(IReadOnlyList<IScopeKey> scopes)
    IScopeKey[] CaptureCurrent()
    static IScopeKey[] CopyInRestorableOrder(IList<IScopeKey> scopes)
  static class ScopeSerializer
    static List<ActionFunctionCall.ScopeEntry> CaptureForFunctionCall()
    static IScopeKey[] Deserialize(IReadOnlyList<ActionFunctionCall.ScopeEntry> entries)
  class ScopeStack
    ctor()
    IList<IScopeKey> Current { get; }
    void Add(IScopeKey scope)
    TScope Get<TScope>()
    IScopeKey GetByName(string name)
    TScope? TryGet<TScope>()
    bool TryGet<TScope>(out TScope scope)
    IScopeKey TryGetByName(string name)
    IDisposable Use(IScopeKey scope)
    IDisposable UseScopes(params IScopeKey[] scopes)
  struct TenantScope : IScopeKey
    ctor(string tenantId)
    string Id { get; }
    string Name { get; }
  struct UserScope : IScopeKey
    ctor(string userId)
    ctor(Context context)
    string Id { get; }
    string Name { get; }
