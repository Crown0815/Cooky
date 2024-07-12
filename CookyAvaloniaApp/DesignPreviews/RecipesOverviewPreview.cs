using CookyPresentation.ViewModels;

namespace CookyAvaloniaApp.DesignPreviews;

public class RecipesOverviewPreview : RecipesOverview
{
    public RecipesOverviewPreview() : base(null!)
    {
        Recipes.Add(new RecipeItemPreview(this));
        Recipes.Add(new RecipeItemPreview(this));
        Recipes.Add(new RecipeItemPreview(this));
        Recipes.Add(new RecipeItemPreview(this));
    }
}