using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CookyAvaloniaApp.Views;
using CookyPresentation.ViewModels;

namespace CookyAvaloniaApp;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data) => data switch
    {
        null => null,
        RecipeItem => Create<RecipeItemView>(data),
        RecipesOverview => Create<RecipesOverviewView>(data),
        RecipeEditor=> Create<RecipesEditorView>(data),
        IngredientsEditor=> Create<IngredientsEditorView>(data),
        _ => new TextBlock { Text = "Not Found: " + data.GetType() }
    };

    private static Control Create<T>(object data) where T : Control, new() => new T { DataContext = data };

    public bool Match(object? data) => data is ViewModelBase;
}