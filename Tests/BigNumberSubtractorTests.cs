using Core;
using Xunit;

namespace Tests;

public class BigNumberSubtractorTests
{
    private BigNumberSubtractor subtractor = new BigNumberSubtractor();

    [Theory]
    [InlineData("2", "1", "1")]
    [InlineData("33333333333333333333333333333333333333333333333333",
        "22222222222222222222222222222222222222222222222222",
        "11111111111111111111111111111111111111111111111111")]
    [InlineData("100000", "1", "99999")]
    [InlineData("199999999999999999999999999999999999999999999999998",
        "99999999999999999999999999999999999999999999999999",
        "99999999999999999999999999999999999999999999999999")]
    [InlineData("123", "0", "123")]
    [InlineData("123", "123", "0")]
    [InlineData("10000000000", "1", "9999999999")]
    [InlineData("18", "9", "9")]
    [InlineData("1000", "999", "1")]
    [InlineData("9999999999999999999999999999999999999999999999999",
        "1",
        "9999999999999999999999999999999999999999999999998")]
    public void Subtract(string a, string b, string expected)
    {
        Assert.Equal(expected, subtractor.Subtract(a, b));
    }
}