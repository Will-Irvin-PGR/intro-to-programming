
using System.Text.RegularExpressions;

public class Calculator
{
    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        string pattern = "[,\n]";

        string[] sepNumbers = Regex.Split(numbers, pattern);
        int result = 0;

        foreach (string n in sepNumbers)
        {
            string[] sepNewline = n.Split("\n");
            //foreach (string n2 in sepNewline)
            //{
                try
                {
                    result += int.Parse(n);
                }
                catch (FormatException)
                {
                    return 0;
                }
            //}
        }
        return result; 
    }
}
