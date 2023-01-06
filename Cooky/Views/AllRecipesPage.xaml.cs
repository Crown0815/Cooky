using Cooky.Models;
using RecipePageModel = CookyPresentation.ViewModel.RecipePage;

namespace Cooky.Views;

public partial class AllRecipesPage
{
    private AllRecipes AllRecipes => (AllRecipes)BindingContext;
    
    public AllRecipesPage()
    {
        InitializeComponent();
        BindingContext = new AllRecipes();
    }
    
    protected override void OnAppearing() => AllRecipes.LoadRecipes();

    private void SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection is [RecipePageModel recipe, ..]) NavigateTo(recipe);
    }

    private void NavigateTo(RecipePageModel recipe)
    {
        AllRecipes.OpenCommand.Execute(recipe);
        ClearSelection();
    }

    private void ClearSelection() => RecipesCollection.SelectedItem = null;
}