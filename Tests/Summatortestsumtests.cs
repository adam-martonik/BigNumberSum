using Core;
using Xunit;

namespace Tests;

public class SummatorTestSumTests
{
    private readonly Summator summator = new Summator();

    [Fact]
    public void TestSum_ReturnsCorrectResult()
    {
        Assert.Equal("-92840390306166053216855649662554338599706011144395", summator.TestSum());
    }

    [Fact]
    public void TestSum_First10Digits_AreCorrect()
    {
        string result = summator.TestSum();
        // Výsledok je záporný, preskočíme mínus a zoberieme prvých 10 číslic
        string digits = result.StartsWith("-") ? result.Substring(1) : result;
        Assert.Equal("9284039030", digits.Substring(0, 10));
    }

    [Fact]
    public void TestSum_IsNegative()
    {
        Assert.StartsWith("-", summator.TestSum());
    }
}