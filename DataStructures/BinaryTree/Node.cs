using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace DataStructures.BinaryTree
{
    public class Node
    {
        public Node(int grade)
        {
            this.Grade = grade;
            Console.WriteLine("Nuevo Node con Grade: {0}", this.Grade);
        }
        
        public int Grade { get; private set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node Parent { get; set; }

        public bool IsRoot
        {
            get
            {
                return (this.Left == null) && (this.Right == null);
            }
        }

        public void AddChild(Node child)
        {
            if (child.Grade > this.Grade)
            {
                if (this.Right == null)
                {
                    child.Parent = this;
                    this.Right = child;
                    return;
                }

                this.Right.AddChild(child);
                return;
            }

            if (child.Grade < this.Grade)
            {
                if (this.Left == null)
                {
                    child.Parent = this;
                    this.Left = child;
                    return;
                }

                this.Left.AddChild(child);
            }
        }
    }
}
