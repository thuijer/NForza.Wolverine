using WolverineGettingStarted.Issues.Model;
using WolverineGettingStarted.Users;

namespace WolverineGettingStarted.Issues;

public record IssueAssigned(IssueId IssueId, UserId AssigneeId);
