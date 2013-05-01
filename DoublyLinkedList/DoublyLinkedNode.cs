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
using System.Collections.Generic;

namespace Binarysharp.Collections
{
    /// <summary>
    /// Represents a generic linked node.
    /// </summary>
    public sealed class DoublyLinkedNode<T> : IEquatable<DoublyLinkedNode<T>>
    {
        /// <summary>
        /// The next node.
        /// </summary>
        public DoublyLinkedNode<T> Next { get; internal set; } 
        /// <summary>
        /// The previous node.
        /// </summary>
        public DoublyLinkedNode<T> Previous { get; internal set; }
        /// <summary>
        /// The value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Initializes the node with a value.
        /// </summary>
        /// <param name="value">The value used to be initialized.</param>
        public DoublyLinkedNode(T value) : this()
        {
            Value = value;
        }
        /// <summary>
        /// Initializes the node.
        /// </summary>
        public DoublyLinkedNode()
        {
            Next = null;
            Previous = null;
            Value = default(T);
        }
        /// <summary>
        /// Returns a string that represents the current node.
        /// </summary>
        public override string ToString()
        {
            return Value.ToString();
        }

        #region Equality things
        public bool Equals(DoublyLinkedNode<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public static bool operator ==(DoublyLinkedNode<T> left, DoublyLinkedNode<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DoublyLinkedNode<T> left, DoublyLinkedNode<T> right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is DoublyLinkedNode<T> && Equals((DoublyLinkedNode<T>)obj);
        }
        #endregion
    }
}
