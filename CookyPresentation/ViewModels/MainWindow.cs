namespace CookyPresentation.ViewModels;

public class MainWindow : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    public ViewModelBase? CurrentViewModel { get; set; } = new RecipesOverview();
}