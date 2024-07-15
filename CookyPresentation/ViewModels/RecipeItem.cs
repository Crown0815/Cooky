using CookyPresentation.Model;

namespace CookyPresentation.ViewModels;

public class RecipeItem(Recipe recipe, RecipesOverview overview) : ViewModelBase, IOpen, IEditor
{
    public string Title => recipe.Title;
    public DateTime Created => recipe.Date;

    public Task Open() => overview.Open(recipe);

    public string OpenLabel => "Open";
    public string DeleteLabel => "Delete";

    public Task Save() => overview.SaveItem(this);

    public Task Delete() => overview.Delete(recipe);
}