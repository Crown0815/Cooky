using CookyPresentation.ViewModel;
using FluentAssertions;
using Xunit;

namespace CookyPresentation.Tests;

public class Recipe_persistence_specs
{
    private static readonly RecipePage Recipe = RecipePage.New();

    private static RecipePage SavedAndLoaded(RecipePage recipe)
    {
        RecipeCommands.SaveCommand.Execute(recipe);
        return RecipePage.Load(recipe.Filename);
    }

    [Fact]
    public void A_recipe_when_saved_and_loaded_preserves_its_given_title()
    {
        Recipe.Title = Example.GivenTitle;
        SavedAndLoaded(Recipe).Title.Should().Be(Example.GivenTitle);
    }

    [Fact]
    public void A_recipe_when_saved_and_loaded_preserves_its_given_instructions()
    {
        Recipe.Instructions = Example.Instructions;
        SavedAndLoaded(Recipe).Instructions.Should().Be(Example.Instructions);
    }
}