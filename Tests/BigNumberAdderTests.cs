using Core;
using Xunit;

namespace Tests;

public class BigNumberAdderTests
{
    private BigNumberAdder adder = new BigNumberAdder();

    [Theory]
    [InlineData("1", "1", "2")]
    [InlineData("11111111111111111111111111111111111111111111111111",
        "22222222222222222222222222222222222222222222222222",
        "33333333333333333333333333333333333333333333333333")]
    [InlineData("99999", "1", "100000")]
    [InlineData("99999999999999999999999999999999999999999999999999",
        "99999999999999999999999999999999999999999999999999",
        "199999999999999999999999999999999999999999999999998")]
    [InlineData("0", "123", "123")]
    [InlineData("123", "0", "123")]
    [InlineData("9999999999", "1", "10000000000")]
    [InlineData("9", "9", "18")]
    public void Add(string a, string b, string expected)
    {
        Assert.Equal(expected, adder.Add(a, b));
    }
}