
public class Calculator
{
    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        try
        {
            return int.Parse(numbers);
        }
        catch (FormatException)
        {
            string first = numbers.Substring(0, numbers.IndexOf(','));
            string second = numbers.Substring(numbers.IndexOf(",") + 1);
            return int.Parse(first) + int.Parse(second);
        }
    }
}
