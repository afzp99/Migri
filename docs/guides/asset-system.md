# Asset System

## Asset System

Uniform abstraction for storing and retrieving files, JSON payloads, and binary artifacts across multiple storage backends. All operations go through `Asset.Instance`.

### Asset classes

| Class | URI segment | Use case |
|-------|-------------|----------|
| `LocalFile` | `local-file` | File-system backed, local development. Files stored under the app Data directory. |
| `EmbeddedFile` | `embedded-file` | Read-only assets embedded into an assembly (seed data, scripts). |
| `CloudFile` | `cloud-file` | Private cloud object storage for arbitrary binary payloads. Supports signed URLs and optimistic concurrency. |
| `CloudFilePublic` | `cloud-file-public` | Same as CloudFile but exposes public URLs. |
| `CloudJson` | `cloud-json` | JSON documents via Hub API, suited for low-latency configuration payloads. Supports optimistic concurrency. |

### URI construction

```csharp
// URIs use assets:// scheme with optional scope segments (space, user, channel)
var localFile = new AssetUri(AssetClass.LocalFile, "image.jpg");
var cloudFile = new AssetUri(AssetClass.CloudFile, "path/file.jpg", spaceId: app.GlobalState.SpaceId);
var publicFile = new AssetUri(AssetClass.CloudFilePublic, "path/file.jpg", spaceId: app.GlobalState.SpaceId);
var cloudJson = new AssetUri(AssetClass.CloudJson, "path/data.json", spaceId: app.GlobalState.SpaceId);
```

### Read/Write

```csharp
// Bytes
var bytes = await Asset.Instance.GetBytesAsync(uri);
await Asset.Instance.SetBytesAsync(uri, bytes, new AssetMetadata(mimeType: MimeTypes.ImageJpeg));

// Text
var text = await Asset.Instance.GetTextAsync(uri);
await Asset.Instance.SetTextAsync(uri, jsonString);

// Typed objects (JSON serialization)
var layout = await Asset.Instance.GetAsync<DashboardLayout>(uri);
await Asset.Instance.SetAsync(uri, new DashboardLayout { Columns = 3 });

// Streams
await using var readStream = (await Asset.Instance.GetReadStreamAsync(uri)).Content;
await using var writeStream = await Asset.Instance.GetWriteStreamAsync(uri, new AssetMetadata(mimeType: "image/png"));
```

### Metadata & existence

```csharp
bool exists = await Asset.Instance.ExistsAsync(uri);
var metadata = await Asset.Instance.GetMetadataAsync(uri);  // .Size, .LastModified, .Url, .UrlIsTemporal, .MimeType
```

### Optimistic concurrency

Read with metadata, carry `LastModified` forward into writes to prevent blind overwrites:

```csharp
var content = await Asset.Instance.GetTextWithMetadataAsync(uri);
// ... modify content.Content ...
var result = await Asset.Instance.TrySetTextAsync(uri, modified, new AssetMetadata(lastModified: content.Metadata.LastModified));
if (result.IsConflict) { /* re-read and retry */ }
```

### Change subscriptions

```csharp
await Asset.Instance.GetOrUpdateWithMetadataAsync(uri,
    async (args, content) =>
    {
        if (content is null) { cache.Remove(uri); return; }
        cache[uri] = content.Content;
    },
    async _ => await Asset.Instance.SetAsync(uri, Settings.Default));
```

### Listing & deletion

```csharp
var entries = await Asset.Instance.ListAsync(new AssetQuery(folderUri) { Limit = 50 });
await Asset.Instance.DeleteAsync(uri);
```

---

# Ikon.Common.Core Public API
namespace Ikon.Common.Core.Assets
  sealed class Asset : AsyncLocalInstance<Asset>, IAsyncDisposable
    ctor()
    IkonBackend Backend { get;  set; }
    Task AddStorageAsync(AssetClass assetClass, IStorage storage, bool startInBackground = false)
    Task DeleteAsync(AssetUri assetUri)
    ValueTask DisposeAsync()
    Task<bool> ExistsAsync(AssetUri assetUri)
    Task<T> GetAsync<T>(AssetUri assetUri)
    Task<byte[]> GetBytesAsync(AssetUri assetUri)
    Task<AssetContent<byte[]>> GetBytesWithMetadataAsync(AssetUri assetUri)
    Task<AssetMetadata> GetMetadataAsync(AssetUri assetUri)
    Task<IAsyncDisposable> GetOrUpdateWithMetadataAsync<T>(AssetUri assetUri, Func<AssetEventArgs, AssetContent<T>, Task> onAsset, Func<AssetEventArgs, Task> onAssetNotFound = null)
    Task<IAsyncDisposable> GetOrUpdateWithMetadataAsync<T>(AssetUri assetUri, Action<AssetEventArgs, AssetContent<T>> onAsset, Func<AssetEventArgs, Task> onAssetNotFound = null)
    Task<AssetContent<Stream>> GetReadStreamAsync(AssetUri assetUri)
    Task<string> GetTextAsync(AssetUri assetUri, Encoding encoding = null)
    Task<AssetContent<string>> GetTextWithMetadataAsync(AssetUri assetUri, Encoding encoding = null)
    Task<AssetContent<T>> GetWithMetadataAsync<T>(AssetUri assetUri)
    Task<Stream> GetWriteStreamAsync(AssetUri assetUri, AssetMetadata? metadata = null, CancellationToken cancellationToken = null)
    Task<IReadOnlyList<AssetListingEntry>> ListAsync(AssetQuery query, CancellationToken cancellationToken = null)
    Task<IReadOnlyList<AssetUri>> ListAsync(AssetClass assetClass, string prefix = null, CancellationToken cancellationToken = null)
    Task<IReadOnlyList<AssetUri>> ListAsync(AssetUri folderUri, CancellationToken cancellationToken = null)
    Task NotifyUpdateAsync(AssetUri assetUri)
    Task SetAsync<T>(AssetUri assetUri, T asset, AssetMetadata? metadata = null, CancellationToken cancellationToken = null)
    Task SetBytesAsync(AssetUri assetUri, byte[] bytes, AssetMetadata? metadata = null, CancellationToken cancellationToken = null)
    Task SetTextAsync(AssetUri assetUri, string text, AssetMetadata? metadata = null, CancellationToken cancellationToken = null)
    Task<T> TryGetAsync<T>(AssetUri assetUri)
    Task<byte[]> TryGetBytesAsync(AssetUri assetUri)
    Task<AssetContent<byte[]>> TryGetBytesWithMetadataAsync(AssetUri assetUri)
    Task<AssetMetadata?> TryGetMetadataAsync(AssetUri assetUri)
    Task<string> TryGetTextAsync(AssetUri assetUri, Encoding encoding = null)
    Task<AssetContent<string>> TryGetTextWithMetadataAsync(AssetUri assetUri, Encoding encoding = null)
    Task<AssetContent<T>> TryGetWithMetadataAsync<T>(AssetUri assetUri)
    Task<AssetWriteResult> TrySetBytesAsync(AssetUri assetUri, byte[] bytes, AssetMetadata? metadata = null, CancellationToken cancellationToken = null)
    Task<AssetWriteResult> TrySetTextAsync(AssetUri assetUri, string text, AssetMetadata? metadata = null, CancellationToken cancellationToken = null)
  enum AssetClass
    LocalFile
    EmbeddedFile
    CloudFile
    CloudFilePublic
    CloudJson
    CloudProfile
  sealed class AssetContent<T> : IDisposable
    ctor(T content, AssetMetadata? metaData = null)
    T Content { get; }
    AssetMetadata? MetaData { get; }
    void Dispose()
  class AssetEventArgs : EventArgs
    ctor(AssetUri assetUri, AssetStatus status)
    AssetUri AssetUri { get; }
    AssetStatus Status { get; }
  struct AssetListingEntry
    ctor(AssetUri assetUri, AssetMetadata metadata)
    AssetUri AssetUri { get; }
    AssetMetadata Metadata { get; }
  struct AssetMetadata
    ctor(string mimeType = null, long? size = null, DateTime? lastModified = null, string url = null, bool? urlIsTemporal = null, string[] tags = null, string internalPath = null, string storageId = null)
    string InternalPath { get; }
    DateTime? LastModified { get; }
    string MimeType { get; }
    long? Size { get; }
    string StorageId { get; }
    string[] Tags { get; }
    string Url { get; }
    bool? UrlIsTemporal { get; }
  sealed class AssetQuery
    ctor(AssetClass assetClass)
    ctor(AssetUri folderUri)
    string ChannelId { get;  set; }
    AssetClass Class { get; }
    string ContinuationToken { get;  set; }
    string EffectiveChannelId { get; }
    string EffectiveFolderPrefix { get; }
    string EffectiveSpaceId { get; }
    string EffectiveUserId { get; }
    string FolderPrefix { get;  set; }
    AssetUri? FolderUri { get;  set; }
    int? Limit { get;  set; }
    string NextContinuationToken { get;  set; }
    string SpaceId { get;  set; }
    string[] Tags { get;  set; }
    string UserId { get;  set; }
    AssetQuery Clone()
  enum AssetStatus
    None
    Added
    Exists
    Changed
    Deleted
  struct AssetUri : IEquatable<AssetUri>
    ctor(string uriString)
    ctor(AssetClass assetClass, string path = null, string spaceId = null, string userId = null, string channelId = null, string query = null)
    string ChannelId { get; }
    AssetClass Class { get; }
    string FileName { get; }
    string Path { get; }
    string Query { get; }
    static string Scheme { get; }
    string SpaceId { get; }
    string UserId { get; }
    static AssetUri FromFilesystemPath(string relativePathToRoot, AssetClass defaultAssetClass = LocalFile)
    static bool IsValid(string uriString)
    static string ToFilesystemPath(AssetUri assetUri)
    static bool TryParse(string uriString, out AssetUri assetUri, out string failureReason)
    static bool TryParse(string uriString, out AssetUri assetUri)
    AssetUri With(AssetClass? assetClass = null, string path = null, string spaceId = null, string userId = null, string channelId = null, string query = null)
  struct AssetWriteResult
    ctor(AssetWriteStatus status, AssetMetadata? metadata = null)
    bool IsConflict { get; }
    AssetMetadata? Metadata { get; }
    AssetWriteStatus Status { get; }
    bool Succeeded { get; }
  enum AssetWriteStatus
    NotFound
    Conflict
    Skipped
    Success
  interface IHashableStream
    abstract void SetSha256Hash(string hash)
  interface IStorage : IAsyncDisposable
    abstract Task DeleteAsync(AssetUri assetUri)
    abstract Task<bool> ExistsAsync(AssetUri assetUri)
    abstract Task<AssetContent<Stream>> GetReadStreamAsync(AssetUri assetUri)
    abstract Task<Stream> GetWriteStreamAsync(AssetUri assetUri, AssetMetadata? metadata, CancellationToken cancellationToken)
    abstract Task<IReadOnlyList<AssetListingEntry>> ListAsync(AssetQuery query, CancellationToken cancellationToken)
    abstract Task StartAsync()
    abstract Task<AssetMetadata?> TryGetMetadataAsync(AssetUri assetUri)
    abstract Task WaitUntilQueueEmptyAsync()
    event Func<AssetEventArgs, Task> AssetEventAsync
  static class StorageExtensions
    static Task AddEmbeddedFileStorageAsync(Asset asset, Assembly assembly = null, string resourceNamespace = "")

---

# Asset System Developer Guide

## Overview

The Ikon asset system exposes a uniform abstraction for storing and retrieving files, JSON payloads, and other binary or textual artifacts without binding application code to a specific backend. Each `Asset` instance dispatches every read, write, delete, and listing request to the storage driver that corresponds to the asset class encoded in the `AssetUri`, and propagates change notifications through `AssetEventAsync` so caches can react to updates. The API is asynchronous end-to-end, providing cancellation support where appropriate and surfacing metadata on every transfer to enable optimistic concurrency and lifecycle management.

## Asset URIs

All asset identifiers use the `assets://` scheme defined by `AssetUri`. URIs are composed of optional scope segments followed by the asset class and backend-specific path:

```
assets://space/{spaceId}/user/{userId}/channel/{channelId}/{asset-class}/{path/to/resource}?{query}
```

Key rules:

- `space`, `user`, and `channel` segments are optional and may appear in that order. They scope the asset inside the storage backend.
- The asset class segment must match one of the values defined in `AssetClass` (for example `cloud-file`, `cloud-json`, or `embedded-file`).
- The remaining path is interpreted by the storage driver and can include nested folders.
- `AssetUri` instances normalize the file name, expose `With` helpers for cloning with modified components, and provide converters for filesystem paths when assets need to be mirrored locally.

## Storage classes

`AssetClass` maps human-readable URI segments to the available backend implementations. Use the class that best matches the data profile:

| Asset class | URI segment | Characteristics |
|-------------|-------------|-----------------|
| `LocalFile` | `local-file` | File-system backed, primarily for local development and tooling. Paths are rooted under a system-managed directory. |
| `EmbeddedFile` | `embedded-file` | Read-only assets embedded into an assembly. Ideal for shipping seed data and scripts. |
| `CloudFile` | `cloud-file` | Private cloud object storage optimized for arbitrary binary payloads. Supports signed URLs, metadata, and optimistic concurrency tokens. |
| `CloudFilePublic` | `cloud-file-public` | Same backing service as `CloudFile` but exposes public URLs for assets meant to be shared openly. |
| `CloudJson` | `cloud-json` | JSON documents persisted through the Hub API, suited for low-latency configuration payloads. Supports optimistic concurrency via the `LastModified` timestamp. |
| `CloudProfile` | `cloud-profile` | Legacy profile projection support. Marked obsolete and scheduled for removal once dependent workloads migrate. |

Each storage reports metadata such as MIME type, byte size, update timestamp, tags, download URL (when applicable), and the backend-specific identifier through `AssetMetadata` so callers can perform fine-grained reconciliation.

## Asset metadata helpers

Most read and write operations accept or return an `AssetMetadata` instance. Populate `MimeType`, `Tags`, or `LastModified` when writing so that storage drivers can set headers or enforce optimistic concurrency. `Get*WithMetadataAsync` helpers pair the payload with the metadata in an `AssetContent<T>`, disposing underlying streams automatically when needed.

## Storing data

### `GetWriteStreamAsync`

`GetWriteStreamAsync` returns a writable stream bound to the storage driver identified by the URI. The write is committed when the stream is disposed, allowing each storage to finalize uploads (for example by issuing signed PUT requests).

```csharp
var assets = Asset.Instance;
var photoUri = new AssetUri(
    assetClass: AssetClass.CloudFile,
    path: "images/hero.png",
    spaceId: "space-42");

await using var writeStream = await assets.GetWriteStreamAsync(
    photoUri,
    metadata: new AssetMetadata(mimeType: "image/png"));
await using var fileStream = File.OpenRead("./hero.png");
await fileStream.CopyToAsync(writeStream);
```

### `SetTextAsync` / `TrySetTextAsync`

Use `SetTextAsync` to persist UTF-8 encoded text to any storage class that accepts textual payloads (for example `CloudJson`). Provide `AssetMetadata.LastModified` when you need optimistic concurrency: the driver validates the value against the current revision and throws `AssetUpdateConflictException` (or returns `AssetWriteStatus.Conflict` from `TrySetTextAsync`).

```csharp
var settingsUri = new AssetUri(AssetClass.CloudJson, "config/app.json", spaceId: "space-42");
var payload = JsonSerializer.Serialize(settingsObject);
await assets.SetTextAsync(
    settingsUri,
    payload,
    new AssetMetadata(lastModified: cachedMetadata?.LastModified));
```

`TrySetTextAsync` mirrors the behavior but returns an `AssetWriteResult` so you can branch without exceptions:

```csharp
var write = await assets.TrySetTextAsync(settingsUri, payload);
if (write.IsConflict)
{
    // Inspect write.Metadata to decide whether to re-read and retry.
}
```

### `SetBytesAsync` / `TrySetBytesAsync`

`SetBytesAsync` uploads byte arrays that are already materialized in memory. `TrySetBytesAsync` exposes the same optimistic concurrency semantics as the text helper.

```csharp
var thumbnailUri = new AssetUri(AssetClass.CloudFile, "thumbnails/card.jpg", spaceId: "space-42");
await assets.SetBytesAsync(thumbnailUri, thumbnailBytes, new AssetMetadata(mimeType: "image/jpeg"));
```

### `SetAsync<T>`

`SetAsync<T>` serializes arbitrary reference types to JSON (unless the value is already `string` or `byte[]`) and writes the result using `SetTextAsync`. This is a convenient way to persist strongly typed settings without manual serialization.

```csharp
await assets.SetAsync(
    new AssetUri(AssetClass.CloudJson, "layouts/dashboard.json", spaceId: "space-42"),
    new DashboardLayout { Columns = 3, Widgets = widgets });
```

## Loading data

### Existence and metadata

- `ExistsAsync` checks whether an asset is present.
- `GetMetadataAsync` returns metadata or throws if the asset is missing.
- `TryGetMetadataAsync` returns `null` when metadata is unavailable.

```csharp
if (!await assets.ExistsAsync(settingsUri))
{
    throw new InvalidOperationException("Missing configuration asset.");
}

var metadata = await assets.GetMetadataAsync(settingsUri);
Console.WriteLine($"Last updated {metadata.LastModified:O}");
```

### Streams and primitives

- `GetReadStreamAsync` returns `AssetContent<Stream>` so callers can stream large files while inspecting metadata.
- `GetTextWithMetadataAsync` / `GetTextAsync` read UTF-8 text by default and support explicit encodings. `TryGet*` variants avoid throwing.
- `GetBytesWithMetadataAsync` / `GetBytesAsync` materialize the asset into memory as a byte array.

```csharp
var download = await assets.GetReadStreamAsync(photoUri);
await using (download)
{
    await using var destination = File.Create("./downloaded.png");
    await download.Content.CopyToAsync(destination);
}

var script = await assets.GetTextAsync(new AssetUri(AssetClass.EmbeddedFile, "Scripts/init.sql"));
```

### Structured objects

`GetWithMetadataAsync<T>` deserializes JSON payloads into the requested type (with fast paths for `string` and `byte[]`) and surfaces metadata. `GetAsync<T>` and `TryGetAsync<T>` return just the content.

```csharp
var layout = await assets.GetAsync<DashboardLayout>(
    new AssetUri(AssetClass.CloudJson, "layouts/dashboard.json", spaceId: "space-42"));
```

### Change subscriptions

`GetOrUpdateWithMetadataAsync` wires a callback to an asset. The callback is invoked immediately with the current content and again whenever the underlying storage reports an add, change, or delete event. Provide `onAssetNotFound` to seed defaults before subscribing.

```csharp
await assets.GetOrUpdateWithMetadataAsync(
    settingsUri,
    async (args, content) =>
    {
        if (content is null)
        {
            cache.Remove(settingsUri);
            return;
        }

        cache[settingsUri] = content.Content;
    },
    async _ => await assets.SetAsync(settingsUri, Settings.Default));
```

## Listing assets

Use `ListAsync` with an `AssetQuery` to enumerate folders, filter by tags, and paginate through large collections. Listing is currently supported by the `LocalFile` and `EmbeddedFile` backends only. Cloud backends (`CloudFile`, `CloudFilePublic`, `CloudJson`) do not yet support listing and will throw `NotSupportedException`.

```csharp
var folderUri = new AssetUri(AssetClass.LocalFile, "albums/2024/");
var query = new AssetQuery(folderUri)
{
    Tags = new[] { "cover" },
    Limit = 50,
};

var entries = await assets.ListAsync(query);
foreach (var entry in entries)
{
    Console.WriteLine($"{entry.AssetUri.Path} updated {entry.Metadata.LastModified:O}");
}

var nextPageToken = query.NextContinuationToken;
```

Convenience overloads accept an `AssetClass` and optional prefix or a folder URI directly when only the URIs are required.

## Optimistic concurrency workflow

When an asset must not be overwritten blindly, follow this pattern:

1. Read the asset with metadata (`GetTextWithMetadataAsync`, `GetBytesWithMetadataAsync`, or `GetWithMetadataAsync<T>`).
2. Carry `metadata.LastModified` forward into `SetTextAsync` or `SetBytesAsync` via `AssetMetadata`.
3. Handle `AssetUpdateConflictException` (or check `AssetWriteResult.IsConflict`) to trigger a re-read and retry.

This approach is supported consistently across `CloudFile` and `CloudJson` backends and aligns with the Hub service’s `ifUpdatedAt` semantics.
