using System.Collections.ObjectModel;
using CookyPresentation.Model;

namespace CookyPresentation.ViewModels;

public class RecipesOverview(IAppWrapper app) : ViewModelBase, ICreator
{
    private readonly Dictionary<Recipe, RecipeItem> _items = new();
    public ObservableCollection<RecipeItem> Recipes { get; } = [];
    public string NewRecipeLabel => "Add New Recipe";

    public Task CreateItem()
    {
        var recipe = RecipePersistence.New();
        _items.Add(recipe, new RecipeItem(recipe, this));
        Recipes.Add(_items[recipe]);
        return Task.CompletedTask;
    }

    public Task Delete(Recipe recipe)
    {
        var item = _items[recipe];
        Recipes.Remove(item);
        _items.Remove(recipe);
        return app.GoBack();
    }

    public Task SaveItem(RecipeItem recipeItem)
    {
        throw new NotImplementedException();
    }

    public Task Open(Recipe recipe) => app.Open(new RecipeEditor(recipe, this));
    public Task Open(ViewModelBase? viewModel) => app.Open(viewModel);
}