using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    using BinaryTree;

    class Program
    {
        static void Main(string[] args)
        {
            /*Tree tree = new Tree();
            Node node = tree.Create();

            Console.WriteLine("In Order");
            tree.PrintInOrder(node);

            Console.WriteLine();
            Console.WriteLine();
            
            Console.WriteLine("Post Order");
            tree.PrintPostOrder(node);

            Console.WriteLine();
            Console.WriteLine();
            
            Console.WriteLine("Pre Order");
            tree.PrintPreOrder(node);
*/
            var one = "omar".ToCharArray();
            Array.Sort(one);
            bool @equals = "omar".Equals(new string(one));
            var s = new string(one);
        }

        public void check_anagrams(string[] firstWords, string[] secondWords)
        {
            int length = firstWords.Length >= secondWords.Length ? firstWords.Length : secondWords.Length;

            for (int i = 0; i < length; i++)
            {
                var one = firstWords[i].ToCharArray();
                var two = secondWords[i].ToCharArray();

                Array.Sort(one);
                Array.Sort(two);
                var oneS = new string(one);
                var twoS = new string(two);
                Console.WriteLine("{0} and {1} are anagram? {2}",
                oneS,
                twoS,
                oneS.Equals(twoS));
            }
        }
    }
}
