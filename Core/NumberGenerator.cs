namespace Core;

public class NumberGenerator
{
    private Random rnd = new Random();

    public string GenerateNumber(int n)
    {
		if(n <= 0){
			throw new ArgumentException("n must be greater than 0");
		}
        string number = "";
        int rnd_sign = rnd.Next(0, 2);

        if (rnd_sign == 0)
            number += "-";

        for (int i = 0; i < n; i++)
        {
            if (i == 0)
                number += rnd.Next(1, 10);
            else
                number += rnd.Next(0, 10);
        }

        return number;
    }
}