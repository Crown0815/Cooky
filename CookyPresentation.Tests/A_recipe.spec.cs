using CookyPresentation.ViewModel;
using FluentAssertions;
using Xunit;
using static CookyPresentation.Tests.Example;

namespace CookyPresentation.Tests;

public class A_recipe
{
    private static readonly RecipePage Recipe = RecipePage.New();

    [Fact]
    public void when_its_title_is_changed_has_the_given_title()
    {
        Recipe.Title = GivenTitle;
        Recipe.Title.Should().Be(GivenTitle);
    }

    [Fact]
    public void when_its_instructions_are_changed_has_the_given_instructions()
    {
        Recipe.Instructions = Instructions;
        Recipe.Instructions.Should().Be(Instructions);
    }

    [Fact]
    public void when_its_instructions_are_changed_trims_trailing_blank_lines()
    {
        Recipe.Instructions = GivenTextWithSurroundingBlankLines;
        Recipe.Instructions.Should().Be(Instructions);
    }

    public class when_its_ingredients_are_changed
    {
        private readonly IngredientsEditor _ingredients = Recipe.Ingredients;

        [Theory]
        [MemberData(nameof(IngredientNamesOnly), MemberType = typeof(Example))]
        public void parses_ingredient_names_from(string text)
        {
            _ingredients.Text = text;

            _ingredients.List.Select(x => x.Name).Should().BeEquivalentTo(
                "Carrot", "Meat");
        }

        [Theory]
        [InlineData(IngredientsWithPreparation)]
        [InlineData(IngredientsWithQuantityAndPreparation)]
        [InlineData(IngredientsWithPreparationAndTrailingWhitespaces)]
        public void parses_ingredient_preparation_separated_by_comma(string text)
        {
            _ingredients.Text = text;

            _ingredients.List.Select(x => x.Preparation)
                .Should().BeEquivalentTo("chopped", "cut into 1 inch dice");
        }

        [Theory]
        [InlineData(IngredientsWithQuantity)]
        [InlineData(IngredientsWithQuantityAndPreparation)]
        public void parses_ingredient_state_separated_by_comma(string text)
        {
            _ingredients.Text = text;

            _ingredients.List.Select(x => x.Quantity)
                .Should().BeEquivalentTo("5", "500g");
        }

        [Theory]
        [MemberData(nameof(IngredientNamesOnly), MemberType = typeof(Example))]
        public void and_confirmed_has_text_with_whitespace_and_empty_lines_trimmed_from(string text)
        {
            _ingredients.Text = text;
            _ingredients.Confirm();
            _ingredients.Text.Should().Be(TrimmedIngredientsText);
        }

        [Fact]
        public void raises_property_changed_for_ingredients_list()
        {
            using var monitoredSubject = _ingredients.Monitor();
            _ingredients.Text = "changed ingredients";

            monitoredSubject.Should().RaisePropertyChangeFor(x => x.List);
        }

        [Fact]
        public void raises_property_changed_for_ingredients_text_if_changes_are_confirmed()
        {
            using var monitoredSubject = _ingredients.Monitor();
            _ingredients.Text = "changed ingredients";
            _ingredients.Confirm();

            monitoredSubject.Should().RaisePropertyChangeFor(x => x.Text);
        }
    }
}
