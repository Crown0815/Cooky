using CookyPresentation.ViewModels;
using FluentAssertions;
using Xunit;

namespace CookyPresentation.Tests;

public class A_main_window
{
    [Fact]
    public void by_default_shows_an_overview_of_all_recipes()
    {
        var subject = new MainWindow();
        subject.CurrentViewModel.Should().BeOfType<RecipesOverview>();
    }
}