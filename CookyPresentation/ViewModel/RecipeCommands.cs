using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace CookyPresentation.ViewModel;

public static class RecipeCommands
{
    public static ICommand SaveCommand { get; } = new AsyncRelayCommand<RecipePage>(Save!);
    public static ICommand DeleteCommand { get; } = new AsyncRelayCommand<RecipePage>(Delete!);

    private static async Task Save(RecipePage recipe)
    {
        await File.WriteAllTextAsync(recipe.Filename, recipe.Serialized());
        await GoBackAsync();
    }

    private static Task GoBackAsync() => Application.GoBack();

    private static Task Delete(RecipePage recipe)
    {
        Delete(recipe.Filename);
        return GoBackAsync();
    }

    private static void Delete(string fileName)
    {
        if (File.Exists(fileName))
            File.Delete(fileName);
    }
}