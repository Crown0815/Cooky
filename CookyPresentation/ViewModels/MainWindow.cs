using CommunityToolkit.Mvvm.ComponentModel;

namespace CookyPresentation.ViewModels;

public partial class MainWindow : ViewModelBase, IAppWrapper
{
    private readonly RecipesOverview _recipesOverview;
    [ObservableProperty] 
    private ViewModelBase? _currentViewModel;
    public MainWindow()
    {
        _recipesOverview = new RecipesOverview(this);
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