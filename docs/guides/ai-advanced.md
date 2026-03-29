# AI Advanced

## AI Advanced Features

> **For LLM calls, chatbots, and conversation history, always use `Emerge.Run<T>()` from the emergence guide.** This section covers low-level infrastructure that most developers don't need directly.

### AI Database

Database utilities for AI context — vector stores, document retrieval, and semantic search infrastructure.

Refer to generated API docs for full details.

---

# Ikon.AI Public API
namespace Ikon.AI.Database
  sealed class BigQueryDbConnection : DbConnection
    ctor(string projectId, string datasetId)
    string ConnectionString { get;  set; }
    string DataSource { get; }
    string Database { get; }
    string ServerVersion { get; }
    ConnectionState State { get; }
    override void ChangeDatabase(string databaseName)
    override void Close()
    override DataTable GetSchema()
    override DataTable GetSchema(string collectionName)
    override DataTable GetSchema(string collectionName, string[] restrictionValues)
    override void Open()
  class DatabaseConnection.Config
    ctor()
    string EnvVarPrefix { get;  set; }
    DatabaseConnection.SpaceSecret SpaceSecret { get;  set; }
  class DatabaseInfoExtractor.Config
    ctor()
    List<string> ColumnExcludeRegex { get;  set; }
    Dictionary<string, string> ColumnExtraInfo { get;  set; }
    bool IncludeEmptyColumns { get;  set; }
    int JsonSampleLengthLimit { get;  set; }
    int JsonSampleRowLimit { get;  set; }
    int NonTextSampleRowLimit { get;  set; }
    List<string> Schemas { get;  set; }
    List<string> TableExcludeRegex { get;  set; }
    Dictionary<string, string> TableExtraInfo { get;  set; }
    List<string> TableIncludeRegex { get;  set; }
    int TextSampleLengthLimit { get;  set; }
    int TextSampleRowLimit { get;  set; }
  class DatabaseColumnInfo
    ctor()
    string ColumnName { get;  set; }
    string DataType { get;  set; }
    string Description { get;  set; }
    string ExtraInfo { get;  set; }
    string ForeignKeyColumnName { get;  set; }
    string ForeignKeyTableName { get;  set; }
    bool? IsForeignKey { get;  set; }
    bool? IsPrimaryKey { get;  set; }
    List<string> Values { get;  set; }
  class DatabaseConnection
    ctor()
    string BigQueryDataset { get;  set; }
    string BigQueryProjectId { get;  set; }
    DatabaseType DatabaseType { get;  set; }
    DbConnection DbConnection { get;  set; }
    static Task<DatabaseConnection> CreateAsync(DatabaseConnection.Config config)
  class DatabaseInfo
    ctor()
    DatabaseType DatabaseType { get;  set; }
    List<string> ExampleQuestions { get;  set; }
    string SqlCteCommand { get;  set; }
    List<DatabaseTableInfo> Tables { get;  set; }
  class DatabaseInfoExtractor
    ctor(DatabaseConnection databaseConnection)
    Task<DatabaseInfo> ExtractAsync(DatabaseInfoExtractor.Config config, CancellationToken cancellationToken)
    Task<ResultSet> GetCteDatabaseInfoAllValuesAsync(DatabaseInfo cteDatabaseInfo, int maxRows)
    static bool IsText(string dataType)
    Task<DatabaseInfo> ValidateAndFillCteDatabaseInfoAsync(DatabaseInfo cteDatabaseInfo, int maxRowsFilter)
  class DatabaseTableInfo
    ctor()
    List<DatabaseColumnInfo> Columns { get;  set; }
    string Description { get;  set; }
    string ExtraInfo { get;  set; }
    string TableName { get;  set; }
  enum DatabaseType
    Unknown
    PostgreSql
    Sqlite
    BigQuery
    Trino
  class DatabaseConnection.SpaceSecret
    ctor()
    string Prefix { get;  set; }
    string SpaceId { get;  set; }
  static class SqlValidator
    static void ValidateReadOnly(string sql, HashSet<string> allowedTables)

namespace Ikon.AI.Policy
  sealed class CreditLimitChecker : IUsageLimitChecker
    ctor()
    ValueTask<UsageLimitCheckResult> CheckAsync(PolicyCallContext context, object[] args)

namespace Ikon.AI.Storage
  class KeywordIndex
    ctor()
    Task Add(string word, string link)
    static KeywordIndex Deserialize(Stream stream)
    Task InitializeAsync()
    void RemoveTooCommonTerms(double threshold = 0.5, int minDocumentCount = 5)
    List<KeywordSearchResult> Search(string words)
    void Serialize(Stream stream)
  struct KeywordSearchResult
    ctor(string link, float score)
    string Link
    float Score
  enum Metric
    DotProduct
    CosineSimilarity
    EuclideanDistance
  struct Result<T>
    ctor(int key, float score, T value)
    int Key
    float Score
    T Value
  class VectorDatabase
    ctor()
    Task CreateCollectionAsync(string collectionName, EmbeddingModel model)
    Task<int> GetDataItemCount(string collectionName)
    Task RemoveAsync(string collectionName, IEnumerable<string> tags)
    Task<List<Result<object>>> SearchAsync(string collectionName, float[] queryVector, int maxItems, float threshold, Metric metric, Func<IEnumerable<string>, bool> tagsFilter = null)
    Task<List<Result<object>>> SearchAsync(string collectionName, string query, int maxItems, float threshold, Metric metric, Func<IEnumerable<string>, bool> tagsFilter = null)
    Task<List<Result<T>>> SearchAsync<T>(string collectionName, string query, int maxItems, float threshold, Metric metric, Func<IEnumerable<string>, bool> tagsFilter = null)
    Task<List<Result<T>>> SearchAsync<T>(string collectionName, float[] queryVector, int maxItems, float threshold, Metric metric, Func<IEnumerable<string>, bool> tagsFilter = null)
    Task<int> SetAsync(string collectionName, int? key, string text, object value, IEnumerable<string> tags = null)
    Task<int> SetAsync(string collectionName, int? key, float[] vector, object value, IEnumerable<string> tags = null)
