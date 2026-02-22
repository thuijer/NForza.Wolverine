using Marten;
using WolverineGettingStarted.Issues;
using WolverineReporting.Reports;

namespace WolverineReporting.Handlers;

public static class IssueAssignedHandler
{
    public static async Task Handle(IssueAssigned @event, IDocumentSession session)
    {
        var report = await session.LoadAsync<IssueReport>(@event.IssueId);
        if (report is null) return;

        report.AssigneeId = @event.AssigneeId;
        report.LastUpdated = DateTimeOffset.UtcNow;
        report.EventCount++;

        session.Store(report);
    }
}
