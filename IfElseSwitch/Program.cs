
namespace IfElseSwitch;

public class Node
{
    public string Name;
    public Node? Child;

    public Node(string name)
    {
        Name = name;
    }
}



public class Programm
{
    static void Main()
    {
         Console.WriteLine("Binomische Formeln");
        Console.WriteLine("1. Binomische Formel: (a+b)² = a² + 2ab + b²");
        Console.WriteLine("2. Binomische Formel: (a-b)² = a² - 2ab + b²");
        Console.WriteLine("3. Binomische Formel: (a+b)(a-b) = a² - b²");

        var menu = Console.ReadLine();

        Console.WriteLine("a:");
        var a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("b:");
        var b = Convert.ToDouble(Console.ReadLine());

        switch (menu)
        {
            case "1":
                Console.WriteLine("Ergebnis:"+ Math.Pow((a + b), 2));
                break;
            case "2":
                Console.WriteLine("Ergebnis:" + Math.Pow((a - b), 2));
                break;
            case "3":
                Console.WriteLine("Ergebnis:" + (Math.Pow(a, 2) - Math.Pow(b, 2)));
                break;
            default:
                Console.WriteLine("Ungültige Eingabe");
                break;
        }
    }
}
