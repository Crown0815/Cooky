using Cooky.Models;

namespace Cooky.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class RecipePage
{
    public string ItemId
    {
        set => BindingContext = Recipe.Load(value);
    }

    public RecipePage()
    {
        InitializeComponent();
        BindingContext = Recipe.New();
    }
}