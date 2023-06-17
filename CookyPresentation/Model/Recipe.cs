namespace CookyPresentation.Model;

internal class Recipe
{
    public string Id { get; internal init; } = "";
    public DateTime Date { get; internal init; }

    public string Title { get; set; } = "";
    public string Instructions { get; set; } = "";
    public string Ingredients { get; set; } = "";
}
