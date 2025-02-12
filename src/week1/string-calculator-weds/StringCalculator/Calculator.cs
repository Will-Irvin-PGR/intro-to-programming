
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
            result += int.Parse(n);
        }
        return result; 
        try
        {
            return int.Parse(numbers);
        }
        catch (FormatException)
        {
            string first = numbers.Substring(0, numbers.IndexOf(','));
            string second = numbers.Substring(numbers.IndexOf(",") + 1);
            try
            {
                return int.Parse(first) + int.Parse(second);
            }
            catch (FormatException)
            {
                return 0;
            }
        }
    }
}
