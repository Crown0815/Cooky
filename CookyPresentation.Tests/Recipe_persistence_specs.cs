using CookyPresentation.ViewModel;
using FluentAssertions;
using Xunit;

namespace CookyPresentation.Tests;

public class Recipe_persistence_specs
{
    private readonly RecipePage _recipe = RecipePage.New();

    private static RecipePage SavedAndLoaded(RecipePage recipe)
    {
        recipe.Save().GetAwaiter().GetResult();
        return RecipePage.Load(recipe.Filename);
    }

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
    public void A_recipe_when_saved_and_loaded_preserves_its_given_ingredients()
    {
        _recipe.Ingredients.Text = Example.TrimmedIngredientsText;
        SavedAndLoaded(_recipe).Ingredients.Text.Should().Be(Example.TrimmedIngredientsText);
    }

    [Fact]
    public async Task A_recipe_when_saved_and_deleted_cannot_be_loaded()
    {
        await _recipe.Save();
        _recipe.Delete();
        
        FluentActions.Invoking(() => RecipePage.Load(_recipe.Filename))
            .Should().Throw<RecipeNotFoundException>()
            .WithMessage($"*'{_recipe.Filename}' was not found*");
    }
}