using FluentAssertions;
using PrimeFactors.Presentation;
using Xunit;

namespace PrimeFactors.Presentation.Tests;

public class PositiveIntegerParserTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("invalid")]
    [InlineData("0")]
    [InlineData("-1")]
    [InlineData("9223372036854775808")]
    public void ThrowsInvalidNumericInputExceptionForInvalidInput(string input)
    {
        // Act
        Action act = () => PositiveIntegerParser.Parse(input);

        // Assert
        act.Should().Throw<InvalidNumericInputException>();
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("8191", 8191)]
    [InlineData("9223372036854775807", long.MaxValue)]
    public void ParsesPositiveInteger(string input, long expectedNumber)
    {
        // Act
        long number = PositiveIntegerParser.Parse(input);

        // Assert
        number.Should().Be(expectedNumber);
    }
}
