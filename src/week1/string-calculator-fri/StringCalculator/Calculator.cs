
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
            var negList = numList.Where((num) => num < 0);
            if (negList.Count() > 0)
            {
                var negStrings = negList.Select((num) => num.ToString());   
                throw new NegativeNumberException(string.Join(",", negStrings));
            }
            return numList.Sum();
        }
        catch (FormatException)
        {
            return 0;
        }
    }
}

public class NegativeNumberException : ArgumentException
{
    public NegativeNumberException(string? message) : base(message)
    {
    }
}
