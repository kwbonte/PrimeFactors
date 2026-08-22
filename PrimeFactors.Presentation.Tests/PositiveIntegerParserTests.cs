using PrimeFactors.Presentation;
using Xunit;

namespace PrimeFactors.Presentation.Tests;

public class PositiveIntegerParserTests
{
    [Fact]
    public void ThrowsInvalidNumericInputExceptionForInvalidInput()
    {
        Assert.Throws<InvalidNumericInputException>(() => PositiveIntegerParser.Parse("invalid"));
    }
}
