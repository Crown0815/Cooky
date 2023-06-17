using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using static CookyPresentation.Application;

namespace CookyPresentation.ViewModel;

public static class RecipeCommands
{
    public static ICommand SaveCommand { get; } = new AsyncRelayCommand<IDocument>(Save!);
    public static ICommand DeleteCommand { get; } = new AsyncRelayCommand<IDocument>(Delete!);

    private static async Task Save(IDocument document)
    {
        await document.Save();
        await GoBack();
    }

    private static Task Delete(IDocument document)
    {
        document.Delete();
        return GoBack();
    }
}
