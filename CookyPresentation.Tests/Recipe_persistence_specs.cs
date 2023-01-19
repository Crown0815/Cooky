using CookyPresentation.ViewModel;
using FluentAssertions;
using Xunit;

namespace CookyPresentation.Tests;

public class Recipe_persistence_specs
{
    private readonly RecipePage _recipe = RecipePage.New();

    private static RecipePage SavedAndLoaded(RecipePage recipe)
    {
        Save(recipe);
        return Load(recipe);
    }

    private static void Save(RecipePage recipe) => 
        recipe.Save().GetAwaiter().GetResult();

    private static RecipePage Load(RecipePage recipe) => 
        RecipePage.Load(recipe.Filename);

    private static void Delete(RecipePage recipe) =>
        recipe.Delete();

    [Fact]
    public void A_recipe_when_saved_and_loaded_preserves_its_given_title()
    {
        _recipe.Title = Example.GivenTitle;
        SavedAndLoaded(_recipe).Title.Should().Be(Example.GivenTitle);
    }

    [Fact]
    public void A_recipe_when_saved_and_loaded_preserves_its_given_instructions()
    {
        _recipe.Instructions = Example.Instructions;
        SavedAndLoaded(_recipe).Instructions.Should().Be(Example.Instructions);
    }

    [Fact]
    public void A_recipe_when_saved_and_deleted_cannot_be_loaded()
    {
        Save(_recipe);
        Delete(_recipe);
        
        FluentActions.Invoking(() => RecipePage.Load(_recipe.Filename))
            .Should().Throw<RecipeNotFoundException>()
            .WithMessage($"*'{_recipe.Filename}' was not found*");
    }
}