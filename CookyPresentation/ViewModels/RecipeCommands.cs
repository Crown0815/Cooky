using CommunityToolkit.Mvvm.Input;
using static CookyPresentation.Application;

namespace CookyPresentation.ViewModels;

public static class RecipeCommands
{
    public static AsyncRelayCommand<IEditor> SaveCommand { get; } = new(Save!);
    public static AsyncRelayCommand<IEditor> DeleteCommand { get; } = new(Delete!);
    public static AsyncRelayCommand<IOpen> OpenCommand { get; } = new(Open!);
    public static AsyncRelayCommand<ICreator> CreateItemCommand { get; } = new(Create!);

    private static Task Create(ICreator creator) => creator.CreateItem();

    private static async Task Save(IEditor editor)
    {
        await editor.Save();
        await GoBack();
    }

    private static async Task Delete(IEditor editor)
    {
        await editor.Delete();
        await GoBack();
    }

    private static Task Open(IOpen open)
    {
        return open.Open();
    }
}