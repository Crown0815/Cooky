using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace CookyPresentation.ViewModel;

public class Recipe
{
    private string _text = "";

    private Recipe(string filename)
    {
        Filename = filename;
        Load();
    }

    public string Filename { get; }
    public string Placeholder => "Enter your recipe";
    public string TitlePlaceholder => "Title";

    public string Text
    {
        get => _text;
        set => _text = value.Trim();
    }

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
        var content = $"""
                    # {recipe.Title}

                    {recipe.Text}
                    """;
        
        await File.WriteAllTextAsync(recipe.Filename, content);
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
        var allText = File.ReadAllText(Filename);
        if (allText.StartsWith("# "))
        {
            allText = allText[2..];
            Title = allText.Split(Environment.NewLine).First();
            if (Title is not "")
                allText = allText.Replace(Title, "");
            allText = allText.Trim();
        }

        Text = allText;

    }
}