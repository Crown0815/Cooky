using RecipePageModel = CookyPresentation.ViewModel.RecipePage;

namespace Cooky.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class RecipePage
{
    public string ItemId
    {
        set => BindingContext = RecipePageModel.Load(value);
    }

    public RecipePage()
    {
        InitializeComponent();
        BindingContext = RecipePageModel.New();
    }
}