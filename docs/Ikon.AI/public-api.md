# Ikon.AI Public API

namespace Ikon.AI
  class IkonAIConnection : AsyncLocalInstance<IkonAIConnection>
    ctor()
    IkonClientConfig ConfigOverride { get;  set; }
    Task ForceReconnectAsync(CancellationToken ct = null)
    Task<IkonClient> GetOrCreateClientAsync(CancellationToken ct = null)
    Task WarmupAsync(CancellationToken ct = null)
    static string ChannelKey
    static string DevelopmentSpaceId
    static string ExternalUserId
    static string ProductionSpaceId
  class ImplementationSelector : AsyncLocalInstance<ImplementationSelector>
    ctor()
    bool ForceLocal { get;  set; }
    bool ForceRemote { get;  set; }
  enum ModelCategory
    Classifier
    Embeddings
    FileConverter
    ImageGenerator
    LLM
    OCR
    Reranker
    SoundEffectGenerator
    SpeechGenerator
    SpeechRecognizer
    VideoEnhancer
    VideoGenerator
    WebScraper
    WebSearcher
  class ModelEnumConverterFactory : JsonConverterFactory
    ctor()
    override bool CanConvert(Type typeToConvert)
    override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
  enum ModelRegion
    Global
    Eu
    EuNorth
    EuWest
    EuCentral
    EuSouth
    Us
    UsEast
    UsWest
  struct ModelRegionPriorityKey : IEquatable<ModelRegionPriorityKey>
    ctor(ModelCategory category, Organization organization, string modelFamilyName)
    ModelCategory Category { get; }
    string ModelFamilyName { get; }
    Organization Organization { get; }
  static class ModelRegionSelector
    static void SetPriorityList(ModelRegionPriorityKey key, IReadOnlyList<ModelRegion> priorities)
    static bool TryGetPriorityList(ModelRegionPriorityKey key, out IReadOnlyList<ModelRegion> priorities)
  enum Organization
    None
    AI21
    Anthropic
    AssemblyAI
    Aws
    Azure
    BlackForestLabs
    Cerebras
    Cohere
    ConvertApi
    DeepInfra
    Deepgram
    ElevenLabs
    Fireworks
    Google
    Groq
    Hyperbolic
    Ikon
    Jina
    Mistral
    Ngrok
    OpenAI
    OpenRouter
    Pollo
    SerpApi
    Spider
    Stability
    TensorPix
    Together
    Voyage
    XAI

namespace Ikon.AI.Chat
  sealed class BasicChat : IAsyncDisposable
    ctor(AssetUri shaderUri)
    KernelContext BaseContext { get;  set; }
    int MaxHistoryLength { get;  set; }
    IReadOnlyList<MessageBlock> Messages { get; }
    void AddModelMessage(string text)
    void AddModelMessage(params object[] parts)
    void AddUserMessage(string text)
    void AddUserMessage(params object[] parts)
    void ClearMessages()
    void Continue()
    KernelContext CreateKernelContext()
    ValueTask DisposeAsync()
    IAsyncEnumerable<StreamingResult> GenerateAsync(IEnumerable<ValueTuple<string, object>> parameters = null, IEnumerable<KernelContext> contexts = null, CancellationToken cancellationToken = null)
    Task<T> GenerateObjectAsync<T>(IEnumerable<ValueTuple<string, object>> parameters = null, IEnumerable<KernelContext> contexts = null, CancellationToken cancellationToken = null)
    Task<string> GenerateStringAsync(IEnumerable<ValueTuple<string, object>> parameters = null, IEnumerable<KernelContext> contexts = null, CancellationToken cancellationToken = null)
    T GetState<T>(string key)
    void SetState(string key, object value)
    void StopProcessing()
    event EventHandler<string> RenderedShader

namespace Ikon.AI.Classification
  sealed class ClassificationDetail
    ctor(ClassificationLabel label, string originalCategory, bool isFlagged, double score)
    bool IsFlagged { get;  init; }
    ClassificationLabel Label { get;  init; }
    string OriginalCategory { get;  init; }
    double Score { get;  init; }
  sealed class ClassificationInput
    ctor()
    byte[] Data { get;  init; }
    string MimeType { get;  init; }
    string Text { get;  init; }
    string Url { get;  init; }
    static ClassificationInput FromMessagePart(IMessagePart messagePart)
  enum ClassificationLabel
    Unknown
    SafetyHateSpeech
    SafetyHarassment
    SafetySelfHarm
    SafetySexualContent
    SafetyChildAbuse
    SafetyViolence
    SafetyJailbreak
    SafetyCopyright
    SafetyDangerousContent
    SafetyHealth
    SafetyFinancial
    SafetyLegal
    SafetyPII
  enum ClassificationModel
    OpenAIOmniModeration
    MistralModeration
  static class ClassificationModelExtensions
    static string DisplayName(ClassificationModel model)
  sealed class ClassificationResult
    ctor()
    List<ClassificationDetail> Details { get;  init; }
    bool IsFlagged { get;  init; }
    override string ToString()
  sealed class Classifier : IClassifier, IDisposable
    ctor(string modelName, IReadOnlyList<ModelRegion> regions = null)
    ctor(ClassificationModel model, IReadOnlyList<ModelRegion> regions = null)
    Task<ClassificationResult> ClassifyAsync(IReadOnlyList<ClassificationInput> inputs, TimeSpan? timeout = null, CancellationToken cancellationToken = null)
    Task<ClassificationResult> ClassifyAsync(IReadOnlyList<IMessagePart> messageParts, TimeSpan? timeout = null, CancellationToken cancellationToken = null)
    Task<ClassificationResult> ClassifyAsync(string text, TimeSpan? timeout = null, CancellationToken cancellationToken = null)
    void Dispose()
    static ClassifierCapabilities GetCapabilities(ClassificationModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(ClassificationModel model)
  sealed class ClassifierCapabilities
    ctor()
  interface IClassifier : IDisposable
    abstract Task<ClassificationResult> ClassifyAsync(IReadOnlyList<ClassificationInput> inputs, TimeSpan? timeout = null, CancellationToken cancellationToken = null)
    virtual Task<ClassificationResult> ClassifyAsync(IReadOnlyList<IMessagePart> messageParts, TimeSpan? timeout = null, CancellationToken cancellationToken = null)
    virtual Task<ClassificationResult> ClassifyAsync(string text, TimeSpan? timeout = null, CancellationToken cancellationToken = null)

namespace Ikon.AI.Database
  sealed class BigQueryDbConnection : DbConnection
    ctor(string projectId, string datasetId)
    string ConnectionString { get;  set; }
    string DataSource { get; }
    string Database { get; }
    string ServerVersion { get; }
    ConnectionState State { get; }
    override void ChangeDatabase(string databaseName)
    override void Close()
    override DataTable GetSchema()
    override DataTable GetSchema(string collectionName)
    override DataTable GetSchema(string collectionName, string[] restrictionValues)
    override void Open()
  class DatabaseConnection.Config
    ctor()
    string EnvVarPrefix { get;  set; }
    DatabaseConnection.SpaceSecret SpaceSecret { get;  set; }
  class DatabaseInfoExtractor.Config
    ctor()
    List<string> ColumnExcludeRegex { get;  set; }
    Dictionary<string, string> ColumnExtraInfo { get;  set; }
    bool IncludeEmptyColumns { get;  set; }
    int JsonSampleLengthLimit { get;  set; }
    int JsonSampleRowLimit { get;  set; }
    int NonTextSampleRowLimit { get;  set; }
    List<string> Schemas { get;  set; }
    List<string> TableExcludeRegex { get;  set; }
    Dictionary<string, string> TableExtraInfo { get;  set; }
    List<string> TableIncludeRegex { get;  set; }
    int TextSampleLengthLimit { get;  set; }
    int TextSampleRowLimit { get;  set; }
  class DatabaseColumnInfo
    ctor()
    string ColumnName { get;  set; }
    string DataType { get;  set; }
    string Description { get;  set; }
    string ExtraInfo { get;  set; }
    string ForeignKeyColumnName { get;  set; }
    string ForeignKeyTableName { get;  set; }
    bool? IsForeignKey { get;  set; }
    bool? IsPrimaryKey { get;  set; }
    List<string> Values { get;  set; }
  class DatabaseConnection
    ctor()
    string BigQueryDataset { get;  set; }
    string BigQueryProjectId { get;  set; }
    DatabaseType DatabaseType { get;  set; }
    DbConnection DbConnection { get;  set; }
    static Task<DatabaseConnection> CreateAsync(DatabaseConnection.Config config)
  class DatabaseInfo
    ctor()
    DatabaseType DatabaseType { get;  set; }
    List<string> ExampleQuestions { get;  set; }
    string SqlCteCommand { get;  set; }
    List<DatabaseTableInfo> Tables { get;  set; }
  class DatabaseInfoExtractor
    ctor(DatabaseConnection databaseConnection)
    Task<DatabaseInfo> ExtractAsync(DatabaseInfoExtractor.Config config, CancellationToken cancellationToken)
    Task<ResultSet> GetCteDatabaseInfoAllValuesAsync(DatabaseInfo cteDatabaseInfo, int maxRows)
    static bool IsText(string dataType)
    Task<DatabaseInfo> ValidateAndFillCteDatabaseInfoAsync(DatabaseInfo cteDatabaseInfo, int maxRowsFilter)
  class DatabaseTableInfo
    ctor()
    List<DatabaseColumnInfo> Columns { get;  set; }
    string Description { get;  set; }
    string ExtraInfo { get;  set; }
    string TableName { get;  set; }
  enum DatabaseType
    Unknown
    PostgreSql
    Sqlite
    BigQuery
    Trino
  class DatabaseConnection.SpaceSecret
    ctor()
    string Prefix { get;  set; }
    string SpaceId { get;  set; }
  static class SqlValidator
    static void ValidateReadOnly(string sql, HashSet<string> allowedTables)

namespace Ikon.AI.Embeddings
  enum EmbeddingEncoding
    Base64
    GzipBase64
  sealed class EmbeddingGenerator : IDisposable, IEmbeddingGenerator
    ctor(string modelName, IReadOnlyList<ModelRegion> regions = null)
    ctor(EmbeddingModel model, IReadOnlyList<ModelRegion> regions = null)
    int EmbeddingVectorSize { get; }
    int MaxInputCount { get; }
    void Dispose()
    Task<List<float[]>> GenerateEmbeddingsAsync(IReadOnlyList<string> inputs, EmbeddingType type, int maxInputCount = 0, TimeSpan? timeout = null, CancellationToken cancellationToken = null)
    static EmbeddingGeneratorCapabilities GetCapabilities(EmbeddingModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(EmbeddingModel model)
  sealed class EmbeddingGeneratorCapabilities
    ctor()
    int EmbeddingVectorSize { get;  init; }
    int MaxInputCount { get;  init; }
  sealed class EmbeddingItem
    ctor(string context, EmbeddingModel model, EmbeddingType type, EmbeddingEncoding encoding, string embedding)
    string Context { get;  init; }
    string Embedding { get;  init; }
    float[] EmbeddingArray { get; }
    EmbeddingEncoding Encoding { get;  init; }
    EmbeddingModel Model { get;  init; }
    EmbeddingType Type { get;  init; }
    static Task<EmbeddingItem> Create(string input, string context, EmbeddingModel model, EmbeddingType type, EmbeddingEncoding encoding, CancellationToken cancellationToken = null)
    static Task<EmbeddingItem> Create(float[] embedding, string context, EmbeddingModel model, EmbeddingType type, EmbeddingEncoding encoding)
  enum EmbeddingModel
    OpenAIAda2
    OpenAI3Small
    OpenAI3Large
    CohereEmbed4
    MistralEmbed
    GeminiEmbedding1
    GoogleTextEmbedding5
    GoogleTextMultilingualEmbedding2
    JinaEmbeddings3
    Voyage35
    Voyage35Lite
  static class EmbeddingModelExtensions
    static string DisplayName(EmbeddingModel model)
  enum EmbeddingType
    Generic
    Document
    Query
    Clustering
    Classification
  interface IEmbeddingGenerator : IDisposable
    int EmbeddingVectorSize { get; }
    int MaxInputCount { get; }
    abstract Task<List<float[]>> GenerateEmbeddingsAsync(IReadOnlyList<string> inputs, EmbeddingType type, int maxInputCount = 0, TimeSpan? timeout = null, CancellationToken cancellationToken = null)
  struct VectorMath.Neighbor
    ctor(int index, float distance)
    float Distance { get; }
    int Index { get; }
  static class VectorMath
    static float[] CalculateAverageEmbedding(IList<float[]> embeddings)
    static float CalculateCosineSimilarity(ReadOnlySpan<float> vectorA, ReadOnlySpan<float> vectorB)
    static float CalculateDotProduct(ReadOnlySpan<float> vectorA, ReadOnlySpan<float> vectorB)
    static float CalculateEuclideanDistance(ReadOnlySpan<float> vectorA, ReadOnlySpan<float> vectorB)
    static List<List<VectorMath.Neighbor>> CalculateKNearestNeighbors(IList<float[]> embeddings, int k)
    static float GetMagnitude(ReadOnlySpan<float> vector)

namespace Ikon.AI.FileConversion
  sealed class ConvertedFile
    ctor()
    byte[] Data { get;  init; }
    string Mimetype { get;  init; }
    string Name { get;  init; }
  sealed class FileConverter : IDisposable, IFileConverter
    ctor(string modelName, IReadOnlyList<ModelRegion> regions = null)
    ctor(FileConverterModel model, IReadOnlyList<ModelRegion> regions = null)
    Task<ConvertedFile> ConvertToPdfAsync(FileConverterConfig config, CancellationToken cancellationToken = null)
    void Dispose()
    static FileConverterCapabilities GetCapabilities(FileConverterModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(FileConverterModel model)
  sealed class FileConverterCapabilities
    ctor()
  sealed class FileConverterConfig
    ctor()
    AssetUri? AssetUri { get;  set; }
    byte[] Data { get;  set; }
    string FileName { get;  set; }
    TimeSpan Timeout { get;  set; }
    string Url { get;  set; }
  enum FileConverterModel
    ConvertApi
  static class FileConverterModelExtensions
    static string DisplayName(FileConverterModel model)
  interface IFileConverter : IDisposable
    abstract Task<ConvertedFile> ConvertToPdfAsync(FileConverterConfig config, CancellationToken cancellationToken = null)

namespace Ikon.AI.ImageGeneration
  interface IImageGenerator : IDisposable
    abstract Task<List<ImageGeneratorResult>> GenerateImageAsync(ImageGeneratorConfig config, CancellationToken cancellationToken = null)
  enum ImageBackground
    Auto
    Opaque
    Transparent
  sealed class ImageGenerator : IDisposable, IImageGenerator
    ctor(string modelName, IReadOnlyList<ModelRegion> regions = null)
    ctor(ImageGeneratorModel model, IReadOnlyList<ModelRegion> regions = null)
    void Dispose()
    Task<List<ImageGeneratorResult>> GenerateImageAsync(ImageGeneratorConfig config, CancellationToken cancellationToken = null)
    static ImageGeneratorCapabilities GetCapabilities(ImageGeneratorModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(ImageGeneratorModel model)
  sealed class ImageGeneratorCapabilities
    ctor()
  sealed class ImageGeneratorConfig
    ctor()
    ImageBackground Background { get;  set; }
    int Count { get;  set; }
    int Height { get;  set; }
    List<InputImage> InputImages { get;  set; }
    string NegativePrompt { get;  set; }
    string Prompt { get;  set; }
    ImageQuality Quality { get;  set; }
    SafetyLevel SafetyLevel { get;  set; }
    string SearchPrompt { get;  set; }
    int Seed { get;  set; }
    int Steps { get;  set; }
    string Style { get;  set; }
    TimeSpan Timeout { get;  set; }
    bool UpsamplePrompt { get;  set; }
    int Width { get;  set; }
  enum ImageGeneratorModel
    Dalle3
    GptImage1
    GptImage15
    Imagen3
    Imagen4Fast
    Imagen4Standard
    Imagen4Ultra
    Gemini25FlashImage
    Gemini3ProImage
    Gemini31FlashImage
    Flux1Dev
    Flux1Schnell
    Flux11Pro
    Flux11ProUltra
    Flux11ProUltraRaw
    Flux1KontextPro
    Flux1KontextMax
    Flux1KreaDev
    Flux2Dev
    Flux2Flex
    Flux2Pro
  static class ImageGeneratorModelExtensions
    static string DisplayName(ImageGeneratorModel model)
  sealed class ImageGeneratorResult
    ctor()
    byte[] Data { get;  set; }
    int Height { get;  set; }
    string MimeType { get;  set; }
    int Width { get;  set; }
  enum ImageQuality
    Auto
    Low
    Medium
    High
  sealed class InputImage
    ctor()
    byte[] Data { get;  set; }
    double? MaskDilution { get;  set; }
    string MimeType { get;  set; }
    double? Strength { get;  set; }
    InputImageType Type { get;  set; }
  enum InputImageType
    Normal
    Mask
  enum SafetyLevel
    Level0
    Level1
    Level2
    Level3
    Level4
    Level5
    Level6

namespace Ikon.AI.Kernel
  sealed class AsyncEnumerableExtensions.<G>$CA58BA95B4ED5DE0AC5F384160329049
    Task<T1[]> AsArrayAsync<T1>()
    Task<T1> AsFirstAsync<T1>()
    Task<string> AsStringAsync()
    IAsyncEnumerable<StreamingResult> WithWindowedProcessingAsync(Func<string, List<StreamingResult>, Task<ValueTuple<bool, List<StreamingResult>>>> processAsync, int windowSize = 0, int windowOverlap = 0)
  static class AsyncEnumerableExtensions.<G>$CA58BA95B4ED5DE0AC5F384160329049.<M>$7325656A85ACD35A95DB91A9468B406C
  static class AsyncEnumerableExtensions
    static Task<T1[]> AsArrayAsync<T1>(IAsyncEnumerable<StreamingResult> source)
    static Task<T1> AsFirstAsync<T1>(IAsyncEnumerable<StreamingResult> source)
    static Task<string> AsStringAsync(IAsyncEnumerable<StreamingResult> source)
    static IAsyncEnumerable<StreamingResult> WithCitationsAsync(IAsyncEnumerable<StreamingResult> source, IdMapper idMapper)
    static IAsyncEnumerable<StreamingResult> WithParsedTagsAsync(IAsyncEnumerable<StreamingResult> source, List<string> tagWhitelist = null, List<string> tagBlacklist = null)
    static IAsyncEnumerable<StreamingResult> WithReasoningFromTagAsync(IAsyncEnumerable<StreamingResult> source, string reasoningTagName)
    static IAsyncEnumerable<StreamingResult> WithThrottlingAsync(IAsyncEnumerable<StreamingResult> source, int charsPerSecond, int charsPerUpdate)
    static IAsyncEnumerable<StreamingResult> WithWindowedProcessingAsync(IAsyncEnumerable<StreamingResult> source, Func<string, List<StreamingResult>, Task<ValueTuple<bool, List<StreamingResult>>>> processAsync, int windowSize = 0, int windowOverlap = 0)
  struct AudioIdPart : IMessagePart
    ctor(string id)
    string Id { get; }
    MessagePartType Type { get; }
  struct AudioPart : IMessagePart
    ctor(byte[] content, string mimeType)
    byte[] Content { get; }
    string MimeType { get; }
    MessagePartType Type { get; }
  class BinaryDataContainer
    ctor(byte[] data, string mimeType)
    byte[] Data { get; }
    string MimeType { get; }
  class Citation
    ctor(string originalId, string mappedId, int referStartIndex, int referEndIndex, int positionIndex)
    string MappedId { get; }
    string OriginalId { get; }
    int PositionIndex { get; }
    int ReferEndIndex { get; }
    int ReferStartIndex { get; }
  class CompletionTokenUsage
    ctor(int inputTokens, int outputTokens)
    int InputTokens { get; }
    int OutputTokens { get; }
  class FinalModelMessage
    ctor(string text)
    string Text { get; }
  class FinalTextResponse
    ctor(string text)
    string Text { get; }
  class FinishReason
    ctor(string reason)
    string Reason { get; }
  class FunctionCall
    ctor(Function function, object[] parameters, string parametersJson, string callId, string hash, string thoughtSignature = "")
    string CallId { get; }
    Function Function { get; }
    string Hash { get; }
    object[] Parameters { get; }
    string ParametersJson { get; }
    string ThoughtSignature { get; }
  class FunctionResult
    ctor(object result = null, string modelMessagePrefix = null, string modelMessageSuffix = null)
    string ModelMessagePrefix { get;  set; }
    string ModelMessageSuffix { get;  set; }
    object Result { get;  set; }
  struct FunctionResultPart : IMessagePart
    ctor(FunctionCall functionCall, StreamingResult[] streamingResults, object result)
    FunctionCall FunctionCall { get; }
    object Result { get; }
    StreamingResult[] StreamingResults { get; }
    MessagePartType Type { get; }
  interface IMessagePart
    MessagePartType Type { get; }
  struct ImagePart : IMessagePart
    ctor(byte[] content, string mimeType)
    byte[] Content { get; }
    string MimeType { get; }
    MessagePartType Type { get; }
  struct ImageUrlPart : IMessagePart
    ctor(string url)
    MessagePartType Type { get; }
    string Url { get; }
  struct Instruction
    ctor(InstructionType type, string content)
    string Content { get; }
    InstructionType Type { get; }
  enum InstructionType
    Context
    Command
  class JsonExampleGenerator
    ctor()
    static JsonNode DeepSerialize(object obj)
    static T GenerateExampleInstance<T>()
    static string GenerateExampleJson<T>()
  static class JsonSchemaGenerator
    static ExpandoObject GenerateJsonSchemaExpandoObject<T>(bool supersetCompatibilityMode = false)
    static string GenerateSchemaString<T>(bool supersetCompatibilityMode = false)
  struct KernelContext : IEquatable<KernelContext>
    ctor()
    ctor(KernelContext? baseContext = null, ImmutableList<Instruction> instructions = null, ImmutableList<MessageBlock> messages = null, ImmutableDictionary<string, Function> functions = null, TimeSpan? timeout = null, double? temperature = null, int? maxOutputTokens = null, ReasoningEffort? reasoningEffort = null, int? reasoningTokenBudget = null, bool? useStreaming = null, bool? useJson = null, bool? useCitations = null, bool? useUserNames = null, bool? useAudioOutput = null, string audioOutputVoiceId = null, bool? useCaching = null, bool? disableFunctionCalling = null, bool? discardTextOutputWithFunctionCalls = null, bool? logFullRequest = null, bool? logFullResponse = null, object jsonSchema = null, string gbnfGrammar = null, string toolPlan = null)
    string AudioOutputVoiceId { get;  init; }
    bool DisableFunctionCalling { get;  init; }
    bool DiscardTextOutputWithFunctionCalls { get;  init; }
    ImmutableDictionary<string, Function> Functions { get;  init; }
    string GbnfGrammar { get;  init; }
    ImmutableList<Instruction> Instructions { get;  init; }
    object JsonSchema { get;  init; }
    bool LogFullRequest { get;  init; }
    bool LogFullResponse { get;  init; }
    int MaxOutputTokens { get;  init; }
    ImmutableList<MessageBlock> Messages { get;  init; }
    ReasoningEffort ReasoningEffort { get;  init; }
    int ReasoningTokenBudget { get;  init; }
    double Temperature { get;  init; }
    TimeSpan Timeout { get;  init; }
    string ToolPlan { get;  init; }
    bool UseAudioOutput { get;  init; }
    bool UseCaching { get;  init; }
    bool UseCitations { get;  init; }
    bool UseJson { get;  init; }
    bool UseStreaming { get;  init; }
    bool UseUserNames { get;  init; }
    KernelContext Add(Instruction instruction)
    KernelContext Add(MessageBlock message)
    static KernelContext Create(IEnumerable<Instruction> instructions = null, IEnumerable<MessageBlock> messages = null, IEnumerable<Function> functions = null, TimeSpan? timeout = null, double? temperature = null, int? maxOutputTokens = null, ReasoningEffort? reasoningEffort = null, int? reasoningTokenBudget = null, bool? useStreaming = null, bool? useJson = null, bool? useCitations = null, bool? useUserNames = null, bool? useAudioOutput = null, string audioOutputVoiceId = null, bool? useCaching = null, bool? disableFunctionCalling = null, bool? discardTextOutputWithFunctionCalls = null, bool? logFullRequest = null, bool? logFullResponse = null, object jsonSchema = null, string gbnfGrammar = null, string toolPlan = null)
    IAsyncEnumerable<StreamingResult> GenerateAsync(ILLM llm, CancellationToken cancellationToken = null)
    KernelContext KeepMessagesMax(int count)
    IAsyncEnumerable<StreamingResult> RecurseAsync(IAsyncEnumerable<StreamingResult> generator, HashSet<string> alreadyCalledFunctions)
    IAsyncEnumerable<StreamingResult> ReturnFunctionCallAsync(string name, string parametersJson, string callId, string thoughtSignature = "")
    IAsyncEnumerable<StreamingResult> RunFunctionAsync(string functionName, object[] parameters, CancellationToken cancellationToken = null)
    KernelContext WithFunctions(IEnumerable<Function> functions, bool replaceExisting = false)
  struct MessageBlock
    ctor(MessageBlockRole role, IMessagePart[] parts, string userName = null)
    ctor(MessageBlockRole role, IEnumerable<IMessagePart> parts, string userName = null)
    ctor(MessageBlockRole role, string message, string userName = null)
    IMessagePart[] Parts { get; }
    MessageBlockRole Role { get; }
    string UserName { get; }
    static MessageBlock? CreateFromObjects(IReadOnlyList<object> inputs, MessageBlockRole role)
    override string ToString()
  enum MessageBlockRole
    User
    Model
    FunctionResult
  enum MessagePartType
    Text
    Image
    ImageUrl
    Audio
    AudioId
    Video
    VideoUrl
    Pdf
    PdfUrl
    FunctionResult
  class OutputAudioId
    ctor(string id)
    string Id { get; }
  class OutputAudioTranscript
    ctor(string transcript)
    string Transcript { get; }
  struct PdfPart : IMessagePart
    ctor(byte[] content, string mimeType)
    byte[] Content { get; }
    string MimeType { get; }
    MessagePartType Type { get; }
  struct PdfUrlPart : IMessagePart
    ctor(string url)
    MessagePartType Type { get; }
    string Url { get; }
  class Reasoning
    ctor(string text)
    string Text { get; }
  enum ReasoningEffort
    None
    Minimal
    Low
    Medium
    High
  struct StreamingResult
    ctor(object value, string sourceName, string valueTypeName = null)
    string SourceName { get; }
    object Value { get; }
    string ValueTypeName { get; }
  class Tag
    ctor(string name, string content, Dictionary<string, string> attributes = null)
    Dictionary<string, string> Attributes { get; }
    string Content { get; }
    string Name { get; }
  struct TextPart : IMessagePart
    ctor(string content)
    string Content { get; }
    MessagePartType Type { get; }
  class ToolPlan
    ctor(string text)
    string Text { get; }
  struct VideoPart : IMessagePart
    ctor(byte[] content, string mimeType)
    byte[] Content { get; }
    string MimeType { get; }
    MessagePartType Type { get; }
  struct VideoUrlPart : IMessagePart
    ctor(string url, string mimeType)
    string MimeType { get; }
    MessagePartType Type { get; }
    string Url { get; }

namespace Ikon.AI.LLM
  interface ILLM : IDisposable, ILLMInfo
    abstract IAsyncEnumerable<StreamingResult> GenerateAsync(KernelContext context, CancellationToken cancellationToken = null)
  interface ILLMInfo
    int ContextWindowSize { get; }
    string InlineReasoningTagName { get; }
    bool SupportsGbnfGrammar { get; }
    bool SupportsInputAudio { get; }
    bool SupportsInputImages { get; }
    bool SupportsInputPdf { get; }
    bool SupportsInputVideo { get; }
    bool SupportsJsonSchema { get; }
    bool SupportsOutputAudio { get; }
    bool SupportsParallelToolCalling { get; }
    bool SupportsReasoning { get; }
    bool SupportsStreaming { get; }
    bool UsesInlineReasoning { get; }
  sealed class LLM : IDisposable, ILLM, ILLMInfo
    ctor(string modelName, IReadOnlyList<ModelRegion> regions = null)
    ctor(LLMModel model, IReadOnlyList<ModelRegion> regions = null)
    int ContextWindowSize { get; }
    string InlineReasoningTagName { get; }
    bool SupportsGbnfGrammar { get; }
    bool SupportsInputAudio { get; }
    bool SupportsInputImages { get; }
    bool SupportsInputPdf { get; }
    bool SupportsInputVideo { get; }
    bool SupportsJsonSchema { get; }
    bool SupportsOutputAudio { get; }
    bool SupportsParallelToolCalling { get; }
    bool SupportsReasoning { get; }
    bool SupportsSingleToolCalling { get; }
    bool SupportsStreaming { get; }
    bool UsesInlineReasoning { get; }
    void Dispose()
    IAsyncEnumerable<StreamingResult> GenerateAsync(KernelContext context, CancellationToken cancellationToken = null)
    static LLMCapabilities GetCapabilities(LLMModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(LLMModel model)
  sealed class LLMCapabilities : ILLMInfo
    ctor()
    int ContextWindowSize { get;  init; }
    string InlineReasoningTagName { get;  init; }
    bool SupportsGbnfGrammar { get;  init; }
    bool SupportsInputAudio { get;  init; }
    bool SupportsInputImages { get;  init; }
    bool SupportsInputPdf { get;  init; }
    bool SupportsInputVideo { get;  init; }
    bool SupportsJsonSchema { get;  init; }
    bool SupportsOutputAudio { get;  init; }
    bool SupportsParallelToolCalling { get;  init; }
    bool SupportsReasoning { get;  init; }
    bool SupportsStreaming { get;  init; }
    bool UsesInlineReasoning { get;  init; }
  enum LLMModel
    Gpt4Omni
    Gpt4OmniMini
    Gpt4OmniAudio
    Gpt41
    Gpt41Mini
    Gpt41Nano
    Gpt5
    Gpt5Mini
    Gpt5Nano
    Gpt51
    Gpt52
    Gpt5Codex
    Gpt51Codex
    Gpt51CodexMax
    Gpt52Codex
    Gpt5Pro
    Gpt52Pro
    Gpt54
    Gpt54Pro
    O3
    O3Mini
    O3Pro
    O4Mini
    Claude41Opus
    Claude45Haiku
    Claude45Sonnet
    Claude45Opus
    Claude46Opus
    Claude46Sonnet
    Gemini20Flash
    Gemini20FlashLite
    Gemini25Flash
    Gemini25Pro
    Gemini3Flash
    Gemini3Pro
    Grok3
    Grok3Mini
    Grok4
    Grok4Fast
    GrokCodeFast1
    MistralSmall
    MistralMedium
    MistralLarge
    MagistralSmall
    MagistralMedium
    PixtralLarge
    Codestral
    DevstralSmall
    DevstralMedium
    CommandR
    CommandA
    KimiK2Thinking
    KimiK2
    KimiK25
    GptOss120B
    Glm47
    Glm5
    MiniMaxM25
    DeepSeekV32
    NovaPro
    NovaLite
    NovaMicro
    Nova2Lite
  static class LLMModelExtensions
    static string DisplayName(LLMModel model)

namespace Ikon.AI.Legacy
  class Mind : IAsyncDisposable
    ctor()
    Context CurrentUserClientContext { get; }
    string CurrentUserLocale { get; }
    string DefaultModelName { get;  set; }
    string DefaultSecondaryModelName { get;  set; }
    string DefaultUserLocale { get;  set; }
    string DefaultUserName { get;  set; }
    KernelContext KernelContext { get; }
    Task AddModelInput(string text, bool isHistory = false)
    Task AddUserInput(Context clientContext, string userName, string userLocale, IReadOnlyList<object> inputs, bool isHistory = false)
    Task CancelGenerateAnswer()
    void ClearMessageHistory()
    void ClearState()
    ValueTask DisposeAsync()
    Task GenerateAnswer(string command = null, string context = null, string modelMessagePrefix = null, string modelMessageSuffix = null, Context clientContext = null, List<ValueTuple<string, object>> variables = null)
    T GetState<T>(string key)
    T GetState<T>(string key, T defaultValue)
    Task InitializeAsync(MindConfig config, Retriever retriever, string mindUserName, Context hostClientContext, AssetUri? shaderUri = null)
    Mind.ShaderLoadResult LoadShader(string shaderContent)
    Task PostMessage(string text)
    Task RegenerateAnswer(Context clientContext = null)
    Task RequestGenerateAnswer(string command = null, string context = null, string modelMessagePrefix = null, string modelMessageSuffix = null, Context clientContext = null, List<ValueTuple<string, object>> variables = null)
    Task RequestRegenerateAnswer(Context clientContext = null)
    void SetState<T>(string key, T value)
    Task StopAsync()
    Task WaitGenerateAnswer()
    Func<Task> Activity
    Func<Task> Cancel
    Func<MindResult, Task> Finish
    Func<List<KernelContext>> GetContexts
    Func<StreamingResult, Task> Output
    Action PreStart
    Action<string> RenderedShader
    Func<Task> Retry
    Func<Task> Start
    Func<Dictionary<string, object>, Task> StateUpdate
  class MindConfig
    ctor()
    int ActivityIntervalMs
    string BackupFailureMessage
    bool ClipLongUserMessagesInsteadOfError
    bool EnableRenderedShaderLogging
    bool IncludeReasonInFailureMessage
    int MaxHistoryLength
    int MaxRetryCount
    int MaxUserMessageLength
    int MaxUserMessagesRateLimit
    double MaxUserMessagesRateWindow
  class MindResult
    ctor()
    string AudioId { get;  set; }
    string ModelMessage { get;  set; }
    string TextResponse { get;  set; }
  class Mind.ShaderLoadResult
    ctor()
    string ErrorMessage
    bool IsSuccess

namespace Ikon.AI.OCR
  enum DocumentType
    General
  interface IOCR : IDisposable
    abstract Task<OCRResult> AnalyzeDocumentAsync(OCRConfig config, CancellationToken cancellationToken = null)
  sealed class OCR : IDisposable, IOCR
    ctor(string modelName, IReadOnlyList<ModelRegion> regions = null)
    ctor(OCRModel model, IReadOnlyList<ModelRegion> regions = null)
    Task<OCRResult> AnalyzeDocumentAsync(OCRConfig config, CancellationToken cancellationToken = null)
    void Dispose()
    static OCRCapabilities GetCapabilities(OCRModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(OCRModel model)
  sealed class OCRBoundingBox
    ctor()
    int PageNumber { get;  init; }
    List<float> Polygon { get;  init; }
  sealed class OCRCapabilities
    ctor()
  sealed class OCRConfig
    ctor()
    AssetUri? AssetUri { get;  set; }
    byte[] Data { get;  set; }
    DocumentType DocumentType { get;  set; }
    TimeSpan Timeout { get;  set; }
    string Url { get;  set; }
  enum OCRModel
    AzureDocumentIntelligence
    MistralOCR
  static class OCRModelExtensions
    static string DisplayName(OCRModel model)
  sealed class OCRPage
    ctor()
    float Height { get;  init; }
    int PageNumber { get;  init; }
    string Unit { get;  init; }
    float Width { get;  init; }
  sealed class OCRParagraph
    ctor()
    List<OCRBoundingBox> BoundingRegions { get;  init; }
    string Content { get;  init; }
  sealed class OCRResult
    ctor()
    List<OCRPage> Pages { get;  init; }
    List<OCRParagraph> Paragraphs { get;  init; }
    string Text { get;  init; }
    List<OCRWord> Words { get;  init; }
  sealed class OCRWord
    ctor()
    OCRBoundingBox BoundingBox { get;  init; }
    float Confidence { get;  init; }
    string Content { get;  init; }

namespace Ikon.AI.Policy
  sealed class CreditLimitChecker : IUsageLimitChecker
    ctor()
    ValueTask<UsageLimitCheckResult> CheckAsync(PolicyCallContext context, object[] args)

namespace Ikon.AI.Reranking
  interface IReranker : IDisposable
    abstract Task<List<RerankItem>> RerankAsync(IReadOnlyList<string> documents, string query, int topN = 0, TimeSpan? timeout = null, CancellationToken cancellationToken = null)
  sealed class RerankItem
    ctor()
    int Index { get;  init; }
    double Score { get;  init; }
  enum RerankModel
    CohereRerank4Fast
    CohereRerank4Pro
    JinaReranker3
    VoyageRerank25
    VoyageRerank25Lite
  static class RerankModelExtensions
    static string DisplayName(RerankModel model)
  sealed class Reranker : IDisposable, IReranker
    ctor(string modelName, IReadOnlyList<ModelRegion> regions = null)
    ctor(RerankModel model, IReadOnlyList<ModelRegion> regions = null)
    void Dispose()
    static RerankerCapabilities GetCapabilities(RerankModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(RerankModel model)
    Task<List<RerankItem>> RerankAsync(IReadOnlyList<string> documents, string query, int topN = 0, TimeSpan? timeout = null, CancellationToken cancellationToken = null)
  sealed class RerankerCapabilities
    ctor()

namespace Ikon.AI.Retrieving
  class Content
    ctor(object value, ContentLink link, string mimeType)
    override string ToString()
    ContentLink Link
    string MimeType
    object Value
  class ContentLink
    ctor(string link, float score = 0)
    ctor(List<string> segments, float score = 0)
    ctor(ContentLink parent, string secondPart, float score = 0)
    ctor(string link, string secondPart, float score = 0)
    ContentLink Parent { get; }
    ContentLink Root { get; }
    override bool Equals(object obj)
    List<ValueTuple<string, string>> GenerateHierarchicalSplitLinks()
    override int GetHashCode()
    override string ToString()
    string Link
    float Score
    List<string> Segments
  class Retriever.ContentMetadata
    ctor()
    DateTime CreatedAt { get;  set; }
    string DocumentTitle { get;  set; }
    string OriginalName { get;  set; }
    string OriginalPath { get;  set; }
    int PageNumber { get;  set; }
    List<int> PageNumbers { get;  set; }
    List<string> TitleHierarchy { get;  set; }
    DateTime UpdatedAt { get;  set; }
  class Retriever.Event
    ctor()
    DateTime Date { get;  set; }
    string Description { get;  set; }
    override string ToString()
    ContentLink Source
  class Retriever.GetContentsOptions
    ctor()
    string ContentPostfixes { get;  set; }
    float CumulativeScoreThreshold { get;  set; }
    int HitCountThreshold { get;  set; }
    int MaxContentCount { get;  set; }
    int MaxSearchResults { get;  set; }
    int MinContentCount { get;  set; }
    float SearchThreshold { get;  set; }
    bool UseCumulativeScore { get;  set; }
    bool UseIdMapper { get;  set; }
  class Retriever.GetContentsOptions2
    ctor()
    bool IncludeFullTexts { get;  set; }
    int MaxRerankResults { get;  set; }
    int MaxSearchResults { get;  set; }
    double RerankThreshold { get;  set; }
    float SearchThreshold { get;  set; }
  class IdMapper
    ctor(IdMappingType mappingType = None, int randomHexLength = 8, int randomLettersLength = 8, int integerCounter = 0, int? seed = null)
    string ToMapped(string original)
    string ToOriginal(string mapped)
    bool TryToOriginal(string mapped, out string original)
    ConcurrentDictionary<string, string> Mapping
    ConcurrentDictionary<string, string> ReverseMapping
  enum IdMappingType
    None
    RandomHex
    RandomLetters
    IncreasingInteger
  class JsonAsset
    ctor(string content)
    IEnumerable<string> GetAllKeys()
    string[] GetKeys()
    bool TryGetValue(string keyPath, out object value)
    bool TryGetValueAsObject(string keyPath, out object value)
  class Retriever : IAsyncDisposable
    ctor()
    KernelContext Context { get; }
    IdMapper IdMapper { get; }
    ValueTask DisposeAsync()
    Task<ContentLink[]> Expand(ContentLink[] links)
    Task<ContentLink[]> Expand(ContentLink link)
    Task<Content> GetContent(ContentLink link)
    Retriever.ContentMetadata GetContentMetadata(string metadataId)
    Task<string> GetContents(string query, Retriever.GetContentsOptions options)
    Task<string> GetContents2(string query, Retriever.GetContentsOptions2 options)
    ContentLink Ignore(ContentLink link, string detail)
    Task InitializeAsync(string dataDirectory, EmbeddingModel embeddingModel = OpenAI3Small)
    Task InitializeAsync(IReadOnlyList<AssetUri> assetUris, EmbeddingModel embeddingModel = OpenAI3Small)
    ContentLink[] Prefer(ContentLink link, string detail)
    ContentLink[] Prefer(ContentLink[] links, string detail)
    Task<ContentLink[]> Search(string query, int maxLinks = 25, float searchThreshold = 0.1)
    Task<Retriever.Event[]> SearchEvents(string startUtcTimestamp, string endUtcTimestamp, int maxResults = 100)
    Task<Retriever.Event[]> SearchEvents(string startUtcTimestamp, string endUtcTimestamp, string searchString, int maxResults = 100)
    Task<KeywordSearchResult[]> SearchKeywords(string searchString, int maxResults = 100)
    Task StopAsync()
    Task WaitForLoadingToEnd()

namespace Ikon.AI.Shader
  class Actions
    ctor()
    ScriptableStringValue AfterPass { get;  set; }
    ScriptableStringValue AfterShader { get;  set; }
    ScriptableStringValue BeforePass { get;  set; }
    ScriptableStringValue BeforeShader { get;  set; }
    Dictionary<string, ScriptableStringValue> Listeners
  class FunctionDetailsDictionaryConverter<T> : JsonConverter where T : new(), IFunctionDetails
    ctor()
    override bool CanConvert(Type objectType)
    override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
  class History
    ctor()
    ScriptableValue<int> Max { get;  set; }
    ScriptableValue<int> Skip { get;  set; }
  interface IFunctionDetails
    ScriptableValue<bool> Select { get;  set; }
  interface IScriptContext
    abstract void AddFilter(string name, KernelContext context, Function function)
    abstract void AddFunction(string name, KernelContext context, Function function)
    abstract bool ContainsKey(string key)
    abstract IEnumerable<string> GetKeys()
    abstract object GetValue(string key)
    abstract string GetValueAsString(string key)
    abstract void Register<T>()
    abstract void SetValue(string key, object value)
  interface IScriptEngine
    abstract IScriptContext CreateContext()
    abstract bool TryParse(string template, out IScriptTemplate parsedTemplate, out string errorMessage)
  interface IScriptTemplate
    abstract Task<string> RenderAsync(IScriptContext context)
  class ShaderCache.ImplicitShader
    ctor(AssetUri? shaderUri, string callerFilePath, ShaderCache outer)
    IAsyncEnumerable<StreamingResult> GenerateAsync(List<KernelContext> contexts = null, ShaderInvocationContext invocationContext = null, Func<KernelContext, Task<KernelContext>> preprocessContext = null, CancellationToken cancellationToken = null, params ValueTuple<string, object>[] parameters)
    Task<T> GenerateObjectAsync<T>(List<KernelContext> contexts = null, ShaderInvocationContext invocationContext = null, CancellationToken cancellationToken = null, params ValueTuple<string, object>[] parameters)
    Task<T> GenerateObjectAsync<T>(List<KernelContext> contexts = null, CancellationToken cancellationToken = null, params ValueTuple<string, object>[] parameters)
    Task<T> GenerateObjectAsync<T>(string cacheKey = null, List<KernelContext> contexts = null, CancellationToken cancellationToken = null, params ValueTuple<string, object>[] parameters)
    Task<T> GenerateObjectAsync<T>(List<KernelContext> contexts = null, ShaderInvocationContext invocationContext = null, Func<KernelContext, Task<KernelContext>> preprocessContext = null, CancellationToken cancellationToken = null, params ValueTuple<string, object>[] parameters)
    Task<T> GenerateObjectAsync<T>(List<KernelContext> contexts = null, Func<KernelContext, Task<KernelContext>> preprocessContext = null, CancellationToken cancellationToken = null, params ValueTuple<string, object>[] parameters)
    Task<T> GenerateObjectAsync<T>(string cacheKey = null, List<KernelContext> contexts = null, Func<KernelContext, Task<KernelContext>> preprocessContext = null, CancellationToken cancellationToken = null, params ValueTuple<string, object>[] parameters)
    Task<string> GenerateStringAsync(List<KernelContext> contexts = null, ShaderInvocationContext invocationContext = null, CancellationToken cancellationToken = null, params ValueTuple<string, object>[] parameters)
    Task<string> GenerateStringAsync(List<KernelContext> contexts = null, ShaderInvocationContext invocationContext = null, Func<KernelContext, Task<KernelContext>> preprocessContext = null, CancellationToken cancellationToken = null, params ValueTuple<string, object>[] parameters)
    Task<Shader> GetShaderAsync()
  class Intent
    ctor()
    History History { get;  set; }
    string Id { get;  set; }
    Dictionary<string, object> Input { get;  set; }
    Misc Misc { get;  set; }
    Model Model { get;  set; }
    List<Pass> Passes { get;  set; }
    ScriptableValue<bool> Select { get;  set; }
  class JTokenConverter
    ctor()
    static object ConvertJTokenToObject(JToken token)
  class Misc
    ctor()
    ScriptableStringValue CitationInsertionCommand { get;  set; }
    ScriptableStringValue CitationUserMessageExtension { get;  set; }
    List<string> FailClassificationLabels { get;  set; }
    ScriptableStringValue FailureMessage { get;  set; }
    ScriptableValue<bool> InsertCitationsBackToModelMessage { get;  set; }
    ScriptableValue<bool> UseTrimming { get;  set; }
  class Model
    ctor()
    ScriptableStringValue AudioOutputVoiceId { get;  set; }
    ScriptableValue<int> CharsPerSecond { get;  set; }
    ScriptableValue<int> CharsPerUpdate { get;  set; }
    ScriptableValue<bool> DisableFunctionCalling { get;  set; }
    ScriptableValue<bool> DiscardTextOutputWithFunctionCalls { get;  set; }
    ScriptableValue<bool> ForceCitations { get;  set; }
    ScriptableStringValue GbnfGrammar { get;  set; }
    ExpandoObject JsonSchema { get;  set; }
    ScriptableStringValue JsonSchemaString { get;  set; }
    ScriptableValue<bool> LogFullRequest { get;  set; }
    ScriptableValue<bool> LogRenderedShader { get;  set; }
    ScriptableValue<int> MaxOutputTokens { get;  set; }
    ScriptableValue<int> MaxRecursionDepth { get;  set; }
    ScriptableStringValue Name { get;  set; }
    ScriptableStringValue ReasoningEffort { get;  set; }
    ScriptableValue<int> ReasoningTokenBudget { get;  set; }
    List<ModelRegion> Regions { get;  set; }
    ScriptableValue<int> RequestTimeoutSeconds { get;  set; }
    ScriptableValue<double> Temperature { get;  set; }
    List<Transform> Transforms { get;  set; }
    ScriptableValue<bool> UseAudioOutput { get;  set; }
    ScriptableValue<bool> UseCaching { get;  set; }
    ScriptableValue<bool> UseCitations { get;  set; }
    ScriptableValue<bool> UseJson { get;  set; }
    ScriptableValue<bool> UseStreaming { get;  set; }
    ScriptableValue<bool> UseThrottling { get;  set; }
    ScriptableValue<bool> UseUserNames { get;  set; }
  class ModelFunctionDetails : IFunctionDetails
    ctor()
    ScriptableStringValue Call { get;  set; }
    ScriptableValue<bool> CallOnlyOnce { get;  set; }
    ScriptableStringValue Description { get;  set; }
    ScriptableValue<bool> InlineCall { get;  set; }
    Dictionary<string, ParameterDetails> Parameters { get;  set; }
    ScriptableStringValue Process { get;  set; }
    ScriptableValue<bool> Select { get;  set; }
    ScriptableStringValue Use { get;  set; }
  class Output
    ctor()
    ScriptableStringValue AfterPass { get;  set; }
    ScriptableStringValue AfterShader { get;  set; }
    ScriptableStringValue BeforePass { get;  set; }
    ScriptableStringValue BeforeShader { get;  set; }
  class ParameterDetails
    ctor()
    object DefaultValue { get;  set; }
    ScriptableStringValue Description { get;  set; }
    ScriptableValue<bool> HasDefaultValue { get;  set; }
    ScriptableStringValue Type { get;  set; }
    ScriptableStringValue Use { get;  set; }
  class Pass
    ctor()
    Actions Actions { get;  set; }
    ScriptableStringValue Command { get;  set; }
    ScriptableStringValue Context { get;  set; }
    History History { get;  set; }
    string Id { get;  set; }
    Dictionary<string, object> Input { get;  set; }
    Misc Misc { get;  set; }
    Model Model { get;  set; }
    Dictionary<string, ModelFunctionDetails> ModelFunctions { get;  set; }
    Output Output { get;  set; }
    ScriptableValue<bool> Select { get;  set; }
    Dictionary<string, TemplateFunctionDetails> TemplateFunctions { get;  set; }
  class ScriptableStringDictionaryConverter : JsonConverter
    ctor()
    override bool CanConvert(Type objectType)
    override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
  class ScriptableStringValue
    ctor(string value = "")
    bool IsScript { get; }
    string Value { get; }
    Task<string> GetValueAsync(Func<string, Task<string>> renderer)
  class ScriptableStringValueConverter : JsonConverter
    ctor()
    override bool CanConvert(Type objectType)
    override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
  class ScriptableValueConverter : JsonConverter
    ctor()
    override bool CanConvert(Type objectType)
    override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
  class ScriptableValue<T> where T : struct
    ctor(T value)
    ctor(string script)
    string Script { get; }
    T? Value { get; }
    Task<T> GetValueAsync(Func<string, Task<string>> renderer)
  class Shader
    ctor(string shaderConfigAsJsonString, bool enableRenderedShaderLogging = false)
    Dictionary<string, object> Input { get; }
    static string Escape(string text)
    IAsyncEnumerable<StreamingResult> GenerateAsync(KernelContext? context = null, List<KernelContext> externalContexts = null, Dictionary<string, object> state = null, ShaderInvocationContext invocationContext = null, ExpandoObject implicitJsonSchema = null, string implicitJsonExample = null, IdMapper idMapper = null, string modelUserName = "", string modelMessagePrefix = "", string modelMessageSuffix = "", int iteration = 0, Func<Dictionary<string, object>, Task> stateUpdateCallback = null, Func<KernelContext, Task<KernelContext>> preprocessContext = null, CancellationToken cancellationToken = null)
    Task<T> GenerateObjectAsync<T>(KernelContext? context = null, List<KernelContext> externalContexts = null, Dictionary<string, object> state = null, ShaderInvocationContext invocationContext = null, Func<Dictionary<string, object>, Task> stateUpdateCallback = null, JsonSerializerOptions jsonSerializerOptions = null, Func<KernelContext, Task<KernelContext>> preprocessContext = null, CancellationToken cancellationToken = null)
    Task<string> GenerateStringAsync(KernelContext? context = null, List<KernelContext> externalContexts = null, Dictionary<string, object> state = null, ShaderInvocationContext invocationContext = null, Func<Dictionary<string, object>, Task> stateUpdateCallback = null, Func<KernelContext, Task<KernelContext>> preprocessContext = null, CancellationToken cancellationToken = null)
    void SetActiveState<T>(string key, T value)
    static string Unescape(string text)
    event EventHandler<string> RenderedShader
  class ShaderCache : AsyncLocalInstance<ShaderCache>
    ctor()
    string DefaultSpaceId { get;  set; }
    ShaderCache.ImplicitShader GetImplicitShader(string callerFilePath = "")
  class ShaderConfig
    ctor()
    static object Default { get; }
    History History { get;  set; }
    Dictionary<string, object> Input { get;  set; }
    List<Intent> Intents { get;  set; }
    ScriptableValue<int> MaxLogLineLength { get;  set; }
    ScriptableValue<int> MaxLogSectionLineCount { get;  set; }
    Misc Misc { get;  set; }
    Model Model { get;  set; }
    string ShaderLanguage { get;  set; }
    int? ShaderVersion { get;  set; }
  class ShaderInvocationContext
    ctor()
    string FailureMessage { get; }
    string Reasoning { get; }
  class StyleInvariantComparer : IEqualityComparer<string>
    ctor()
    bool Equals(string x, string y)
    int GetHashCode(string obj)
  class TemplateFunctionDetails : IFunctionDetails
    ctor()
    ScriptableStringValue Name { get;  set; }
    ScriptableValue<bool> Select { get;  set; }
  class Shader.TemplateMessage
    ctor()
    string Content { get;  set; }
    string Role { get;  set; }
  class Transform
    ctor()
    Dictionary<string, object> Config { get;  set; }
    ScriptableStringValue Name { get;  set; }
    ScriptableValue<bool> ProcessInput { get;  set; }
    ScriptableValue<bool> ProcessOutput { get;  set; }
    ScriptableValue<int> WindowOverlap { get;  set; }
    ScriptableValue<int> WindowSize { get;  set; }

namespace Ikon.AI.Shader.Scriban
  class ScribanScriptEngine : IScriptEngine
    ctor()
    IScriptContext CreateContext()
    bool TryParse(string template, out IScriptTemplate parsedTemplate, out string errorMessage)

namespace Ikon.AI.SoundEffectGeneration
  interface ISoundEffectGenerator : IDisposable, ISoundEffectGeneratorInfo
    int ChannelCount { get; }
    int SampleRate { get; }
    abstract IAsyncEnumerable<AudioContainer> GenerateSoundEffectAsync(SoundEffectGeneratorConfig config, CancellationToken cancellationToken = null)
  interface ISoundEffectGeneratorInfo
    bool SupportsLooping { get; }
  sealed class SoundEffectFileResult
    byte[] AudioData { get;  init; }
    string ContentType { get;  init; }
    double DurationSeconds { get;  init; }
  sealed class SoundEffectGenerator : IDisposable, ISoundEffectGenerator, ISoundEffectGeneratorInfo
    ctor(string modelName, bool useLocalCache = true, TimeSpan? localCacheExpirationTime = null)
    ctor(SoundEffectGeneratorModel model, bool useLocalCache = true, TimeSpan? localCacheExpirationTime = null)
    ctor(string modelName, IReadOnlyList<ModelRegion> regions, bool useLocalCache = true, TimeSpan? localCacheExpirationTime = null)
    ctor(SoundEffectGeneratorModel model, IReadOnlyList<ModelRegion> regions, bool useLocalCache = true, TimeSpan? localCacheExpirationTime = null)
    int ChannelCount { get; }
    int SampleRate { get; }
    bool SupportsLooping { get; }
    void Dispose()
    IAsyncEnumerable<AudioContainer> GenerateSoundEffectAsync(SoundEffectGeneratorConfig config, CancellationToken cancellationToken = null)
    Task<SoundEffectFileResult> GenerateSoundEffectFileAsync(SoundEffectGeneratorConfig config, CancellationToken cancellationToken = null)
    static SoundEffectGeneratorCapabilities GetCapabilities(SoundEffectGeneratorModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(SoundEffectGeneratorModel model)
  sealed class SoundEffectGeneratorCapabilities : ISoundEffectGeneratorInfo
    ctor()
    bool SupportsLooping { get;  init; }
  sealed class SoundEffectGeneratorConfig
    double? DurationSeconds { get;  set; }
    bool Loop { get;  set; }
    string Prompt { get;  set; }
    double PromptInfluence { get;  set; }
    TimeSpan Timeout { get;  set; }
  enum SoundEffectGeneratorModel
    ElevenLabsV2
  static class SoundEffectGeneratorModelExtensions
    static string DisplayName(SoundEffectGeneratorModel model)

namespace Ikon.AI.SpeechGeneration
  sealed class TextFilter.Config
    ctor()
    int MaxTextLength { get;  set; }
    bool RemoveEmojis { get;  set; }
    bool SimplifyUrls { get;  set; }
    bool SpeakOnlyFirstParagraph { get;  set; }
  interface ISpeechGenerator : IDisposable
    int ChannelCount { get; }
    int SampleRate { get; }
    IReadOnlyList<string> VoiceIds { get; }
    abstract IAsyncEnumerable<AudioContainer> GenerateSpeechAsync(SpeechGeneratorConfig config, CancellationToken cancellationToken = null)
  sealed class SpeechGenerator : IDisposable, ISpeechGenerator
    ctor(string modelName, bool useLocalCache = true, TimeSpan? localCacheExpirationTime = null)
    ctor(SpeechGeneratorModel model, bool useLocalCache = true, TimeSpan? localCacheExpirationTime = null)
    ctor(string modelName, IReadOnlyList<ModelRegion> regions, bool useLocalCache = true, TimeSpan? localCacheExpirationTime = null)
    ctor(SpeechGeneratorModel model, IReadOnlyList<ModelRegion> regions, bool useLocalCache = true, TimeSpan? localCacheExpirationTime = null)
    int ChannelCount { get; }
    int SampleRate { get; }
    IReadOnlyList<string> VoiceIds { get; }
    void Dispose()
    IAsyncEnumerable<AudioContainer> GenerateSpeechAsync(SpeechGeneratorConfig config, CancellationToken cancellationToken = null)
    static SpeechGeneratorCapabilities GetCapabilities(SpeechGeneratorModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(SpeechGeneratorModel model)
    static IReadOnlyDictionary<SpeechGeneratorModel, IReadOnlyList<string>> GetVoiceIdsByModel()
  sealed class SpeechGeneratorCapabilities
    ctor()
  sealed class SpeechGeneratorConfig
    ctor()
    string Instructions { get;  set; }
    string Language { get;  set; }
    string Speed { get;  set; }
    string Text { get;  set; }
    TimeSpan Timeout { get;  set; }
    string VoiceId { get;  set; }
  static class SpeechGeneratorExtensions
    static Task StreamSpeechAsync(ISpeechGenerator speechGenerator, SpeechGeneratorConfig config, Func<AudioContainer, Task> onAudio, CancellationToken cancellationToken = null)
  enum SpeechGeneratorModel
    AzureSpeechService
    OpenAITts1
    OpenAITts1Hd
    Gpt4OmniMiniTts
    ElevenFlash2
    ElevenTurbo2
    ElevenMultilingual2
    ElevenFlash25
    ElevenTurbo25
    Eleven3
    GoogleChirp3
    Gemini25FlashTts
    Gemini25ProTts
  static class SpeechGeneratorModelExtensions
    static string DisplayName(SpeechGeneratorModel model)
  static class TextFilter
    static string Filter(string text, TextFilter.Config config)

namespace Ikon.AI.SpeechRecognition
  sealed class AnalyzePronunciationConfig
    ctor()
    int ChannelCount { get;  set; }
    string Language { get;  set; }
    string ReferenceText { get;  set; }
    int SampleRate { get;  set; }
    float[] Samples { get;  set; }
    TimeSpan Timeout { get;  set; }
  sealed class Pronunciation.Break
    ctor()
    int BreakLength { get;  init; }
    List<string> ErrorTypes { get;  init; }
    Pronunciation.MissingBreak MissingBreak { get;  init; }
    Pronunciation.UnexpectedBreak UnexpectedBreak { get;  init; }
  sealed class SpeechRecognizerAdapter.Config
    ctor()
    TimeSpan MaxSpeechDuration { get;  set; }
    SpeechRecognizerAdapter.Mode Mode { get;  set; }
    TimeSpan RecognitionInterval { get;  set; }
    TimeSpan RequestTimeout { get;  set; }
    TimeSpan SilenceDuration { get;  set; }
    float SilenceThreshold { get;  set; }
  sealed class Pronunciation.Feedback
    ctor()
    Pronunciation.Prosody Prosody { get;  init; }
  interface ISpeechRecognizer : IDisposable, ISpeechRecognizerInfo
    int ChannelCount { get; }
    int SampleRate { get; }
    abstract Task<Pronunciation.Result> AnalyzePronunciationAsync(AnalyzePronunciationConfig config, CancellationToken cancellationToken = null)
    abstract Task<string> RecognizeBatchSpeechAsync(RecognizeSpeechConfig config, CancellationToken cancellationToken = null)
    abstract IAsyncEnumerable<string> RecognizeContinuousSpeechAsync(RecognizeContinuousSpeechConfig config, IAsyncEnumerable<float[]> samples, CancellationToken cancellationToken = null)
  interface ISpeechRecognizerInfo
    bool SupportsBatchRecognition { get; }
    bool SupportsContinuousRecognition { get; }
    bool SupportsPronunciationAnalysis { get; }
  sealed class Pronunciation.Intonation
    ctor()
    List<string> ErrorTypes { get;  init; }
    Pronunciation.Monotone Monotone { get;  init; }
  sealed class Pronunciation.MissingBreak
    ctor()
    double Confidence { get;  init; }
  enum SpeechRecognizerAdapter.Mode
    GrowingWindow
    SlidingWindow
    SilenceTriggered
  sealed class Pronunciation.Monotone
    ctor()
    double SyllablePitchDeltaConfidence { get;  init; }
  sealed class Pronunciation.NBest
    ctor()
    double Confidence { get;  init; }
    string Display { get;  init; }
    string ITN { get;  init; }
    string Lexical { get;  init; }
    string MaskedITN { get;  init; }
    Pronunciation.PronunciationAssessment PronunciationAssessment { get;  init; }
    List<Pronunciation.Word> Words { get;  init; }
  sealed class Pronunciation.Phoneme
    ctor()
    long Duration { get;  init; }
    long Offset { get;  init; }
    Pronunciation.PhonemePronunciationAssessment PronunciationAssessment { get;  init; }
    string Text { get;  init; }
  sealed class Pronunciation.PhonemePronunciationAssessment
    ctor()
    double AccuracyScore { get;  init; }
  static class Pronunciation
  sealed class Pronunciation.PronunciationAssessment
    ctor()
    double AccuracyScore { get;  init; }
    double CompletenessScore { get;  init; }
    double FluencyScore { get;  init; }
    double PronScore { get;  init; }
    double ProsodyScore { get;  init; }
  sealed class Pronunciation.Prosody
    ctor()
    Pronunciation.Break Break { get;  init; }
    Pronunciation.Intonation Intonation { get;  init; }
  sealed class RecognizeContinuousSpeechConfig
    ctor()
    string[] CandidateLanguages { get;  set; }
    int ChannelCount { get;  set; }
    string Language { get;  set; }
    int SampleRate { get;  set; }
  sealed class RecognizeSpeechConfig
    ctor()
    int ChannelCount { get;  set; }
    string Language { get;  set; }
    string Prompt { get;  set; }
    int SampleRate { get;  set; }
    float[] Samples { get;  set; }
    double Temperature { get;  set; }
    TimeSpan Timeout { get;  set; }
  sealed class Pronunciation.Result
    ctor()
    int Channel { get;  init; }
    string DisplayText { get;  init; }
    long Duration { get;  init; }
    string Id { get;  init; }
    List<Pronunciation.NBest> NBest { get;  init; }
    long Offset { get;  init; }
    string RecognitionStatus { get;  init; }
    double SNR { get;  init; }
  sealed class SpeechRecognizer : IDisposable, ISpeechRecognizer, ISpeechRecognizerInfo
    ctor(string modelName, IReadOnlyList<ModelRegion> regions = null)
    ctor(SpeechRecognizerModel model, IReadOnlyList<ModelRegion> regions = null)
    int ChannelCount { get; }
    int SampleRate { get; }
    bool SupportsBatchRecognition { get; }
    bool SupportsContinuousRecognition { get; }
    bool SupportsPronunciationAnalysis { get; }
    Task<Pronunciation.Result> AnalyzePronunciationAsync(AnalyzePronunciationConfig config, CancellationToken cancellationToken = null)
    void Dispose()
    static SpeechRecognizerCapabilities GetCapabilities(SpeechRecognizerModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(SpeechRecognizerModel model)
    Task<string> RecognizeBatchSpeechAsync(RecognizeSpeechConfig config, CancellationToken cancellationToken = null)
    IAsyncEnumerable<string> RecognizeContinuousSpeechAsync(RecognizeContinuousSpeechConfig config, IAsyncEnumerable<float[]> samples, CancellationToken cancellationToken = null)
  sealed class SpeechRecognizerAdapter : IDisposable, ISpeechRecognizer, ISpeechRecognizerInfo
    ctor(ISpeechRecognizer speechRecognizer, SpeechRecognizerAdapter.Config config = null)
    int ChannelCount { get; }
    int SampleRate { get; }
    bool SupportsBatchRecognition { get; }
    bool SupportsContinuousRecognition { get; }
    bool SupportsPronunciationAnalysis { get; }
    Task<Pronunciation.Result> AnalyzePronunciationAsync(AnalyzePronunciationConfig config, CancellationToken cancellationToken = null)
    void Dispose()
    Task<string> RecognizeBatchSpeechAsync(RecognizeSpeechConfig config, CancellationToken cancellationToken = null)
    IAsyncEnumerable<string> RecognizeContinuousSpeechAsync(RecognizeContinuousSpeechConfig config, IAsyncEnumerable<float[]> samples, CancellationToken cancellationToken = null)
  sealed class SpeechRecognizerCapabilities : ISpeechRecognizerInfo
    ctor()
    bool SupportsBatchRecognition { get;  init; }
    bool SupportsContinuousRecognition { get;  init; }
    bool SupportsPronunciationAnalysis { get;  init; }
  enum SpeechRecognizerModel
    AzureSpeechService
    Whisper2
    WhisperLarge3
    WhisperLarge3Turbo
    Gpt4OmniTranscribe
    Gpt4OmniMiniTranscribe
    DeepgramNova3General
    AssemblyAIUniversalStreaming
    VoxtralMiniTranscribe2
  static class SpeechRecognizerModelExtensions
    static string DisplayName(SpeechRecognizerModel model)
  sealed class Pronunciation.Syllable
    ctor()
    long Duration { get;  init; }
    string Grapheme { get;  init; }
    long Offset { get;  init; }
    Pronunciation.SyllablePronunciationAssessment PronunciationAssessment { get;  init; }
    string Text { get;  init; }
  sealed class Pronunciation.SyllablePronunciationAssessment
    ctor()
    double AccuracyScore { get;  init; }
  sealed class Pronunciation.UnexpectedBreak
    ctor()
    double Confidence { get;  init; }
  sealed class Pronunciation.Word
    ctor()
    long Duration { get;  init; }
    long Offset { get;  init; }
    List<Pronunciation.Phoneme> Phonemes { get;  init; }
    Pronunciation.WordPronunciationAssessment PronunciationAssessment { get;  init; }
    List<Pronunciation.Syllable> Syllables { get;  init; }
    string Text { get;  init; }
  sealed class Pronunciation.WordPronunciationAssessment
    ctor()
    double AccuracyScore { get;  init; }
    string ErrorType { get;  init; }
    Pronunciation.Feedback Feedback { get;  init; }

namespace Ikon.AI.Storage
  class KeywordIndex
    ctor()
    Task Add(string word, string link)
    static KeywordIndex Deserialize(Stream stream)
    Task InitializeAsync()
    void RemoveTooCommonTerms(double threshold = 0.5, int minDocumentCount = 5)
    List<KeywordSearchResult> Search(string words)
    void Serialize(Stream stream)
  struct KeywordSearchResult
    ctor(string link, float score)
    string Link
    float Score
  enum Metric
    DotProduct
    CosineSimilarity
    EuclideanDistance
  struct Result<T>
    ctor(int key, float score, T value)
    int Key
    float Score
    T Value
  class VectorDatabase
    ctor()
    Task CreateCollectionAsync(string collectionName, EmbeddingModel model)
    Task<int> GetDataItemCount(string collectionName)
    Task RemoveAsync(string collectionName, IEnumerable<string> tags)
    Task<List<Result<object>>> SearchAsync(string collectionName, float[] queryVector, int maxItems, float threshold, Metric metric, Func<IEnumerable<string>, bool> tagsFilter = null)
    Task<List<Result<object>>> SearchAsync(string collectionName, string query, int maxItems, float threshold, Metric metric, Func<IEnumerable<string>, bool> tagsFilter = null)
    Task<List<Result<T>>> SearchAsync<T>(string collectionName, string query, int maxItems, float threshold, Metric metric, Func<IEnumerable<string>, bool> tagsFilter = null)
    Task<List<Result<T>>> SearchAsync<T>(string collectionName, float[] queryVector, int maxItems, float threshold, Metric metric, Func<IEnumerable<string>, bool> tagsFilter = null)
    Task<int> SetAsync(string collectionName, int? key, string text, object value, IEnumerable<string> tags = null)
    Task<int> SetAsync(string collectionName, int? key, float[] vector, object value, IEnumerable<string> tags = null)

namespace Ikon.AI.Utils
  static class HttpUtils
    static Task<string> DumpHttpRequest(HttpRequestMessage request)
    static Task<string> GetErrorMessage(HttpRequestException exception, HttpResponseMessage response, string modelName)
    static Task<int> GetHttpRequestSize(HttpRequestMessage request)
  static class ImageUtils
    static ValueTuple<int, int> GetImageDimensions(byte[] buffer)

namespace Ikon.AI.VideoEnhancement
  interface IVideoEnhancer : IDisposable
    abstract Task<VideoEnhancerResult> EnhanceVideoAsync(VideoEnhancerConfig config, CancellationToken cancellationToken = null)
  sealed class VideoEnhancer : IDisposable, IVideoEnhancer
    ctor(string modelName, IReadOnlyList<ModelRegion> regions = null)
    ctor(VideoEnhancerModel model, IReadOnlyList<ModelRegion> regions = null)
    void Dispose()
    Task<VideoEnhancerResult> EnhanceVideoAsync(VideoEnhancerConfig config, CancellationToken cancellationToken = null)
    static VideoEnhancerCapabilities GetCapabilities(VideoEnhancerModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(VideoEnhancerModel model)
  sealed class VideoEnhancerCapabilities
    ctor()
  sealed class VideoEnhancerConfig
    ctor()
    int? EndFrame { get;  set; }
    string MimeType { get;  set; }
    int? StartFrame { get;  set; }
    int? TargetFps { get;  set; }
    TimeSpan Timeout { get;  set; }
    byte[] VideoData { get;  set; }
    string VideoUrl { get;  set; }
  enum VideoEnhancerModel
    TensorPixFpsBoost
    TensorPixUpscale2xUltra4
    TensorPixUpscale2xUltra41
    TensorPixUpscale4xUltra4
  static class VideoEnhancerModelExtensions
    static string DisplayName(VideoEnhancerModel model)
  sealed class VideoEnhancerResult
    ctor()
    int? OutputFps { get;  init; }
    long? OutputSizeBytes { get;  init; }
    string Url { get;  init; }

namespace Ikon.AI.VideoGeneration
  interface IVideoGenerator : IDisposable, IVideoGeneratorInfo
    abstract Task<VideoGeneratorResult> GenerateVideoAsync(VideoGeneratorConfig config, CancellationToken cancellationToken = null)
  interface IVideoGeneratorInfo
    int MaxInputImages { get; }
    VideoGeneratorResolutionMode ResolutionMode { get; }
    IReadOnlyList<int> SupportedLengths { get; }
    IReadOnlyList<VideoGeneratorResolution> SupportedResolutions { get; }
    bool SupportsAudio { get; }
    bool SupportsImageToVideo { get; }
    bool SupportsMultipleImages { get; }
    bool SupportsNegativePrompt { get; }
    bool SupportsSeed { get; }
    bool SupportsTailImage { get; }
    bool SupportsTextToVideo { get; }
  sealed class VideoGeneratorConfig.InputImage
    ctor()
    byte[] Data { get;  set; }
    string MimeType { get;  set; }
    string Url { get;  set; }
  sealed class VideoGenerator : IDisposable, IVideoGenerator, IVideoGeneratorInfo
    ctor(string modelName, IReadOnlyList<ModelRegion> regions = null)
    ctor(VideoGeneratorModel model, IReadOnlyList<ModelRegion> regions = null)
    int MaxInputImages { get; }
    VideoGeneratorResolutionMode ResolutionMode { get; }
    IReadOnlyList<int> SupportedLengths { get; }
    IReadOnlyList<VideoGeneratorResolution> SupportedResolutions { get; }
    bool SupportsAudio { get; }
    bool SupportsImageToVideo { get; }
    bool SupportsMultipleImages { get; }
    bool SupportsNegativePrompt { get; }
    bool SupportsSeed { get; }
    bool SupportsTailImage { get; }
    bool SupportsTextToVideo { get; }
    void Dispose()
    Task<VideoGeneratorResult> GenerateVideoAsync(VideoGeneratorConfig config, CancellationToken cancellationToken = null)
    static VideoGeneratorCapabilities GetCapabilities(VideoGeneratorModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(VideoGeneratorModel model)
  enum VideoGeneratorAspectRatio
    Ratio16x9
    Ratio9x16
    Ratio4x3
    Ratio3x4
    Ratio1x1
  sealed class VideoGeneratorCapabilities : IVideoGeneratorInfo
    ctor()
    int MaxInputImages { get;  init; }
    VideoGeneratorResolutionMode ResolutionMode { get;  init; }
    IReadOnlyList<int> SupportedLengths { get;  init; }
    IReadOnlyList<VideoGeneratorResolution> SupportedResolutions { get;  init; }
    bool SupportsAudio { get;  init; }
    bool SupportsImageToVideo { get;  init; }
    bool SupportsMultipleImages { get;  init; }
    bool SupportsNegativePrompt { get;  init; }
    bool SupportsSeed { get;  init; }
    bool SupportsTailImage { get;  init; }
    bool SupportsTextToVideo { get;  init; }
  sealed class VideoGeneratorConfig
    ctor()
    VideoGeneratorAspectRatio AspectRatio { get;  set; }
    bool? GenerateAudio { get;  set; }
    List<VideoGeneratorConfig.InputImage> InputImages { get;  set; }
    int Length { get;  set; }
    string NegativePrompt { get;  set; }
    string Prompt { get;  set; }
    VideoGeneratorResolution Resolution { get;  set; }
    int? Seed { get;  set; }
    TimeSpan Timeout { get;  set; }
  enum VideoGeneratorModel
    Hailuo23
    Hailuo23Fast
    Kling26
    KlingVideoO1
    LumaRay20
    LumaRay20Flash
    Pika22
    Pixverse55
    Pollo20
    RunwayGen4
    Seedance15Pro
    Sora2
    Sora2Pro
    Veo31
    Veo31Fast
    ViduQ2Pro
    ViduQ2Turbo
    Wan26
  static class VideoGeneratorModelExtensions
    static string DisplayName(VideoGeneratorModel model)
  enum VideoGeneratorResolution
    Resolution360p
    Resolution480p
    Resolution540p
    Resolution720p
    Resolution768p
    Resolution1080p
    Resolution4K
  enum VideoGeneratorResolutionMode
    Discrete
    AspectRatio
  sealed class VideoGeneratorResult
    ctor()
    string Url { get;  init; }

namespace Ikon.AI.WebScraping
  sealed class Cookie
    ctor()
    string Domain { get;  set; }
    double ExpirationDate { get;  set; }
    bool HostOnly { get;  set; }
    bool HttpOnly { get;  set; }
    int Id { get;  set; }
    string Name { get;  set; }
    string Path { get;  set; }
    string SameSite { get;  set; }
    bool Secure { get;  set; }
    bool Session { get;  set; }
    string StoreId { get;  set; }
    string Value { get;  set; }
  interface IWebScraper : IDisposable, IWebScraperInfo
    abstract Task<List<PageResult>> ScrapeMultiplePagesAsync(MultiPageScrapeConfig config, CancellationToken cancellationToken = null)
    abstract Task<PageResult> ScrapeSinglePageAsync(SinglePageScrapeConfig config, CancellationToken cancellationToken = null)
    abstract Task<ScreenshotResult> TakeScreenshotAsync(ScreenshotConfig config, CancellationToken cancellationToken = null)
  interface IWebScraperInfo
    bool SupportsMultiPageScraping { get; }
    bool SupportsScreenshotting { get; }
    bool SupportsSinglePageScraping { get; }
  sealed class MultiPageScrapeConfig
    ctor()
    bool AddGivenUrlsToWhitelist { get;  set; }
    bool AllowOnlyGivenUrls { get;  set; }
    List<Cookie> Cookies { get;  set; }
    string CountryCode { get;  set; }
    int DelayMs { get;  set; }
    string ExcludedCSSElements { get;  set; }
    List<string> ExcludedLineStarts { get;  set; }
    List<string> ExcludedWholeLines { get;  set; }
    bool Headless { get;  set; }
    bool IgnoreRobotsTxt { get;  set; }
    bool IncludeLinkedFiles { get;  set; }
    string IncludedCSSElements { get;  set; }
    string JavaScript { get;  set; }
    bool LoadResources { get;  set; }
    string Locale { get;  set; }
    int MaxDepth { get;  set; }
    int MaxPages { get;  set; }
    WebScraperOutputFormat OutputFormat { get;  set; }
    string PlaywrightScript { get;  set; }
    bool RerunIfGivenUrlsMissing { get;  set; }
    TimeSpan SinglePageTimeout { get;  set; }
    TimeSpan Timeout { get;  set; }
    List<string> UrlBlacklist { get;  set; }
    List<string> UrlWhitelist { get;  set; }
    List<string> Urls { get;  set; }
    bool UseReadability { get;  set; }
    bool UseSitemap { get;  set; }
    bool UseSitemapOnly { get;  set; }
    bool UseStreaming { get;  set; }
    TimeSpan WaitAfter { get;  set; }
    WebScraperModel WebScraperModel { get;  set; }
  sealed class PageResult
    ctor()
    string Content { get;  init; }
    List<string> Keywords { get;  init; }
    string Mimetype { get;  init; }
    string Title { get;  init; }
    string Url { get;  init; }
  sealed class ScreenshotConfig
    ctor()
    List<Cookie> Cookies { get;  set; }
    string CountryCode { get;  set; }
    bool FullPage { get;  set; }
    bool Headless { get;  set; }
    int Height { get;  set; }
    string JavaScript { get;  set; }
    string Locale { get;  set; }
    string PlaywrightScript { get;  set; }
    TimeSpan Timeout { get;  set; }
    string Url { get;  set; }
    bool UseCaptchaSolver { get;  set; }
    TimeSpan WaitAfter { get;  set; }
    int Width { get;  set; }
  sealed class ScreenshotResult
    ctor()
    byte[] Data { get;  init; }
    string MimeType { get;  init; }
  sealed class SinglePageScrapeConfig
    ctor()
    List<Cookie> Cookies { get;  set; }
    string CountryCode { get;  set; }
    string ExcludedCSSElements { get;  set; }
    List<string> ExcludedLineStarts { get;  set; }
    List<string> ExcludedWholeLines { get;  set; }
    bool Headless { get;  set; }
    bool IncludeLinkedFiles { get;  set; }
    string IncludedCSSElements { get;  set; }
    string JavaScript { get;  set; }
    bool LoadResources { get;  set; }
    string Locale { get;  set; }
    WebScraperOutputFormat OutputFormat { get;  set; }
    string PlaywrightScript { get;  set; }
    TimeSpan Timeout { get;  set; }
    string Url { get;  set; }
    bool UseCaptchaSolver { get;  set; }
    bool UseReadability { get;  set; }
    TimeSpan WaitAfter { get;  set; }
    WebScraperModel WebScraperModel { get;  set; }
  sealed class WebScraper : IDisposable, IWebScraper, IWebScraperInfo
    ctor(string modelName, bool useLocalCache = false)
    ctor(WebScraperModel model, bool useLocalCache = false)
    ctor(string modelName, IReadOnlyList<ModelRegion> regions, bool useLocalCache = false)
    ctor(WebScraperModel model, IReadOnlyList<ModelRegion> regions, bool useLocalCache = false)
    bool SupportsMultiPageScraping { get; }
    bool SupportsScreenshotting { get; }
    bool SupportsSinglePageScraping { get; }
    void Dispose()
    static WebScraperCapabilities GetCapabilities(WebScraperModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(WebScraperModel model)
    Task<List<PageResult>> ScrapeMultiplePagesAsync(MultiPageScrapeConfig config, CancellationToken cancellationToken = null)
    Task<PageResult> ScrapeSinglePageAsync(SinglePageScrapeConfig config, CancellationToken cancellationToken = null)
    Task<ScreenshotResult> TakeScreenshotAsync(ScreenshotConfig config, CancellationToken cancellationToken = null)
  sealed class WebScraperCapabilities : IWebScraperInfo
    ctor()
    bool SupportsMultiPageScraping { get;  init; }
    bool SupportsScreenshotting { get;  init; }
    bool SupportsSinglePageScraping { get;  init; }
  enum WebScraperModel
    Spider
    Jina
    LocalPuppeteer
    LocalNodriver
    LocalPlaywright
  static class WebScraperModelExtensions
    static string DisplayName(WebScraperModel model)
  enum WebScraperOutputFormat
    Text
    Markdown
    Html

namespace Ikon.AI.WebSearching
  interface IWebSearcher : IDisposable, IWebSearcherInfo
    abstract Task<List<SearchResult>> SearchImagesAsync(SearchConfig config, CancellationToken cancellationToken = null)
    abstract Task<List<SearchResult>> SearchPagesAsync(SearchConfig config, CancellationToken cancellationToken = null)
  interface IWebSearcherInfo
    bool SupportsImageSearching { get; }
  sealed class SearchConfig
    ctor()
    string CountryCode { get;  set; }
    string InSiteUrl { get;  set; }
    string Language { get;  set; }
    int MaxResults { get;  set; }
    WebSearcherOutputFormat OutputFormat { get;  set; }
    string Query { get;  set; }
    TimeSpan Timeout { get;  set; }
  sealed class SearchResult
    ctor()
    string Content { get;  init; }
    List<string> Keywords { get;  init; }
    string Mimetype { get;  init; }
    string Title { get;  init; }
    string Url { get;  init; }
  sealed class WebSearcher : IDisposable, IWebSearcher, IWebSearcherInfo
    ctor(string modelName, IReadOnlyList<ModelRegion> regions = null)
    ctor(WebSearcherModel model, IReadOnlyList<ModelRegion> regions = null)
    bool SupportsImageSearching { get; }
    void Dispose()
    static WebSearcherCapabilities GetCapabilities(WebSearcherModel model)
    static IReadOnlyList<ModelRegion> GetSupportedRegions(WebSearcherModel model)
    Task<List<SearchResult>> SearchImagesAsync(SearchConfig config, CancellationToken cancellationToken = null)
    Task<List<SearchResult>> SearchPagesAsync(SearchConfig config, CancellationToken cancellationToken = null)
  sealed class WebSearcherCapabilities : IWebSearcherInfo
    ctor()
    bool SupportsImageSearching { get;  init; }
  enum WebSearcherModel
    Spider
    Jina
    Google
    GoogleLight
    GoogleLightImages
    Amazon
    Bing
    BingImages
    Youtube
  static class WebSearcherModelExtensions
    static string DisplayName(WebSearcherModel model)
  enum WebSearcherOutputFormat
    Text
    Markdown
    Html
