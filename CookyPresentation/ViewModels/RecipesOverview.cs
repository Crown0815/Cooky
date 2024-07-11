using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CookyPresentation.Model;

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
    public ICommand OpenCommand { get; } = new AsyncRelayCommand<RecipeEditor>(Open);

    private Task CreateNewRecipe()
    {
        var recipe = RecipePersistence.New();
        Recipes.Add(new RecipeItem(recipe));
        return Task.CompletedTask;
    }

    private static Task Open(RecipeEditor? recipe) => Application.Open(recipe);
}

public class RecipeItem(Recipe recipe) : ViewModelBase
{
    public string Title => recipe.Title;
    public DateTime Created => recipe.Date;
}