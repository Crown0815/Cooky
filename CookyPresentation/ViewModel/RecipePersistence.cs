namespace CookyPresentation.ViewModel;

internal static class RecipePersistence
{
    public static Recipe Load(string id)
    {
        var fileName = FileNameFrom(id);
        if (!File.Exists(fileName)) 
            throw new RecipeNotFoundException(id);

        var date = File.GetCreationTime(fileName);
        var (title, instructions) = Parse(File.ReadAllText(fileName));

        return new Recipe
        {
            Id = id,
            Date = date,
            Instructions = instructions,
            Title = title,
        };
    }
    
    private static (string, string) Parse(string raw)
    {
        var title = "";
        var allText = raw;
        if (allText.StartsWith("# "))
        {
            allText = allText[2..];
            title = allText.Split(Environment.NewLine).First();
            if (title is not "")
                allText = allText.Replace(title, "");
            allText = allText.Trim();
        }
        
        return (title, allText);
    }

    private static string Serialized(Recipe recipe) => $"""
                                # {recipe.Title}

                                {recipe.Instructions}
                                """;

    public static Task Save(Recipe recipe) => 
        File.WriteAllTextAsync(FileNameFrom(recipe.Id), Serialized(recipe));

    public static void Delete(Recipe recipe)
    {
        var fileName = FileNameFrom(recipe.Id);
        if (File.Exists(fileName))
            File.Delete(fileName);
    }

    public static Recipe New() => new() { Id = Path.GetRandomFileName() };

    private static string FileNameFrom(string id) {
        var appDataPath = Application.AppDataDirectory;
        var filename = id;
        if (!filename.StartsWith(appDataPath))
            filename = Path.Combine(appDataPath, id);
        if (!filename.EndsWith(".notes.txt"))
            filename += ".notes.txt";
        return filename;
    }
}