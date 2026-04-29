using Core;
using Xunit;

namespace Tests;

public class SignedCalculatorTests
{
    private readonly SignedCalculator calc = new SignedCalculator();

    // (+) + (+)
    [Theory]
    [InlineData("1", "1", "2")]
    [InlineData("123", "456", "579")]
    [InlineData("999", "1", "1000")]
    [InlineData("99999999999999999999", "1", "100000000000000000000")]
    public void Add_BothPositive_ReturnsCorrectSum(string a, string b, string expected)
    {
        Assert.Equal(expected, calc.Add(a, b));
    }

    // (-) + (-)
    [Theory]
    [InlineData("-1", "-1", "-2")]
    [InlineData("-123", "-456", "-579")]
    [InlineData("-999", "-1", "-1000")]
    [InlineData("-99999999999999999999", "-1", "-100000000000000000000")]
    public void Add_BothNegative_ReturnsCorrectSum(string a, string b, string expected)
    {
        Assert.Equal(expected, calc.Add(a, b));
    }

    // (+) + (-), kde |a| > |b|
    [Theory]
    [InlineData("20", "-10", "10")]
    [InlineData("1000", "-1", "999")]
    [InlineData("500", "-499", "1")]
    [InlineData("100000000000000000000", "-1", "99999999999999999999")]
    public void Add_PositiveLarger_ReturnsPositiveResult(string a, string b, string expected)
    {
        Assert.Equal(expected, calc.Add(a, b));
    }

    // (+) + (-), kde |b| > |a|
    [Theory]
    [InlineData("10", "-20", "-10")]
    [InlineData("1", "-1000", "-999")]
    [InlineData("499", "-500", "-1")]
    [InlineData("1", "-100000000000000000000", "-99999999999999999999")]
    public void Add_NegativeLarger_ReturnsNegativeResult(string a, string b, string expected)
    {
        Assert.Equal(expected, calc.Add(a, b));
    }

    // Výsledok je presne nula
    [Theory]
    [InlineData("1", "-1")]
    [InlineData("12345", "-12345")]
    [InlineData("99999999999999999999", "-99999999999999999999")]
    public void Add_OppositeNumbers_ReturnsZero(string a, string b)
    {
        Assert.Equal("0", calc.Add(a, b));
    }

    // Sčítanie s nulou
    [Theory]
    [InlineData("0", "123", "123")]
    [InlineData("123", "0", "123")]
    [InlineData("0", "-123", "-123")]
    [InlineData("-123", "0", "-123")]
    [InlineData("0", "0", "0")]
    public void Add_WithZero_ReturnsOtherNumber(string a, string b, string expected)
    {
        Assert.Equal(expected, calc.Add(a, b));
    }

    // Výsledok nesmie mať úvodné nuly
    [Theory]
    [InlineData("100", "-99")]
    [InlineData("1000", "-999")]
    [InlineData("10000", "-9999")]
    public void Add_ResultHasNoLeadingZeros(string a, string b)
    {
        string result = calc.Add(a, b);
        string digits = result.StartsWith("-") ? result.Substring(1) : result;
        Assert.False(digits.StartsWith("0"), $"Leading zero in result '{result}'");
    }

    // Záporná nula nesmie vzniknúť
    [Fact]
    public void Add_NeverReturnsNegativeZero()
    {
        string result = calc.Add("5", "-5");
        Assert.Equal("0", result);
        Assert.NotEqual("-0", result);
    }

    // Veľké čísla — kontrola oproti Pythonom vypočítanej hodnote
    [Fact]
    public void Add_LargeNumbers_ReturnsCorrectResult()
    {
        string a = "99999999999999999999999999999999999999999999999999";  // 50 číslic
        string b = "-99999999999999999999999999999999999999999999999998"; // 50 číslic
        Assert.Equal("1", calc.Add(a, b));
    }
}