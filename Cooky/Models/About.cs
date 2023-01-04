using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Cooky.Models;

internal class About
{
    private const string MoreInfoUrl = "https://aka.ms/maui";
    
    public string Title => AppInfo.Name;
    public string Version => AppInfo.VersionString;
    public string Message => "This app is written in XAML and C# with .NET MAUI.";
    public string LearnMoreLabel => "Learn more...";
    
    public ICommand LearnMore { get; } = new AsyncRelayCommand(OpenLearnMoreUrl);

    private static Task OpenLearnMoreUrl() => Launcher.Default.OpenAsync(MoreInfoUrl);
}