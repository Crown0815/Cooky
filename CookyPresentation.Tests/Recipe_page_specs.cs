using CookyPresentation.ViewModel;
using FluentAssertions;
using Xunit;
using static CookyPresentation.Tests.Example;

namespace CookyPresentation.Tests;

public class Recipe_page_specs
{
    private static readonly RecipePage Recipe = RecipePage.New();

    [Fact]
    public void A_recipe_when_its_title_is_changed_has_the_given_title()
    {
        Recipe.Title = GivenTitle;
        Recipe.Title.Should().Be(GivenTitle);
    }
    
    [Fact]
    public void A_recipe_when_its_instructions_are_changed_has_the_given_instructions()
    {
        Recipe.Instructions = Instructions;
        Recipe.Instructions.Should().Be(Instructions);
    }
    
    [Fact]
    public void A_recipe_when_its_instructions_are_changed_trims_trailing_blank_lines()
    {
        Recipe.Instructions = GivenTextWithSurroundingBlankLines;
        Recipe.Instructions.Should().Be(Instructions);
    }
}