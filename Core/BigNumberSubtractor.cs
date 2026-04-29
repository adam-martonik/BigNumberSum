namespace Core;

public class BigNumberSubtractor
{
    // Subtracts two non-negative integer numbers represented as strings.
    // Assumes that the first number is greater than or equal to the second one.
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

            // If the current digit is too small, borrow from the next digit.
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

        // Remove leading zeros from the result.
        result = result.TrimStart('0');

        // Return "0" if the result contains only zeros.
        return result == "" ? "0" : result;
    }
}