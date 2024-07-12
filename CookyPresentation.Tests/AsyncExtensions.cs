namespace CookyPresentation.Tests;

public static class AsyncExtensions
{
    public static void Await(this Task task) => task.GetAwaiter().GetResult();
    public static T Await<T>(this Task<T> task) => task.GetAwaiter().GetResult();
}