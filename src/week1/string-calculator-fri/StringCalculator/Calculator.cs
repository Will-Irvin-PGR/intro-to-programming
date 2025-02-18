
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

        string delimPattern = @"//(.)\|//\[(.*)\]\\";

        //if (numbers.Length > 4 &&
        //    numbers[0] == '/' && numbers[1] == '/' && numbers[3] == '\\')
        //{
        //    pattern = pattern.Substring(0, pattern.Length - 1) + numbers[2] + ']';
        //    numbers = numbers.Substring(4);
        //}

        var matches = Regex.Matches(numbers, delimPattern);
        int length = 0;

        foreach (Match match in matches)
        {
            pattern = pattern.Substring(0, pattern.Length - 1) + match.Value + ']';
            length += match.Length;
        }
        if (length > 1)
        {
            length += 5;
        } 
        else if (length == 1)
        {
            length += 3;
        }

        numbers = numbers.Substring(length);
        try
        {
            var numList = Regex.Split(numbers, pattern).Select(int.Parse);
            var negList = numList.Where((num) => num < 0);
            if (negList.Count() > 0)
            {
                var negStrings = negList.Select((num) => num.ToString());   
                throw new NegativeNumberException(string.Join(",", negStrings));
            }
            return numList.Where((num) => num <= 1000).Sum();
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
