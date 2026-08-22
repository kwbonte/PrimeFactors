using FluentAssertions;
using PrimeFactors.Presentation;
using Xunit;

namespace PrimeFactors.Presentation.Tests;

public class PrimeFactorsApplicationTests
{
    [Fact]
    public void DisplaysPrimeFactorsForValidInput()
    {
        // Arrange
        var input = new StringReader("60");
        var output = new StringWriter();
        var application = new PrimeFactorsApplication(input, output);

        // Act
        application.Run();

        // Assert
        output.ToString().Should().Be(
            $"Enter a positive integer: Prime factors: 2 × 2 × 3 × 5{Environment.NewLine}" +
            "Enter a positive integer: ");
    }

    [Fact]
    public void DisplaysErrorAndContinuesAfterInvalidInput()
    {
        // Arrange
        var input = new StringReader($"invalid{Environment.NewLine}12");
        var output = new StringWriter();
        var application = new PrimeFactorsApplication(input, output);

        // Act
        application.Run();

        // Assert
        output.ToString().Should().Be(
            "Enter a positive integer: " +
            $"Invalid input. Please enter a positive integer.{Environment.NewLine}" +
            "Enter a positive integer: " +
            $"Prime factors: 2 × 2 × 3{Environment.NewLine}" +
            "Enter a positive integer: ");
    }

    [Fact]
    public void StopsWhenUserEntersQuit()
    {
        // Arrange
        var input = new StringReader("  QUIT  ");
        var output = new StringWriter();
        var application = new PrimeFactorsApplication(input, output);

        // Act
        application.Run();

        // Assert
        output.ToString().Should().Be("Enter a positive integer: ");
    }

    [Fact]
    public void ProcessesMultipleNumbersUntilQuit()
    {
        // Arrange
        var input = new StringReader(
            $"4{Environment.NewLine}97{Environment.NewLine}quit{Environment.NewLine}");
        var output = new StringWriter();
        var application = new PrimeFactorsApplication(input, output);

        // Act
        application.Run();

        // Assert
        output.ToString().Should().Be(
            "Enter a positive integer: " +
            $"Prime factors: 2 × 2{Environment.NewLine}" +
            "Enter a positive integer: " +
            $"Prime factors: 97{Environment.NewLine}" +
            "Enter a positive integer: ");
    }

    [Fact]
    public void StopsAtEndOfInput()
    {
        // Arrange
        var input = new StringReader(string.Empty);
        var output = new StringWriter();
        var application = new PrimeFactorsApplication(input, output);

        // Act
        application.Run();

        // Assert
        output.ToString().Should().Be("Enter a positive integer: ");
    }

    [Fact]
    public void DisplaysMessageWhenNumberHasNoPrimeFactors()
    {
        // Arrange
        var input = new StringReader("1");
        var output = new StringWriter();
        var application = new PrimeFactorsApplication(input, output);

        // Act
        application.Run();

        // Assert
        output.ToString().Should().Be(
            $"Enter a positive integer: 1 has no prime factors.{Environment.NewLine}" +
            "Enter a positive integer: ");
    }
}
