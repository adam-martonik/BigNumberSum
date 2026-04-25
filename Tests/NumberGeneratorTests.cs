namespace Tests;
using Core;
using Xunit;
public class NumberGeneratorTests
{
    private NumberGenerator generator = new NumberGenerator(); 
    [Theory]
    [InlineData(50)]
    [InlineData(1)]
    [InlineData(34)]
    [InlineData(0)]
    [InlineData(49)]
    [InlineData(15)]
    
    public void nthLengthNumber(int len)
    {
        Assert.Equal(len, generator.GenerateNumber(len).Length);
    }
}