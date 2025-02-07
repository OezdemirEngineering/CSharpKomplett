using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals;


// Dog class inherits from Animal class and passes the name, age to the base class
internal abstract class Dog(string name, int age): Animal(name, age)
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof Woof");
    }


    // abstract must be ovverrided to create an instance of this base 
    public abstract void GetRace();

}
