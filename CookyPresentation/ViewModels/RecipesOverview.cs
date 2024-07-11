using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace CookyPresentation.ViewModels;

public class RecipesOverview : ViewModelBase
{
    public RecipesOverview()
    {
        NewRecipeCommand = new AsyncRelayCommand(CreateNewRecipe);
    }

    public ObservableCollection<RecipeItem> Recipes { get; } = new();
    public string NewRecipeLabel => "Add New Recipe";
    public ICommand NewRecipeCommand { get; }

    private Task CreateNewRecipe()
    {
        var recipe = RecipePersistence.New();
        Recipes.Add(new RecipeItem(recipe));
        return Task.CompletedTask;
    }
}