using CookyPresentation.ViewModel;
using FluentAssertions;
using Xunit;

namespace CookyPresentation.Tests;

public class A_recipe_when_saved
{
    private readonly RecipeEditor _recipe = RecipeEditor.New();

    private static RecipeEditor SavedAndLoaded(RecipeEditor recipe)
    {
        recipe.Save().GetAwaiter().GetResult();
        return RecipeEditor.Load(recipe.Filename);
    }

    [Fact]
    public void and_loaded_preserves_its_given_title()
    {
        _recipe.Title = Example.GivenTitle;
        SavedAndLoaded(_recipe).Title.Should().Be(Example.GivenTitle);
    }

    [Fact]
    public void and_loaded_preserves_its_given_instructions()
    {
        _recipe.Instructions = Example.Instructions;
        SavedAndLoaded(_recipe).Instructions.Should().Be(Example.Instructions);
    }

    [Fact]
    public void and_loaded_preserves_its_given_ingredients()
    {
        _recipe.Ingredients.Text = Example.TrimmedIngredientsText;
        SavedAndLoaded(_recipe).Ingredients.Text.Should().Be(Example.TrimmedIngredientsText);
    }

    [Fact]
    public void and_loaded_preserves_trims_given_ingredients_text()
    {
        _recipe.Ingredients.Text = Example.IngredientsWithBlankLinesAndTrailingWhitespace;
        SavedAndLoaded(_recipe).Ingredients.Text.Should().Be(Example.TrimmedIngredientsText);
    }

    [Fact]
    public async Task and_deleted_cannot_be_loaded()
    {
        await _recipe.Save();
        _recipe.Delete();

        FluentActions.Invoking(() => RecipeEditor.Load(_recipe.Filename))
            .Should().Throw<RecipeNotFoundException>()
            .WithMessage($"*'{_recipe.Filename}' was not found*");
    }
}
