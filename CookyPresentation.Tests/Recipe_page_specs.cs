using CookyPresentation.ViewModel;
using FluentAssertions;
using Xunit;

namespace CookyPresentation.Tests;

public class Recipe_page_specs
{
    [Fact]
    public void A_recipe_has_a_changeable_title()
    {
        var r = Recipe.New();
        r.Title = "new title";

        r.Title.Should().Be("new title");
    }
}