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

class SinglyLinkedListPrintHelepr
{
    public static void PrintList(SinglyLinkedListNode node, string sep)
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
}


class Result
{

    /*
     * Complete the 'RemoveDuplicates' function below.
     *
     * The function is expected to return an INTEGER_SINGLY_LINKED_LIST.
     * The function accepts INTEGER_SINGLY_LINKED_LIST llist as parameter.
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
    private static void CheckConstraints(SinglyLinkedListNode llist)
    {
        var currentNode = llist;
        var nodeCounter = 0;
        
        while (currentNode != null)
        {
            if (currentNode.data < 1 || currentNode.data > Math.Pow(10, 3))
                throw new ArgumentException("Node data must be between 1 and 1000.");

            nodeCounter++;

            currentNode = currentNode.next;
        }

        if (nodeCounter < 1 || nodeCounter > Math.Pow(10,3))
            throw new ArgumentException("The number of nodes must be between 1 and 1000.");
    }

    public static SinglyLinkedListNode RemoveDuplicatesUnsortedLinkedList(SinglyLinkedListNode llist)
    {
        if (llist == null)
            return null;

        var seenValues = new HashSet<int>();
        var currentNode = llist;
        SinglyLinkedListNode previousNode = null;

        while (currentNode != null)
        {
            if (!seenValues.Contains(currentNode.data))
            {
                seenValues.Add(currentNode.data);
                previousNode = currentNode;
            } 
            else
                previousNode.next = currentNode.next;

            currentNode = currentNode.next;
        }

        return llist;
    }

    public static SinglyLinkedListNode RemoveDuplicates(SinglyLinkedListNode llist)
    {
        CheckConstraints(llist);

        if (llist == null)
            return null;

        var currentNode = llist;

        while (currentNode != null)
        {
            if (currentNode.data == currentNode.next.data)
                currentNode.next = currentNode.next.next;
            else
                currentNode = currentNode.next;
        }

        return llist;
    }

}
class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine().Trim());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine().Trim());
                llist.InsertNode(llistItem);
            }

            SinglyLinkedListNode llist1 = Result.RemoveDuplicatesUnsortedLinkedList(llist.head);

            SinglyLinkedListPrintHelepr.PrintList(llist1, " ");
            Console.WriteLine();
        }

    }
}
