using CookyPresentation.ViewModels;

namespace CookyPresentation;

public interface IAppWrapper
{
    Task GoBack();
    string AppDataDirectory { get; }
    Task Open(RecipeEditor? recipe);
}