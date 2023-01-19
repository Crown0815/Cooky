namespace CookyPresentation.ViewModel;

public interface IPersistable
{
    Task Save();
    void Delete();
}