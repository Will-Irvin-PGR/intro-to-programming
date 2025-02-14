
using System.Text.RegularExpressions;
using StringCalculator;

public class Calculator(ILogger _logger)
{
    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        string pattern = "[,\n]";

        if (numbers.Length >= 4 && numbers[0] == '/' &&
            numbers[1] == '/' && numbers[3] == '\\')
        {
            pattern = pattern.Substring(0, pattern.Length - 1)
                + numbers[2]
                + pattern.Substring(pattern.Length - 1);
            numbers = numbers.Substring(4);
        }

        string[] sepNumbers = Regex.Split(numbers, pattern);
        int result = 0;

        foreach (string n in sepNumbers)
        {
            string[] sepNewline = n.Split("\n");
            try
            {
                int next = int.Parse(n);
                if (next < 0)
                {
                    throw new Exception("No negative numbers allowed");
                }
                result += next;
            }
            catch (FormatException)
            {
                return 0;
            }
        }
        _logger.Write(result.ToString());
        return result;
    }
}
