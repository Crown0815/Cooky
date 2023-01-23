using CommunityToolkit.Mvvm.ComponentModel;

namespace CookyPresentation.ViewModel;

public class IngredientsEditor : ObservableObject
{
    private string _text = "";

    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            List = value.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
            OnPropertyChanged(nameof(List));
        }
    }

    public IReadOnlyCollection<string> List { get; private set; } = Array.Empty<string>();

    public void Complete()
    {
        _text = string.Join(Environment.NewLine, List);
        OnPropertyChanged(nameof(Text));
    }
}