
public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        //if (numbers.Contains(','))
        //{
        //    var ind = numbers.IndexOf(',');
        //    try
        //    {
        //        return int.Parse(numbers.Substring(0, ind)) + int.Parse(numbers.Substring(ind + 1));
        //    }
        //    catch (FormatException)
        //    {
        //        return 0;
        //    }
        //}

        try
        {
            return numbers.Split(",").Select(int.Parse).Sum();
        }
        catch (FormatException)
        {
            return 0;
        }
    }
}
