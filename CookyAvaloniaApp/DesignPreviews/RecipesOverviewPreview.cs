using CookyPresentation.ViewModels;

namespace CookyAvaloniaApp.DesignPreviews;

public class RecipesOverviewPreview : RecipesOverview
{
    public RecipesOverviewPreview()
    {
        Recipes.Add(new RecipeItemPreview(this));
        Recipes.Add(new RecipeItemPreview(this));
        Recipes.Add(new RecipeItemPreview(this));
        Recipes.Add(new RecipeItemPreview(this));
    }
}