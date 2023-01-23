﻿using CommunityToolkit.Mvvm.ComponentModel;
using static System.StringSplitOptions;

namespace CookyPresentation.ViewModel;

public class RecipePage : ObservableObject, IPersistable
{
    private readonly Recipe _recipe;

    private RecipePage(Recipe recipe)
    {
        _recipe = recipe;
    }

    public static RecipePage New() => new(RecipePersistence.New());

    public static RecipePage Load(string id) => new(RecipePersistence.Load(id));

    public RecipeLabels Labels { get; } = new();

    public string Filename => _recipe.Id;

    public string Instructions
    {
        get => _recipe.Instructions;
        set => _recipe.Instructions = value.Trim();
    }

    public DateTime Date => _recipe.Date;

    public string Title
    {
        get => _recipe.Title;
        set => _recipe.Title = value;
    }

    public IngredientsEditor Ingredients { get; } = new();

    public Task Save() => RecipePersistence.Save(_recipe);

    public void Delete() => RecipePersistence.Delete(_recipe);
}

public class IngredientsEditor : ObservableObject
{
    private string _text = "";

    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            List = value.Split(Environment.NewLine, TrimEntries | RemoveEmptyEntries).ToList();
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