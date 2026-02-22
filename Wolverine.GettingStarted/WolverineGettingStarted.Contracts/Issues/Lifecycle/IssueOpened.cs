using WolverineGettingStarted.Issues.Model;

namespace WolverineGettingStarted.Issues.Lifecycle;

public record IssueOpened(IssueId IssueId, DateTimeOffset Reopened);
