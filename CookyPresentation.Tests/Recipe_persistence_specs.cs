using CookyPresentation.ViewModel;
using FluentAssertions;
using Xunit;

namespace CookyPresentation.Tests;

public class Recipe_persistence_specs
{
    [Fact]
    public void A_recipe_when_saved_and_loaded_preserves_its_given_title()
    {
        var r = Recipe.New();
        r.Title = Example.GivenTitle;
        
        r.SaveCommand.Execute(r);
        var rLoaded = Recipe.Load(r.Filename);

        rLoaded.Title.Should().Be(Example.GivenTitle);
    }
    
    [Fact]
    public void A_recipe_when_saved_and_loaded_preserves_its_given_text()
    {
        var r = Recipe.New();
        r.Text = Example.GivenText;
        
        r.SaveCommand.Execute(r);
        var rLoaded = Recipe.Load(r.Filename);

        rLoaded.Text.Should().Be(Example.GivenText);
    }
}