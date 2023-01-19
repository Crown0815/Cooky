using CookyPresentation.ViewModel;
using FluentAssertions;
using Xunit;

namespace CookyPresentation.Tests;

public class Recipe_persistence_specs
{
    private static readonly RecipePage Recipe = RecipePage.New();

    private static RecipePage SavedAndLoaded(RecipePage recipe)
    {
        Save(recipe);
        return Load(recipe);
    }

    private static void Save(RecipePage recipe) => 
        RecipeCommands.SaveCommand.Execute(recipe);

    private static RecipePage Load(RecipePage recipe) => 
        RecipePage.Load(recipe.Filename);

    private static void Delete(RecipePage recipe) =>
        RecipeCommands.DeleteCommand.Execute(recipe);

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

    [Fact]
    public void A_recipe_when_saved_and_deleted_cannot_be_loaded()
    {
        Save(Recipe);
        Delete(Recipe);
        
        FluentActions.Invoking(() => RecipePage.Load(Recipe.Filename))
            .Should().Throw<RecipeNotFoundException>()
            .WithMessage($"*'{Recipe.Filename}' was not found*");
    }
}