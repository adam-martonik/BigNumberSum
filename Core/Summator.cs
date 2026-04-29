namespace Core;

public class Summator
{
    private NumberGenerator generator = new NumberGenerator();
    private BigNumberAdder adder = new BigNumberAdder();
    private BigNumberSubtractor subtractor = new BigNumberSubtractor();

    public string Sum()
    {
        string sum = generator.GenerateNumber(1);

        for (int i = 2; i <= 50; i++)
        {
            string temp = generator.GenerateNumber(i);

            if (temp[0] == '-')
                sum = subtractor.Subtract(sum, temp.Substring(1));
            else
                sum = adder.Add(sum, temp);
        }

        return sum;
    }
}