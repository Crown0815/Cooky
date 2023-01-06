namespace CookyPresentation.Tests;

internal static class Example
{
    public const string GivenTitle = "new title";

    public const string GivenText = """
                                     Some text with a
                                     linebreak
                                     """;

    public const string GivenTextWithSurroundingBlankLines = $"""

                                     {GivenText}

                                     """;
}