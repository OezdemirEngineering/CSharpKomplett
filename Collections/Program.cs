namespace Collections;

public class Program
{
    static void Main()
    {
        List<string> namen = new List<string>();
        namen.Add("Hans");
        namen.Add("Peter");
        namen.Add("Klaus");

        string name = namen[0];
        namen.Remove(name);
        namen.Clear();

        // var deklaration 
        var user = new List<string>();

        // List simple initialization
        List<string> users = new();

        // List initialization with values
        List<string> users2 = new() { "Hans", "Peter", "Klaus" };

        // Expression
        List<string> users3 = ["Hans", "Peter", "Klaus"];
        
        List<string> users4 = [];


        // for with index 
        for(int x =0; x < users3.Count;x++)
        {
            Console.WriteLine(users3[x]);
        }

        // foreach 
        foreach (var item in users3)
        {
            Console.WriteLine(item);
        }


        // Lambda Expression 
        users3.ForEach(x => Console.WriteLine(x));

        users3.ForEach(x => 
        {
            string str = x;
            Console.WriteLine(str); 
        });

    }
}


