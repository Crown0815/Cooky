using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using RecipePage = CookyPresentation.ViewModel.RecipePage;

namespace Cooky.Models;

internal class AllRecipes
{
    private static readonly string RecipesPath = FileSystem.AppDataDirectory;
    public ObservableCollection<RecipePage> Recipes { get; } = new();
    public ICommand NewRecipe { get; } = new AsyncRelayCommand(CreateNewRecipe);

    private static Task CreateNewRecipe() => Shell.Current.GoToAsync(nameof(Views.RecipePage));

    public AllRecipes() => LoadRecipes();

    public void LoadRecipes()
    {
        Recipes.Clear();

        foreach (var note in RecipesFrom(RecipesPath))
            Recipes.Add(note);
    }

    private static IEnumerable<RecipePage> RecipesFrom(string path) => 
        Directory
            .EnumerateFiles(path, "*.notes.txt")
            .Select(RecipePage.Load)
            .OrderBy(x => x.Date);

    public ICommand OpenCommand { get; } = new AsyncRelayCommand<RecipePage>(Open);

    private static Task Open(RecipePage recipe) => 
        Shell.Current.GoToAsync($"{nameof(Views.RecipePage)}?{nameof(Views.RecipePage.ItemId)}={recipe.Filename}");
}