using CommunityToolkit.Mvvm.ComponentModel;

namespace CookyPresentation.ViewModels;

public partial class MainWindow : ViewModelBase, IAppWrapper
{
    private readonly RecipesOverview _recipesOverview = new();
    [ObservableProperty] 
    private ViewModelBase? _currentViewModel;
    public MainWindow()
    {
        CurrentViewModel = _recipesOverview;
        Application.Initialize(this);
    }
    
    public string AppDataDirectory => "";
    public string Greeting => "Welcome to Avalonia!";

    public Task Open(RecipeEditor? recipe)
    {
        CurrentViewModel = recipe;
        return Task.CompletedTask;
    }
    
    public Task GoBack()
    {
        CurrentViewModel = _recipesOverview;
        return Task.CompletedTask;
    }
}