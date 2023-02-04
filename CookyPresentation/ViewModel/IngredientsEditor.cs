using CommunityToolkit.Mvvm.ComponentModel;

namespace CookyPresentation.ViewModel;


public record Ingredient(string Name, string Preparation);

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
            _recipe.Ingredients = value;
            List = LinesFrom(value).Select(x => new Ingredient(x, "")).ToList();
            OnPropertyChanged(nameof(List));
        }
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