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
