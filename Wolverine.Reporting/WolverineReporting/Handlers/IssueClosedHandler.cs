using Marten;
using WolverineGettingStarted.Issues.Lifecycle;
using WolverineReporting.Reports;

namespace WolverineReporting.Handlers;

public static class IssueClosedHandler
{
    public static async Task Handle(IssueClosed @event, IDocumentSession session)
    {
        var report = await session.LoadAsync<IssueReport>(@event.IssueId);
        if (report is null) return;

        report.Status = "Closed";
        report.Closed = @event.Closed;
        report.LastUpdated = @event.Closed;
        report.EventCount++;

        session.Store(report);
    }
}
