namespace CookyPresentation.ViewModel;

public class RecipePage
{
    private string _text = "";

    private RecipePage(string filename)
    {
        Filename = filename;
        Load();
        RecipeCommands = new RecipeCommands();
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

    public string DeleteLabel => "Delete";
    public string Title { get; set; } = "";

    public RecipeCommands RecipeCommands { get; }

    public static RecipePage New()
    {
        var appDataPath = Application.AppDataDirectory;
        var randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        var filename = Path.Combine(appDataPath, randomFileName);
        
        return Load(filename);
    }

    public static RecipePage Load(string fileName) => new(fileName);

    private void Load()
    {
        if (!File.Exists(Filename)) return;
        
        Date = File.GetCreationTime(Filename);
        Parse(File.ReadAllText(Filename));
    }

    private void Parse(string raw)
    {
        var allText = raw;
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

    public string Serialized() => $"""
                                # {Title}

                                {Text}
                                """;
}