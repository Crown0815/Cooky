using System;
using CookyPresentation.Model;
using CookyPresentation.ViewModels;

namespace CookyAvaloniaApp.DesignPreviews;

public class RecipeItemPreview(RecipesOverview overview = null!) : RecipeItem(PreviewRecipe, overview)
{
    private static readonly Recipe PreviewRecipe = new(Guid.NewGuid().ToString(), DateTime.Now, "")
    {
        Title = $"Title_{Guid.NewGuid()}",
    };
}