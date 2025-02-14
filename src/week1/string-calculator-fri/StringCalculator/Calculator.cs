
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

        if (numbers.Length > 4 &&
            numbers[0] == '/' && numbers[1] == '/' && numbers[3] == '\\')
        {
            pattern = pattern.Substring(0, pattern.Length - 1) + numbers[2] + ']';
            numbers = numbers.Substring(4);
        }

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
