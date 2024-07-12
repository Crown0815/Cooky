using CookyPresentation.ViewModels;
using FluentAssertions;
using Xunit;

namespace CookyPresentation.Tests;

public class A_main_window
{
    private readonly MainWindow _subject = new();

    [Fact]
    public void by_default_shows_an_overview_of_all_recipes()
    {
        _subject.CurrentViewModel.Should().BeOfType<RecipesOverview>();
    }

    [Fact]
    public async Task when_a_recipe_is_opened_then_it_switches_to_the_recipe_editor()
    {
        using var monitor = _subject.Monitor();
        
        var overview = (RecipesOverview)_subject.CurrentViewModel!;
        await overview.CreateItem();
        var recipe = overview.Recipes.Single();
        await recipe.Open();
        
        _subject.CurrentViewModel.Should().BeOfType<RecipeEditor>();
        monitor.Should().RaisePropertyChangeFor(x => x.CurrentViewModel);
    }
}