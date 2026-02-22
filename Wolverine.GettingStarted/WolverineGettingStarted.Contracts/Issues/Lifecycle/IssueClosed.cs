using WolverineGettingStarted.Issues.Model;

namespace WolverineGettingStarted.Issues.Lifecycle;

public record IssueClosed(IssueId IssueId, DateTimeOffset Closed);
