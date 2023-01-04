using Cooky.Models;

namespace Cooky.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage
{
    public string ItemId
    {
        set => BindingContext = Note.Load(value);
    }

    public NotePage()
    {
        InitializeComponent();
        BindingContext = Note.New();
    }
}