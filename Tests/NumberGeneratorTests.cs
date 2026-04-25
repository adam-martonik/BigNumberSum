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
    [InlineData(49)]
    [InlineData(15)]
    
    public void nthLengthNumber(int len)
    {
		string example = generator.GenerateNumber(len);
		if (example[0] == '-' )
		{
			Assert.Equal(len+1,example.Length);
		}else{
			Assert.Equal(len,example.Length);
    	}
	}

	[Fact]
	public void zeroLengthNumber(){
        Assert.Throws<ArgumentException>(() => generator.GenerateNumber(0));
	}

}