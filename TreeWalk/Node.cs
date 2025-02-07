using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeWalk;

internal class Node
{
    public string Name { get; set; }
    public Node? Child { get; set; }

    public Node(string name, Node? child = null)
    {
        Name = name;
        Child = child;
    }

    public void PrintAllNames()
    {
        Console.WriteLine(Name);
        Child?.PrintAllNames();
    }
}
