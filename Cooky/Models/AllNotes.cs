using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Cooky.Views;

namespace Cooky.Models;

internal class AllNotes
{
    private static readonly string NotesPath = FileSystem.AppDataDirectory;
    public ObservableCollection<Note> Notes { get; } = new();
    public ICommand AddNote { get; } = new AsyncRelayCommand(CreateNewNote);

    private static Task CreateNewNote() => Shell.Current.GoToAsync(nameof(NotePage));

    public AllNotes() => LoadNotes();

    public void LoadNotes()
    {
        Notes.Clear();

        foreach (var note in NotesFrom(NotesPath))
            Notes.Add(note);
    }

    private static IEnumerable<Note> NotesFrom(string path) => 
        Directory
            .EnumerateFiles(path, "*.notes.txt")
            .Select(Note)
            .OrderBy(x => x.Date);

    private static Note Note(string filename) => new()
    {
        Filename = filename,
        Text = File.ReadAllText(filename),
        Date = File.GetCreationTime(filename)
    };

    public ICommand OpenNote { get; } = new AsyncRelayCommand<Note>(Open);

    private static Task Open(Note note) => 
        Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");
}