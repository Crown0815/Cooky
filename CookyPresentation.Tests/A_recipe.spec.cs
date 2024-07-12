using CookyPresentation.ViewModels;
using FluentAssertions;
using Xunit;
using static CookyPresentation.Tests.Example;

namespace CookyPresentation.Tests;

public class An_open_recipe
{
    private readonly RecipeEditor _recipe = new MainWindow().OpenNewRecipe().Await();

    [Fact]
    public void by_default_has_the_title_new_recipe()
    {
        _recipe.Title.Should().Be("New Recipe");
    }

    [Fact]
    public void by_default_has_no_ingredients()
    {
        _recipe.Ingredients.Text.Should().BeEmpty();
        _recipe.Ingredients.List.Should().BeNull();
    }

    [Fact]
    public void when_its_title_is_changed_has_the_given_title()
    {
        _recipe.Title = GivenTitle;
        _recipe.Title.Should().Be(GivenTitle);
    }

    [Fact]
    public void when_its_instructions_are_changed_has_the_given_instructions()
    {
        _recipe.Instructions = Instructions;
        _recipe.Instructions.Should().Be(Instructions);
    }

    [Fact]
    public void when_its_instructions_are_changed_trims_trailing_blank_lines()
    {
        _recipe.Instructions = GivenTextWithSurroundingBlankLines;
        _recipe.Instructions.Should().Be(Instructions);
    }

    public class When_its_ingredients_are_set_to_a_new_line_separated_list_of
    {
        private readonly IngredientsEditor _ingredients = new An_open_recipe()._recipe.Ingredients;

        [Theory]
        [MemberData(nameof(IngredientNamesOnly), MemberType = typeof(Example))]
        public void names_extracts_name_only_ingredients(string text)
        {
            _ingredients.Text = text;

            _ingredients.List!.Select(x => x.Name).Should().Equal("Carrot", "Meat");
        }

        [Theory]
        [InlineData(IngredientsWithPreparation)]
        [InlineData(IngredientsWithQuantityAndPreparation)]
        [InlineData(IngredientsWithPreparationAndTrailingWhitespaces)]
        public void names_with_comma_separated_preparation_steps_extracts_preparation_steps(string text)
        {
            _ingredients.Text = text;

            _ingredients.List!.Select(x => x.Preparation).Should().Equal("chopped", "cut into 1 inch dice");
        }

        [Theory]
        [InlineData(IngredientsWithQuantity)]
        [InlineData(IngredientsWithQuantityAndPreparation)]
        public void quantities_and_names_extracts_ingredients_with_quantities(string text)
        {
            _ingredients.Text = text;

            _ingredients.List!.Select(x => x.Quantity).Should().Equal("5", "500g");
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