namespace CookyPresentation.ViewModel;

internal static class RecipePersistence
{
    public static Recipe Load(string id)
    {
        if (!File.Exists(id)) 
            throw new RecipeNotFoundException(id);

        var date = File.GetCreationTime(id);
        var (title, instructions) = Parse(File.ReadAllText(id));

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
        File.WriteAllTextAsync(recipe.Id, Serialized(recipe));

    public static void Delete(Recipe recipe)
    {
        var fileName = recipe.Id;
        if (File.Exists(fileName))
            File.Delete(fileName);
    }

    public static Recipe New() => new() { Id = NewId() };

    private static string NewId()
    {
        var appDataPath = Application.AppDataDirectory;
        var randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        return Path.Combine(appDataPath, randomFileName);
    }
}