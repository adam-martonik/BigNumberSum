namespace Core;

public class NumberGenerator
{
    private Random rnd = new Random();
    

    // Generates a random signed integer number with exactly n digits.
    public string GenerateNumber(int n)
    {
		// The number of digits must be positive.
		if(n <= 0){
			throw new ArgumentException("n must be greater than 0");
		}
        string number = "";
        int rnd_sign = rnd.Next(0, 2);


        // Randomly decide whether the generated number should be negative.
        if (rnd_sign == 0)
            number += "-";

        for (int i = 0; i < n; i++)
        {
			// The first digit cannot be zero, so the number has exactly n digits.
            if (i == 0)
                number += rnd.Next(1, 10);
            else
                number += rnd.Next(0, 10);
        }

        return number;
    }
}