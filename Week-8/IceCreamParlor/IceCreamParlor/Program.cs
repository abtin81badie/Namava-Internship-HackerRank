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

    /*
     * Complete the 'icecreamParlor' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER m
     *  2. INTEGER_ARRAY arr
     */
    private static void CheckConstraints(int m, List<int> arr)
    {
        if (m < 2
            || m > Math.Pow(10, 4))
            throw new ArgumentException("Money must be between 2 and 10,000.");

        if (arr.Count < 1
            || arr.Count > Math.Pow(10, 4))
            throw new ArgumentException("The number of costs must be between 1 and 10,000.");

        if (arr.Any(cost => cost < 1
            || cost > Math.Pow(10, 4)))
            throw new ArgumentException("Each cost must be between 1 and 10,000.");

    }

    public static List<int> IceCreamParlor(int m, List<int> arr)
    {
        CheckConstraints(m, arr);

        var seenIndex = new Dictionary<int, int>();

        for (var i = 0; i < arr.Count; i++)
        {
            var cost = arr[i];
            var remaining = m - cost;

            if (seenIndex.TryGetValue(remaining, out var index))
                return new List<int> { index, i + 1 };

            if (!seenIndex.ContainsKey(cost))
                seenIndex[cost] = i + 1;
        }

        return new List<int>();
    }


}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int m = Convert.ToInt32(Console.ReadLine().Trim());

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Result.IceCreamParlor(m, arr);

            Console.WriteLine(String.Join(" ", result));
        }

    }
}
