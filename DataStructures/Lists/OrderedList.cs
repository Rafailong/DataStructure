using NUnit.Framework;

namespace DataStructures.Lists
{
    public class OrderedList
    {
        private static Node<int> _root;

        public Node<int> Create(int initValue)
        {
            return (_root = new Node<int>(initValue));
        }

        public void Add(int i)
        {
            var node = new Node<int>(i);
            AddItem(_root, node);
        }

        private void AddItem(Node<int> list, Node<int> item)
        {
            if (item.Data >= list.Data)
            {
                if (list.NextNode != null)
                {
                    if (list.NextNode.Data > item.Data)
                    {
                        item.NextNode = list.NextNode;
                        list.NextNode = item;
                    }
                    else
                    {
                        AddItem(list.NextNode, item);
                    }
                }
                else
                {
                    list.NextNode = item;
                }
            }
            else
            {
                int data = _root.Data;
                _root.Data = item.Data;
                item.Data = data;

                item.NextNode = _root.NextNode;
                _root.NextNode = item;
            }
        }

        private void RemoveItem(Node<int> list, int itemData)
        {
            if (list.Data == itemData)
            {
                if (list.NextNode != null)
                {
                    list.Data = list.NextNode.Data;
                    list.NextNode = list.NextNode.NextNode;
                }
            }
            else if (list.Data < itemData && list.NextNode != null)
            {
                if (list.NextNode.Data == itemData)
                {
                    if (list.NextNode.NextNode == null)
                    {
                        list.NextNode = null;
                    }
                    else
                    {
                        list.NextNode.Data = list.NextNode.Data;
                        list.NextNode = list.NextNode.NextNode;
                    }
                }
                else
                {
                    RemoveItem(list.NextNode, itemData);
                }
            }
        }

        public void Remove(int i)
        {
            RemoveItem(_root, i);
        }
    }

    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public Node<T> NextNode { get; set; }

        public T Data { get; set; }
    }

    [TestFixture]
    public class OrderedListTests
    {
        [SetUp]
        public void SetUp()
        {
            _orderedList = new OrderedList();
        }

        private OrderedList _orderedList;

        [Test]
        public void AddItemAtTheEnd()
        {
            Node<int> list = _orderedList.Create(1);

            _orderedList.Add(7);

            _orderedList.Add(5);

            _orderedList.Add(0);

            _orderedList.Add(10);

            _orderedList.Remove(5);

            _orderedList.Remove(10);

            _orderedList.Remove(0);
        }

        [Test]
        public void CreateList()
        {
            Node<int> root = _orderedList.Create(7);

            Assert.That(_orderedList, Is.Not.Null);
            Assert.That(root.Data, Is.EqualTo(7));
        }
    }
}