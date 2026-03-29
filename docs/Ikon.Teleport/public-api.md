# Ikon.Teleport Public API

namespace Ikon.Teleport
  sealed class TeleportAttribute : Attribute
    ctor(uint version = 1)
    uint Version { get; }
  enum TeleportError
    Underflow
    BadMarker
    BadType
    InvalidLength
    InvalidUtf8
    ArrayMalformed
    DictMalformed
    DepthOverflow
  sealed class TeleportFieldAttribute : Attribute
    ctor(string name)
    ctor(uint explicitId)
    uint? ExplicitId { get; }
    string Name { get; }
  static class TeleportHasher
    static uint ComputeFieldId(string fieldName)
  sealed class TeleportIgnoreAttribute : Attribute
    ctor()
  sealed class TeleportJsonIrDocument
    static TeleportJsonIrDocument Parse(string json)
  static class TeleportJsonMirror
    static string ToJson(ReadOnlySpan<byte> binary, TeleportJsonIrDocument schema)
    static string ToJson(ReadOnlySpan<byte> binary, TeleportJsonMirrorOptions options = null)
  sealed class TeleportJsonMirrorOptions
    ctor()
    bool Indented { get;  set; }
    TeleportJsonIrDocument Schema { get;  set; }
  delegate TeleportSerializer.TeleportReadDelegate<T>
    T TeleportReadDelegate`1<T>(ReadOnlySpan<byte> data)
  sealed class TeleportSerializedBuffer : IDisposable
    ReadOnlyMemory<byte> Memory { get; }
    ReadOnlySpan<byte> Span { get; }
    void Dispose()
    byte[] ToArray()
  static class TeleportSerializer
    static T Deserialize<T>(ReadOnlySpan<byte> data)
    static object Deserialize(Type type, ReadOnlySpan<byte> data)
    static void Register<T>(uint version, TeleportSerializer.TeleportWriteDelegate<T> writer, TeleportSerializer.TeleportReadDelegate<T> reader)
    static byte[] Serialize<T>(T value)
    static byte[] Serialize(object value)
    static TeleportSerializedBuffer SerializeToBuffer<T>(T value)
    static TeleportSerializedBuffer SerializeToBuffer(object value)
  enum TeleportType
    Null
    Bool
    Int32
    Int64
    UInt32
    UInt64
    Float32
    Float64
    Array
    Dict
    Object
    String
    Binary
    Guid
  delegate TeleportSerializer.TeleportWriteDelegate<T>
    void TeleportWriteDelegate`1<T>(TeleportWriter.TeleportObjectScope scope, T value)
  sealed class TeleportWriter : IDisposable
    ctor(int initialCapacity = 256)
    ReadOnlySpan<byte> WrittenSpan { get; }
    TeleportWriter.TeleportObjectScope BeginObject(uint version = 1)
    void Dispose()
    void EnsureCapacity(int minimumCapacity)
    void Reset(int? minimumCapacity = null)
    byte[] ToArray()
  sealed class TeleportWriterPool : IDisposable
    ctor(int initialCapacity = 256)
    void Dispose()
    TeleportWriter Rent(int? minimumCapacity = null)
    void Return(TeleportWriter writer)
