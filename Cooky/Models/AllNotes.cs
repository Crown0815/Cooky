using System.Collections.ObjectModel;

namespace Cooky.Models;

internal class AllNotes
{
    private static readonly string NotesPath = FileSystem.AppDataDirectory;
    public ObservableCollection<Note> Notes { get; } = new();

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
}