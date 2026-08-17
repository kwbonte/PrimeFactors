using PrimeFactors;

long? number = ReadPositiveInteger();

if (number is null)
{
    return;
}

List<long> factors = PrimeFactorCalculator.Calculate(number.Value);

Console.WriteLine(factors.Count == 0
    ? $"{number} has no prime factors."
    : $"Prime factors: {string.Join(" × ", factors)}");

static long? ReadPositiveInteger()
{
    while (true)
    {
        Console.Write("Enter a positive integer: ");
        string? input = Console.ReadLine();

        // End gracefully if the input stream is closed.
        if (input is null)
        {
            return null;
        }

        if (long.TryParse(input, out long number) && number > 0)
        {
            return number;
        }

        Console.WriteLine("Invalid input. Please enter a positive integer.");
    }
}
