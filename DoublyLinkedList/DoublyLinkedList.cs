/*
 * DoublyLinkedList.NET
 * https://github.com/ZenLulz/DoublyLinkedList.NET
 *
 * Copyright 2013 ZenLulz ~ Jämes Ménétrey
 * Released under the MIT license
 *
 * Date: 2013-05-02
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace Binarysharp.Collections
{
    /// <summary>
    /// Represents a generic list of objects.
    /// </summary>
    public class DoublyLinkedList<T> : ICollection<T>
    {
        #region Properties
        /// <summary>
        /// Gets the node of the linked list at the specified index.
        /// </summary>
        /// <param name="index">The specified index.</param>
        /// <remarks>Complexity: O(n).</remarks>
        public DoublyLinkedNode<T> this[int index]
        {
            get
            {
                // Check if the index is not too big
                if (index < 0 || index > Count - 1)
                    throw new ArgumentOutOfRangeException("index");

                // Set the starting point
                var node = First;

                // Traverse the list
                for (var i = 0; i < index; i++)
                {
                    node = node.Next;
                }

                // Return the value of the node
                return node;
            }
        }

        /// <summary>
        /// The number of nodes in the linked list.
        /// </summary>
        /// <remarks>Complexity: O(1).</remarks>
        public int Count { get; private set; }

        /// <summary>
        /// The first node in the linked list.
        /// </summary>
        /// <remarks>Complexity: O(1).</remarks>
        public DoublyLinkedNode<T> First { get; private set; }

        /// <summary>
        /// States if the linked list is empty.
        /// </summary>
        /// <remarks>Complexity: O(1).</remarks>
        public bool IsEmpty
        {
            get { return First == null; }
        }

        /// <summary>
        /// Gets a value indicating whether the linked list is read-only.
        /// </summary>
        /// <remarks>Complexity: O(1).</remarks>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// The last node of the linked list.
        /// </summary>
        /// <remarks>Complexity: O(1).</remarks>
        public DoublyLinkedNode<T> Last { get; private set; }
        #endregion

        #region Constructors & Destructor
        /// <summary>
        /// Initializes the linked list with a value.
        /// </summary>
        /// <param name="value">The specified value.</param>
        public DoublyLinkedList(T value)
            : this()
        {
            AddLast(value);
        }
        /// <summary>
        /// Initializes the linked list with values.
        /// </summary>
        /// <param name="values">The specified values.</param>
        public DoublyLinkedList(IEnumerable<T> values)
            : this()
        {
            foreach (var value in values)
            {
                AddLast(value);
            }
        }
        /// <summary>
        /// Initializes the linked list.
        /// </summary>
        public DoublyLinkedList()
        {
            Clear();
        }
        #endregion

        #region Methods
        #region Add (Implementation of ICollection<T>
        /// <summary>
        /// Adds a value at the end of the linked list.
        /// </summary>
        /// <seealso cref="AddLast(T)"/>
        /// <remarks>Complexity: O(1).</remarks>
        public void Add(T item)
        {
            AddLast(item);
        }
        #endregion
        #region AddFirst
        /// <summary>
        /// Adds a value at the beginning of the linked list.
        /// </summary>
        /// <remarks>Complexity: O(1).</remarks>
        public void AddFirst(T value)
        {
            // Create a node
            var node = new DoublyLinkedNode<T>(value);
            // Increment the length
            Count++;

            // If the linked list is empty
            if (IsEmpty)
            {
                // The node is the last
                Last = node;
            }
            else
            {
                // Make the links
                First.Previous = node;
                node.Next = First;
            }

            // The node is the first
            First = node;
        }
        /// <summary>
        /// Adds values at the beginning of the linked list.
        /// </summary>
        /// <remarks>Complexity: O(1).</remarks>
        public void AddFirst(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                AddFirst(value);
            }
        }
        #endregion
        #region AddLast
        /// <summary>
        /// Adds a value at the end of the linked list.
        /// </summary>
        /// <remarks>Complexity: O(1).</remarks>
        public void AddLast(T value)
        {
            // Create a node
            var node = new DoublyLinkedNode<T>(value);
            // Increment the length
            Count++;

            // If the linked list is empty
            if (IsEmpty)
            {
                // The node is the first
                First = node;
            }
            else
            {
                // Make the links
                Last.Next = node;
                node.Previous = Last;
            }

            // The node is the last
            Last = node;
        }
        /// <summary>
        /// Adds values at the end of the linked list.
        /// </summary>
        /// <remarks>Complexity: O(1).</remarks>
        public void AddLast(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                AddLast(value);
            }
        }
        #endregion
        #region Clear
        /// <summary>
        /// Clears the linked list.
        /// </summary>
        /// <remarks>Complexity: O(1).</remarks>
        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }
        #endregion
        #region Contains (Implementation of ICollection<T>
        /// <summary>
        /// Determines whether the linked list contains a specific value.
        /// </summary>
        /// <remarks>Complexity: O(n).</remarks>
        public bool Contains(T item)
        {
            // Traverse the linked list
            foreach (var value in this)
            {
                if (value.Equals(item))
                    return true;
            }

            return false;
        }
        #endregion
        #region CopyTo (Implementation of ICollection<T>)
        /// <summary>
        /// Copies the elements of the linked list to an Array, starting at a particular Array index.
        /// </summary>
        /// <remarks>Complexity: O(n).</remarks>
        public void CopyTo(T[] array, int arrayIndex)
        {
            // Traverse the linked list
            foreach (var value in this)
            {
                array[arrayIndex++] = value;
            }
        }
        #endregion
        #region GetEnumerator (Implementation of IEnumerable<T>)
        /// <summary>
        /// Implementation of IEnumerable.
        /// </summary>
        /// <remarks>Complexity: O(n).</remarks>
        public IEnumerator<T> GetEnumerator()
        {
            // Set the starting point
            var node = First;

            // Traverse the list
            while (node != null)
            {
                // Return the value
                yield return node.Value;
                // Select the next node
                node = node.Next;
            }
        }
        /// <summary>
        /// Implementation of generic IEnumerable.
        /// </summary>
        /// <remarks>Complexity: O(n).</remarks>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        #region Insert
        /// <summary>
        /// Inserts the value at a specified index in the linked list.
        /// </summary>
        /// <remarks>Complexity: O(n).</remarks>
        public void Insert(int index, T value)
        {
            // Check the index
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException("index");

            // Create a node
            var newNode = new DoublyLinkedNode<T>(value);

            // If the position is the first
            if (index == 0)
            {
                AddFirst(value);
            }
            // If the position is the last
            else if (index == Count)
            {
                AddLast(value);
            }
            // Else the position is somewhere in the linked list
            else
            {
                // Increment the length
                Count++;

                // Set the starting point
                var currentNode = First;

                // Traverse the list
                for (var i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                // Make the links with the previous node
                newNode.Previous = currentNode.Previous;
                currentNode.Previous.Next = newNode;

                // Make the links with the next node
                currentNode.Previous = newNode;
                newNode.Next = currentNode;
            }
        }
        #endregion
        #region Remove (Implementation of ICollection<T>
        /// <summary>
        /// Removes the first occurrence of a specific object from the linked list.
        /// </summary>
        /// <remarks>Complexity: O(n).</remarks>
        public bool Remove(T item)
        {
            // Set the starting point
            var currentNode = First;

            // Traverse the list
            for (var i = 0; i < Count - 1; i++)
            {
                if (currentNode.Value.Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }
        #endregion
        #region RemoveAt
        /// <summary>
        /// Removes the value at a specified index in the linked list.
        /// </summary>
        /// <remarks>Complexity: O(n).</remarks>
        public void RemoveAt(int index)
        {
            // Check the index
            if (index < 0 || index > Count - 1)
                throw new ArgumentOutOfRangeException("index");

            // If the position is the first
            if (index == 0)
            {
                RemoveFirst();
            }
            // If the position is the last
            else if (index == Count - 1)
            {
                RemoveLast();
            }
            // Else the position is somewhere in the linked list
            else
            {
                // Decrment the length
                Count--;

                // Set the starting point
                var currentNode = First;

                // Traverse the list
                for (var i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                // Break the links
                currentNode.Next.Previous = currentNode.Previous;
                currentNode.Previous.Next = currentNode.Next;
            }
        }
        #endregion
        #region RemoveFirst
        /// <summary>
        /// Removes the first value of the linked list.
        /// </summary>
        /// <remarks>Complexity: O(1).</remarks>
        public void RemoveFirst()
        {
            // Check if the linked list is not empty
            if (!IsEmpty)
            {
                // Decrement the length
                Count--;
                // Get the first node
                var deleted = First;
                // Remove the link in the second node that refers the first
                deleted.Next.Previous = null;
                // Set the second node as first
                First = deleted.Next;
                // Remove the 'Next' link in the deleted node
                deleted.Next = null;
            }
        }
        #endregion
        #region RemoveLast
        /// <summary>
        /// Removes the last value of the linked list.
        /// </summary>
        /// <remarks>Complexity: O(1).</remarks>
        public void RemoveLast()
        {
            // Check if the linked list is not empty
            if (!IsEmpty)
            {
                // Decrement the length
                Count--;
                // Get the last node
                var deleted = Last;
                // Remove the link in the before-last node that refers the last
                deleted.Previous.Next = null;
                // Set the before-last node as last
                Last = deleted.Previous;
                // Remove the 'Previous' link in the deleted node
                deleted.Previous = null;
            }
        }
        #endregion
        #endregion
    }
}
