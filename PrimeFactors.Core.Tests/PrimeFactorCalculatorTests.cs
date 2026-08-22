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
}
