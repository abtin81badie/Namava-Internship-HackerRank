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
    private const int MaxArraySize = 100;
    private static void CheckConstraint(int n, List<int> arr)
    {
        if (n < 100 || n > Math.Pow(10,6))
            throw new AggregateException("Constraint violated: n must be between 100 to 1000000");

        if (arr.Count != n)
            throw new ArgumentException($"Constraint violated: The number of elements in the list ({arr.Count}) does not match the provided size n ({n}).");

        if (arr.Any(item => item < 0 || item > 99))
            throw new ArgumentException("Constraint violated: One or more array elements are outside the valid range of 0 to 99.");

    }

    private static List<int> CreateSortedListFormFrequencies(int[] frequencyArray)
    {
        var sortedList = new List<int>();

        for (int number = 0; number < frequencyArray.Length; number++)
        {
            int count = frequencyArray[number];

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
        var frequencyArray = new int[MaxArraySize];

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
