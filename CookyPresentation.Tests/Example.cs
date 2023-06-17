using static System.Environment;

namespace CookyPresentation.Tests;

internal static class Example
{
    private static object[] Case(params object[] arguments) => arguments;

    public const string GivenTitle = "new title";

    public const string Instructions = """
                                    Some text with a
                                    linebreak
                                    """;

    public const string GivenTextWithSurroundingBlankLines = $"""

                                    {Instructions}

                                    """;

    private static readonly string[] Ingredients = { "Carrot", "Meat" };
    private static readonly string BlankLine = NewLine + NewLine;

    public static readonly string TrimmedIngredientsText = string.Join(NewLine, Ingredients);
    private static readonly string TrimmedIngredientsTextUnix = string.Join('\n', Ingredients);
    private static readonly string TrimmedIngredientsTextNonUnix = string.Join("\r\n", Ingredients);

    public static readonly string IngredientsWithBlankLinesAndTrailingWhitespace =
        string.Join(BlankLine, Ingredients.Select(WithTrailingWhitespace).Prepend("").Append(""));

    private static string WithTrailingWhitespace(string arg) => $"    {arg}    ";

    public static object[][] IngredientNamesOnly =
    {
        Case(TrimmedIngredientsText),
        Case(TrimmedIngredientsTextUnix),
        Case(TrimmedIngredientsTextNonUnix),
        Case(IngredientsWithBlankLinesAndTrailingWhitespace),
    };

    public const string IngredientsWithPreparation = """
                                    Carrot, chopped
                                    Meat, cut into 1 inch dice
                                    """;

    public const string IngredientsWithPreparationAndTrailingWhitespaces = """
                                    Carrot  , chopped
                                      Meat,  cut into 1 inch dice
                                    """;

    public const string IngredientsWithQuantity = """
                                    5 Carrots
                                    500g Meat
                                    """;

    public const string IngredientsWithQuantityAndPreparation = """
                                    5 Carrots, chopped
                                    500g Meat,  cut into 1 inch dice
                                    """;
}
