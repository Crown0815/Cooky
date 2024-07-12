using CommunityToolkit.Mvvm.ComponentModel;

namespace CookyPresentation.ViewModels;

public partial class MainWindow : ViewModelBase, IAppWrapper
{
    public MainWindow()
    {
        Application.Initialize(this);
    }
    
    private static readonly RecipesOverview RecipesOverview = new();
    public string Greeting => "Welcome to Avalonia!";
    
    [ObservableProperty]
    private ViewModelBase? _currentViewModel = RecipesOverview;
    
    public Task GoBack()
    {
        _currentViewModel = RecipesOverview;
        return Task.CompletedTask;
    }

    public string AppDataDirectory => "";
    public Task Open(RecipeEditor? recipe)
    {
        _currentViewModel = recipe;
        return Task.CompletedTask;
    }
}