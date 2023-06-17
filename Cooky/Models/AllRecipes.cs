using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Cooky.Views;
using CookyPresentation.ViewModel;

namespace Cooky.Models;

internal class AllRecipes
{
    private static readonly string RecipesPath = FileSystem.AppDataDirectory;
    public ObservableCollection<RecipeEditor> Recipes { get; } = new();
    public ICommand NewRecipe { get; } = new AsyncRelayCommand(CreateNewRecipe);

    private static Task CreateNewRecipe() => Shell.Current.GoToAsync(nameof(RecipePage));

    public AllRecipes() => LoadRecipes();

    public void LoadRecipes()
    {
        Recipes.Clear();

        foreach (var note in RecipesFrom(RecipesPath))
            Recipes.Add(note);
    }

    private static IEnumerable<RecipeEditor> RecipesFrom(string path)
    {
        return Directory
            .EnumerateFiles(path, "*.notes.txt")
            .Select(RecipeEditor.Load)
            .OrderBy(x => x.Date);
    }

    public ICommand OpenCommand { get; } = new AsyncRelayCommand<RecipeEditor>(Open);

    private static Task Open(RecipeEditor recipe)
    {
        return Shell.Current.GoToAsync(
            $"{nameof(RecipePage)}?{nameof(RecipePage.ItemId)}={recipe.Filename}");
    }
}