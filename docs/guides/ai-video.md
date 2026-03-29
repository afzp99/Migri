# AI Video

## AI Video

### Video Generation

```csharp
using var generator = new VideoGenerator(VideoGeneratorModel.Veo2);
var result = await generator.GenerateVideoAsync(new VideoGeneratorConfig
{
    Prompt = "A timelapse of a flower blooming",
    AspectRatio = VideoAspectRatio.Landscape16x9,
    DurationSeconds = 5
});
// result.Data (byte[]), result.MimeType
```

### Video Enhancement

```csharp
using var enhancer = new VideoEnhancer(VideoEnhancerModel.Veo2);
var result = await enhancer.EnhanceVideoAsync(new VideoEnhancerConfig
{
    InputData = videoBytes,
    InputMimeType = "video/mp4",
    Prompt = "Enhance colors and stabilize"
});
```

---

# Ikon.AI Public API
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
