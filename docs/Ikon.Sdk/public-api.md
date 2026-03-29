# Ikon.Sdk Public API

namespace Ikon.Sdk
  // Configuration for API key authentication mode. Use this for programmatic access to cloud channels.
  class ApiKeyConfig
    ctor()
    // API key for the space (from portal, format: 'ikon-xxxxx').
    string ApiKey { get;  set; }
    // Backend environment. Defaults to Production.
    BackendType BackendType { get;  set; }
    // Optional channel key (slug) for spaces with multiple channels. If not provided, connects to the first available channel.
    string ChannelKey { get;  set; }
    // Client type for this connection. Default: DesktopApp
    ClientType ClientType { get;  set; }
    // External user identifier - an arbitrary string to identify the user. This does not need to be an internal Ikon user ID. The backend will create/map an internal user for this external ID.
    string ExternalUserId { get;  set; }
    // Optional session ID for targeting precomputed sessions.
    string SessionId { get;  set; }
    // Space ID (MongoDB ObjectId from portal).
    string SpaceId { get;  set; }
    // User type for this connection. Default: Human
    UserType UserType { get;  set; }
  // Async event handler delegate.
  delegate AsyncEventHandler<TEventArgs> where TEventArgs : EventArgs
    Task AsyncEventHandler`1<TEventArgs>(object sender, TEventArgs e)
  // Event arguments raised when an incoming audio frame is received
  class AudioInputFrameEventArgs : EventArgs
    // Event arguments raised when an incoming audio frame is received
    ctor(string streamId, float[] samples, bool isFirst, bool isLast, TimeSpan totalDuration)
    // Whether this is the first frame in a sequence
    bool IsFirst { get; }
    // Whether this is the last frame in a sequence
    bool IsLast { get; }
    // Decoded floating point PCM samples in range [-1.0, 1.0]
    float[] Samples { get; }
    // Unique identifier for the audio stream
    string StreamId { get; }
    // Total duration of the audio if known, otherwise zero
    TimeSpan TotalDuration { get;  set; }
  // Event arguments raised when an incoming audio stream begins
  class AudioInputStreamBeginEventArgs : EventArgs
    // Event arguments raised when an incoming audio stream begins
    ctor(string streamId, string description, string sourceType, AudioCodec codec, string codecDetails, int sampleRate, int channelCount)
    // Number of audio channels
    int ChannelCount { get; }
    // Audio codec used for encoding/decoding
    AudioCodec Codec { get; }
    // Codec-specific details
    string CodecDetails { get; }
    // Description of the audio stream
    string Description { get; }
    // Sample rate in Hz (can be modified by event handler)
    int SampleRate { get;  set; }
    // Source type of the audio stream (e.g., "microphone")
    string SourceType { get; }
    // Unique identifier for the audio stream
    string StreamId { get; }
    // Controls when frames are output (can be modified by event handler)
    AudioInputStreamingMode StreamingMode { get;  set; }
  // Event arguments raised when an incoming audio stream ends
  class AudioInputStreamEndEventArgs : EventArgs
    // Event arguments raised when an incoming audio stream ends
    ctor(string streamId)
    // Unique identifier for the audio stream
    string StreamId { get; }
  // Controls when incoming audio frames are output to listeners
  enum AudioInputStreamingMode
    Streaming
    DelayUntilTotalDurationKnown
    DelayUntilIsLast
  // Configuration for backend authentication mode. Uses existing IkonBackend login credentials (from login.json or environment variables). This is the preferred mode for internal Ikon C# applications.
  class BackendConfig
    ctor()
    // Optional channel key (slug) for spaces with multiple channels. If not provided, connects to the first available channel.
    string ChannelKey { get;  set; }
    // Client type for this connection. Default: DesktopApp
    ClientType ClientType { get;  set; }
    // External user identifier - an arbitrary string to identify the user. This does not need to be an internal Ikon user ID. The backend will create/map an internal user for this external ID.
    string ExternalUserId { get;  set; }
    // Optional session ID for targeting precomputed sessions.
    string SessionId { get;  set; }
    // Space ID (MongoDB ObjectId from portal).
    string SpaceId { get;  set; }
    // User type for this connection. Default: Human
    UserType UserType { get;  set; }
  // Backend environment type.
  enum BackendType
    Production
    Development
  // Connection state of the IkonClient.
  enum ConnectionState
    Idle
    Connecting
    Connected
    Reconnecting
    Offline
  class IkonClient.ConnectionStateEventArgs : EventArgs
    ctor(ConnectionState state)
    ConnectionState State { get; }
  // Helper methods for ConnectionState.
  static class ConnectionStateExtensions
    // Returns true if the state represents a successful connection.
    static bool IsConnected(ConnectionState state)
    // Returns true if the state represents an active connection attempt.
    static bool IsConnecting(ConnectionState state)
    // Returns true if the state represents a disconnected state.
    static bool IsOffline(ConnectionState state)
  class IkonClient.ErrorEventArgs : EventArgs
    ctor(Exception error)
    Exception Error { get; }
  // Main client for connecting to Ikon servers. Features: - Single connection per client instance - Three authentication modes: Local, ApiKey, Backend - Automatic reconnection with exponential backoff - Audio encoding/decoding helpers - Function registration via FunctionRegistry
  sealed class IkonClient : IAsyncDisposable
    // Creates a new IkonClient with the specified configuration. Each IkonClient instance gets its own FunctionRegistry, enabling multiple SDK connections to run independently without conflicts (e.g., when running SDK inside an Ikon app).
    ctor(IkonClientConfig config)
    // Client context from the server. Available after connection is established.
    Context ClientContext { get; }
    // Configuration used to create this client.
    IkonClientConfig Config { get; }
    // Default encoder options for audio output
    AudioEncoderOptions DefaultEncoderOptions { get;  set; }
    // Function registry for this client instance. Each IkonClient has its own isolated FunctionRegistry, allowing multiple SDK connections to run independently (e.g., when running SDK inside an Ikon app, or multiple SDK clients).
    FunctionRegistry FunctionRegistry { get; }
    // Global state from the server. Available after connection is established.
    GlobalState GlobalState { get; }
    // Current connection state.
    ConnectionState State { get; }
    // Connect to the Ikon server.
    Task ConnectAsync(CancellationToken ct = null)
    // Disconnect from the server and release connection-specific resources.
    Task DisconnectAsync()
    // Disposes the client and releases all resources.
    ValueTask DisposeAsync()
    // Sends audio data to the server.
    ValueTask SendAudioAsync(ReadOnlyMemory<float> samples, int sampleRate, int channelCount, bool isFirst, bool isLast, string streamId = null, TimeSpan totalDuration = null, AudioEncoderOptions encoderOptions = null, IReadOnlyList<int> targetIds = null)
    // Send a protocol message to the server.
    ValueTask SendMessageAsync(ProtocolMessage message)
    ValueTask SendMessageAsync<T>(T payload)
    // Signal that the client is ready. Should be called after initialization in the ReadyAsync event handler.
    Task SignalReadyAsync()
    // Wait for a specific client to connect and become ready.
    Task<bool> WaitForClientAsync(string productId = null, string userId = null, TimeSpan timeout = null)
    // Event raised when an incoming audio frame is received and decoded
    event AsyncEventHandler<AudioInputFrameEventArgs> AudioInputFrameAsync
    // Event raised when an incoming audio stream begins
    event AsyncEventHandler<AudioInputStreamBeginEventArgs> AudioInputStreamBeginAsync
    // Event raised when an incoming audio stream ends
    event AsyncEventHandler<AudioInputStreamEndEventArgs> AudioInputStreamEndAsync
    // Event triggered after disconnection.
    event AsyncEventHandler<EventArgs> DisconnectedAsync
    // Event triggered when an error occurs.
    event AsyncEventHandler<IkonClient.ErrorEventArgs> ErrorOccurredAsync
    // Event triggered when a protocol message is received.
    event AsyncEventHandler<MessageEventArgs> MessageReceivedAsync
    // Event triggered when connection is fully established and ready. Called before SignalReadyAsync() should be called.
    event AsyncEventHandler<EventArgs> ReadyAsync
    // Event triggered when connection state changes.
    event AsyncEventHandler<IkonClient.ConnectionStateEventArgs> StateChangedAsync
    // Event triggered when server is stopping. Messages can still be sent in this handler.
    event AsyncEventHandler<EventArgs> StoppingAsync
  // Configuration for IkonClient. Exactly one of Local or ApiKey must be provided.
  class IkonClientConfig
    ctor()
    // API key authentication for programmatic access. Use this for libraries, scripts, plugins that need to connect to cloud channels.
    ApiKeyConfig ApiKey { get;  set; }
    // Backend authentication using existing IkonBackend login. Use this for internal Ikon C# applications that have already logged in via CLI.
    BackendConfig Backend { get;  set; }
    // Description for this client. Default: "Ikon SDK C#"
    string Description { get;  set; }
    // Device ID for the connection. If not provided, a random one will be generated.
    string DeviceId { get;  set; }
    // Installation ID.
    string InstallId { get;  set; }
    // Local server configuration for development mode. Use this when connecting to a local Ikon server.
    LocalConfig Local { get;  set; }
    // User locale (e.g., "en-US"). Default: "en-US"
    string Locale { get;  set; }
    // Opcode groups to receive from server. Default: All groups
    Opcode OpcodeGroupsFromServer { get;  set; }
    // Opcode groups to send to server. Default: All groups
    Opcode OpcodeGroupsToServer { get;  set; }
    // Client parameters passed to the server.
    Dictionary<string, string> Parameters { get;  set; }
    // Payload type for protocol messages. Default: Teleport
    PayloadType PayloadType { get;  set; }
    // Product identifier.
    string ProductId { get;  set; }
    // Timeout configuration.
    TimeoutConfig Timeouts { get;  set; }
    // User agent string.
    string UserAgent { get;  set; }
    // Version identifier.
    string VersionId { get;  set; }
    // Validates the configuration.
    void Validate()
  // Configuration for local development mode. Connects directly to a local Ikon server.
  class LocalConfig
    ctor()
    // Host of the local Ikon server. Example: "localhost"
    string Host { get;  set; }
    // HTTPS port of the local Ikon server. Example: 8443
    int HttpsPort { get;  set; }
    // User ID for the connection. Falls back to "local" if not provided (with a warning).
    string UserId { get;  set; }
  // Event arguments for protocol messages.
  class MessageEventArgs : EventArgs
    // Event arguments for protocol messages.
    ctor(ProtocolMessage message)
    // The protocol message.
    ProtocolMessage Message { get; }
  // Timeout configuration for the SDK.
  class TimeoutConfig
    ctor()
    // Initial delay before the first reconnection attempt. Each subsequent attempt doubles the delay (e.g. 500ms, 1s, 2s, 4s). Default: 500 milliseconds
    TimeSpan InitialReconnectDelay { get;  set; }
    // Maximum number of reconnection attempts. Default: 4
    int MaxReconnectAttempts { get;  set; }
  // Version class
  static class Version
    // Version string for the library
    static string VersionString
