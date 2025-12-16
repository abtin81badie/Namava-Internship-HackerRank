using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    class DoublyLinkedListNode
    {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;

        public DoublyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
            this.prev = null;
        }
    }

    class DoublyLinkedList
    {
        public DoublyLinkedListNode head;
        public DoublyLinkedListNode tail;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
                node.prev = this.tail;
            }

            this.tail = node;
        }
    }

    static void PrintDoublyLinkedList(DoublyLinkedListNode node, string sep)
    {
        while (node != null)
        {
            Console.Write(node.data);

            node = node.next;

            if (node != null)
            {
                Console.Write(sep);
            }
        }
    }

    class Result
    {

        /*
         * Complete the 'sortedInsert' function below.
         *
         * The function is expected to return an INTEGER_DOUBLY_LINKED_LIST.
         * The function accepts following parameters:
         *  1. INTEGER_DOUBLY_LINKED_LIST llist
         *  2. INTEGER data
         */

        /*
         * For your reference:
         *
         * DoublyLinkedListNode
         * {
         *     int data;
         *     DoublyLinkedListNode next;
         *     DoublyLinkedListNode prev;
         * }
         *
         */
        private static void CheckConstraints(DoublyLinkedListNode llist, int data)
        {
            var currentNode = llist;
            var count = 0;

            while (currentNode != null)
            {
                if (currentNode.data < 1
                    || currentNode.data > 1000)
                    throw new Exception($"Constraint Violation: 'data' must be between 1 and 1000.");

                currentNode = currentNode.next;
                count++;
            }

            if (count < 1
                || count > 1000)
                throw new Exception($"Constraint Violation: 'n' must be between 1 and 1000.");
        }

        public static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode llist, int data)
        {
            CheckConstraints(llist, data);  

            var newNode = new DoublyLinkedListNode(data);

            if (llist == null)
                return newNode;

            if (data <= llist.data)
            {
                newNode.next = llist;
                llist.prev = newNode;
                return newNode;
            }

            var currentNode = llist;

            while (currentNode != null
                && currentNode.next.data < data)
            {
                currentNode = currentNode.next;
            }

            newNode.next = currentNode.next;
            newNode.prev = currentNode;
            if (currentNode.next != null)
                currentNode.next.prev = newNode;
            currentNode.next = newNode;

            return llist;
        }

    }

    static void Main(string[] args)
    {

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            DoublyLinkedList llist = new DoublyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                llist.InsertNode(llistItem);
            }

            int data = Convert.ToInt32(Console.ReadLine());

            DoublyLinkedListNode llist1 = Result.sortedInsert(llist.head, data);

            PrintDoublyLinkedList(llist1, " ");
            Console.WriteLine();
        }

    }
}
