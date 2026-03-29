# Audio & Video

## Audio & Video

### Audio

```csharp
private Audio Audio { get; } = new(host);

// Send audio to clients immediately (sends all audio at once)
await Audio.SendAsync(samples, sampleRate, channelCount, isFirst, isLast, streamId);

// Send speech (throttles output to real-time playback speed and crossfades between sources)
Audio.SendSpeech(audioChunk);

// Receive audio input from client microphone
Audio.AudioInputStreamBeginAsync += async args => { /* args.StreamId, args.SampleRate, args.ChannelCount */ };
Audio.AudioInputFrameAsync += async args => { /* args.Samples, args.IsFirst, args.IsLast */ };
Audio.AudioInputStreamEndAsync += async args => { /* cleanup */ };

// Stream info and cleanup
var info = Audio.GetOutputStreamInfo(streamId); // StreamId, TrackId, Codec, SampleRate, ChannelCount
await Audio.CloseAsync(streamId);
await Audio.CloseAllAsync();
```

### Video

```csharp
private Video Video { get; } = new(host);

// Receive video input from client camera/screen
Video.VideoInputStreamBeginAsync += async args => { /* args.StreamId, args.Codec, args.Width, args.Height */ };
Video.VideoInputFrameAsync += async args => { /* args.Data, args.FrameNumber, args.IsKey */ };
Video.VideoInputStreamEndAsync += async args => { /* cleanup */ };

// Forward/echo video to other clients
await Video.SendAsync(data, frameNumber, isKey, timestampInUs, durationInUs, codec, width, height, framerate, streamId);

// Stream info and cleanup
var info = Video.GetOutputStreamInfo(streamId); // StreamId, TrackId, Codec, Width, Height, Framerate
await Video.CloseAsync(streamId);
await Video.CloseAllAsync();
```

Use `CaptureButton` in the UI to start audio/video capture from the client.

### Audio Effects & Mixer

Apply real-time audio effects via `IAudioEffect` from `Ikon.Resonance.Effects`:

```csharp
using Ikon.Resonance.Effects;

// Available effects: BitCrusherAudioEffect, ChorusAudioEffect, DelayAudioEffect,
// DistortionAudioEffect, FlangerAudioEffect, GainAudioEffect, PannerAudioEffect,
// ReverbAudioEffect, RingModulatorAudioEffect, TremoloAudioEffect

// Add effects to a SpeechMixer
var mixer = new SpeechMixer();
mixer.AddSamples(container, effects: [new ReverbAudioEffect(), new DelayAudioEffect()]);
```

### Synthesis

Build synthesizers with `Ikon.Resonance.Synth`:

```csharp
using Ikon.Resonance.Synth;
using Ikon.Resonance.Synth.Oscillators;
using Ikon.Resonance.Synth.Filters;
using Ikon.Resonance.Synth.Envelopes;

// Oscillators, filters, envelopes, Moog synth, sequencer
// See Ikon.Resonance Public API reference below for full class listings
```

---

# Ikon.Resonance Public API

namespace Ikon.Resonance
  struct AudioFrameEx
    ctor(ReadOnlyMemory<float> samples, int sampleRate, int channelCount, bool isFirst, bool isLast, string streamId, TimeSpan totalDuration = null, AudioEncoderOptions encoderOptions = null, IReadOnlyList<int> targetIds = null, IReadOnlyList<AudioAnalysisResult> analysisResults = null, IReadOnlyList<AudioShapeSetDeclaration> shapeSetDeclarations = null)
    IReadOnlyList<AudioAnalysisResult> AnalysisResults { get; }
    int ChannelCount { get; }
    AudioEncoderOptions EncoderOptions { get; }
    bool IsFirst { get; }
    bool IsLast { get; }
    int SampleRate { get; }
    ReadOnlyMemory<float> Samples { get; }
    IReadOnlyList<AudioShapeSetDeclaration> ShapeSetDeclarations { get; }
    string StreamId { get; }
    IReadOnlyList<int> TargetIds { get; }
    TimeSpan TotalDuration { get; }
  sealed class AudioGenerator
    ctor()
    bool IsRunning { get; }
    AudioGeneratorOptions Options { get; }
    void AddEffect(IAudioEffect effect)
    string AddSource(IAudioSource source)
    void ClearEffects()
    T GetSource<T>(string streamId)
    IEnumerable<ValueTuple<string, T>> GetSourcesOfType<T>()
    void RemoveEffectAt(int index)
    bool RemoveSource(string streamId)
    void ReplaceEffect(int index, IAudioEffect newEffect)
    Task StartAsync(Func<AudioGeneratorFrame, ValueTask> onFrame, CancellationToken cancellationToken = null)
    Task StopAsync()
    void UpdateOptions(Action<AudioGeneratorOptions> configure)
  struct AudioGeneratorFrame
    ctor(ReadOnlyMemory<float> samples, int sampleRate, int channelCount, bool isFirst, bool isLast, string streamId)
    int ChannelCount { get; }
    bool IsFirst { get; }
    bool IsLast { get; }
    int SampleRate { get; }
    ReadOnlyMemory<float> Samples { get; }
    string StreamId { get; }
  sealed class AudioGeneratorOptions
    ctor()
    int BurstPacketCount { get;  set; }
    double DriftFactor { get;  set; }
    bool EnableBurstMode { get;  set; }
    bool EnableDrift { get;  set; }
    bool EnableJitter { get;  set; }
    bool EnablePause { get;  set; }
    int JitterMs { get;  set; }
    int PauseDurationMs { get;  set; }
    int PauseIntervalMs { get;  set; }
  class AudioMetrics
    ctor()
    double AvgEncodeTimeMs { get; }
    double AvgIpdMs { get; }
    double CpuUsagePercent { get; }
    bool Enabled { get;  set; }
    double JitterMs { get; }
    bool LogMetrics { get;  set; }
    double MaxIpdMs { get; }
    double MinIpdMs { get; }
    int StreamCount { get; }
    double UpdateIntervalSeconds { get;  set; }
    void RecordPacket(string streamId, double encodingTimeMs)
    void Remove(string streamId)
    void Reset(string streamId)
    void ResetAll()
    event Action Updated
  static class AudioResampler
    static int CalculateResampledFrameCount(int inputFrameCount, int inputSampleRate, int outputSampleRate)
    static void ConvertChannels(ReadOnlySpan<float> source, Span<float> destination, int inputChannelCount, int outputChannelCount)
    static bool IsSupportedChannelCount(int channelCount)
    static void Resample(ReadOnlySpan<float> source, Span<float> destination, int inputSampleRate, int outputSampleRate, int inputChannelCount, int outputChannelCount)
    static int MaxSupportedChannelCount
  sealed class AudioTimer
    ctor()
    void Reset()
    void WaitUntil(long targetTicks, CancellationToken token)
    Task WaitUntilAsync(long targetTicks, CancellationToken token)
  static class AudioUtils
    static int ConvertFloatToPcm16Bytes(ReadOnlySpan<float> input, Span<byte> output)
    static byte[] ConvertFloatToPcm16Bytes(ReadOnlySpan<float> input)
    static int ConvertFloatToPcm16Shorts(ReadOnlySpan<float> input, Span<short> output)
    static short[] ConvertFloatToPcm16Shorts(ReadOnlySpan<float> input)
    static int ConvertPcm16ToFloat(ReadOnlySpan<short> input, Span<float> output)
    static float[] ConvertPcm16ToFloat(ReadOnlySpan<short> input)
    static int ConvertPcm16ToFloat(ReadOnlySpan<byte> input, Span<float> output)
    static float[] ConvertPcm16ToFloat(ReadOnlySpan<byte> input)
  enum CrossfadeCurve
    Linear
    EqualPower
  enum FadeMode
    Sequential
    Crossfade
  interface IAudioSource
    abstract void GenerateAudio(Span<float> buffer, int samplesPerChannel, int channelCount, int sampleRate)
  enum WavFile.SampleFormat
    Short
    Float
  sealed class SilenceRemover
    ctor(int sampleRate, int channelCount, SilenceRemoverConfig config = null)
    static IAsyncEnumerable<float[]> FilterAsync(IAsyncEnumerable<float[]> source, int sampleRate, int channelCount, SilenceRemoverConfig config = null, CancellationToken ct = null)
    float[] ProcessChunk(ReadOnlySpan<float> chunk)
    void Reset()
  sealed class SilenceRemoverConfig
    ctor()
    float AttackAlpha { get;  set; }
    float InitialNoiseFloor { get;  set; }
    float MaxNoiseFloor { get;  set; }
    float NoiseFloorAlpha { get;  set; }
    float NoiseFloorMultiplier { get;  set; }
    float NoiseFloorOffset { get;  set; }
    int PreBufferMs { get;  set; }
    float ReleaseAlpha { get;  set; }
    int SpeechOnsetChunks { get;  set; }
    int TrailingSilenceMs { get;  set; }
  sealed class SpeechMixer : IAsyncDisposable
    ctor(SpeechMixerConfig config = null)
    AudioEncoderOptions EncoderOptions { get;  set; }
    bool IsPaused { get; }
    string StreamId { get; }
    void AddSamples(AudioContainer container, IReadOnlyList<IAudioEffect> effects = null, IReadOnlyList<IAudioAnalyzer> analyzers = null, IReadOnlyList<int> targetIds = null)
    void AddSamples(string speechEventId, ReadOnlySpan<float> samples, int sampleRate, int channelCount, bool isFirst, bool isLast, IReadOnlyList<IAudioEffect> effects = null, IReadOnlyList<IAudioAnalyzer> analyzers = null, IReadOnlyList<int> targetIds = null)
    void Clear()
    ValueTask DisposeAsync()
    void FadeOut()
    void Pause()
    void Resume()
    Task StartAsync(Func<AudioFrameEx, ValueTask> onFrame, CancellationToken cancellationToken = null)
  sealed class SpeechMixerConfig
    ctor()
    CrossfadeCurve CrossfadeCurve { get;  set; }
    double EndPaddingMs { get;  set; }
    double FadeInMs { get;  set; }
    FadeMode FadeMode { get;  set; }
    double FadeOutMs { get;  set; }
    double MaxBufferSizeMs { get;  set; }
    double MaxPaddingTimeMs { get;  set; }
    double PaddingThreshold { get;  set; }
  class WavFile : IDisposable
    ctor(int sampleRate, int channelCount, WavFile.SampleFormat sampleFormat)
    void AddSamples(ReadOnlySpan<short> samples)
    void AddSamples(ReadOnlySpan<float> samples)
    byte[] AsArray()
    Stream AsStream()
    void Dispose()
    void SaveToFile(string filePath)

namespace Ikon.Resonance.Analysis
  struct AudioAnalysisResult
    uint SetId { get;  set; }
    float[] Values { get;  set; }
  struct AudioShapeSetDeclaration
    string Name { get;  set; }
    uint SetId { get;  set; }
    string[] ShapeNames { get;  set; }
  interface IAudioAnalyzer
    AudioShapeSetDeclaration ShapeSetDeclaration { get; }
    abstract IAudioAnalyzerInstance Create(int sampleRate, int channelCount)
  interface IAudioAnalyzerInstance
    abstract AudioAnalysisResult Analyze(ReadOnlySpan<float> buffer)
    abstract void Reset()
  sealed class VisemeAnalyzer : IAudioAnalyzer
    ctor()
    AudioShapeSetDeclaration ShapeSetDeclaration { get; }
    IAudioAnalyzerInstance Create(int sampleRate, int channelCount)

namespace Ikon.Resonance.Effects
  sealed class BitCrusherAudioEffect : IAudioEffect
    ctor()
    ctor(int bitDepth, int downsampleFactor, float mix)
    IAudioEffectInstance Create(int sampleRate, int channelCount)
  sealed class ChorusAudioEffect : IAudioEffect
    ctor()
    ctor(float baseDelayMs, float depthMs, float rateHz, float mix, float stereoPhaseOffsetDegrees = 90)
    IAudioEffectInstance Create(int sampleRate, int channelCount)
  sealed class DelayAudioEffect : IAudioEffect
    ctor()
    ctor(float delayMs, float feedback, float mix, float feedbackDamping = 0.25)
    IAudioEffectInstance Create(int sampleRate, int channelCount)
  interface IAudioEffect
    abstract IAudioEffectInstance Create(int sampleRate, int channelCount)
  interface IAudioEffectInstance
    abstract void Process(Span<float> buffer)
    abstract void Reset()
  sealed class ReverbAudioEffect : IAudioEffect
    ctor()
    ctor(float roomSize, float decay, float damping, float mix)
    ctor(IReadOnlyList<float> feedbacks, IReadOnlyList<float> mixes, IReadOnlyList<float> delayTimesMs, IReadOnlyList<float> cutoffFrequencies)
    IAudioEffectInstance Create(int sampleRate, int channelCount)
  sealed class RobotVoiceAudioEffect : IAudioEffect
    ctor()
    ctor(float carrierFrequencyHz, float mix, float drive)
    IAudioEffectInstance Create(int sampleRate, int channelCount)
  sealed class SaturationAudioEffect : IAudioEffect
    ctor()
    ctor(float drive, float mix)
    IAudioEffectInstance Create(int sampleRate, int channelCount)
  sealed class TelephoneAudioEffect : IAudioEffect
    ctor()
    ctor(float lowCutHz, float highCutHz, float mix, float drive)
    IAudioEffectInstance Create(int sampleRate, int channelCount)
  sealed class TremoloAudioEffect : IAudioEffect
    ctor()
    ctor(float rateHz, float depth, float mix, float stereoPhaseOffsetDegrees = 90)
    IAudioEffectInstance Create(int sampleRate, int channelCount)

namespace Ikon.Resonance.Synth
  sealed class DrumMachineSource : IAudioSource
    ctor(double bpm)
    double Bpm { get; }
    void GenerateAudio(Span<float> buffer, int samplesPerChannel, int channelCount, int sampleRate)
  sealed class SineWaveSource : IAudioSource
    ctor(int frequencyIndex)
    int FrequencyIndex { get; }
    double FrequencyLeft { get; }
    double FrequencyRight { get; }
    void GenerateAudio(Span<float> buffer, int samplesPerChannel, int channelCount, int sampleRate)

namespace Ikon.Resonance.Synth.Envelopes
  sealed class AdsrEnvelope
    ctor()
    double Attack { get;  set; }
    double Decay { get;  set; }
    bool IsActive { get; }
    double Output { get; }
    double Release { get;  set; }
    EnvelopeStage Stage { get; }
    double Sustain { get;  set; }
    void Gate(bool gate)
    void NoteOff()
    void NoteOn()
    double Process()
    void Reset()
    void SetSampleRate(double sampleRate)
  enum EnvelopeStage
    Idle
    Attack
    Decay
    Sustain
    Release

namespace Ikon.Resonance.Synth.Filters
  sealed class MoogLadderFilter
    ctor()
    double Cutoff { get;  set; }
    double Drive { get;  set; }
    double Resonance { get;  set; }
    double Process(double input)
    void Reset()
    void SetSampleRate(double sampleRate)

namespace Ikon.Resonance.Synth.Modulation
  sealed class Lfo
    ctor()
    double Phase { get; }
    double Rate { get;  set; }
    LfoWaveform Waveform { get;  set; }
    double Process()
    void Reset()
    void SetSampleRate(double sampleRate)
    void Sync()
  enum LfoWaveform
    Sine
    Triangle
    Saw
    Square
    SampleAndHold

namespace Ikon.Resonance.Synth.Moog
  sealed class MoogSynth
    ctor(int voiceCount = 8)
    Lfo Lfo { get; }
    double NoiseFloor { get;  set; }
    MoogSynthPatch Patch { get;  set; }
    VoiceAllocator VoiceAllocator { get; }
    void AllNotesOff()
    void ApplyPatch()
    void NoteOff(int noteNumber)
    void NoteOn(int noteNumber, double velocity = 1)
    double Process()
    void Process(Span<float> buffer, int samplesPerChannel, int channelCount, int sampleRate)
    void Reset()
    void SetSampleRate(double sampleRate)
  sealed class MoogSynthPatch
    ctor()
    double AmpAttack { get;  set; }
    double AmpDecay { get;  set; }
    double AmpRelease { get;  set; }
    double AmpSustain { get;  set; }
    double DriftAmount { get;  set; }
    double FilterAttack { get;  set; }
    double FilterCutoff { get;  set; }
    double FilterDecay { get;  set; }
    double FilterEnvAmount { get;  set; }
    double FilterKeyTrack { get;  set; }
    double FilterRelease { get;  set; }
    double FilterResonance { get;  set; }
    double FilterSustain { get;  set; }
    double LfoRate { get;  set; }
    double LfoToFilter { get;  set; }
    double LfoToPitch { get;  set; }
    double LfoToPwm { get;  set; }
    LfoWaveform LfoWaveform { get;  set; }
    double MasterVolume { get;  set; }
    string Name { get;  set; }
    double NoiseLevel { get;  set; }
    double Osc1Level { get;  set; }
    double Osc2Level { get;  set; }
    double Osc2PulseWidth { get;  set; }
    double SubLevel { get;  set; }
  static class MoogSynthPresets
    static MoogSynthPatch AcidLead()
    static MoogSynthPatch[] All()
    static MoogSynthPatch Brass()
    static MoogSynthPatch FatBass()
    static MoogSynthPatch FilterSweep()
    static MoogSynthPatch LushPad()
    static MoogSynthPatch Pluck()
  sealed class MoogSynthSource : IAudioSource
    ctor(MoogSynthPatch patch = null)
    Sequencer Sequencer { get; }
    MoogSynth Synth { get; }
    void GenerateAudio(Span<float> buffer, int samplesPerChannel, int channelCount, int sampleRate)
    void NextPattern()
    void SetPatch(MoogSynthPatch patch)
    void SetSequencerMode(SequencerMode mode)

namespace Ikon.Resonance.Synth.Oscillators
  interface IOscillator
    double Phase { get; }
    abstract double Process(double frequency, double sampleRate)
    abstract void Reset()
    abstract void Sync()
  enum OscillatorType
    Saw
    Square
    Triangle
    Pulse
    Sine
  static class PolyBlep
    static double Compute(double t, double dt)
  sealed class PulseOscillator : IOscillator
    ctor()
    double Phase { get; }
    double PulseWidth { get;  set; }
    double Process(double frequency, double sampleRate, double pulseWidth)
    double Process(double frequency, double sampleRate)
    void Reset()
    void Sync()
  sealed class SawOscillator : IOscillator
    ctor()
    double Phase { get; }
    double Process(double frequency, double sampleRate)
    void Reset()
    void Sync()
  sealed class SquareOscillator : IOscillator
    ctor()
    double Phase { get; }
    double PulseWidth { get;  set; }
    double Process(double frequency, double sampleRate)
    void Reset()
    void Sync()
  sealed class SubOscillator : IOscillator
    ctor()
    int OctaveDown { get;  set; }
    double Phase { get; }
    double Process(double frequency, double sampleRate)
    void Reset()
    void Sync()
  sealed class TriangleOscillator : IOscillator
    ctor()
    double Phase { get; }
    double Process(double frequency, double sampleRate)
    void Reset()
    void Sync()

namespace Ikon.Resonance.Synth.Sequencer
  sealed class GenerativeSettings
    ctor()
    double Bpm { get;  set; }
    double ChordProbability { get;  set; }
    double MaxVelocity { get;  set; }
    double MinVelocity { get;  set; }
    double NoteProbability { get;  set; }
    int OctaveRange { get;  set; }
    double RestProbability { get;  set; }
    int RootNote { get;  set; }
    int[] Scale { get;  set; }
  sealed class Sequencer
    ctor(MoogSynth synth)
    double Bpm { get; }
    GenerativeSettings GenerativeSettings { get;  set; }
    SequencerMode Mode { get;  set; }
    SequencerPattern Pattern { get;  set; }
    void NextPattern()
    void Process(int sampleCount)
    void Reset()
    void SetSampleRate(double sampleRate)
  enum SequencerMode
    Pattern
    Generative
  struct SequencerNote
    ctor(int noteNumber, double velocity, double duration)
    double Duration { get; }
    int NoteNumber { get; }
    double Velocity { get; }
  sealed class SequencerPattern
    ctor()
    double Bpm { get;  set; }
    string Name { get;  set; }
    List<SequencerNote?> Steps { get;  set; }
    int StepsPerBeat { get;  set; }
    static SequencerPattern AcidBass()
    static SequencerPattern Arpeggio()
    static SequencerPattern FilterSweep()
    static SequencerPattern Pad()

namespace Ikon.Resonance.Synth.Songs
  sealed class Song
    ctor()
    double Bpm { get;  set; }
    int LoopLengthBeats { get;  set; }
    string Name { get;  set; }
    List<SongTrack> Tracks { get;  set; }
  static class SongLibrary
    static Song[] All()
    static Song BinaryHorizon()
    static Song CyberChase()
    static Song DigitalDreams()
    static Song LostPatrol()
    static Song NeonPatrol()
    static Song Parallax()
    static Song ShadowRunner()
  struct SongNote
    ctor(int noteNumber, double velocity, double duration, double startBeat)
    double Duration { get; }
    int NoteNumber { get; }
    double StartBeat { get; }
    double Velocity { get; }
  sealed class SongPlayer
    ctor()
    double BeatPosition { get; }
    string CurrentSongName { get; }
    bool IsPlaying { get; }
    Song Song { get;  set; }
    void Play()
    void Process(Span<float> buffer, int samplesPerChannel, int channelCount, int sampleRate)
    void Reset()
    void SetSampleRate(double sampleRate)
    void Stop()
  sealed class SongPlayerSource : IAudioSource
    ctor(Song song = null)
    string CurrentSongName { get; }
    SongPlayer Player { get; }
    void GenerateAudio(Span<float> buffer, int samplesPerChannel, int channelCount, int sampleRate)
    void NextSong()
    void Play()
    void Reset()
    void SetSong(Song song)
    void Stop()
  sealed class SongTrack
    ctor()
    string Name { get;  set; }
    List<SongNote> Notes { get;  set; }
    MoogSynthPatch Patch { get;  set; }

namespace Ikon.Resonance.Synth.Voice
  sealed class SynthVoice
    ctor()
    AdsrEnvelope AmpEnvelope { get; }
    double DriftAmount { get;  set; }
    double FilterCutoff { get;  set; }
    double FilterEnvAmount { get;  set; }
    AdsrEnvelope FilterEnvelope { get; }
    double FilterKeyTrack { get;  set; }
    double FilterResonance { get;  set; }
    bool IsActive { get; }
    double NoiseLevel { get;  set; }
    int NoteNumber { get; }
    double Osc1Level { get;  set; }
    double Osc2Level { get;  set; }
    double Osc2PulseWidth { get;  set; }
    double SubLevel { get;  set; }
    double Velocity { get; }
    void NoteOff()
    void NoteOn(int noteNumber, double velocity)
    double Process(double lfoFilterMod, double lfoPitchMod, double lfoPwmMod)
    void Reset()
    void SetSampleRate(double sampleRate)
  sealed class VoiceAllocator
    ctor(int voiceCount = 8)
    int VoiceCount { get; }
    IReadOnlyList<SynthVoice> Voices { get; }
    void AllNotesOff()
    void NoteOff(int noteNumber)
    SynthVoice NoteOn(int noteNumber, double velocity)
    void Reset()
    void SetSampleRate(double sampleRate)


---

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
