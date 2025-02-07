
namespace TreeWalk;


public class Program
{
    static void Main()
    {
        var node = new Node("Node1",new("Node2", new("Node3")));

        node.Traverse();
        node.PrintAllNames();

    }



}