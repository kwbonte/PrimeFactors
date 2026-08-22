namespace PrimeFactors.Core;

public static class PrimeFactorCalculator
{
    public static List<long> Calculate(long number)
    {
        var factors = new List<long>();
        long remaining = number;

        // Remove every factor of 2 first so the loop only needs to test odd divisors.
        while (remaining % 2 == 0)
        {
            factors.Add(2);
            remaining /= 2;
        }

        // Test odd divisors in ascending order. Division is used in the condition
        // instead of divisor * divisor to avoid overflowing a long.
        for (long divisor = 3; divisor <= remaining / divisor; divisor += 2)
        {
            // Record repeated factors and reduce the value still being factored.
            while (remaining % divisor == 0)
            {
                factors.Add(divisor);
                remaining /= divisor;
            }
        }

        // Any value left is the final (and largest) prime factor.
        if (remaining > 1)
        {
            factors.Add(remaining);
        }

        return factors;
    }
}
