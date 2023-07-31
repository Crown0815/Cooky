using CookyPresentation.ViewModel;
using Moq;
using Xunit;
using static Moq.Times;

namespace CookyPresentation.Tests;

[Collection(nameof(Recipe_commands_specs))]
public class Recipe_commands_specs
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

    [Collection(nameof(Recipe_commands_specs))]
    public class The_application_is_brought_back_to_its_previous_page_after_executing_the
    {
        private readonly Mock<IAppWrapper> _appSpy = new();

        public The_application_is_brought_back_to_its_previous_page_after_executing_the()
        {
            Application.Initialize(_appSpy.Object);
        }

        private void Verify() => _appSpy.Verify(x => x.GoBack(), Once);

        [Fact]
        public void save_command()
        {
            RecipeCommands.SaveCommand.Execute(Mock.Of<IEditor>());
            Verify();
        }

        [Fact]
        public void delete_command()
        {
            RecipeCommands.DeleteCommand.Execute(Mock.Of<IEditor>());
            Verify();
        }
    }
}
