using Marten;
using Wolverine.Http;
using WolverineGettingStarted.Issues.Model;

namespace WolverineGettingStarted.Issues.Lifecycle;

public static class ReopenIssueEndpoint
{
    [EmptyResponse]
    [WolverinePut("/api/issues/{issueId}/reopen")]
    public static async Task Reopen(ReopenIssue command, IDocumentSession session)
    {
        var stream = await session.Events.FetchForWriting<Issue>(command.IssueId);
        stream.AppendOne(new IssueOpened(stream.Aggregate!.Id, DateTimeOffset.UtcNow));
    }
}
