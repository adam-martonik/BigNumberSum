namespace Core;

public class BigNumberSubtractor
{
    public string Subtract(string a, string b)
    {
        int i = a.Length - 1;
        int j = b.Length - 1;
        int borrow = 0;
        string result = "";

        while (i >= 0)
        {
            int digitA = a[i] - '0';
            int digitB = (j >= 0) ? (b[j] - '0') : 0;

            int diff = digitA - digitB - borrow;

            if (diff < 0)
            {
                diff += 10;
                borrow = 1;
            }
            else
            {
                borrow = 0;
            }

            result = diff + result;
            i--;
            j--;
        }

        // odstráň úvodné nuly
        result = result.TrimStart('0');

        return result == "" ? "0" : result;
    }
}