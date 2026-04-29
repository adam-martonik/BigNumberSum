namespace Core;

public class Summator
{
    private readonly NumberGenerator generator = new NumberGenerator();
    private readonly SignedCalculator calculator = new SignedCalculator();

  
    public string Sum()
    {
        string sum = generator.GenerateNumber(1);

        for (int i = 2; i <= 50; i++)
        {
            string next = generator.GenerateNumber(i);
            sum = calculator.Add(sum, next);
        }

        return sum;
    }
}