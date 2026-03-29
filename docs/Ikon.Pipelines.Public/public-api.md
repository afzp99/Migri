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
