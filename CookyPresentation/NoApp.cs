namespace CookyPresentation;

internal class NoApp : IAppWrapper
{
    public Task GoBack() => Task.CompletedTask;

    public string AppDataDirectory => string.Empty;
}