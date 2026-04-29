using Core;
using Xunit;

namespace Tests;

public class NumberGeneratorTests
{
    private NumberGenerator generator = new NumberGenerator();

    [Theory]
    [InlineData(1)]
    [InlineData(15)]
    [InlineData(34)]
    [InlineData(49)]
    [InlineData(50)]
    public void GenerateNumber_HasCorrectLength(int len)
    {
        string result = generator.GenerateNumber(len);
        int expectedLength = result[0] == '-' ? len + 1 : len;
        Assert.Equal(expectedLength, result.Length);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(15)]
    [InlineData(50)]
    public void GenerateNumber_ContainsOnlyDigitsAndOptionalLeadingMinus(int len)
    {
        string result = generator.GenerateNumber(len);
        string digits = result[0] == '-' ? result.Substring(1) : result;
        Assert.All(digits, c => Assert.True(char.IsDigit(c), $"Non-digit character '{c}' in result '{result}'"));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(15)]
    [InlineData(50)]
    public void GenerateNumber_HasNoLeadingZeros(int len)
    {
        for (int i = 0; i < 20; i++)
        {
            string result = generator.GenerateNumber(len);
            string digits = result[0] == '-' ? result.Substring(1) : result;
            Assert.False(digits.StartsWith("0"), $"Leading zero in result '{result}' for len={len}");
        }
    }

    [Theory]
    [InlineData(1)]
    [InlineData(25)]
    [InlineData(50)]
    public void GenerateNumber_MultipleRuns_AlwaysCorrectLength(int len)
    {
        for (int i = 0; i < 20; i++)
        {
            string result = generator.GenerateNumber(len);
            int expectedLength = result[0] == '-' ? len + 1 : len;
            Assert.Equal(expectedLength, result.Length);
        }
    }

    [Fact]
    public void GenerateNumber_Zero_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => generator.GenerateNumber(0));
    }

    [Fact]
    public void GenerateNumber_NegativeInput_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => generator.GenerateNumber(-1));
    }
}