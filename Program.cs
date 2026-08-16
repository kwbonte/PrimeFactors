Console.Write("Enter a positive integer: ");

if (!long.TryParse(Console.ReadLine(), out long number) || number <= 0)
{
    Console.WriteLine("Invalid input. Please enter a positive integer.");
    return;
}

var factors = new List<long>();
long remaining = number;

for (long divisor = 2; divisor <= remaining / divisor; divisor++)
{
    while (remaining % divisor == 0)
    {
        factors.Add(divisor);
        remaining /= divisor;
    }
}

if (remaining > 1)
{
    factors.Add(remaining);
}

Console.WriteLine(factors.Count == 0
    ? $"{number} has no prime factors."
    : $"Prime factors: {string.Join(" × ", factors)}");
