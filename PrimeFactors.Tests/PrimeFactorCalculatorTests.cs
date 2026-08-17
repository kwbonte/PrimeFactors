using PrimeFactors;
using Xunit;

namespace PrimeFactors.Tests;

public class PrimeFactorCalculatorTests
{
    [Fact]
    public void CalculatesFactorsOf2()
    {
        Assert.Equal([2], PrimeFactorCalculator.Calculate(2));
    }

    [Fact]
    public void CalculatesFactorsOf4()
    {
        Assert.Equal([2, 2], PrimeFactorCalculator.Calculate(4));
    }

    [Fact]
    public void CalculatesFactorsOf12()
    {
        Assert.Equal([2, 2, 3], PrimeFactorCalculator.Calculate(12));
    }

    [Fact]
    public void CalculatesFactorsOf60()
    {
        Assert.Equal([2, 2, 3, 5], PrimeFactorCalculator.Calculate(60));
    }

    [Fact]
    public void CalculatesFactorsOf97()
    {
        Assert.Equal([97], PrimeFactorCalculator.Calculate(97));
    }
}
