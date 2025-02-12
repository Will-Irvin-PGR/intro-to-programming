
public class Calculator
{
    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers))
        {
            return 0;
        }
        
        return int.Parse(numbers);
    }
}
