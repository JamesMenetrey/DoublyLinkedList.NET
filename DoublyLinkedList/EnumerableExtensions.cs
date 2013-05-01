/*
 * DoublyLinkedList.NET
 * https://github.com/ZenLulz/DoublyLinkedList.NET
 *
 * Copyright 2013 ZenLulz ~ Jämes Ménétrey
 * Released under the MIT license
 *
 * Date: 2013-05-02
 */

using System.Collections.Generic;

namespace Binarysharp.Collections
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Converts an <see cref="IEnumerable&lt;T&gt;"/> interface to a doubly linked list.
        /// </summary>
        public static DoublyLinkedList<T> ToDoublyLinkedList<T>(this IEnumerable<T> enumerable)
        {
            return new DoublyLinkedList<T>(enumerable);
        }
    }
}
