using Cooky.Models;

namespace Cooky.Views;

public partial class AllNotesPage
{
    private AllNotes AllNotes => (AllNotes)BindingContext;
    
    public AllNotesPage()
    {
        InitializeComponent();
        BindingContext = new AllNotes();
    }
    
    protected override void OnAppearing() => AllNotes.LoadNotes();

    private void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection is [Note note, ..]) NavigateTo(note);
    }

    private void NavigateTo(Note note)
    {
        AllNotes.OpenNote.Execute(note);
        ClearSelection();
    }

    private void ClearSelection() => NotesCollection.SelectedItem = null;
}