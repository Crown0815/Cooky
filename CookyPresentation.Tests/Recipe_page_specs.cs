using CookyPresentation.ViewModel;
using FluentAssertions;
using Xunit;

namespace CookyPresentation.Tests;

public class Recipe_page_specs
{
    private const string GivenTitle = "new title";

    private const string GivenText = """
                                     Some text with a
                                     linebreak
                                     """;

    private const string GivenTextWithSurroundingBlankLines = $"""

                                     {GivenText}

                                     """;

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
    
    [Fact]
    public void A_recipe_when_saved_and_loaded_preserves_its_given_title()
    {
        var r = Recipe.New();
        r.Title = GivenTitle;
        
        r.SaveCommand.Execute(r);
        var rLoaded = Recipe.Load(r.Filename);

        rLoaded.Title.Should().Be(GivenTitle);
    }
    
    [Fact]
    public void A_recipe_when_saved_and_loaded_preserves_its_given_text()
    {
        var r = Recipe.New();
        r.Text = GivenText;
        
        r.SaveCommand.Execute(r);
        var rLoaded = Recipe.Load(r.Filename);

        rLoaded.Text.Should().Be(GivenText);
    }
}