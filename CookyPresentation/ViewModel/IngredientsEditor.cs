using CommunityToolkit.Mvvm.ComponentModel;
using CookyPresentation.Model;

namespace CookyPresentation.ViewModel;


public record Ingredient(string Name, string Preparation, string Quantity = "");

public class IngredientsEditor : ObservableObject
{
    private readonly Recipe _recipe;

    internal IngredientsEditor(Recipe recipe)
    {
        _recipe = recipe;
    }

    public string Text
    {
        get => _recipe.Ingredients;
        set
        {
            _recipe.SetIngredients(value);
            OnPropertyChanged(nameof(List));
        }
    }

    public IReadOnlyCollection<Ingredient> List => _recipe.IngredientsList;

    public void Confirm()
    {
        OnPropertyChanged(nameof(Text));
    }
}

internal static class IngredientParsingExtensions
{
    public static bool IsUnit(this string text) => char.IsDigit(text[0]);
}
