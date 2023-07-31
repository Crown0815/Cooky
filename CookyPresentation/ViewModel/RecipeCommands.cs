using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using static CookyPresentation.Application;

namespace CookyPresentation.ViewModel;

public static class RecipeCommands
{
    public static ICommand SaveCommand { get; } = new AsyncRelayCommand<IEditor>(Save!);
    public static ICommand DeleteCommand { get; } = new AsyncRelayCommand<IEditor>(Delete!);

    private static async Task Save(IEditor editor)
    {
        await editor.Save();
        await GoBack();
    }

    private static Task Delete(IEditor editor)
    {
        editor.Delete();
        return GoBack();
    }
}
