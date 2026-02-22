using Alba;
using Marten;
using Microsoft.Extensions.DependencyInjection;
using Wolverine.Tracking;

namespace WolverineReporting.Tests;

[Collection("integration")]
public abstract class IntegrationContext : IAsyncLifetime
{
    private readonly AppFixture _fixture;

    protected IntegrationContext(AppFixture fixture)
    {
        _fixture = fixture;
    }

    public IAlbaHost Host => _fixture.Host;

    public IDocumentStore Store =>
        Host.Services.GetRequiredService<IDocumentStore>();

    public async Task InitializeAsync()
    {
        await Store.Advanced.ResetAllData();
    }

    public Task DisposeAsync() => Task.CompletedTask;

    protected async Task<IScenarioResult> Scenario(Action<Scenario> configure)
    {
        return await Host.Scenario(configure);
    }

    protected async Task<ITrackedSession> SendMessage(object message)
    {
        return await Host.InvokeMessageAndWaitAsync(message);
    }
}
