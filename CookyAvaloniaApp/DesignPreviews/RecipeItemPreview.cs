using System;
using CookyPresentation.Model;
using CookyPresentation.ViewModels;

namespace CookyAvaloniaApp.DesignPreviews;

public class RecipeItemPreview(RecipesOverview overview) : RecipeItem(PreviewRecipe, overview)
{
    public RecipeItemPreview() : this(new RecipesOverviewPreview()) { }
    
    public static Recipe PreviewRecipe => new(Guid.NewGuid().ToString(), DateTime.Now, "")
    {
        Title = $"Title_{Guid.NewGuid()}",
        Instructions = """
                       1. Instruction
                       2. Instruction
                       3. ...
                       """,
    };
}