namespace CookyPresentation.ViewModels;

public class MainWindow : ViewModelBase, IAppWrapper
{

    public MainWindow()
    {
        Application.Initialize(this);
    }
    private static readonly RecipesOverview RecipesOverview = new();
    public string Greeting => "Welcome to Avalonia!";
    public ViewModelBase? CurrentViewModel { get; set; } = RecipesOverview;
    
    public Task GoBack()
    {
        CurrentViewModel = RecipesOverview;
        return Task.CompletedTask;
    }

    public string AppDataDirectory => "";
    public Task Open(RecipeEditor? recipe)
    {
        CurrentViewModel = recipe;
        return Task.CompletedTask;
    }
}