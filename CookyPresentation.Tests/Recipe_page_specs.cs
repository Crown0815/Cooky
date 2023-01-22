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

    public class A_recipe_when_its_ingredients_text_changes
    {
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

    public class A_recipe_parses_ingredients_when_the_ingredients_text_changes_by
    {
        private const string IngredientsText = """
                                   Carrot
                                   Meat
                                   """;

        private static IEnumerable<string> IngredientsFrom(params string[] ingredients)
        {
            return ingredients;
        }

        [Fact]
        public void treating_each_line_as_an_ingredient()
        {
            IngredientsShouldBeParsedFrom(IngredientsText);
        }

        [Fact]
        public void ignoring_blank_lines()
        {
            IngredientsShouldBeParsedFrom("""

                                   Carrot

                                   Meat

                                   """);
        }

        [Fact]
        public void ignoring_trailing_whitespace_in_each_ingredient_line()
        {
            IngredientsShouldBeParsedFrom("""
                                      Carrot   
                                      Meat   
                                   """);
        }

        private static void IngredientsShouldBeParsedFrom(string text)
        {
            Recipe.IngredientsText = text;

            Recipe.IngredientsText.Should().Be(IngredientsText);
            Recipe.Ingredients.Should().BeEquivalentTo(IngredientsFrom("Carrot", "Meat"));
        }
    }
}