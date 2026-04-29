using Core;

var summator = new Summator();
string result = summator.Sum();

Console.WriteLine("Výsledok: " + result.Substring(0, Math.Min(10, result.Length)));