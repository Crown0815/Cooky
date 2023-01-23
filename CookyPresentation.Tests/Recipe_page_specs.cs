using System.ComponentModel;
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

    public class A_recipe_when_the_ingredients_text_changes
    {
        private const string TrimmedIngredientsText = """
                                   Carrot
                                   Meat
                                   """;

        private const string IngredientsWithBlankLines = """

                                   Carrot

                                   Meat

                                   """;

        private const string IngredientsWithTrailingWhitespace = """
                                      Carrot   
                                      Meat   
                                   """;

        private static IEnumerable<string> IngredientsFrom(params string[] ingredients)
        {
            return ingredients;
        }

        [Theory]
        [InlineData("extracting one ingredient from each line in", TrimmedIngredientsText)]
        [InlineData("ignoring blank lines in", IngredientsWithBlankLines)]
        [InlineData("removing trailing whitespace from", IngredientsWithTrailingWhitespace)]
        public void parses_ingredients(string by, string text)
        {
            Recipe.IngredientsText = text;

            Recipe.Ingredients.Should().BeEquivalentTo(
                IngredientsFrom("Carrot", "Meat"), 
                "the recipe should be {0} {1}", by, nameof(text));
        }

        [Theory]
        [InlineData(TrimmedIngredientsText)]
        [InlineData(IngredientsWithBlankLines)]
        [InlineData(IngredientsWithTrailingWhitespace)]
        public void trims_whitespace_and_empty_lines_from(string text)
        {
            Recipe.IngredientsText = text;
            Recipe.IngredientsText.Should().Be(TrimmedIngredientsText);;
        }

        [Theory]
        [InlineData(nameof(RecipePage.IngredientsText))]
        [InlineData(nameof(RecipePage.Ingredients))]
        public void raises_property_changed_for(string property)
        {
            using var monitoredSubject = Recipe.Monitor();
            Recipe.IngredientsText = "changed ingredients";

            monitoredSubject.Should().Raise(nameof(INotifyPropertyChanged.PropertyChanged))
                .WithArgs<PropertyChangedEventArgs>(x => x.PropertyName == property);
        }
    }
}