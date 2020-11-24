using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTree
{
    class Node
    {
        public int X { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }

        public Node(int x)
        {
            this.X = x;
            left = null;
            right = null;
        }
        public Node() { }
    }
    class Tree
    {
        public Node root { get; set; }

        public Tree(int x)
        {
            root = new Node(x);
        }
        public static void Add(int x, Node temp)
        {
            if (temp == null)
            {
                temp = new Node(x);
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(temp);

            while (q.Count != 0)
            {
                temp = q.Peek();
                q.Dequeue();

                if (temp.left == null)
                {
                    temp.left = new Node(x);
                    break;
                }
                else
                    q.Enqueue(temp.left);

                if (temp.right == null)
                {
                    temp.right = new Node(x);
                    break;
                }
                else
                    q.Enqueue(temp.right);
            }
        }
        public void PrintByLevel()
        {  
            if (root == null)
                return;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);  

            while (true)
            {
                int nodeCount = q.Count;
                if (nodeCount == 0)
                    break;

                // Берем из очереди все узлы на текущем уровне  
                // и вставляем в очередь все узлы следующего уровня  
                while (nodeCount > 0)
                {
                    Node node = q.Peek();

                    Console.Write(node.X + " ");

                    q.Dequeue();

                    if (node.left != null)
                        q.Enqueue(node.left);

                    if (node.right != null)
                        q.Enqueue(node.right);

                    nodeCount--;
                }
                Console.WriteLine();
            }
        }
        public static Tree operator +(Tree tree1, Tree tree2)
        {
            if (tree1.root == null || tree2.root == null)
                throw new Exception("are null");

            Queue<Node> q1 = new Queue<Node>();
            Queue<Node> q2 = new Queue<Node>();

            q1.Enqueue(tree1.root);
            q2.Enqueue(tree2.root);

            Node temp1, temp2;

            while (q1.Count != 0 && q2.Count != 0)
            {
                temp1 = q1.Peek();
                temp2 = q2.Peek();
                q1.Dequeue();
                q2.Dequeue();
                if (temp1.left == null && temp2.left == null)
                {
                    continue;
                }
                else
                {
                    temp1.left.X += temp2.left.X;
                    q1.Enqueue(temp1.left);
                    q2.Enqueue(temp2.left);
                }

                if (temp1.right == null && temp2.right == null)
                {
                    continue;
                }
                else
                {
                    temp1.right.X += temp2.right.X;
                    q1.Enqueue(temp1.right);
                    q2.Enqueue(temp2.right);
                }
            }

            tree1.root.X += tree2.root.X;

            return tree1;
        }
    }
}
