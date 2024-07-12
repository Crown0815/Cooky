using System.Collections.ObjectModel;

namespace CookyPresentation.ViewModels;

public class RecipesOverview(IAppWrapper app) : ViewModelBase, ICreator
{
    public ObservableCollection<RecipeItem> Recipes { get; } = new();
    public string NewRecipeLabel => "Add New Recipe";

    public Task CreateItem()
    {
        var recipe = RecipePersistence.New();
        Recipes.Add(new RecipeItem(recipe, this));
        return Task.CompletedTask;
    }
    
    public Task DeleteItem(RecipeItem item)
    {
        Recipes.Remove(item);
        return app.GoBack();
    }

    public Task SaveItem(RecipeItem recipeItem)
    {
        throw new NotImplementedException();
    }

    public Task Open(RecipeEditor recipeEditor) => app.Open(recipeEditor);
}