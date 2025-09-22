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

class Result
{
    private static void CheckConstraint(int n, List<int> arr)
    {
        if (n<100 || n>1000000 )
        {
            throw new AggregateException("Constraint violated: n must be between 100 to 1000000");
        }

        if (arr.Count != n)
        {
            throw new ArgumentException($"Constrainr violated: The number of elements in the list ({arr.Count}) does not match the provided size n ({n}).");
        }

        foreach (var item in arr) 
        {
            if (item < 0 || item > 99)
            {
                throw new ArgumentException($"Constraint violated: Array element {item} must be between 0 and 99.");  
            }
        }

    }

    private static List<int> CreateSortedListFormFrequencies(int[] frequencyAraay) 
    {
        var sortedList = new List<int>();

        for (int number = 0; number < frequencyAraay.Length; number++) 
        {
            int count = frequencyAraay[number];

            while (count > 0) 
            {
                sortedList.Add(number);
                count--;
            }
        }

        return sortedList;
    }

    public static List<int> countingSort(List<int> arr)
    {
        CheckConstraint(arr.Count, arr);
        var frequencyArray = new int[100];

        foreach (var number in arr)
        {
            frequencyArray[number]++;
        }

        return frequencyArray.ToList();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.countingSort(arr);

        Console.WriteLine(String.Join(" ", result));

        //textWriter.WriteLine(String.Join(" ", result));

        //textWriter.Flush();
        //textWriter.Close();
    }
}
