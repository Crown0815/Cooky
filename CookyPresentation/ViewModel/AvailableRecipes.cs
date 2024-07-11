using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace CookyPresentation.ViewModel;

public class AvailableRecipes : ViewModelBase
{
    public AvailableRecipes()
    {
        NewRecipe = new AsyncRelayCommand(CreateNewRecipe);
    }

    public ObservableCollection<RecipeEditor> Recipes { get; } = new();
    public ICommand NewRecipe { get; }
    public ICommand OpenCommand { get; } = new AsyncRelayCommand<RecipeEditor>(Open);

    private Task CreateNewRecipe()
    {
        Recipes.Add(RecipeEditor.New());
        return Task.CompletedTask;
    }

    private static Task Open(RecipeEditor? recipe) => Application.Open(recipe);
}