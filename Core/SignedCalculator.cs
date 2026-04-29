namespace Core;

public class SignedCalculator
{
    private readonly BigNumberAdder adder = new BigNumberAdder();
    private readonly BigNumberSubtractor subtractor = new BigNumberSubtractor();
    
    // Adds two signed integer numbers represented as strings.
    public string Add(string a, string b)
    {
        bool negA = a[0] == '-';
        bool negB = b[0] == '-';
        
        // Remove the minus sign to work with absolute values.
        string absA = negA ? a.Substring(1) : a;
        string absB = negB ? b.Substring(1) : b;

        
        // If both numbers have the same sign, add their absolute values.
        if (negA == negB)
        {
            string sum = adder.Add(absA, absB);
            return negA ? "-" + sum : sum;
        }
        
        // If signs are different, subtract the smaller absolute value from the larger one.
        int cmp = Compare(absA, absB);

        if (cmp == 0) return "0";

        if (cmp > 0)
        {
            string diff = subtractor.Subtract(absA, absB);
            return negA ? "-" + diff : diff;
        }
        else
        {
            string diff = subtractor.Subtract(absB, absA);
            return negB ? "-" + diff : diff;
        }
    }

    // Compares two non-negative integer numbers represented as strings.
    private int Compare(string a, string b)
    {
        if (a.Length != b.Length)
            return a.Length > b.Length ? 1 : -1;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i])
                return a[i] > b[i] ? 1 : -1;
        }

        return 0;
    }
}