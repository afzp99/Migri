# AI Web & Data

## AI Web & Data Services

### Web Search

```csharp
using var searcher = new WebSearcher(WebSearcherModel.Google);
var results = await searcher.SearchAsync(new WebSearcherConfig { Query = "latest AI news" });
foreach (var result in results) { /* result.Title, result.Url, result.Snippet */ }
```

### Embeddings

```csharp
using var embedder = new EmbeddingGenerator(EmbeddingModel.TextEmbedding3Small);
var embeddings = await embedder.GenerateEmbeddingsAsync(["Hello world", "Goodbye"], EmbeddingType.Document);
// embeddings[0] is float[] vector
```

### Other Data Services

Available: `WebScraper`, `Classifier`, `OCR`, `FileConverter`, `Reranker`, `Retriever`. Refer to generated API docs for model listings and configuration.

---

# Ikon.AI Public API
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
