namespace CookyPresentation.ViewModels;

public class RecipeNotFoundException(string id) : Exception(MessageContaining(id))
{
    private static string MessageContaining(string id) => 
        $"A recipe with id '{id}' was not found.";
}