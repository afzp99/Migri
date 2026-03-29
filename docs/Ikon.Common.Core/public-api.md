# Ikon.Common.Core Public API

namespace Ikon.Common.Core
  class IkonBackend.Address
    ctor()
    string City { get;  set; }
    string Country { get;  set; }
    List<float> Location { get;  set; }
    string Municipality { get;  set; }
    string State { get;  set; }
    string Street { get;  set; }
    string Zip { get;  set; }
    override string ToString()
  class IkonBackend.ApiKeyResponse
    ctor()
    string Token { get;  set; }
  class IkonBackend.AppBundle
    ctor()
    List<IkonBackend.AppBundleWarning> ActivationErrors { get;  set; }
    List<IkonBackend.AppBundleWarning> ActivationWarnings { get;  set; }
    DateTime CreatedAt { get;  set; }
    string Hash { get;  set; }
    string Id { get;  set; }
    string Item { get;  set; }
    string SpaceId { get;  set; }
    IkonBackend.AppBundleState State { get;  set; }
    DateTime UpdatedAt { get;  set; }
    string Version { get;  set; }
  enum IkonBackend.AppBundleState
    Received
    Inactive
    Activating
    Active
    ActivationFailed
    Failed
  class IkonBackend.AppBundleWarning
    ctor()
    string Code { get;  set; }
    string Message { get;  set; }
  class IkonBackend.ApplyAppBundleConfigResponse
    ctor()
    List<IkonBackend.AppBundleWarning> Warnings { get;  set; }
  class ArrayQueue<T> where T : struct
    ctor(int capacity)
    int Count { get; }
    int FreeCount { get; }
    T Item { get; }
    Span<T> Span { get; }
    void Clear()
    void Dequeue(Span<T> target, int skipCount, int count)
    void Dequeue(Span<T> target, int count)
    void DequeueMemory(int count)
    void Enqueue(ReadOnlySpan<T> source, int count)
    void Enqueue(ReadOnlySpan<T> source)
    void EnqueueMemory(int count)
    Memory<T> GetDequeueMemory(int skipCount, int count)
    Memory<T> GetEnqueueMemory(int count)
  class IkonBackend.Asset
    ctor()
    string AssetId { get;  set; }
    DateTime CreatedAt { get;  set; }
    string Filename { get;  set; }
    string Type { get;  set; }
    string Url { get;  set; }
  class IkonBackend.AssetSignedDownload
    ctor()
    string Url { get;  set; }
  delegate Log.AsyncFlowFinishedHandler
    void AsyncFlowFinishedHandler(object sender, int asyncFlowId)
  sealed class AsyncLocalInstanceAttribute : Attribute
    ctor()
  class AsyncLocalInstance<T> where T : new()
    ctor()
    static T Instance { get; }
    static void EnableAndInitAsyncLocalInstance()
    static void SetAsyncLocalInstance(T value)
  class BasePluginConfig
    ctor()
    AppSourceType AppSourceType
    string DataDirectory
    bool DebugMode
    bool EnableProxyMode
    bool HasInput
    string IkonBackendToken
    string IkonBackendUrl
    string Locale
    int MaxMessageSize
    PayloadType PayloadType
    int ReceiveQueueCapacity
    int SendQueueCapacity
    ServerRunType ServerRunType
    bool TcpNoDelay
    int TcpReceiveBufferSize
    int TcpSendBufferSize
    string UserId
  abstract class BasePlugin<TPlugin, TConfig> : ILogInfo, IPlugin, IProtocolMessageChannel where TConfig : new(), BasePluginConfig
    Context ClientContext { get; }
    string ConnectTokenJson { get; }
    Dictionary<string, object> DynamicConfig { get; }
    IReadOnlyList<EndpointInfo> Endpoints { get; }
    GlobalState GlobalState { get; }
    bool IsAuthTicketSent { get; }
    bool IsConnected { get; }
    object LogInfo { get; }
    Reactive<Dictionary<string, object>> ReactiveDynamicConfig { get; }
    ReactiveGlobalState ReactiveGlobalState { get; }
    DateTime ServerInitTime { get;  set; }
    Task ConnectAsync2(string connectUrl, CancellationToken ct = null)
    Task ConnectAsync2(string host, int port, bool useTls, CancellationToken ct = null)
    void OverrideConfigValues(string overrideConfigJson)
    IDisposable RegisterMessageHandler(Func<ProtocolMessage, ValueTask> handler, Opcode? opcodeGroupMask = null, Opcode[] opcodes = null)
    virtual ValueTask SendMessageAsync(ProtocolMessage message)
    ValueTask SendMessageAsync(IProtocolMessagePayload payload)
    Task SignalReadyAsync()
    Task StopAsync()
    override string ToString()
    Task<bool> WaitForClientAsync(int? clientSessionId = null, string description = null, string userId = null, string deviceId = null, string productId = null, TimeSpan timeout = null)
    Func<Task> ConnectedAsync
    Func<Task> ConnectingAsync
    Func<Task> DisconnectedAsync
    Func<Task> JoinedAsync
    Func<ProtocolMessage, ValueTask> MessageReceivedAsync
    Func<Task> StoppingAsync
  class IkonBackend.Channel
    ctor()
    List<IkonBackend.ChannelConditionGroup> Conditions { get;  set; }
    string Description { get;  set; }
    IkonBackend.ChannelHash Hash { get;  set; }
    string Id { get;  set; }
    bool? IsPrivate { get;  set; }
    string Key { get;  set; }
    bool? MainChannel { get;  set; }
    string Name { get;  set; }
    List<IkonBackend.ChannelPlugin> Plugins { get;  set; }
    string ServerHostingMode { get;  set; }
    string SpaceId { get;  set; }
    List<string> Tags { get;  set; }
    string Type { get;  set; }
  class IkonBackend.ChannelCondition
    ctor()
    string Condition { get;  set; }
    string Field { get;  set; }
    object Value { get;  set; }
  class IkonBackend.ChannelConditionGroup
    ctor()
    List<IkonBackend.ChannelCondition> Conditions { get;  set; }
  class IkonBackend.ChannelHash
    ctor()
    bool Enabled { get;  set; }
    bool IncludeUserId { get;  set; }
  class IkonBackend.ChannelInstance
    ctor()
    string ChannelId { get;  set; }
    string ChannelKey { get;  set; }
    string ChannelTitle { get;  set; }
    string Code { get;  set; }
    string Id { get;  set; }
    string IkonServerHost { get;  set; }
    string Mode { get;  set; }
    string Name { get;  set; }
    string SpaceId { get;  set; }
    bool UseInsecureConnection { get;  set; }
  class IkonBackend.ChannelInstanceLaunchToken
    ctor()
    string Token { get;  set; }
  class IkonBackend.ChannelPlugin
    ctor()
    List<IkonBackend.ChannelPluginConfiguration> Configurations { get;  set; }
    bool Enabled { get;  set; }
    string PluginId { get;  set; }
  class IkonBackend.ChannelPluginConfiguration
    ctor()
    string Code { get;  set; }
    string Configuration { get;  set; }
  class IkonBackend.ChatMessage
    ctor()
    string ChannelInstanceId { get;  set; }
    string CreatedAt { get;  set; }
    string Id { get;  set; }
    string Text { get;  set; }
    string UserId { get;  set; }
  class IkonBackend.ConnectChannelInstanceConfiguration
    ctor()
    string ProxyUrl { get;  set; }
    string Url { get;  set; }
  class IkonBackend.ConnectChannelInstanceRequest
    ctor()
    ClientType ClientType { get;  set; }
    string Code { get;  set; }
    ContextType ContextType { get;  set; }
    string Description { get;  set; }
    string DeviceId { get;  set; }
    bool HasInput { get;  set; }
    string Hash { get;  set; }
    string InitialPath { get;  set; }
    string InstallId { get;  set; }
    Dictionary<string, string> LaunchParameters { get;  set; }
    string Locale { get;  set; }
    Opcode OpcodeGroupsFromServer { get;  set; }
    Opcode OpcodeGroupsToServer { get;  set; }
    PayloadType PayloadType { get;  set; }
    string ProductId { get;  set; }
    int ProtocolVersion { get;  set; }
    bool ReceiveAllMessages { get;  set; }
    SdkType SdkType { get;  set; }
    UserType UserType { get;  set; }
    string VersionId { get;  set; }
    bool WaitForRunning { get;  set; }
  class IkonBackend.ConnectChannelInstanceResponse
    ctor()
    IkonBackend.ConnectChannelInstanceConfiguration Configuration { get;  set; }
    bool IsProvisioning { get; }
    bool IsRunning { get; }
    string State { get;  set; }
  class IkonBackend.CursorResponse<T>
    ctor()
    int Count { get;  set; }
    string NextCursor { get;  set; }
    string PreviousCursor { get;  set; }
    List<T> Results { get;  set; }
    int TotalCount { get;  set; }
  class IkonBackend.CustomField
    ctor()
    List<string> AllowedMimeTypes { get;  set; }
    string Context { get;  set; }
    string Entity { get;  set; }
    string Field { get;  set; }
    string Id { get;  set; }
    bool IsEditable { get;  set; }
    int MaxCount { get;  set; }
    int MaxSize { get;  set; }
    int MinCount { get;  set; }
    bool Multiple { get;  set; }
    string Name { get;  set; }
    List<IkonBackend.CustomFieldOption> Options { get;  set; }
    string Type { get;  set; }
    List<IkonBackend.CustomFieldVisibility> Visibility { get;  set; }
  class IkonBackend.CustomFieldOption
    ctor()
    string LongName { get;  set; }
    string Name { get;  set; }
    bool UserInput { get;  set; }
    string UserInputField { get;  set; }
    string UserInputName { get;  set; }
    bool UserInputOptional { get;  set; }
    string Value { get;  set; }
  class IkonBackend.CustomFieldVisibility
    ctor()
    bool IsVisible { get;  set; }
    string Target { get;  set; }
  class IkonBackend.Database
    ctor()
    string DatabaseName { get;  set; }
    string Id { get;  set; }
    string Name { get;  set; }
    string OrganisationId { get;  set; }
    string Provider { get;  set; }
    string SpaceId { get;  set; }
    string Status { get;  set; }
    string Tier { get;  set; }
  class IkonBackend.DatabaseConnectionResponse
    ctor()
    string ConnectionString { get;  set; }
    string DatabaseName { get;  set; }
    string Host { get;  set; }
    string Password { get;  set; }
    int Port { get;  set; }
    string Username { get;  set; }
  class ReactiveGlobalState.DictionaryComparer<TKey, TValue> : IEqualityComparer<Dictionary<TKey, TValue>>
    ctor()
    bool Equals(Dictionary<TKey, TValue> x, Dictionary<TKey, TValue> y)
    int GetHashCode(Dictionary<TKey, TValue> obj)
    static ReactiveGlobalState.DictionaryComparer<TKey, TValue> Instance
  sealed class EndpointInfo
    ctor()
    string Descriptor { get;  set; }
    int LocalPort { get;  set; }
    string Name { get;  set; }
    string Protocol { get;  set; }
    string PublicUrl { get;  set; }
  enum IkonBackend.EnvironmentType
    Unknown
    Local
    Development
    Production
  static class ExceptionFormatter
    static string FormatException(Exception ex, bool includeFilePaths = true)
  static class ExtendedCast
    static T Convert<T>(object value)
    static object Convert(object value, Type targetType)
  static class ExtendedCastExtensions
    static T ExtendedCast<T>(object value)
    static object ExtendedCast(object value, Type targetType)
  class FeatureFlagsStorage : AsyncLocalInstance<FeatureFlagsStorage>
    ctor()
    ImmutableDictionary<string, bool> ReadOnlyFeatureFlags { get; }
    bool Get(string featureFlagName)
    void Set(string featureFlagName, bool value, bool shouldOverride = false)
  class IkonBackend.FileUploadResponse
    ctor()
    string UploadUrl { get;  set; }
  class IkonBackend.Folder
    ctor()
    string Id { get;  set; }
    string OrganisationId { get;  set; }
    string ParentPath { get;  set; }
    string Path { get;  set; }
    List<string> PathSegments { get;  set; }
    string SpaceId { get;  set; }
  class HighPrecisionTimestamp : AsyncLocalInstance<HighPrecisionTimestamp>
    ctor()
    DateTime UtcNow { get; }
  interface ILogInfo
    object LogInfo { get; }
  interface IPlugin : IProtocolMessageChannel
    string ConnectTokenJson { get; }
    bool IsAuthTicketSent { get; }
    bool IsConnected { get; }
    DateTime ServerInitTime { get;  set; }
    abstract Task ConnectAsync2(string connectUrl, CancellationToken ct = null)
    abstract Task ConnectAsync2(string host, int port, bool useTls, CancellationToken ct = null)
    abstract void OverrideConfigValues(string overrideConfigJson)
    abstract Task StopAsync()
  interface IProtocolMessageChannel
    Context ClientContext { get; }
    abstract IDisposable RegisterMessageHandler(Func<ProtocolMessage, ValueTask> handler, Opcode? opcodeGroupMask = null, Opcode[] opcodes = null)
    abstract ValueTask SendMessageAsync(ProtocolMessage message)
    abstract ValueTask SendMessageAsync(IProtocolMessagePayload payload)
  class IkonBackend : AsyncLocalInstance<IkonBackend>
    ctor()
    string ChannelDomain { get; }
    string ChannelDomainLegacy { get; }
    IkonBackend.EnvironmentType Environment { get; }
    static string IkonDataDirectory { get; }
    bool IsAdmin { get; }
    bool IsLoggedIn { get; }
    bool IsSpaceToken { get; }
    static string LoginJsonPath { get; }
    string Token { get;  set; }
    int TotalSentMessageByteCount { get; }
    int TotalSentMessageCount { get; }
    string Url { get;  set; }
    string UserId { get; }
    Task<IkonBackend.AppBundle> ActivateAppBundleAsync(string id)
    Task<IkonBackend.ApplyAppBundleConfigResponse> ApplyAppBundleConfigAsync(object config)
    Task<string> AuthenticateSpaceTokenAsync(string spaceId, string externalUserId)
    Task CompleteItemSignedUploadAsync(string uri, string path, string sha256 = null)
    Task<IkonBackend.ConnectChannelInstanceResponse> ConnectChannelInstanceAsync(IkonBackend.ConnectChannelInstanceRequest request)
    Task<IkonBackend.AppBundle> CreateAppBundleAsync(string spaceId, string version, string itemId, IkonBackend.AppBundleState? state = null)
    Task CreateAuditEventAsync(string eventName, string spaceId, string userId, string entityType = null, string entityId = null, string ip = null)
    Task<IkonBackend.Channel> CreateChannelAsync(string spaceId, string name, string type, bool isPrivate)
    Task<IkonBackend.ChannelInstance> CreateChannelInstanceAsync(string channelId, string mode)
    Task<IkonBackend.ChannelInstanceLaunchToken> CreateChannelInstanceLaunchTokenAsync(string id, int? httpsPort = null, int? httpPort = null, int? tcpPort = null, int? tlsPort = null)
    Task CreateChatMessageAsync(string channelInstanceId, string userId, string text, string createdAt)
    Task<IkonBackend.Pipeline> CreatePipelineAsync(object form)
    Task<IkonBackend.Plugin> CreatePluginAsync(IkonBackend.Plugin plugin)
    Task CreateProfileLeadAsync(string profileId, string source)
    Task<IkonBackend.SpaceApiKey> CreateSpaceApiKeyAsync(string spaceId)
    Task<IkonBackend.Space> CreateSpaceAsync(string name, string organisationId, string domain)
    Task<string> DelegateSpaceTokenAsync(string spaceId, string userId)
    Task DeleteAppBundleAsync(string id)
    Task DeleteChannelAsync(string id)
    Task<IkonBackend.ChannelInstance> DeleteChannelInstanceAsync(string id)
    Task DeleteItemAsync(string id)
    Task DeletePluginAsync(string id)
    Task DeleteProfileFileAsync(string profileId, string assetId)
    Task DeleteSpaceApiKeyAsync(string id)
    static IkonBackend.EnvironmentType DetermineEnvironment(string url)
    Task<List<IkonBackend.Profile>> FindProfilesAsync(string spaceId, Dictionary<string, string> filters, int maxResults = 1000)
    Task<List<IkonBackend.Translation>> GetAllTranslationsAsync(string spaceId, int maxResults = 1000)
    Task<Dictionary<string, string>> GetApiKeysAsync(bool all = false)
    Task<IkonBackend.AppBundle> GetAppBundleAsync(string id)
    Task<List<IkonBackend.AppBundle>> GetAppBundlesAsync(string spaceId, IkonBackend.AppBundleState? state = null, int maxResults = 1000)
    Task<string> GetAssetSignedUrlAsync(string assetId)
    Task<IkonBackend.Channel> GetChannelAsync(string id)
    Task<IkonBackend.ChannelInstance> GetChannelInstanceAsync(string id)
    Task<List<IkonBackend.ChannelInstance>> GetChannelInstancesAsync(string spaceId = null, string userId = null, string scope = "all", int maxResults = 1000)
    Task<List<IkonBackend.Channel>> GetChannelsAsync(string spaceId, int maxResults = 1000)
    Task<List<IkonBackend.ChatMessage>> GetChatMessagesAsync(string channelInstanceId, int maxResults = 1000)
    Task<IkonBackend.User> GetCurrentUserAsync()
    Task<List<IkonBackend.CustomField>> GetCustomFieldsAsync(string spaceId, int maxResults = 1000)
    Task<IkonBackend.DatabaseConnectionResponse> GetDatabaseConnectionAsync(string databaseId)
    Task<List<IkonBackend.Database>> GetDatabasesForSpaceAsync(string spaceId, int maxResults = 20)
    Task<IkonBackend.Folder> GetFolderByPathAsync(string spaceId, string path)
    Task<List<IkonBackend.Folder>> GetFoldersAsync(string spaceId, string path, int maxResults = 1000)
    static IEnumerable<string> GetIkonDataDirectoryCandidates()
    Task<IkonBackend.Item> GetItemAsync(AssetUri assetUri)
    Task<IkonBackend.ItemDownloadUrl> GetItemSignedDownloadUrlAsync(string id)
    Task<IkonBackend.ItemSignedUpload> GetItemSignedUploadUrlAsync(string uri, string filename, string mime, string[] tags)
    Task<List<IkonBackend.Item>> GetItemsAsync(string spaceId, string folderId, int maxResults = 1000)
    Task<IkonBackend.LocalIkonServerTokenResponse> GetLocalIkonServerTokenAsync(string spaceId)
    Task<IkonBackend.Profile> GetOrCreateCurrentProfileAsync(string spaceId)
    Task<IkonBackend.Organisation> GetOrganisationAsync(string id)
    Task<List<IkonBackend.Organisation>> GetOrganisationsAsync(int maxResults = 1000)
    Task<IkonBackend.Pipeline> GetPipelineAsync(string id)
    Task<IkonBackend.Pipeline> GetPipelineByTypeNameAsync(string spaceId, string typeName)
    Task<List<IkonBackend.Pipeline>> GetPipelinesAsync(string spaceId, int maxResults = 1000)
    Task<IkonBackend.Plugin> GetPluginAsync(string id)
    Task<List<IkonBackend.Plugin>> GetPluginsAsync(string spaceId, int maxResults = 1000)
    Task<IkonBackend.Profile> GetProfileAsync(string spaceId, string userId)
    Task<List<IkonBackend.Profile>> GetProfilesAsync(string spaceId, int maxResults = 1000)
    Task<List<string>> GetReleaseNoteVersions(string target)
    Task<List<IkonBackend.ReleaseNoteEntry>> GetReleaseNotes(string target, string minVersion = null, int maxResults = 100)
    Task<Dictionary<string, string>> GetSecretsAsync(string spaceId)
    Task<IkonBackend.SpaceApiKey> GetSpaceApiKeyAsync(string id)
    Task<List<IkonBackend.SpaceApiKey>> GetSpaceApiKeysAsync(string spaceId, int maxResults = 1000)
    Task<IkonBackend.Space> GetSpaceAsync(string id)
    Task<IkonBackend.SpaceGitRepository> GetSpaceGitRepositoryAsync(string spaceId)
    Task<List<IkonBackend.Space>> GetSpacesAsync(string organisationId, int maxResults = 1000)
    Task<T> GetStorageAsync<T>(string spaceId, string entity, string entityId, IEnumerable<string> keys)
    Task<IkonBackend.Translation> GetTranslationAsync(string spaceId, string text, string locale, string description)
    Task<IkonBackend.User> GetUserAsync(string id)
    Task<List<IkonBackend.User>> GetUsersAsync(string query, int limit = 20)
    Task<bool> IsSpaceDomainAvailableAsync(string domain)
    Task<IkonBackend.ItemListResponse> ListItemsAsync(IkonBackend.ItemListRequest request)
    bool Login(ValueTuple<string, string>? fromCommandLine = null, ValueTuple<string, string>? fromConfig = null, bool logSource = true, bool mustLogin = true)
    static IkonBackend.LoginInfo ReadLoginConfig()
    Task<string> RequestAccessTokenAsync(string apiKey, string spaceId, string externalUserId)
    Task<IkonBackend.ChannelInstance> RequestChannelAsync(IkonBackend.RequestChannelRequest request)
    void ResetCounters()
    Task ResetProfileAsync(string profileId)
    void SendMessage(ProtocolMessage message)
    Task SetStorageAsync(string spaceId, string entity, string entityId, Dictionary<string, object> values)
    Task StopAsync()
    Task<IkonBackend.AppBundle> UpdateAppBundleAsync(string id, IkonBackend.AppBundleState state)
    Task<IkonBackend.Channel> UpdateChannelAsync(string id, object form)
    Task<IkonBackend.ChannelInstance> UpdateChannelInstanceAsync(string id, object form)
    Task<IkonBackend.Item> UpdateItemAsync(AssetUri assetUri, object text, string[] tags, DateTime? ifUpdatedAt = null)
    Task<IkonBackend.Pipeline> UpdatePipelineAsync(string id, object form)
    Task<IkonBackend.Plugin> UpdatePluginAsync(string id, object form)
    Task UpdateProfileFieldAsync(string profileId, object form)
    Task UpdateProfileFieldAsync(string profileId, string field, string value)
    Task UpdateProfileFieldAsync(string profileId, string field, List<string> value)
    Task<IkonBackend.Space> UpdateSpaceAsync(string id, object form)
    Task UploadFileAsync(string url, string mime, string filePath)
    Task<IkonBackend.FileUploadResponse> UploadProfileFileAsync(string profileId, string type, string filename, string mime)
    static void WriteLoginConfig(IkonBackend.LoginInfo info)
    static string DevelopmentAuthEndpointUrl
    static string DevelopmentBackendEndpointUrl
    static string ProductionAuthEndpointUrl
    static string ProductionBackendEndpointUrl
  class IkonBackend.Item
    ctor()
    IkonBackend.ItemAsset Asset { get;  set; }
    DateTime CreatedAt { get;  set; }
    string Folder { get;  set; }
    string Id { get;  set; }
    bool IsPrivate { get;  set; }
    string Name { get;  set; }
    string OrganisationId { get;  set; }
    string SpaceId { get;  set; }
    string[] Tags { get;  set; }
    string Text { get;  set; }
    string Type { get;  set; }
    DateTime UpdatedAt { get;  set; }
  class IkonBackend.ItemAsset
    ctor()
    string Filename { get;  set; }
    string Mime { get;  set; }
    string Sha256 { get;  set; }
    long Size { get;  set; }
    string Url { get;  set; }
  class IkonBackend.ItemDownloadUrl
    ctor(string url)
    string Url { get;  set; }
  class IkonBackend.ItemListRequest
    ctor()
    string ContinuationToken { get;  set; }
    string FolderPrefix { get;  set; }
    int? Limit { get;  set; }
    string SpaceId { get;  set; }
    string[] Tags { get;  set; }
  class IkonBackend.ItemListResponse
    ctor()
    List<IkonBackend.Item> Items { get;  set; }
    string NextPageToken { get;  set; }
  class IkonBackend.ItemSignedUpload
    ctor()
    string Path { get;  set; }
    string Url { get;  set; }
  static class Json
    static Dictionary<string, object> AsDict(string json)
    static Dictionary<string, object> ConvertDict(Dictionary<string, object> dict)
    static T DeepCopy<T>(T obj)
    static string Format(string json, bool useJson5 = false, bool includeFields = true, bool enumsAsNames = true, bool camelCase = false, bool includeNull = true, bool enumCamelCase = false)
    static T From<T>(string json, bool useJson5 = false, bool includeFields = true, bool enumsAsNames = true, bool camelCase = false, bool includeNull = true, bool enumCamelCase = false, bool caseInsensitive = false)
    static object From(string json, Type type, bool useJson5 = false, bool includeFields = true, bool enumsAsNames = true, bool camelCase = false, bool includeNull = true, bool enumCamelCase = false)
    static object From(string json, string typeName, bool useJson5 = false, bool includeFields = true, bool enumsAsNames = true, bool camelCase = false, bool includeNull = true, bool enumCamelCase = false)
    static string To<T>(T obj, bool useJson5 = false, bool indentation = true, bool includeFields = true, bool enumsAsNames = true, bool camelCase = false, bool includeNull = true, bool enumCamelCase = false)
  static class JwtHelper
    static string Decode(string token, byte[] key)
    static string DecodePayload(string token)
    static string Encode(string payload, byte[] key)
  class IkonBackend.LocalIkonServerTokenResponse
    ctor()
    string Token { get;  set; }
  class Log : AsyncLocalInstance<Log>
    ctor()
    IList<IScopeKey> CurrentScopes { get; }
    bool ShowTimeDelta { get;  set; }
    void AddDefaultLogHandlers()
    void AddLogEvent(LogEvent logEvent)
    void AddScope(IScopeKey scope)
    IDisposable BeginTimer(string name, LogType logType = Debug, string filePath = "", int lineNumber = 0, string memberName = "")
    IDisposable CreateAsyncFlow(string description = null)
    void Critical(LogCriticalHandler handler)
    void Critical(string message, string filePath = "", int lineNumber = 0, string memberName = "")
    void Debug(LogDebugHandler handler)
    void Debug(string message, string filePath = "", int lineNumber = 0, string memberName = "")
    void DisableFileOutput()
    void EnableFileOutput(string filePath, bool append = false)
    void Error(LogErrorHandler handler)
    void Error(string message, string filePath = "", int lineNumber = 0, string memberName = "")
    void Event(string name, object parameters = null, string filePath = "", int lineNumber = 0, string memberName = "")
    string Exception(LogExceptionHandler handler)
    string Exception(string message, string filePath = "", int lineNumber = 0, string memberName = "")
    TScope GetScope<TScope>()
    IScopeKey GetScopeByName(string name)
    void Info(LogInfoHandler handler)
    void Info(string message, string filePath = "", int lineNumber = 0, string memberName = "")
    Task InitializeAsync()
    void LogMessage(LogType type, LogGeneralHandler handler)
    void LogMessage(LogType type, string message, string filePath = "", int lineNumber = 0, string memberName = "")
    void LogMessage2(LogType type, string filePath, int lineNumber, string memberName, LogGeneralHandler2 handler)
    void LogMessage2(LogType type, string filePath, int lineNumber, string memberName, string message)
    void RemoveDefaultLogHandlers()
    static Sensitive<T> Sensitive<T>(T value, SensitivityPolicy sensitivityPolicy = Default)
    Task StopAsync()
    void Trace(LogTraceHandler handler)
    void Trace(string message, string filePath = "", int lineNumber = 0, string memberName = "")
    TScope? TryGetScope<TScope>()
    bool TryGetScope<TScope>(out TScope scope)
    IScopeKey TryGetScopeByName(string name)
    void Usage(string usageName, double usage, string filePath = "", int lineNumber = 0, string memberName = "")
    void Usage(string usageName, Func<Task<double>> usageFunc, string filePath = "", int lineNumber = 0, string memberName = "")
    IDisposable UseScope(IScopeKey scope)
    IDisposable UseScopes(params IScopeKey[] scopes)
    Task WaitEmptyAsync()
    void Warning(LogWarningHandler handler)
    void Warning(string message, string filePath = "", int lineNumber = 0, string memberName = "")
    static void WriteErrorToConsole(string message)
    static void WriteToConsole(string message, ConsoleColor color)
    static void WriteWarningToConsole(string message)
    bool BlockWhenFull
    LogFilter ConsoleWriterFilter
    LogFilter FileWriterFilter
    LogFilter Filter
    static bool RequireInitCall
    bool ShowAsyncFlow
    string TraceFilter
    static event Log.AsyncFlowFinishedHandler AsyncFlowFinished
    event Log.LogEventHandler LogEvent
  class LogEvent
    ctor()
    Dictionary<string, object> GetParameters(bool includeExtraParameters = true)
    string GetParametersAsJson(bool includeExtraParameters = true)
    int AsyncFlowId
    string EventName
    object EventParameters
    int LineNumber
    string MemberName
    string Message
    LogEvent.Parameter[] Parameters
    string Path
    int PreviousAsyncFlowId
    LogScopeEntry[] Scopes
    DateTime Time
    LogType Type
    double Usage
    string UsageName
  delegate Log.LogEventHandler
    void LogEventHandler(object sender, LogEvent logEvent)
  class LogEventSender
    ctor()
    void Flush()
    Task InitializeAsync(bool sendLogs = true, bool sendEvents = true, bool sendUsages = true)
    void OnLogEvent(object sender, LogEvent logEvent)
    Task StopAsync()
  enum LogFilter
    None
    Critical
    Error
    Warning
    Info
    Debug
    Trace
  struct LogScopeEntry
    string Id { get;  set; }
    string Type { get;  set; }
  class IkonBackend.LoginInfo
    ctor()
    string DefaultOrganisationId
    string DefaultOrganisationName
    string DefaultSpaceId
    string DefaultSpaceName
    string IkonBackendEnvironment
    string IkonBackendToken
    string IkonBackendUrl
  static class NameConversions
    static string ToCamelCase(string input)
    static string ToDisplayName(string input)
    static string ToKebabCase(string input)
    static string ToPascalCase(string input)
    static string ToSlug(string input, int maxLength)
    static string ToSnakeCase(string input)
  class IkonBackend.Organisation
    ctor()
    string Id { get;  set; }
    string Name { get;  set; }
    List<IkonBackend.OrganisationUser> Users { get;  set; }
  class IkonBackend.OrganisationUser
    ctor()
    string Role { get;  set; }
    string UserId { get;  set; }
  class OverrideConfig
    ctor()
    AppSourceType AppSourceType { get;  set; }
    string DataDirectory { get;  set; }
    bool DebugMode { get;  set; }
    Dictionary<string, object> DynamicConfig { get;  set; }
    List<EndpointInfo> Endpoints { get;  set; }
    string IkonBackendToken { get;  set; }
    string IkonBackendUrl { get;  set; }
    PayloadType PayloadType { get;  set; }
    ServerRunType ServerRunType { get;  set; }
  struct LogEvent.Parameter
    ctor(string name, object value)
    string Name
    object Value
  class IkonBackend.Pipeline
    ctor()
    string BundleAsset { get;  set; }
    object Config { get;  set; }
    DateTime CreatedAt { get;  set; }
    string DllName { get;  set; }
    string Guid { get;  set; }
    string Hash { get;  set; }
    string Id { get;  set; }
    string Name { get;  set; }
    string OpenApiSpecJson { get;  set; }
    string SpaceId { get;  set; }
    string TypeName { get;  set; }
    DateTime UpdatedAt { get;  set; }
  class IkonBackend.Plugin
    ctor()
    List<string> Api { get;  set; }
    string Developer { get;  set; }
    string DllName { get;  set; }
    Guid? Guid { get;  set; }
    string Id { get;  set; }
    string Name { get;  set; }
    string NupkgAsset { get;  set; }
    string ProductId { get;  set; }
    string SpaceId { get;  set; }
    List<string> Targets { get;  set; }
    string Type { get;  set; }
    string TypeName { get;  set; }
  class PluginAttribute : Attribute
    ctor(string name, string productId, string description, int version, string guid, UserType userType, Opcode opcodeGroupsFromServer, Opcode opcodeGroupsToServer, bool receiveAllMessages, string[] dependencies = null)
    string[] Dependencies { get; }
    string Description { get; }
    string Guid { get; }
    string Name { get; }
    Opcode OpcodeGroupsFromServer { get; }
    Opcode OpcodeGroupsToServer { get; }
    string ProductId { get; }
    bool ReceiveAllMessages { get; }
    UserType UserType { get; }
    int Version { get; }
  class PortalPluginConfig
    ctor()
    object DefaultConfig
    string FileName
    string FileNameJsonPath
    string Format
    string Name
    string TypeName
  static class ProcessGuard
    static void HandleOutOfMemory()
  static class ProcessRunner
    static ProcessRunner.Result Run(string command, bool ignoreErrors = false, bool runInBackground = false, bool runInNewWindow = false, bool attachToConsole = false, string workingDirectory = null, string stdinInput = null, IDictionary<string, string> environmentVariables = null, TimeSpan waitAfterCancel = null, bool captureBinaryOutput = false, CancellationToken cancellationToken = null)
    static Task<ProcessRunner.Result> RunAsync(string command, bool ignoreErrors = false, bool runInBackground = false, bool runInNewWindow = false, bool attachToConsole = false, string workingDirectory = null, string stdinInput = null, IDictionary<string, string> environmentVariables = null, TimeSpan waitAfterCancel = null, bool captureBinaryOutput = false, CancellationToken cancellationToken = null)
  class IkonBackend.Profile
    ctor()
    IkonBackend.Address Address { get;  set; }
    List<IkonBackend.Asset> Assets { get;  set; }
    Dictionary<string, object> Attributes { get;  set; }
    IkonBackend.Asset Avatar { get; }
    string BirthDate { get;  set; }
    string Email { get;  set; }
    string FirstName { get;  set; }
    string Gender { get;  set; }
    string Id { get;  set; }
    string Language { get;  set; }
    string LastName { get;  set; }
    IkonBackend.ProfileModules Modules { get;  set; }
    string Name { get;  set; }
    string NativeLanguage { get;  set; }
    string PhoneNumber { get;  set; }
    string PreferredName { get;  set; }
    List<string> Roles { get;  set; }
    List<string> SpokenLanguages { get;  set; }
    string UserId { get;  set; }
    string VisibleAddress { get; }
    string VisibleName { get; }
    string GetStringAttribute(string name)
  static class ProfileExtensions
    static string GetValueByPath(IkonBackend.Profile profile, string path)
  class IkonBackend.ProfileModules
    ctor()
    IkonBackend.ProfileProviderModule Provider { get;  set; }
  class IkonBackend.ProfileProviderModule
    ctor()
    bool? Accepted { get;  set; }
    DateTime? AcceptedAt { get;  set; }
    string Provider { get;  set; }
  sealed class ProtocolMessageHandlerRegistry
    ctor()
    bool HasHandlers { get; }
    ValueTask DispatchAsync(ProtocolMessage message)
    IDisposable Register(Func<ProtocolMessage, ValueTask> handler, Opcode? opcodeGroupMask = null, Opcode[] opcodes = null)
  sealed class PublicApiDocIgnoreAttribute : Attribute
    ctor()
  class ReactiveGlobalState
    ctor()
    Reactive<AppSourceType> AppSourceType { get; }
    Reactive<Dictionary<string, GlobalState.AudioStreamState>> AudioStreams { get; }
    Reactive<string> ChannelId { get; }
    Reactive<string> ChannelName { get; }
    Reactive<string> ChannelUrl { get; }
    Reactive<Dictionary<int, Context>> Clients { get; }
    Reactive<bool> DebugMode { get; }
    Reactive<string> FirstUserId { get; }
    Reactive<Dictionary<int, List<ActionFunctionRegister>>> Functions { get; }
    Reactive<string> OrganisationName { get; }
    Reactive<string> PrimaryUserId { get; }
    Reactive<bool> PublicAccess { get; }
    Reactive<ServerRunType> ServerRunType { get; }
    Reactive<string> SessionChannelUrl { get; }
    Reactive<string> SessionId { get; }
    Reactive<string> SpaceId { get; }
    Reactive<string> SpaceName { get; }
    Reactive<Dictionary<string, GlobalState.TrackingStreamState>> TrackingStreams { get; }
    Reactive<Dictionary<string, GlobalState.UIStreamState>> UIStreams { get; }
    Reactive<Dictionary<string, GlobalState.VideoStreamState>> VideoStreams { get; }
    Context GetClientContext(int clientSessionId)
    Context GetClientContext(string userId)
    IEnumerable<Context> GetHumanClients()
    IEnumerable<Context> GetUniqueAuthClientContexts()
    IEnumerable<Context> GetUniqueHumanAuthClientContexts()
    void UpdateFrom(GlobalState newState)
  class IkonBackend.ReleaseNoteEntry
    ctor()
    string Content { get;  set; }
    string Target { get;  set; }
    string Version { get;  set; }
  class IkonBackend.ReleaseNoteVersionsResponse
    ctor()
    List<string> Results { get;  set; }
  class IkonBackend.RequestChannelRequest
    ctor()
    string Hash { get;  set; }
    string Key { get;  set; }
    Dictionary<string, string> Params { get;  set; }
    string Space { get;  set; }
  sealed class ProcessRunner.Result
    ctor()
    int ExitCode { get;  set; }
    Process Process { get;  set; }
    string StdErr { get;  set; }
    string StdOut { get;  set; }
    byte[] StdOutBytes { get;  set; }
    bool Success { get;  set; }
  class Sensitive<T>
    ctor(T value, SensitivityPolicy sensitivityPolicy = Default)
    bool IsSensitive { get; }
    SensitivityPolicy Policy { get; }
    T Value { get; }
  enum SensitivityPolicy
    Default
  class IkonBackend.Space
    ctor()
    string Domain { get;  set; }
    string Id { get;  set; }
    IkonBackend.SpaceLanguages Languages { get;  set; }
    string Layout { get;  set; }
    string Name { get;  set; }
    string OrganisationId { get;  set; }
    string Region { get;  set; }
    string Slug { get;  set; }
  class IkonBackend.SpaceApiKey
    ctor()
    DateTime CreatedAt { get;  set; }
    string Id { get;  set; }
    string Key { get;  set; }
    string SpaceId { get;  set; }
    DateTime UpdatedAt { get;  set; }
  class IkonBackend.SpaceDomainAvailability
    ctor()
    bool Available { get;  set; }
    string Domain { get;  set; }
  class IkonBackend.SpaceGitRepository
    ctor()
    string GitPassword { get;  set; }
    string GitRepositoryPath { get;  set; }
    string GitRepositoryUrl { get;  set; }
    string GitUsername { get;  set; }
  class IkonBackend.SpaceLanguages
    ctor()
    List<string> AvailableLanguages { get;  set; }
    string DefaultLanguage { get;  set; }
    bool UseUserLocale { get;  set; }
  static class StableFileWriter
    static bool SaveXml(XDocument document, string path)
    static Task<bool> SaveXmlAsync(XDocument document, string path, CancellationToken cancellationToken = null)
    static bool WriteAllText(string path, string content)
    static Task<bool> WriteAllTextAsync(string path, string content, CancellationToken cancellationToken = null)
  class IkonBackend.StorageResponse<T> where T : new()
    ctor()
    string Entity { get;  set; }
    string EntityId { get;  set; }
    T Values { get;  set; }
  static class Throttler
    static bool TryExecute(Action action, TimeSpan throttleInterval = null, string extraKey = null)
  static class Toml
    static T From<T>(string toml)
    static string To<T>(T obj)
  class IkonBackend.Translation
    ctor()
    string Text { get;  set; }
    Dictionary<string, string> Translations { get;  set; }
  class IkonBackend.User
    ctor()
    string Email { get;  set; }
    string Id { get;  set; }
    string Name { get;  set; }
  static class Utils
    static int FindAvailableTcpAndUdpPort(int startPort, HashSet<int> usedPorts = null)
    static int FindAvailableUdpPortRange(int startPort, int count)
    static string GenerateDeviceId()
    static void OpenBrowser(string url)
    static bool TcpPortIsAvailable(int port)
    static bool UdpPortIsAvailable(int port)

namespace Ikon.Common.Core.Assets
  sealed class Asset : AsyncLocalInstance<Asset>, IAsyncDisposable
    ctor()
    IkonBackend Backend { get;  set; }
    Task AddStorageAsync(AssetClass assetClass, IStorage storage, bool startInBackground = false)
    Task DeleteAsync(AssetUri assetUri)
    ValueTask DisposeAsync()
    Task<bool> ExistsAsync(AssetUri assetUri)
    Task<T> GetAsync<T>(AssetUri assetUri)
    Task<byte[]> GetBytesAsync(AssetUri assetUri)
    Task<AssetContent<byte[]>> GetBytesWithMetadataAsync(AssetUri assetUri)
    Task<AssetMetadata> GetMetadataAsync(AssetUri assetUri)
    Task<IAsyncDisposable> GetOrUpdateWithMetadataAsync<T>(AssetUri assetUri, Func<AssetEventArgs, AssetContent<T>, Task> onAsset, Func<AssetEventArgs, Task> onAssetNotFound = null)
    Task<IAsyncDisposable> GetOrUpdateWithMetadataAsync<T>(AssetUri assetUri, Action<AssetEventArgs, AssetContent<T>> onAsset, Func<AssetEventArgs, Task> onAssetNotFound = null)
    Task<AssetContent<Stream>> GetReadStreamAsync(AssetUri assetUri)
    Task<string> GetTextAsync(AssetUri assetUri, Encoding encoding = null)
    Task<AssetContent<string>> GetTextWithMetadataAsync(AssetUri assetUri, Encoding encoding = null)
    Task<AssetContent<T>> GetWithMetadataAsync<T>(AssetUri assetUri)
    Task<Stream> GetWriteStreamAsync(AssetUri assetUri, AssetMetadata? metadata = null, CancellationToken cancellationToken = null)
    Task<IReadOnlyList<AssetListingEntry>> ListAsync(AssetQuery query, CancellationToken cancellationToken = null)
    Task<IReadOnlyList<AssetUri>> ListAsync(AssetClass assetClass, string prefix = null, CancellationToken cancellationToken = null)
    Task<IReadOnlyList<AssetUri>> ListAsync(AssetUri folderUri, CancellationToken cancellationToken = null)
    Task NotifyUpdateAsync(AssetUri assetUri)
    Task SetAsync<T>(AssetUri assetUri, T asset, AssetMetadata? metadata = null, CancellationToken cancellationToken = null)
    Task SetBytesAsync(AssetUri assetUri, byte[] bytes, AssetMetadata? metadata = null, CancellationToken cancellationToken = null)
    Task SetTextAsync(AssetUri assetUri, string text, AssetMetadata? metadata = null, CancellationToken cancellationToken = null)
    Task<T> TryGetAsync<T>(AssetUri assetUri)
    Task<byte[]> TryGetBytesAsync(AssetUri assetUri)
    Task<AssetContent<byte[]>> TryGetBytesWithMetadataAsync(AssetUri assetUri)
    Task<AssetMetadata?> TryGetMetadataAsync(AssetUri assetUri)
    Task<string> TryGetTextAsync(AssetUri assetUri, Encoding encoding = null)
    Task<AssetContent<string>> TryGetTextWithMetadataAsync(AssetUri assetUri, Encoding encoding = null)
    Task<AssetContent<T>> TryGetWithMetadataAsync<T>(AssetUri assetUri)
    Task<AssetWriteResult> TrySetBytesAsync(AssetUri assetUri, byte[] bytes, AssetMetadata? metadata = null, CancellationToken cancellationToken = null)
    Task<AssetWriteResult> TrySetTextAsync(AssetUri assetUri, string text, AssetMetadata? metadata = null, CancellationToken cancellationToken = null)
  enum AssetClass
    LocalFile
    EmbeddedFile
    CloudFile
    CloudFilePublic
    CloudJson
    CloudProfile
  sealed class AssetContent<T> : IDisposable
    ctor(T content, AssetMetadata? metaData = null)
    T Content { get; }
    AssetMetadata? MetaData { get; }
    void Dispose()
  class AssetEventArgs : EventArgs
    ctor(AssetUri assetUri, AssetStatus status)
    AssetUri AssetUri { get; }
    AssetStatus Status { get; }
  struct AssetListingEntry
    ctor(AssetUri assetUri, AssetMetadata metadata)
    AssetUri AssetUri { get; }
    AssetMetadata Metadata { get; }
  struct AssetMetadata
    ctor(string mimeType = null, long? size = null, DateTime? lastModified = null, string url = null, bool? urlIsTemporal = null, string[] tags = null, string internalPath = null, string storageId = null)
    string InternalPath { get; }
    DateTime? LastModified { get; }
    string MimeType { get; }
    long? Size { get; }
    string StorageId { get; }
    string[] Tags { get; }
    string Url { get; }
    bool? UrlIsTemporal { get; }
  sealed class AssetQuery
    ctor(AssetClass assetClass)
    ctor(AssetUri folderUri)
    string ChannelId { get;  set; }
    AssetClass Class { get; }
    string ContinuationToken { get;  set; }
    string EffectiveChannelId { get; }
    string EffectiveFolderPrefix { get; }
    string EffectiveSpaceId { get; }
    string EffectiveUserId { get; }
    string FolderPrefix { get;  set; }
    AssetUri? FolderUri { get;  set; }
    int? Limit { get;  set; }
    string NextContinuationToken { get;  set; }
    string SpaceId { get;  set; }
    string[] Tags { get;  set; }
    string UserId { get;  set; }
    AssetQuery Clone()
  enum AssetStatus
    None
    Added
    Exists
    Changed
    Deleted
  struct AssetUri : IEquatable<AssetUri>
    ctor(string uriString)
    ctor(AssetClass assetClass, string path = null, string spaceId = null, string userId = null, string channelId = null, string query = null)
    string ChannelId { get; }
    AssetClass Class { get; }
    string FileName { get; }
    string Path { get; }
    string Query { get; }
    static string Scheme { get; }
    string SpaceId { get; }
    string UserId { get; }
    static AssetUri FromFilesystemPath(string relativePathToRoot, AssetClass defaultAssetClass = LocalFile)
    static bool IsValid(string uriString)
    static string ToFilesystemPath(AssetUri assetUri)
    static bool TryParse(string uriString, out AssetUri assetUri, out string failureReason)
    static bool TryParse(string uriString, out AssetUri assetUri)
    AssetUri With(AssetClass? assetClass = null, string path = null, string spaceId = null, string userId = null, string channelId = null, string query = null)
  struct AssetWriteResult
    ctor(AssetWriteStatus status, AssetMetadata? metadata = null)
    bool IsConflict { get; }
    AssetMetadata? Metadata { get; }
    AssetWriteStatus Status { get; }
    bool Succeeded { get; }
  enum AssetWriteStatus
    NotFound
    Conflict
    Skipped
    Success
  interface IHashableStream
    abstract void SetSha256Hash(string hash)
  interface IStorage : IAsyncDisposable
    abstract Task DeleteAsync(AssetUri assetUri)
    abstract Task<bool> ExistsAsync(AssetUri assetUri)
    abstract Task<AssetContent<Stream>> GetReadStreamAsync(AssetUri assetUri)
    abstract Task<Stream> GetWriteStreamAsync(AssetUri assetUri, AssetMetadata? metadata, CancellationToken cancellationToken)
    abstract Task<IReadOnlyList<AssetListingEntry>> ListAsync(AssetQuery query, CancellationToken cancellationToken)
    abstract Task StartAsync()
    abstract Task<AssetMetadata?> TryGetMetadataAsync(AssetUri assetUri)
    abstract Task WaitUntilQueueEmptyAsync()
    event Func<AssetEventArgs, Task> AssetEventAsync
  static class StorageExtensions
    static Task AddEmbeddedFileStorageAsync(Asset asset, Assembly assembly = null, string resourceNamespace = "")

namespace Ikon.Common.Core.CommandLineParser
  static class CommandLineParser
    static Task<ParseResult<TGlobalOptions>> ParseAsync<TGlobalOptions>(string[] args, bool globalOptionsOnly = false)
  sealed class OptionAttribute : Attribute
    ctor(string name, string description, bool required = false, string[] synonyms = null)
    string Description { get; }
    string Name { get; }
    bool Required { get;  set; }
    string[] Synonyms { get; }
  sealed class ParseResult<TGlobalOptions>
    ctor(bool success, string errorMessage, bool helpRequested, string helpText, TGlobalOptions globalOptions, VerbInfo verbInfo, bool unknownVerb = false)
    string ErrorMessage { get; }
    TGlobalOptions GlobalOptions { get; }
    bool HelpRequested { get; }
    string HelpText { get; }
    bool Success { get; }
    bool UnknownVerb { get; }
    VerbInfo VerbInfo { get; }
  sealed class PositionalOptionAttribute : Attribute
    ctor(int index, string name, string description, bool required = false)
    string Description { get; }
    int Index { get; }
    string Name { get; }
    bool Required { get;  set; }
  sealed class RemainingArgsOptionAttribute : Attribute
    ctor(string description)
    string Description { get; }
  sealed class VerbAttribute : Attribute
    ctor(string verb, string description, string category = null, bool loginNeeded = false, bool spaceTokenNeeded = false, string[] synonyms = null)
    string Category { get; }
    string Description { get; }
    bool LoginNeeded { get; }
    bool SpaceTokenNeeded { get; }
    string[] Synonyms { get; }
    string Verb { get; }
  sealed class VerbCache
    ctor()
    string Hash { get;  set; }
    List<VerbCacheEntry> Verbs { get;  set; }
  sealed class VerbCacheEntry
    ctor()
    string AssemblyName { get;  set; }
    string Description { get;  set; }
    bool LoginNeeded { get;  set; }
    string MethodName { get;  set; }
    string OptionsTypeAssemblyName { get;  set; }
    string OptionsTypeFullName { get;  set; }
    bool SpaceTokenNeeded { get;  set; }
    string[] Synonyms { get;  set; }
    string TypeFullName { get;  set; }
    string Verb { get;  set; }
  sealed class VerbInfo
    ctor(bool loginNeeded, bool spaceTokenNeeded, object options, Func<object, CancellationToken, ValueTask> callback)
    Func<object, CancellationToken, ValueTask> Callback { get; }
    bool LoginNeeded { get; }
    object Options { get; }
    bool SpaceTokenNeeded { get; }
  static class VerbResolver
    static bool LoadVerbCache(string path)
    static void WriteVerbCache(string path, string hash)

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

namespace Ikon.Common.Core.Functions.Policy
  sealed class PolicyDecision.Allow : PolicyDecision
  sealed class ApprovalAuditEntry
    ctor(Guid approvalId, Guid callId, string functionName, int approverSessionId, string approverUserId, bool approved, string reason, string policyName, DateTimeOffset timestamp)
    Guid ApprovalId { get; }
    bool Approved { get; }
    int ApproverSessionId { get; }
    string ApproverUserId { get; }
    Guid CallId { get; }
    string FunctionName { get; }
    string PolicyName { get; }
    string Reason { get; }
    DateTimeOffset Timestamp { get; }
    static ApprovalAuditEntry CreateApproved(Guid approvalId, Guid callId, string functionName, int approverSessionId, string approverUserId, string policyName)
    static ApprovalAuditEntry CreateRejected(Guid approvalId, Guid callId, string functionName, int approverSessionId, string approverUserId, string reason, string policyName)
  sealed class ApprovalContext
    Guid ApprovalId { get; }
    string ApprovalTokenHash { get; }
    object[] Args { get; }
    string ArgsHash { get; }
    PolicyCallContext CallContext { get; }
    int CallerSessionId { get; }
    DateTimeOffset ExpiresAt { get; }
    string FunctionName { get; }
    string Reason { get; }
    int TimeoutSeconds { get; }
    static ValueTuple<ApprovalContext, Guid> Create(string functionName, string reason, object[] args, PolicyCallContext callContext, int timeoutSeconds = 300)
    bool IsExpired()
    bool ValidateToken(Guid providedToken)
    bool ValidateToken(string providedToken)
  delegate ApprovalHandlerDelegate
    Task<ApprovalResult> ApprovalHandlerDelegate(ApprovalContext context)
  struct ApprovalResult
    bool IsApproved { get; }
    string RejectionReason { get; }
    static ApprovalResult Approved()
    static ApprovalResult Rejected(string reason = null)
    override string ToString()
  enum ApproverType
    Caller
    SpecificClient
    SpecificUser
  static class BuiltInApprovalHandlers
    static ApprovalHandlerDelegate AskCaller { get; }
    static ApprovalHandlerDelegate AskClient(int clientSessionId)
    static ApprovalHandlerDelegate AskUser(string userId)
  sealed class PolicyDecision.Deny : PolicyDecision
    string Code { get; }
    string Reason { get; }
  interface IFunctionPolicy
    string Name { get; }
    int Priority { get; }
    abstract ValueTask<PolicyDecision> EvaluateAsync(object[] args, PolicyCallContext context)
  interface IUsageLimitChecker
    abstract ValueTask<UsageLimitCheckResult> CheckAsync(PolicyCallContext context, object[] args)
  sealed class PolicyDecision.NeedsApproval : PolicyDecision
    int ExpirySeconds { get; }
    ApprovalHandlerDelegate Handler { get; }
    string Message { get; }
  sealed class PerSessionRateLimitPolicy : IFunctionPolicy
    ctor(int limit, int windowSeconds, string name = null, int priority = 50)
    string Name { get; }
    int Priority { get; }
    ValueTask<PolicyDecision> EvaluateAsync(object[] args, PolicyCallContext context)
    PolicyDelegate ToDelegate()
  static class PolicyArgs
    static bool HasAll(object[] args, params int[] requiredIndices)
    static T Optional<T>(object[] args, int index, T defaultValue = null)
    static T Required<T>(object[] args, int index)
    static bool TryGet<T>(object[] args, int index, out T value)
  abstract class PolicyAttribute : Attribute
    int Priority { get;  set; }
    abstract IFunctionPolicy CreatePolicy()
  sealed class PolicyAttribute<TPolicy> : PolicyAttribute where TPolicy : new(), IFunctionPolicy
    ctor()
    override IFunctionPolicy CreatePolicy()
  sealed class PolicyCallContext
    ctor(Guid callId, string functionName, int callerSessionId, string userId, string tenantId, Guid? instanceId, bool isInternal, CancellationToken cancellationToken, DateTime? callTimestamp = null, IReadOnlyDictionary<string, object> additionalContext = null)
    IReadOnlyDictionary<string, object> AdditionalContext { get; }
    Guid CallId { get; }
    DateTime CallTimestamp { get; }
    int CallerSessionId { get; }
    CancellationToken CancellationToken { get; }
    string FunctionName { get; }
    Guid? InstanceId { get; }
    bool IsInternal { get; }
    string TenantId { get; }
    string UserId { get; }
  static class PolicyChain
    static IFunctionPolicy All(params IFunctionPolicy[] policies)
    static PolicyDelegate AllAsDelegate(params IFunctionPolicy[] policies)
  abstract class PolicyDecision
    static PolicyDecision Allowed()
    static PolicyDecision Denied(string reason, string code = null)
    static PolicyDecision RequireApproval(string message)
    static PolicyDecision RequireApproval(string message, int expirySeconds)
    static PolicyDecision RequireApproval(string message, ApprovalHandlerDelegate handler)
    static PolicyDecision RequireApproval(string message, int expirySeconds, ApprovalHandlerDelegate handler)
    static int DefaultExpirySeconds
    static int MinExpirySeconds
  delegate PolicyDelegate
    ValueTask<PolicyDecision> PolicyDelegate(object[] args, PolicyCallContext context)
  sealed class PolicyEvaluationResult
    ctor(PolicyDecision decision, string functionName, Guid callId, string decidingPolicyName, TimeSpan evaluationDuration)
    Guid CallId { get; }
    string DecidingPolicyName { get; }
    PolicyDecision Decision { get; }
    TimeSpan EvaluationDuration { get; }
    string FunctionName { get; }
    bool IsAllowed { get; }
    bool IsDenied { get; }
    bool RequiresApproval { get; }
    static PolicyEvaluationResult Allowed(string functionName, Guid callId)
    static PolicyEvaluationResult Denied(string functionName, Guid callId, string reason, string policyName, TimeSpan evaluationDuration)
    static PolicyEvaluationResult Denied(string functionName, Guid callId, string reason, string code, string policyName, TimeSpan evaluationDuration)
    static PolicyEvaluationResult NeedsApproval(PolicyDecision decision, string functionName, Guid callId, string policyName, TimeSpan evaluationDuration)
    override string ToString()
  sealed class PolicyTypeAttribute : PolicyAttribute
    ctor(Type policyType)
    Type PolicyType { get; }
    override IFunctionPolicy CreatePolicy()
  sealed class RateLimitAttribute : PolicyAttribute
    ctor(int limit, int windowSeconds)
    int Limit { get; }
    bool PerSession { get;  set; }
    int WindowSeconds { get; }
    override IFunctionPolicy CreatePolicy()
  sealed class RateLimitPolicy : IFunctionPolicy
    ctor(int limit, int windowSeconds, string name = null, int priority = 50)
    string Name { get; }
    int Priority { get; }
    ValueTask<PolicyDecision> EvaluateAsync(object[] args, PolicyCallContext context)
    PolicyDelegate ToDelegate()
  sealed class RequireApprovalAttribute : PolicyAttribute
    ctor()
    ApproverType ApproverType { get;  set; }
    int ClientSessionId { get;  set; }
    string Reason { get;  set; }
    string UserId { get;  set; }
    override IFunctionPolicy CreatePolicy()
  sealed class RequireApprovalPolicy : IFunctionPolicy
    ctor(string reason, string name = null, int priority = 100)
    ctor(string reason, ApprovalHandlerDelegate handler, string name = null, int priority = 100)
    string Name { get; }
    int Priority { get; }
    ValueTask<PolicyDecision> EvaluateAsync(object[] args, PolicyCallContext context)
    static RequireApprovalPolicy ForClient(string reason, int clientSessionId, string name = null, int priority = 100)
    static RequireApprovalPolicy ForUser(string reason, string userId, string name = null, int priority = 100)
    PolicyDelegate ToDelegate()
  sealed class UsageLimitAttribute : PolicyAttribute
    ctor(Type checkerType)
    Type CheckerType { get; }
    override IFunctionPolicy CreatePolicy()
  sealed class UsageLimitCheckResult
    bool Allowed { get; }
    string DenyCode { get; }
    string DenyReason { get; }
    static UsageLimitCheckResult Allow()
    static UsageLimitCheckResult Deny(string reason, string code = "usage_limit_exceeded")
  sealed class UsageLimitPolicy : IFunctionPolicy
    ctor(IUsageLimitChecker checker, string name = null, int priority = 10)
    string Name { get; }
    int Priority { get; }
    ValueTask<PolicyDecision> EvaluateAsync(object[] args, PolicyCallContext context)
    PolicyDelegate ToDelegate()

namespace Ikon.Common.Core.Protocol
  sealed class Action : IProtocolMessagePayload
    ctor()
    ctor(string description, string actionId)
    string ActionId { get;  set; }
    string Description { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static Action ReadFromTeleport(ReadOnlySpan<byte> data)
    static Action ReadFromTeleport(ReadOnlySpan<byte> data, Action destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionActive : IProtocolMessagePayload
    ctor()
    ctor(string description, bool isFinished)
    string Description { get;  set; }
    bool IsFinished { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionActive ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionActive ReadFromTeleport(ReadOnlySpan<byte> data, ActionActive destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionAudioStop : IProtocolMessagePayload
    ctor()
    ctor(string audioStreamId, float fadeoutTimeInSec)
    string AudioStreamId { get;  set; }
    float FadeoutTimeInSec { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionAudioStop ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionAudioStop ReadFromTeleport(ReadOnlySpan<byte> data, ActionAudioStop destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionCall : IProtocolMessagePayload
    ctor()
    ctor(string actionId, string callId, string callArgumentsJson)
    string ActionId { get;  set; }
    string CallArgumentsJson { get;  set; }
    string CallId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionCall ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionCall ReadFromTeleport(ReadOnlySpan<byte> data, ActionCall destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionCall2 : IProtocolMessagePayload
    ctor()
    ctor(Guid actionId, string payloadJson)
    Guid ActionId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string PayloadJson { get;  set; }
    static ActionCall2 ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionCall2 ReadFromTeleport(ReadOnlySpan<byte> data, ActionCall2 destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionCallResult : IProtocolMessagePayload
    ctor()
    ctor(string callId, string resultJson)
    string CallId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string ResultJson { get;  set; }
    static ActionCallResult ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionCallResult ReadFromTeleport(ReadOnlySpan<byte> data, ActionCallResult destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionCallText : IProtocolMessagePayload
    ctor()
    ctor(string actionId, string text)
    string ActionId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Text { get;  set; }
    static ActionCallText ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionCallText ReadFromTeleport(ReadOnlySpan<byte> data, ActionCallText destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionCancelGeneration : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionCancelGeneration ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionCancelGeneration ReadFromTeleport(ReadOnlySpan<byte> data, ActionCancelGeneration destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionClassificationResult.ActionClassificationDetail
    ctor()
    ctor(string label, string originalCategory, bool isFlagged, double score)
    bool IsFlagged { get;  set; }
    string Label { get;  set; }
    string OriginalCategory { get;  set; }
    double Score { get;  set; }
    static ActionClassificationResult.ActionClassificationDetail ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionClassificationResult.ActionClassificationDetail ReadFromTeleport(ReadOnlySpan<byte> data, ActionClassificationResult.ActionClassificationDetail destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionClassificationResult : IProtocolMessagePayload
    ctor()
    ctor(bool isFlagged, List<ActionClassificationResult.ActionClassificationDetail> details)
    List<ActionClassificationResult.ActionClassificationDetail> Details { get;  set; }
    bool IsFlagged { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionClassificationResult ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionClassificationResult ReadFromTeleport(ReadOnlySpan<byte> data, ActionClassificationResult destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionClearChatMessageHistory : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionClearChatMessageHistory ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionClearChatMessageHistory ReadFromTeleport(ReadOnlySpan<byte> data, ActionClearChatMessageHistory destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionClearState : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionClearState ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionClearState ReadFromTeleport(ReadOnlySpan<byte> data, ActionClearState destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionCustomUserMessage : IProtocolMessagePayload
    ctor()
    ctor(int? opcode, string typeName, string mimeType, string jsonPayload, byte[] binaryPayload)
    byte[] BinaryPayload { get;  set; }
    string JsonPayload { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string MimeType { get;  set; }
    int? Opcode { get;  set; }
    string TypeName { get;  set; }
    static ActionCustomUserMessage ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionCustomUserMessage ReadFromTeleport(ReadOnlySpan<byte> data, ActionCustomUserMessage destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionDownload : IProtocolMessagePayload
    ctor()
    ctor(string fileName, string mime, string data)
    string Data { get;  set; }
    string FileName { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Mime { get;  set; }
    static ActionDownload ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionDownload ReadFromTeleport(ReadOnlySpan<byte> data, ActionDownload destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionEnterFullscreen : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionEnterFullscreen ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionEnterFullscreen ReadFromTeleport(ReadOnlySpan<byte> data, ActionEnterFullscreen destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadAck : IProtocolMessagePayload
    ctor()
    ctor(string actionId, int sequenceId)
    string ActionId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    int SequenceId { get;  set; }
    static ActionFileUploadAck ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadAck ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadAck destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadAck2 : IProtocolMessagePayload
    ctor()
    ctor(string uploadId, int sequenceId)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    int SequenceId { get;  set; }
    string UploadId { get;  set; }
    static ActionFileUploadAck2 ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadAck2 ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadAck2 destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadBegin : IProtocolMessagePayload
    ctor()
    ctor(string actionId, string fileName, string mime, int byteCount, bool checkHash, string hash)
    string ActionId { get;  set; }
    int ByteCount { get;  set; }
    bool CheckHash { get;  set; }
    string FileName { get;  set; }
    string Hash { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Mime { get;  set; }
    static ActionFileUploadBegin ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadBegin ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadBegin destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadCallback : IProtocolMessagePayload
    ctor()
    ctor(string actionId, string fileName, string mime, long size, string filePath)
    string ActionId { get;  set; }
    string FileName { get;  set; }
    string FilePath { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Mime { get;  set; }
    long Size { get;  set; }
    static ActionFileUploadCallback ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadCallback ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadCallback destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadComplete2 : IProtocolMessagePayload
    ctor()
    ctor(string uploadId)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string UploadId { get;  set; }
    static ActionFileUploadComplete2 ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadComplete2 ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadComplete2 destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadData : IProtocolMessagePayload
    ctor()
    ctor(string actionId, byte[] data, int sequenceId)
    string ActionId { get;  set; }
    byte[] Data { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    int SequenceId { get;  set; }
    static ActionFileUploadData ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadData ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadData destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadData2 : IProtocolMessagePayload
    ctor()
    ctor(string uploadId, byte[] data, int sequenceId)
    byte[] Data { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    int SequenceId { get;  set; }
    string UploadId { get;  set; }
    static ActionFileUploadData2 ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadData2 ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadData2 destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadEnd : IProtocolMessagePayload
    ctor()
    ctor(string actionId)
    string ActionId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionFileUploadEnd ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadEnd ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadEnd destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadEnd2 : IProtocolMessagePayload
    ctor()
    ctor(string uploadId)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string UploadId { get;  set; }
    static ActionFileUploadEnd2 ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadEnd2 ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadEnd2 destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadPreStart2 : IProtocolMessagePayload
    ctor()
    ctor(string uploadId, string uploadActionId, string fileName, string mime, long byteCount)
    long ByteCount { get;  set; }
    string FileName { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Mime { get;  set; }
    string UploadActionId { get;  set; }
    string UploadId { get;  set; }
    static ActionFileUploadPreStart2 ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadPreStart2 ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadPreStart2 destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadPreStartResponse2 : IProtocolMessagePayload
    ctor()
    ctor(string uploadId, bool accepted)
    bool Accepted { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string UploadId { get;  set; }
    static ActionFileUploadPreStartResponse2 ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadPreStartResponse2 ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadPreStartResponse2 destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadResult : IProtocolMessagePayload
    ctor()
    ctor(string actionId, bool isSuccess, string errorMessage)
    string ActionId { get;  set; }
    string ErrorMessage { get;  set; }
    bool IsSuccess { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionFileUploadResult ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadResult ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadResult destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadStart2 : IProtocolMessagePayload
    ctor()
    ctor(string uploadId, string hash)
    string Hash { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string UploadId { get;  set; }
    static ActionFileUploadStart2 ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadStart2 ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadStart2 destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFileUploadStartResponse2 : IProtocolMessagePayload
    ctor()
    ctor(string uploadId, bool accepted)
    bool Accepted { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string UploadId { get;  set; }
    static ActionFileUploadStartResponse2 ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFileUploadStartResponse2 ReadFromTeleport(ReadOnlySpan<byte> data, ActionFileUploadStartResponse2 destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionAck : IProtocolMessagePayload
    ctor()
    ctor(Guid callId, Guid instanceId)
    Guid CallId { get;  set; }
    Guid InstanceId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionFunctionAck ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionAck ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionAck destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionApprovalRequired : IProtocolMessagePayload
    ctor()
    ctor(Guid callId, Guid approvalId, Guid approvalToken, string functionName, string reason, string argsJson, int timeoutSeconds)
    Guid ApprovalId { get;  set; }
    Guid ApprovalToken { get;  set; }
    string ArgsJson { get;  set; }
    Guid CallId { get;  set; }
    string FunctionName { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Reason { get;  set; }
    int TimeoutSeconds { get;  set; }
    static ActionFunctionApprovalRequired ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionApprovalRequired ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionApprovalRequired destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionApprovalResponse : IProtocolMessagePayload
    ctor()
    ctor(Guid approvalId, Guid approvalToken, bool approved, string rejectionReason)
    Guid ApprovalId { get;  set; }
    Guid ApprovalToken { get;  set; }
    bool Approved { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string RejectionReason { get;  set; }
    static ActionFunctionApprovalResponse ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionApprovalResponse ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionApprovalResponse destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionAwaitingApproval : IProtocolMessagePayload
    ctor()
    ctor(Guid callId, Guid approvalId, string functionName, string reason, int timeoutSeconds)
    Guid ApprovalId { get;  set; }
    Guid CallId { get;  set; }
    string FunctionName { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Reason { get;  set; }
    int TimeoutSeconds { get;  set; }
    static ActionFunctionAwaitingApproval ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionAwaitingApproval ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionAwaitingApproval destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionCall : IProtocolMessagePayload
    ctor()
    ctor(Guid functionId, Guid callId, Guid instanceId, string functionName, List<FunctionParameter> parameters, List<ActionFunctionCall.ScopeEntry> scopes, string version)
    Guid CallId { get;  set; }
    Guid FunctionId { get;  set; }
    string FunctionName { get;  set; }
    Guid InstanceId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    List<FunctionParameter> Parameters { get;  set; }
    List<ActionFunctionCall.ScopeEntry> Scopes { get;  set; }
    string Version { get;  set; }
    static ActionFunctionCall ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionCall ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionCall destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionCancel : IProtocolMessagePayload
    ctor()
    ctor(Guid callId, Guid instanceId)
    Guid CallId { get;  set; }
    Guid InstanceId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionFunctionCancel ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionCancel ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionCancel destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionDispose : IProtocolMessagePayload
    ctor()
    ctor(Guid callId, Guid instanceId)
    Guid CallId { get;  set; }
    Guid InstanceId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionFunctionDispose ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionDispose ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionDispose destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionEnumerationEnd : IProtocolMessagePayload
    ctor()
    ctor(Guid callId, Guid instanceId, Guid enumerationId)
    Guid CallId { get;  set; }
    Guid EnumerationId { get;  set; }
    Guid InstanceId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionFunctionEnumerationEnd ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionEnumerationEnd ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionEnumerationEnd destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionEnumerationItem : IProtocolMessagePayload
    ctor()
    ctor(Guid callId, Guid instanceId, Guid enumerationId, long itemIndex, string itemTypeName, string itemJson, byte[] itemData)
    Guid CallId { get;  set; }
    Guid EnumerationId { get;  set; }
    Guid InstanceId { get;  set; }
    byte[] ItemData { get;  set; }
    long ItemIndex { get;  set; }
    string ItemJson { get;  set; }
    string ItemTypeName { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionFunctionEnumerationItem ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionEnumerationItem ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionEnumerationItem destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionEnumerationItemBatch : IProtocolMessagePayload
    ctor()
    ctor(List<ActionFunctionEnumerationItem> items)
    List<ActionFunctionEnumerationItem> Items { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionFunctionEnumerationItemBatch ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionEnumerationItemBatch ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionEnumerationItemBatch destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionError : IProtocolMessagePayload
    ctor()
    ctor(Guid callId, Guid instanceId, string errorMessage, string errorTypeName, string stackTrace)
    Guid CallId { get;  set; }
    string ErrorMessage { get;  set; }
    string ErrorTypeName { get;  set; }
    Guid InstanceId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string StackTrace { get;  set; }
    static ActionFunctionError ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionError ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionError destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionRegister : IProtocolMessagePayload
    ctor()
    ctor(Guid functionId, string functionName, List<ActionFunctionRegister.FunctionRegisterParameter> parameters, string resultTypeName, bool isEnumerable, string enumerableItemTypeName, bool isCancellable, string description, bool llmInlineResult, bool llmCallOnlyOnce, bool requiresInstance, List<string> versions)
    string Description { get;  set; }
    string EnumerableItemTypeName { get;  set; }
    Guid FunctionId { get;  set; }
    string FunctionName { get;  set; }
    bool IsCancellable { get;  set; }
    bool IsEnumerable { get;  set; }
    bool LlmCallOnlyOnce { get;  set; }
    bool LlmInlineResult { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    List<ActionFunctionRegister.FunctionRegisterParameter> Parameters { get;  set; }
    bool RequiresInstance { get;  set; }
    string ResultTypeName { get;  set; }
    List<string> Versions { get;  set; }
    static ActionFunctionRegister.FunctionRegisterParameter CreateParameter(int parameterIndex, string parameterName, Type clrType, bool hasDefaultValue, object defaultValue, bool isEnumerable, string enumerableItemTypeName, string description)
    static ActionFunctionRegister ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionRegister ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionRegister destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionRegisterBatch : IProtocolMessagePayload
    ctor()
    ctor(List<ActionFunctionRegister> functions)
    List<ActionFunctionRegister> Functions { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionFunctionRegisterBatch ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionRegisterBatch ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionRegisterBatch destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionResult : IProtocolMessagePayload
    ctor()
    ctor(Guid callId, Guid instanceId, string resultTypeName, string resultJson, byte[] resultData)
    Guid CallId { get;  set; }
    Guid InstanceId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    byte[] ResultData { get;  set; }
    string ResultJson { get;  set; }
    string ResultTypeName { get;  set; }
    static ActionFunctionResult ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionResult ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionResult destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionGenerateAnswer : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionGenerateAnswer ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionGenerateAnswer ReadFromTeleport(ReadOnlySpan<byte> data, ActionGenerateAnswer destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionOpenChannel : IProtocolMessagePayload
    ctor()
    ctor(string channelCode, string prompt)
    string ChannelCode { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Prompt { get;  set; }
    static ActionOpenChannel ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionOpenChannel ReadFromTeleport(ReadOnlySpan<byte> data, ActionOpenChannel destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionOpenExternalUrl : IProtocolMessagePayload
    ctor()
    ctor(string name, string url)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Name { get;  set; }
    string Url { get;  set; }
    static ActionOpenExternalUrl ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionOpenExternalUrl ReadFromTeleport(ReadOnlySpan<byte> data, ActionOpenExternalUrl destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionPan : IProtocolMessagePayload
    ctor()
    ctor(Coordinate2D location, Coordinate2D delta)
    Coordinate2D Delta { get;  set; }
    Coordinate2D Location { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionPan ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionPan ReadFromTeleport(ReadOnlySpan<byte> data, ActionPan destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionPlaySound : IProtocolMessagePayload
    ctor()
    ctor(string url, int count, string id)
    int Count { get;  set; }
    string Id { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Url { get;  set; }
    static ActionPlaySound ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionPlaySound ReadFromTeleport(ReadOnlySpan<byte> data, ActionPlaySound destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionRegenerateAnswer : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionRegenerateAnswer ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionRegenerateAnswer ReadFromTeleport(ReadOnlySpan<byte> data, ActionRegenerateAnswer destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionReloadApplication : IProtocolMessagePayload
    ctor()
    ctor(string applicationId)
    string ApplicationId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionReloadApplication ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionReloadApplication ReadFromTeleport(ReadOnlySpan<byte> data, ActionReloadApplication destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionReloadChannels : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionReloadChannels ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionReloadChannels ReadFromTeleport(ReadOnlySpan<byte> data, ActionReloadChannels destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionReloadProfile : IProtocolMessagePayload
    ctor()
    ctor(string profileId, string userId)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string ProfileId { get;  set; }
    string UserId { get;  set; }
    static ActionReloadProfile ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionReloadProfile ReadFromTeleport(ReadOnlySpan<byte> data, ActionReloadProfile destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionReloadProvider : IProtocolMessagePayload
    ctor()
    ctor(string providerId)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string ProviderId { get;  set; }
    static ActionReloadProvider ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionReloadProvider ReadFromTeleport(ReadOnlySpan<byte> data, ActionReloadProvider destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionScrollToContainer : IProtocolMessagePayload
    ctor()
    ctor(string containerId)
    string ContainerId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionScrollToContainer ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionScrollToContainer ReadFromTeleport(ReadOnlySpan<byte> data, ActionScrollToContainer destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionSetState : IProtocolMessagePayload
    ctor()
    ctor(string key, string typeName, string valueJson)
    string Key { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string TypeName { get;  set; }
    string ValueJson { get;  set; }
    static ActionSetState ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionSetState ReadFromTeleport(ReadOnlySpan<byte> data, ActionSetState destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionSpeechRecognized : IProtocolMessagePayload
    ctor()
    ctor(bool wasSuccessful, string text)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Text { get;  set; }
    bool WasSuccessful { get;  set; }
    static ActionSpeechRecognized ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionSpeechRecognized ReadFromTeleport(ReadOnlySpan<byte> data, ActionSpeechRecognized destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionStartRecording : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionStartRecording ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionStartRecording ReadFromTeleport(ReadOnlySpan<byte> data, ActionStartRecording destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionStopRecording : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionStopRecording ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionStopRecording ReadFromTeleport(ReadOnlySpan<byte> data, ActionStopRecording destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionStopSound : IProtocolMessagePayload
    ctor()
    ctor(string id, float fadeoutTimeInSec)
    float FadeoutTimeInSec { get;  set; }
    string Id { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionStopSound ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionStopSound ReadFromTeleport(ReadOnlySpan<byte> data, ActionStopSound destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionTap : IProtocolMessagePayload
    ctor()
    ctor(Coordinate2D location)
    Coordinate2D Location { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionTap ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionTap ReadFromTeleport(ReadOnlySpan<byte> data, ActionTap destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionTextOutput : IProtocolMessagePayload
    ctor()
    ctor(string userId, string text, bool generateChatMessage, string createdAt, ulong preciseCreatedAt)
    string CreatedAt { get;  set; }
    bool GenerateChatMessage { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    ulong PreciseCreatedAt { get;  set; }
    string Text { get;  set; }
    string UserId { get;  set; }
    static ActionTextOutput ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionTextOutput ReadFromTeleport(ReadOnlySpan<byte> data, ActionTextOutput destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionTextOutputDelta : IProtocolMessagePayload
    ctor()
    ctor(string delta)
    string Delta { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionTextOutputDelta ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionTextOutputDelta ReadFromTeleport(ReadOnlySpan<byte> data, ActionTextOutputDelta destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionTextOutputDeltaFull : IProtocolMessagePayload
    ctor()
    ctor(string full)
    string Full { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionTextOutputDeltaFull ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionTextOutputDeltaFull ReadFromTeleport(ReadOnlySpan<byte> data, ActionTextOutputDeltaFull destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionTriggerGitPull : IProtocolMessagePayload
    ctor()
    ctor(bool forceFullRebuild, string target)
    bool ForceFullRebuild { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Target { get;  set; }
    static ActionTriggerGitPull ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionTriggerGitPull ReadFromTeleport(ReadOnlySpan<byte> data, ActionTriggerGitPull destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionUIBlockingBegin : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionUIBlockingBegin ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionUIBlockingBegin ReadFromTeleport(ReadOnlySpan<byte> data, ActionUIBlockingBegin destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionUIBlockingEnd : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionUIBlockingEnd ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionUIBlockingEnd ReadFromTeleport(ReadOnlySpan<byte> data, ActionUIBlockingEnd destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionUIClearStream : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionUIClearStream ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionUIClearStream ReadFromTeleport(ReadOnlySpan<byte> data, ActionUIClearStream destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionUICloseView : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionUICloseView ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionUICloseView ReadFromTeleport(ReadOnlySpan<byte> data, ActionUICloseView destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionUIDeleteContainer : IProtocolMessagePayload
    ctor()
    ctor(string containerId)
    string ContainerId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionUIDeleteContainer ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionUIDeleteContainer ReadFromTeleport(ReadOnlySpan<byte> data, ActionUIDeleteContainer destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionUIOpenView : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionUIOpenView ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionUIOpenView ReadFromTeleport(ReadOnlySpan<byte> data, ActionUIOpenView destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionUISetContainerStable : IProtocolMessagePayload
    ctor()
    ctor(string containerId)
    string ContainerId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionUISetContainerStable ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionUISetContainerStable ReadFromTeleport(ReadOnlySpan<byte> data, ActionUISetContainerStable destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionUIUpdateTextDelta : IProtocolMessagePayload
    ctor()
    ctor(string containerId, int elementId, string delta)
    string ContainerId { get;  set; }
    string Delta { get;  set; }
    int ElementId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ActionUIUpdateTextDelta ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionUIUpdateTextDelta ReadFromTeleport(ReadOnlySpan<byte> data, ActionUIUpdateTextDelta destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionUpdateGfxShader : IProtocolMessagePayload
    ctor()
    ctor(string name, float fps, string content, string contentHash)
    string Content { get;  set; }
    string ContentHash { get;  set; }
    float Fps { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Name { get;  set; }
    static ActionUpdateGfxShader ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionUpdateGfxShader ReadFromTeleport(ReadOnlySpan<byte> data, ActionUpdateGfxShader destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionUrlChanged : IProtocolMessagePayload
    ctor()
    ctor(string path)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Path { get;  set; }
    static ActionUrlChanged ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionUrlChanged ReadFromTeleport(ReadOnlySpan<byte> data, ActionUrlChanged destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionZoom : IProtocolMessagePayload
    ctor()
    ctor(float startScale, float currentScale)
    float CurrentScale { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    float StartScale { get;  set; }
    static ActionZoom ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionZoom ReadFromTeleport(ReadOnlySpan<byte> data, ActionZoom destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AnalyticsEvents : IProtocolMessagePayload
    ctor()
    ctor(List<AnalyticsEvents.AnalyticsEventsItem> events)
    List<AnalyticsEvents.AnalyticsEventsItem> Events { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static AnalyticsEvents ReadFromTeleport(ReadOnlySpan<byte> data)
    static AnalyticsEvents ReadFromTeleport(ReadOnlySpan<byte> data, AnalyticsEvents destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AnalyticsEvents.AnalyticsEventsItem
    ctor()
    ctor(string time, string eventName, string message, string parameters)
    string EventName { get;  set; }
    string Message { get;  set; }
    string Parameters { get;  set; }
    string Time { get;  set; }
    static AnalyticsEvents.AnalyticsEventsItem ReadFromTeleport(ReadOnlySpan<byte> data)
    static AnalyticsEvents.AnalyticsEventsItem ReadFromTeleport(ReadOnlySpan<byte> data, AnalyticsEvents.AnalyticsEventsItem destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AnalyticsIkonProxyServerStats : IProtocolMessagePayload
    ctor()
    ctor(string time, int channelCount, double sentMessagesPerSecond, double sentMessagesBandwidthKb, int sentMessagesCount, double receivedMessagesPerSecond, double receivedMessagesBandwidthKb, int receivedMessagesCount, double cpuUsagePercentage, double processMemoryUsedMb, double managedMemoryUsedMb)
    int ChannelCount { get;  set; }
    double CpuUsagePercentage { get;  set; }
    double ManagedMemoryUsedMb { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    double ProcessMemoryUsedMb { get;  set; }
    double ReceivedMessagesBandwidthKb { get;  set; }
    int ReceivedMessagesCount { get;  set; }
    double ReceivedMessagesPerSecond { get;  set; }
    double SentMessagesBandwidthKb { get;  set; }
    int SentMessagesCount { get;  set; }
    double SentMessagesPerSecond { get;  set; }
    string Time { get;  set; }
    static AnalyticsIkonProxyServerStats ReadFromTeleport(ReadOnlySpan<byte> data)
    static AnalyticsIkonProxyServerStats ReadFromTeleport(ReadOnlySpan<byte> data, AnalyticsIkonProxyServerStats destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AnalyticsLogs : IProtocolMessagePayload
    ctor()
    ctor(List<AnalyticsLogs.AnalyticsLogsItem> logs)
    List<AnalyticsLogs.AnalyticsLogsItem> Logs { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static AnalyticsLogs ReadFromTeleport(ReadOnlySpan<byte> data)
    static AnalyticsLogs ReadFromTeleport(ReadOnlySpan<byte> data, AnalyticsLogs destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AnalyticsLogs.AnalyticsLogsItem
    ctor()
    ctor(string time, int type, string message, string parameters)
    string Message { get;  set; }
    string Parameters { get;  set; }
    string Time { get;  set; }
    int Type { get;  set; }
    static AnalyticsLogs.AnalyticsLogsItem ReadFromTeleport(ReadOnlySpan<byte> data)
    static AnalyticsLogs.AnalyticsLogsItem ReadFromTeleport(ReadOnlySpan<byte> data, AnalyticsLogs.AnalyticsLogsItem destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AnalyticsProcessingUpdate : IProtocolMessagePayload
    ctor()
    ctor(string processingId, int totalRuns, int totalItems, int totalPages, int totalRetries, int totalFailures, string startedAt, float elapsedSeconds, Dictionary<string, double> usages, int runsRemaining, int itemsRemaining, float estimatedTimeLeftSecondsRuns, float estimatedTimeLeftSecondsItems)
    float ElapsedSeconds { get;  set; }
    float EstimatedTimeLeftSecondsItems { get;  set; }
    float EstimatedTimeLeftSecondsRuns { get;  set; }
    int ItemsRemaining { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string ProcessingId { get;  set; }
    int RunsRemaining { get;  set; }
    string StartedAt { get;  set; }
    int TotalFailures { get;  set; }
    int TotalItems { get;  set; }
    int TotalPages { get;  set; }
    int TotalRetries { get;  set; }
    int TotalRuns { get;  set; }
    Dictionary<string, double> Usages { get;  set; }
    static AnalyticsProcessingUpdate ReadFromTeleport(ReadOnlySpan<byte> data)
    static AnalyticsProcessingUpdate ReadFromTeleport(ReadOnlySpan<byte> data, AnalyticsProcessingUpdate destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AnalyticsReactiveProcessingUpdate : IProtocolMessagePayload
    ctor()
    ctor(string processingId, string startedAt, float elapsedSeconds, int inputItemCount, int inputItemCacheHits, int inputItemCacheMiss, int processedItemCount, int processedItemCacheHits, int processedItemCacheMiss, int outputItemCount, int outputItemCacheHits, int outputItemCacheMiss, int invalidItemCount, int duplicateItemCount, int processRetryCount, int processFailureCount, int warningLogCount, int errorLogCount, bool hasCompleted, bool hasFaulted, bool wasCancelled, Dictionary<string, float> usages)
    int DuplicateItemCount { get;  set; }
    float ElapsedSeconds { get;  set; }
    int ErrorLogCount { get;  set; }
    bool HasCompleted { get;  set; }
    bool HasFaulted { get;  set; }
    int InputItemCacheHits { get;  set; }
    int InputItemCacheMiss { get;  set; }
    int InputItemCount { get;  set; }
    int InvalidItemCount { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    int OutputItemCacheHits { get;  set; }
    int OutputItemCacheMiss { get;  set; }
    int OutputItemCount { get;  set; }
    int ProcessFailureCount { get;  set; }
    int ProcessRetryCount { get;  set; }
    int ProcessedItemCacheHits { get;  set; }
    int ProcessedItemCacheMiss { get;  set; }
    int ProcessedItemCount { get;  set; }
    string ProcessingId { get;  set; }
    string StartedAt { get;  set; }
    Dictionary<string, float> Usages { get;  set; }
    int WarningLogCount { get;  set; }
    bool WasCancelled { get;  set; }
    static AnalyticsReactiveProcessingUpdate ReadFromTeleport(ReadOnlySpan<byte> data)
    static AnalyticsReactiveProcessingUpdate ReadFromTeleport(ReadOnlySpan<byte> data, AnalyticsReactiveProcessingUpdate destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AnalyticsSpecialLog : IProtocolMessagePayload
    ctor()
    ctor(string title, string message)
    string Message { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Title { get;  set; }
    static AnalyticsSpecialLog ReadFromTeleport(ReadOnlySpan<byte> data)
    static AnalyticsSpecialLog ReadFromTeleport(ReadOnlySpan<byte> data, AnalyticsSpecialLog destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AnalyticsUsage : IProtocolMessagePayload
    ctor()
    ctor(string usageName, float usage)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    float Usage { get;  set; }
    string UsageName { get;  set; }
    static AnalyticsUsage ReadFromTeleport(ReadOnlySpan<byte> data)
    static AnalyticsUsage ReadFromTeleport(ReadOnlySpan<byte> data, AnalyticsUsage destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AnalyticsUsages : IProtocolMessagePayload
    ctor()
    ctor(List<AnalyticsUsages.AnalyticsUsagesItem> usages)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    List<AnalyticsUsages.AnalyticsUsagesItem> Usages { get;  set; }
    static AnalyticsUsages ReadFromTeleport(ReadOnlySpan<byte> data)
    static AnalyticsUsages ReadFromTeleport(ReadOnlySpan<byte> data, AnalyticsUsages destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AnalyticsUsages.AnalyticsUsagesItem
    ctor()
    ctor(string time, string eventName, float usage, string parameters)
    string EventName { get;  set; }
    string Parameters { get;  set; }
    string Time { get;  set; }
    float Usage { get;  set; }
    static AnalyticsUsages.AnalyticsUsagesItem ReadFromTeleport(ReadOnlySpan<byte> data)
    static AnalyticsUsages.AnalyticsUsagesItem ReadFromTeleport(ReadOnlySpan<byte> data, AnalyticsUsages.AnalyticsUsagesItem destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum AppSourceType
    Bundle
    GitSource
  enum AudioCodec
    Unknown
    Opus
    Mp3
    RawPcm16
  sealed class AudioFrame : IProtocolMessagePayload
    ctor()
    ctor(byte[] data, bool isKey, bool isLast, ulong timestampInUs, uint durationInUs, bool isFirst, uint totalDurationInUs, float volume, int volumeSampleCount)
    byte[] Data { get;  set; }
    uint DurationInUs { get;  set; }
    bool IsFirst { get;  set; }
    bool IsKey { get;  set; }
    bool IsLast { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    ulong TimestampInUs { get;  set; }
    uint TotalDurationInUs { get;  set; }
    float Volume { get;  set; }
    int VolumeSampleCount { get;  set; }
    static AudioFrame ReadFromTeleport(ReadOnlySpan<byte> data)
    static AudioFrame ReadFromTeleport(ReadOnlySpan<byte> data, AudioFrame destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AudioFrame2 : IProtocolMessagePayload
    ctor()
    ctor(byte[] samples, uint epoch, uint sequence, uint frameSizeInInterleavedSamples, ulong timeStampInInterleavedSamples, bool isFirst, bool isLast, float averageVolume, float audioEventEstimatedDuration, List<AudioFrame2.AudioShapeSetValues> shapeSetValues)
    float AudioEventEstimatedDuration { get;  set; }
    float AverageVolume { get;  set; }
    uint Epoch { get;  set; }
    uint FrameSizeInInterleavedSamples { get;  set; }
    bool IsFirst { get;  set; }
    bool IsLast { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    byte[] Samples { get;  set; }
    uint Sequence { get;  set; }
    List<AudioFrame2.AudioShapeSetValues> ShapeSetValues { get;  set; }
    ulong TimeStampInInterleavedSamples { get;  set; }
    static AudioFrame2 ReadFromTeleport(ReadOnlySpan<byte> data)
    static AudioFrame2 ReadFromTeleport(ReadOnlySpan<byte> data, AudioFrame2 destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AudioFrameVolume : IProtocolMessagePayload
    ctor()
    ctor(float volume, int count)
    int Count { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    float Volume { get;  set; }
    static AudioFrameVolume ReadFromTeleport(ReadOnlySpan<byte> data)
    static AudioFrameVolume ReadFromTeleport(ReadOnlySpan<byte> data, AudioFrameVolume destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AudioStreamBegin.AudioShapeSet
    ctor()
    ctor(uint setId, string name, List<string> shapeNames)
    string Name { get;  set; }
    uint SetId { get;  set; }
    List<string> ShapeNames { get;  set; }
    static AudioStreamBegin.AudioShapeSet ReadFromTeleport(ReadOnlySpan<byte> data)
    static AudioStreamBegin.AudioShapeSet ReadFromTeleport(ReadOnlySpan<byte> data, AudioStreamBegin.AudioShapeSet destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AudioFrame2.AudioShapeSetValues
    ctor()
    ctor(uint setId, List<float> values)
    uint SetId { get;  set; }
    List<float> Values { get;  set; }
    static AudioFrame2.AudioShapeSetValues ReadFromTeleport(ReadOnlySpan<byte> data)
    static AudioFrame2.AudioShapeSetValues ReadFromTeleport(ReadOnlySpan<byte> data, AudioFrame2.AudioShapeSetValues destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AudioStreamBegin : IProtocolMessagePayload
    ctor()
    ctor(string streamId, string description, string sourceType, AudioCodec codec, string codecDetails, int sampleRate, int channels, List<AudioStreamBegin.AudioShapeSet> shapeSets)
    int Channels { get;  set; }
    AudioCodec Codec { get;  set; }
    string CodecDetails { get;  set; }
    string Description { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    int SampleRate { get;  set; }
    List<AudioStreamBegin.AudioShapeSet> ShapeSets { get;  set; }
    string SourceType { get;  set; }
    string StreamId { get;  set; }
    static AudioStreamBegin ReadFromTeleport(ReadOnlySpan<byte> data)
    static AudioStreamBegin ReadFromTeleport(ReadOnlySpan<byte> data, AudioStreamBegin destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AudioStreamEnd : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static AudioStreamEnd ReadFromTeleport(ReadOnlySpan<byte> data)
    static AudioStreamEnd ReadFromTeleport(ReadOnlySpan<byte> data, AudioStreamEnd destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class GlobalState.AudioStreamState
    ctor()
    ctor(string streamId, int clientSessionId, int trackId, AudioStreamBegin info)
    int ClientSessionId { get;  set; }
    AudioStreamBegin Info { get;  set; }
    string StreamId { get;  set; }
    int TrackId { get;  set; }
    static GlobalState.AudioStreamState ReadFromTeleport(ReadOnlySpan<byte> data)
    static GlobalState.AudioStreamState ReadFromTeleport(ReadOnlySpan<byte> data, GlobalState.AudioStreamState destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AuthResponse : IProtocolMessagePayload
    ctor()
    ctor(Context clientContext, Context serverContext, string certHash, List<Entrypoint> entrypoints, Dictionary<string, bool> featureFlags, string spaceId, string channelId, string channelInstanceId, string primaryUserId, string serverSessionId)
    string CertHash { get;  set; }
    string ChannelId { get;  set; }
    string ChannelInstanceId { get;  set; }
    Context ClientContext { get;  set; }
    List<Entrypoint> Entrypoints { get;  set; }
    Dictionary<string, bool> FeatureFlags { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string PrimaryUserId { get;  set; }
    Context ServerContext { get;  set; }
    string ServerSessionId { get;  set; }
    string SpaceId { get;  set; }
    static AuthResponse ReadFromTeleport(ReadOnlySpan<byte> data)
    static AuthResponse ReadFromTeleport(ReadOnlySpan<byte> data, AuthResponse destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class AuthTicket : IProtocolMessagePayload
    ctor()
    ctor(string host, int httpsPort, int tcpPort, string secret, Opcode opcodeGroupsFromServer, Opcode opcodeGroupsToServer, Context clientContext, int tlsPort)
    Context ClientContext { get;  set; }
    string Host { get;  set; }
    int HttpsPort { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    Opcode OpcodeGroupsFromServer { get;  set; }
    Opcode OpcodeGroupsToServer { get;  set; }
    string Secret { get;  set; }
    int TcpPort { get;  set; }
    int TlsPort { get;  set; }
    static AuthTicket ReadFromTeleport(ReadOnlySpan<byte> data)
    static AuthTicket ReadFromTeleport(ReadOnlySpan<byte> data, AuthTicket destination)
    override string ToString()
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class BackgroundWorkActive : IProtocolMessagePayload
    ctor()
    ctor(bool isActive)
    bool IsActive { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static BackgroundWorkActive ReadFromTeleport(ReadOnlySpan<byte> data)
    static BackgroundWorkActive ReadFromTeleport(ReadOnlySpan<byte> data, BackgroundWorkActive destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ClientReady : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ClientReady ReadFromTeleport(ReadOnlySpan<byte> data)
    static ClientReady ReadFromTeleport(ReadOnlySpan<byte> data, ClientReady destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum ClientType
    Unknown
    MobileWeb
    MobileApp
    DesktopWeb
    DesktopApp
  sealed class ConnectToken : IProtocolMessagePayload
    ctor()
    ctor(string serverSessionId, ContextType contextType, UserType userType, PayloadType payloadType, bool isInternal, string description, string userId, string deviceId, string productId, string versionId, string installId, string locale, Opcode opcodeGroupsFromServer, Opcode opcodeGroupsToServer, int protocolVersion, bool hasInput, string channelLocale, string embeddedSpaceId, string authSessionId, bool receiveAllMessages, string userAgent, ClientType clientType, Dictionary<string, string> parameters, SdkType sdkType, int viewportWidth, int viewportHeight, string theme, string timezone, bool isTouchDevice, string initialPath)
    string AuthSessionId { get;  set; }
    string ChannelLocale { get;  set; }
    ClientType ClientType { get;  set; }
    ContextType ContextType { get;  set; }
    string Description { get;  set; }
    string DeviceId { get;  set; }
    string EmbeddedSpaceId { get;  set; }
    bool HasInput { get;  set; }
    string InitialPath { get;  set; }
    string InstallId { get;  set; }
    bool IsInternal { get;  set; }
    bool IsTouchDevice { get;  set; }
    string Locale { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    Opcode OpcodeGroupsFromServer { get;  set; }
    Opcode OpcodeGroupsToServer { get;  set; }
    Dictionary<string, string> Parameters { get;  set; }
    PayloadType PayloadType { get;  set; }
    string ProductId { get;  set; }
    int ProtocolVersion { get;  set; }
    bool ReceiveAllMessages { get;  set; }
    SdkType SdkType { get;  set; }
    string ServerSessionId { get;  set; }
    string Theme { get;  set; }
    string Timezone { get;  set; }
    string UserAgent { get;  set; }
    string UserId { get;  set; }
    UserType UserType { get;  set; }
    string VersionId { get;  set; }
    int ViewportHeight { get;  set; }
    int ViewportWidth { get;  set; }
    static ConnectToken ReadFromTeleport(ReadOnlySpan<byte> data)
    static ConnectToken ReadFromTeleport(ReadOnlySpan<byte> data, ConnectToken destination)
    override string ToString()
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class Context : IProtocolMessagePayload
    ctor()
    ctor(ContextType contextType, UserType userType, PayloadType payloadType, string description, string userId, string deviceId, string productId, string versionId, string installId, string locale, int sessionId, bool isInternal, bool isReady, bool hasInput, string channelLocale, string embeddedSpaceId, string authSessionId, bool receiveAllMessages, ulong preciseJoinedAt, string userAgent, ClientType clientType, string uniqueSessionId, Dictionary<string, string> parameters, SdkType sdkType, int viewportWidth, int viewportHeight, string theme, string timezone, bool isTouchDevice, string initialPath)
    string AuthSessionId { get;  set; }
    string ChannelLocale { get;  set; }
    ClientType ClientType { get;  set; }
    ContextType ContextType { get;  set; }
    string Description { get;  set; }
    string DeviceId { get;  set; }
    string EmbeddedSpaceId { get;  set; }
    bool HasInput { get;  set; }
    string InitialPath { get;  set; }
    string InstallId { get;  set; }
    bool IsInternal { get;  set; }
    bool IsReady { get;  set; }
    bool IsTouchDevice { get;  set; }
    string Locale { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    Dictionary<string, string> Parameters { get;  set; }
    PayloadType PayloadType { get;  set; }
    ulong PreciseJoinedAt { get;  set; }
    string ProductId { get;  set; }
    bool ReceiveAllMessages { get;  set; }
    SdkType SdkType { get;  set; }
    int SessionId { get;  set; }
    string Theme { get;  set; }
    string Timezone { get;  set; }
    string UniqueSessionId { get;  set; }
    string UserAgent { get;  set; }
    string UserId { get;  set; }
    UserType UserType { get;  set; }
    string VersionId { get;  set; }
    int ViewportHeight { get;  set; }
    int ViewportWidth { get;  set; }
    static Context ReadFromTeleport(ReadOnlySpan<byte> data)
    static Context ReadFromTeleport(ReadOnlySpan<byte> data, Context destination)
    override string ToString()
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum ContextType
    Unknown
    Backend
    Server
    Plugin
    Browser
  sealed class Coordinate2D : IProtocolMessagePayload
    ctor()
    ctor(float x, float y)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    float X { get;  set; }
    float Y { get;  set; }
    static Coordinate2D ReadFromTeleport(ReadOnlySpan<byte> data)
    static Coordinate2D ReadFromTeleport(ReadOnlySpan<byte> data, Coordinate2D destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class DynamicConfig : IProtocolMessagePayload
    ctor()
    ctor(string configJsonContent)
    string ConfigJsonContent { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static DynamicConfig ReadFromTeleport(ReadOnlySpan<byte> data)
    static DynamicConfig ReadFromTeleport(ReadOnlySpan<byte> data, DynamicConfig destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class Entrypoint : IProtocolMessagePayload
    ctor()
    ctor(EntrypointType type, string uri, Opcode opcodeGroupsFromServer, Opcode opcodeGroupsToServer, int priority, string description, byte[] authTicket, bool isUnreliable)
    byte[] AuthTicket { get;  set; }
    string Description { get;  set; }
    bool IsUnreliable { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    Opcode OpcodeGroupsFromServer { get;  set; }
    Opcode OpcodeGroupsToServer { get;  set; }
    int Priority { get;  set; }
    EntrypointType Type { get;  set; }
    string Uri { get;  set; }
    static Entrypoint ReadFromTeleport(ReadOnlySpan<byte> data)
    static Entrypoint ReadFromTeleport(ReadOnlySpan<byte> data, Entrypoint destination)
    override string ToString()
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum EntrypointType
    None
    WebSocket
    WebSocketProxy
    WebTransport
    WebTransportProxy
    Tcp
    TcpProxy
    Https
    WebRTC
    TcpTls
  sealed class EventsOnChannelComplete : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static EventsOnChannelComplete ReadFromTeleport(ReadOnlySpan<byte> data)
    static EventsOnChannelComplete ReadFromTeleport(ReadOnlySpan<byte> data, EventsOnChannelComplete destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class EventsOnProfileUpdate : IProtocolMessagePayload
    ctor()
    ctor(string userId, string valuesAsJson)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string UserId { get;  set; }
    string ValuesAsJson { get;  set; }
    static EventsOnProfileUpdate ReadFromTeleport(ReadOnlySpan<byte> data)
    static EventsOnProfileUpdate ReadFromTeleport(ReadOnlySpan<byte> data, EventsOnProfileUpdate destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class EventsSpeechPlaybackCompleted : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static EventsSpeechPlaybackCompleted ReadFromTeleport(ReadOnlySpan<byte> data)
    static EventsSpeechPlaybackCompleted ReadFromTeleport(ReadOnlySpan<byte> data, EventsSpeechPlaybackCompleted destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class FunctionParameter : IProtocolMessagePayload
    ctor()
    ctor(int parameterIndex, string typeName, string valueJson, byte[] valueData, bool isEnumerable, string enumerableItemTypeName, Guid enumerationId)
    string EnumerableItemTypeName { get;  set; }
    Guid EnumerationId { get;  set; }
    bool IsEnumerable { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    int ParameterIndex { get;  set; }
    string TypeName { get;  set; }
    byte[] ValueData { get;  set; }
    string ValueJson { get;  set; }
    static FunctionParameter ReadFromTeleport(ReadOnlySpan<byte> data)
    static FunctionParameter ReadFromTeleport(ReadOnlySpan<byte> data, FunctionParameter destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionRegister.FunctionRegisterParameter
    ctor()
    ctor(int parameterIndex, string parameterName, string typeName, bool hasDefaultValue, string defaultValueJson, byte[] defaultValueData, bool isEnumerable, string enumerableItemTypeName, string description)
    byte[] DefaultValueData { get;  set; }
    string DefaultValueJson { get;  set; }
    string Description { get;  set; }
    string EnumerableItemTypeName { get;  set; }
    bool HasDefaultValue { get;  set; }
    bool IsEnumerable { get;  set; }
    int ParameterIndex { get;  set; }
    string ParameterName { get;  set; }
    string TypeName { get;  set; }
    static ActionFunctionRegister.FunctionRegisterParameter ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionRegister.FunctionRegisterParameter ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionRegister.FunctionRegisterParameter destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class GlobalState : ILogInfo, IProtocolMessagePayload
    ctor()
    ctor(Dictionary<int, Context> clients, Dictionary<int, List<ActionFunctionRegister>> functions, Dictionary<string, GlobalState.UIStreamState> uiStreams, Dictionary<string, GlobalState.AudioStreamState> audioStreams, Dictionary<string, GlobalState.VideoStreamState> videoStreams, Dictionary<string, GlobalState.TrackingStreamState> trackingStreams, string spaceId, string channelId, string sessionId, string channelUrl, string sessionChannelUrl, string firstUserId, string primaryUserId, string organisationName, string spaceName, string channelName, ServerRunType serverRunType, AppSourceType appSourceType, bool publicAccess, bool debugMode)
    AppSourceType AppSourceType { get;  set; }
    Dictionary<string, GlobalState.AudioStreamState> AudioStreams { get;  set; }
    string ChannelId { get;  set; }
    string ChannelName { get;  set; }
    string ChannelUrl { get;  set; }
    Dictionary<int, Context> Clients { get;  set; }
    bool DebugMode { get;  set; }
    string FirstUserId { get;  set; }
    Dictionary<int, List<ActionFunctionRegister>> Functions { get;  set; }
    object LogInfo { get; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string OrganisationName { get;  set; }
    string PrimaryUserId { get;  set; }
    bool PublicAccess { get;  set; }
    ServerRunType ServerRunType { get;  set; }
    string SessionChannelUrl { get;  set; }
    string SessionId { get;  set; }
    string SpaceId { get;  set; }
    string SpaceName { get;  set; }
    Dictionary<string, GlobalState.TrackingStreamState> TrackingStreams { get;  set; }
    Dictionary<string, GlobalState.UIStreamState> UIStreams { get;  set; }
    Dictionary<string, GlobalState.VideoStreamState> VideoStreams { get;  set; }
    void AddAudioStream(GlobalState.AudioStreamState audioStreamState)
    void AddClient(Context clientContext)
    void AddFunction(int clientSessionId, ActionFunctionRegister function)
    void AddTrackingStream(GlobalState.TrackingStreamState trackingStreamState)
    void AddUIStream(GlobalState.UIStreamState uiStreamState)
    void AddVideoStream(GlobalState.VideoStreamState videoStreamState)
    Context GetClientContext(int clientSessionId)
    Context GetClientContext(string userId)
    int GetClientSessionId(string userId)
    int[] GetClientSessionIds()
    int[] GetClientSessionIdsByProductId(string productId)
    int[] GetClientSessionIdsExcept(int[] clientSessionIds)
    int[] GetHumanClientSessionIds()
    int[] GetMachineClientSessionIds()
    List<string> GetUserIds(IEnumerable<int> targetIds)
    static GlobalState ReadFromTeleport(ReadOnlySpan<byte> data)
    static GlobalState ReadFromTeleport(ReadOnlySpan<byte> data, GlobalState destination)
    void RemoveAudioStream(string streamId)
    void RemoveClient(int clientSessionId)
    void RemoveFunction(Guid functionId)
    void RemoveTrackingStream(string streamId)
    void RemoveUIStream(string streamId)
    void RemoveVideoStream(string streamId)
    void SetReady(int clientSessionId)
    override string ToString()
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  interface IProtocolMessagePayload
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
  interface IUIContainerElement
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    string StyleId { get;  set; }
  sealed class InvalidateVideoFrame : IProtocolMessagePayload
    ctor()
    ctor(ulong frameNumber, ulong timeStampInUs)
    ulong FrameNumber { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    ulong TimeStampInUs { get;  set; }
    static InvalidateVideoFrame ReadFromTeleport(ReadOnlySpan<byte> data)
    static InvalidateVideoFrame ReadFromTeleport(ReadOnlySpan<byte> data, InvalidateVideoFrame destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class KeepaliveRequest : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static KeepaliveRequest ReadFromTeleport(ReadOnlySpan<byte> data)
    static KeepaliveRequest ReadFromTeleport(ReadOnlySpan<byte> data, KeepaliveRequest destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class KeepaliveResponse : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static KeepaliveResponse ReadFromTeleport(ReadOnlySpan<byte> data)
    static KeepaliveResponse ReadFromTeleport(ReadOnlySpan<byte> data, KeepaliveResponse destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum LogType
    None
    Trace
    Debug
    Info
    Warning
    Error
    Critical
    Event
    Usage
    Exception
  enum MessageFlag
    None
    SendBackToSender
    Delayable
    SendToUser
    Compressed
    Unreliable
  sealed class OnClientJoined : IProtocolMessagePayload
    ctor()
    ctor(Context clientContext)
    Context ClientContext { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static OnClientJoined ReadFromTeleport(ReadOnlySpan<byte> data)
    static OnClientJoined ReadFromTeleport(ReadOnlySpan<byte> data, OnClientJoined destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class OnClientLeft : IProtocolMessagePayload
    ctor()
    ctor(Context clientContext)
    Context ClientContext { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static OnClientLeft ReadFromTeleport(ReadOnlySpan<byte> data)
    static OnClientLeft ReadFromTeleport(ReadOnlySpan<byte> data, OnClientLeft destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class OnClientReady : IProtocolMessagePayload
    ctor()
    ctor(Context clientContext)
    Context ClientContext { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static OnClientReady ReadFromTeleport(ReadOnlySpan<byte> data)
    static OnClientReady ReadFromTeleport(ReadOnlySpan<byte> data, OnClientReady destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class OnHostedServerExit : IProtocolMessagePayload
    ctor()
    ctor(string serverSessionId, bool wasSuccessful)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string ServerSessionId { get;  set; }
    bool WasSuccessful { get;  set; }
    static OnHostedServerExit ReadFromTeleport(ReadOnlySpan<byte> data)
    static OnHostedServerExit ReadFromTeleport(ReadOnlySpan<byte> data, OnHostedServerExit destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class OnPluginReloaded : IProtocolMessagePayload
    ctor()
    ctor(Context serverContext, string pluginName)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string PluginName { get;  set; }
    Context ServerContext { get;  set; }
    static OnPluginReloaded ReadFromTeleport(ReadOnlySpan<byte> data)
    static OnPluginReloaded ReadFromTeleport(ReadOnlySpan<byte> data, OnPluginReloaded destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class OnServerStarted : IProtocolMessagePayload
    ctor()
    ctor(Context serverContext)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    Context ServerContext { get;  set; }
    static OnServerStarted ReadFromTeleport(ReadOnlySpan<byte> data)
    static OnServerStarted ReadFromTeleport(ReadOnlySpan<byte> data, OnServerStarted destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class OnServerStatusPing : IProtocolMessagePayload
    ctor()
    ctor(Context serverContext, ServerStatus status, int userCount, int clientCount, int humanClientCount, int idleTimeInSeconds, float sentMessagesPerSecond, float sentMessagesBandwidth, int sentMessagesCount, float receivedMessagesPerSecond, float receivedMessagesBandwidth, int receivedMessagesCount, float processCpuUsage, float processMemoryUsedMb, float managedMemoryUsedMb, string memoryInfo, bool isDoingBackgroundWork)
    int ClientCount { get;  set; }
    int HumanClientCount { get;  set; }
    int IdleTimeInSeconds { get;  set; }
    bool IsDoingBackgroundWork { get;  set; }
    float ManagedMemoryUsedMb { get;  set; }
    string MemoryInfo { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    float ProcessCpuUsage { get;  set; }
    float ProcessMemoryUsedMb { get;  set; }
    float ReceivedMessagesBandwidth { get;  set; }
    int ReceivedMessagesCount { get;  set; }
    float ReceivedMessagesPerSecond { get;  set; }
    float SentMessagesBandwidth { get;  set; }
    int SentMessagesCount { get;  set; }
    float SentMessagesPerSecond { get;  set; }
    Context ServerContext { get;  set; }
    ServerStatus Status { get;  set; }
    int UserCount { get;  set; }
    static OnServerStatusPing ReadFromTeleport(ReadOnlySpan<byte> data)
    static OnServerStatusPing ReadFromTeleport(ReadOnlySpan<byte> data, OnServerStatusPing destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class OnServerStopped : IProtocolMessagePayload
    ctor()
    ctor(Context serverContext)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    Context ServerContext { get;  set; }
    static OnServerStopped ReadFromTeleport(ReadOnlySpan<byte> data)
    static OnServerStopped ReadFromTeleport(ReadOnlySpan<byte> data, OnServerStopped destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class OnServerStopping : IProtocolMessagePayload
    ctor()
    ctor(Context serverContext)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    Context ServerContext { get;  set; }
    static OnServerStopping ReadFromTeleport(ReadOnlySpan<byte> data)
    static OnServerStopping ReadFromTeleport(ReadOnlySpan<byte> data, OnServerStopping destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class OnUserJoined : IProtocolMessagePayload
    ctor()
    ctor(Context clientContext)
    Context ClientContext { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static OnUserJoined ReadFromTeleport(ReadOnlySpan<byte> data)
    static OnUserJoined ReadFromTeleport(ReadOnlySpan<byte> data, OnUserJoined destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class OnUserLeft : IProtocolMessagePayload
    ctor()
    ctor(Context clientContext)
    Context ClientContext { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static OnUserLeft ReadFromTeleport(ReadOnlySpan<byte> data)
    static OnUserLeft ReadFromTeleport(ReadOnlySpan<byte> data, OnUserLeft destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum Opcode
    NONE
    CONSTANT_GROUP_BITS
    CONSTANT_GROUP_OFFSET
    GROUP_CORE
    CORE_AUTH_RESPONSE
    CORE_AUTH_TICKET
    CORE_GLOBAL_STATE
    CORE_ON_SERVER_STATUS_PING
    CORE_ON_USER_JOINED
    CORE_ON_USER_LEFT
    CORE_ON_CLIENT_JOINED
    CORE_ON_CLIENT_LEFT
    CORE_ON_SERVER_STARTED
    CORE_ON_SERVER_STOPPED
    CORE_ON_SERVER_STOPPING
    CORE_ON_CLIENT_READY
    CORE_CLIENT_READY
    CORE_SERVER_INIT
    CORE_ON_PLUGIN_RELOADED
    CORE_SERVER_START
    CORE_SERVER_STOP
    CORE_ON_HOSTED_SERVER_EXIT
    CORE_DYNAMIC_CONFIG
    CORE_PROXY_RPC_AUTH_TICKET
    CORE_SERVER_INIT2
    CORE_UPDATE_CLIENT_CONTEXT
    CORE_BACKGROUND_WORK_ACTIVE
    CORE_WEBRTC_OFFER
    CORE_WEBRTC_ANSWER
    CORE_WEBRTC_ICE_CANDIDATE
    CORE_WEBRTC_READY
    CORE_WEBRTC_AUDIO_SEGMENT
    CORE_WEBRTC_TRACK_MAP
    GROUP_KEEPALIVE
    KEEPALIVE_REQUEST
    KEEPALIVE_RESPONSE
    GROUP_EVENTS
    EVENTS_PROFILE_UPDATE
    EVENTS_CHANNEL_COMPLETE
    EVENTS_SPEECH_PLAYBACK_COMPLETE
    GROUP_ANALYTICS
    ANALYTICS_LOGS
    ANALYTICS_EVENTS
    ANALYTICS_USAGES
    ANALYTICS_USAGE
    ANALYTICS_SPECIAL_LOG
    ANALYTICS_PROCESSING_UPDATE
    ANALYTICS_REACTIVE_PROCESSING_UPDATE
    ANALYTICS_IKON_PROXY_SERVER_STATS
    GROUP_ACTIONS
    ACTION_CALL
    ACTION_ACTIVE
    ACTION_TEXT_OUTPUT
    ACTION_TEXT_OUTPUT_DELTA
    ACTION_TEXT_OUTPUT_DELTA_FULL
    ACTION_SET_STATE
    ACTION_TAP
    ACTION_PAN
    ACTION_ZOOM
    ACTION_FILE_UPLOAD_BEGIN
    ACTION_FILE_UPLOAD_DATA
    ACTION_FILE_UPLOAD_ACK
    ACTION_FILE_UPLOAD_END
    ACTION_FILE_UPLOAD_RESULT
    ACTION_OPEN_CHANNEL
    ACTION_OPEN_EXTERNAL_URL
    ACTION_UI_OPEN_VIEW
    ACTION_UI_CLOSE_VIEW
    ACTION_UI_BLOCKING_BEGIN
    ACTION_UI_BLOCKING_END
    ACTION_UI_UPDATE_TEXT_DELTA
    ACTION_UI_DELETE_CONTAINER
    ACTION_UPDATE_GFX_SHADER
    ACTION_FUNCTION_REGISTER
    ACTION_FUNCTION_CALL
    ACTION_FUNCTION_RESULT
    ACTION_GENERATE_ANSWER
    ACTION_REGENERATE_ANSWER
    ACTION_CLEAR_CHAT_MESSAGE_HISTORY
    ACTION_CLEAR_STATE
    ACTION_RELOAD_CHANNELS
    ACTION_RELOAD_PROFILE
    ACTION_CLASSIFICATION_RESULT
    ACTION_AUDIO_STOP
    ACTION_CALL_TEXT
    ACTION_RELOAD_APPLICATION
    ACTION_CANCEL_GENERATION
    ACTION_UI_SET_CONTAINER_STABLE
    ACTION_SPEECH_RECOGNIZED
    ACTION_CALL_RESULT
    ACTION_RELOAD_PROVIDER
    ACTION_DOWNLOAD
    ACTION_SCROLL_TO_CONTAINER
    ACTION_UI_CLEAR_STREAM
    ACTION_PLAY_SOUND
    ACTION_ENTER_FULLSCREEN
    ACTION_STOP_SOUND
    ACTION_START_RECORDING
    ACTION_STOP_RECORDING
    ACTION_FUNCTION_ENUMERATION_ITEM
    ACTION_FUNCTION_ENUMERATION_END
    ACTION_FUNCTION_CANCEL
    ACTION_FUNCTION_DISPOSE
    ACTION_FUNCTION_ERROR
    ACTION_FUNCTION_ACK
    ACTION_FUNCTION_AWAITING_APPROVAL
    ACTION_FUNCTION_APPROVAL_REQUIRED
    ACTION_FUNCTION_APPROVAL_RESPONSE
    UI_UPDATE_ACK
    ACTION_CALL2
    ACTION_FUNCTION_REGISTER_BATCH
    ACTION_TRIGGER_GIT_PULL
    ACTION_FILE_UPLOAD_CALLBACK
    ACTION_CUSTOM_USER_MESSAGE
    ACTION_URL_CHANGED
    ACTION_FILE_UPLOAD_PRE_START2
    ACTION_FILE_UPLOAD_PRE_START_RESPONSE2
    ACTION_FILE_UPLOAD_START2
    ACTION_FILE_UPLOAD_START_RESPONSE2
    ACTION_FILE_UPLOAD_DATA2
    ACTION_FILE_UPLOAD_ACK2
    ACTION_FILE_UPLOAD_END2
    ACTION_FILE_UPLOAD_COMPLETE2
    ACTION_FUNCTION_ENUMERATION_ITEM_BATCH
    GROUP_UI
    UI_STREAM_BEGIN
    UI_STREAM_END
    UI_CONTAINER_BEGIN
    UI_CONTAINER_END
    UI_SECTION_BEGIN
    UI_SECTION_END
    UI_LIST_BEGIN
    UI_LIST_ITEM
    UI_LIST_END
    UI_TEXT
    UI_HEADER
    UI_SEPARATOR
    UI_BUTTON
    UI_ICON_BUTTON
    UI_IMAGE
    UI_FILE
    UI_BADGE
    UI_CONTENT_LINK
    UI_MAP
    UI_VEGA_CHART
    UI_ICON
    UI_FILE_UPLOAD_SECTION_BEGIN
    UI_FILE_UPLOAD_SECTION_END
    UI_MATERIAL_SYMBOL
    UI_BUTTON_BEGIN
    UI_BUTTON_END
    UI_CONTAINER_DELETE
    UI_INPUT_TEXT
    UI_PROGRESS_BAR
    UI_UPDATE_BEGIN
    UI_UPDATE_END
    UI_AUTOCOMPLETE
    UI_CHECKBOX
    UI_QS
    UI_ELEMENT
    UI_STYLES
    UI_SVG
    UI_UPDATE
    UI_INIT
    UI_STYLES_BATCH
    UI_STYLES_DELETE
    GROUP_COMMON
    GROUP_AUDIO
    AUDIO_STREAM_BEGIN
    AUDIO_STREAM_END
    AUDIO_FRAME
    AUDIO_FRAME_VOLUME
    AUDIO_FRAME2
    GROUP_VIDEO
    VIDEO_STREAM_BEGIN
    VIDEO_STREAM_END
    VIDEO_FRAME
    VIDEO_REQUEST_IDR_FRAME
    VIDEO_INVALIDATE_FRAME
    GROUP_TRACKING
    TRACKING_STREAM_BEGIN
    TRACKING_STREAM_END
    TRACKING_FRAME
    GROUP_SCENE
    SCENE_MESH
    SCENE_ARRAY
    GROUP_ALL
    CONSTANT_GROUP_MASK
  static class Opcodes
    static bool IsOpcodeInAnyGroup(Opcode opcode, Opcode groups)
  static class PayloadCompression
    static ValueTuple<byte[], int> Compress(ReadOnlySpan<byte> data)
    static ValueTuple<byte[], int> Decompress(ReadOnlySpan<byte> compressedData, int estimatedSize = 0)
    static void ReturnBuffer(byte[] buffer)
    static bool ShouldCompress(int payloadSize)
    static int CompressionThreshold
  enum PayloadType
    Unknown
    MessagePack
    MemoryPack
    Json
    Teleport
    All
  class ProtocolMessage : AsyncLocalInstance<ProtocolMessage>
    ctor()
    ctor(Memory<byte> data)
    Memory<byte> Data { get; }
    MessageFlag Flags { get; }
    int Length { get; }
    Opcode Opcode { get; }
    Memory<byte> Payload { get; }
    Span<byte> PayloadSpan { get; }
    PayloadType PayloadType { get; }
    int PayloadVersion { get; }
    int SenderId { get; }
    int SequenceId { get; }
    string StreamId { get; }
    int TargetIdCount { get; }
    int[] TargetIds { get; }
    ReadOnlySpan<int> TargetIdsSpan { get; }
    int TrackId { get; }
    static ProtocolMessage Create(int senderId, IProtocolMessagePayload payload, PayloadType payloadType = Unknown, int trackId = 0, int sequenceId = 0, MessageFlag flags = None, IReadOnlyList<int> targetIds = null, bool compress = false)
    T GetPayload<T>()
    IProtocolMessagePayload GetPayload()
    static ProtocolMessage ModifyMessage(ProtocolMessage message, int? senderId = null, int? trackId = null, int? sequenceId = null, MessageFlag? flags = null, IReadOnlyList<int> targetIds = null)
    static ProtocolMessage ModifyPayload(IProtocolMessagePayload payload, ProtocolMessage message, PayloadType payloadType = Unknown)
    override string ToString()
    PayloadType DefaultPayloadType
    static int MaxMessageSize
    static int MinimumHeaderLength
    static Dictionary<Opcode, Type> OpcodeToType
    static Dictionary<Type, Opcode> TypeToOpcode
    static Dictionary<Type, int> TypeToVersion
  class ProtocolMessageAttribute : Attribute
    ctor(int version = 0, Opcode opcode = NONE)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
  static class ProtocolVersion
    static int Version { get; }
  sealed class ProxyRpcAuthTicket : IProtocolMessagePayload
    ctor()
    ctor(string proxyServerToken, string clientIkonBackendToken)
    string ClientIkonBackendToken { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string ProxyServerToken { get;  set; }
    static ProxyRpcAuthTicket ReadFromTeleport(ReadOnlySpan<byte> data)
    static ProxyRpcAuthTicket ReadFromTeleport(ReadOnlySpan<byte> data, ProxyRpcAuthTicket destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class RequestIdrVideoFrame : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static RequestIdrVideoFrame ReadFromTeleport(ReadOnlySpan<byte> data)
    static RequestIdrVideoFrame ReadFromTeleport(ReadOnlySpan<byte> data, RequestIdrVideoFrame destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class SceneArray : IProtocolMessagePayload
    ctor()
    ctor(int serializerType, string type, string subId, int elementOffset, int elementCount, int byteOffset, int typeSize, int strideSize, byte[] byteArray)
    byte[] ByteArray { get;  set; }
    int ByteOffset { get;  set; }
    int ElementCount { get;  set; }
    int ElementOffset { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    int SerializerType { get;  set; }
    int StrideSize { get;  set; }
    string SubId { get;  set; }
    string Type { get;  set; }
    int TypeSize { get;  set; }
    static SceneArray ReadFromTeleport(ReadOnlySpan<byte> data)
    static SceneArray ReadFromTeleport(ReadOnlySpan<byte> data, SceneArray destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class SceneMesh : IProtocolMessagePayload
    ctor()
    ctor(List<float> vertices)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    List<float> Vertices { get;  set; }
    static SceneMesh ReadFromTeleport(ReadOnlySpan<byte> data)
    static SceneMesh ReadFromTeleport(ReadOnlySpan<byte> data, SceneMesh destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ActionFunctionCall.ScopeEntry
    ctor()
    ctor(string type, string id)
    string Id { get;  set; }
    string Type { get;  set; }
    static ActionFunctionCall.ScopeEntry ReadFromTeleport(ReadOnlySpan<byte> data)
    static ActionFunctionCall.ScopeEntry ReadFromTeleport(ReadOnlySpan<byte> data, ActionFunctionCall.ScopeEntry destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum SdkType
    Unknown
    DotNet
    TypeScript
    Cpp
  sealed class ServerInit.ServerExtensionInit
    ctor()
    ctor(bool enabled, string typeName, string configJsonContent)
    string ConfigJsonContent { get;  set; }
    bool Enabled { get;  set; }
    string TypeName { get;  set; }
    static ServerInit.ServerExtensionInit ReadFromTeleport(ReadOnlySpan<byte> data)
    static ServerInit.ServerExtensionInit ReadFromTeleport(ReadOnlySpan<byte> data, ServerInit.ServerExtensionInit destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ServerInit : IProtocolMessagePayload
    ctor()
    ctor(string ikonBackendUrl, string ikonBackendToken, string spaceId, string channelId, List<ServerInit.ServerPluginInit> plugins, string primaryUserId, string channelInstanceId, string channelUrl, List<ServerInit.ServerExtensionInit> extensions, Dictionary<string, string> dynamicConfigObsolete, string organisationName, string spaceName, string channelName, string dynamicConfigJsonContent, string spaceGitRepositoryUrl, string sessionId, string legacyChannelCode, bool disableLegacyDefaultExtensions, Dictionary<string, string> sessionIdentity, List<ServerInit.ServerInitEndpointRequest> endpointRequests, int frontendPort, AppSourceType appSourceType, bool debugMode, List<ServerInit.ServerInitDatabaseConnectionInfo> databaseConnectionInfos)
    AppSourceType AppSourceType { get;  set; }
    string ChannelId { get;  set; }
    string ChannelInstanceId { get;  set; }
    string ChannelName { get;  set; }
    string ChannelUrl { get;  set; }
    List<ServerInit.ServerInitDatabaseConnectionInfo> DatabaseConnectionInfos { get;  set; }
    bool DebugMode { get;  set; }
    bool DisableLegacyDefaultExtensions { get;  set; }
    string DynamicConfigJsonContent { get;  set; }
    Dictionary<string, string> DynamicConfigObsolete { get;  set; }
    List<ServerInit.ServerInitEndpointRequest> EndpointRequests { get;  set; }
    List<ServerInit.ServerExtensionInit> Extensions { get;  set; }
    int FrontendPort { get;  set; }
    string IkonBackendToken { get;  set; }
    string IkonBackendUrl { get;  set; }
    string LegacyChannelCode { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string OrganisationName { get;  set; }
    List<ServerInit.ServerPluginInit> Plugins { get;  set; }
    string PrimaryUserId { get;  set; }
    string SessionId { get;  set; }
    Dictionary<string, string> SessionIdentity { get;  set; }
    string SpaceGitRepositoryUrl { get;  set; }
    string SpaceId { get;  set; }
    string SpaceName { get;  set; }
    static ServerInit ReadFromTeleport(ReadOnlySpan<byte> data)
    static ServerInit ReadFromTeleport(ReadOnlySpan<byte> data, ServerInit destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ServerInit2 : IProtocolMessagePayload
    ctor()
    ctor(string sessionId, Dictionary<string, string> sessionIdentity)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string SessionId { get;  set; }
    Dictionary<string, string> SessionIdentity { get;  set; }
    static ServerInit2 ReadFromTeleport(ReadOnlySpan<byte> data)
    static ServerInit2 ReadFromTeleport(ReadOnlySpan<byte> data, ServerInit2 destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ServerInit.ServerInitDatabaseConnectionInfo
    ctor()
    ctor(string name, string type, string connectionString)
    string ConnectionString { get;  set; }
    string Name { get;  set; }
    string Type { get;  set; }
    static ServerInit.ServerInitDatabaseConnectionInfo ReadFromTeleport(ReadOnlySpan<byte> data)
    static ServerInit.ServerInitDatabaseConnectionInfo ReadFromTeleport(ReadOnlySpan<byte> data, ServerInit.ServerInitDatabaseConnectionInfo destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ServerInit.ServerInitEndpointRequest
    ctor()
    ctor(string descriptor, int localPort)
    string Descriptor { get;  set; }
    int LocalPort { get;  set; }
    static ServerInit.ServerInitEndpointRequest ReadFromTeleport(ReadOnlySpan<byte> data)
    static ServerInit.ServerInitEndpointRequest ReadFromTeleport(ReadOnlySpan<byte> data, ServerInit.ServerInitEndpointRequest destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ServerInit.ServerPluginInit
    ctor()
    ctor(bool enabled, string bundleDirectoryPath, byte[] bundleDirectoryZipContent, string dllName, string typeName, string configFilePath, string configJsonContent, List<ServerInit.ServerPluginInitExtraConfig> extraConfigs)
    string BundleDirectoryPath { get;  set; }
    byte[] BundleDirectoryZipContent { get;  set; }
    string ConfigFilePath { get;  set; }
    string ConfigJsonContent { get;  set; }
    string DllName { get;  set; }
    bool Enabled { get;  set; }
    List<ServerInit.ServerPluginInitExtraConfig> ExtraConfigs { get;  set; }
    string TypeName { get;  set; }
    static ServerInit.ServerPluginInit ReadFromTeleport(ReadOnlySpan<byte> data)
    static ServerInit.ServerPluginInit ReadFromTeleport(ReadOnlySpan<byte> data, ServerInit.ServerPluginInit destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class ServerInit.ServerPluginInitExtraConfig
    ctor()
    ctor(string filePath, string content)
    string Content { get;  set; }
    string FilePath { get;  set; }
    static ServerInit.ServerPluginInitExtraConfig ReadFromTeleport(ReadOnlySpan<byte> data)
    static ServerInit.ServerPluginInitExtraConfig ReadFromTeleport(ReadOnlySpan<byte> data, ServerInit.ServerPluginInitExtraConfig destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum ServerRunType
    Local
    Cloud
  sealed class ServerStart : IProtocolMessagePayload
    ctor()
    ctor(string hostServerSessionId, string configJsonContent)
    string ConfigJsonContent { get;  set; }
    string HostServerSessionId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static ServerStart ReadFromTeleport(ReadOnlySpan<byte> data)
    static ServerStart ReadFromTeleport(ReadOnlySpan<byte> data, ServerStart destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum ServerStatus
    Unknown
    Starting
    Running
    Stopping
    Stopped
  sealed class ServerStop : IProtocolMessagePayload
    ctor()
    ctor(string hostServerSessionId, string targetServerSessionId)
    string HostServerSessionId { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string TargetServerSessionId { get;  set; }
    static ServerStop ReadFromTeleport(ReadOnlySpan<byte> data)
    static ServerStop ReadFromTeleport(ReadOnlySpan<byte> data, ServerStop destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class TrackingFrame : IProtocolMessagePayload
    ctor()
    ctor(ulong timestampInUs, uint durationInUs, List<float> faceBlendshapes, List<float> faceTransformationMatrix)
    uint DurationInUs { get;  set; }
    List<float> FaceBlendshapes { get;  set; }
    List<float> FaceTransformationMatrix { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    ulong TimestampInUs { get;  set; }
    static TrackingFrame ReadFromTeleport(ReadOnlySpan<byte> data)
    static TrackingFrame ReadFromTeleport(ReadOnlySpan<byte> data, TrackingFrame destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class TrackingStreamBegin : IProtocolMessagePayload
    ctor()
    ctor(string category, TrackingType type, List<string> faceBlendshapes)
    string Category { get;  set; }
    List<string> FaceBlendshapes { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    TrackingType Type { get;  set; }
    static TrackingStreamBegin ReadFromTeleport(ReadOnlySpan<byte> data)
    static TrackingStreamBegin ReadFromTeleport(ReadOnlySpan<byte> data, TrackingStreamBegin destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class TrackingStreamEnd : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static TrackingStreamEnd ReadFromTeleport(ReadOnlySpan<byte> data)
    static TrackingStreamEnd ReadFromTeleport(ReadOnlySpan<byte> data, TrackingStreamEnd destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class GlobalState.TrackingStreamState
    ctor()
    ctor(string streamId, int clientSessionId, int trackId, TrackingStreamBegin info)
    int ClientSessionId { get;  set; }
    TrackingStreamBegin Info { get;  set; }
    string StreamId { get;  set; }
    int TrackId { get;  set; }
    static GlobalState.TrackingStreamState ReadFromTeleport(ReadOnlySpan<byte> data)
    static GlobalState.TrackingStreamState ReadFromTeleport(ReadOnlySpan<byte> data, GlobalState.TrackingStreamState destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum TrackingType
    Face
    Hands
    Pose
    All
  sealed class UIAutocomplete : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string name, List<UIAutocomplete.UIAutocompleteOption> options, string updateActionId, int minCount, int maxCount, UIColor color, UIInputVariant variant, List<string> initialValue, string placeholder)
    UIColor Color { get;  set; }
    int ElementId { get;  set; }
    List<string> InitialValue { get;  set; }
    List<string> Labels { get;  set; }
    int MaxCount { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    int MinCount { get;  set; }
    string Name { get;  set; }
    List<UIAutocomplete.UIAutocompleteOption> Options { get;  set; }
    string Placeholder { get;  set; }
    string StyleId { get;  set; }
    string UpdateActionId { get;  set; }
    UIInputVariant Variant { get;  set; }
    static UIAutocomplete ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIAutocomplete ReadFromTeleport(ReadOnlySpan<byte> data, UIAutocomplete destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIAutocomplete.UIAutocompleteOption
    ctor()
    ctor(string name, string value, string group)
    string Group { get;  set; }
    string Name { get;  set; }
    string Value { get;  set; }
    static UIAutocomplete.UIAutocompleteOption ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIAutocomplete.UIAutocompleteOption ReadFromTeleport(ReadOnlySpan<byte> data, UIAutocomplete.UIAutocompleteOption destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIBadge : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string text, UIColor color, string clickActionId, UIBadgeVariant variant, string pressStartActionId, string pressEndActionId, string pressChangeActionId, string pressUpActionId, string dragStartActionId, string dragEnterActionId, string dragLeaveActionId, string dragOverActionId, string dropActionId, string dragEndActionId)
    string ClickActionId { get;  set; }
    UIColor Color { get;  set; }
    string DragEndActionId { get;  set; }
    string DragEnterActionId { get;  set; }
    string DragLeaveActionId { get;  set; }
    string DragOverActionId { get;  set; }
    string DragStartActionId { get;  set; }
    string DropActionId { get;  set; }
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string PressChangeActionId { get;  set; }
    string PressEndActionId { get;  set; }
    string PressStartActionId { get;  set; }
    string PressUpActionId { get;  set; }
    string StyleId { get;  set; }
    string Text { get;  set; }
    UIBadgeVariant Variant { get;  set; }
    static UIBadge ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIBadge ReadFromTeleport(ReadOnlySpan<byte> data, UIBadge destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum UIBadgeVariant
    Filled
    Outlined
  sealed class UIButton : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string text, UIIconType icon, UIColor color, string clickActionId, UIButtonVariant variant, string pressStartActionId, string pressEndActionId, string pressChangeActionId, string pressUpActionId, string dragStartActionId, string dragEnterActionId, string dragLeaveActionId, string dragOverActionId, string dropActionId, string dragEndActionId)
    string ClickActionId { get;  set; }
    UIColor Color { get;  set; }
    string DragEndActionId { get;  set; }
    string DragEnterActionId { get;  set; }
    string DragLeaveActionId { get;  set; }
    string DragOverActionId { get;  set; }
    string DragStartActionId { get;  set; }
    string DropActionId { get;  set; }
    int ElementId { get;  set; }
    UIIconType Icon { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string PressChangeActionId { get;  set; }
    string PressEndActionId { get;  set; }
    string PressStartActionId { get;  set; }
    string PressUpActionId { get;  set; }
    string StyleId { get;  set; }
    string Text { get;  set; }
    UIButtonVariant Variant { get;  set; }
    static UIButton ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIButton ReadFromTeleport(ReadOnlySpan<byte> data, UIButton destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIButtonBegin : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, UIColor color, string clickActionId, UIButtonVariant variant, string pressStartActionId, string pressEndActionId, string pressChangeActionId, string pressUpActionId, string dragStartActionId, string dragEnterActionId, string dragLeaveActionId, string dragOverActionId, string dropActionId, string dragEndActionId)
    string ClickActionId { get;  set; }
    UIColor Color { get;  set; }
    string DragEndActionId { get;  set; }
    string DragEnterActionId { get;  set; }
    string DragLeaveActionId { get;  set; }
    string DragOverActionId { get;  set; }
    string DragStartActionId { get;  set; }
    string DropActionId { get;  set; }
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string PressChangeActionId { get;  set; }
    string PressEndActionId { get;  set; }
    string PressStartActionId { get;  set; }
    string PressUpActionId { get;  set; }
    string StyleId { get;  set; }
    UIButtonVariant Variant { get;  set; }
    static UIButtonBegin ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIButtonBegin ReadFromTeleport(ReadOnlySpan<byte> data, UIButtonBegin destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIButtonEnd : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static UIButtonEnd ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIButtonEnd ReadFromTeleport(ReadOnlySpan<byte> data, UIButtonEnd destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum UIButtonVariant
    Outlined
    Contained
    Text
  sealed class UICheckbox : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string name, string updateActionId, bool selected)
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Name { get;  set; }
    bool Selected { get;  set; }
    string StyleId { get;  set; }
    string UpdateActionId { get;  set; }
    static UICheckbox ReadFromTeleport(ReadOnlySpan<byte> data)
    static UICheckbox ReadFromTeleport(ReadOnlySpan<byte> data, UICheckbox destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum UIColor
    Default
    Primary
    Secondary
    Error
    Warning
    Info
    Success
  sealed class UIContainerBegin : IProtocolMessagePayload
    ctor()
    ctor(string containerId, string userId, string createdAt, string updatedAt, string alternativeText, bool isTransient, bool isHistory, bool isUpdate, int groupId, int sortingId, bool isStable, UIVisibilityType visibility, ulong preciseCreatedAt, string optimisticActionId)
    string AlternativeText { get;  set; }
    string ContainerId { get;  set; }
    string CreatedAt { get;  set; }
    int GroupId { get;  set; }
    bool IsHistory { get;  set; }
    bool IsStable { get;  set; }
    bool IsTransient { get;  set; }
    bool IsUpdate { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string OptimisticActionId { get;  set; }
    ulong PreciseCreatedAt { get;  set; }
    int SortingId { get;  set; }
    string UpdatedAt { get;  set; }
    string UserId { get;  set; }
    UIVisibilityType Visibility { get;  set; }
    static UIContainerBegin ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIContainerBegin ReadFromTeleport(ReadOnlySpan<byte> data, UIContainerBegin destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIContainerDelete : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static UIContainerDelete ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIContainerDelete ReadFromTeleport(ReadOnlySpan<byte> data, UIContainerDelete destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIContainerEnd : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static UIContainerEnd ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIContainerEnd ReadFromTeleport(ReadOnlySpan<byte> data, UIContainerEnd destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIContentLink : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, UIContentLinkType type, string code)
    string Code { get;  set; }
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string StyleId { get;  set; }
    UIContentLinkType Type { get;  set; }
    static UIContentLink ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIContentLink ReadFromTeleport(ReadOnlySpan<byte> data, UIContentLink destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum UIContentLinkType
    Unknown
    Youtube
  sealed class UIElement : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string name, string description, string argumentsJson, Dictionary<string, Action> actionIds, Dictionary<string, UIPayload> payloads)
    Dictionary<string, Action> ActionIds { get;  set; }
    string ArgumentsJson { get;  set; }
    string Description { get;  set; }
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Name { get;  set; }
    Dictionary<string, UIPayload> Payloads { get;  set; }
    string StyleId { get;  set; }
    static UIElement ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIElement ReadFromTeleport(ReadOnlySpan<byte> data, UIElement destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  static class UIElementLabels
    static string Blur
    static string ChatMessage
    static string Disabled
    static string ImageAvatar
    static string Markdown
    static string SizeExtraSmall
    static string SizeFitContent
    static string SizeFullWidth
    static string SizeLarge
    static string SizeMedium
    static string SizeSmall
    static string Wrap
  sealed class UIFile : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string name, string secondaryText, string type, string mime, List<string> allowedMimeTypes, int maxSize, UIFile.UIFileInfo fileInfo, string openActionId, string uploadActionId, string removeActionId)
    List<string> AllowedMimeTypes { get;  set; }
    int ElementId { get;  set; }
    UIFile.UIFileInfo FileInfo { get;  set; }
    List<string> Labels { get;  set; }
    int MaxSize { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Mime { get;  set; }
    string Name { get;  set; }
    string OpenActionId { get;  set; }
    string RemoveActionId { get;  set; }
    string SecondaryText { get;  set; }
    string StyleId { get;  set; }
    string Type { get;  set; }
    string UploadActionId { get;  set; }
    static UIFile ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIFile ReadFromTeleport(ReadOnlySpan<byte> data, UIFile destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIFile.UIFileInfo
    ctor()
    ctor(string id, string name, string fileName, string createdAt, int size, string url)
    string CreatedAt { get;  set; }
    string FileName { get;  set; }
    string Id { get;  set; }
    string Name { get;  set; }
    int Size { get;  set; }
    string Url { get;  set; }
    static UIFile.UIFileInfo ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIFile.UIFileInfo ReadFromTeleport(ReadOnlySpan<byte> data, UIFile.UIFileInfo destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIFileUploadSectionBegin : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, int gap, string uploadActionId, List<string> allowedMimeTypes, int maxSize)
    List<string> AllowedMimeTypes { get;  set; }
    int ElementId { get;  set; }
    int Gap { get;  set; }
    List<string> Labels { get;  set; }
    int MaxSize { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string StyleId { get;  set; }
    string UploadActionId { get;  set; }
    static UIFileUploadSectionBegin ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIFileUploadSectionBegin ReadFromTeleport(ReadOnlySpan<byte> data, UIFileUploadSectionBegin destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIFileUploadSectionEnd : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static UIFileUploadSectionEnd ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIFileUploadSectionEnd ReadFromTeleport(ReadOnlySpan<byte> data, UIFileUploadSectionEnd destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIHeader : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string text, string subText, UIHeaderLevel level)
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    UIHeaderLevel Level { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string StyleId { get;  set; }
    string SubText { get;  set; }
    string Text { get;  set; }
    static UIHeader ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIHeader ReadFromTeleport(ReadOnlySpan<byte> data, UIHeader destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum UIHeaderLevel
    Default
    Large
    Medium
    Normal
    Small
  sealed class UIIcon : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, UIIconType icon, UIColor color)
    UIColor Color { get;  set; }
    int ElementId { get;  set; }
    UIIconType Icon { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string StyleId { get;  set; }
    static UIIcon ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIIcon ReadFromTeleport(ReadOnlySpan<byte> data, UIIcon destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIIconButton : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, UIIconType icon, UIColor color, string clickActionId, string pressStartActionId, string pressEndActionId, string pressChangeActionId, string pressUpActionId, string dragStartActionId, string dragEnterActionId, string dragLeaveActionId, string dragOverActionId, string dropActionId, string dragEndActionId)
    string ClickActionId { get;  set; }
    UIColor Color { get;  set; }
    string DragEndActionId { get;  set; }
    string DragEnterActionId { get;  set; }
    string DragLeaveActionId { get;  set; }
    string DragOverActionId { get;  set; }
    string DragStartActionId { get;  set; }
    string DropActionId { get;  set; }
    int ElementId { get;  set; }
    UIIconType Icon { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string PressChangeActionId { get;  set; }
    string PressEndActionId { get;  set; }
    string PressStartActionId { get;  set; }
    string PressUpActionId { get;  set; }
    string StyleId { get;  set; }
    static UIIconButton ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIIconButton ReadFromTeleport(ReadOnlySpan<byte> data, UIIconButton destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum UIIconType
    None
    Close
    Download
    Delete
    PinDrop
    Favorite
    FavoriteBorder
    AddCircle
    AddCircleOutline
    StarOutline
    Document
    GenderMale
    GenderFemale
    Upload
    GenderOther
  sealed class UIImage : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string name, string url, string mime, byte[] data, string clickActionId, string pressStartActionId, string pressEndActionId, string pressChangeActionId, string pressUpActionId, string dragStartActionId, string dragEnterActionId, string dragLeaveActionId, string dragOverActionId, string dropActionId, string dragEndActionId)
    string ClickActionId { get;  set; }
    byte[] Data { get;  set; }
    string DragEndActionId { get;  set; }
    string DragEnterActionId { get;  set; }
    string DragLeaveActionId { get;  set; }
    string DragOverActionId { get;  set; }
    string DragStartActionId { get;  set; }
    string DropActionId { get;  set; }
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Mime { get;  set; }
    string Name { get;  set; }
    string PressChangeActionId { get;  set; }
    string PressEndActionId { get;  set; }
    string PressStartActionId { get;  set; }
    string PressUpActionId { get;  set; }
    string StyleId { get;  set; }
    string Url { get;  set; }
    static UIImage ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIImage ReadFromTeleport(ReadOnlySpan<byte> data, UIImage destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIInit : IProtocolMessagePayload
    ctor()
    ctor(List<UIInit.UIInitModule> modules)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    List<UIInit.UIInitModule> Modules { get;  set; }
    static UIInit ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIInit ReadFromTeleport(ReadOnlySpan<byte> data, UIInit destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIInit.UIInitModule
    ctor()
    ctor(string name, string javascript)
    string Javascript { get;  set; }
    string Name { get;  set; }
    static UIInit.UIInitModule ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIInit.UIInitModule ReadFromTeleport(ReadOnlySpan<byte> data, UIInit.UIInitModule destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIInputText : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string name, string updateActionId, UIColor color, UIInputVariant variant, int rows, string initialValue, string submitActionId)
    UIColor Color { get;  set; }
    int ElementId { get;  set; }
    string InitialValue { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Name { get;  set; }
    int Rows { get;  set; }
    string StyleId { get;  set; }
    string SubmitActionId { get;  set; }
    string UpdateActionId { get;  set; }
    UIInputVariant Variant { get;  set; }
    static UIInputText ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIInputText ReadFromTeleport(ReadOnlySpan<byte> data, UIInputText destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum UIInputVariant
    Outlined
    Filled
    Standard
  sealed class UIListBegin : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, UIListType type)
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string StyleId { get;  set; }
    UIListType Type { get;  set; }
    static UIListBegin ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIListBegin ReadFromTeleport(ReadOnlySpan<byte> data, UIListBegin destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIListEnd : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static UIListEnd ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIListEnd ReadFromTeleport(ReadOnlySpan<byte> data, UIListEnd destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIListItem : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string name, string text)
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Name { get;  set; }
    string StyleId { get;  set; }
    string Text { get;  set; }
    static UIListItem ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIListItem ReadFromTeleport(ReadOnlySpan<byte> data, UIListItem destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum UIListType
    Default
    Unordered
    Ordered
    Definition
  sealed class UIMap : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string name, UIMap.UIMapMarker marker, List<UIMap.UIMapMarker> markers)
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    UIMap.UIMapMarker Marker { get;  set; }
    List<UIMap.UIMapMarker> Markers { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Name { get;  set; }
    string StyleId { get;  set; }
    static UIMap ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIMap ReadFromTeleport(ReadOnlySpan<byte> data, UIMap destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIMap.UIMapMarker
    ctor()
    ctor(string title, float latitude, float longitude)
    float Latitude { get;  set; }
    float Longitude { get;  set; }
    string Title { get;  set; }
    static UIMap.UIMapMarker ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIMap.UIMapMarker ReadFromTeleport(ReadOnlySpan<byte> data, UIMap.UIMapMarker destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIMaterialSymbol : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string name, UIColor color, UIMaterialSymbolVariant variant)
    UIColor Color { get;  set; }
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Name { get;  set; }
    string StyleId { get;  set; }
    UIMaterialSymbolVariant Variant { get;  set; }
    static UIMaterialSymbol ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIMaterialSymbol ReadFromTeleport(ReadOnlySpan<byte> data, UIMaterialSymbol destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum UIMaterialSymbolVariant
    Default
    Filled
  sealed class UIPayload : IProtocolMessagePayload
    ctor()
    ctor(string mimeType, byte[] value)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string MimeType { get;  set; }
    byte[] Value { get;  set; }
    static UIPayload ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIPayload ReadFromTeleport(ReadOnlySpan<byte> data, UIPayload destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIProgressBar : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, float percentage)
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    float Percentage { get;  set; }
    string StyleId { get;  set; }
    static UIProgressBar ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIProgressBar ReadFromTeleport(ReadOnlySpan<byte> data, UIProgressBar destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIQS : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string name, string eventActionId, Dictionary<string, string> argumentsJson)
    Dictionary<string, string> ArgumentsJson { get;  set; }
    int ElementId { get;  set; }
    string EventActionId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Name { get;  set; }
    string StyleId { get;  set; }
    static UIQS ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIQS ReadFromTeleport(ReadOnlySpan<byte> data, UIQS destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UISectionBegin : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, UISectionType type, int gap, string clickActionId, string pressStartActionId, string pressEndActionId, string pressChangeActionId, string pressUpActionId, string dragStartActionId, string dragEnterActionId, string dragLeaveActionId, string dragOverActionId, string dropActionId, string dragEndActionId)
    string ClickActionId { get;  set; }
    string DragEndActionId { get;  set; }
    string DragEnterActionId { get;  set; }
    string DragLeaveActionId { get;  set; }
    string DragOverActionId { get;  set; }
    string DragStartActionId { get;  set; }
    string DropActionId { get;  set; }
    int ElementId { get;  set; }
    int Gap { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string PressChangeActionId { get;  set; }
    string PressEndActionId { get;  set; }
    string PressStartActionId { get;  set; }
    string PressUpActionId { get;  set; }
    string StyleId { get;  set; }
    UISectionType Type { get;  set; }
    static UISectionBegin ReadFromTeleport(ReadOnlySpan<byte> data)
    static UISectionBegin ReadFromTeleport(ReadOnlySpan<byte> data, UISectionBegin destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UISectionEnd : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static UISectionEnd ReadFromTeleport(ReadOnlySpan<byte> data)
    static UISectionEnd ReadFromTeleport(ReadOnlySpan<byte> data, UISectionEnd destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum UISectionType
    Default
    ColumnLayout
    RowLayout
    Card
    Right
    Carousel
    ScrollView
  sealed class UISeparator : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId)
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string StyleId { get;  set; }
    static UISeparator ReadFromTeleport(ReadOnlySpan<byte> data)
    static UISeparator ReadFromTeleport(ReadOnlySpan<byte> data, UISeparator destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIStreamBegin : IProtocolMessagePayload
    ctor()
    ctor(string category)
    string Category { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static UIStreamBegin ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIStreamBegin ReadFromTeleport(ReadOnlySpan<byte> data, UIStreamBegin destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  static class UIStreamCategories
    static string App
    static string Chat
    static string Collapsed
    static string DebugOverlay
    static string Footer
    static string Header
    static string Input
    static string Menu
    static string Overlay
    static string Preview
    static string SecondScreen
  sealed class UIStreamEnd : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static UIStreamEnd ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIStreamEnd ReadFromTeleport(ReadOnlySpan<byte> data, UIStreamEnd destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class GlobalState.UIStreamState
    ctor()
    ctor(string streamId, int clientSessionId, int trackId, UIStreamBegin info)
    int ClientSessionId { get;  set; }
    UIStreamBegin Info { get;  set; }
    string StreamId { get;  set; }
    int TrackId { get;  set; }
    static GlobalState.UIStreamState ReadFromTeleport(ReadOnlySpan<byte> data)
    static GlobalState.UIStreamState ReadFromTeleport(ReadOnlySpan<byte> data, GlobalState.UIStreamState destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIStyles : IProtocolMessagePayload
    ctor()
    ctor(string styleId, Dictionary<string, string> style)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    Dictionary<string, string> Style { get;  set; }
    string StyleId { get;  set; }
    static UIStyles ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIStyles ReadFromTeleport(ReadOnlySpan<byte> data, UIStyles destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIStylesBatch : IProtocolMessagePayload
    ctor()
    ctor(List<UIStylesBatch.UIStylesBatchItem> styles)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    List<UIStylesBatch.UIStylesBatchItem> Styles { get;  set; }
    static UIStylesBatch ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIStylesBatch ReadFromTeleport(ReadOnlySpan<byte> data, UIStylesBatch destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIStylesBatch.UIStylesBatchItem
    ctor()
    ctor(string styleId, Dictionary<string, string> style)
    Dictionary<string, string> Style { get;  set; }
    string StyleId { get;  set; }
    static UIStylesBatch.UIStylesBatchItem ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIStylesBatch.UIStylesBatchItem ReadFromTeleport(ReadOnlySpan<byte> data, UIStylesBatch.UIStylesBatchItem destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIStylesDelete : IProtocolMessagePayload
    ctor()
    ctor(List<string> styleIds)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    List<string> StyleIds { get;  set; }
    static UIStylesDelete ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIStylesDelete ReadFromTeleport(ReadOnlySpan<byte> data, UIStylesDelete destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  static class UIStylesKeys
    static string Common
    static string Crosswind
    static string Css
    static string ReactNative
  sealed class UISvg : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string svg)
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string StyleId { get;  set; }
    string Svg { get;  set; }
    static UISvg ReadFromTeleport(ReadOnlySpan<byte> data)
    static UISvg ReadFromTeleport(ReadOnlySpan<byte> data, UISvg destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIText : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string text, UITextType type, UIColor color)
    UIColor Color { get;  set; }
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string StyleId { get;  set; }
    string Text { get;  set; }
    UITextType Type { get;  set; }
    static UIText ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIText ReadFromTeleport(ReadOnlySpan<byte> data, UIText destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum UITextType
    Normal
    Caption
    Strong
    CaptionSmall
    Small
  sealed class UIUpdate : IProtocolMessagePayload
    ctor()
    ctor(string json, Dictionary<string, UIPayload> payloads)
    string Json { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    Dictionary<string, UIPayload> Payloads { get;  set; }
    static UIUpdate ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIUpdate ReadFromTeleport(ReadOnlySpan<byte> data, UIUpdate destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIUpdateAck : IProtocolMessagePayload
    ctor()
    ctor(uint version)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    uint Version { get;  set; }
    static UIUpdateAck ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIUpdateAck ReadFromTeleport(ReadOnlySpan<byte> data, UIUpdateAck destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIUpdateBegin : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static UIUpdateBegin ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIUpdateBegin ReadFromTeleport(ReadOnlySpan<byte> data, UIUpdateBegin destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIUpdateEnd : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static UIUpdateEnd ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIUpdateEnd ReadFromTeleport(ReadOnlySpan<byte> data, UIUpdateEnd destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class UIVegaChart : IProtocolMessagePayload, IUIContainerElement
    ctor()
    ctor(int elementId, List<string> labels, string styleId, string dataJson, string specJson)
    string DataJson { get;  set; }
    int ElementId { get;  set; }
    List<string> Labels { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string SpecJson { get;  set; }
    string StyleId { get;  set; }
    static UIVegaChart ReadFromTeleport(ReadOnlySpan<byte> data)
    static UIVegaChart ReadFromTeleport(ReadOnlySpan<byte> data, UIVegaChart destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum UIVisibilityType
    Always
    AfterEarlierStable
  sealed class UpdateClientContext : IProtocolMessagePayload
    ctor()
    ctor(int viewportWidth, int viewportHeight, string theme, string timezone)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Theme { get;  set; }
    string Timezone { get;  set; }
    int ViewportHeight { get;  set; }
    int ViewportWidth { get;  set; }
    static UpdateClientContext ReadFromTeleport(ReadOnlySpan<byte> data)
    static UpdateClientContext ReadFromTeleport(ReadOnlySpan<byte> data, UpdateClientContext destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  enum UserType
    Unknown
    Machine
    Human
  enum VideoCodec
    Unknown
    H264
    Vp8
    Vp9
    Av1
  sealed class VideoFrame : IProtocolMessagePayload
    ctor()
    ctor(byte[] data, int frameNumber, bool isKey, ulong timestampInUs, uint durationInUs)
    byte[] Data { get;  set; }
    uint DurationInUs { get;  set; }
    int FrameNumber { get;  set; }
    bool IsKey { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    ulong TimestampInUs { get;  set; }
    static VideoFrame ReadFromTeleport(ReadOnlySpan<byte> data)
    static VideoFrame ReadFromTeleport(ReadOnlySpan<byte> data, VideoFrame destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class VideoStreamBegin : IProtocolMessagePayload
    ctor()
    ctor(string streamId, string description, string sourceType, VideoCodec codec, string codecDetails, int width, int height, double framerate)
    VideoCodec Codec { get;  set; }
    string CodecDetails { get;  set; }
    string Description { get;  set; }
    double Framerate { get;  set; }
    int Height { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string SourceType { get;  set; }
    string StreamId { get;  set; }
    int Width { get;  set; }
    static VideoStreamBegin ReadFromTeleport(ReadOnlySpan<byte> data)
    static VideoStreamBegin ReadFromTeleport(ReadOnlySpan<byte> data, VideoStreamBegin destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class VideoStreamEnd : IProtocolMessagePayload
    ctor()
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static VideoStreamEnd ReadFromTeleport(ReadOnlySpan<byte> data)
    static VideoStreamEnd ReadFromTeleport(ReadOnlySpan<byte> data, VideoStreamEnd destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class GlobalState.VideoStreamState
    ctor()
    ctor(string streamId, int clientSessionId, int trackId, VideoStreamBegin info)
    int ClientSessionId { get;  set; }
    VideoStreamBegin Info { get;  set; }
    string StreamId { get;  set; }
    int TrackId { get;  set; }
    static GlobalState.VideoStreamState ReadFromTeleport(ReadOnlySpan<byte> data)
    static GlobalState.VideoStreamState ReadFromTeleport(ReadOnlySpan<byte> data, GlobalState.VideoStreamState destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class WebRTCAnswer : IProtocolMessagePayload
    ctor()
    ctor(string sdp)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    string Sdp { get;  set; }
    static WebRTCAnswer ReadFromTeleport(ReadOnlySpan<byte> data)
    static WebRTCAnswer ReadFromTeleport(ReadOnlySpan<byte> data, WebRTCAnswer destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class WebRTCAudioSegment : IProtocolMessagePayload
    ctor()
    ctor(bool isStart)
    bool IsStart { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    static WebRTCAudioSegment ReadFromTeleport(ReadOnlySpan<byte> data)
    static WebRTCAudioSegment ReadFromTeleport(ReadOnlySpan<byte> data, WebRTCAudioSegment destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class WebRTCIceCandidate : IProtocolMessagePayload
    ctor()
    ctor(string candidate, string sdpMid, int sdpMLineIndex)
    string Candidate { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    int SdpMLineIndex { get;  set; }
    string SdpMid { get;  set; }
    static WebRTCIceCandidate ReadFromTeleport(ReadOnlySpan<byte> data)
    static WebRTCIceCandidate ReadFromTeleport(ReadOnlySpan<byte> data, WebRTCIceCandidate destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class WebRTCOffer : IProtocolMessagePayload
    ctor()
    ctor(string sdp, Opcode opcodeGroupsFromServer, Opcode opcodeGroupsToServer, bool useAudioTrack, bool useVideoTrack, bool useDataChannel)
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    Opcode OpcodeGroupsFromServer { get;  set; }
    Opcode OpcodeGroupsToServer { get;  set; }
    string Sdp { get;  set; }
    bool UseAudioTrack { get;  set; }
    bool UseDataChannel { get;  set; }
    bool UseVideoTrack { get;  set; }
    static WebRTCOffer ReadFromTeleport(ReadOnlySpan<byte> data)
    static WebRTCOffer ReadFromTeleport(ReadOnlySpan<byte> data, WebRTCOffer destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class WebRTCReady : IProtocolMessagePayload
    ctor()
    ctor(bool success, string errorMessage)
    string ErrorMessage { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    bool Success { get;  set; }
    static WebRTCReady ReadFromTeleport(ReadOnlySpan<byte> data)
    static WebRTCReady ReadFromTeleport(ReadOnlySpan<byte> data, WebRTCReady destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion
  sealed class WebRTCTrackMap : IProtocolMessagePayload
    ctor()
    ctor(string kind, int trackIndex, int senderId, int senderTrackId, string streamId, string sourceType, bool active)
    bool Active { get;  set; }
    string Kind { get;  set; }
    Opcode MessageOpcode { get; }
    int MessageVersion { get; }
    int SenderId { get;  set; }
    int SenderTrackId { get;  set; }
    string SourceType { get;  set; }
    string StreamId { get;  set; }
    int TrackIndex { get;  set; }
    static WebRTCTrackMap ReadFromTeleport(ReadOnlySpan<byte> data)
    static WebRTCTrackMap ReadFromTeleport(ReadOnlySpan<byte> data, WebRTCTrackMap destination)
    void WriteToTeleport(TeleportWriter.TeleportObjectScope scope)
    static uint TeleportVersion

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
