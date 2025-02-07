using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeWalk;

internal static class NodeExtensions
{
    internal static void Traverse(this Node node)
    {
        Console.WriteLine(node.Name);
        if (node.Child != null)
        {
            Traverse(node.Child);
        }
    }
}
