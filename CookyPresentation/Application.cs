namespace CookyPresentation;

public static class Application
{
    private static IAppWrapper _app = new NoApp();
    
    public static Task GoBack() => _app.GoBack();

    public static string AppDataDirectory => _app.AppDataDirectory;

    public static void Initialize(IAppWrapper app) => _app = app;
}