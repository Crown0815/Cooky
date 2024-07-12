using CookyPresentation.Model;

namespace CookyPresentation.ViewModels;

public class RecipeItem(Recipe recipe) : ViewModelBase, IOpen
{
    public string Title => recipe.Title;
    public DateTime Created => recipe.Date;

    public Task Open() => Application.Open(new RecipeEditor(recipe));

    public string OpenLabel => "Open";
}