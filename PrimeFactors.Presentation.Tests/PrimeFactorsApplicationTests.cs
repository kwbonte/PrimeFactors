using PrimeFactors.Presentation;
using Xunit;

namespace PrimeFactors.Presentation.Tests;

public class PrimeFactorsApplicationTests
{
    [Fact]
    public void DisplaysPrimeFactorsForValidInput()
    {
        var input = new StringReader("60");
        var output = new StringWriter();
        var application = new PrimeFactorsApplication(input, output);

        application.Run();

        Assert.Equal(
            $"Enter a positive integer: Prime factors: 2 × 2 × 3 × 5{Environment.NewLine}" +
            "Enter a positive integer: ",
            output.ToString());
    }

    [Fact]
    public void DisplaysErrorAndContinuesAfterInvalidInput()
    {
        var input = new StringReader($"invalid{Environment.NewLine}12");
        var output = new StringWriter();
        var application = new PrimeFactorsApplication(input, output);

        application.Run();

        Assert.Equal(
            "Enter a positive integer: " +
            $"Invalid input. Please enter a positive integer.{Environment.NewLine}" +
            "Enter a positive integer: " +
            $"Prime factors: 2 × 2 × 3{Environment.NewLine}" +
            "Enter a positive integer: ",
            output.ToString());
    }

    [Fact]
    public void StopsWhenUserEntersQuit()
    {
        var input = new StringReader("  QUIT  ");
        var output = new StringWriter();
        var application = new PrimeFactorsApplication(input, output);

        application.Run();

        Assert.Equal("Enter a positive integer: ", output.ToString());
    }

    [Fact]
    public void ProcessesMultipleNumbersUntilQuit()
    {
        var input = new StringReader(
            $"4{Environment.NewLine}97{Environment.NewLine}quit{Environment.NewLine}");
        var output = new StringWriter();
        var application = new PrimeFactorsApplication(input, output);

        application.Run();

        Assert.Equal(
            "Enter a positive integer: " +
            $"Prime factors: 2 × 2{Environment.NewLine}" +
            "Enter a positive integer: " +
            $"Prime factors: 97{Environment.NewLine}" +
            "Enter a positive integer: ",
            output.ToString());
    }
}
