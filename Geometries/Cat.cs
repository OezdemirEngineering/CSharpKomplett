using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals;

internal class Cat : Animal
{
    public Cat(string name, int age) : base(name, age)
    {
    }
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}
