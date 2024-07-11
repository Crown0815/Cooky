using System;
using CookyPresentation.Model;
using CookyPresentation.ViewModels;

namespace CookyAvaloniaApp.DesignPreviews;

public class RecipeItemPreview() : RecipeItem(PreviewRecipe)
{
    private static readonly Recipe PreviewRecipe = new(Guid.NewGuid().ToString(), DateTime.Now, "")
    {
        Title = $"Title_{Guid.NewGuid()}",
    };
}