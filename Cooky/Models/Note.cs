using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Cooky.Models;

internal class Note
{
    private Note(string filename)
    {
        Filename = filename;
        Load();
    }

    public string Filename { get; }
    public string Placeholder => "Enter your note";
    public string Text { get; set; }
    public DateTime Date { get; set; }
    
    public string SaveLabel => "Save";
    public ICommand SaveCommand { get; } = new AsyncRelayCommand<Note>(Save);
    
    public string DeleteLabel => "Delete";
    public ICommand DeleteCommand { get; } = new AsyncRelayCommand<Note>(Delete);

    public static Note New()
    {
        var appDataPath = FileSystem.AppDataDirectory;
        var randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        var filename = Path.Combine(appDataPath, randomFileName);
        
        return Load(filename);
    }

    private static async Task Save(Note note)
    {
        await File.WriteAllTextAsync(note.Filename, note.Text);
        await GoBackAsync();
    }
    
    private static Task GoBackAsync() => Shell.Current.GoToAsync("..");

    private static Task Delete(Note note)
    {
        Delete(note.Filename);
        return GoBackAsync();
    }

    private static void Delete(string fileName)
    {
        if (File.Exists(fileName))
            File.Delete(fileName);
    }

    public static Note Load(string fileName) => new(fileName);

    private void Load()
    {
        if (!File.Exists(Filename)) return;
        
        Date = File.GetCreationTime(Filename);
        Text = File.ReadAllText(Filename);
    }
}