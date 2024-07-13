using CookyPresentation.Model;

namespace CookyPresentation.ViewModels;

public class IngredientsEditor : ViewModelBase, IOpen
{
    private readonly Recipe _recipe;

    protected internal IngredientsEditor(Recipe recipe)
    {
        _recipe = recipe;
    }

    public string Text
    {
        get => _recipe.Ingredients;
        set
        {
            _recipe.Ingredients = value;
            OnPropertyChanged(nameof(List));
        }
    }

    public IReadOnlyCollection<Ingredient> List => _recipe.IngredientsList.Count == 0 
        ? new EmptyList<Ingredient>("No ingredients yet. Add some!") 
        : _recipe.IngredientsList;

    public string Watermark => 
        """
        Add ingredients here, one per line.
        You can specify their
        - quantity, e.g., "1 cup sugar",
        - preparation, e.g., "1 cup sugar, sifted",
        - brand, e.g., "1 cup sugar, sifted (Domino)",
        """;

    public void Confirm() => OnPropertyChanged(nameof(Text));
}

internal static class IngredientParsingExtensions
{
    public static bool IsUnit(this string text) => char.IsDigit(text[0]);
}