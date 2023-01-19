using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using static CookyPresentation.Application;

namespace CookyPresentation.ViewModel;

public static class RecipeCommands
{
    public static ICommand SaveCommand { get; } = new AsyncRelayCommand<IPersistable>(Save!);
    public static ICommand DeleteCommand { get; } = new AsyncRelayCommand<IPersistable>(Delete!);

    private static async Task Save(IPersistable persistable)
    {
        await persistable.Save();
        await GoBack();
    }

    private static Task Delete(IPersistable persistable)
    {
        persistable.Delete();
        return GoBack();
    }
}