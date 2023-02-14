using CommunityToolkit.Mvvm.ComponentModel;

namespace CookyPresentation.ViewModel;


public record Ingredient(string Name, string Preparation);

public class IngredientsEditor : ObservableObject
{
    private const char IngredientPreparationSeparator = ',';
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
            _recipe.Ingredients = value;
            List = LinesFrom(value).Select(AsIngredient).ToList();
            OnPropertyChanged(nameof(List));
        }
    }

    private static Ingredient AsIngredient(string line)
    {
        if (line.Contains(IngredientPreparationSeparator))
        {
            var pieces = line.Split(IngredientPreparationSeparator);
            return new Ingredient(pieces[0].Trim(), pieces[1].Trim());
        }

        return new Ingredient(line, "");
    }

    private static IEnumerable<string> LinesFrom(string value) => 
        value.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();

    public IReadOnlyCollection<Ingredient> List { get; private set; } = Array.Empty<Ingredient>();

    public void Complete()
    {
        _recipe.Ingredients = string.Join(Environment.NewLine, List.Select(x => x.Name));
        OnPropertyChanged(nameof(Text));
    }
}