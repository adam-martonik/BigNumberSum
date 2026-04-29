namespace Core;

public class BigNumberAdder
{
    // Adds two non-negative integer numbers represented as strings([0-9]+[0-9]).
    public string Add(string a, string b)
    {
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;
        string result = "";

        while (i >= 0 || j >= 0 || carry > 0)
        {
            int digitA = (i >= 0) ? (a[i] - '0') : 0;
            int digitB = (j >= 0) ? (b[j] - '0') : 0;

            int sum = digitA + digitB + carry;
            carry = sum / 10;
            result = (sum % 10) + result; 

            i--;
            j--;
        }

        return result;
    }
    
}