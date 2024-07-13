using System.Collections;

namespace CookyPresentation.ViewModels;

public class EmptyList<T>(string? message = null) : ViewModelBase, IReadOnlyList<T>, IEmptyList
{
    public string Message => message ?? "Nothing here";
    public IEnumerator<T> GetEnumerator() => (IEnumerator<T>)Array.Empty<T>().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public int Count => 0;
    public T this[int index] => throw new IndexOutOfRangeException();
}

public interface IEmptyList
{
    string Message { get; }
}