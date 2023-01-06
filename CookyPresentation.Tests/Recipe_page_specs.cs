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
    public void A_recipe_when_its_text_is_changed_has_the_given_text()
    {
        Recipe.Text = GivenText;
        Recipe.Text.Should().Be(GivenText);
    }
    
    [Fact]
    public void A_recipe_when_its_text_is_changed_to_text_with_surrounding_blank_lines_has_the_trimmed_text()
    {
        Recipe.Text = GivenTextWithSurroundingBlankLines;
        Recipe.Text.Should().Be(GivenText);
    }
}