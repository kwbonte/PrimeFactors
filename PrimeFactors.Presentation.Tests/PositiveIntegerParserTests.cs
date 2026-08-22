using FluentAssertions;
using PrimeFactors.Presentation;
using Xunit;

namespace PrimeFactors.Presentation.Tests;

public class PositiveIntegerParserTests
{
    [Fact]
    public void ThrowsInvalidNumericInputExceptionForInvalidInput()
    {
        // Arrange
        const string input = "invalid";

        // Act
        Action act = () => PositiveIntegerParser.Parse(input);

        // Assert
        act.Should().Throw<InvalidNumericInputException>();
    }
}
