using CookyPresentation.ViewModel;

namespace Cooky.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class RecipePage
{
    public string ItemId
    {
        set => BindingContext = RecipeEditor.Load(value);
    }

    public RecipePage()
    {
        InitializeComponent();
        BindingContext = RecipeEditor.New();
    }
}