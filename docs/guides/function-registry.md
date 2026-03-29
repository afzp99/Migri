# Function Registry

## Function Registry

Register callable functions that can be invoked by LLMs, clients, and pipelines.

### Direct Registration

```csharp
FunctionRegistry.Instance.AddFunction(
    Function.Register(MyMethod, "my_function",
        new FunctionAttribute { Description = "Description of what it does" }),
    FunctionVisibility.Shared);
```

### Attribute-Based Registration (Static Methods)

```csharp
public class MathFunctions
{
    [Function(Name = "Add", Description = "Adds two numbers", Visibility = FunctionVisibility.Shared)]
    public static int Add(int a, int b) => a + b;
}

FunctionRegistry.Instance.RegisterFromType(typeof(MathFunctions));
```

### Attribute-Based Registration (Instance Methods)

```csharp
[RegisterAll(Visibility = FunctionVisibility.Shared)]
public class GreetingFunctions(string greeting)
{
    [Function(Name = "Greet", Description = "Greets a person")]
    public string Greet(string name) => $"{greeting}, {name}!";
}

FunctionRegistry.Instance.RegisterFromInstance(new GreetingFunctions("Hello"));
```

### Pipeline Registration

```csharp
FunctionRegistry.Instance.RegisterPipeline<MyPipeline>("run_my_pipeline");
```

### Function Visibility

- `FunctionVisibility.Shared` - Distributed to connected clients and available to LLMs
- `FunctionVisibility.Local` - Only callable within the server process

### Calling Functions

```csharp
var result = FunctionRegistry.Instance.Call<int>("Add", [2, 3]);
var result = await FunctionRegistry.Instance.CallAsync<string>("Greet", args: ["World"]);
```

---

# Ikon.Common.Core Public API
namespace Ikon.Common.Core.Functions
  enum CallbackType
    Sync
    Async
    AsyncEnumerable
  struct Function
    ctor(Guid id, string name, FunctionParameter[] parameters, string returnTypeName, string description, FunctionVisibility visibility, bool llmInlineResult, bool llmCallOnlyOnce, CallbackType callbackType, int? clientSessionId, bool requiresInstance = false, string version = null)
    ctor(Guid id, string name, FunctionParameter[] parameters, Type returnType, string description, FunctionVisibility visibility, bool llmInlineResult, bool llmCallOnlyOnce, CallbackType callbackType, int? clientSessionId, Func<object[], object> callback, Func<object[], Task<object>> callbackAsync, Func<object[], IAsyncEnumerable<object>> callbackAsyncEnumerable, MethodInfo methodInfo = null, bool requiresInstance = false, PolicyDelegate policy = null, string version = null)
    CallbackType CallbackType { get; }
    int? ClientSessionId { get; }
    string Description { get; }
    bool HasCallback { get; }
    bool HasPolicy { get; }
    Guid Id { get; }
    bool IsLocal { get; }
    bool IsRemote { get; }
    bool LlmCallOnlyOnce { get; }
    bool LlmInlineResult { get; }
    string Name { get; }
    FunctionParameter[] Parameters { get; }
    PolicyDelegate Policy { get; }
    bool RequiresInstance { get; }
    Type ReturnType { get; }
    string ReturnTypeName { get; }
    string Version { get; }
    FunctionVisibility Visibility { get; }
    object Call(object[] args)
    Task<object> CallAsync(object[] args)
    IAsyncEnumerable<object> CallAsyncEnumerable(object[] args)
    IEnumerable<object> CallEnumerable(object[] args)
    static Function Create<TResult>(string name, string description, Func<TResult> function, PolicyDelegate policy = null)
    static Function Create<T1, TResult>(string name, string description, Func<T1, TResult> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, TResult>(string name, string description, Func<T1, T2, TResult> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, T3, TResult>(string name, string description, Func<T1, T2, T3, TResult> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, T3, T4, TResult>(string name, string description, Func<T1, T2, T3, T4, TResult> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, T3, T4, T5, TResult>(string name, string description, Func<T1, T2, T3, T4, T5, TResult> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, T3, T4, T5, T6, TResult>(string name, string description, Func<T1, T2, T3, T4, T5, T6, TResult> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, T3, T4, T5, T6, T7, TResult>(string name, string description, Func<T1, T2, T3, T4, T5, T6, T7, TResult> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(string name, string description, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function, PolicyDelegate policy = null)
    static Function Create<TResult>(string name, string description, Func<Task<TResult>> function, PolicyDelegate policy = null)
    static Function Create<T1, TResult>(string name, string description, Func<T1, Task<TResult>> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, TResult>(string name, string description, Func<T1, T2, Task<TResult>> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, T3, TResult>(string name, string description, Func<T1, T2, T3, Task<TResult>> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, T3, T4, TResult>(string name, string description, Func<T1, T2, T3, T4, Task<TResult>> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, T3, T4, T5, TResult>(string name, string description, Func<T1, T2, T3, T4, T5, Task<TResult>> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, T3, T4, T5, T6, TResult>(string name, string description, Func<T1, T2, T3, T4, T5, T6, Task<TResult>> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, T3, T4, T5, T6, T7, TResult>(string name, string description, Func<T1, T2, T3, T4, T5, T6, T7, Task<TResult>> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(string name, string description, Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<TResult>> function, PolicyDelegate policy = null)
    static Function Create<TResult>(string name, string description, Func<IAsyncEnumerable<TResult>> function, PolicyDelegate policy = null)
    static Function Create<T1, TResult>(string name, string description, Func<T1, IAsyncEnumerable<TResult>> function, PolicyDelegate policy = null)
    static Function Create<T1, T2, TResult>(string name, string description, Func<T1, T2, IAsyncEnumerable<TResult>> function, PolicyDelegate policy = null)
    static Function Register(Delegate function, string name = null, FunctionAttribute attribute = null, MethodInfo methodInfo = null, PolicyDelegate policy = null, Dictionary<string, string> paramDescriptions = null)
    static Function Register<TResult>(Func<TResult> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, TResult>(Func<T1, TResult> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, T2, TResult>(Func<T1, T2, TResult> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<TResult>(Func<Task<TResult>> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, TResult>(Func<T1, Task<TResult>> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, T2, TResult>(Func<T1, T2, Task<TResult>> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, T2, T3, TResult>(Func<T1, T2, T3, Task<TResult>> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, Task<TResult>> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<TResult>(Func<IAsyncEnumerable<TResult>> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, TResult>(Func<T1, IAsyncEnumerable<TResult>> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    static Function Register<T1, T2, TResult>(Func<T1, T2, IAsyncEnumerable<TResult>> function, string name = null, FunctionAttribute attribute = null, PolicyDelegate policy = null)
    override string ToString()
    Function With(Guid? id = null, string name = null, FunctionParameter[] parameters = null, Type returnType = null, string description = null, FunctionVisibility? visibility = null, bool? llmInlineResult = null, bool? llmCallOnlyOnce = null, CallbackType? callbackType = null, int? clientSessionId = null, Func<object[], object> callback = null, Func<object[], Task<object>> callbackAsync = null, Func<object[], IAsyncEnumerable<object>> callbackAsyncEnumerable = null, MethodInfo methodInfo = null, bool? requiresInstance = null, PolicyDelegate policy = null, bool clearClientSessionId = false, bool clearMethodInfo = false, bool clearPolicy = false, string version = null)
    Function WithParamDescription(string paramName, string description)
  class FunctionAttribute : Attribute
    ctor()
    ctor(string description, bool llmInlineResult = false, bool llmCallOnlyOnce = false)
    string Description { get;  set; }
    bool LlmCallOnlyOnce { get;  set; }
    bool LlmInlineResult { get;  set; }
    string Name { get;  set; }
    object TypeId { get; }
    FunctionVisibility Visibility { get;  set; }
  struct FunctionParameter
    ctor(int index, string name, string description, Type type, bool hasDefaultValue, object defaultValue)
    ctor(int index, string name, string description, string typeName, bool hasDefaultValue, object defaultValue)
    object DefaultValue { get; }
    string Description { get; }
    bool HasDefaultValue { get; }
    int Index { get; }
    bool IsNullableValueType { get; }
    string Name { get; }
    Type Type { get; }
    string TypeName { get; }
    override string ToString()
  class FunctionRegistry : AsyncLocalInstance<FunctionRegistry>, BuiltInApprovalHandlers.IApprovalProtocolBridge
    ctor()
    IReadOnlyDictionary<string, IReadOnlyList<Function>> Functions { get; }
    static Action RemoteCallExecutionStarting { get;  set; }
    void AddFunction(Function function, FunctionVisibility? visibilityOverride = null)
    Task AttachProtocolAsync(IProtocolMessageChannel channel, int senderId)
    TResult Call<TResult>(string name, object[] args = null, int? targetId = null, bool propagateScopes = false, string version = null, Guid? instanceId = null)
    Task<TResult> CallAsync<TResult>(string name, CancellationToken cancellationToken = null, object[] args = null, int? targetId = null, bool propagateScopes = false, string version = null, Guid? instanceId = null)
    Task CallAsync(string name, CancellationToken cancellationToken = null, object[] args = null, int? targetId = null, bool propagateScopes = false, string version = null, Guid? instanceId = null)
    IAsyncEnumerable<TItem> CallAsyncEnumerable<TItem>(string name, CancellationToken cancellationToken = null, object[] args = null, int? targetId = null, bool propagateScopes = false, string version = null, Guid? instanceId = null)
    IEnumerable<TItem> CallEnumerable<TItem>(string name, object[] args = null)
    void ClearLocalFunctions()
    void DetachProtocol()
    Task DisposeInstanceAsync(Guid instanceId, int? targetId = null)
    IReadOnlyCollection<int> GetClientSessionsWithFunction(string name)
    Function? GetFunction(string name)
    Function? GetFunction(string name, object[] args)
    Function? GetFunction(string name, IReadOnlyList<FunctionParameter> protocolParameters)
    Function? GetFunction(string name, IReadOnlyList<FunctionParameter> protocolParameters, string version)
    Function? GetFunction(string name, int clientSessionId)
    IReadOnlyList<Function> GetFunctions(string name)
    bool HasFunction(string name)
    bool HasFunction(string name, int clientSessionId)
    void RegisterFromAssembly(Assembly assembly, FunctionVisibility? visibilityOverride = null, string version = null)
    void RegisterFromInstance(object instance, FunctionVisibility? visibilityOverride = null, string version = null)
    void RegisterFromType<T>(FunctionVisibility? visibilityOverride = null, string version = null)
    void RegisterFromType(Type type, FunctionVisibility? visibilityOverride = null, string version = null)
    void RegisterRemoteFunction(Guid id, string name, FunctionParameter[] parameters, Type returnType, string description, FunctionVisibility visibility, bool llmInlineResult, bool llmCallOnlyOnce, CallbackType callbackType, int clientSessionId, bool requiresInstance = false)
    bool RemoveFunction(string name, FunctionVisibility visibility)
    bool RemoveFunction(string name)
    void RemoveFunctionsByClientSessionId(int clientSessionId)
    Task StartProtocolAsync()
    Task StopProtocolAsync()
    void SyncFunctionsFromGlobalState(GlobalState globalState)
    bool TryGetFunction(string name, out Function? function)
    Task<bool> WaitForFunctionAsync(string functionName, TimeSpan timeout = null, CancellationToken ct = null)
    event Action<ApprovalAuditEntry> ApprovalCompleted
    event Action<Function> FunctionRegistered
    event Action<string> FunctionUnregistered
    event Action<PolicyEvaluationResult> PolicyEvaluated
  sealed class FunctionResultWithData<T>
    ctor(T value, byte[] data)
    byte[] Data { get; }
    T Value { get; }
  static class FunctionUtils
    static ValueTuple<string, string> DecodeFunctionName(string encodedFunctionName)
    static string EncodeFunctionName(string typeName, string functionName)
  enum FunctionVisibility
    Local
    Shared
  class RegisterAllAttribute : Attribute
    ctor()
    bool LlmCallOnlyOnce { get;  set; }
    bool LlmInlineResult { get;  set; }
    FunctionVisibility Visibility { get;  set; }
  sealed class RemoteFunctionCallRequest
    ctor(string functionName)
    CancellationToken CancellationToken { get;  set; }
    string FunctionName { get; }
    Guid? InstanceId { get;  set; }
    object[] Parameters { get;  set; }
    bool PropagateScopes { get;  set; }
    int? TargetId { get;  set; }
    string Version { get;  set; }
  sealed class RemoteFunctionCaller
    ctor(IProtocolMessageChannel protocolMessageChannel, int senderId = 0, TimeSpan? actionAckTimeout = null, TimeSpan? callTimeout = null, int? enumerationBufferCapacity = null)
    TResult Call<TResult>(RemoteFunctionCallRequest request)
    void Call(RemoteFunctionCallRequest request)
    Task<TResult> CallAsync<TResult>(RemoteFunctionCallRequest request)
    Task CallAsync(RemoteFunctionCallRequest request)
    IAsyncEnumerable<TItem> CallAsyncEnumerable<TItem>(RemoteFunctionCallRequest request)
    void CancelAllPendingCalls()
    static object CreateAsyncEnumerableParameter<T>(IAsyncEnumerable<T> source)
    static object CreateEnumerableParameter<T>(IEnumerable<T> source)
    static FunctionParameter CreateParameter<T>(T value)
    static FunctionParameter CreateParameter(Type type, object value)
    Task DisposeInstanceAsync(Guid instanceId, int? targetId = null)
