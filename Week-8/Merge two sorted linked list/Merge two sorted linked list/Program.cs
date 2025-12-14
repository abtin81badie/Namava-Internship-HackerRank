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
using System.Security;

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

    // Complete the mergeLists function below.

    /*
     * For your reference:
     *
     * SinglyLinkedListNode {
     *     int data;
     *     SinglyLinkedListNode next;
     * }
     *
     */
    private static void CheckConstraints(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {
        var countOne = 0;
        var countTwo = 0;

        while (head1 != null)
        {
            if (head1.data < 1 || head1.data > 1000)
                throw new ArgumentException($"Constraint violation in List 1: Element value {head1.data} is out of range. Must be between 1 and 1000.");
            head1 = head1.next;
            countOne++;
        }

        while (head2 != null)
        {
            if (head2.data < 1 || head2.data > 1000)
                throw new ArgumentException($"Constraint violation in List 2: Element value {head2.data} is out of range. Must be between 1 and 1000.");
            head2 = head2.next;
            countTwo++;
        }

        if (countOne < 1 || countTwo < 1 || countOne > 1000 || countTwo > 1000)
            throw new ArgumentException($"Constraint violation: List lengths must be between 1 and 1000. Found List 1 length: {countOne}, List 2 length: {countTwo}.");
    }

    static SinglyLinkedListNode MergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {
        CheckConstraints(head1, head2);

        var dummyNode = new SinglyLinkedListNode(0);
        var current = dummyNode;

        current.next = head1 ?? head2;

        while (head1 != null
                && head2 != null)
        {
            if (head1.data <= head2.data)
            {
                current.next = head1;
                head1 = head1.next;
            }
            else
            {
                current.next = head2;
                head2 = head2.next;
            }

            current = current.next;
        }

        if (head1 != null)
            current.next = head1;
        else
            current.next = head2;

        return dummyNode.next;
    }

    static void Main(string[] args)
    {
        int tests = Convert.ToInt32(Console.ReadLine());

        for (int testsItr = 0; testsItr < tests; testsItr++)
        {
            SinglyLinkedList llist1 = new SinglyLinkedList();

            int llist1Count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llist1Count; i++)
            {
                int llist1Item = Convert.ToInt32(Console.ReadLine());
                llist1.InsertNode(llist1Item);
            }

            SinglyLinkedList llist2 = new SinglyLinkedList();

            int llist2Count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llist2Count; i++)
            {
                int llist2Item = Convert.ToInt32(Console.ReadLine());
                llist2.InsertNode(llist2Item);
            }

            SinglyLinkedListNode llist3 = MergeLists(llist1.head, llist2.head);

            PrintSinglyLinkedList(llist3, " ");
            Console.WriteLine();
        }

    }
}
