using Cooky.Models;

namespace Cooky.Views;

public partial class AboutPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is About about) 
            await NavigateTo(about.MoreInfoUrl);
    }

    private static Task<bool> NavigateTo(string url) => Launcher.Default.OpenAsync(url);
}