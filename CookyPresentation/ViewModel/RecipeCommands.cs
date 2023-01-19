using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using static CookyPresentation.Application;

namespace CookyPresentation.ViewModel;

public static class RecipeCommands
{
    public static ICommand SaveCommand { get; } = new AsyncRelayCommand<RecipePage>(Save!);
    public static ICommand DeleteCommand { get; } = new AsyncRelayCommand<RecipePage>(Delete!);

    private static async Task Save(RecipePage recipe)
    {
        await recipe.Save();
        await GoBack();
    }

    private static Task Delete(RecipePage recipe)
    {
        recipe.Delete();
        return GoBack();
    }
}