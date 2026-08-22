using PrimeFactors.Core;

namespace PrimeFactors.Presentation;

public class PrimeFactorsApplication(TextReader input, TextWriter output)
{
    public void Run()
    {
        while (true)
        {
            output.Write("Enter a positive integer: ");
            string? value = input.ReadLine();

            if (value is null)
            {
                return;
            }

            if (string.Equals(value.Trim(), "quit", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            long number;

            try
            {
                number = PositiveIntegerParser.Parse(value);
            }
            catch (InvalidNumericInputException)
            {
                output.WriteLine("Invalid input. Please enter a positive integer.");
                continue;
            }

            List<long> factors = PrimeFactorCalculator.Calculate(number);

            output.WriteLine(factors.Count == 0
                ? $"{number} has no prime factors."
                : $"Prime factors: {string.Join(" × ", factors)}");
        }
    }
}
