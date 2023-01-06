using CookyPresentation;
using Application = CookyPresentation.Application;

namespace Cooky;

public partial class App
{
    public App()
    {
        InitializeComponent();

        Application.Initialize(new MauiWrapper());
        MainPage = new AppShell();
    }
}

internal class MauiWrapper : IAppWrapper
{
    public Task GoBack() => Shell.Current.GoToAsync("..");

    public string AppDataDirectory => FileSystem.AppDataDirectory;
}