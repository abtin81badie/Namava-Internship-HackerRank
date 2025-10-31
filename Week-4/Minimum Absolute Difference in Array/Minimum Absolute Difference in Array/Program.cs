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
     * Complete the 'MinimumAbsoluteDifference' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    private static void CheckConstraints(List<int> arr)
    {

        int n = arr.Count;

        if (arr.Count < 2 || arr.Count > 100000)
            throw new ArgumentException($"List size constraint violated. Expected 2 <= n <= 100,000, but got n = {n}.");

        if (arr.Any(number => number < -Math.Pow(10, 9) || number > Math.Pow(10, 9)))
            throw new ArgumentException($"Value constraint violated. Expected -10^9 <= val <= 10^9.");
    }

    public static int MinimumAbsoluteDifference(List<int> arr)
    {
        CheckConstraints(arr);

        arr.Sort();
        int minimumDifference = int.MaxValue;

        int previousItem = 0;
        bool isFirstItem = true;

        foreach (int currentItem in arr)
        {
            if (isFirstItem)
            {
                previousItem = currentItem;
                isFirstItem = false;
            }
            else
            {
                int absoluteDifference = currentItem - previousItem;

                if (absoluteDifference < minimumDifference)
                    minimumDifference = absoluteDifference;

                previousItem = currentItem;
            }
        }

        return minimumDifference;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.MinimumAbsoluteDifference(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
