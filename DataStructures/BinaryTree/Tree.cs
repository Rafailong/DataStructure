using System;

namespace DataStructures.BinaryTree
{
    public class Tree
    {
        public Node Create()
        {
            var root = new Node(_grades[0]);
            for (int i = 1; i < _grades.Length; i++)
            {
                Node node1 = new Node(_grades[i]);
                root.AddChild(node1);
            }

            return root;
        }

        public void PrintInOrder(Node root)
        {
            if (root.Left != null)
            {
                PrintInOrder(root.Left);
            }

            if (root.Right != null)
            {
                Console.WriteLine(root.Grade);
                PrintInOrder(root.Right);
            }
            else
            {
                Console.WriteLine(root.Grade);
            }
        }

        public void PrintPostOrder(Node root)
        {
            if (root.Left != null)
            {
                PrintPostOrder(root.Left);
            }

            if (root.Right != null)
            {
                PrintPostOrder(root.Right);
            }
            
            Console.WriteLine(root.Grade);
        }

        public void PrintPreOrder(Node root)
        {
            Console.WriteLine(root.Grade);

            if (root.Left != null)
            {
                PrintPreOrder(root.Left);
            }

            if (root.Right != null)
            {
                PrintPreOrder(root.Right);
            }
        }

        private int[] _grades = {3, 1, 5, 64, 235, 23, 34, 634, 6, 546};
    }
}