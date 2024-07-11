using CookyPresentation.ViewModel;

namespace CookyAvaloniaApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    public AvailableRecipes Recipes { get; } = new();
}