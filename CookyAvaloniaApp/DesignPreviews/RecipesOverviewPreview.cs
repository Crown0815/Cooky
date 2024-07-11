using CookyPresentation.ViewModels;

namespace CookyAvaloniaApp.DesignPreviews;

public class RecipesOverviewPreview : RecipesOverview
{
    public RecipesOverviewPreview()
    {
        Recipes.Add(new RecipeItemPreview());
        Recipes.Add(new RecipeItemPreview());
        Recipes.Add(new RecipeItemPreview());
        Recipes.Add(new RecipeItemPreview());
    }
}