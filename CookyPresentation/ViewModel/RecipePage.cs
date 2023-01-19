namespace CookyPresentation.ViewModel;

public class RecipePage
{
    private string _instructions = "";
    private readonly Recipe _recipe;

    private RecipePage(string filename)
    {
        Filename = filename;
        Load();
    }
    
    public RecipeLabels Labels { get; } = new();

    public string Filename { get; }

    public string Instructions
    {
        get => _instructions;
        set => _instructions = value.Trim();
    }

    public DateTime Date { get; set; }

    public string Title { get; set; } = "";


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

        Instructions = allText;
    }

    public string Serialized() => $"""
                                # {Title}

                                {Instructions}
                                """;
}