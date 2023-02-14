namespace CookyPresentation.Tests;

internal static class Example
{
    public const string GivenTitle = "new title";

    public const string Instructions = """
                                    Some text with a
                                    linebreak
                                    """;

    public const string GivenTextWithSurroundingBlankLines = $"""

                                    {Instructions}

                                    """;

    public const string TrimmedIngredientsText = """
                                    Carrot
                                    Meat
                                    """;
    
    public const string IngredientsWithBlankLinesAndTrailingWhitespace = """

                                       Carrot

                                    Meat   

                                    """;

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
}