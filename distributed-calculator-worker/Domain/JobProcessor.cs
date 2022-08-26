namespace distributed_calculator_worker;

public interface IJobProcessor
{
    string Calculate(string calculation);
}

public class JobProcessor : IJobProcessor
{
    public string Calculate(string calculation)
    {
        string[] parts;
        try
        {
            parts = calculation.Split(' ');
            var op1 = double.Parse(parts[0]);
            var op2 = double.Parse(parts[2]);
            var result = parts[1] switch
            {
                "+" => op1 + op2,
                "-" => op1 - op2,
                "*" => op1 * op2,
                "/" => op1 / op2
            };
            return Math.Round(result, 3).ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR PROCESSING CALCULATION: " + calculation);
            Console.WriteLine(ex);
            return "ERROR";
        }
    }
}