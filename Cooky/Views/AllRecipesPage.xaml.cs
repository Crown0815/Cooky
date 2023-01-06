using Cooky.Models;

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
        if (e.CurrentSelection is [Recipe note, ..]) NavigateTo(note);
    }

    private void NavigateTo(Recipe recipe)
    {
        AllRecipes.OpenCommand.Execute(recipe);
        ClearSelection();
    }

    private void ClearSelection() => RecipesCollection.SelectedItem = null;
}