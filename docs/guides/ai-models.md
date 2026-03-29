# AI Models & LLM

## AI Models & LLM Connection

LLM model selection, connection configuration, and core AI infrastructure.

---

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
