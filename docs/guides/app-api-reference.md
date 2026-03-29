# App API Reference

## App API Reference

Full API reference for Ikon.App and Ikon.Common.

---

# Ikon.App Public API

namespace Ikon.App
  sealed class AppAttribute : Attribute
    ctor(string name = null, string productId = null, string description = null, int version = 1, string guid = null, UserType userType = Machine, Opcode receiveOpcodeGroups = GROUP_ALL, Opcode sendOpcodeGroups = GROUP_ALL, string[] dependencies = null)
    int AppVersion { get; }
    string[] Dependencies { get; }
    string Description { get; }
    string Guid { get; }
    string Name { get; }
    string ProductId { get; }
    Opcode ReceiveOpcodeGroups { get; }
    Opcode SendOpcodeGroups { get; }
    UserType UserType { get; }
    int Version { get; }
    PluginAttribute ToPluginAttribute(Type owner)
  static class AppDatabaseConnection
    static DbConnection Create(IAppBase host, string databaseName)
    static DbConnection Create(DatabaseConnectionInfo dbInfo)
  sealed class AppEndpointHost : IAsyncDisposable
    ctor(IAppBase host, string endpointName, TimeSpan? webSocketKeepAliveInterval = null)
    int LocalPort { get; }
    string PublicUrl { get; }
    ValueTask DisposeAsync()
    void MapGet(string pattern, Func<HttpContext, Task> handler)
    void MapPost(string pattern, Func<HttpContext, Task> handler)
    void MapWebSocket(string pattern, Func<HttpContext, WebSocket, Task> handler)
    Task StartAsync(CancellationToken cancellationToken = null)
    Task StopAsync(CancellationToken cancellationToken = null)
  class App<TConfig> : BasePlugin<App<TConfig>, WrapperConfig<TConfig>>, IAppBase, IApp<TConfig>
    ctor(Type appInstanceType, WrapperConfig<TConfig> userConfig, PluginAttribute pluginAttribute, string argsJson)
    BackgroundWork BackgroundWork { get; }
    TConfig Config { get; }
    string DataDirectory { get; }
    IReadOnlyList<DatabaseConnectionInfo> Databases { get; }
    Navigation Navigation { get; }
    ReactiveGlobalState ReactiveGlobalState { get; }
    ReactiveRoot ReactiveRoot { get; }
    event AsyncEventHandler<ClientJoinedEventArgs> ClientJoinedAsync
    event AsyncEventHandler<ClientLeftEventArgs> ClientLeftAsync
    event AsyncEventHandler<MessageReceivedEventArgs> MessageReceivedAsync
    event AsyncEventHandler<StartingEventArgs> StartingAsync
    event AsyncEventHandler<StoppingEventArgs> StoppingAsync
  class App<TSessionIdentity, TClientParameters> : BasePlugin<App<TSessionIdentity, TClientParameters>, BasePluginConfig>, IAppBase, IApp<TSessionIdentity, TClientParameters>
    ctor(Type appInstanceType, PluginAttribute pluginAttribute, string argsJson)
    BackgroundWork BackgroundWork { get; }
    IClientCollection<TClientParameters> Clients { get; }
    string DataDirectory { get; }
    IReadOnlyList<DatabaseConnectionInfo> Databases { get; }
    Navigation Navigation { get; }
    ReactiveGlobalState ReactiveGlobalState { get; }
    ReactiveRoot ReactiveRoot { get; }
    TSessionIdentity SessionIdentity { get; }
    event AsyncEventHandler<ClientJoinedEventArgs> ClientJoinedAsync
    event AsyncEventHandler<ClientLeftEventArgs> ClientLeftAsync
    event AsyncEventHandler<MessageReceivedEventArgs> MessageReceivedAsync
    event AsyncEventHandler<StartingEventArgs> StartingAsync
    event AsyncEventHandler<StoppingEventArgs> StoppingAsync
  delegate AsyncEventHandler<TEventArgs> where TEventArgs : EventArgs
    Task AsyncEventHandler`1<TEventArgs>(TEventArgs e)
  class Audio
    ctor(IAppBase host)
    AudioEncoderOptions DefaultEncoderOptions { get;  set; }
    AudioMetrics Metrics { get; }
    SpeechMixer SpeechMixer { get; }
    ValueTask CloseAllAsync()
    ValueTask CloseAsync(string streamId = null)
    AudioOutputStreamInfo GetOutputStreamInfo(string streamId = null)
    ValueTask SendAsync(ReadOnlyMemory<float> samples, int sampleRate, int channelCount, bool isFirst, bool isLast, string streamId = null, TimeSpan totalDuration = null, AudioEncoderOptions encoderOptions = null, IReadOnlyList<int> targetIds = null)
    void SendSpeech(AudioContainer audio, IReadOnlyList<IAudioEffect> effects = null, IReadOnlyList<IAudioAnalyzer> analyzers = null, IReadOnlyList<int> targetIds = null)
    void SendSpeech(string speechEventId, ReadOnlySpan<float> samples, int sampleRate, int channelCount, bool isFirst, bool isLast, IReadOnlyList<IAudioEffect> effects = null, IReadOnlyList<IAudioAnalyzer> analyzers = null, IReadOnlyList<int> targetIds = null)
    event AsyncEventHandler<AudioInputFrameEventArgs> AudioInputFrameAsync
    event AsyncEventHandler<AudioInputStreamBeginEventArgs> AudioInputStreamBeginAsync
    event AsyncEventHandler<AudioInputStreamEndEventArgs> AudioInputStreamEndAsync
  class AudioInputFrameEventArgs : EventArgs
    ctor(string streamId, Context clientContext, float[] samples, bool isFirst, bool isLast, TimeSpan totalDuration)
    Context ClientContext { get; }
    int ClientSessionId { get; }
    bool IsFirst { get; }
    bool IsLast { get; }
    float[] Samples { get; }
    string StreamId { get; }
    TimeSpan TotalDuration { get;  set; }
    string UserId { get; }
  class AudioInputStreamBeginEventArgs : EventArgs
    ctor(string streamId, string description, string sourceType, int sampleRate, int channelCount, Context clientContext, int trackId)
    int ChannelCount { get; }
    Context ClientContext { get; }
    int ClientSessionId { get; }
    string Description { get; }
    int SampleRate { get; }
    string SourceType { get; }
    string StreamId { get; }
    AudioInputStreamingMode StreamingMode { get;  set; }
    int TrackId { get; }
    string UserId { get; }
  class AudioInputStreamEndEventArgs : EventArgs
    ctor(string streamId, Context clientContext)
    Context ClientContext { get; }
    int ClientSessionId { get; }
    string StreamId { get; }
    string UserId { get; }
  enum AudioInputStreamingMode
    Streaming
    DelayUntilTotalDurationKnown
    DelayUntilIsLast
  class AudioOutputStreamInfo : IEquatable<AudioOutputStreamInfo>
    ctor(string StreamId, int TrackId, AudioCodec Codec, int SampleRate, int ChannelCount)
    int ChannelCount { get;  init; }
    AudioCodec Codec { get;  init; }
    int SampleRate { get;  init; }
    string StreamId { get;  init; }
    int TrackId { get;  init; }
  class BackgroundWork
    ValueTask<IAsyncDisposable> StartAsync()
    ValueTask StopAsync()
  sealed class ClientAudioCaptureOptions : IEquatable<ClientAudioCaptureOptions>
    ctor()
    bool? AutoGainControl { get;  init; }
    int? Bitrate { get;  init; }
    static ClientAudioCaptureOptions Default { get; }
    string DeviceId { get;  init; }
    bool? EchoCancellation { get;  init; }
    bool? NoiseSuppression { get;  init; }
    IReadOnlyList<int> TargetIds { get;  init; }
  class ClientCollection<TClientParameters> : IClientCollection<TClientParameters>
    ctor()
    int Count { get; }
    IClient<TClientParameters> Item { get; }
  sealed class ClientContact : IEquatable<ClientContact>
    ctor(IReadOnlyList<string> Names, IReadOnlyList<string> Emails, IReadOnlyList<string> Phones)
    IReadOnlyList<string> Emails { get;  init; }
    IReadOnlyList<string> Names { get;  init; }
    IReadOnlyList<string> Phones { get;  init; }
  static class ClientFunctions
    static Task<ClientImageCapture> CaptureImageAsync(int targetId, ClientImageCaptureOptions options = null, CancellationToken cancellationToken = null)
    static Task<ClientImageCapture> CaptureImageAsync(ClientImageCaptureOptions options = null, CancellationToken cancellationToken = null)
    static Task<bool> ExitFullscreenAsync(int targetId, CancellationToken cancellationToken = null)
    static Task<bool> ExitFullscreenAsync(CancellationToken cancellationToken = null)
    static Task<int?> GetBatteryLevelAsync(int targetId, CancellationToken cancellationToken = null)
    static Task<int?> GetBatteryLevelAsync(CancellationToken cancellationToken = null)
    static Task<string> GetLanguageAsync(int targetId, CancellationToken cancellationToken = null)
    static Task<string> GetLanguageAsync(CancellationToken cancellationToken = null)
    static Task<IReadOnlyList<ClientMediaDevice>> GetMediaDevicesAsync(int targetId, CancellationToken cancellationToken = null)
    static Task<IReadOnlyList<ClientMediaDevice>> GetMediaDevicesAsync(CancellationToken cancellationToken = null)
    static Task<string> GetNetworkTypeAsync(int targetId, CancellationToken cancellationToken = null)
    static Task<string> GetNetworkTypeAsync(CancellationToken cancellationToken = null)
    static Task<string> GetThemeAsync(int targetId, CancellationToken cancellationToken = null)
    static Task<string> GetThemeAsync(CancellationToken cancellationToken = null)
    static Task<string> GetTimezoneAsync(int targetId, CancellationToken cancellationToken = null)
    static Task<string> GetTimezoneAsync(CancellationToken cancellationToken = null)
    static Task<string> GetUrlAsync(int targetId, CancellationToken cancellationToken = null)
    static Task<string> GetUrlAsync(CancellationToken cancellationToken = null)
    static Task<string> GetVisibilityAsync(int targetId, CancellationToken cancellationToken = null)
    static Task<string> GetVisibilityAsync(CancellationToken cancellationToken = null)
    static Task<bool> KeepScreenAwakeAsync(int targetId, bool enabled, CancellationToken cancellationToken = null)
    static Task<bool> KeepScreenAwakeAsync(bool enabled, CancellationToken cancellationToken = null)
    static Task<bool> LogoutAsync(int targetId, CancellationToken cancellationToken = null)
    static Task<bool> LogoutAsync(CancellationToken cancellationToken = null)
    static Task<string> PlaySoundAsync(int targetId, string url, double volume = 1, bool loop = false, CancellationToken cancellationToken = null)
    static Task<string> PlaySoundAsync(int targetId, byte[] data, string mimeType, double volume = 1, bool loop = false, CancellationToken cancellationToken = null)
    static Task<string> PlaySoundAsync(string url, double volume = 1, bool loop = false, CancellationToken cancellationToken = null)
    static Task<string> PlaySoundAsync(byte[] data, string mimeType, double volume = 1, bool loop = false, CancellationToken cancellationToken = null)
    static Task<bool> RequestFullscreenAsync(int targetId, CancellationToken cancellationToken = null)
    static Task<bool> RequestFullscreenAsync(CancellationToken cancellationToken = null)
    static Task<bool> ScrollToAsync(int targetId, double x, double y, bool smooth = false, CancellationToken cancellationToken = null)
    static Task<bool> ScrollToAsync(double x, double y, bool smooth = false, CancellationToken cancellationToken = null)
    static Task<bool> SetThemeAsync(int targetId, string theme, bool persist = true, CancellationToken cancellationToken = null)
    static Task<bool> SetThemeAsync(string theme, bool persist = true, CancellationToken cancellationToken = null)
    static Task<bool> SetUrlAsync(int targetId, string url, bool replace = false, bool preserveQueryParams = false, CancellationToken cancellationToken = null)
    static Task<bool> SetUrlAsync(string url, bool replace = false, bool preserveQueryParams = false, CancellationToken cancellationToken = null)
    static Task<string> StartAudioCaptureAsync(int targetId, ClientAudioCaptureOptions options = null, CancellationToken cancellationToken = null)
    static Task<string> StartAudioCaptureAsync(ClientAudioCaptureOptions options = null, CancellationToken cancellationToken = null)
    static Task<string> StartVideoCaptureAsync(int targetId, ClientVideoCaptureSource source = Camera, ClientVideoCaptureOptions options = null, CancellationToken cancellationToken = null)
    static Task<string> StartVideoCaptureAsync(ClientVideoCaptureSource source = Camera, ClientVideoCaptureOptions options = null, CancellationToken cancellationToken = null)
    static Task<bool> StopCaptureAsync(int targetId, string streamId, CancellationToken cancellationToken = null)
    static Task<bool> StopCaptureAsync(string streamId, CancellationToken cancellationToken = null)
    static Task<bool> StopSoundAsync(int targetId, string playbackId, CancellationToken cancellationToken = null)
    static Task<bool> StopSoundAsync(string playbackId, CancellationToken cancellationToken = null)
    static Task<bool> VibrateAsync(int targetId, string pattern, CancellationToken cancellationToken = null)
    static Task<bool> VibrateAsync(string pattern, CancellationToken cancellationToken = null)
  enum ClientHardwareAcceleration
    PreferHardware
    PreferSoftware
  sealed class ClientImageCapture : IEquatable<ClientImageCapture>
    ctor(string Mime, int Width, int Height, byte[] Data)
    byte[] Data { get;  init; }
    int Height { get;  init; }
    string Mime { get;  init; }
    int Width { get;  init; }
  enum ClientImageCaptureFormat
    Jpeg
    Png
  sealed class ClientImageCaptureOptions : IEquatable<ClientImageCaptureOptions>
    ctor()
    ClientImageCaptureFormat? Format { get;  init; }
    int? Height { get;  init; }
    double? Quality { get;  init; }
    int? Width { get;  init; }
  class ClientJoinedEventArgs : EventArgs
    ctor(Context clientContext)
    Context ClientContext { get; }
    int ClientSessionId { get; }
    string UserId { get; }
  class ClientLeftEventArgs : EventArgs
    ctor(Context clientContext)
    Context ClientContext { get; }
    int ClientSessionId { get; }
    string UserId { get; }
  sealed class ClientLocation : IEquatable<ClientLocation>
    ctor(double Latitude, double Longitude, double Accuracy)
    double Accuracy { get;  init; }
    double Latitude { get;  init; }
    double Longitude { get;  init; }
  static class ClientMediaCaptureSerializer
    static string SerializeAudioOptions(ClientAudioCaptureOptions options)
    static string SerializeImageOptions(ClientImageCaptureOptions options)
    static string SerializeVideoOptions(ClientVideoCaptureOptions options)
  sealed class ClientMediaDevice : IEquatable<ClientMediaDevice>
    ctor(string DeviceId, string Kind, string Label, string GroupId)
    string DeviceId { get;  init; }
    string GroupId { get;  init; }
    string Kind { get;  init; }
    string Label { get;  init; }
  sealed class ClientProfile
    ProfileAddress Address { get; }
    string BirthDate { get; }
    string Email { get; }
    string FirstName { get; }
    string Gender { get; }
    string Id { get; }
    bool IsAdmin { get; }
    bool IsGuest { get; }
    bool IsModerator { get; }
    string Language { get; }
    string LastName { get; }
    string Name { get; }
    string PhoneNumber { get; }
    string PreferredName { get; }
    IReadOnlyList<string> Roles { get; }
    string UserId { get; }
    string VisibleName { get; }
    object GetAttribute(string key)
    TAttributes GetAttributes<TAttributes>()
    bool HasRole(UserRole role)
    bool HasRole(string role)
    bool HasRole<TRole>(TRole role)
  class ClientProfiles
    ctor(IAppBase host)
    Task AddRoleAsync(Context clientContext, UserRole role)
    Task AddRoleAsync(Context clientContext, string role)
    void ClearCache()
    Task<IReadOnlyList<ClientProfile>> FindProfilesAsync(Dictionary<string, string> filters, int maxResults = 1000)
    Task<IReadOnlyList<ClientProfile>> GetAllProfilesAsync(int maxResults = 1000)
    TAttributes GetAttributes<TAttributes>(Context clientContext)
    ClientProfile GetProfile(Context clientContext)
    bool HasRole(Context clientContext, UserRole role)
    bool HasRole(Context clientContext, string role)
    bool HasRole<TRole>(Context clientContext, TRole role)
    bool IsAdmin(Context clientContext)
    bool IsGuest(Context clientContext)
    bool IsModerator(Context clientContext)
    Task RefreshProfileAsync(Context clientContext)
    Task RefreshProfileAsync(string userId)
    Task RemoveRoleAsync(Context clientContext, UserRole role)
    Task RemoveRoleAsync(Context clientContext, string role)
    void RequireAdmin(Context clientContext)
    void RequireModerator(Context clientContext)
    void RequireRole(Context clientContext, UserRole role)
    void RequireRole(Context clientContext, string role)
    Task SetAttributesAsync<TAttributes>(Context clientContext, TAttributes attrs)
    Task SetRolesAsync(Context clientContext, IEnumerable<UserRole> roles)
    Task SetRolesAsync(Context clientContext, IEnumerable<string> roles)
    ClientProfile TryGetProfile(Context clientContext)
    ClientProfile TryGetProfile(string userId)
    Task UpdateAsync(Context clientContext, Action<ProfileData> update)
  enum ClientVideoCaptureCodec
    H264
    Vp8
    Vp9
    Av1
  sealed class ClientVideoCaptureOptions : IEquatable<ClientVideoCaptureOptions>
    ctor()
    int? Bitrate { get;  init; }
    static ClientVideoCaptureOptions DefaultCamera { get; }
    static ClientVideoCaptureOptions DefaultScreen { get; }
    string DeviceId { get;  init; }
    int? Framerate { get;  init; }
    ClientHardwareAcceleration? HardwareAcceleration { get;  init; }
    int? Height { get;  init; }
    int? KeyFrameIntervalFrames { get;  init; }
    IReadOnlyList<ClientVideoCaptureCodec> PreferredCodecs { get;  init; }
    IReadOnlyList<int> TargetIds { get;  init; }
    int? Width { get;  init; }
  enum ClientVideoCaptureSource
    Camera
    Screen
  class Client<TClientParameters> : IClient<TClientParameters>
    ctor(TClientParameters parameters)
    TClientParameters Parameters { get; }
  static class Constants
    static string DarkTheme
    static string LightTheme
  sealed class FileUploadCallbackSet
    ctor()
    Func<FileUploadChunkArgs, Task> OnChunkReceived
    Func<FileUploadCompleteArgs, Task> OnUploadComplete
    Func<FileUploadErrorArgs, Task> OnUploadError
    Func<FileUploadPreStartArgs, Task<FileUploadPreStartResult>> OnUploadPreStart
    Func<FileUploadProgressArgs, Task> OnUploadProgress
    Func<FileUploadStartArgs, Task<FileUploadStartResult>> OnUploadStart
  sealed class FileUploadChunkArgs : IEquatable<FileUploadChunkArgs>
    ctor(string UploadId, string FileName, string MimeType, long Size, byte[] Data, long BytesWritten)
    long BytesWritten { get;  init; }
    byte[] Data { get;  init; }
    string FileName { get;  init; }
    string MimeType { get;  init; }
    long Size { get;  init; }
    string UploadId { get;  init; }
  sealed class FileUploadCompleteArgs : IEquatable<FileUploadCompleteArgs>
    ctor(string UploadId, string FileName, string MimeType, long Size, string LocalTempFilePath, string AssetUri)
    string AssetUri { get;  init; }
    string FileName { get;  init; }
    string LocalTempFilePath { get;  init; }
    string MimeType { get;  init; }
    long Size { get;  init; }
    string UploadId { get;  init; }
  sealed class FileUploadErrorArgs : IEquatable<FileUploadErrorArgs>
    ctor(string UploadId, string FileName, string MimeType, long Size, string ErrorMessage)
    string ErrorMessage { get;  init; }
    string FileName { get;  init; }
    string MimeType { get;  init; }
    long Size { get;  init; }
    string UploadId { get;  init; }
  sealed class FileUploadHandler : IDisposable
    ctor(IAppBase host)
    void Dispose()
    void RegisterCallbacks(string uploadActionId, FileUploadCallbackSet callbackSet)
  sealed class FileUploadPreStartArgs : IEquatable<FileUploadPreStartArgs>
    ctor(string UploadId, string FileName, string MimeType, long Size, Func<string, Task> Cancel)
    Func<string, Task> Cancel { get;  init; }
    string FileName { get;  init; }
    string MimeType { get;  init; }
    long Size { get;  init; }
    string UploadId { get;  init; }
  sealed class FileUploadPreStartResult : IEquatable<FileUploadPreStartResult>
    ctor()
    bool Accepted { get;  set; }
    string AssetUri { get;  set; }
  sealed class FileUploadProgressArgs : IEquatable<FileUploadProgressArgs>
    ctor(string UploadId, string FileName, string MimeType, long Size, double ProgressPercentage, long BytesUploaded)
    long BytesUploaded { get;  init; }
    string FileName { get;  init; }
    string MimeType { get;  init; }
    double ProgressPercentage { get;  init; }
    long Size { get;  init; }
    string UploadId { get;  init; }
  sealed class FileUploadStartArgs : IEquatable<FileUploadStartArgs>
    ctor(string UploadId, string FileName, string MimeType, long Size, string Hash)
    string FileName { get;  init; }
    string Hash { get;  init; }
    string MimeType { get;  init; }
    long Size { get;  init; }
    string UploadId { get;  init; }
  sealed class FileUploadStartResult : IEquatable<FileUploadStartResult>
    ctor()
    bool Accepted { get;  set; }
    string AssetUri { get;  set; }
  interface IAppBase : IProtocolMessageChannel
    BackgroundWork BackgroundWork { get; }
    string DataDirectory { get; }
    IReadOnlyList<DatabaseConnectionInfo> Databases { get; }
    IReadOnlyList<EndpointInfo> Endpoints { get; }
    GlobalState GlobalState { get; }
    Navigation Navigation { get; }
    ReactiveGlobalState ReactiveGlobalState { get; }
    ReactiveRoot ReactiveRoot { get; }
    event AsyncEventHandler<ClientJoinedEventArgs> ClientJoinedAsync
    event AsyncEventHandler<ClientLeftEventArgs> ClientLeftAsync
    event AsyncEventHandler<MessageReceivedEventArgs> MessageReceivedAsync
    event AsyncEventHandler<StartingEventArgs> StartingAsync
    event AsyncEventHandler<StoppingEventArgs> StoppingAsync
  interface IApp<TConfig> : IAppBase, IProtocolMessageChannel
    TConfig Config { get; }
  interface IApp<TSessionIdentity, TClientParameters> : IAppBase, IProtocolMessageChannel
    TClientParameters ClientParameters { get; }
    IClientCollection<TClientParameters> Clients { get; }
    TSessionIdentity SessionIdentity { get; }
  interface IClientCollection<TClientParameters>
    int Count { get; }
    IClient<TClientParameters> Item { get; }
  interface IClient<TClientParameters>
    TClientParameters Parameters { get; }
  interface IProfileAttributes
  class MessageReceivedEventArgs : EventArgs
    ctor(ProtocolMessage message)
    ProtocolMessage Message { get; }
  static class ClientFunctions.Names
    static string CaptureImage
    static string ExitFullscreen
    static string GetBatteryLevel
    static string GetLanguage
    static string GetMediaDevices
    static string GetNetworkType
    static string GetTheme
    static string GetTimezone
    static string GetUrl
    static string GetVisibility
    static string KeepScreenAwake
    static string Logout
    static string PlaySound
    static string RequestFullscreen
    static string ScrollTo
    static string SetTheme
    static string SetUrl
    static string StartAudioCapture
    static string StartVideoCapture
    static string StopCapture
    static string StopSound
    static string Vibrate
  class Navigation : IReactiveWithState
    Task<string> GetPathAsync(int targetId)
    Task<string> GetPathAsync()
    Task<bool> SetPathAsync(int targetId, string path, bool replace = false)
    Task<bool> SetPathAsync(string path, bool replace = false)
    event AsyncEventHandler<NavigationPathChangedEventArgs> PathChangedAsync
  class NavigationPathChangedEventArgs : EventArgs
    ctor(string url, Context clientContext)
    Context ClientContext { get; }
    int ClientSessionId { get; }
    string Path { get; }
    string Url { get; }
    string UserId { get; }
  class PersistentReactive<T> : Reactive<T>
    ctor(T initialValue, string file = "", string member = "")
  sealed class ProfileAddress
    string City { get; }
    string Country { get; }
    string Municipality { get; }
    string State { get; }
    string Street { get; }
    string Zip { get; }
  sealed class ProfileData
    ctor()
    string AddressCity { get;  set; }
    string AddressCountry { get;  set; }
    string AddressState { get;  set; }
    string AddressStreet { get;  set; }
    string AddressZip { get;  set; }
    string BirthDate { get;  set; }
    string Email { get;  set; }
    string FirstName { get;  set; }
    string Gender { get;  set; }
    string Language { get;  set; }
    string LastName { get;  set; }
    string Name { get;  set; }
    string PhoneNumber { get;  set; }
    string PreferredName { get;  set; }
  class ReactiveRoot
    ctor(IAppBase host, int updateIntervalMs = 1000)
    ReactiveManager ReactiveManager { get; }
    Task RunAsync(Func<Task> render, Func<Context, bool> filter = null)
  class StartingEventArgs : EventArgs
    ctor()
  class StoppingEventArgs : EventArgs
    ctor()
  enum UserRole
    Guest
    User
    Moderator
    Admin
  class Video
    ctor(IAppBase host)
    ValueTask CloseAllAsync()
    ValueTask CloseAsync(string streamKey = null)
    VideoOutputStreamInfo GetOutputStreamInfo(string streamId = null)
    ValueTask SendAsync(byte[] data, int frameNumber, bool isKey, ulong timestampInUs, uint durationInUs, VideoCodec codec, int width, int height, double framerate, string streamId = null, IReadOnlyList<int> targetIds = null, int? trackId = null)
    event AsyncEventHandler<VideoInputFrameEventArgs> VideoInputFrameAsync
    event AsyncEventHandler<VideoInputStreamBeginEventArgs> VideoInputStreamBeginAsync
    event AsyncEventHandler<VideoInputStreamEndEventArgs> VideoInputStreamEndAsync
  class VideoInputFrameEventArgs : EventArgs
    ctor(string streamId, Context clientContext, int trackId, byte[] data, int frameNumber, bool isKey, ulong timestampInUs, uint durationInUs)
    Context ClientContext { get; }
    int ClientSessionId { get; }
    byte[] Data { get; }
    uint DurationInUs { get; }
    int FrameNumber { get; }
    bool IsKey { get; }
    string StreamId { get; }
    ulong TimestampInUs { get; }
    int TrackId { get; }
    string UserId { get; }
  class VideoInputStreamBeginEventArgs : EventArgs
    ctor(string streamId, string description, string sourceType, VideoCodec codec, string codecDetails, int width, int height, double framerate, Context clientContext, int trackId)
    Context ClientContext { get; }
    int ClientSessionId { get; }
    VideoCodec Codec { get; }
    string CodecDetails { get; }
    string Description { get; }
    double Framerate { get; }
    int Height { get; }
    string SourceType { get; }
    string StreamId { get; }
    int TrackId { get; }
    string UserId { get; }
    int Width { get; }
  class VideoInputStreamEndEventArgs : EventArgs
    ctor(string streamId, Context clientContext, int trackId)
    Context ClientContext { get; }
    int ClientSessionId { get; }
    string StreamId { get; }
    int TrackId { get; }
    string UserId { get; }
  class VideoOutputStreamInfo : IEquatable<VideoOutputStreamInfo>
    ctor(string StreamId, int TrackId, VideoCodec Codec, int Width, int Height, double Framerate)
    VideoCodec Codec { get;  init; }
    double Framerate { get;  init; }
    int Height { get;  init; }
    string StreamId { get;  init; }
    int TrackId { get;  init; }
    int Width { get;  init; }
  class WrapperConfig<TConfig> : BasePluginConfig
    ctor()
    ctor(TConfig userConfig)
    TConfig AppConfig { get;  set; }


---

# Ikon.Common Public API

namespace Ikon.Common
  enum FileScanner.FileEventArgs.ActionType
    Added
    Changed
    Deleted
  class AppProjectConfig.ActivationConfig : ITomlMetadataProvider
    ctor()
    bool StopSessions { get;  set; }
  class AppBundleConfig.ActivationConfig
    ctor()
    bool StopSessions { get;  set; }
  class AppBundleConfig
    ctor()
    AppBundleConfig.ActivationConfig Activation { get;  set; }
    AppBundleConfig.AuthConfig Auth { get;  set; }
    string ChannelId { get;  set; }
    string CreatedAt { get;  set; }
    List<AppBundleConfig.DatabaseEntry> Databases { get;  set; }
    List<string> Endpoints { get;  set; }
    string Hash { get;  set; }
    string Name { get;  set; }
    string OrganisationId { get;  set; }
    List<AppBundleConfig.Pipeline> Pipelines { get;  set; }
    List<string> SessionIdentityKeys { get;  set; }
    string SpaceId { get;  set; }
    string Version { get;  set; }
    static string ConfigFileName
  class AppBundleConfigLegacy
    ctor()
    string AppTypeName { get;  set; }
    string CreatedAt { get;  set; }
    string DllName { get;  set; }
    string Hash { get;  set; }
    string Version { get;  set; }
    static string ConfigFileName
  class AppBundleRuntimeConfig
    ctor()
    string AppTypeName { get;  set; }
    string DllName { get;  set; }
    static string ConfigFileName
  sealed class AppProjectUtils.AppDiscoveryResult
    ctor()
    bool Found { get;  init; }
    string TypeName { get;  init; }
  class AppProjectConfig : ITomlMetadataProvider
    ctor()
    AppProjectConfig.ActivationConfig Activation { get;  set; }
    AppProjectConfig.AuthConfig Auth { get;  set; }
    List<string> Databases { get;  set; }
    List<string> Endpoints { get;  set; }
    AppProjectConfig.TargetConfig Target { get;  set; }
    static string GetConfigFileName(IkonBackend.EnvironmentType environment)
    static string GetConfigFileName(string targetName)
    static string ConfigFileName
  class AppProjectConfigLegacy : ITomlMetadataProvider
    ctor()
    AppProjectConfig.ActivationConfig Activation { get;  set; }
    AppProjectConfig.AuthConfig Auth { get;  set; }
    List<string> Databases { get;  set; }
    List<string> Endpoints { get;  set; }
    Dictionary<string, AppProjectConfigLegacy.Target> Targets { get;  set; }
  static class AppProjectUtils
    static IEnumerable<string> EnumerateCsprojFiles(string rootDirectory, int maxDepth = 3)
    static AppProjectUtils.AppDiscoveryResult FindAppTypeInAssembly(string dllPath)
    static string FindBestProjectFilePath(string targetDirectory)
    static string FindIkonPlatformDotnetRoot(string startDirectory)
    static string FindIkonPlatformRepoRoot(string startDirectory)
    static string FindIkonPlatformSlnx(string startDirectory)
    static Task GenerateTsconfigPathsJsonAsync(string frontendNodeDirectory)
    static AppProjectVariables GetAppProjectVars(string targetDirectory)
    static string GetAssemblyNameFromCsproj(string csprojPath)
    static Type[] GetTypesSafely(Assembly assembly)
    static bool HasIkonAppAttribute(Type type)
    static bool IsInsideIkonPlatform(string directory)
    static bool IsLegacyConfig(string tomlContent)
    static AppProjectConfig MigrateFromLegacy(string tomlContent, IkonBackend.EnvironmentType environment)
    static int ScoreProjectFile(string csprojPath)
  sealed class AppProjectVariables
    ctor()
    string ConfigFilePath { get;  init; }
    string CsProjectFilePath { get;  init; }
    string CsProjectName { get;  init; }
    string FrontendNodeDirectory { get;  init; }
    string GitRootDirectory { get;  init; }
    string ProjectDirectory { get;  init; }
    string ProjectName { get;  init; }
    string RelativeConfigFilePath { get;  init; }
    string RelativeCsProjectFilePath { get;  init; }
    string RelativeRootDirectory { get;  init; }
    string RootDirectory { get;  init; }
    string TargetDirectory { get;  init; }
  class AsyncLocalInstances
    void Capture(object owner, bool allowOverride = false)
    void InitializeAll()
    void Remove(object owner)
    void Restore(object owner)
    bool TryRestore(object owner)
    static AsyncLocalInstances Instance
  class AppProjectConfig.AuthConfig : ITomlMetadataProvider
    ctor()
    List<string> DomainAllowlist { get;  set; }
    bool Enabled { get;  set; }
    List<string> Methods { get;  set; }
  class AppBundleConfig.AuthConfig
    ctor()
    List<string> DomainAllowlist { get;  set; }
    bool Enabled { get;  set; }
    List<string> Methods { get;  set; }
  struct CertificateStore.Certificate
    ctor(X509Certificate2 cert, X509Certificate2 rootCert, string certHash, string spkiHash, bool isDotnetDevCert)
    X509Certificate2 Cert { get; }
    string CertHash { get; }
    bool IsDotnetDevCert { get; }
    X509Certificate2 RootCert { get; }
    string SpkiHash { get; }
  static class CertificateStore
    static CertificateStore.Certificate GetCertificate(string host, X509Certificate2 rootCert = null, bool disableDotnetDevCerts = false)
  sealed class DatabaseConnectionInfo
    ctor()
    string ConnectionString { get;  set; }
    string Name { get;  set; }
    string Type { get;  set; }
  class AppBundleConfig.DatabaseEntry
    ctor()
    string Name { get;  set; }
    string Tier { get;  set; }
    string Type { get;  set; }
  class DescriptionAttribute : Attribute
    ctor(string description, object example = null, RequiredStatus isRequired = Default, int minArrayItems = 0)
    string Description { get; }
    object Example { get; }
    RequiredStatus IsRequired { get; }
    int MinArrayItems { get; }
  class ExponentialMovingAverage
    ctor(double smoothingFactor = 0.1)
    double CurrentValue { get; }
    double Update(double value)
    double UpdatePerElapsedTime(double value)
  class FileScanner.FileEventArgs : EventArgs
    ctor(string absolutePath, string relativePath, FileScanner.FileEventArgs.ActionType action)
    string AbsolutePath { get; }
    FileScanner.FileEventArgs.ActionType Action { get; }
    string RelativePath { get; }
    override string ToString()
  class FileScanner : IAsyncDisposable, IStorage
    ctor()
    int QueueSize { get; }
    Task DeleteAsync(AssetUri assetUri)
    ValueTask DisposeAsync()
    Task<bool> ExistsAsync(AssetUri assetUri)
    List<string> GetPaths(string link)
    Task<AssetContent<Stream>> GetReadStreamAsync(AssetUri assetUri)
    Task<Stream> GetWriteStreamAsync(AssetUri assetUri, AssetMetadata? metadata, CancellationToken cancellationToken)
    Task InitializeAsync(string name, string dataDirectory, bool scanZipFiles = true, bool start = true)
    Task<IReadOnlyList<AssetListingEntry>> ListAsync(AssetQuery query, CancellationToken cancellationToken)
    Stream OpenStream(string absoluteOrRelativePath)
    Task<string> ReadAllTextAsync(string absoluteOrRelativePath)
    Task StartAsync()
    Task StopAsync()
    Task<AssetMetadata?> TryGetMetadataAsync(AssetUri assetUri)
    Task WaitUntilQueueEmptyAsync()
    event Func<AssetEventArgs, Task> AssetEventAsync
    event Func<object, FileScanner.FileEventArgs, Task> FileEvent
  class GenericListCache<T> : IGenericListCache<T>
    ctor()
    void Add(string hash, T item)
    void Clear()
    void Delete(string hash)
    List<string> DeleteOlderThan(TimeSpan timeSpan)
    List<T> Get(string hash)
  static class HashUtils
    static byte[] ComputeMD5Bytes(byte[] value)
    static byte[] ComputeMD5Bytes(string value)
    static string ComputeMD5FromFile(string path)
    static string ComputeMD5FromStream(Stream stream)
    static string ComputeMD5String(byte[] value)
    static string ComputeMD5String(string value)
    static byte[] ComputeSHA256Bytes(byte[] value)
    static string ComputeSHA256FromFile(string path)
    static string ComputeSHA256FromStream(Stream stream)
    static string ComputeSHA256String(byte[] value)
    static string ComputeSHA256String(string value)
    static string ToHexString(byte[] data)
  interface IGenericListCache<T>
    abstract void Add(string hash, T item)
    abstract void Clear()
    abstract void Delete(string hash)
    abstract List<string> DeleteOlderThan(TimeSpan timeSpan)
    abstract List<T> Get(string hash)
  sealed class IkonLoggerProvider : IDisposable, ILoggerProvider
    ctor()
    ILogger CreateLogger(string categoryName)
    void Dispose()
  class IkonProjectConfigLegacy
    ctor()
    string ChannelId { get;  set; }
    string OrganisationId { get;  set; }
    string ProjectId { get;  set; }
    string SpaceId { get;  set; }
    static string ConfigFileName
  class IkonProjectConfigLegacyPerEnv
    ctor()
    Dictionary<string, IkonProjectConfigLegacy> Environments { get;  set; }
  sealed class InMemoryProtocolMessageChannel : IProtocolMessageChannel
    ctor()
    Context ClientContext { get; }
    static ValueTuple<InMemoryProtocolMessageChannel, InMemoryProtocolMessageChannel> CreateConnectedPair()
    IDisposable RegisterMessageHandler(Func<ProtocolMessage, ValueTask> handler, Opcode? opcodeGroupMask = null, Opcode[] opcodes = null)
    ValueTask SendMessageAsync(ProtocolMessage message)
    ValueTask SendMessageAsync(IProtocolMessagePayload payload)
  sealed class AppProjectUtils.IsolatedLoadContext : AssemblyLoadContext, IDisposable
    ctor(string mainAssemblyPath)
    void Dispose()
  static class Markdown
    static string To<T>(T obj, bool includeFields = true, bool enumsAsNames = true, bool camelCase = false, bool includeNull = true, int maxDepth = 5)
  static class MimeTypes
    static void AddOrUpdate(string mime, string extension)
    static string GetExtensionFromMimeType(string mimeType)
    static string GetMimeTypeFromExtension(string extension)
    static string GetMimeTypeFromFilename(string fileName)
    static bool Is(string mimeType, string mimeTypeToCompare)
    static bool IsAudio(string mimeType)
    static bool IsBinary(string mimeType)
    static bool IsCsv(string mimeType)
    static bool IsImage(string mimeType)
    static bool IsJson(string mimeType)
    static bool IsMarkdown(string mimeType)
    static bool IsMicrosoftExcel(string mimeType)
    static bool IsMicrosoftPowerpoint(string mimeType)
    static bool IsMicrosoftWord(string mimeType)
    static bool IsNotes(string mimeType)
    static bool IsPdf(string mimeType)
    static bool IsText(string mimeType)
    static bool IsVideo(string mimeType)
    static bool IsXml(string mimeType)
    static bool IsZip(string mimeType)
    static bool TypeMatchesMimetype(string type, string mimeType)
    static string ApplicationAndrewInset
    static string ApplicationApplixware
    static string ApplicationAtomXml
    static string ApplicationAtomcatXml
    static string ApplicationAtomsvcXml
    static string ApplicationCcxmlXml
    static string ApplicationCdmiCapability
    static string ApplicationCdmiContainer
    static string ApplicationCdmiDomain
    static string ApplicationCdmiObject
    static string ApplicationCdmiQueue
    static string ApplicationCuSeeme
    static string ApplicationDavmountXml
    static string ApplicationDocbookXml
    static string ApplicationDsscDer
    static string ApplicationDsscXml
    static string ApplicationEcmascript
    static string ApplicationEmmaXml
    static string ApplicationEpubZip
    static string ApplicationExcel
    static string ApplicationExi
    static string ApplicationFontTdpfr
    static string ApplicationGmlXml
    static string ApplicationGpxXml
    static string ApplicationGxf
    static string ApplicationHyperstudio
    static string ApplicationInkmlXml
    static string ApplicationIpfix
    static string ApplicationJavaArchive
    static string ApplicationJavaSerializedObject
    static string ApplicationJavaVm
    static string ApplicationJavascript
    static string ApplicationJson
    static string ApplicationJsonmlJson
    static string ApplicationLostXml
    static string ApplicationMacBinhex40
    static string ApplicationMacCompactpro
    static string ApplicationMadsXml
    static string ApplicationMarc
    static string ApplicationMarcxmlXml
    static string ApplicationMathematica
    static string ApplicationMathmlXml
    static string ApplicationMbox
    static string ApplicationMediaservercontrolXml
    static string ApplicationMetalink4Xml
    static string ApplicationMetalinkXml
    static string ApplicationMetsXml
    static string ApplicationModsXml
    static string ApplicationMp21
    static string ApplicationMp4
    static string ApplicationMsword
    static string ApplicationMxf
    static string ApplicationOctetStream
    static string ApplicationOda
    static string ApplicationOebpsPackageXml
    static string ApplicationOgg
    static string ApplicationOmdocXml
    static string ApplicationOnenote
    static string ApplicationOxps
    static string ApplicationPatchOpsErrorXml
    static string ApplicationPdf
    static string ApplicationPgpEncrypted
    static string ApplicationPgpSignature
    static string ApplicationPicsRules
    static string ApplicationPkcs10
    static string ApplicationPkcs7Mime
    static string ApplicationPkcs7Signature
    static string ApplicationPkcs8
    static string ApplicationPkixAttrCert
    static string ApplicationPkixCert
    static string ApplicationPkixCrl
    static string ApplicationPkixPkipath
    static string ApplicationPkixcmp
    static string ApplicationPlsXml
    static string ApplicationPostscript
    static string ApplicationPrsCww
    static string ApplicationPskcXml
    static string ApplicationRdfXml
    static string ApplicationReginfoXml
    static string ApplicationRelaxNgCompactSyntax
    static string ApplicationResourceListsDiffXml
    static string ApplicationResourceListsXml
    static string ApplicationRlsServicesXml
    static string ApplicationRpkiGhostbusters
    static string ApplicationRpkiManifest
    static string ApplicationRpkiRoa
    static string ApplicationRsdXml
    static string ApplicationRssXml
    static string ApplicationRtf
    static string ApplicationSbmlXml
    static string ApplicationScvpCvRequest
    static string ApplicationScvpCvResponse
    static string ApplicationScvpVpRequest
    static string ApplicationScvpVpResponse
    static string ApplicationSdp
    static string ApplicationSetPaymentInitiation
    static string ApplicationSetRegistrationInitiation
    static string ApplicationShfXml
    static string ApplicationSmilXml
    static string ApplicationSparqlQuery
    static string ApplicationSparqlResultsXml
    static string ApplicationSql
    static string ApplicationSrgs
    static string ApplicationSrgsXml
    static string ApplicationSruXml
    static string ApplicationSsdlXml
    static string ApplicationSsmlXml
    static string ApplicationTeiXml
    static string ApplicationThraudXml
    static string ApplicationTimestampedData
    static string ApplicationVnd3gpp2Tcap
    static string ApplicationVnd3gppPicBwLarge
    static string ApplicationVnd3gppPicBwSmall
    static string ApplicationVnd3gppPicBwVar
    static string ApplicationVnd3mPostItNotes
    static string ApplicationVndAccpacSimplyAso
    static string ApplicationVndAccpacSimplyImp
    static string ApplicationVndAcucobol
    static string ApplicationVndAcucorp
    static string ApplicationVndAdobeAirApplicationInstallerPackageZip
    static string ApplicationVndAdobeFormscentralFcdt
    static string ApplicationVndAdobeFxp
    static string ApplicationVndAdobeXdpXml
    static string ApplicationVndAdobeXfdf
    static string ApplicationVndAheadSpace
    static string ApplicationVndAirzipFilesecureAzf
    static string ApplicationVndAirzipFilesecureAzs
    static string ApplicationVndAmazonEbook
    static string ApplicationVndAmericandynamicsAcc
    static string ApplicationVndAmigaAmi
    static string ApplicationVndAndroidPackageArchive
    static string ApplicationVndAnserWebCertificateIssueInitiation
    static string ApplicationVndAnserWebFundsTransferInitiation
    static string ApplicationVndAntixGameComponent
    static string ApplicationVndAppleInstallerXml
    static string ApplicationVndAppleMpegurl
    static string ApplicationVndAristanetworksSwi
    static string ApplicationVndAstraeaSoftwareIota
    static string ApplicationVndAudiograph
    static string ApplicationVndBlueiceMultipass
    static string ApplicationVndBmi
    static string ApplicationVndBusinessobjects
    static string ApplicationVndChemdrawXml
    static string ApplicationVndChipnutsKaraokeMmd
    static string ApplicationVndCinderella
    static string ApplicationVndClaymore
    static string ApplicationVndCloantoRp9
    static string ApplicationVndClonkC4group
    static string ApplicationVndCluetrustCartomobileConfig
    static string ApplicationVndCluetrustCartomobileConfigPkg
    static string ApplicationVndCommonspace
    static string ApplicationVndContactCmsg
    static string ApplicationVndCosmocaller
    static string ApplicationVndCrickClicker
    static string ApplicationVndCrickClickerKeyboard
    static string ApplicationVndCrickClickerPalette
    static string ApplicationVndCrickClickerTemplate
    static string ApplicationVndCrickClickerWordbank
    static string ApplicationVndCriticaltoolsWbsXml
    static string ApplicationVndCtcPosml
    static string ApplicationVndCupsPpd
    static string ApplicationVndCurlCar
    static string ApplicationVndCurlPcurl
    static string ApplicationVndDart
    static string ApplicationVndDataVisionRdz
    static string ApplicationVndDeceData
    static string ApplicationVndDeceTtmlXml
    static string ApplicationVndDeceUnspecified
    static string ApplicationVndDeceZip
    static string ApplicationVndDenovoFcselayoutLink
    static string ApplicationVndDna
    static string ApplicationVndDolbyMlp
    static string ApplicationVndDpgraph
    static string ApplicationVndDreamfactory
    static string ApplicationVndDsKeypoint
    static string ApplicationVndDvbAit
    static string ApplicationVndDvbService
    static string ApplicationVndDynageo
    static string ApplicationVndEcowinChart
    static string ApplicationVndEnliven
    static string ApplicationVndEpsonEsf
    static string ApplicationVndEpsonMsf
    static string ApplicationVndEpsonQuickanime
    static string ApplicationVndEpsonSalt
    static string ApplicationVndEpsonSsf
    static string ApplicationVndEszigno3Xml
    static string ApplicationVndEzpixAlbum
    static string ApplicationVndEzpixPackage
    static string ApplicationVndFdf
    static string ApplicationVndFdsnMseed
    static string ApplicationVndFdsnSeed
    static string ApplicationVndFlographit
    static string ApplicationVndFluxtimeClip
    static string ApplicationVndFramemaker
    static string ApplicationVndFrogansFnc
    static string ApplicationVndFrogansLtf
    static string ApplicationVndFscWeblaunch
    static string ApplicationVndFujitsuOasys
    static string ApplicationVndFujitsuOasys2
    static string ApplicationVndFujitsuOasys3
    static string ApplicationVndFujitsuOasysgp
    static string ApplicationVndFujitsuOasysprs
    static string ApplicationVndFujixeroxDdd
    static string ApplicationVndFujixeroxDocuworks
    static string ApplicationVndFujixeroxDocuworksBinder
    static string ApplicationVndFuzzysheet
    static string ApplicationVndGenomatixTuxedo
    static string ApplicationVndGeogebraFile
    static string ApplicationVndGeogebraTool
    static string ApplicationVndGeometryExplorer
    static string ApplicationVndGeonext
    static string ApplicationVndGeoplan
    static string ApplicationVndGeospace
    static string ApplicationVndGmx
    static string ApplicationVndGoogleEarthKmlXml
    static string ApplicationVndGoogleEarthKmz
    static string ApplicationVndGrafeq
    static string ApplicationVndGrooveAccount
    static string ApplicationVndGrooveHelp
    static string ApplicationVndGrooveIdentityMessage
    static string ApplicationVndGrooveInjector
    static string ApplicationVndGrooveToolMessage
    static string ApplicationVndGrooveToolTemplate
    static string ApplicationVndGrooveVcard
    static string ApplicationVndHalXml
    static string ApplicationVndHandheldEntertainmentXml
    static string ApplicationVndHbci
    static string ApplicationVndHheLessonPlayer
    static string ApplicationVndHpHpgl
    static string ApplicationVndHpHpid
    static string ApplicationVndHpHps
    static string ApplicationVndHpJlyt
    static string ApplicationVndHpPcl
    static string ApplicationVndHpPclxl
    static string ApplicationVndHydrostatixSofData
    static string ApplicationVndIbmMinipay
    static string ApplicationVndIbmModcap
    static string ApplicationVndIbmRightsManagement
    static string ApplicationVndIbmSecureContainer
    static string ApplicationVndIccprofile
    static string ApplicationVndIgloader
    static string ApplicationVndImmervisionIvp
    static string ApplicationVndImmervisionIvu
    static string ApplicationVndInsorsIgm
    static string ApplicationVndInterconFormnet
    static string ApplicationVndIntergeo
    static string ApplicationVndIntuQbo
    static string ApplicationVndIntuQfx
    static string ApplicationVndIpunpluggedRcprofile
    static string ApplicationVndIrepositoryPackageXml
    static string ApplicationVndIsXpr
    static string ApplicationVndIsacFcs
    static string ApplicationVndJam
    static string ApplicationVndJcpJavameMidletRms
    static string ApplicationVndJisp
    static string ApplicationVndJoostJodaArchive
    static string ApplicationVndKahootz
    static string ApplicationVndKdeKarbon
    static string ApplicationVndKdeKchart
    static string ApplicationVndKdeKformula
    static string ApplicationVndKdeKivio
    static string ApplicationVndKdeKontour
    static string ApplicationVndKdeKpresenter
    static string ApplicationVndKdeKspread
    static string ApplicationVndKdeKword
    static string ApplicationVndKenameaapp
    static string ApplicationVndKidspiration
    static string ApplicationVndKinar
    static string ApplicationVndKoan
    static string ApplicationVndKodakDescriptor
    static string ApplicationVndLasLasXml
    static string ApplicationVndLlamagraphicsLifeBalanceDesktop
    static string ApplicationVndLlamagraphicsLifeBalanceExchangeXml
    static string ApplicationVndLotus123
    static string ApplicationVndLotusApproach
    static string ApplicationVndLotusFreelance
    static string ApplicationVndLotusNotes
    static string ApplicationVndLotusOrganizer
    static string ApplicationVndLotusScreencam
    static string ApplicationVndLotusWordpro
    static string ApplicationVndMacportsPortpkg
    static string ApplicationVndMcd
    static string ApplicationVndMedcalcdata
    static string ApplicationVndMediastationCdkey
    static string ApplicationVndMfer
    static string ApplicationVndMfmp
    static string ApplicationVndMicrografxFlo
    static string ApplicationVndMicrografxIgx
    static string ApplicationVndMif
    static string ApplicationVndMobiusDaf
    static string ApplicationVndMobiusDis
    static string ApplicationVndMobiusMbk
    static string ApplicationVndMobiusMqy
    static string ApplicationVndMobiusMsl
    static string ApplicationVndMobiusPlc
    static string ApplicationVndMobiusTxf
    static string ApplicationVndMophunApplication
    static string ApplicationVndMophunCertificate
    static string ApplicationVndMozillaXulXml
    static string ApplicationVndMsArtgalry
    static string ApplicationVndMsCabCompressed
    static string ApplicationVndMsExcel
    static string ApplicationVndMsExcelAddinMacroenabled12
    static string ApplicationVndMsExcelSheetBinaryMacroenabled12
    static string ApplicationVndMsExcelSheetMacroenabled12
    static string ApplicationVndMsExcelTemplateMacroenabled12
    static string ApplicationVndMsFontobject
    static string ApplicationVndMsHtmlhelp
    static string ApplicationVndMsIms
    static string ApplicationVndMsLrm
    static string ApplicationVndMsOfficetheme
    static string ApplicationVndMsPkiSeccat
    static string ApplicationVndMsPkiStl
    static string ApplicationVndMsPowerpoint
    static string ApplicationVndMsPowerpointAddinMacroenabled12
    static string ApplicationVndMsPowerpointPresentationMacroenabled12
    static string ApplicationVndMsPowerpointSlideMacroenabled12
    static string ApplicationVndMsPowerpointSlideshowMacroenabled12
    static string ApplicationVndMsPowerpointTemplateMacroenabled12
    static string ApplicationVndMsProject
    static string ApplicationVndMsWordDocumentMacroenabled12
    static string ApplicationVndMsWordTemplateMacroenabled12
    static string ApplicationVndMsWorks
    static string ApplicationVndMsWpl
    static string ApplicationVndMsXpsdocument
    static string ApplicationVndMseq
    static string ApplicationVndMusician
    static string ApplicationVndMuveeStyle
    static string ApplicationVndMynfc
    static string ApplicationVndNeurolanguageNlu
    static string ApplicationVndNitf
    static string ApplicationVndNoblenetDirectory
    static string ApplicationVndNoblenetSealer
    static string ApplicationVndNoblenetWeb
    static string ApplicationVndNokiaNGageData
    static string ApplicationVndNokiaNGageSymbianInstall
    static string ApplicationVndNokiaRadioPreset
    static string ApplicationVndNokiaRadioPresets
    static string ApplicationVndNovadigmEdm
    static string ApplicationVndNovadigmEdx
    static string ApplicationVndNovadigmExt
    static string ApplicationVndOasisOpendocumentChart
    static string ApplicationVndOasisOpendocumentChartTemplate
    static string ApplicationVndOasisOpendocumentDatabase
    static string ApplicationVndOasisOpendocumentFormula
    static string ApplicationVndOasisOpendocumentFormulaTemplate
    static string ApplicationVndOasisOpendocumentGraphics
    static string ApplicationVndOasisOpendocumentGraphicsTemplate
    static string ApplicationVndOasisOpendocumentImage
    static string ApplicationVndOasisOpendocumentImageTemplate
    static string ApplicationVndOasisOpendocumentPresentation
    static string ApplicationVndOasisOpendocumentPresentationTemplate
    static string ApplicationVndOasisOpendocumentSpreadsheet
    static string ApplicationVndOasisOpendocumentSpreadsheetTemplate
    static string ApplicationVndOasisOpendocumentText
    static string ApplicationVndOasisOpendocumentTextMaster
    static string ApplicationVndOasisOpendocumentTextTemplate
    static string ApplicationVndOasisOpendocumentTextWeb
    static string ApplicationVndOlpcSugar
    static string ApplicationVndOmaDd2Xml
    static string ApplicationVndOpenofficeorgExtension
    static string ApplicationVndOpenxmlformatsOfficedocumentPresentationmlPresentation
    static string ApplicationVndOpenxmlformatsOfficedocumentPresentationmlSlide
    static string ApplicationVndOpenxmlformatsOfficedocumentPresentationmlSlideshow
    static string ApplicationVndOpenxmlformatsOfficedocumentPresentationmlTemplate
    static string ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlSheet
    static string ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlTemplate
    static string ApplicationVndOpenxmlformatsOfficedocumentWordprocessingmlDocument
    static string ApplicationVndOpenxmlformatsOfficedocumentWordprocessingmlTemplate
    static string ApplicationVndOsgeoMapguidePackage
    static string ApplicationVndOsgiDp
    static string ApplicationVndOsgiSubsystem
    static string ApplicationVndPalm
    static string ApplicationVndPawaafile
    static string ApplicationVndPgFormat
    static string ApplicationVndPgOsasli
    static string ApplicationVndPicsel
    static string ApplicationVndPmiWidget
    static string ApplicationVndPocketlearn
    static string ApplicationVndPowerbuilder6
    static string ApplicationVndPreviewsystemsBox
    static string ApplicationVndProteusMagazine
    static string ApplicationVndPublishareDeltaTree
    static string ApplicationVndPviPtid1
    static string ApplicationVndQuarkQuarkxpress
    static string ApplicationVndRealvncBed
    static string ApplicationVndRecordareMusicxml
    static string ApplicationVndRecordareMusicxmlXml
    static string ApplicationVndRigCryptonote
    static string ApplicationVndRimCod
    static string ApplicationVndRnRealmedia
    static string ApplicationVndRnRealmediaVbr
    static string ApplicationVndRoute66Link66Xml
    static string ApplicationVndSailingtrackerTrack
    static string ApplicationVndSeemail
    static string ApplicationVndSema
    static string ApplicationVndSemd
    static string ApplicationVndSemf
    static string ApplicationVndShanaInformedFormdata
    static string ApplicationVndShanaInformedFormtemplate
    static string ApplicationVndShanaInformedInterchange
    static string ApplicationVndShanaInformedPackage
    static string ApplicationVndSimtechMindmapper
    static string ApplicationVndSmaf
    static string ApplicationVndSmartTeacher
    static string ApplicationVndSolentSdkmXml
    static string ApplicationVndSpotfireDxp
    static string ApplicationVndSpotfireSfs
    static string ApplicationVndStardivisionCalc
    static string ApplicationVndStardivisionDraw
    static string ApplicationVndStardivisionImpress
    static string ApplicationVndStardivisionMath
    static string ApplicationVndStardivisionWriter
    static string ApplicationVndStardivisionWriterGlobal
    static string ApplicationVndStepmaniaPackage
    static string ApplicationVndStepmaniaStepchart
    static string ApplicationVndSunXmlCalc
    static string ApplicationVndSunXmlCalcTemplate
    static string ApplicationVndSunXmlDraw
    static string ApplicationVndSunXmlDrawTemplate
    static string ApplicationVndSunXmlImpress
    static string ApplicationVndSunXmlImpressTemplate
    static string ApplicationVndSunXmlMath
    static string ApplicationVndSunXmlWriter
    static string ApplicationVndSunXmlWriterGlobal
    static string ApplicationVndSunXmlWriterTemplate
    static string ApplicationVndSusCalendar
    static string ApplicationVndSvd
    static string ApplicationVndSymbianInstall
    static string ApplicationVndSyncmlDmWbxml
    static string ApplicationVndSyncmlDmXml
    static string ApplicationVndSyncmlXml
    static string ApplicationVndTaoIntentModuleArchive
    static string ApplicationVndTcpdumpPcap
    static string ApplicationVndTmobileLivetv
    static string ApplicationVndTridTpt
    static string ApplicationVndTriscapeMxs
    static string ApplicationVndTrueapp
    static string ApplicationVndUfdl
    static string ApplicationVndUiqTheme
    static string ApplicationVndUmajin
    static string ApplicationVndUnity
    static string ApplicationVndUomlXml
    static string ApplicationVndVcx
    static string ApplicationVndVisio
    static string ApplicationVndVisionary
    static string ApplicationVndVsf
    static string ApplicationVndWapWbxml
    static string ApplicationVndWapWmlc
    static string ApplicationVndWapWmlscriptc
    static string ApplicationVndWebturbo
    static string ApplicationVndWolframPlayer
    static string ApplicationVndWordperfect
    static string ApplicationVndWqd
    static string ApplicationVndWtStf
    static string ApplicationVndXara
    static string ApplicationVndXfdl
    static string ApplicationVndYamahaHvDic
    static string ApplicationVndYamahaHvScript
    static string ApplicationVndYamahaHvVoice
    static string ApplicationVndYamahaOpenscoreformat
    static string ApplicationVndYamahaOpenscoreformatOsfpvgXml
    static string ApplicationVndYamahaSmafAudio
    static string ApplicationVndYamahaSmafPhrase
    static string ApplicationVndYellowriverCustomMenu
    static string ApplicationVndZul
    static string ApplicationVndZzazzDeckXml
    static string ApplicationVoicexmlXml
    static string ApplicationWidget
    static string ApplicationWinhlp
    static string ApplicationWsdlXml
    static string ApplicationWspolicyXml
    static string ApplicationX7zCompressed
    static string ApplicationXAbiword
    static string ApplicationXAceCompressed
    static string ApplicationXAppleDiskimage
    static string ApplicationXAuthorwareBin
    static string ApplicationXAuthorwareMap
    static string ApplicationXAuthorwareSeg
    static string ApplicationXBcpio
    static string ApplicationXBittorrent
    static string ApplicationXBlorb
    static string ApplicationXBzip
    static string ApplicationXBzip2
    static string ApplicationXCbr
    static string ApplicationXCdlink
    static string ApplicationXCfsCompressed
    static string ApplicationXChat
    static string ApplicationXChessPgn
    static string ApplicationXConference
    static string ApplicationXCpio
    static string ApplicationXCsh
    static string ApplicationXDebianPackage
    static string ApplicationXDgcCompressed
    static string ApplicationXDirector
    static string ApplicationXDoom
    static string ApplicationXDtbncxXml
    static string ApplicationXDtbookXml
    static string ApplicationXDtbresourceXml
    static string ApplicationXDvi
    static string ApplicationXEnvoy
    static string ApplicationXEva
    static string ApplicationXFontBdf
    static string ApplicationXFontGhostscript
    static string ApplicationXFontLinuxPsf
    static string ApplicationXFontPcf
    static string ApplicationXFontSnf
    static string ApplicationXFontType1
    static string ApplicationXFreearc
    static string ApplicationXFuturesplash
    static string ApplicationXGcaCompressed
    static string ApplicationXGlulx
    static string ApplicationXGnumeric
    static string ApplicationXGrampsXml
    static string ApplicationXGtar
    static string ApplicationXHdf
    static string ApplicationXInstallInstructions
    static string ApplicationXIso9660Image
    static string ApplicationXJavaJnlpFile
    static string ApplicationXLatex
    static string ApplicationXLzhCompressed
    static string ApplicationXMie
    static string ApplicationXMobipocketEbook
    static string ApplicationXMsApplication
    static string ApplicationXMsShortcut
    static string ApplicationXMsWmd
    static string ApplicationXMsWmz
    static string ApplicationXMsXbap
    static string ApplicationXMsaccess
    static string ApplicationXMsbinder
    static string ApplicationXMscardfile
    static string ApplicationXMsclip
    static string ApplicationXMsdownload
    static string ApplicationXMsmediaview
    static string ApplicationXMsmetafile
    static string ApplicationXMsmoney
    static string ApplicationXMspublisher
    static string ApplicationXMsschedule
    static string ApplicationXMsterminal
    static string ApplicationXMswrite
    static string ApplicationXNetcdf
    static string ApplicationXNzb
    static string ApplicationXPkcs12
    static string ApplicationXPkcs7Certificates
    static string ApplicationXPkcs7Certreqresp
    static string ApplicationXRarCompressed
    static string ApplicationXResearchInfoSystems
    static string ApplicationXSh
    static string ApplicationXShar
    static string ApplicationXShockwaveFlash
    static string ApplicationXSilverlightApp
    static string ApplicationXSql
    static string ApplicationXStuffit
    static string ApplicationXStuffitx
    static string ApplicationXSubrip
    static string ApplicationXSv4cpio
    static string ApplicationXSv4crc
    static string ApplicationXT3vmImage
    static string ApplicationXTads
    static string ApplicationXTar
    static string ApplicationXTcl
    static string ApplicationXTex
    static string ApplicationXTexTfm
    static string ApplicationXTexinfo
    static string ApplicationXTgif
    static string ApplicationXUstar
    static string ApplicationXWaisSource
    static string ApplicationXX509CaCert
    static string ApplicationXXfig
    static string ApplicationXXliffXml
    static string ApplicationXXpinstall
    static string ApplicationXXz
    static string ApplicationXZmachine
    static string ApplicationXamlXml
    static string ApplicationXcapDiffXml
    static string ApplicationXencXml
    static string ApplicationXhtmlXml
    static string ApplicationXml
    static string ApplicationXmlDtd
    static string ApplicationXopXml
    static string ApplicationXprocXml
    static string ApplicationXsltXml
    static string ApplicationXspfXml
    static string ApplicationXvXml
    static string ApplicationYang
    static string ApplicationYinXml
    static string ApplicationZip
    static string AudioAdpcm
    static string AudioBasic
    static string AudioMidi
    static string AudioMp4
    static string AudioMpeg
    static string AudioOgg
    static string AudioS3m
    static string AudioSilk
    static string AudioVndDeceAudio
    static string AudioVndDigitalWinds
    static string AudioVndDra
    static string AudioVndDts
    static string AudioVndDtsHd
    static string AudioVndLucentVoice
    static string AudioVndMsPlayreadyMediaPya
    static string AudioVndNueraEcelp4800
    static string AudioVndNueraEcelp7470
    static string AudioVndNueraEcelp9600
    static string AudioVndRip
    static string AudioWebm
    static string AudioXAac
    static string AudioXAiff
    static string AudioXCaf
    static string AudioXFlac
    static string AudioXMatroska
    static string AudioXMpegurl
    static string AudioXMsWax
    static string AudioXMsWma
    static string AudioXPnRealaudio
    static string AudioXPnRealaudioPlugin
    static string AudioXWav
    static string AudioXm
    static string Binary
    static string ChemicalXCdx
    static string ChemicalXCif
    static string ChemicalXCmdf
    static string ChemicalXCml
    static string ChemicalXCsml
    static string ChemicalXXyz
    static string DefaultExtension
    static string DefaultMimeType
    static string FontCollection
    static string FontOtf
    static string FontTtf
    static string FontWoff
    static string FontWoff2
    static string ImageBmp
    static string ImageCgm
    static string ImageG3fax
    static string ImageGif
    static string ImageHeif
    static string ImageIef
    static string ImageJpeg
    static string ImageKtx
    static string ImagePng
    static string ImagePrsBtif
    static string ImageSgi
    static string ImageSvg
    static string ImageSvgXml
    static string ImageTiff
    static string ImageVndAdobePhotoshop
    static string ImageVndDeceGraphic
    static string ImageVndDjvu
    static string ImageVndDvbSubtitle
    static string ImageVndDwg
    static string ImageVndDxf
    static string ImageVndFastbidsheet
    static string ImageVndFpx
    static string ImageVndFst
    static string ImageVndFujixeroxEdmicsMmr
    static string ImageVndFujixeroxEdmicsRlc
    static string ImageVndMsModi
    static string ImageVndMsPhoto
    static string ImageVndNetFpx
    static string ImageVndWapWbmp
    static string ImageVndXiff
    static string ImageWebp
    static string ImageX3ds
    static string ImageXCmuRaster
    static string ImageXCmx
    static string ImageXFreehand
    static string ImageXIcon
    static string ImageXMrsidImage
    static string ImageXPcx
    static string ImageXPict
    static string ImageXPortableAnymap
    static string ImageXPortableBitmap
    static string ImageXPortableGraymap
    static string ImageXPortablePixmap
    static string ImageXRgb
    static string ImageXTga
    static string ImageXXbitmap
    static string ImageXXpixmap
    static string ImageXXwindowdump
    static string MessageRfc822
    static string ModelIges
    static string ModelMesh
    static string ModelVndColladaXml
    static string ModelVndDwf
    static string ModelVndGdl
    static string ModelVndGtw
    static string ModelVndMts
    static string ModelVndVtu
    static string ModelVrml
    static string ModelX3dBinary
    static string ModelX3dVrml
    static string ModelX3dXml
    static string TextCacheManifest
    static string TextCalendar
    static string TextCss
    static string TextCsv
    static string TextHtml
    static string TextJavascript
    static string TextMarkdown
    static string TextN3
    static string TextPlain
    static string TextPrsLinesTag
    static string TextRichtext
    static string TextSgml
    static string TextTabSeparatedValues
    static string TextTroff
    static string TextTurtle
    static string TextUriList
    static string TextVcard
    static string TextVndCurl
    static string TextVndCurlDcurl
    static string TextVndCurlMcurl
    static string TextVndCurlScurl
    static string TextVndFly
    static string TextVndFmiFlexstor
    static string TextVndGraphviz
    static string TextVndIn3d3dml
    static string TextVndIn3dSpot
    static string TextVndSunJ2meAppDescriptor
    static string TextVndWapWml
    static string TextVndWapWmlscript
    static string TextXAsm
    static string TextXC
    static string TextXFortran
    static string TextXJavaSource
    static string TextXNfo
    static string TextXOpml
    static string TextXPascal
    static string TextXSetext
    static string TextXSfv
    static string TextXUuencode
    static string TextXVcalendar
    static string TextXVcard
    static string TextXml
    static string Video3gpp
    static string Video3gpp2
    static string VideoH261
    static string VideoH263
    static string VideoH264
    static string VideoJpeg
    static string VideoJpm
    static string VideoMj2
    static string VideoMp4
    static string VideoMpeg
    static string VideoOgg
    static string VideoQuicktime
    static string VideoVndDeceHd
    static string VideoVndDeceMobile
    static string VideoVndDecePd
    static string VideoVndDeceSd
    static string VideoVndDeceVideo
    static string VideoVndDvbFile
    static string VideoVndFvt
    static string VideoVndMpegurl
    static string VideoVndMsPlayreadyMediaPyv
    static string VideoVndUvvuMp4
    static string VideoVndVivo
    static string VideoWebm
    static string VideoXF4v
    static string VideoXFli
    static string VideoXFlv
    static string VideoXM4v
    static string VideoXMatroska
    static string VideoXMng
    static string VideoXMsAsf
    static string VideoXMsVob
    static string VideoXMsWm
    static string VideoXMsWmv
    static string VideoXMsWmx
    static string VideoXMsWvx
    static string VideoXMsvideo
    static string VideoXSgiMovie
    static string VideoXSmv
    static string XConferenceXCooltalk
  class MovingAverage
    ctor(int size = 32)
    void AddValue(double value)
    double GetAverage()
  class AppBundleConfig.Pipeline
    ctor()
    string Description { get;  set; }
    string DllName { get;  set; }
    string Guid { get;  set; }
    string Name { get;  set; }
    string OpenApiSpecJson { get;  set; }
    string TypeName { get;  set; }
    int Version { get;  set; }
    List<AppBundleConfig.Workflow> Workflows { get;  set; }
  class PipelineBundleConfigLegacy
    ctor()
    string CreatedAt { get;  set; }
    string DllName { get;  set; }
    string Hash { get;  set; }
    string PipelineTypeName { get;  set; }
    string Version { get;  set; }
    static string ConfigFileName
    static string SpecFileName
  enum PipelineExecutionMode
    None
    HttpsEndpoint
    Scheduled
  sealed class PipelineProtocolHandler
    ctor(IDuplexPipe transport, Func<ProtocolMessage, Task> onMessageReceived, int maxMessageSize = 104857600)
    bool IsConnected { get; }
    Task CloseConnectionAsync()
    Task SendMessageAsync(ProtocolMessage message)
    Task StartReceiveAsync()
    void Stop()
  class PolymorphicConverter<TBase> : JsonConverter<object> where TBase : class
    ctor()
    override bool CanConvert(Type typeToConvert)
    override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
  class PriceInfo
    ctor()
    bool IsCertain { get;  set; }
    List<PriceTierInfo> PriceTiers { get;  set; }
    string UncertaintyReason { get;  set; }
    string UsageName { get;  set; }
  class PriceTierInfo
    ctor()
    string Currency { get;  set; }
    double Price { get;  set; }
    double Quantity { get;  set; }
    double Threshold { get;  set; }
    string ThresholdCorrelatedUsageType { get;  set; }
    string Unit { get;  set; }
  class PricingOutput
    ctor()
    string CreatedAt { get;  set; }
    List<PriceInfo> PriceInfos { get;  set; }
  static class QrEncoder
    static string GenerateSvg(string data, int size)
  class RateLimiter
    ctor(TimeSpan window, int rateLimit)
    int Rate { get; }
    bool Guard()
  enum RequiredStatus
    Default
    Required
    Optional
  class Resources : AsyncLocalInstance<Resources>
    ctor()
    Task<byte[]> ReadAsBytesAsync(string resourcePath)
    Task<Stream> ReadAsStreamAsync(string resourcePath)
    Task<string> ReadAsStringAsync(string resourcePath)
  static class Retrier
    static T Run<T>(List<Type> retryableExceptions, int retries, Func<T> func, string callerMemberName = "", string callerFilePath = "")
    static T Run<T>(Func<T> func, List<Type> retryableExceptions = null, int retries = 5, Action<Exception> onRetry = null, Action<Exception> onFailure = null, bool useExponentialBackoff = true, string description = null, string callerMemberName = "", string callerFilePath = "")
    static void Run(List<Type> retryableExceptions, int retries, Action func, string callerMemberName = "", string callerFilePath = "")
    static void Run(Action func, List<Type> retryableExceptions = null, int retries = 5, Action<Exception> onRetry = null, Action<Exception> onFailure = null, bool useExponentialBackoff = true, string description = null, string callerMemberName = "", string callerFilePath = "")
    static Task<T> RunAsync<T>(List<Type> retryableExceptions, int retries, Func<Task<T>> func, string callerMemberName = "", string callerFilePath = "")
    static Task<T> RunAsync<T>(Func<Task<T>> func, List<Type> retryableExceptions = null, int retries = 5, Func<Exception, Task> onRetry = null, Func<Exception, Task> onFailure = null, bool useExponentialBackoff = true, string description = null, string callerMemberName = "", string callerFilePath = "")
    static Task RunAsync(List<Type> retryableExceptions, int retries, Func<Task> func, string callerMemberName = "", string callerFilePath = "")
    static Task RunAsync(Func<Task> func, List<Type> retryableExceptions = null, int retries = 5, Func<Exception, Task> onRetry = null, Func<Exception, Task> onFailure = null, bool useExponentialBackoff = true, string description = null, string callerMemberName = "", string callerFilePath = "")
  class AppProjectConfigLegacy.Target : ITomlMetadataProvider
    ctor()
    string ChannelId { get;  set; }
    string OrganisationId { get;  set; }
    string SpaceId { get;  set; }
  class AppProjectConfig.TargetConfig : ITomlMetadataProvider
    ctor()
    string ChannelId { get;  set; }
    string Name { get;  set; }
    string OrganisationId { get;  set; }
    string SpaceId { get;  set; }
  static class TaskExtensions
    static void RunParallel(Task task, Action<Exception> onException = null)
  class TempDirectory
    ctor(string rootDirName)
    string FullPath { get; }
    long Size { get; }
    void Delete()
    string GetDirPath(string subDirName)
    string GetFilePath(string fileName)
  class TimeAverage
    ctor()
    void AddValue(double value)
    double GetValue()
  static class TimeSpanExtensions
    static string ToHumanReadable(TimeSpan timeSpan, int precision = 2)
  class TimedQueue<T>
    ctor()
    int Count { get; }
    void Enqueue(T item, long durationInMicroseconds)
    Task UpdateAsync(float deltaTime, Func<T, Task> process)
  class Translator
    ctor(string spaceId)
    ctor(string spaceId, string locale)
    Task InitializeAsync()
    void SetLocale(string newLocale)
    Task<string> TranslateAsync(string text, string description = "")
  class UsageTracker
    ctor()
    bool HasUsages { get; }
    Dictionary<string, double> Snapshot { get; }
    void Clear()
    void OnLogEvent(object sender, LogEvent logEvent)
    string PrettyPrint()
    void Register(string name, double value)
  static class Utils
    static string GenerateRandomToken(int size = 32)
    static string GetCSharpTypeName(object obj)
    static IPAddress GetFirstIPv4AddressOrLocalhost()
    static string ToUnescapedString(string input, bool unicodeOnly = false)
  class ValueStatistics
    ctor(double alpha = 0.9, double interval = 30)
    string ResultString { get; }
    bool TimerElapsed { get; }
    void AddSample(double sample)
    void Reset()
    double Average
    double Maximum
    double Minimum
  class AppBundleConfig.Workflow
    ctor()
    PipelineExecutionMode ExecutionMode { get;  set; }
    string Name { get;  set; }
    string Schedule { get;  set; }

namespace Ikon.Common.Assets
  static class StorageExtensions
    static Task AddCloudFilePublicStorageAsync(Asset asset)
    static Task AddCloudFileStorageAsync(Asset asset)
    static Task AddCloudJsonStorageAsync(Asset asset)
    static Task AddCloudProfileStorageAsync(Asset asset)
    static Task AddLocalFileStorageAsync(Asset asset, string root)

namespace Ikon.Common.Git
  class GitBranch : IEquatable<GitBranch>
    ctor(string Name, bool IsRemote, bool IsCurrent)
    bool IsCurrent { get;  init; }
    bool IsRemote { get;  init; }
    string Name { get;  init; }
  enum GitChangeType
    Added
    Modified
    Deleted
    Renamed
    Untracked
  class GitCloneOptions : IEquatable<GitCloneOptions>
    ctor(string Branch = null, bool Shallow = false, GitCredentials Credentials = null)
    string Branch { get;  init; }
    GitCredentials Credentials { get;  init; }
    bool Shallow { get;  init; }
  class GitCommit : IEquatable<GitCommit>
    ctor(string Sha, string ShortSha, string Author, string AuthorEmail, DateTimeOffset Date, string Message)
    string Author { get;  init; }
    string AuthorEmail { get;  init; }
    DateTimeOffset Date { get;  init; }
    string Message { get;  init; }
    string Sha { get;  init; }
    string ShortSha { get;  init; }
  class GitCredentials : IEquatable<GitCredentials>
    ctor(string Username, string Password)
    string Password { get;  init; }
    string Username { get;  init; }
  class GitDiff : IEquatable<GitDiff>
    ctor(string FromSha, string ToSha, List<GitFileDiff> Files)
    List<GitFileDiff> Files { get;  init; }
    string FromSha { get;  init; }
    string ToSha { get;  init; }
  class GitFileChange : IEquatable<GitFileChange>
    ctor(string Path, GitChangeType Type)
    string Path { get;  init; }
    GitChangeType Type { get;  init; }
  class GitFileDiff : IEquatable<GitFileDiff>
    ctor(string Path, GitChangeType Type, int LinesAdded, int LinesRemoved, string Patch = null)
    int LinesAdded { get;  init; }
    int LinesRemoved { get;  init; }
    string Patch { get;  init; }
    string Path { get;  init; }
    GitChangeType Type { get;  init; }
  class GitRepository
    ctor(string workingDirectory, GitCredentials credentials = null)
    GitCredentials Credentials { get; }
    string WorkingDirectory { get; }
    Task AbortAllInProgressOperationsAsync(CancellationToken ct = null)
    Task<bool> AbortCherryPickAsync(CancellationToken ct = null)
    Task<bool> AbortMergeAsync(CancellationToken ct = null)
    Task<bool> AbortRebaseAsync(CancellationToken ct = null)
    Task AddRemoteAsync(string name, string url, CancellationToken ct = null)
    Task CheckoutAsync(string branchOrRef, CancellationToken ct = null)
    Task CheckoutFilesFromRefAsync(string refName, string path = ".", CancellationToken ct = null)
    static Task<GitRepository> CloneAsync(string url, string targetDir, GitCloneOptions options = null, CancellationToken ct = null)
    static Task<ValueTuple<GitRepository, string, bool>> CloneOrSyncAsync(string url, string targetDir, GitCloneOptions options = null, CancellationToken ct = null)
    Task<GitCommit> CommitAsync(string message, CancellationToken ct = null)
    Task<GitCommit> CommitAsync(string message, string authorName, string authorEmail, bool allowEmpty = false, CancellationToken ct = null)
    Task CreateBranchAsync(string name, string startPoint = null, CancellationToken ct = null)
    Task<GitTag> CreateTagAsync(string name, string message = null, CancellationToken ct = null)
    Task DeleteTagAsync(string name, CancellationToken ct = null)
    Task DiscardChangesAsync(CancellationToken ct = null)
    static string EscapeMessage(string message)
    Task FetchAsync(bool includeTags = false, CancellationToken ct = null)
    static string GetAuthenticatedUrl(string url, GitCredentials credentials)
    Task<List<GitBranch>> GetBranchesAsync(CancellationToken ct = null)
    Task<string> GetConfigAsync(string key, CancellationToken ct = null)
    Task<string> GetCurrentBranchAsync(CancellationToken ct = null)
    Task<GitDiff> GetDiffAsync(string target = null, CancellationToken ct = null)
    Task<GitCommit> GetHeadCommitAsync(CancellationToken ct = null)
    Task<string> GetHeadShaAsync(bool shortSha = false, CancellationToken ct = null)
    Task<List<GitCommit>> GetHistoryAsync(int limit = 20, string fromRef = null, CancellationToken ct = null)
    Task<string> GetRemoteUrlAsync(string name = "origin", CancellationToken ct = null)
    Task<GitStatus> GetStatusAsync(CancellationToken ct = null)
    Task<List<GitTag>> GetTagsAsync(CancellationToken ct = null)
    Task<bool> HasCommitsAsync(CancellationToken ct = null)
    Task<bool> HasRemoteAsync(string name = "origin", CancellationToken ct = null)
    Task<bool> HasUncommittedChangesAsync(CancellationToken ct = null)
    static Task<GitRepository> InitAndConnectAsync(string directory, string remoteUrl, GitCredentials credentials = null, string configKey = null, string configValue = null, CancellationToken ct = null)
    static Task<GitRepository> InitAsync(string directory, CancellationToken ct = null)
    Task<bool> IsGitRepositoryAsync(CancellationToken ct = null)
    static Task<bool> IsGitRepositoryAsync(string directory, CancellationToken ct = null)
    Task PushAsync(bool setUpstream = false, CancellationToken ct = null)
    Task<bool> RefExistsAsync(string refName, CancellationToken ct = null)
    Task RenameBranchAsync(string oldName, string newName, CancellationToken ct = null)
    Task ResetHardAsync(string target, CancellationToken ct = null)
    Task ResetSoftAsync(string target, CancellationToken ct = null)
    Task<GitSyncResult> RestoreAsync(string target, CancellationToken ct = null)
    Task<string> RunAsync(string args, CancellationToken ct = null)
    Task<GitSyncResult> SaveAsync(string message, CancellationToken ct = null)
    Task SetConfigAsync(string key, string value, CancellationToken ct = null)
    Task SetRemoteUrlAsync(string name, string url, CancellationToken ct = null)
    Task SetUpstreamAsync(string remoteBranch, CancellationToken ct = null)
    static string ShortCommitHash(string hash)
    Task StageAllAsync(CancellationToken ct = null)
    Task<bool> StashAsync(string message = null, CancellationToken ct = null)
    Task<bool> StashPopAsync(CancellationToken ct = null)
    static string StripCredentialsFromUrl(string url)
    Task<GitSyncResult> SyncAsync(CancellationToken ct = null)
    static GitRepository TryOpen(string directory)
    Task<ValueTuple<bool, string, string>> TryRunAsync(string args, CancellationToken ct = null)
    static bool UrlsMatch(string url1, string url2)
  class GitStatus : IEquatable<GitStatus>
    ctor(string Branch, string HeadSha, bool HasUncommittedChanges, bool IsDetachedHead, int AheadBy, int BehindBy, List<GitFileChange> Changes)
    int AheadBy { get;  init; }
    int BehindBy { get;  init; }
    string Branch { get;  init; }
    List<GitFileChange> Changes { get;  init; }
    bool HasUncommittedChanges { get;  init; }
    string HeadSha { get;  init; }
    bool IsDetachedHead { get;  init; }
  class GitSyncResult : IEquatable<GitSyncResult>
    ctor(bool Success, string PreviousSha, string CurrentSha, string Error = null)
    string CurrentSha { get;  init; }
    string Error { get;  init; }
    string PreviousSha { get;  init; }
    bool Success { get;  init; }
  class GitTag : IEquatable<GitTag>
    ctor(string Name, string Sha, GitCommit Commit = null)
    GitCommit Commit { get;  init; }
    string Name { get;  init; }
    string Sha { get;  init; }

namespace Ikon.Common.Maths
  enum AxisConvention
    RightHanded_X_Up
    RightHanded_Y_Up
    RightHanded_Z_Up
    LeftHanded_X_Up
    LeftHanded_Y_Up
    LeftHanded_Z_Up
  struct BoundingBox : IEquatable<BoundingBox>
    ctor(BoundingSphere sphere)
    ctor(Vector3[] points)
    ctor(Vector3 a, Vector3 b)
    Vector3 Center { get;  set; }
    Vector3 Diagonal { get;  set; }
    Vector3 HalfDiagonal { get;  set; }
    static BoundingBox UnitCube { get; }
    Vector3[] GetCorners()
    static BoundingBox Merge(BoundingBox value1, BoundingBox value2)
    Vector3 Maximum
    Vector3 Minimum
  class BoundingFrustum : IEquatable<BoundingFrustum>
    ctor(Matrix4x4 value)
    ctor(Matrix4x4 value, Vector2 offset, Vector2 size)
    Plane Bottom { get; }
    Plane Far { get; }
    Plane Left { get; }
    Matrix4x4 Matrix4x4 { get;  set; }
    Plane Near { get; }
    Plane Right { get; }
    Plane Top { get; }
    ContainmentType Contains(BoundingBox box)
    void Contains(ref BoundingBox box, out ContainmentType result)
    ContainmentType Contains(BoundingFrustum frustum)
    ContainmentType Contains(BoundingSphere sphere)
    void Contains(ref BoundingSphere sphere, out ContainmentType result)
    ContainmentType Contains(Vector3 point)
    void Contains(ref Vector3 point, out ContainmentType result)
    Vector3[] GetCorners()
    bool Intersects(BoundingBox box)
    void Intersects(ref BoundingBox box, out bool result)
    bool Intersects(BoundingFrustum frustum)
    bool Intersects(BoundingSphere sphere)
    void Intersects(ref BoundingSphere sphere, out bool result)
    PlaneIntersectionType Intersects(Plane plane)
    void Intersects(ref Plane plane, out PlaneIntersectionType result)
    float? Intersects(Ray ray)
    void Intersects(ref Ray ray, out float? result)
  struct BoundingSphere : IEquatable<BoundingSphere>
    ctor(BoundingBox value)
    ctor(Vector3[] points)
    ctor(Vector3 center, float radius)
    static BoundingSphere UnitSphere { get; }
    static BoundingSphere Merge(BoundingSphere value1, BoundingSphere value2)
    Vector3 Center
    float Radius
  static class Collision
    static ContainmentType BoxContainsBox(ref BoundingBox box1, ref BoundingBox box2)
    static ContainmentType BoxContainsPoint(ref BoundingBox box, ref Vector3 point)
    static ContainmentType BoxContainsSphere(ref BoundingBox box, ref BoundingSphere sphere)
    static bool BoxIntersectsBox(ref BoundingBox box1, ref BoundingBox box2)
    static bool BoxIntersectsSphere(ref BoundingBox box, ref BoundingSphere sphere)
    static void ClosestPointBoxPoint(ref BoundingBox box, ref Vector3 point, out Vector3 result)
    static void ClosestPointPlanePoint(ref Plane plane, ref Vector3 point, out Vector3 result)
    static void ClosestPointPointTriangle(ref Vector3 point, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3, out Vector3 result)
    static void ClosestPointSpherePoint(ref BoundingSphere sphere, ref Vector3 point, out Vector3 result)
    static void ClosestPointSphereSphere(ref BoundingSphere sphere1, ref BoundingSphere sphere2, out Vector3 result)
    static float DistanceBoxBox(ref BoundingBox box1, ref BoundingBox box2)
    static float DistanceBoxPoint(ref BoundingBox box, ref Vector3 point)
    static float DistancePlanePoint(ref Plane plane, ref Vector3 point)
    static float DistanceSpherePoint(ref BoundingSphere sphere, ref Vector3 point)
    static float DistanceSphereSphere(ref BoundingSphere sphere1, ref BoundingSphere sphere2)
    static PlaneIntersectionType PlaneIntersectsBox(ref Plane plane, ref BoundingBox box)
    static bool PlaneIntersectsPlane(ref Plane plane1, ref Plane plane2)
    static bool PlaneIntersectsPlane(ref Plane plane1, ref Plane plane2, out Ray line)
    static PlaneIntersectionType PlaneIntersectsPoint(ref Plane plane, ref Vector3 point)
    static PlaneIntersectionType PlaneIntersectsSphere(ref Plane plane, ref BoundingSphere sphere)
    static PlaneIntersectionType PlaneIntersectsTriangle(ref Plane plane, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
    static bool RayIntersectsBox(ref Ray ray, ref BoundingBox box, out float distance)
    static bool RayIntersectsBox(ref Ray ray, ref BoundingBox box, out Vector3 point)
    static bool RayIntersectsPlane(ref Ray ray, ref Plane plane, out float distance)
    static bool RayIntersectsPlane(ref Ray ray, ref Plane plane, out Vector3 point)
    static bool RayIntersectsPoint(ref Ray ray, ref Vector3 point)
    static bool RayIntersectsRay(ref Ray ray1, ref Ray ray2, out Vector3 point)
    static bool RayIntersectsSphere(ref Ray ray, ref BoundingSphere sphere, out float distance)
    static bool RayIntersectsSphere(ref Ray ray, ref BoundingSphere sphere, out Vector3 point)
    static bool RayIntersectsTriangle(ref Ray ray, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3, out float distance)
    static bool RayIntersectsTriangle(ref Ray ray, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3, out Vector3 point)
    static ContainmentType SphereContainsBox(ref BoundingSphere sphere, ref BoundingBox box)
    static ContainmentType SphereContainsPoint(ref BoundingSphere sphere, ref Vector3 point)
    static ContainmentType SphereContainsSphere(ref BoundingSphere sphere1, ref BoundingSphere sphere2)
    static ContainmentType SphereContainsTriangle(ref BoundingSphere sphere, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
    static bool SphereIntersectsSphere(ref BoundingSphere sphere1, ref BoundingSphere sphere2)
    static bool SphereIntersectsTriangle(ref BoundingSphere sphere, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
  enum ContainmentType
    Outside
    Inside
    Intersects
  struct KeyFrame<T> where T : struct
    float Time
    T Value
  class Math
    ctor()
    static Vector4 Abs(Vector4 a)
    static Vector3 Abs(Vector3 a)
    static Vector2 Abs(Vector2 a)
    static float Abs(float a)
    int Abs(int a)
    static Vector4 Acos(Vector4 a)
    static Vector3 Acos(Vector3 a)
    static Vector2 Acos(Vector2 a)
    static float Acos(float a)
    static Matrix4x4 Add(Matrix4x4 a, Matrix4x4 b)
    static float Angle(Vector4 a, Vector4 b)
    static float Angle(Vector3 a, Vector3 b)
    static float Angle(Vector2 a, Vector2 b)
    static float Angle(float a, float b)
    static bool AreZeroes(float[] values)
    static bool AreZeroes(Vector2[] values)
    static bool AreZeroes(Vector3[] values)
    static bool AreZeroes(Vector4[] values)
    static bool AreZeroes(Quaternion[] values)
    static Vector4 Asin(Vector4 a)
    static Vector3 Asin(Vector3 a)
    static Vector2 Asin(Vector2 a)
    static float Asin(float a)
    static Vector4 Atan(Vector4 a)
    static Vector3 Atan(Vector3 a)
    static Vector2 Atan(Vector2 a)
    static float Atan(float a)
    static Vector4 Atan2(Vector4 a, Vector4 b)
    static Vector3 Atan2(Vector3 a, Vector3 b)
    static Vector2 Atan2(Vector2 a, Vector2 b)
    static float Atan2(float a, float b)
    static Vector3 CalculateCentroid(Vector3[] positions, double[] weights = null)
    static float CalculateCentroidRootMeanSquareDistance(Vector3[] positions, Vector3 centroid, double[] weights = null)
    static float CalculatePositionWiseRootMeanSquareDistance(Vector3[] positions)
    static float CalculateRootMeanSquareDistance(Vector3[] a, Vector3[] b)
    static Vector4 CatmullRom(Vector4 value1, Vector4 value2, Vector4 value3, Vector4 value4, float weight)
    static Vector3 CatmullRom(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, float weight)
    static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, float weight)
    static float CatmullRom(float value1, float value2, float value3, float value4, float weight)
    static Vector4 CatmullRom(KeyFrame<Vector4>[] values, float time)
    static Vector4 Ceil(Vector4 a)
    static Vector3 Ceil(Vector3 a)
    static Vector2 Ceil(Vector2 a)
    static float Ceil(float a)
    static Vector4 Clamp(Vector4 a, Vector4 c1, Vector4 c2)
    static Vector3 Clamp(Vector3 a, Vector3 c1, Vector3 c2)
    static Vector2 Clamp(Vector2 a, Vector2 c1, Vector2 c2)
    static Vector4 Clamp(Vector4 a, float c1, float c2)
    static Vector3 Clamp(Vector3 a, float c1, float c2)
    static Vector2 Clamp(Vector2 a, float c1, float c2)
    static float Clamp(float a, float c1, float c2)
    static int Clamp(int a, int c1, int c2)
    static Vector3 ConvertAxis(Vector3 value, AxisConvention currentAxis, AxisConvention destinationAxis)
    static Vector4 ConvertAxis(Vector4 value, AxisConvention currentAxis, AxisConvention destinationAxis)
    static Matrix4x4 ConvertAxis(Matrix4x4 value, AxisConvention currentAxis, AxisConvention destinationAxis)
    static Vector4 Cos(Vector4 a)
    static Vector3 Cos(Vector3 a)
    static Vector2 Cos(Vector2 a)
    static float Cos(float a)
    static Vector4 Cosh(Vector4 a)
    static Vector3 Cosh(Vector3 a)
    static Vector2 Cosh(Vector2 a)
    static float Cosh(float a)
    static Vector3 Cross(Vector3 a, Vector3 b)
    static float Degrees(float radians)
    static Vector4 Dehomogenize(Vector4 a)
    static float Distance(Vector4 a, Vector4 b)
    static float Distance(Vector3 a, Vector3 b)
    static float Distance(Vector2 a, Vector2 b)
    static float Distance(float a, float b)
    static float DistanceSquared(Vector4 a, Vector4 b)
    static float DistanceSquared(Vector3 a, Vector3 b)
    static float DistanceSquared(Vector2 a, Vector2 b)
    static float DistanceSquared(float a, float b)
    static float Dot(Plane a, Plane b)
    static float Dot(Quaternion a, Quaternion b)
    static float Dot(Vector4 a, Vector4 b)
    static float Dot(Vector3 a, Vector3 b)
    static float Dot(Vector2 a, Vector2 b)
    static float Dot(float a, float b)
    static Vector4 Floor(Vector4 a)
    static Vector3 Floor(Vector3 a)
    static Vector2 Floor(Vector2 a)
    static float Floor(float a)
    static Vector2 GetClosestPoint(Vector2 start, Vector2 end, Vector2 position)
    static Vector2 GetClosestPoint(Vector2 start, Vector2 end, Vector2 position, out float distance, out float u)
    static Vector2 GetClosestPoint(Vector2 start, Vector2 end, Vector2 position, out float distance, out float u, out float x)
    static Vector2 GetClosestPointInClosedSegment(Vector2 start, Vector2 end, Vector2 position, out float distance, out float u)
    static Vector4 Hermite(Vector4 value1, Vector4 tangent1, Vector4 value2, Vector4 tangent2, float weight)
    static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float weight)
    static Vector2 Hermite(Vector2 value1, Vector2 tangent1, Vector2 value2, Vector2 tangent2, float weight)
    static float Hermite(float value1, float tangent1, float value2, float tangent2, float weight)
    static Matrix4x4 Invert(Matrix4x4 value)
    static Quaternion Invert(Quaternion value)
    static Vector4 Invert(Vector4 a)
    static Vector3 Invert(Vector3 a)
    static Vector2 Invert(Vector2 a)
    static float Invert(float a)
    static bool IsNumber(float value)
    static bool IsNumber(Vector2 value)
    static bool IsNumber(Vector3 value)
    static bool IsNumber(Vector4 value)
    static bool IsNumber(Quaternion value)
    static bool IsPower2(int v)
    static float Length(Plane a)
    static float Length(Quaternion a)
    static float Length(Vector4 a)
    static float Length(Vector3 a)
    static float Length(Vector2 a)
    static float Length(float a)
    static float LengthSquared(Quaternion a)
    static float LengthSquared(Vector4 a)
    static float LengthSquared(Vector3 a)
    static float LengthSquared(Vector2 a)
    static float LengthSquared(float a)
    static Quaternion Lerp(Quaternion value1, Quaternion value2, float weight)
    static float[] Lerp(float[] value1, float[] value2, float weight)
    static Vector4 Lerp(Vector4 value1, Vector4 value2, float weight)
    static Vector3 Lerp(Vector3 value1, Vector3 value2, float weight)
    static Vector2 Lerp(Vector2 value1, Vector2 value2, float weight)
    static float Lerp(float value1, float value2, float weight)
    static Vector4 Maximum(Vector4 a, Vector4 b)
    static Vector3 Maximum(Vector3 a, Vector3 b)
    static Vector2 Maximum(Vector2 a, Vector2 b)
    static float Maximum(float a, float b)
    static int Maximum(int a, int b)
    static Vector4 Minimum(Vector4 a, Vector4 b)
    static Vector3 Minimum(Vector3 a, Vector3 b)
    static Vector2 Minimum(Vector2 a, Vector2 b)
    static float Minimum(float a, float b)
    static int Minimum(int a, int b)
    static int NextPower2(int v)
    static Plane Normalize(Plane a)
    static Quaternion Normalize(Quaternion a)
    static Vector4 Normalize(Vector4 a)
    static Vector3 Normalize(Vector3 a)
    static Vector2 Normalize(Vector2 a)
    static float Normalize(float a)
    static Matrix4x4 Outer(Vector3 a, Vector3 b)
    static Vector4 Pow(Vector4 a, float power)
    static Vector3 Pow(Vector3 a, float power)
    static Vector2 Pow(Vector2 a, float power)
    static float Pow(float a, float power)
    static float Radians(float degrees)
    static float Random()
    static float Random(float maximum)
    static Vector2 Random(Vector2 maximum)
    static Vector3 Random(Vector3 maximum)
    static Vector4 Random(Vector4 maximum)
    static Vector4 Round(Vector4 a)
    static Vector3 Round(Vector3 a)
    static Vector2 Round(Vector2 a)
    static float Round(float value)
    static Vector4 Round(Vector4 a, float interval)
    static Vector3 Round(Vector3 a, float interval)
    static Vector2 Round(Vector2 a, float interval)
    static float Round(float a, float interval)
    static Vector4 Saturate(Vector4 a)
    static Vector3 Saturate(Vector3 a)
    static Vector2 Saturate(Vector2 a)
    static float Saturate(float a)
    static Vector4 Sin(Vector4 a)
    static Vector3 Sin(Vector3 a)
    static Vector2 Sin(Vector2 a)
    static float Sin(float a)
    static Vector4 Sinh(Vector4 a)
    static Vector3 Sinh(Vector3 a)
    static Vector2 Sinh(Vector2 a)
    static float Sinh(float a)
    static Quaternion Slerp(Quaternion value1, Quaternion value2, float weight)
    static Vector4 SmoothStep(Vector4 value1, Vector4 value2, float weight)
    static Vector3 SmoothStep(Vector3 value1, Vector3 value2, float weight)
    static Vector2 SmoothStep(Vector2 value1, Vector2 value2, float weight)
    static float SmoothStep(float value1, float value2, float weight)
    static Vector4 Sqrt(Vector4 a)
    static Vector3 Sqrt(Vector3 a)
    static Vector2 Sqrt(Vector2 a)
    static float Sqrt(float a)
    static float Sum(Plane a)
    static float Sum(Quaternion a)
    static float Sum(Vector4 a)
    static float Sum(Vector3 a)
    static float Sum(Vector2 a)
    static float Sum(float a)
    static Vector4 Tan(Vector4 a)
    static Vector3 Tan(Vector3 a)
    static Vector2 Tan(Vector2 a)
    static float Tan(float a)
    static Vector4 Trunc(Vector4 a)
    static Vector3 Trunc(Vector3 a)
    static Vector2 Trunc(Vector2 a)
    static float Trunc(float a)
    static float HalfPI
    static float PI
    static float QuarterPI
    static float ZeroTolerance
  static class MathExtensions
    static Quaternion Divide(Quaternion value, float scale)
    static Plane Divide(Plane value1, Plane value2)
    static Plane Divide(Plane value, float scale)
    static Quaternion Multiply(Quaternion value, float scale)
    static Plane Multiply(Plane value1, Plane value2)
    static Plane Multiply(Plane value, float scale)
    static void Set(ref Matrix4x4 m, Vector3 x, Vector3 y, Vector3 z, Vector3 p)
    static Vector2 XY(Vector4 value)
    static Vector2 XY(Vector3 value)
    static Vector3 XYZ(Vector4 value)
    static Vector2 XZ(Vector3 value)
    static Vector2 YX(Vector4 value)
    static Vector2 YX(Vector3 value)
    static Vector2 YZ(Vector3 value)
    static Vector2 ZX(Vector3 value)
    static Vector3 ZXY(Vector4 value)
    static Vector2 ZY(Vector3 value)
  class OneEuroFilter
    ctor(float freq = 10, float mincutoff = 1, float beta = 0, float dcutoff = 1)
    float PrevValue { get; }
    float Value { get; }
    float Filter(float value, float timestamp = -1)
    void UpdateParams(float freq, float mincutoff = 1, float beta = 0, float dcutoff = 1)
  enum PlaneIntersectionType
    Back
    Front
    Intersecting
  struct Ray : IEquatable<Ray>
    ctor(Vector3 position, Vector3 direction)
    Vector3 Direction
    Vector3 Position
