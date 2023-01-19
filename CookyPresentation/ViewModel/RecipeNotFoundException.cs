namespace CookyPresentation.ViewModel;

public class RecipeNotFoundException : Exception
{
    public RecipeNotFoundException(string id) : base(MessageContaining(id))
    {
    }

    private static string MessageContaining(string id) => 
        $"A recipe with id '{id}' was not found.";
}