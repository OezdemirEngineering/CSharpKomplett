using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals;


// Dog class inherits from Animal class and passes the name, age to the base class
internal class GermanShepard(string name, int age): Dog(name, age)
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof Woof");
    }

    public override void GetRace()
    {
        Console.WriteLine("Sup, im a german Shepard!");
    }

}
