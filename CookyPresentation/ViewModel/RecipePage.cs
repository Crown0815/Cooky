using CommunityToolkit.Mvvm.ComponentModel;
using static System.StringSplitOptions;

namespace CookyPresentation.ViewModel;

public class RecipePage : ObservableObject, IPersistable
{
    private readonly Recipe _recipe;

    private RecipePage(Recipe recipe)
    {
        _recipe = recipe;
    }

    public static RecipePage New() => new(RecipePersistence.New());

    public static RecipePage Load(string id) => new(RecipePersistence.Load(id));

    public RecipeLabels Labels { get; } = new();

    public string Filename => _recipe.Id;

    public string Instructions
    {
        get => _recipe.Instructions;
        set => _recipe.Instructions = value.Trim();
    }

    public DateTime Date => _recipe.Date;

    public string Title
    {
        get => _recipe.Title;
        set => _recipe.Title = value;
    }

    public IReadOnlyCollection<string> Ingredients { get; private set; } = new List<string>();

    public string IngredientsText
    {
        get => string.Join(Environment.NewLine, Ingredients);
        set
        {
            Ingredients = value.Split(Environment.NewLine, TrimEntries | RemoveEmptyEntries).ToList();
            OnPropertyChanged();
            OnPropertyChanged(nameof(Ingredients));
        }
    }

    public Task Save() => RecipePersistence.Save(_recipe);

    public void Delete() => RecipePersistence.Delete(_recipe);
}