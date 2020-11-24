using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree1 = new Tree(1);
            Tree tree2 = new Tree(1);
            string s = "";
            Console.WriteLine("First tree: ");
            while ((s = Console.ReadLine()) != null)
            {
                if (s == "")
                    break;
                Tree.Add(int.Parse(s), tree1.root);
            }
            tree1.PrintByLevel();
            Console.WriteLine("Second tree : ");
            while ((s = Console.ReadLine()) != null)
            {
                if (s == "")
                    break;
                Tree.Add(int.Parse(s), tree2.root);
            }
            tree2.PrintByLevel();
            tree1 = tree1 + tree2;
            Console.WriteLine("Res of sum: ");
            tree1.PrintByLevel();
            Console.ReadKey();
        }
    }
}
