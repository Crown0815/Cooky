using CookyPresentation.ViewModel;

namespace CookyPresentation.Model;

internal class Recipe
{
    public Recipe(string id, DateTime date, string ingredients)
    {
        Id = id;
        Date = date;
        _ingredients = ingredients;
    }

    private string _ingredients;
    private const char IngredientPreparationSeparator = ',';

    public string Id { get; }
    public DateTime Date { get; }

    public string Title { get; set; } = "";
    public string Instructions { get; set; } = "";

    public string Ingredients => string.Join(Environment.NewLine, IngredientsList.Select(x => x.Name));

    public void SetIngredients(string value)
    {
        _ingredients = value;
    }

    public IReadOnlyCollection<Ingredient> IngredientsList => LinesFrom(_ingredients).Select(AsIngredient).ToList();

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
