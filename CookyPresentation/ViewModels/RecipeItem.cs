using CookyPresentation.Model;

namespace CookyPresentation.ViewModels;

public class RecipeItem(Recipe recipe) : ViewModelBase
{
    public string Title => recipe.Title;
    public DateTime Created => recipe.Date;
}