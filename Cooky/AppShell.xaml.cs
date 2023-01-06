namespace Cooky;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.RecipePage), typeof(Views.RecipePage));
    }
}