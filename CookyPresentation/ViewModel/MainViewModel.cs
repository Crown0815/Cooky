namespace CookyPresentation.ViewModel;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    public AvailableRecipes Recipes { get; } = new();
}