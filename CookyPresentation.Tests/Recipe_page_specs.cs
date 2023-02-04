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

    public class A_recipe_s_ingredients_when_ingredient_text
    {
        private readonly IngredientsEditor _ingredients = Recipe.Ingredients;

        private static IEnumerable<string> IngredientsFrom(params string[] ingredients)
        {
            return ingredients;
        }

        [Theory]
        [InlineData("extracting one ingredient from each line in", TrimmedIngredientsText)]
        [InlineData("ignoring blank lines and trailing whitespace in", IngredientsWithBlankLinesAndTrailingWhitespace)]
        public void parses_ingredients(string by, string text)
        {
            _ingredients.Text = text;

            _ingredients.List.Should().BeEquivalentTo(
                IngredientsFrom("Carrot", "Meat"), 
                "the recipe should be {0} {1}", by, nameof(text));
        }

        [Fact]
        public void changes_raises_property_changed_for_ingredients_list()
        {
            using var monitoredSubject = _ingredients.Monitor();
            _ingredients.Text = "changed ingredients";

            monitoredSubject.Should().RaisePropertyChangeFor(x => x.List);
        }

        [Theory]
        [InlineData(TrimmedIngredientsText)]
        [InlineData(IngredientsWithBlankLinesAndTrailingWhitespace)]
        public void changes_are_completed_trims_whitespace_and_empty_lines_from(string text)
        {
            _ingredients.Text = text;
            _ingredients.Complete();
            _ingredients.Text.Should().Be(TrimmedIngredientsText);
        }

        [Fact]
        public void changes_are_completed_raises_property_changed_for_ingredients_text()
        {
            using var monitoredSubject = _ingredients.Monitor();
            _ingredients.Text = "changed ingredients";
            _ingredients.Complete();

            monitoredSubject.Should().RaisePropertyChangeFor(x => x.Text);
        }
    }
}