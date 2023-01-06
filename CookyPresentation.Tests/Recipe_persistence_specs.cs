using CookyPresentation.ViewModel;
using FluentAssertions;
using Xunit;

namespace CookyPresentation.Tests;

public class Recipe_persistence_specs
{
    private static readonly Recipe Recipe = Recipe.New();

    private static Recipe SavedAndLoaded(Recipe recipe)
    {
        recipe.SaveCommand.Execute(recipe);
        var rLoaded = Recipe.Load(recipe.Filename);
        return rLoaded;
    }

    [Fact]
    public void A_recipe_when_saved_and_loaded_preserves_its_given_title()
    {
        Recipe.Title = Example.GivenTitle;
        SavedAndLoaded(Recipe).Title.Should().Be(Example.GivenTitle);
    }

    [Fact]
    public void A_recipe_when_saved_and_loaded_preserves_its_given_text()
    {
        Recipe.Text = Example.GivenText;
        SavedAndLoaded(Recipe).Text.Should().Be(Example.GivenText);
    }
}