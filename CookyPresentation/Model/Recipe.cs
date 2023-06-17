using CookyPresentation.ViewModel;

namespace CookyPresentation.Model;

internal class Recipe
{
    private const char IngredientPreparationSeparator = ',';

    public string Id { get; internal init; } = "";
    public DateTime Date { get; internal init; }

    public string Title { get; set; } = "";
    public string Instructions { get; set; } = "";
    public string Ingredients { get; set; } = "";

    public IReadOnlyCollection<Ingredient> IngredientsList => LinesFrom(Ingredients).Select(AsIngredient).ToList();

    private static Ingredient AsIngredient(string line)
    {
        var unit = "";
        if (line.Split(" ") is [var x, ..] && x.IsUnit())
        {
            unit = x;
            line = line.Remove(0, unit.Length + 1);
        }

        if (line.Contains(IngredientPreparationSeparator))
        {
            var pieces = line.Split(IngredientPreparationSeparator);
            return new Ingredient(pieces[0].Trim(), pieces[1].Trim(), unit);
        }

        return new Ingredient(line, "", unit);
    }

    private static IEnumerable<string> LinesFrom(string text)
    {
        using var reader = new StringReader(text);
        while (reader.ReadLine() is { } line)
            if (!string.IsNullOrEmpty(line))
                yield return line.Trim();
    }
}
