using Xunit;
using Core;

namespace Tests;

public class SummatorTests
{
    private Summator summator = new Summator();

    [Fact]
    public void Sum_ResultIsNotEmpty()
    {
        string result = summator.Sum();
        Assert.False(string.IsNullOrEmpty(result));
    }

    [Fact]
    public void Sum_ResultContainsOnlyDigits()
    {
        string result = summator.Sum();
        string toCheck = result[0] == '-' ? result.Substring(1) : result;
        Assert.All(toCheck, c => Assert.True(char.IsDigit(c)));
    }

    [Fact]
    public void Sum_ResultHasAtLeastOneDigit()
    {
        string result = summator.Sum();
        string toCheck = result[0] == '-' ? result.Substring(1) : result;
        Assert.True(toCheck.Length >= 1);
    }
}