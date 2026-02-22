using Marten;
using Wolverine.Http;
using WolverineGettingStarted.Issues.Model;

namespace WolverineGettingStarted.Issues.Get;

public static class GetIssueEndpoint
{
    [WolverineGet("/api/issues/{id}")]
    public static async Task<Issue?> GetIssue(IssueId id, IQuerySession session)
    {
        return await session.Events.AggregateStreamAsync<Issue>(id);
    }
}
