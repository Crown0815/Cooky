using CookyPresentation.Model;

namespace CookyPresentation.ViewModels;

public class IngredientsEditor : ViewModelBase
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

    public IReadOnlyCollection<Ingredient>? List => _recipe.IngredientsList.Count != 0 ? _recipe.IngredientsList : null;

    public void Confirm() => OnPropertyChanged(nameof(Text));
}

internal static class IngredientParsingExtensions
{
    public static bool IsUnit(this string text) => char.IsDigit(text[0]);
}