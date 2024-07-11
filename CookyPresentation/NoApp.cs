using CookyPresentation.ViewModels;

namespace CookyPresentation;

internal class NoApp : IAppWrapper
{
    public Task GoBack() => Task.CompletedTask;
    public Task Open(RecipeEditor? recipe) => Task.CompletedTask;

    public string AppDataDirectory => string.Empty;
}