using Xunit;
using Core;

namespace Tests;

public class SummatorAdditionalTests
{
    private Summator summator = new Summator();

    [Fact]
    public void Sum_ResultHasNoLeadingZeros()
    {
        string result = summator.Sum();
        string digits = result.StartsWith("-") ? result.Substring(1) : result;

        if (digits != "0")
            Assert.False(digits.StartsWith("0"), $"Result '{result}' has leading zeros.");
    }

    [Fact]
    public void Sum_NegativeResult_StartsWithMinusSign()
    {
        string result = summator.Sum();

        if (result.StartsWith("-"))
        {
            string digits = result.Substring(1);
            Assert.False(string.IsNullOrEmpty(digits));
            Assert.NotEqual("0", digits);
        }
    }

    [Fact]
    public void Sum_PositiveResult_DoesNotStartWithMinusSign()
    {
        string result = summator.Sum();

        if (!result.StartsWith("-"))
            Assert.True(char.IsDigit(result[0]), $"Positive result '{result}' should start with a digit.");
    }

    [Fact]
    public void Sum_ZeroResult_IsExactlyZero()
    {
        string result = summator.Sum();
        if (result == "0")
            Assert.Equal("0", result);
    }

    [Fact]
    public void Sum_ResultLength_IsReasonable()
    {
        string result = summator.Sum();
        string digits = result.StartsWith("-") ? result.Substring(1) : result;
        Assert.True(digits.Length <= 60, $"Result '{result}' seems unreasonably long.");
    }

    [Fact]
    public void Sum_MultipleRuns_AllResultsAreValid()
    {
        for (int i = 0; i < 10; i++)
        {
            var s = new Summator();
            string result = s.Sum();

            Assert.False(string.IsNullOrEmpty(result), "Result should not be empty.");

            string digits = result.StartsWith("-") ? result.Substring(1) : result;
            Assert.All(digits, c => Assert.True(char.IsDigit(c), $"Non-digit character in result '{result}'."));

            if (digits != "0")
                Assert.False(digits.StartsWith("0"), $"Leading zero in result '{result}'.");

            if (result.StartsWith("-"))
                Assert.NotEqual("0", digits);

            Assert.True(digits.Length <= 60, $"Result '{result}' is unreasonably long.");
        }
    }
}