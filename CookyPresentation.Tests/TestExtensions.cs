using CookyPresentation.ViewModels;

namespace CookyPresentation.Tests;

public static class TestExtensions
{
    public static async Task<RecipeEditor> OpenNewRecipe(this MainWindow main)
    {
        var recipe = await main.NewRecipe();
        await recipe.Open();
        return (RecipeEditor)main.CurrentViewModel!;
    }
    
    public static async Task<RecipeItem> NewRecipe(this MainWindow main)
    {
        var overview = main.RecipeOverview();
        await overview.CreateItem();
        return overview.Recipes.Single();
    }
    
    public static RecipesOverview RecipeOverview(this MainWindow main)
    {
        return (RecipesOverview)main.CurrentViewModel!;
    }

}