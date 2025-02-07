

using System;

namespace AllLoops;



class Program
{
    public static void Main(string[] args)
    {
        int i = 0;
        Console.WriteLine("While Loop");
        while (i<10)
        {
            Console.WriteLine(i++);
        }

        do
        {
            Console.WriteLine(i++);
        } while (i < 10);


        Console.WriteLine("For Loop");
        for (int j = 0; j<10; j++)
        {
            Console.WriteLine(j);
        }


        Console.WriteLine("Loop with break");
        int p = 0; 
        while(true)
        {
            if (p ==  10)
            {
                break;
            }
            Console.WriteLine(p);

            //Thread.Sleep(1000);

            p++;
        }


        Console.WriteLine("Loop with continue");
        bool run = true; 

        while(run)
        {
            Console.WriteLine("Enter a number");
            var input = Console.ReadLine();
            if (input == "exit")
            {
                run = false;
                continue;
            }

            if (input == "other")
            {
                run = false;
                Console.WriteLine("You entered: " + input);
                continue;
            }


            Console.WriteLine("You entered: " + input);
        }



        // if expression 
        int x = 10;

        string isNumberTen = x == 10 ? "Yes" : "No";


    }
}
