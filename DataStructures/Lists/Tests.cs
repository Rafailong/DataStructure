using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Lists
{
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Item _item;
        private DoubleLinkedList _doubleLinkedList;
        private Random _random;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            _doubleLinkedList = new DoubleLinkedList();
            _item = _doubleLinkedList.Create(4);
            _random = new Random();
        }

        [Test]
        public void T_01_InsertAsFirst()
        {
            var toInsert = new Item(_random.Next(100));
            _doubleLinkedList.InsertAsFirst(_item, toInsert);

            Assert.That(_item.Previous, Is.Not.Null);
            Assert.That(toInsert.Number, Is.EqualTo(_item.Previous.Number));
        }

        [Test]
        public void T_02_InsertAtEnd()
        {
            var item = new Item(_random.Next(100));
            _doubleLinkedList.InsertAsEnd(_item, item);

            Assert.That(_item.Next, Is.Not.Null);
            Assert.That(_item.Next.Number, Is.EqualTo(item.Number));
        }

        [Test]
        public void T_03_InsertMany()
        {
            var ints = new [] { 1, 6234, 3, 445, 7, 657, 345, 23, 42, 13, 765, 23, 55, 67, 35, 235, 8 };

            foreach (int t in ints)
            {
                _doubleLinkedList.Insert(_item, t);
            }

            while (_item.Previous != null)
            {
                _item = _item.Previous;
            }

            while (_item.Next != null)
            {
                Console.WriteLine(_item.Number);
                _item = _item.Next;
            }
        }
    }
}
