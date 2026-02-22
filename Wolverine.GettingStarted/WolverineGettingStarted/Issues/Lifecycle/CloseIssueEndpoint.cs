using Marten;
using Wolverine.Http;
using WolverineGettingStarted.Issues.Model;

namespace WolverineGettingStarted.Issues.Lifecycle;

public static class CloseIssueEndpoint
{
    [EmptyResponse]
    [WolverinePut("/api/issues/{issueId}/close")]
    public static async Task Close(CloseIssue command, IDocumentSession session)
    {
        var stream = await session.Events.FetchForWriting<Issue>(command.IssueId);
        stream.AppendOne(new IssueClosed(stream.Aggregate!.Id, DateTimeOffset.UtcNow));
    }
}
