namespace CookyPresentation.Tests;

public static class AsyncExtensions
{
    public static void Await(this Task task) => task.GetAwaiter().GetResult();
}