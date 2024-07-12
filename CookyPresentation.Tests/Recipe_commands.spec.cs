using CookyPresentation.ViewModels;
using Moq;
using Xunit;
using static Moq.Times;

namespace CookyPresentation.Tests;

[Collection(nameof(Recipe_commands))]
public class Recipe_commands
{
    private readonly Mock<IEditor> _recipeSpy = new();

    [Fact]
    public void The_save_command_when_executed_calls_save_on_given_recipe()
    {
        RecipeCommands.SaveCommand.Execute(_recipeSpy.Object);
        _recipeSpy.Verify(x => x.Save(), Once);
    }

    [Fact]
    public void The_delete_command_when_executed_calls_delete_on_given_recipe()
    {
        RecipeCommands.DeleteCommand.Execute(_recipeSpy.Object);
        _recipeSpy.Verify(x => x.Delete(), Once);
    }
}