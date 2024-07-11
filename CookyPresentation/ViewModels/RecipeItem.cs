using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CookyPresentation.Model;

namespace CookyPresentation.ViewModels;

public class RecipeItem(Recipe recipe) : ViewModelBase
{
    private readonly Recipe _recipe = recipe;
    public string Title => _recipe.Title;
    public DateTime Created => _recipe.Date;
    
    public ICommand OpenCommand { get; } = new AsyncRelayCommand<RecipeItem>(Open);

    private static Task Open(RecipeItem? arg)
    {
        if (arg is not null)
            Application.Open(new RecipeEditor(arg._recipe));
        return Task.CompletedTask;
    }

    public string OpenLabel => "Open";
}