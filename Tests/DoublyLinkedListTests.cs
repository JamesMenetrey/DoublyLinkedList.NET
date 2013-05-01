/*
 * DoublyLinkedList.NET
 * https://github.com/ZenLulz/DoublyLinkedList.NET
 *
 * Copyright 2013 ZenLulz ~ Jämes Ménétrey
 * Released under the MIT license
 *
 * Date: 2013-05-02
 */

using Binarysharp.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void Add()
        {
            var list = new DoublyLinkedList<int>(2);

            list.AddFirst(1);
            list.AddLast(3);
            list.AddFirst(0);
            list.AddLast(4);

            for (var i = 0; i < 5; i++)
            {
                Assert.AreEqual(i, list[i].Value);
            }
        }

        [TestMethod]
        public void Remove()
        {
            var list = new DoublyLinkedList<int>(new [] {0, 1, 2, 3, 4, 5});

            list.RemoveFirst();
            list.RemoveLast();
            list.RemoveFirst();
            list.RemoveLast();

            for (var i = 2; i < 4; i++)
            {
                Assert.AreEqual(i, list[i - 2].Value);
            }
        }

        [TestMethod]
        public void Insert()
        {
            var list = new DoublyLinkedList<int>(2);

            list.Insert(0, 0);
            list.Insert(1, 1);
            list.Insert(3, 3);

            for (var i = 0; i < 3; i++)
            {
                Assert.AreEqual(i, list[i].Value);
            }
        }

        [TestMethod]
        public void RemoveAt()
        {
            var list = new DoublyLinkedList<int>(new[] { 1, 2, 3 });

            list.RemoveAt(1);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list[0].Value);
            Assert.AreEqual(3, list[1].Value);
        }

        [TestMethod]
        public void CopyTo()
        {
            var list = new DoublyLinkedList<int>(new[] { 1, 2, 3 });
            var array = new int[4];

            list.CopyTo(array, 1);

            CollectionAssert.AreEqual(new[] {0, 1, 2, 3}, array);
        }

        [TestMethod]
        public void Clear()
        {
            var list = new DoublyLinkedList<int>(new[] { 1, 2, 3 });

            list.Clear();

            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.First);
            Assert.IsNull(list.Last);
        }

        [TestMethod]
        public void Contains()
        {
            var list = new DoublyLinkedList<int>(new[] { 1, 2, 3 });

            Assert.IsTrue(list.Contains(1));
            Assert.IsFalse(list.Contains(10));
        }

        [TestMethod]
        public void Traverse()
        {
            var list = new DoublyLinkedList<int>(new[] { 1, 2, 3 });

            // Perform various operations
            list.AddFirst(0);
            list.RemoveFirst();
            list.AddLast(0);
            list.RemoveLast();
            list.Insert(1, 0);
            list.RemoveAt(1);

            var current = list.First;

            while (current.Next != null)
            {
                current = current.Next;
            }
            Assert.AreEqual(list.Last, current);

            while (current.Previous != null)
            {
                current = current.Previous;
            }
            Assert.AreEqual(list.First, current);
        }
    }
}
