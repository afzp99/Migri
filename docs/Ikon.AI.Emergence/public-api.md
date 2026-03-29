# Ikon.AI.Emergence Public API

namespace Ikon.AI.Emergence
  sealed class AgentScope<T> : EmergeScope<T>
    ctor()
    int Index { get; }
    string Role { get;  set; }
    int? Seed { get;  set; }
  sealed class BestOfOptions<T> : EmergeScope<T>
    ctor()
    Func<T, ScoreBreakdown, string> BuildCriticFeedback { get;  set; }
    Action<CandidateScope<T>> CandidateConfig { get;  set; }
    int Count { get;  set; }
    bool CriticMustImprove { get;  set; }
    EmergeScope<T> CriticScope { get; }
    bool EnableCritic { get;  set; }
    Func<T, EmergenceTrace, double> Score { get;  set; }
    void Candidate(Action<CandidateScope<T>> configure)
    void Critic(Action<EmergeScope<T>> configure)
  sealed class CandidateScope<T> : EmergeScope<T>
    ctor()
    int Index { get; }
    int? Seed { get;  set; }
  sealed class Completed<T> : EmergeEvent<T>, IEquatable<Completed<T>>
    ctor(T Result, KernelContext Context, EmergenceTrace Trace)
    KernelContext Context { get;  init; }
    T Result { get;  init; }
    EmergenceTrace Trace { get;  init; }
  sealed class DebateThenJudgeOptions<T> : EmergeScope<T>
    ctor()
    int DebateRounds { get;  set; }
    Action<AgentScope<T>> DebaterConfig { get;  set; }
    int Debaters { get;  set; }
    EmergeScope<T> JudgeScope { get; }
    void Debater(Action<AgentScope<T>> configure)
    void Judge(Action<EmergeScope<T>> configure)
  static class Emerge
    static IAsyncEnumerable<EmergeEvent<T>> BestOf<T>(LLMModel model, KernelContext context, Action<BestOfOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> BestOf<T>(LLMModel model, KernelContext context, Action<BestOfOptions<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> DebateThenJudge<T>(LLMModel model, KernelContext context, Action<DebateThenJudgeOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> DebateThenJudge<T>(LLMModel model, KernelContext context, Action<DebateThenJudgeOptions<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> EnsembleMerge<T>(LLMModel model, KernelContext context, Action<EnsembleMergeOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> EnsembleMerge<T>(LLMModel model, KernelContext context, Action<EnsembleMergeOptions<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<TResult>> MapReduce<TChunk, TResult>(LLMModel model, KernelContext context, Action<MapReduceOptions<TChunk, TResult>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<TResult>> MapReduce<TChunk, TResult>(LLMModel model, KernelContext context, Action<MapReduceOptions<TChunk, TResult>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> ParallelBestOf<T>(LLMModel model, KernelContext context, Action<ParallelBestOfOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> ParallelBestOf<T>(LLMModel model, KernelContext context, Action<ParallelBestOfOptions<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> PlanAndExecute<T>(LLMModel model, KernelContext context, Action<PlanAndExecuteOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> PlanAndExecute<T>(LLMModel model, KernelContext context, Action<PlanAndExecuteOptions<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> Refine<T>(LLMModel model, KernelContext context, Action<RefineOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> Refine<T>(LLMModel model, KernelContext context, Action<RefineOptions<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> Router<T>(LLMModel model, KernelContext context, Action<RouterOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> Router<T>(LLMModel model, KernelContext context, Action<RouterOptions<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> Run<T>(LLMModel model, KernelContext context, Action<EmergePass<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> Run<T>(LLMModel model, KernelContext context, Action<EmergePass<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> SelfConsistency<T>(LLMModel model, KernelContext context, Action<SelfConsistencyOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> SelfConsistency<T>(LLMModel model, KernelContext context, Action<SelfConsistencyOptions<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> SolverCriticVerifier<T>(LLMModel model, KernelContext context, Action<SolverCriticVerifierOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> SolverCriticVerifier<T>(LLMModel model, KernelContext context, Action<SolverCriticVerifierOptions<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> Swarm<T>(LLMModel model, KernelContext context, Action<SwarmOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> Swarm<T>(LLMModel model, KernelContext context, Action<SwarmOptions<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> TaskGraph<T>(LLMModel model, KernelContext context, Action<TaskGraphOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> TaskGraph<T>(LLMModel model, KernelContext context, Action<TaskGraphOptions<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> TestRefine<T>(LLMModel model, KernelContext context, Action<TestRefineOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> TestRefine<T>(LLMModel model, KernelContext context, Action<TestRefineOptions<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> TreeOfThought<T>(LLMModel model, KernelContext context, Action<TreeOfThoughtOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> TreeOfThought<T>(LLMModel model, KernelContext context, Action<TreeOfThoughtOptions<T>> configure, ILLM llm, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> TreeSearch<T>(LLMModel model, KernelContext context, Action<TreeSearchOptions<T>> configure, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<T>> TreeSearch<T>(LLMModel model, KernelContext context, Action<TreeSearchOptions<T>> configure, ILLM llm, CancellationToken ct = null)
  sealed class EmergeChat
    ctor()
  sealed class EmergeEventCallbacks<T>
    ctor()
    Action<T, EmergenceTrace> OnCompleted { get;  set; }
    Action<string> OnStopped { get;  set; }
    Action<string> OnText { get;  set; }
    Action<FunctionCall> OnToolCallPlanned { get;  set; }
    Action<FunctionCall, object> OnToolCallResult { get;  set; }
  static class EmergeEventExtensions
    static IAsyncEnumerable<RunnerEvent> AsRunnerEvents<T>(IAsyncEnumerable<EmergeEvent<T>> events, CancellationToken ct = null)
    static Task<string> DispatchEventsAsync<T>(IAsyncEnumerable<EmergeEvent<T>> events, EmergeEventCallbacks<T> callbacks, CancellationToken ct = null)
    static Task<ValueTuple<T, KernelContext>> FinalAsync<T>(IAsyncEnumerable<EmergeEvent<T>> events, CancellationToken ct = null)
    static Task<ValueTuple<T, KernelContext, EmergenceTrace>> FinalWithTraceAsync<T>(IAsyncEnumerable<EmergeEvent<T>> events, CancellationToken ct = null)
  abstract class EmergeEvent<T> : IEquatable<EmergeEvent<T>>
  static class EmergePassExtensions
    static EmergePass<T> AddTool<T>(EmergePass<T> pass, Function function)
    static EmergePass<T> AddTool<T, TResult>(EmergePass<T> pass, string name, string description, Func<TResult> function)
    static EmergePass<T> AddTool<T, T1, TResult>(EmergePass<T> pass, string name, string description, Func<T1, TResult> function)
    static EmergePass<T> AddTool<T, T1, T2, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, TResult> function)
    static EmergePass<T> AddTool<T, T1, T2, T3, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, T3, TResult> function)
    static EmergePass<T> AddTool<T, T1, T2, T3, T4, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, T3, T4, TResult> function)
    static EmergePass<T> AddTool<T, T1, T2, T3, T4, T5, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, T3, T4, T5, TResult> function)
    static EmergePass<T> AddTool<T, T1, T2, T3, T4, T5, T6, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, T3, T4, T5, T6, TResult> function)
    static EmergePass<T> AddTool<T, T1, T2, T3, T4, T5, T6, T7, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, T3, T4, T5, T6, T7, TResult> function)
    static EmergePass<T> AddTool<T, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function)
    static EmergePass<T> AddTool<T, TResult>(EmergePass<T> pass, string name, string description, Func<Task<TResult>> function)
    static EmergePass<T> AddTool<T, T1, TResult>(EmergePass<T> pass, string name, string description, Func<T1, Task<TResult>> function)
    static EmergePass<T> AddTool<T, T1, T2, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, Task<TResult>> function)
    static EmergePass<T> AddTool<T, T1, T2, T3, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, T3, Task<TResult>> function)
    static EmergePass<T> AddTool<T, T1, T2, T3, T4, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, T3, T4, Task<TResult>> function)
    static EmergePass<T> AddTool<T, T1, T2, T3, T4, T5, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, T3, T4, T5, Task<TResult>> function)
    static EmergePass<T> AddTool<T, T1, T2, T3, T4, T5, T6, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, T3, T4, T5, T6, Task<TResult>> function)
    static EmergePass<T> AddTool<T, T1, T2, T3, T4, T5, T6, T7, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, T3, T4, T5, T6, T7, Task<TResult>> function)
    static EmergePass<T> AddTool<T, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(EmergePass<T> pass, string name, string description, Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<TResult>> function)
    static EmergePass<T> AddTools<T>(EmergePass<T> pass, params Function[] functions)
    static EmergePass<T> AddToolsFrom<T>(EmergePass<T> pass, object instance)
    static EmergePass<T> DescribeParams<T>(EmergePass<T> pass, string toolName, Dictionary<string, string> paramDescriptions)
  sealed class EmergePass<T>
    ctor()
    bool CaseInsensitiveJson { get;  set; }
    string Command { get;  set; }
    KernelContext Context { get; }
    bool HasFunctionResults { get; }
    bool HasNewFunctionResults { get; }
    bool? IncludeJsonExample { get;  set; }
    bool IsStopped { get; }
    int Iteration { get; }
    string JsonExample { get; }
    string JsonSchema { get; }
    int? MaxIterations { get;  set; }
    int? MaxOutputTokens { get;  set; }
    int? MaxRetries { get;  set; }
    int? MaxToolCalls { get;  set; }
    TimeSpan? MaxWallTime { get;  set; }
    LLMModel? Model { get;  set; }
    bool? OptimizeContext { get;  set; }
    ReasoningEffort? ReasoningEffort { get;  set; }
    int? ReasoningTokenBudget { get;  set; }
    IReadOnlyList<ModelRegion> Regions { get;  set; }
    TimeSpan? RetryDelay { get;  set; }
    int? SkipLastNMessages { get;  set; }
    string StopReason { get; }
    string SystemPrompt { get;  set; }
    double? Temperature { get;  set; }
    TimeSpan? Timeout { get;  set; }
    IList<Function> Tools { get; }
    bool? UseCitations { get;  set; }
    bool UseJson { get;  set; }
    int? UseLastNMessages { get;  set; }
    void Stop(string reason = null)
    void UseLastMessages(int count, int skipLast = 0)
  class EmergeResult
    ctor(object result = null)
    object Result { get; }
    bool SkipReprocessing { get;  init; }
  sealed class EmergeScope : EmergeScopeBase
    ctor()
  abstract class EmergeScopeBase
    string Command { get;  set; }
    bool? IncludeJsonExample { get;  set; }
    int? MaxIterations { get;  set; }
    int? MaxOutputTokens { get;  set; }
    int? MaxRetries { get;  set; }
    int? MaxToolCalls { get;  set; }
    TimeSpan? MaxWallTime { get;  set; }
    LLMModel? Model { get;  set; }
    bool? OptimizeContext { get;  set; }
    ReasoningEffort? ReasoningEffort { get;  set; }
    int? ReasoningTokenBudget { get;  set; }
    IReadOnlyList<ModelRegion> Regions { get;  set; }
    TimeSpan? RetryDelay { get;  set; }
    int? SkipLastNMessages { get;  set; }
    string SystemPrompt { get;  set; }
    double? Temperature { get;  set; }
    TimeSpan? Timeout { get;  set; }
    IList<Function> Tools { get; }
    bool? UseCitations { get;  set; }
    int? UseLastNMessages { get;  set; }
    void UseLastMessages(int count, int skipLast = 0)
  class EmergeScope<T> : EmergeScopeBase
    ctor()
    bool CaseInsensitiveJson { get;  set; }
    string JsonExample { get; }
    string JsonSchema { get; }
    bool UseJson { get;  set; }
  struct EmergenceBudget : IEquatable<EmergenceBudget>
    ctor()
    ctor(int maxIterations, int maxToolCalls, TimeSpan maxWallTime)
    static EmergenceBudget Default { get; }
    int MaxIterations { get;  init; }
    int MaxToolCalls { get;  init; }
    TimeSpan MaxWallTime { get;  init; }
    static EmergenceBudget Unlimited { get; }
  sealed class EmergenceCallInfo
    ctor()
    string CallId { get;  init; }
    TimeSpan? Duration { get;  set; }
    string Error { get;  set; }
    long InputTokens { get;  set; }
    string Model { get;  init; }
    long OutputTokens { get;  set; }
    string Pattern { get;  init; }
    string ResultType { get;  init; }
    DateTime StartedAt { get;  init; }
    string StopReason { get;  set; }
    bool? Success { get;  set; }
    Dictionary<string, string> Tags { get;  init; }
  static class EmergenceMonitor
    static bool HasObservers { get; }
    static void AddObserver(IEmergenceObserver observer)
    static void ClearObservers()
    static void RemoveObserver(IEmergenceObserver observer)
    static void SetSoleObserver(IEmergenceObserver observer)
    static IDisposable WithTags(Dictionary<string, string> tags)
  class EmergenceMonitorState : IEmergenceObserver
    ctor()
    IReadOnlyList<EmergenceCallInfo> Calls { get; }
    void Clear()
    void OnCallCompleted(EmergenceCallInfo call)
    void OnCallStarted(EmergenceCallInfo call)
    void OnEvent(EmergenceCallInfo call, EmergenceObserverEvent evt)
    event Action Changed
  abstract class EmergenceObserverEvent : IEquatable<EmergenceObserverEvent>
  enum EmergenceStatus
    Completed
    Stopped
    Failed
  sealed class EmergenceTrace : IEquatable<EmergenceTrace>
    ctor()
    ctor(int iterations, int toolCalls, TimeSpan duration, IReadOnlyList<FunctionCall> toolCallHistory = null, string finishReason = null, Exception error = null, long inputTokens = 0, long outputTokens = 0)
    TimeSpan Duration { get;  init; }
    Exception Error { get;  init; }
    string FinishReason { get;  init; }
    long InputTokens { get;  init; }
    bool IsTruncated { get; }
    int Iterations { get;  init; }
    long OutputTokens { get;  init; }
    IReadOnlyList<FunctionCall> ToolCallHistory { get;  init; }
    int ToolCalls { get;  init; }
  sealed class EnsembleMergeOptions<T> : EmergeScope<T>
    ctor()
    int MaxParallel { get;  set; }
    EmergeScope<T> MergerScope { get; }
    Action<AgentScope<T>> SolverConfig { get;  set; }
    int SolverCount { get;  set; }
    void Merger(Action<EmergeScope<T>> configure)
    void Solver(Action<AgentScope<T>> configure)
  sealed class ExecutionPlan
    ctor()
    List<PlanStep> Steps { get;  set; }
    string Summary { get;  set; }
  class FoundSection
    ctor()
    string Content { get;  set; }
    string NodeId { get;  set; }
    int? Page { get;  set; }
    string Path { get;  set; }
    string Relevance { get;  set; }
  interface IEmergenceObserver
    abstract void OnCallCompleted(EmergenceCallInfo call)
    abstract void OnCallStarted(EmergenceCallInfo call)
    abstract void OnEvent(EmergenceCallInfo call, EmergenceObserverEvent evt)
  static class KernelContextExtensions
    static IReadOnlyList<FunctionCall> GetFunctionCalls(KernelContext ctx, int take = 10)
    static IReadOnlyList<FunctionResultPart> GetFunctionResults(KernelContext ctx, int take = 10)
    static bool HasFunctionResults(KernelContext ctx)
  sealed class MapReduceOptions<TChunk, TResult> : EmergeScope<TResult>
    ctor()
    IReadOnlyList<object> Chunks { get;  set; }
    object Input { get;  set; }
    EmergeScope<TChunk> MapScope { get; }
    int MaxParallel { get;  set; }
    EmergeScope<TResult> ReduceScope { get; }
    Func<object, IEnumerable<object>> Split { get;  set; }
    void Map(Action<EmergeScope<TChunk>> configure)
    void Reduce(Action<EmergeScope<TResult>> configure)
  sealed class ModelText<T> : EmergeEvent<T>, IEquatable<ModelText<T>>
    ctor(string Text)
    string Text { get;  init; }
  class NavigationDecision
    ctor()
    bool Complete { get;  set; }
    string Reasoning { get;  set; }
  sealed class ObserverCompletedEvent : EmergenceObserverEvent, IEquatable<ObserverCompletedEvent>
    ctor(EmergenceTrace Trace)
    EmergenceTrace Trace { get;  init; }
  sealed class ObserverProgressEvent : EmergenceObserverEvent, IEquatable<ObserverProgressEvent>
    ctor(string Message)
    string Message { get;  init; }
  sealed class ObserverRetryEvent : EmergenceObserverEvent, IEquatable<ObserverRetryEvent>
    ctor(string Reason, int Attempt, int MaxAttempts)
    int Attempt { get;  init; }
    int MaxAttempts { get;  init; }
    string Reason { get;  init; }
  sealed class ObserverStageEvent : EmergenceObserverEvent, IEquatable<ObserverStageEvent>
    ctor(string Name)
    string Name { get;  init; }
  sealed class ObserverStoppedEvent : EmergenceObserverEvent, IEquatable<ObserverStoppedEvent>
    ctor(string Reason)
    string Reason { get;  init; }
  sealed class ObserverTextEvent : EmergenceObserverEvent, IEquatable<ObserverTextEvent>
    ctor(string Text)
    string Text { get;  init; }
  sealed class ObserverTokenEvent : EmergenceObserverEvent, IEquatable<ObserverTokenEvent>
    ctor(long InputTokens, long OutputTokens)
    long InputTokens { get;  init; }
    long OutputTokens { get;  init; }
  sealed class ObserverToolCallPlannedEvent : EmergenceObserverEvent, IEquatable<ObserverToolCallPlannedEvent>
    ctor(string FunctionName, string ParametersJson)
    string FunctionName { get;  init; }
    string ParametersJson { get;  init; }
  sealed class ObserverToolCallResultEvent : EmergenceObserverEvent, IEquatable<ObserverToolCallResultEvent>
    ctor(string FunctionName, string ResultSummary)
    string FunctionName { get;  init; }
    string ResultSummary { get;  init; }
  sealed class ParallelBestOfOptions<T> : EmergeScope<T>
    ctor()
    Func<T, ScoreBreakdown, string> BuildCriticFeedback { get;  set; }
    Action<CandidateScope<T>> CandidateConfig { get;  set; }
    int Count { get;  set; }
    bool CriticMustImprove { get;  set; }
    EmergeScope<T> CriticScope { get; }
    bool EnableCritic { get;  set; }
    int MaxParallel { get;  set; }
    Func<T, EmergenceTrace, double> Score { get;  set; }
    void Candidate(Action<CandidateScope<T>> configure)
    void Critic(Action<EmergeScope<T>> configure)
  sealed class PlanAndExecuteOptions<T> : EmergeScope<T>
    ctor()
    EmergeScope<T> ExecutorScope { get; }
    int MaxSteps { get;  set; }
    EmergeScope<ExecutionPlan> PlannerScope { get; }
    void Executor(Action<EmergeScope<T>> configure)
    void Planner(Action<EmergeScope<ExecutionPlan>> configure)
  sealed class PlanRevision
    ctor()
    List<TaskNode> NewTasks { get;  set; }
    string Reasoning { get;  set; }
    Dictionary<string, string> TaskUpdates { get;  set; }
    List<string> TasksToCancel { get;  set; }
  sealed class PlanStep
    ctor()
    string Description { get;  set; }
    bool RequiresTool { get;  set; }
    string ToolName { get;  set; }
  sealed class Progress<T> : EmergeEvent<T>, IEquatable<Progress<T>>
    ctor(string Message)
    string Message { get;  init; }
  sealed class RefineOptions<T> : EmergeScope<T>
    ctor()
    EmergeScope<T> InitialScope { get; }
    int MaxRefinements { get;  set; }
    EmergeScope<T> RefinementScope { get; }
    Func<T, EmergenceTrace, Task<bool>> ShouldContinue { get;  set; }
    void Initial(Action<EmergeScope<T>> configure)
    void Refinement(Action<EmergeScope<T>> configure)
  sealed class Retry<T> : EmergeEvent<T>, IEquatable<Retry<T>>
    ctor(string Reason, int AttemptNumber, int MaxAttempts)
    int AttemptNumber { get;  init; }
    int MaxAttempts { get;  init; }
    string Reason { get;  init; }
  sealed class ReviewFeedback
    ctor()
    double FitnessScore { get;  set; }
    List<string> Insights { get;  set; }
    List<string> Issues { get;  set; }
    string Reasoning { get;  set; }
    bool SuggestPlanRevision { get;  set; }
  sealed class Route
    ctor()
    Action<EmergeScopeBase> Configure { get;  set; }
    string Description { get;  set; }
    LLMModel? Model { get;  set; }
    string Name { get;  set; }
  sealed class RouterDecision
    ctor()
    string Reasoning { get;  set; }
    string SelectedRoute { get;  set; }
  sealed class RouterOptions<T> : EmergeScope<T>
    ctor()
    EmergeScope<RouterDecision> RouterScope { get; }
    List<Route> Routes { get; }
    void AddRoute(string name, string description, LLMModel? model = null, Action<EmergeScopeBase> configure = null)
    void Router(Action<EmergeScope<RouterDecision>> configure)
  sealed class RunnerCompletedEvent : RunnerEvent, IEquatable<RunnerCompletedEvent>
    ctor(string FinalText)
    string FinalText { get;  init; }
  sealed class RunnerErrorEvent : RunnerEvent, IEquatable<RunnerErrorEvent>
    ctor(string Error)
    string Error { get;  init; }
  abstract class RunnerEvent : IEquatable<RunnerEvent>
  sealed class RunnerTextEvent : RunnerEvent, IEquatable<RunnerTextEvent>
    ctor(string Text)
    string Text { get;  init; }
  sealed class RunnerToolPlannedEvent : RunnerEvent, IEquatable<RunnerToolPlannedEvent>
    ctor(string ToolName, string ParametersJson)
    string ParametersJson { get;  init; }
    string ToolName { get;  init; }
  sealed class RunnerToolResultEvent : RunnerEvent, IEquatable<RunnerToolResultEvent>
    ctor(string ToolName, string Result, bool IsError)
    bool IsError { get;  init; }
    string Result { get;  init; }
    string ToolName { get;  init; }
  sealed class ScoreBreakdown
    ctor()
    IReadOnlyList<ScoreMetric> Metrics { get;  init; }
    double TotalScore { get;  init; }
    ScoreMetric Weakest { get;  init; }
    string FormatBreakdown()
  sealed class ScoreBreakdownBuilder<T>
    ctor()
    ScoreBreakdownBuilder<T> Metric(string name, double weight, Func<T, double> evaluate)
    ScoreBreakdown Score(T value)
  sealed class ScoreMetric
    ctor()
    string Name { get;  init; }
    double Score { get;  init; }
    double Weight { get;  init; }
    double WeightedScore { get; }
  sealed class SelfConsistencyOptions<T> : EmergeScope<T>
    ctor()
    int MaxParallel { get;  set; }
    Action<CandidateScope<T>> SampleConfig { get;  set; }
    int Samples { get;  set; }
    Func<IReadOnlyList<T>, T> SelectMajority { get;  set; }
    void Sample(Action<CandidateScope<T>> configure)
  sealed class SolverCriticVerifierOptions<T> : EmergeScope<T>
    ctor()
    EmergeScope CriticScope { get; }
    int MaxRounds { get;  set; }
    EmergeScope<T> SolverScope { get; }
    EmergeScope<T> VerifierScope { get; }
    void Critic(Action<EmergeScope> configure)
    void Solver(Action<EmergeScope<T>> configure)
    void Verifier(Action<EmergeScope<T>> configure)
  sealed class Stage<T> : EmergeEvent<T>, IEquatable<Stage<T>>
    ctor(string Name)
    string Name { get;  init; }
  sealed class Stopped<T> : EmergeEvent<T>, IEquatable<Stopped<T>>
    ctor(KernelContext Context, string Reason)
    KernelContext Context { get;  init; }
    string Reason { get;  init; }
  sealed class SwarmAgent<T>
    ctor()
    List<string> DependsOn { get;  set; }
    string Id { get;  set; }
    string Role { get;  set; }
    EmergeScope<T> Scope { get; }
  sealed class SwarmOptions<T> : EmergeScope<T>
    ctor()
    List<SwarmAgent<T>> Agents { get; }
    EmergeScope<T> CoordinatorScope { get; }
    int MaxParallel { get;  set; }
    int MaxRounds { get;  set; }
    Func<IReadOnlyList<T>, T> Merge { get;  set; }
    void AddAgent(string role, Action<EmergeScope<T>> configure)
    void Coordinator(Action<EmergeScope<T>> configure)
  sealed class TaskGraphOptions<T> : EmergeScope<T>
    ctor()
    bool EnableParallelReview { get;  set; }
    int MaxParallel { get;  set; }
    Func<string, Task> OnHumanFeedback { get;  set; }
    Action<PlanRevision> OnPlanRevised { get;  set; }
    Action<ReviewFeedback> OnReviewCompleted { get;  set; }
    Action<TaskNode, object> OnTaskCompleted { get;  set; }
    EmergeScope<PlanRevision> PlanReviserScope { get; }
    int ReviewIntervalTasks { get;  set; }
    EmergeScope<ReviewFeedback> ReviewerScope { get; }
    EmergeScope<T> SynthesizerScope { get; }
    List<TaskNode> Tasks { get; }
    EmergeScope<T> WorkerScope { get; }
    void AddTask(string id, string description, params string[] blockedBy)
    void PlanReviser(Action<EmergeScope<PlanRevision>> configure)
    void Reviewer(Action<EmergeScope<ReviewFeedback>> configure)
    void Synthesizer(Action<EmergeScope<T>> configure)
    void Worker(Action<EmergeScope<T>> configure)
  sealed class TaskNode
    ctor()
    List<string> BlockedBy { get;  set; }
    List<string> Blocks { get;  set; }
    string Description { get;  set; }
    string Error { get;  set; }
    string Id { get;  set; }
    string Owner { get;  set; }
    object Result { get;  set; }
    string Status { get;  set; }
  sealed class TestRefineFeedback
    ctor()
    bool Continue { get;  set; }
    string Feedback { get;  set; }
    ScoreBreakdown Score { get;  set; }
  sealed class TestRefineOptions<T> : EmergeScope<T>
    ctor()
    Func<T, int, Task> Apply { get;  set; }
    Func<T, int, Task<TestRefineFeedback>> Evaluate { get;  set; }
    EmergeScope<T> InitialScope { get; }
    int MaxIterations { get;  set; }
    EmergeScope<T> RefinementScope { get; }
    void Initial(Action<EmergeScope<T>> configure)
    void Refinement(Action<EmergeScope<T>> configure)
  sealed class ThoughtNode<T>
    ctor()
    List<ThoughtNode<T>> Children { get; }
    int Depth { get;  set; }
    ThoughtNode<T> Parent { get;  set; }
    string Reasoning { get;  set; }
    double Score { get;  set; }
    T Value { get;  set; }
  sealed class TokenUpdate<T> : EmergeEvent<T>, IEquatable<TokenUpdate<T>>
    ctor(long InputTokens, long OutputTokens)
    long InputTokens { get;  init; }
    long OutputTokens { get;  init; }
  sealed class ToolCallPlanned<T> : EmergeEvent<T>, IEquatable<ToolCallPlanned<T>>
    ctor(FunctionCall Call)
    FunctionCall Call { get;  init; }
  sealed class ToolCallResult<T> : EmergeEvent<T>, IEquatable<ToolCallResult<T>>
    ctor(FunctionCall Call, StreamingResult[] StreamingResults, object Result)
    FunctionCall Call { get;  init; }
    object Result { get;  init; }
    StreamingResult[] StreamingResults { get;  init; }
  sealed class TreeOfThoughtOptions<T> : EmergeScope<T>
    ctor()
    int BeamWidth { get;  set; }
    int BranchingFactor { get;  set; }
    Func<T, EmergenceTrace, double> Evaluate { get;  set; }
    EmergeScope<T> EvaluatorScope { get; }
    int MaxDepth { get;  set; }
    EmergeScope<T> ThoughtScope { get; }
    void Evaluator(Action<EmergeScope<T>> configure)
    void Thought(Action<EmergeScope<T>> configure)
  sealed class TreeSearchOptions<T> : EmergeScope<T>
    ctor()
    TreeIndex Index { get;  set; }
    int MaxResults { get;  set; }
    int MaxSteps { get;  set; }
    EmergeScope<NavigationDecision> NavigatorScope { get; }
    string Query { get;  set; }
    void Navigator(Action<EmergeScope<NavigationDecision>> configure)
  class TreeSearchResult
    ctor()
    string ReasoningTrace { get;  set; }
    List<FoundSection> Sections { get;  set; }

namespace Ikon.AI.Emergence.Structured
  sealed class StructuredTagParser.ParsedBlock : IEquatable<StructuredTagParser.ParsedBlock>
    ctor(string TagName, string Content, int StartIndex, int EndIndex)
    string Content { get;  init; }
    int EndIndex { get;  init; }
    int StartIndex { get;  init; }
    string TagName { get;  init; }
  sealed class StructuredTagParser.ParsedResponse : IEquatable<StructuredTagParser.ParsedResponse>
    ctor(string PlainText, IReadOnlyList<StructuredTagParser.ParsedBlock> Blocks)
    IReadOnlyList<StructuredTagParser.ParsedBlock> Blocks { get;  init; }
    string PlainText { get;  init; }
  static class StructuredTagParser
    static string GetTagContent(string content, string tagName)
    static bool HasTag(string content, string tagName)
    static StructuredTagParser.ParsedResponse Parse(string content, params string[] tagNames)

namespace Ikon.AI.Emergence.Tree
  class ContentSection : IEquatable<ContentSection>
    ctor(string Title, string Content, int? Page = null)
    string Content { get;  init; }
    int? Page { get;  init; }
    string Title { get;  init; }
  interface IContentReader
    abstract IAsyncEnumerable<ContentSection> ReadSectionsAsync(CancellationToken ct = null)
  class StringContentReader : IContentReader
    ctor(string content)
    IAsyncEnumerable<ContentSection> ReadSectionsAsync(CancellationToken ct = null)
  class TreeIndex
    ctor()
    ctor(TreeNode root)
    TreeNode Root { get;  set; }
    static IAsyncEnumerable<EmergeEvent<TreeIndex>> BuildAsync(LLMModel model, string content, TreeIndexOptions options = null, CancellationToken ct = null)
    static IAsyncEnumerable<EmergeEvent<TreeIndex>> BuildAsync(LLMModel model, IContentReader reader, TreeIndexOptions options = null, CancellationToken ct = null)
    TreeNode FindById(string id)
    void RebuildIndex()
    string ToTableOfContents(int maxDepth = -1)
    IEnumerable<TreeNode> Traverse()
  class TreeIndexOptions
    ctor()
    bool GenerateSummaries { get;  set; }
    int MaxDepth { get;  set; }
    int MaxSummaryTokens { get;  set; }
  class TreeNode
    ctor()
    ctor(string id, string title, string content = "")
    List<TreeNode> Children { get; }
    string Content { get;  set; }
    int Depth { get; }
    string Id { get;  set; }
    int? Page { get;  set; }
    TreeNode Parent { get; }
    string Summary { get;  set; }
    string Title { get;  set; }
    void AddChild(TreeNode child)
    string GetPath()
    IEnumerable<TreeNode> Traverse()
