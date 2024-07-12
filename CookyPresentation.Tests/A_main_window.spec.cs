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
        _subject.CurrentViewModel.Should().BeAssignableTo<RecipesOverview>();
    }

    [Fact]
    public async Task when_a_recipe_is_opened_then_it_switches_to_the_recipe_editor()
    {
        using var monitor = _subject.Monitor();
        var recipe = await _subject.NewRecipe();
        
        await recipe.Open();

        _subject.CurrentViewModel.Should().BeAssignableTo<RecipeEditor>();
        monitor.Should().RaisePropertyChangeFor(x => x.CurrentViewModel);
    }

    [Fact]
    public async Task when_a_recipe_is_deleted_then_it_is_no_longer_in_the_recipe_overview()
    {
        using var monitor = _subject.Monitor();
        await _subject.RecipeOverview().CreateItem();
        var recipe = _subject.RecipeOverview().Recipes.Single();
        
        await recipe.Delete();

        _subject.RecipeOverview().Recipes.Should().BeEmpty();
    }

    [Fact]
    public async Task when_an_open_recipe_is_deleted_then_it_switches_back_to_the_recipe_overview()
    {
        using var monitor = _subject.Monitor();
        var editor = await _subject.OpenNewRecipe();
        
        await editor.Delete();
        
        _subject.CurrentViewModel.Should().BeAssignableTo<RecipesOverview>();
        monitor.Should().RaisePropertyChangeFor(x => x.CurrentViewModel);
    }

    [Fact]
    public async Task when_an_open_recipe_is_deleted_then_that_recipe_is_no_longer_visible_in_the_recipe_overview()
    {
        using var monitor = _subject.Monitor();
        var editor = await _subject.OpenNewRecipe();
        
        await editor.Delete();

        _subject.RecipeOverview().Recipes.Should().BeEmpty();
    }
}