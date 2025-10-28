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
     * Complete the 'ClosestNumbers' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    private static void CheckConstraints(List<int> arr)
    {
        if (arr.Count < 2 || arr.Count > 2 * Math.Pow(10, 5))
            throw new ArgumentException($"Input array size (n={arr.Count}) violates constraint: 2 <= n <= 200000.");

        if (arr.Any(x => x < -Math.Pow(10, 7) || x > Math.Pow(10, 7)))
            throw new ArgumentException($"Violates value constraint: -10000000 <= arr[i] <= 10000000.");

        var uniqueCheck = new HashSet<int>();
        foreach (int val in arr)
        {
            if (!uniqueCheck.Add(val))
                throw new ArgumentException($"Input array contains duplicate element: {val}. All elements must be unique.");
        }
    }

    public static List<int> ClosestNumbers(List<int> arr)
    {
        CheckConstraints(arr);

        arr.Sort();
        int minimumAbsoluteValue = int.MaxValue;
        List<int> result = new List<int>();

        int previousElement = arr[0];

        foreach (int currentElement in arr.Skip(1))
        {
            int absoluteValue = currentElement - previousElement;

            if (absoluteValue <= minimumAbsoluteValue)
            {
                if (absoluteValue < minimumAbsoluteValue)
                {
                    minimumAbsoluteValue = absoluteValue;
                    result.Clear();
                }
                result.Add(previousElement);
                result.Add(currentElement);
            }

            previousElement = currentElement;
        }

        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.ClosestNumbers(arr);

        Console.WriteLine(string.Join(" ", result));
        //textWriter.WriteLine(String.Join(" ", result));

        //textWriter.Flush();
        //textWriter.Close();
    }
}