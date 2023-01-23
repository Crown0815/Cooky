using CommunityToolkit.Mvvm.ComponentModel;

namespace CookyPresentation.ViewModel;

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
            List = value.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
            OnPropertyChanged(nameof(List));
        }
    }

    public IReadOnlyCollection<string> List { get; private set; } = Array.Empty<string>();

    public void Complete()
    {
        _recipe.Ingredients = string.Join(Environment.NewLine, List);
        OnPropertyChanged(nameof(Text));
    }
}