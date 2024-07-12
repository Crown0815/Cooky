using CookyPresentation.Model;

namespace CookyPresentation.ViewModels;

public class RecipeItem(Recipe recipe, RecipesOverview overview) : ViewModelBase, IOpen, IEditor
{
    public string Title => recipe.Title;
    public DateTime Created => recipe.Date;

    public Task Open() => Application.Open(new RecipeEditor(recipe, this));

    public string OpenLabel => "Open";
    
    public Task Save() => overview.SaveItem(this);

    public Task Delete() => overview.DeleteItem(this);
}