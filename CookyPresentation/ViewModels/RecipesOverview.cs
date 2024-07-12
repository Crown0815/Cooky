using System.Collections.ObjectModel;

namespace CookyPresentation.ViewModels;

public class RecipesOverview : ViewModelBase, ICreator
{
    public ObservableCollection<RecipeItem> Recipes { get; } = new();
    public string NewRecipeLabel => "Add New Recipe";

    public Task CreateItem()
    {
        var recipe = RecipePersistence.New();
        Recipes.Add(new RecipeItem(recipe));
        return Task.CompletedTask;
    }
}