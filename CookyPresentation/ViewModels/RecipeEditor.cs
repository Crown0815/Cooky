using CookyPresentation.Model;

namespace CookyPresentation.ViewModels;

public class RecipeEditor : ViewModelBase, IEditor
{
    private readonly Recipe _recipe;
    private readonly IEditor _inner;

    public RecipeEditor(Recipe recipe, IEditor inner)
    {
        _recipe = recipe;
        _inner = inner;
        Ingredients = new IngredientsEditor(_recipe);
    }

    public static RecipeEditor Load(string id)
    {
        return new RecipeEditor(RecipePersistence.Load(id), null);
    }

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

    public IngredientsEditor Ingredients { get; }

    public Task Save()
    {
        return RecipePersistence.Save(_recipe);
    }

    public async Task Delete()
    {
        await RecipePersistence.Delete(_recipe);
        await _inner.Delete();
    }
}