using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals;

internal class Animal (string name, int age)
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;

    public void Sleep()
    {
        Console.WriteLine("Animal is sleeping");
    }

    public virtual void MakeSound()
    {
        Console.WriteLine("Animal is making sound");
    }
}
