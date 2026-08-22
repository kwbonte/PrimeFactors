using FluentAssertions;
using PrimeFactors.Core;
using Xunit;

namespace PrimeFactors.Core.Tests;

public class PrimeFactorCalculatorTests
{
    [Fact]
    public void CalculatesFactorsOf1()
    {
        // Arrange
        const long number = 1;

        // Act
        List<long> factors = PrimeFactorCalculator.Calculate(number);

        // Assert
        factors.Should().BeEmpty();
    }

    [Fact]
    public void CalculatesFactorsOf2()
    {
        // Arrange
        const long number = 2;

        // Act
        List<long> factors = PrimeFactorCalculator.Calculate(number);

        // Assert
        factors.Should().Equal(2);
    }

    [Fact]
    public void CalculatesFactorsOf4()
    {
        // Arrange
        const long number = 4;

        // Act
        List<long> factors = PrimeFactorCalculator.Calculate(number);

        // Assert
        factors.Should().Equal(2, 2);
    }

    [Fact]
    public void CalculatesFactorsOf12()
    {
        // Arrange
        const long number = 12;

        // Act
        List<long> factors = PrimeFactorCalculator.Calculate(number);

        // Assert
        factors.Should().Equal(2, 2, 3);
    }

    [Fact]
    public void CalculatesFactorsOf60()
    {
        // Arrange
        const long number = 60;

        // Act
        List<long> factors = PrimeFactorCalculator.Calculate(number);

        // Assert
        factors.Should().Equal(2, 2, 3, 5);
    }

    [Fact]
    public void CalculatesFactorsOf97()
    {
        // Arrange
        const long number = 97;

        // Act
        List<long> factors = PrimeFactorCalculator.Calculate(number);

        // Assert
        factors.Should().Equal(97);
    }

    [Fact]
    public void CalculatesRepeatedOddFactors()
    {
        // Arrange
        const long number = 27;

        // Act
        List<long> factors = PrimeFactorCalculator.Calculate(number);

        // Assert
        factors.Should().Equal(3, 3, 3);
    }

    [Fact]
    public void CalculatesFactorsOfOddPrimeSquare()
    {
        // Arrange
        const long number = 49;

        // Act
        List<long> factors = PrimeFactorCalculator.Calculate(number);

        // Assert
        factors.Should().Equal(7, 7);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(13)]
    [InlineData(8191)]
    public void ReturnsPrimeNumberAsItsOnlyFactor(long number)
    {
        // Act
        List<long> factors = PrimeFactorCalculator.Calculate(number);

        // Assert
        factors.Should().Equal(number);
    }

    [Fact]
    public void CalculatesFactorsOfLargestLong()
    {
        // Arrange
        const long number = long.MaxValue;

        // Act
        List<long> factors = PrimeFactorCalculator.Calculate(number);

        // Assert
        factors.Should().Equal(7, 7, 73, 127, 337, 92737, 649657);
    }
}
