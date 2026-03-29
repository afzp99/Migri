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
