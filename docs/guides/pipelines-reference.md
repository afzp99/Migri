# Pipelines Reference

## Pipelines API Reference

Full Pipeline framework reference and guide.

---

# Ikon.Pipeline Public API

namespace Ikon.Pipeline
  delegate Pipeline<T>.AsyncEventHandler<T, TEventArgs> where T : IItem<T>
    Task AsyncEventHandler`1<T, TEventArgs>(object sender, TEventArgs e)
  sealed class Pipeline<T>.Branch<T> where T : IItem<T>
    ctor(Pipeline<T> outer, ISourceBlock<T> sourceBlock, IDataflowBlock dataflowBlock)
    Pipeline<T>.Branch<T> Filter(Func<T, Task<bool>> predicate, int? maxParallelism = null)
    Pipeline<T>.Branch<T> Filter<TObject>(int? maxParallelism = null)
    void ForEach(Func<T, Task> func, int? maxParallelism = null)
    Pipeline<T>.Branch<T> Merge(params Pipeline<T>.Branch<T>[] branches)
    void Output(int? maxParallelism = null)
    void Post(T item)
    void Post(List<T> items)
    void Post(IAsyncEnumerable<T> stream)
    Pipeline<T>.Branch<T> Transform(Expression<Func<T, Task<List<T>>>> transformExpr, string id = null, int? maxParallelism = null, int? maxRetries = null, bool? skipCache = null, bool? allowDuplicates = null, ProcessorTags[] tags = null, Type[] retryableExceptionTypes = null)
    Pipeline<T>.Branch<T> TransformBatch(Expression<Func<List<T>, Task<List<T>>>> transformExpr, string id = null, int? maxParallelism = null, int? maxRetries = null, int? maxBatchSize = null, bool? skipCache = null, bool? allowDuplicates = null, ProcessorTags[] tags = null, Type[] retryableExceptionTypes = null)
    Pipeline<T>.Branch<T> TransformBatchLambda(Func<List<T>, Task<List<T>>> transformFunc, string id = null, int? maxParallelism = null, int? maxRetries = null, int? maxBatchSize = null, bool? skipCache = null, bool? allowDuplicates = null, ProcessorTags[] tags = null, Type[] retryableExceptionTypes = null)
    Pipeline<T>.Branch<T> TransformGroup(Expression<Func<T, Task<string>>> groupKeySelectorExpr, Expression<Func<List<T>, Task<List<T>>>> transformExpr, string id = null, int? maxParallelism = null, int? maxRetries = null, bool? skipCache = null, bool? allowDuplicates = null, ProcessorTags[] tags = null, Type[] retryableExceptionTypes = null)
    Pipeline<T>.Branch<T> TransformGroupLambda(Func<T, Task<string>> groupKeyFunc, Func<List<T>, Task<List<T>>> transformFunc, string id = null, int? maxParallelism = null, int? maxRetries = null, bool? skipCache = null, bool? allowDuplicates = null, ProcessorTags[] tags = null, Type[] retryableExceptionTypes = null)
    Pipeline<T>.Branch<T> TransformLambda(Func<T, Task<List<T>>> transformFunc, string id = null, int? maxParallelism = null, int? maxRetries = null, bool? skipCache = null, bool? allowDuplicates = null, ProcessorTags[] tags = null, Type[] retryableExceptionTypes = null)
    Pipeline<T>.Branch<T> TransformStream(Expression<Func<T, IAsyncEnumerable<T>>> transformExpr, string id = null, int? maxParallelism = null, int? maxRetries = null, bool? skipCache = null, bool? allowDuplicates = null, ProcessorTags[] tags = null, Type[] retryableExceptionTypes = null)
    Pipeline<T>.Branch<T> TransformStream(Expression<Func<IAsyncEnumerable<T>, IAsyncEnumerable<T>>> transformExpr, string id = null, int? maxParallelism = null, int? maxRetries = null, bool? skipCache = null, bool? allowDuplicates = null, ProcessorTags[] tags = null, Type[] retryableExceptionTypes = null)
    Pipeline<T>.Branch<T> TransformStreamLambda(Func<T, IAsyncEnumerable<T>> transformFunc, string id = null, int? maxParallelism = null, int? maxRetries = null, bool? skipCache = null, bool? allowDuplicates = null, ProcessorTags[] tags = null, Type[] retryableExceptionTypes = null)
    Pipeline<T>.Branch<T> TransformStreamLambda(Func<IAsyncEnumerable<T>, IAsyncEnumerable<T>> transformFunc, string id = null, int? maxParallelism = null, int? maxRetries = null, bool? skipCache = null, bool? allowDuplicates = null, ProcessorTags[] tags = null, Type[] retryableExceptionTypes = null)
  sealed class PipelineRunner.Config
    ctor()
    bool AllApiKeys { get;  set; }
    string CachePath { get;  set; }
    bool ClearCache { get;  set; }
    string ConfigPath { get;  set; }
    CacheType ContentCacheType { get;  set; }
    bool DefaultDisableProcessCache { get;  set; }
    int? DefaultMaxProcessParallelism { get;  set; }
    int? DefaultMaxRetries { get;  set; }
    List<string> DefaultRetryableExceptionTypes { get;  set; }
    bool DisableInputCache { get;  set; }
    bool DisableMetadataOutput { get;  set; }
    bool DisableOutputCache { get;  set; }
    string DllPath { get;  set; }
    bool EnableRemoteClient { get;  set; }
    bool EnableRemoteHost { get;  set; }
    bool EnableSseOutput { get;  set; }
    bool EnumerateZips { get;  set; }
    string FinalStatusPath { get;  set; }
    string IkonBackendToken { get;  set; }
    string IkonBackendUrl { get;  set; }
    List<string> InputPaths { get;  set; }
    bool IsTestRun { get;  set; }
    bool KeepRunning { get;  set; }
    int LogFilter { get;  set; }
    int? MaxInputReadParallelism { get;  set; }
    int? MaxRemoteRequestParallelism { get;  set; }
    bool OutputFinalStatus { get;  set; }
    List<string> OutputPaths { get;  set; }
    int ProcessFailureThreshold { get;  set; }
    string ProcessingId { get;  set; }
    string RabbitMQConnectionString { get;  set; }
    bool RecursiveInput { get;  set; }
    List<string> RemoteClientProcessorWhiteList { get;  set; }
    int ScanInterval { get;  set; }
    StateType StateType { get;  set; }
    int StatusUpdateInterval { get;  set; }
    string TypeName { get;  set; }
    object UserConfigInstance { get;  set; }
    object UserPipelineInstance { get;  set; }
  sealed class ExposePipelineAttribute : Attribute
    ctor(Type pipelineType, string name = null, PipelineExecutionMode executionMode = None, string schedule = null)
    PipelineExecutionMode ExecutionMode { get; }
    string Name { get; }
    Type PipelineType { get; }
    string Schedule { get; }
  static class FunctionRegistryExtensions
    static void RegisterPipeline<TPipeline>(FunctionRegistry registry, string functionName, string description = null, object configInstance = null)
  interface IPipelineHost<TConfig>
    TConfig Config { get; }
  sealed class LocalFile : IDisposable
    ctor(string mimeType, string existingFilePath = null)
    string MimeType { get; }
    string Path { get; }
    void Dispose()
  sealed class PipelineAttribute : Attribute
    ctor(string description = "", int version = 1, string guid = "", Type inputSchema = null, Type resultSchema = null, string name = null, int maxInputItems = 0, PipelineExecutionMode executionMode = None, string schedule = null)
    string Description { get; }
    PipelineExecutionMode ExecutionMode { get; }
    string Guid { get; }
    Type InputSchema { get; }
    int MaxInputItems { get; }
    string Name { get; }
    Type ResultSchema { get; }
    string Schedule { get; }
    int Version { get; }
  static class PipelineFunction
    static Function Create<TPipeline>(string functionName, string description = null, object configInstance = null)
  struct PipelineFunctionItem
    byte[] Content { get;  init; }
    string MimeType { get;  init; }
    string Name { get;  init; }
    List<string> Tags { get;  init; }
    static PipelineFunctionItem FromBytes(string name, byte[] content, string mimeType = null, List<string> tags = null)
    static PipelineFunctionItem FromString(string name, string content, string mimeType = null, List<string> tags = null)
    string GetContentAsString()
  sealed class PipelineRunner : IDisposable
    ctor()
    void Dispose()
    Task Initialize(PipelineRunner.Config config)
    Task Initialize<TPipeline>(TPipeline userPipelineInstance = null, object userConfigInstance = null, bool usePersistentCache = false, string cachePath = null, bool keepRunning = false, string outputPath = null, bool allApiKeys = false)
    Task InitializeForUnitTest()
    Task<List<Item>> Run(List<Item> items = null, CancellationToken cancellationToken = null)
    IAsyncEnumerable<Item> RunAsEnumerable(List<Item> items = null, CancellationToken cancellationToken = null)
    static Task RunInExternalAssembly(string configJson, Action<string> onStatusUpdate, CancellationToken cancellationToken)
    static Task RunRemote(PipelineRunner.Config config, Action<PipelineStatus> onStatusUpdate, CancellationToken cancellationToken = null)
    Task RunWithoutCollecting(List<Item> items = null, CancellationToken cancellationToken = null)
    event Pipeline<T>.AsyncEventHandler<Item, Item> Output
    event EventHandler<PipelineStatus> StatusUpdate
  sealed class PipelineRunnerInvoker
    static Task<PipelineRunnerInvoker> Create(string pipelineDllPath)
    Task Run(string configJson, Action<string> onStatusUpdate, CancellationToken cancellationToken)
  sealed class PipelineStatus
    ctor()
    int DuplicateItemCount { get;  set; }
    TimeSpan Duration { get;  set; }
    int ErrorLogCount { get;  set; }
    bool HasCompleted { get;  set; }
    bool HasFaulted { get;  set; }
    int InputItemCacheHits { get;  set; }
    int InputItemCacheMiss { get; }
    int InputItemCount { get;  set; }
    int InvalidItemCount { get;  set; }
    int OutputItemCacheHits { get;  set; }
    int OutputItemCacheMiss { get; }
    int OutputItemCount { get;  set; }
    int ProcessFailureCount { get;  set; }
    int ProcessRetryCount { get;  set; }
    int ProcessedItemCacheHits { get;  set; }
    int ProcessedItemCacheMiss { get; }
    int ProcessedItemCount { get;  set; }
    string ProcessingId { get;  set; }
    DateTime StartTime { get;  set; }
    Dictionary<string, double> Usages { get;  set; }
    int WarningLogCount { get;  set; }
    bool WasCancelled { get;  set; }
  sealed class Pipeline<T>.PipelineStatus<T> where T : IItem<T>
    ctor()
    TimeSpan Duration { get;  set; }
    int ErrorLogCount { get;  set; }
    int ProcessFailureCount { get;  set; }
    int ProcessRetryCount { get;  set; }
    int ProcessedItemCacheHits { get;  set; }
    int ProcessedItemCount { get;  set; }
    int WarningLogCount { get;  set; }
  sealed class Pipeline<T> where T : IItem<T>
    Task Completion { get; }
    Pipeline<T>.PipelineStatus<T> Status { get; }
    void Complete()
    Pipeline<T>.Branch<T> Inputs()
    bool Post(T item)
    event Pipeline<T>.AsyncEventHandler<T, T> Output
  sealed class ProcessorAttribute : Attribute
    ctor(string id = null, int version = 1, int maxParallelism = 0, int maxRetries = 0, bool isRemote = false, bool skipCache = false, bool allowDuplicates = true, ProcessorTags[] tags = null, Type[] retryableExceptionTypes = null)
    bool AllowDuplicates { get;  set; }
    string Id { get;  set; }
    bool IsRemote { get;  set; }
    int MaxParallelism { get;  set; }
    int MaxRetries { get;  set; }
    Type[] RetryableExceptionTypes { get;  set; }
    bool SkipCache { get;  set; }
    ProcessorTags[] Tags { get;  set; }
    int Version { get;  set; }
  enum ProcessorTags
    Gpu
  sealed class Pipeline<T>.RemoteCall<T> where T : IItem<T>
    ctor(Pipeline<T> pipeline, object instance, string processorName, object[] args)
    object[] Args { get; }
    object Instance { get; }
    Pipeline<T> Pipeline { get; }
    string ProcessorName { get; }
  static class Pipeline<T>.RemoteCallHelper<T> where T : IItem<T>
    static object BlockOnResult(Task<object> task)
    static Task<object> CallRemoteAsync(Pipeline<T> pipeline, object instance, MethodInfo method, ProcessorAttribute attr, object[] args)
    static IAsyncEnumerable<TR> CallRemoteStreamAsync<TR>(Pipeline<T> pipeline, object instance, MethodInfo method, ProcessorAttribute attr, object[] args)
    static Task<RT> CastTaskResult<RT>(Task<object> task)
    static Task IgnoreTaskResult(Task<object> task)

namespace Ikon.Pipeline.ContentCache
  enum CacheType
    InMemory
    FileSystem

namespace Ikon.Pipeline.Items
  interface IItem<T>
    abstract Task<bool> IsObjectAsync<TObject>()
    abstract T WithProcessId(Guid processId)
  struct Item : IItem<Item>
    ctor()
    string GroupId { get;  init; }
    string Hash { get;  init; }
    string InitialPath { get;  init; }
    bool IsDefault { get; }
    ItemMetadata? Metadata { get;  init; }
    string MimeType { get;  init; }
    string Name { get;  init; }
    IReadOnlyList<string> ParentHashes { get;  init; }
    Guid ProcessId { get;  init; }
    IReadOnlyList<string> Tags { get;  init; }
    static Task<Item> Create(List<Item> parents, string name, Stream content, string mimeTypeOverride = null, List<string> tags = null, ItemMetadata? metadata = null)
    static Task<Item> Create(Item parent, string name, Stream content, string mimeTypeOverride = null, List<string> tags = null, ItemMetadata? metadata = null)
    static Task<Item> Create(List<Item> parents, string name, string content, string mimeTypeOverride = null, List<string> tags = null, ItemMetadata? metadata = null)
    static Task<Item> Create(Item parent, string name, string content, string mimeTypeOverride = null, List<string> tags = null, ItemMetadata? metadata = null)
    static Task<Item> Create(List<Item> parents, string name, byte[] content, string mimeTypeOverride = null, List<string> tags = null, ItemMetadata? metadata = null)
    static Task<Item> Create(Item parent, string name, byte[] content, string mimeTypeOverride = null, List<string> tags = null, ItemMetadata? metadata = null)
    static Task<Item> Create(List<Item> parents, string name, LocalFile content, List<string> tags = null, ItemMetadata? metadata = null)
    static Task<Item> Create(Item parent, string name, LocalFile content, List<string> tags = null, ItemMetadata? metadata = null)
    static Task<Item> CreateFromObject<T>(List<Item> parents, string name, T content, List<string> tags = null, ItemMetadata? metadata = null, JsonSerializerOptions jsonSerializerOptions = null)
    static Task<Item> CreateFromObject<T>(Item parent, string name, T content, List<string> tags = null, ItemMetadata? metadata = null, JsonSerializerOptions jsonSerializerOptions = null)
    static Task<Item> CreateInitial(string name, Stream content, string mimeTypeOverride = null, List<string> tags = null, ItemMetadata? metadata = null)
    static Task<Item> CreateInitial(string name, string content, string mimeTypeOverride = null, List<string> tags = null, ItemMetadata? metadata = null)
    static Task<Item> CreateInitial(string name, byte[] content, string mimeTypeOverride = null, List<string> tags = null, ItemMetadata? metadata = null)
    static Task<Item> CreateInitialFromObject<T>(string name, T content, ItemMetadata? metadata = null, List<string> tags = null, JsonSerializerOptions jsonSerializerOptions = null)
    Task<byte[]> GetContentAsBytes()
    Task<TObject> GetContentAsObject<TObject>()
    Task<Stream> GetContentAsStream()
    Task<string> GetContentAsString()
    string GetGroupId()
    Task<string> GetGroupIdAsync()
    Task<LocalFile> GetLocalFile()
    string GetOriginalName()
    Task<string> GetOriginalNameAsync()
    string GetOriginalPath()
    Task<string> GetOriginalPathAsync()
    string GetPageId()
    Task<string> GetPageIdAsync()
    Task<List<Item>> GetParents()
    string GetProcessId()
    Task<string> GetProcessIdAsync()
    bool HasTags(params string[] tags)
    Task<bool> HasTagsAsync(params string[] tags)
    bool IsAudio()
    Task<bool> IsAudioAsync()
    bool IsBinary()
    Task<bool> IsBinaryAsync()
    bool IsCsv()
    Task<bool> IsCsvAsync()
    bool IsImage()
    Task<bool> IsImageAsync()
    bool IsJson()
    Task<bool> IsJsonAsync()
    bool IsMicrosoftExcel()
    Task<bool> IsMicrosoftExcelAsync()
    bool IsMicrosoftPowerpoint()
    Task<bool> IsMicrosoftPowerpointAsync()
    bool IsMicrosoftWord()
    Task<bool> IsMicrosoftWordAsync()
    bool IsObject<TObject>()
    bool IsObject()
    Task<bool> IsObjectAsync<TObject>()
    Task<bool> IsObjectAsync()
    bool IsPdf()
    Task<bool> IsPdfAsync()
    bool IsText()
    Task<bool> IsTextAsync()
    bool IsVideo()
    Task<bool> IsVideoAsync()
    bool IsXml()
    Task<bool> IsXmlAsync()
    static Item ReadFromTeleport(ReadOnlySpan<byte> data)
    Item With(string name = null, string mimeType = null, Guid? processId = null, string groupId = null, List<string> tags = null, ItemMetadata? metadata = null)
    Item WithProcessId(Guid processId)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static string ObjectMimeTypePrefix
    static uint TeleportVersion
  static class ItemExtensions
    static Item? FirstOrNull(IEnumerable<Item> items, Func<Item, bool> predicate)
    static Item? FirstOrNull(IEnumerable<Item> items)
  struct ItemMetadata
    ctor()
    ctor(ItemMetadata? parent, string previousItemName = null, string nextItemName = null, string originalPath = null, string originalName = null, DateTime? createdAt = null, DateTime? updatedAt = null, string documentType = null, string documentTitle = null, IReadOnlyList<string> titleHierarchy = null, int? pageNumber = null, IReadOnlyList<int> pageNumbers = null, int? pageCount = null, IReadOnlyDictionary<string, string> properties = null, string customJson = null)
    DateTime? CreatedAt { get;  init; }
    string CustomJson { get;  init; }
    string DocumentTitle { get;  init; }
    string DocumentType { get;  init; }
    string NextItemName { get;  init; }
    string OriginalName { get;  init; }
    string OriginalPath { get;  init; }
    int? PageCount { get;  init; }
    int? PageNumber { get;  init; }
    IReadOnlyList<int> PageNumbers { get;  init; }
    string PreviousItemName { get;  init; }
    IReadOnlyDictionary<string, string> Properties { get;  init; }
    IReadOnlyList<string> TitleHierarchy { get;  init; }
    DateTime? UpdatedAt { get;  init; }
    static ItemMetadata ReadFromTeleport(ReadOnlySpan<byte> data)
    ItemMetadata With(string previousItemName = null, string nextItemName = null, string originalPath = null, string originalName = null, DateTime? createdAt = null, DateTime? updatedAt = null, string documentType = null, string documentTitle = null, IReadOnlyList<string> titleHierarchy = null, int? pageNumber = null, IReadOnlyList<int> pageNumbers = null, int? pageCount = null, IReadOnlyDictionary<string, string> properties = null, string customJson = null)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion

namespace Ikon.Pipeline.Remote.Bus
  interface IRemoteCallBus
    abstract Task<RemoteCallResult> Client_CallHostFunction(RemoteCallMessage message, CancellationToken cancellationToken = null)
    virtual IAsyncEnumerable<RemoteCallResult> Client_GetFunctionCallResults(CancellationToken cancellationToken = null)
    abstract IAsyncEnumerable<RemoteCallMessage> Client_GetProcessorCalls(CancellationToken cancellationToken = null)
    abstract Task Client_HostProcessorCallResult(RemoteCallResult result)
    abstract Task Host_CallProcessor(RemoteCallMessage message)
    virtual Task Host_ClientFunctionCallResult(RemoteCallResult result)
    virtual IAsyncEnumerable<RemoteCallMessage> Host_GetFunctionCalls(CancellationToken cancellationToken = null)
    abstract IAsyncEnumerable<RemoteCallResult> Host_GetProcessorCallResults(CancellationToken cancellationToken = null)
  sealed class RabbitMQRemoteCallBus : IDisposable, IRemoteCallBus
    Task<RemoteCallResult> Client_CallHostFunction(RemoteCallMessage message, CancellationToken cancellationToken = null)
    IAsyncEnumerable<RemoteCallResult> Client_GetFunctionCallResults(CancellationToken cancellationToken = null)
    IAsyncEnumerable<RemoteCallMessage> Client_GetProcessorCalls(CancellationToken cancellationToken = null)
    Task Client_HostProcessorCallResult(RemoteCallResult result)
    static Task<RabbitMQRemoteCallBus> CreateAsync(string connectionString, bool isHost, bool isClient, List<string> processorWhiteList = null)
    void Dispose()
    Task Host_CallProcessor(RemoteCallMessage message)
    Task Host_ClientFunctionCallResult(RemoteCallResult result)
    IAsyncEnumerable<RemoteCallMessage> Host_GetFunctionCalls(CancellationToken cancellationToken = null)
    IAsyncEnumerable<RemoteCallResult> Host_GetProcessorCallResults(CancellationToken cancellationToken = null)
    void SetWhiteList(List<string> processorNames)
  sealed class RemoteCallMessage
    ctor()
    ctor(string processorName, object[] args, Guid correlationId)
    string[] ArgsJson { get;  set; }
    Guid CorrelationId { get;  set; }
    string ProcessorName { get;  set; }
    T GetArg<T>(int index)
  sealed class RemoteCallResult
    ctor()
    ctor(string processorName, Guid correlationId, string resultJson, RemoteCallResultType remoteCallResultType, string errorMessage = "")
    Guid CorrelationId { get;  set; }
    string ErrorMessage { get;  set; }
    string ProcessorName { get;  set; }
    string ResultJson { get;  set; }
    RemoteCallResultType ResultType { get;  set; }
    T GetResult<T>()
  enum RemoteCallResultType
    Success
    Streaming
    StreamingDone
    Failed

namespace Ikon.Pipeline.Spec
  sealed class PipelineSpec
    ctor()
    object Config { get;  set; }
    string Guid { get;  set; }
    object Input { get;  set; }
    Dictionary<string, object> OpenApiSpec { get;  set; }
    object Result { get;  set; }
  static class PipelineSpecGenerator
    static PipelineSpec Generate(Type pipelineType, bool includeExamples = true)

namespace Ikon.Pipeline.State
  enum StateType
    InMemory
    Sqlite
    SqLiteBatch


---

# Ikon Pipeline Guide

## Overview

The Ikon Pipeline is a reactive asynchronous parallel data processing framework designed for high-performance workloads. It enables you to define the structure of a processing graph once while relying on an intelligent caching system to determine which steps need re-execution when the pipeline runs again.

Key capabilities:

- **Reactive scheduling**: The pipeline run specifies the structure of the processing graph. When executed, the caching system determines what needs to be re-processed based on what has changed since the last run (code, configuration, or input changes).
- **Fully asynchronous**: Every aspect of the pipeline operates asynchronously, from pipeline definition to runtime execution.
- **Parallel processing**: Processors run in parallel where dependencies allow, fully utilizing the processing power of the host machine.
- **Step-level caching**: Every processing step is cached with automatic invalidation based on processor identity, version, configuration, and input state. This avoids unnecessary re-processing and significantly speeds up subsequent runs.
- **Flexible execution**: Pipelines can be invoked directly from code or executed with the `ikon` CLI tool.
- **Distributed execution**: Support for remote host/client modes enables distributing processor execution across multiple machines.

## Defining and Running a Simple Pipeline

Create a pipeline class and annotate it with `[Pipeline]`. Implement a `Run` method with the required signature and compose processing steps using branch operations. Annotate processor methods with `[Processor]`.

```csharp
using Ikon.Common;
using Ikon.Common.Core;
using Ikon.Pipeline;
using Ikon.Pipeline.Items;

[Pipeline]
private class SimplePipeline
{
    // Pipelines must have a Run method with this signature
    // The cancellation token is optional and can be omitted
    public async Task Run(Pipeline<Item>.Branch inputItems, CancellationToken cancellationToken)
    {
        // Transform one item at a time (but in parallel) using the MyProcessor function
        var outputItems = inputItems.Transform(item => MyProcessor(item, "my parameter", cancellationToken));

        // Output the processed items from the pipeline
        outputItems.Output();
    }

    // Processor input parameters are flexible - choose what you need
    [Processor]
    private static async Task<List<Item>> MyProcessor(Item inputItem, string myParameter, CancellationToken cancellationToken)
    {
        var content = await inputItem.GetContentAsString();
        content = $"{content} - Processed with parameter: {myParameter}";
        var outputItem = await Item.Create(inputItem, $"{inputItem.Name}.example", content, MimeTypes.TextPlain);

        return [outputItem]; // Can return empty list if no output is desired
    }
}
```

### Running the Pipeline

Instantiate a `PipelineRunner`, initialize it with the pipeline type, and submit items for processing.

```csharp
using Ikon.Pipeline;
using Ikon.Pipeline.Items;

using var pipelineRunner = new PipelineRunner();
await pipelineRunner.Initialize<SimplePipeline>();

List<Item> inputItems = [];

for (int i = 0; i < 10; i++)
{
    var item = await Item.CreateInitial($"item{i + 1}", $"Content of item {i + 1}", MimeTypes.TextPlain);
    inputItems.Add(item);
}

var outputItems = await pipelineRunner.Run(inputItems);

foreach (var outputItem in outputItems)
{
    var content = await outputItem.GetContentAsString();
    Log.Instance.Info($"Output item, Name={outputItem.Name}, MimeType={outputItem.MimeType}, Content='{content}'");
}
```

### Streaming Results with RunAsEnumerable

`RunAsEnumerable` streams results as soon as processors emit them, which is useful for long-running workflows.

```csharp
using var pipelineRunner = new PipelineRunner();
await pipelineRunner.Initialize<SimplePipeline>();

List<Item> inputItems = [];

for (int i = 0; i < 10; i++)
{
    var item = await Item.CreateInitial($"item{i + 1}", $"Content of item {i + 1}", MimeTypes.TextPlain);
    inputItems.Add(item);
}

await foreach (var outputItem in pipelineRunner.RunAsEnumerable(inputItems))
{
    var content = await outputItem.GetContentAsString();
    Log.Instance.Info($"Output item, Name={outputItem.Name}, MimeType={outputItem.MimeType}, Content='{content}'");
}
```

### Configuring the Runner

`PipelineRunner.Initialize` accepts a `PipelineRunner.Config` object for fine-grained control over processor retry limits, metadata output, type discovery, and more.

```csharp
using var pipelineRunner = new PipelineRunner();

var pipelineRunnerConfig = new PipelineRunner.Config
{
    TypeName = typeof(SimplePipeline).FullName!,
    ProcessFailureThreshold = 2,
    DisableMetadataOutput = true
    // Additional options available, such as cache paths, default retry configuration, and remote execution toggles
};

await pipelineRunner.Initialize(pipelineRunnerConfig);

List<Item> inputItems = [];

for (int i = 0; i < 10; i++)
{
    var item = await Item.CreateInitial($"item{i + 1}", $"Content of item {i + 1}", MimeTypes.TextPlain);
    inputItems.Add(item);
}

var outputItems = await pipelineRunner.Run(inputItems);

foreach (var outputItem in outputItems)
{
    var content = await outputItem.GetContentAsString();
    Log.Instance.Info($"Output item, Name={outputItem.Name}, MimeType={outputItem.MimeType}, Content='{content}'");
}
```

### Cancellation Support

Pass a `CancellationToken` when invoking the pipeline to halt execution cooperatively.

```csharp
using var pipelineRunner = new PipelineRunner();
await pipelineRunner.Initialize<SimplePipeline>();

List<Item> inputItems = [];

for (int i = 0; i < 10; i++)
{
    var item = await Item.CreateInitial($"item{i + 1}", $"Content of item {i + 1}", MimeTypes.TextPlain);
    inputItems.Add(item);
}

List<Item> outputItems = [];
var cts = new CancellationTokenSource();

try
{
    outputItems = await pipelineRunner.Run(inputItems, cts.Token);
}
catch (OperationCanceledException)
{
    Log.Instance.Info("Pipeline run was cancelled");
}

foreach (var outputItem in outputItems)
{
    var content = await outputItem.GetContentAsString();
    Log.Instance.Info($"Output item, Name={outputItem.Name}, MimeType={outputItem.MimeType}, Content='{content}'");
}
```

## Creating Items

Pipelines operate on immutable `Item` instances that carry content, metadata, and lineage.

### Initial Items

Initial items are created outside a pipeline run (but after pipeline initialization) and are meant to be given as input to a pipeline. Initial items do not have any parent item(s) and must not be created inside a processor.

```csharp
List<Item> inputItems = [];

// Create an initial item from a string
// MIME type specified for small text content as automatic detection may not work well
string stringContent = "This is a string content";
inputItems.Add(await Item.CreateInitial("string_item_name", stringContent, mimeTypeOverride: MimeTypes.TextPlain));

// Create an initial item from a byte array
// MIME type will be analyzed from the content
byte[] byteContent = new byte[1024];
inputItems.Add(await Item.CreateInitial("binary_item_name", byteContent));

// Create an initial item from a stream
// MIME type will be analyzed from the content
await using var stream = new MemoryStream(1024);
inputItems.Add(await Item.CreateInitial("stream_item_name", stream));

// Create an initial item from an object (will be serialized to JSON)
// MIME type will be set automatically
var exampleData = new ExampleData();
inputItems.Add(await Item.CreateInitialFromObject("object_item_name", exampleData));
```

The examples rely on a simple data transfer object for object-based items:

```csharp
private class ExampleData
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Occupation { get; set; } = string.Empty;
}
```

### Items Produced by Processors

Non-`Item.CreateInitial*` functions are meant to be used inside processors and (almost) always take in a parent item. The `name` parameter specifies the full item name. Use string interpolation to derive names from parent items. It is also possible, though uncommon, to create items without parents.

```csharp
Item parentItem = /* existing pipeline item */;
Item anotherParentItem = /* another pipeline item */;
List<Item> outputItems = [];

// Create an item from a string with single parent
string stringContent = "This is a string content";
outputItems.Add(await Item.Create(parentItem, $"{parentItem.Name}.name_suffix", stringContent, mimeTypeOverride: MimeTypes.TextPlain));

// Create an item from a string with multiple parents
outputItems.Add(await Item.Create([parentItem, anotherParentItem], "full_item_name", stringContent, mimeTypeOverride: MimeTypes.TextPlain));

// Create an item from a string without any parents (not recommended, but possible)
outputItems.Add(await Item.Create([], "full_item_name", stringContent, mimeTypeOverride: MimeTypes.TextPlain));

// Create an item from a byte array
// MIME type will be analyzed from the content
byte[] byteContent = new byte[1024];
outputItems.Add(await Item.Create(parentItem, $"{parentItem.Name}.name_suffix", byteContent));

// Create an item from a stream
// MIME type will be analyzed from the content
await using var stream = new MemoryStream(1024);
outputItems.Add(await Item.Create(parentItem, $"{parentItem.Name}.name_suffix", stream));

// Create an item from an object (will be serialized to JSON)
// MIME type will be set automatically
var exampleData = new ExampleData();
outputItems.Add(await Item.CreateFromObject(parentItem, $"{parentItem.Name}.name_suffix", exampleData));
```

## Reading Item Content

Items provide asynchronous helpers for working with content in multiple representations.

```csharp
Item parentItem = /* existing pipeline item */;

var stringItem = await Item.Create(parentItem, $"{parentItem.Name}.string", "This is a string content", mimeTypeOverride: MimeTypes.TextPlain);
var byteItem = await Item.Create(parentItem, $"{parentItem.Name}.bytes", new byte[1024]);
await using var stream = new MemoryStream(1024);
var streamItem = await Item.Create(parentItem, $"{parentItem.Name}.stream", stream);
var exampleData = new ExampleData { Name = "John Doe", Age = 30, Occupation = "Engineer" };
var objectItem = await Item.CreateFromObject(parentItem, $"{parentItem.Name}.object", exampleData);

// Get item content as string
string stringContent = await stringItem.GetContentAsString();
Log.Instance.Info($"String content: {stringContent}");

// Get item content as byte array
byte[] byteContent = await byteItem.GetContentAsBytes();
Log.Instance.Info($"Byte content length: {byteContent.Length}");

// Get item content as stream
await using Stream streamContent = await streamItem.GetContentAsStream();
Log.Instance.Info($"Stream content length: {streamContent.Length}");

// Get item content as deserialized object
ExampleData objectContent = await objectItem.GetContentAsObject<ExampleData>();
Log.Instance.Info($"Object content: Name={objectContent.Name}, Age={objectContent.Age}, Occupation={objectContent.Occupation}");
```

## Working with Local Files

Use `LocalFile` to interoperate with APIs that require filesystem access. Temporary files are cleaned up automatically when the `LocalFile` is disposed.

```csharp
Item parentItem = /* existing pipeline item */;
var sourceItem = await Item.Create(parentItem, $"{parentItem.Name}.bytes", new byte[1024]);

// Copy any item to a temporary local file system file
// Useful for external libraries that can only read from a file path
// The local file will be automatically deleted when disposed
using (var localFile = await sourceItem.GetLocalFile())
{
    Log.Instance.Info($"Local file, Path={localFile.Path}, MimeType={localFile.MimeType}");
}

// Create a temporary local file path for writing
// You can give this path to external libraries to write content to
// An item can then be created from the local file
// The file will be automatically deleted when disposed
using (var localFile = new LocalFile(MimeTypes.TextPlain))
{
    await File.WriteAllTextAsync(localFile.Path, "This is some text content");
    var outputItem = await Item.Create(parentItem, "my_item", localFile);
}
```

## Advanced Pipeline Composition

Pipelines can accept strongly typed configuration through dependency injection of `IPipelineHost<TConfig>` and provide rich branching primitives for filtering, batching, streaming, grouping, and observation.

```csharp
// If a config object is desired, the pipeline class can take in an IPipelineHost<TConfig> parameter
// The user supplies the config either as an object or JSON when running the pipeline
// The config will be accessible via the host.Config property
[Pipeline]
private class AdvancedPipeline(IPipelineHost<AdvancedPipeline.Config> host)
{
    // The config object is a user-defined POD class
    public class Config
    {
        public int ConfigValue1 { get; set; } = 1;
        public string ConfigValue2 { get; set; } = "ConfigValue";
    }

    public async Task Run(Pipeline<Item>.Branch inputItems, CancellationToken cancellationToken)
    {
        // Filter items to only those having the "even" tag
        var evenItems = inputItems.Filter(item => item.HasTagsAsync("even"));

        // Filter items to only those having the "odd" tag
        var oddItems = inputItems.Filter(item => item.HasTagsAsync("odd"));

        // Filter items to only those that are objects of type ExampleData
        var objectItems = inputItems.Filter(item => item.IsObjectAsync<ExampleData>());

        // Filter items to only those that are images (based on MIME type)
        var imageItems = inputItems.Filter(item => item.IsImageAsync());

        // All Transform* functions take an expression; the easiest way is to pass a function with parameters
        // The variable values inside the expression are read and used to calculate a hash for the processor call
        // If any of the variable values change, then possible caching for that processor is skipped and it runs
        // If processor name, version, and expression variables are the same as a previous run, cached results are used

        // Process each item separately but in parallel
        evenItems = evenItems.Transform(item => MyProcessor(item, host.Config.ConfigValue2, cancellationToken));

        // Gather items into batches and process each batch in parallel
        // Batch size can be set with maxBatchSize parameter
        oddItems = oddItems.TransformBatch(items => MyBatchProcessor(items, host.Config.ConfigValue2, cancellationToken));

        // Process each item and produce multiple output items as a stream
        var itemToStreamItems = objectItems.TransformStream(item => MyItemToStreamProcessor(item, host.Config.ConfigValue2, cancellationToken));

        // Process multiple input items as a stream and produce multiple output items as a stream
        var streamToStreamItems = oddItems.TransformStream(items => MyStreamToStreamProcessor(items, host.Config.ConfigValue2, cancellationToken));

        // Merge multiple branches into one
        var mergedItems = evenItems.Merge(oddItems, itemToStreamItems, streamToStreamItems);

        // Group items by a key (here process ID) and process each group as a batch
        // Grouping ID can be any string value
        var groupProcessedItems = mergedItems.TransformGroup(item => item.GetProcessIdAsync(), items => MyBatchProcessor(items, host.Config.ConfigValue2, cancellationToken));

        // ForEach can be used to run code for each item without producing any output items
        imageItems.ForEach(async item =>
        {
            Log.Instance.Info($"Image item Name={item.Name}, MimeType={item.MimeType}");
        });

        // All Transform* functions also have a TransformLambda* counterpart that takes a lambda instead of an expression
        // Their use is discouraged as the lambda cannot be analyzed for variable values and thus caching is less effective
        // Also, transparent remote processor handling cannot be used with lambdas
        var doNotUseTransformLambdaItems = inputItems.TransformLambda(async item =>
        {
            return await MyProcessor(item, host.Config.ConfigValue2, cancellationToken);
        });

        // Calling output on any branch outputs those items from the pipeline
        groupProcessedItems.Output();
    }

    [Processor]
    private static async Task<List<Item>> MyProcessor(Item inputItem, string myParameter, CancellationToken cancellationToken)
    {
        var content = await inputItem.GetContentAsString();
        content = $"{content} - Single processed with parameter: {myParameter}";
        var outputItem = await Item.Create(inputItem, $"{inputItem.Name}.processed", content, MimeTypes.TextPlain);

        return [outputItem];
    }

    [Processor]
    private static async Task<List<Item>> MyBatchProcessor(List<Item> inputItems, string myParameter, CancellationToken cancellationToken)
    {
        List<Item> outputItems = [];

        foreach (var item in inputItems)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var content = await item.GetContentAsString();
            content = $"{content} - Batch processed with parameter: {myParameter}";
            var outputItem = await Item.Create(item, $"{item.Name}.batch_processed", content, MimeTypes.TextPlain);
            outputItems.Add(outputItem);
        }

        return outputItems;
    }

    [Processor]
    private static async IAsyncEnumerable<Item> MyItemToStreamProcessor(Item inputItem, string myParameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // It is assumed that the input item is an object of type ExampleData
        var data = await inputItem.GetContentAsObject<ExampleData>();

        for (int i = 0; i < 10; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var content = await inputItem.GetContentAsString();
            content = $"{content} - Streamed output {i + 1} with parameter {myParameter} for object {data.Name}, Age {data.Age}, Occupation {data.Occupation}";
            var outputItem = await Item.Create(inputItem, $"{inputItem.Name}.stream_processed{i + 1}", content, MimeTypes.TextPlain);
            yield return outputItem;
        }
    }

    [Processor]
    private static async IAsyncEnumerable<Item> MyStreamToStreamProcessor(IAsyncEnumerable<Item> inputItems, string myParameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var item in inputItems.WithCancellation(cancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            var content = await item.GetContentAsString();
            content = $"{content} - Stream-to-stream processed with parameter: {myParameter}";
            var outputItem = await Item.Create(item, $"{item.Name}.stream2stream_processed", content, MimeTypes.TextPlain);
            yield return outputItem;
        }
    }
}
```

### Running the Advanced Pipeline

Supply a configuration instance, enable persistent caching, and provide rich input collections including tagged items and binary payloads.

```csharp
using var pipelineRunner = new PipelineRunner();

var myPipelineConfig = new AdvancedPipeline.Config
{
    ConfigValue1 = 42,
    ConfigValue2 = "The answer"
};

await pipelineRunner.Initialize<AdvancedPipeline>(
    userConfigInstance: myPipelineConfig, // Give the user config instance to the pipeline runner
    usePersistentCache: true // This Initialize overload has common useful options (for full control, see the overload taking PipelineRunner.Config)
);

List<Item> inputItems = [];

for (int i = 0; i < 10; i++)
{
    List<string> tags = i % 2 == 0 ? ["even"] : ["odd"];
    var item = await Item.CreateInitial($"item{i}", $"Content of item {i}", MimeTypes.TextPlain, tags);
    inputItems.Add(item);
}

inputItems.Add(await Item.CreateInitialFromObject("object_item", new ExampleData { Name = "Alice", Age = 28, Occupation = "Designer" }));
inputItems.Add(await Item.CreateInitial("image_item", new byte[2048], MimeTypes.ImagePng));

var outputItems = await pipelineRunner.Run(inputItems);

foreach (var outputItem in outputItems)
{
    var content = await outputItem.GetContentAsString();
    Log.Instance.Info($"Output item, Name={outputItem.Name}, MimeType={outputItem.MimeType}, Content='{content}'");
}
```

## Running Pipelines with the ikon CLI

Use `ikon pipeline run` to execute a pipeline outside your application code.

### Common Options

| Option | Description |
|--------|-------------|
| `--type-name` | Fully qualified pipeline type to execute. Required when running from pre-built assemblies or when multiple pipelines exist in the project. |
| `--dll-path` | Load the pipeline from an external assembly instead of the current project. |
| `--input` | One or more input files, directories (supports wildcards), or asset URIs. Separate multiple paths with commas. |
| `--recursive` | Recursively enumerate input directories and wildcards. |
| `--config` | Path to a JSON configuration file whose contents are provided to the pipeline host configuration model. |
| `--output` | One or more output destinations (files, directories, or asset URIs) where generated items should be written. Separate multiple paths with commas. |

### Example Usage

```bash
# Run a pipeline from a compiled DLL with input files
ikon pipeline run --dll-path ./bin/Release/MyPipeline.dll --type-name MyNamespace.MyPipeline --input ./data/*.json --output ./output/

# Run with configuration and recursive input scanning
ikon pipeline run --dll-path ./bin/Release/MyPipeline.dll --type-name MyNamespace.MyPipeline --input ./data/ --recursive --config ./pipeline-config.json --output ./output/
```

Additional parameters cover cache directories, retry configuration, remote execution flags, and status reporting. Run `ikon pipeline run --help` for a complete listing.

## Remote Host and Client Modes

The pipeline runner can operate in remote host and client modes to distribute processor execution across multiple machines. This enables scaling processor workloads horizontally using a message bus (RabbitMQ) for communication.

### Prerequisites

Before running distributed pipelines:

1. **RabbitMQ must be running**: The message bus must be operational and accessible before starting any host or client processes.

2. **Shared cache directory**: Host and all clients must have access to the same cache directory path. Items are transmitted through the message bus as lightweight metadata containing a content hash pointer. The actual content is stored in and read from the shared cache. On a single machine, use the same `--cache` path for all processes. For multi-machine deployments, use a shared network drive or NFS mount.

3. **Same pipeline DLL**: All processes (host and clients) must use the same compiled pipeline DLL.

### Defining Remote Processors

Mark processors for remote execution using the `isRemote` parameter in the `[Processor]` attribute:

```csharp
[Pipeline]
public class DistributedPipeline(IPipelineHost<DistributedPipeline.Config> host)
{
    public class Config
    {
        public int DelayMs { get; set; } = 100;
    }

    public async Task Run(Pipeline<Item>.Branch inputItems)
    {
        var stage1 = inputItems.Transform(item => ProcessorA(item, host.Config.DelayMs));
        var stage2 = stage1.Transform(item => ProcessorB(item, host.Config.DelayMs));
        stage2.Output();
    }

    // Mark processor for remote execution with isRemote: true
    // The version parameter is used for cache invalidation and processor identification
    [Processor(isRemote: true, version: 1)]
    private static async Task<List<Item>> ProcessorA(Item item, int delayMs)
    {
        await Task.Delay(delayMs);
        var content = await item.GetContentAsString();
        content += "->A";
        return [await Item.Create(item, $"{item.Name}.a", content, MimeTypes.TextPlain)];
    }

    [Processor(isRemote: true, version: 1)]
    private static async Task<List<Item>> ProcessorB(Item item, int delayMs)
    {
        await Task.Delay(delayMs);
        var content = await item.GetContentAsString();
        content += "->B";
        return [await Item.Create(item, $"{item.Name}.b", content, MimeTypes.TextPlain)];
    }
}
```

**Important limitations for remote processors:**
- `CancellationToken` parameters are **not supported** in remote processors. Remove any `CancellationToken` parameters from methods marked with `isRemote: true`.
- All processor parameters must be JSON-serializable.

### Host Mode

Enable host mode with `PipelineRunner.Config.EnableRemoteHost` or `ikon pipeline run --remote-host`. The host:

- Reads input items and orchestrates the pipeline graph
- Dispatches remote processor calls to clients via the message bus
- Maintains the shared state and content cache
- Collects results and produces output items

### Client Mode

Enable client mode with `PipelineRunner.Config.EnableRemoteClient` or `ikon pipeline run --remote-client`. The client:

- Connects to the message bus and listens for processor calls
- Executes processors locally using content from the shared cache
- Returns results to the host via the message bus
- Runs indefinitely until terminated

### Startup Order

**Critical: Clients must start before the host.** RabbitMQ discards messages if no consumer is bound to a queue. If you start the host first, processor calls may be lost before clients connect.

Recommended startup sequence:
1. Ensure RabbitMQ is running
2. Start all client processes
3. Wait a few seconds for clients to bind to queues
4. Start the host process

### Processor Name Format

Remote processors are identified by their fully qualified name in the format:

```
{Namespace}.{ClassName}.{MethodName}.{Version}
```

For example, the `ProcessorA` method above would have the name:
```
MyNamespace.DistributedPipeline.ProcessorA.1
```

This name format is used when configuring the client processor whitelist.

### Configuration Options

| Option | Description |
|--------|-------------|
| `RabbitMQConnectionString` / `--remote-rabbitmq` | RabbitMQ connection string. Format: `host=localhost;port=5672;username=guest;password=guest`. Required for distributed execution. |
| `MaxRemoteRequestParallelism` / `--max-remote-request-parallelism` | Maximum concurrent remote operations the host processes. Defaults to `ProcessorCount * 100`. |
| `RemoteClientProcessorWhiteList` / `--remote-client-processor-whitelist` | Comma-separated list of processor names this client handles. If omitted, the client handles all remote processors. |
| `CachePath` / `--cache` | Path to the shared content cache directory. Must be the same for host and all clients. |

### Example: Single Client Handling All Processors

```bash
# Terminal 1: Start the client first
ikon pipeline run \
    --dll-path ./bin/Release/MyPipeline.dll \
    --type-name MyNamespace.DistributedPipeline \
    --cache ./shared-cache \
    --remote-client \
    --remote-rabbitmq "host=localhost;port=5672;username=guest;password=guest"

# Terminal 2: Start the host after client is ready (wait a few seconds)
ikon pipeline run \
    --dll-path ./bin/Release/MyPipeline.dll \
    --type-name MyNamespace.DistributedPipeline \
    --input ./data/ \
    --output ./output/ \
    --cache ./shared-cache \
    --remote-host \
    --remote-rabbitmq "host=localhost;port=5672;username=guest;password=guest"
```

### Example: Specialized Clients

Distribute different processors to different clients using the whitelist:

```bash
# Terminal 1: Client handling only ProcessorA
ikon pipeline run \
    --dll-path ./bin/Release/MyPipeline.dll \
    --type-name MyNamespace.DistributedPipeline \
    --cache ./shared-cache \
    --remote-client \
    --remote-rabbitmq "host=localhost;port=5672;username=guest;password=guest" \
    --remote-client-processor-whitelist "MyNamespace.DistributedPipeline.ProcessorA.1"

# Terminal 2: Client handling only ProcessorB
ikon pipeline run \
    --dll-path ./bin/Release/MyPipeline.dll \
    --type-name MyNamespace.DistributedPipeline \
    --cache ./shared-cache \
    --remote-client \
    --remote-rabbitmq "host=localhost;port=5672;username=guest;password=guest" \
    --remote-client-processor-whitelist "MyNamespace.DistributedPipeline.ProcessorB.1"

# Terminal 3: Start the host after clients are ready
ikon pipeline run \
    --dll-path ./bin/Release/MyPipeline.dll \
    --type-name MyNamespace.DistributedPipeline \
    --input ./data/ \
    --output ./output/ \
    --cache ./shared-cache \
    --remote-host \
    --remote-rabbitmq "host=localhost;port=5672;username=guest;password=guest"
```

### Example: Multiple Clients for Load Distribution

Run multiple clients handling the same processors to distribute load:

```bash
# Start multiple clients (each in separate terminal)
# All clients handle all processors - work is distributed via RabbitMQ
ikon pipeline run \
    --dll-path ./bin/Release/MyPipeline.dll \
    --type-name MyNamespace.DistributedPipeline \
    --cache ./shared-cache \
    --remote-client \
    --remote-rabbitmq "host=localhost;port=5672;username=guest;password=guest"
```

### Programmatic Usage

Use `PipelineRunner.RunRemote` to orchestrate distributed execution from code:

```csharp
var config = new PipelineRunner.Config
{
    TypeName = typeof(DistributedPipeline).FullName!,
    DllPath = "./bin/Release/MyPipeline.dll",
    EnableRemoteHost = true,
    EnableRemoteClient = true, // Can run host and client in same process
    RabbitMQConnectionString = "host=localhost;port=5672;username=guest;password=guest",
    CachePath = "./shared-cache"
};

await PipelineRunner.RunRemote(config, status =>
{
    Console.WriteLine($"Processed: {status.ProcessedItemCount}, Failures: {status.ProcessFailureCount}");
}, cancellationToken);
```

When remote modes are active, `PipelineRunner.RunRemote` orchestrates the host/client lifecycle, forwards live status updates, and honors cancellation tokens for cooperative shutdown.


---

# Ikon.Pipelines.Public Public API

namespace Ikon.Pipelines.Public.Examples
  class FullExamplePipeline.Config
    ctor()
    int TestValue1 { get;  set; }
    string TestValue2
  static class ExampleProcessors
    static Task<List<Item>> Run(Item inputItem)
    static Task<List<Item>> Run2(Item inputItem, CancellationToken cancellationToken)
    static Task<List<Item>> Run3(List<Item> inputItems)
    static Task<List<Item>> Run4(List<Item> inputItems, CancellationToken cancellationToken)
  class FullExamplePipeline
    ctor(IPipelineHost<FullExamplePipeline.Config> host)
    Task Run(Pipeline<T>.Branch<Item> inputItems, CancellationToken cancellationToken)
  class FullExamplePipeline.Input
    ctor()
    int TestValue1 { get;  set; }
    string TestValue2
  class MinimalExamplePipeline
    ctor()
    Task Run(Pipeline<T>.Branch<Item> inputItems, CancellationToken cancellationToken)
  class FullExamplePipeline.Result
    ctor()
    int TestValue1 { get;  set; }
    string TestValue2

namespace Ikon.Pipelines.Public.Processors.Json
  static class MergeJsonProcessor
    static Task<List<Item>> Run(List<Item> items, string itemName)
  static class SplitJsonArrayProcessor
    static Task<List<Item>> Run(Item input)
  static class TrimJsonProcessor
    static Task<List<Item>> Run(Item input, List<string> fieldsToRemove = null)

namespace Ikon.Pipelines.Public.Processors.OCR
  class OCRProcessor.Config
    ctor()
    OCRModel OCRModel { get;  set; }
  static class OCRProcessor
    static Task<List<Item>> Run(Item input, OCRProcessor.Config config, CancellationToken cancellationToken)

namespace Ikon.Pipelines.Public.Processors.Pdf
  class ExtractPdfProcessor.Config
    ctor()
    int MaxPageImageDimension { get;  set; }
  static class ExtractPdfProcessor
    static Task<List<Item>> Run(Item input, ExtractPdfProcessor.Config config, CancellationToken cancellationToken)
  interface IPdfDocument : IDisposable
    int PageCount { get; }
    abstract IPdfPage GetPage(int index)
  interface IPdfPage : IDisposable
    double Height { get; }
    int Index { get; }
    double Width { get; }
    abstract void CreateCopy(Stream output)
    abstract ValueTuple<Rgba32[], byte[], int, int> GetPixels(int maxDimension)
    abstract ValueTuple<Rgba32[], byte[], int, int> GetPixels(int width, int height, bool hasAlpha)
    abstract string GetText()
  static class PdfDocument
    static IPdfDocument Load(byte[] bytes, string password = null)

namespace Ikon.Pipelines.Public.UniversalRag
  class UniversalRagPipeline.Config
    ctor()
    AnalyzePdfDocumentProcessor.Config AnalyzeDocumentType { get;  set; }
    int EmbeddingBatchSize { get;  set; }
    ExtractPdfProcessor.Config ExtractPdf { get;  set; }
    ExtractFullTextAndSectionsProcessor.Config ExtractSections { get;  set; }
    ExtractTextProcessor.Config ExtractText { get;  set; }
    FormatWebPageProcessor.Config FormatWebPage { get;  set; }
    GenerateEmbeddingsProcessor.Config GenerateEmbeddings { get;  set; }
    GenerateSummaryProcessor.Config GenerateSummary { get;  set; }
    int MaxLLMParallelism { get;  set; }
  class UniversalRagPipeline
    ctor(IPipelineHost<UniversalRagPipeline.Config> host)
    Task Run(Pipeline<T>.Branch<Item> inputItems, CancellationToken cancellationToken)

namespace Ikon.Pipelines.Public.UniversalRag.Processors
  static class AnalyzePdfDocumentProcessor
    static Task<List<Item>> Run(List<Item> inputItems, AnalyzePdfDocumentProcessor.Config config, CancellationToken cancellationToken)
  static class CombineEmbeddingsProcessor
    static Task<List<Item>> Run(List<Item> inputItems, CancellationToken cancellationToken)
  class AnalyzePdfDocumentProcessor.Config
    ctor()
    LLMModel LLMModel { get;  set; }
    int PagesToAnalyze { get;  set; }
  class ExtractFullTextAndSectionsProcessor.Config
    ctor()
    string ExtraCommand { get;  set; }
    string ExtraContext { get;  set; }
    bool ExtractFullText { get;  set; }
    bool ExtractSections { get;  set; }
    LLMModel LLMModel { get;  set; }
  class ExtractTextProcessor.Config
    ctor()
    LLMModel LLMModel { get;  set; }
  class FormatWebPageProcessor.Config
    ctor()
    string ExtraCommand { get;  set; }
    string ExtraContext { get;  set; }
    LLMModel LLMModel { get;  set; }
  class GenerateEmbeddingsProcessor.Config
    ctor()
    EmbeddingModel EmbeddingModel { get;  set; }
  class GenerateSummaryProcessor.Config
    ctor()
    LLMModel LLMModel { get;  set; }
  static class ExtractFullTextAndSectionsProcessor
    static Task<List<Item>> Run(Item inputItem, ExtractFullTextAndSectionsProcessor.Config config, CancellationToken cancellationToken)
    static Task<List<Item>> Run(List<Item> inputItems, ExtractFullTextAndSectionsProcessor.Config config, CancellationToken cancellationToken)
  static class ExtractTextProcessor
    static Task<List<Item>> Run(List<Item> inputItems, ExtractTextProcessor.Config config, CancellationToken cancellationToken)
  static class FormatWebPageProcessor
    static Task<List<Item>> Run(Item inputItem, FormatWebPageProcessor.Config config, CancellationToken cancellationToken)
  static class FullTextPassthroughProcessor
    static Task<List<Item>> Run(Item inputItem, CancellationToken cancellationToken)
  static class GenerateEmbeddingsProcessor
    static Task<List<Item>> Run(List<Item> inputItems, GenerateEmbeddingsProcessor.Config config, CancellationToken cancellationToken)
  static class GenerateRouterProcessor
    static Task<List<Item>> Run(List<Item> inputItems, CancellationToken cancellationToken)
  static class GenerateSummaryProcessor
    static Task<List<Item>> Run(Item inputItem, GenerateSummaryProcessor.Config config, CancellationToken cancellationToken)
  static class WebScraperConfigProcessor
    static Task<List<Item>> Run(List<Item> inputItems, CancellationToken cancellationToken)
  static class WebScraperProcessor
    static Task<List<Item>> Run(Item inputItem, CancellationToken cancellationToken)

namespace Ikon.Pipelines.Public.UniversalRag.Shaders
  class AnalyzePdfDocument
    ctor()
    static Task<AnalyzePdfDocument.Result> Run(LLMModel llmModel, List<Item> pageImageItems, CancellationToken cancellationToken = null)
  enum AnalyzePdfDocument.DocumentType
    Document
    Presentation
  class ExtractDocumentPageText
    ctor()
    static Task<string> Run(LLMModel llmModel, Item rawTextItem, Item imageItem, CancellationToken cancellationToken = null)
  class ExtractPresentationPageText
    ctor()
    static Task<string> Run(LLMModel llmModel, Item rawTextItem, Item imageItem, CancellationToken cancellationToken = null)
  class ExtractSections
    ctor()
    static Task<ExtractSections.Result> Run(LLMModel llmModel, string documentTextWithLineNumbers, string extraContext, string extraCommand, CancellationToken cancellationToken = null)
  class FormatWebPage
    ctor()
    static Task<FormatWebPage.Result> Run(LLMModel llmModel, string url, string title, string content, string extraContext, string extraCommand, CancellationToken cancellationToken = null)
  class GenerateSummary
    ctor()
    static Task<string> Run(LLMModel llmModel, string content, CancellationToken cancellationToken = null)
  class AnalyzePdfDocument.Result
    ctor()
    string Title { get;  set; }
    AnalyzePdfDocument.DocumentType Type { get;  set; }
  class ExtractSections.Result
    ctor()
    List<ExtractSections.Section> Sections { get;  set; }
  class FormatWebPage.Result
    ctor()
    string Content { get;  set; }
    bool HasContent { get;  set; }
  class ExtractSections.Section
    ctor()
    int EndLine { get;  set; }
    int StartLine { get;  set; }
    List<string> TitleHierarchy { get;  set; }

namespace Ikon.Pipelines.Public.UniversalRag.Utils
  static class TextUtils
    static string TrimMarkdownBackticks(string input)

namespace Ikon.Pipelines.Public.VideoImageSafety
  enum CollageSelectionMode
    SceneThreshold
    FixedInterval
  class ImageSafetyPipeline.Config
    ctor()
    LLMModel AnalysisModel { get;  set; }
    int MaxAnalysisParallelism { get;  set; }
    int MaxModerationParallelism { get;  set; }
    ClassificationModel ModerationModel { get;  set; }
  class VideoSafetyPipeline.Config
    ctor()
    LLMModel AnalysisModel { get;  set; }
    int CollageCount { get;  set; }
    int CollageFrameWidth { get;  set; }
    double CollageIntervalMinutes { get;  set; }
    CollageSelectionMode CollageSelection { get;  set; }
    LLMModel EvaluationModel { get;  set; }
    double FramesPerSecond { get;  set; }
    int MaxAnalysisParallelism { get;  set; }
    int MaxFrames { get;  set; }
    int MaxModerationParallelism { get;  set; }
    ClassificationModel ModerationModel { get;  set; }
    double SceneChangeThreshold { get;  set; }
    int TileColumns { get;  set; }
    int TileRows { get;  set; }
    string TranscriptionLanguage { get;  set; }
    SpeechRecognizerModel TranscriptionModel { get;  set; }
    float TranscriptionTemperature { get;  set; }
  class ImageSafetyPipeline
    ctor(IPipelineHost<ImageSafetyPipeline.Config> host)
    Task Run(Pipeline<T>.Branch<Item> inputItems, CancellationToken cancellationToken)
  class ImageSafetyResult
    ctor()
    string ContentCategory { get;  set; }
    string Facts { get;  set; }
    string IdealAudience { get;  set; }
    string ImageDescription { get;  set; }
    string ImageMeaning { get;  set; }
    bool IsSafe { get;  set; }
    string PrimaryRisk { get;  set; }
    string RecommendedActions { get;  set; }
    string SafetySummary { get;  set; }
    ImageSource Source { get;  set; }
    string[] TriggeredCategories { get;  set; }
  class ImageSource
    ctor()
    string Description { get;  set; }
    string Name { get;  set; }
    string Url { get;  set; }
  class VideoSafetyPipeline
    ctor(IPipelineHost<VideoSafetyPipeline.Config> host)
    Task Run(Pipeline<T>.Branch<Item> inputItems, CancellationToken cancellationToken)
  class VideoSafetyResult
    ctor()
    string ContentCategory { get;  set; }
    string Facts { get;  set; }
    string IdealAudience { get;  set; }
    bool IsSafe { get;  set; }
    string Meaning { get;  set; }
    string PrimaryRisk { get;  set; }
    string RecommendedActions { get;  set; }
    string RepresentativeDescription { get;  set; }
    string SafetySummary { get;  set; }
    VideoSource Source { get;  set; }
    string Transcript { get;  set; }
    string[] TriggeredCategories { get;  set; }
  class VideoSource
    ctor()
    string Description { get;  set; }
    string Name { get;  set; }
    string Url { get;  set; }

namespace Ikon.Pipelines.Public.VideoImageSafety.Shaders
  static class AnalyzeImageSafety
    static Task<AnalyzeImageSafety.Result> RunAsync(LLMModel llmModel, byte[] image, string imageMimeType, string sourceName, string sourceDescription, CancellationToken cancellationToken = null)
  static class AnalyzeVideoFrames
    static Task<AnalyzeVideoFrames.Result> RunAsync(LLMModel llmModel, byte[] collageImage, string collageImageMimeType, CancellationToken cancellationToken = null)
  static class EvaluateVideoSafety
    static Task<EvaluateVideoSafety.Result> RunAsync(LLMModel llmModel, string sourceName, string sourceDescription, string transcript, AnalyzeVideoFrames.Result combinedAnalysis, CancellationToken cancellationToken = null)
  class AnalyzeImageSafety.Result
    ctor()
    string ContentCategory { get;  set; }
    string Facts { get;  set; }
    string IdealAudience { get;  set; }
    string ImageDescription { get;  set; }
    string ImageMeaning { get;  set; }
    bool IsSafe { get;  set; }
    string PrimaryRisk { get;  set; }
    string RecommendedActions { get;  set; }
    string SafetySummary { get;  set; }
    string[] TriggeredCategories { get;  set; }
  class AnalyzeVideoFrames.Result
    ctor()
    string Facts { get;  set; }
    string FramesDescription { get;  set; }
    string VideoMeaning { get;  set; }
  class EvaluateVideoSafety.Result
    ctor()
    string ContentCategory { get;  set; }
    string IdealAudience { get;  set; }
    bool IsSafe { get;  set; }
    string PrimaryRisk { get;  set; }
    string RecommendedActions { get;  set; }
    string SafetySummary { get;  set; }
    string[] TriggeredCategories { get;  set; }
