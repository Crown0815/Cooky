namespace CookyPresentation;

public interface IAppWrapper
{
    Task GoBack();
    string AppDataDirectory { get; }
}