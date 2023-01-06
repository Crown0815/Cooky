using CookyPresentation.ViewModel;
using FluentAssertions;
using Xunit;
using static CookyPresentation.Tests.Example;

namespace CookyPresentation.Tests;

public class Recipe_page_specs
{
    [Fact]
    public void A_recipe_when_its_title_is_changed_has_the_given_title()
    {
        var r = Recipe.New();
        r.Title = GivenTitle;

        r.Title.Should().Be(GivenTitle);
    }
    
    [Fact]
    public void A_recipe_when_its_text_is_changed_has_the_given_text()
    {
        var r = Recipe.New();
        r.Text = GivenText;

        r.Text.Should().Be(GivenText);
    }
    
    [Fact]
    public void A_recipe_when_its_text_is_changed_to_text_with_surrounding_blank_lines_has_the_trimmed_text()
    {
        var r = Recipe.New();
        r.Text = GivenTextWithSurroundingBlankLines;

        r.Text.Should().Be(GivenText);
    }
}