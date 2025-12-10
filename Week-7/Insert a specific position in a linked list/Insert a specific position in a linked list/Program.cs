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

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
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
         * Complete the 'insertNodeAtPosition' function below.
         *
         * The function is expected to return an INTEGER_SINGLY_LINKED_LIST.
         * The function accepts following parameters:
         *  1. INTEGER_SINGLY_LINKED_LIST llist
         *  2. INTEGER data
         *  3. INTEGER position
         */

        /*
         * For your reference:
         *
         * SinglyLinkedListNode
         * {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        private static void CheckConstraints(SinglyLinkedListNode llist, int data, int position)
        {
            var nodeCounter = 0;
            var currentNode = llist;

            while (currentNode != null)
            {
                nodeCounter++;

                if (currentNode.data < 1 || currentNode.data > 1000)
                    throw new ArgumentOutOfRangeException(nameof(llist),
                        "Each node's data must satisfy: 1 <= data <= 1000.");

                currentNode = currentNode.next;
            }

            if (nodeCounter < 1 || nodeCounter > 1000)
                throw new ArgumentOutOfRangeException(nameof(llist),
                    "The linked list size must satisfy: 1 <= nodeCounter <= 1000.");

            if (data < 1 || data > 1000)
                throw new ArgumentOutOfRangeException(nameof(data),
                    "Inserted node data must satisfy:  1 <= data <= 1000.");

            if (position < 0 || position > nodeCounter)
                throw new ArgumentOutOfRangeException(nameof(position),
                    "Position must satisfy: 0 <= position <= nodePosition.");
        }
  

        public static SinglyLinkedListNode InsertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
        {
            CheckConstraints(llist,data,position);

            var newNode = new SinglyLinkedListNode(data);
            var currentNode = llist;
            var currentPosition = 0;

            if (llist == null || position == 0)
            {
                newNode.next = llist;
                return newNode;
            }

            while (currentNode.next != null && currentPosition < position - 1)
            {
                currentNode = currentNode.next;
                currentPosition++;
            }


            newNode.next = currentNode.next;
            currentNode.next = newNode;

            return llist;
        }

    }

    static void Main(string[] args)
    {
        SinglyLinkedList llist = new SinglyLinkedList();

        int llistCount = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < llistCount; i++)
        {
            int llistItem = Convert.ToInt32(Console.ReadLine());
            llist.InsertNode(llistItem);
        }

        int data = Convert.ToInt32(Console.ReadLine());

        int position = Convert.ToInt32(Console.ReadLine());

        SinglyLinkedListNode llist_head = Result.InsertNodeAtPosition(llist.head, data, position);

        PrintSinglyLinkedList(llist_head, " ");
        Console.WriteLine();

    }
}
