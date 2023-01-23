using System.Text.RegularExpressions;
using static System.Environment;
using static System.StringSplitOptions;

namespace CookyPresentation.ViewModel;

internal static class RecipePersistence
{
    public static Recipe Load(string id)
    {
        var fileName = FileNameFrom(id);
        if (!File.Exists(fileName)) 
            throw new RecipeNotFoundException(id);

        var date = File.GetCreationTime(fileName);
        var (title, ingredients, instructions) = Parse(File.ReadAllText(fileName));

        return new Recipe
        {
            Id = id,
            Date = date,
            Ingredients = ingredients,
            Instructions = instructions,
            Title = title,
        };
    }
    
    private static (string, string, string) Parse(string raw)
    {
        var pattern = new Regex(
            @"^(?:# (?<Title>.*))\n*(?:## Ingredients\n*(?<Ingredients>.*))\n*(?:## Instructions\n*(?<Instructions>.*))", 
            RegexOptions.Singleline);

        var match = pattern.Match(raw);

        return (match.Groups["Title"].Value.Trim(),
            match.Groups["Ingredients"].Value.Trim(),
            match.Groups["Instructions"].Value.Trim());
    }

    private static string Serialized(Recipe recipe) => $"""
                                # {recipe.Title}

                                ## Ingredients

                                {Trimmed(recipe.Ingredients)}

                                ## Instructions

                                {recipe.Instructions}
                                """;

    private static string Trimmed(string text) => 
        string.Join(NewLine, text.Split(NewLine, TrimEntries|RemoveEmptyEntries));

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