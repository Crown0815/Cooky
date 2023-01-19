namespace CookyPresentation.ViewModel;

public class RecipePage : IPersistable
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

    public Task Save() => RecipePersistence.Save(_recipe);

    public void Delete() => RecipePersistence.Delete(_recipe);
}