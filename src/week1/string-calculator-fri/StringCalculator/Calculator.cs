
using System.Text.RegularExpressions;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        string pattern = "[,\n]";

        try
        {
            return Regex.Split(numbers, pattern).Select(int.Parse).Sum();
        }
        catch (FormatException)
        {
            return 0;
        }
    }
}
