# Ikon.Resonance.Core Public API

namespace Ikon.Resonance.Core
  class AudioContainer
    ctor(string id, float[] samples, int sampleRate, int channelCount, bool isFirst, bool isLast)
    int ChannelCount { get;  set; }
    string Id { get;  set; }
    bool IsFirst { get;  set; }
    bool IsLast { get;  set; }
    int SampleRate { get;  set; }
    float[] Samples { get;  set; }
  class AudioEncoderOptions
    ctor()
    int? Bitrate { get;  set; }
    int? Complexity { get;  set; }
    bool? UseVBR { get;  set; }
  class OpusEncoder.EncodedAudio
    ctor()
    float AverageVolume { get; }
    ReadOnlyMemory<byte> Data { get; }
    double EncodingTimeMs { get; }
    bool IsFirst { get; }
    bool IsLast { get; }
  class OpusDecoder : IDisposable
    ctor(int sampleRate, int channelCount)
    ReadOnlyMemory<float> DecodeAsFloat(ReadOnlySpan<byte> data, bool isFirst, bool decodeFec = false)
    ReadOnlyMemory<short> DecodeAsShort(ReadOnlySpan<byte> data, bool isFirst, bool decodeFec = false)
    void Dispose()
  class OpusEncoder : IDisposable
    ctor(OpusEncoderOptions options)
    float FrameDurationMs { get; }
    int FrameSizeInInterleavedSamples { get; }
    int FrameSizePerChannelInSamples { get; }
    void Dispose()
    IEnumerable<OpusEncoder.EncodedAudio> Encode(ReadOnlyMemory<float> samples, bool isFirst, bool isLast)
  class OpusEncoderOptions
    ctor()
    OpusApplication? Application { get;  set; }
    int? Bitrate { get;  set; }
    int ChannelCount { get;  set; }
    int? Complexity { get;  set; }
    float FrameDurationMs { get;  set; }
    int InputBufferSizeMs { get;  set; }
    OpusBandwidth? MaxBandwidth { get;  set; }
    int SampleRate { get;  set; }
    OpusSignal? SignalType { get;  set; }
    bool? UseConstrainedVBR { get;  set; }
    bool? UseVBR { get;  set; }
    static OpusEncoderOptions FromAudioEncoderOptions(AudioEncoderOptions options)
