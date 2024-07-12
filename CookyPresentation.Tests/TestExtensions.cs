using CookyPresentation.ViewModels;

namespace CookyPresentation.Tests;

public static class TestExtensions
{
    public static RecipeEditor OpenNewRecipe(this MainWindow main)
    {
        var overview = (RecipesOverview)main.CurrentViewModel!;
        overview.CreateItem().Await();
        overview.Recipes.Single().Open().Await();
        return (RecipeEditor)main.CurrentViewModel!;
    }
}