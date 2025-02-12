
public class Calculator
{
    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        string[] sepNumbers = numbers.Split(',');
        int result = 0;

        foreach (string n in sepNumbers)
        {
            string[] sepNewline = n.Split("\n");
            foreach (string n2 in sepNewline)
            {
                try
                {
                    result += int.Parse(n2);
                }
                catch (FormatException)
                {
                    return 0;
                }
            }
        }
        return result; 
    }
}
