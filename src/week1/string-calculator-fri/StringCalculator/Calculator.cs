
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
            var numList = Regex.Split(numbers, pattern).Select(int.Parse);
            if (numList.Where((num) => num < 0).Count() > 0)
            {
                throw new NegativeNumberException();
            }
            return numList.Sum();
        }
        catch (FormatException)
        {
            return 0;
        }
    }
}

public class NegativeNumberException : ArgumentException { }
