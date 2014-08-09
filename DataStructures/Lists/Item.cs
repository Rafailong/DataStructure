using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Lists
{
    public class Item
    {
        public Item Next;

        public Item Previous;

        public Item(int number)
        {
            Number = number;
        }

        public int Number { get; private set; }
    }
}
