using Core;

// Create a summator instance used to calculate the final sum.
var summator = new Summator();

// Calculate the sum of generated numbers.
string result = summator.Sum();

string output;

if (result.StartsWith("-"))
{
    // Print the minus sign and the first 10 digits of the negative result.
    output = "-" + result.Substring(1, Math.Min(10, result.Length - 1));
}
else
{
    // Print the first 10 digits of the positive result.
    output = result.Substring(0, Math.Min(10, result.Length));
}

// Print the first 10 digits of the result.
Console.WriteLine("Výsledok: " + output);