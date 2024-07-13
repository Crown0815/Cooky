using CookyPresentation.ViewModels;

namespace CookyAvaloniaApp.DesignPreviews;

public class EmptyListPreview : ViewModelBase, IEmptyList
{
    public string Message { get; } = "Nothing here";
}