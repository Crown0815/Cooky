using CookyPresentation.ViewModel;

namespace CookyPresentation;

public interface IAppWrapper
{
    Task GoBack();
    string AppDataDirectory { get; }
    Task Open(RecipeEditor? recipe);
}