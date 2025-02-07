
namespace CSharpKomplett;

public static class Program  
{
    public static void Main(string[] args)
    {
        int number = 10;

        number = 5;

        float floatNumber = 5.5f; // single precision floating point number
        double doubleNumber = 5.5; // double precision floating point number

        bool isTrue = true;

        byte byteNumber = 255; // 0 - 255

        string text = "Hello World!";
        char character = 'A';

        var variable = 5; // implicitly typed variable

        variable = (int)10.5f; // casts float into integer-> 10

    
        dynamic dynamicVariable = 5; // dynamic variable
        dynamicVariable = "Hello World!";

        int inkrement = 0; 

        inkrement++; // inkrement = inkrement + 1
        inkrement--; // inkrement = inkrement - 1

        ++inkrement; // inkrement = inkrement + 1
        --inkrement; // inkrement = inkrement - 1

        var strNumber = variable.ToString();


        var numberFromString = Convert.ToInt16(strNumber);

        Console.WriteLine("Write current speed:");
        var readVariable =  Console.ReadLine();

        var readNumber = Convert.ToInt16(readVariable);

        // s = V*V/2*a, a= 7.5

    }
}
