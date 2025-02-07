
namespace Methods;



class Program
{
    private static  void Print(string message)
    {
        Console.WriteLine(message);
    }

    private static void Print(string  id ,string message)
    {
        var stringFormat = string.Format(" Der user {0} : schreibt {1}", id, message);

        Console.WriteLine(stringFormat);    
    }

    private static double Abs(double value)
    {
        var result = Math.Abs(value);
        return result;
    }

    private static double Square(double value) 
        => value * value;


    private static double BinomialCalculation(int menu, double a , double b) => menu switch
    {
        1 => Math.Pow((a + b), 2),
        2 => Math.Pow((a - b), 2),
        3 => Math.Pow(a, 2) - Math.Pow(b, 2),
        _ => 0
    };

    private static void Log(string message , string level = "INFO")
    {
        Console.WriteLine($"{level}: {message}");
    }

    private static void Log2(string message, string level = "INFO",string user = null, string source = null)
    {
        Console.WriteLine($"{level}: {message}");
    }

    public static void Main(string[] args)
    {
        Print((10).ToString(), "Hallo Welt");

        var absValue = Abs(-10);

        var squareValue = Square(10);

       var binomialResult = BinomialCalculation(1, 10, 20);
        Console.WriteLine(binomialResult);

        Log("Hello World");
        Log("Hello World", "ERROR");

        Log2("Hello World", "ERROR", "Hans", "Program.cs");

        Log2("Hello World", source: "Program.cs");
    }

}
