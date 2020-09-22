using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    public class Class1
    {
        private static void Main(string [] args)
        {
            Tree<int> tree = new Tree<int>(10);
            tree.AddChild(new Tree<int>(13, new Tree<int>(200), new Tree<int>(300)));
            Console.WriteLine(tree.ToString());

        }
    }
}
