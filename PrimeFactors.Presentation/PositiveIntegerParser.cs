namespace PrimeFactors.Presentation;

public static class PositiveIntegerParser
{
    public static long Parse(string input)
    {
        if (long.TryParse(input, out long number) && number > 0)
        {
            return number;
        }

        throw new InvalidNumericInputException();
    }
}
