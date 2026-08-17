Console.Write("Enter a positive integer: ");

if (!long.TryParse(Console.ReadLine(), out long number) || number <= 0)
{
    Console.WriteLine("Invalid input. Please enter a positive integer.");
    return;
}

var factors = new List<long>();
long remaining = number;

// Try each possible divisor in ascending order, starting with the smallest prime.
// We only need to test through the square root of the remaining value. Using
// division here instead of divisor * divisor avoids overflowing a long.
for (long divisor = 2; divisor <= remaining / divisor; divisor++)
{
    // A prime factor can occur more than once, so keep removing this divisor
    // until it no longer divides the remaining value evenly.
    while (remaining % divisor == 0)
    {
        // Record the factor and reduce the value that still needs factoring.
        factors.Add(divisor);
        remaining /= divisor;
    }
}

// If a value greater than 1 remains, it is the final (and largest) prime factor.
if (remaining > 1)
{
    factors.Add(remaining);
}

Console.WriteLine(factors.Count == 0
    ? $"{number} has no prime factors."
    : $"Prime factors: {string.Join(" × ", factors)}");
