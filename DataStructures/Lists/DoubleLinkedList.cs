using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Lists
{
    public class DoubleLinkedList
    {
        public Item Create(int val)
        {
            var list = new Item(val);
            return list;
        }

        public void InsertAsFirst(Item list, Item itemToInsert)
        {
            if (list.Previous == null)
            {
                itemToInsert.Next = list;
                list.Previous = itemToInsert;
                return;
            }

            InsertAsFirst(list.Previous, itemToInsert);
        }

        public void InsertAsEnd(Item list, Item item)
        {
            if (list.Next == null)
            {
                list.Next = item;
                item.Previous = list;
                return;
            }

            InsertAsEnd(list.Next, item);
        }

        public void Insert(Item list, int item)
        {
            if (list.Number >= item)
            {
                if (list.Previous != null)
                {
                    Insert(list.Previous, item);
                }
                else
                {
                    var listItem = new Item(item);
                    list.Previous = listItem;
                    listItem.Next = list;
                }
            }
            else
            {
                if (list.Next != null)
                {
                    if (list.Number < item && item <= list.Next.Number)
                    {
                        var item1 = new Item(item);
                        item1.Previous = list;
                        item1.Next = list.Next;

                        list.Next.Previous = item1;
                        list.Next = item1;

                        return;
                    }

                    Insert(list.Next, item);
                }
                else
                {
                    var listItem = new Item(item);
                    list.Next = listItem;
                    listItem.Previous = list;
                }
            }
        }
    }
}
