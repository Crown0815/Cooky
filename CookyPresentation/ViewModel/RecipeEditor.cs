using CommunityToolkit.Mvvm.ComponentModel;
using CookyPresentation.Model;

namespace CookyPresentation.ViewModel;

public class RecipeEditor : ObservableObject, IEditor
{
    private readonly Recipe _recipe;

    private RecipeEditor(Recipe recipe)
    {
        _recipe = recipe;
        Ingredients = new IngredientsEditor(_recipe);
    }

    public static RecipeEditor New()
    {
        return new RecipeEditor(RecipePersistence.New());
    }

    public static RecipeEditor Load(string id)
    {
        return new RecipeEditor(RecipePersistence.Load(id));
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

    public Task Save() => RecipePersistence.Save(_recipe);

    public void Delete() => RecipePersistence.Delete(_recipe);
}
