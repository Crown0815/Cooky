using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace CookyPresentation.ViewModel;

public class Recipe
{
    private Recipe(string filename)
    {
        Filename = filename;
        Load();
    }

    public string Filename { get; }
    public string Placeholder => "Enter your recipe";
    public string TitlePlaceholder => "Title";
    public string Text { get; set; } = "";
    public DateTime Date { get; set; }
    
    public string SaveLabel => "Save";
    public ICommand SaveCommand { get; } = new AsyncRelayCommand<Recipe>(Save!);
    
    public string DeleteLabel => "Delete";
    public ICommand DeleteCommand { get; } = new AsyncRelayCommand<Recipe>(Delete!);
    public string Title { get; set; } = "";

    public static Recipe New()
    {
        var appDataPath = Application.AppDataDirectory;
        var randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        var filename = Path.Combine(appDataPath, randomFileName);
        
        return Load(filename);
    }

    private static async Task Save(Recipe recipe)
    {
        await File.WriteAllTextAsync(recipe.Filename, recipe.Text);
        await GoBackAsync();
    }
    
    private static Task GoBackAsync() => Application.GoBack();

    private static Task Delete(Recipe recipe)
    {
        Delete(recipe.Filename);
        return GoBackAsync();
    }

    private static void Delete(string fileName)
    {
        if (File.Exists(fileName))
            File.Delete(fileName);
    }

    public static Recipe Load(string fileName) => new(fileName);

    private void Load()
    {
        if (!File.Exists(Filename)) return;
        
        Date = File.GetCreationTime(Filename);
        Text = File.ReadAllText(Filename);
    }
}