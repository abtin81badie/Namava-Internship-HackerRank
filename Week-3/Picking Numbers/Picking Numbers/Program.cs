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
    public static void CheckConstraints(List<int> a)
    {
        if (a.Count < 2 || a.Count > 100)
            throw new ArgumentOutOfRangeException(nameof(a), "Input array size must be between 2 and 100.");

        if (a.Any(x => x <= 0 || x >= 100))
            throw new ArgumentOutOfRangeException(nameof(a), $"Elements in the array must be between 1 and 99.");
    }

    /*
     * Complete the 'PickingNumbers' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */
    public static int PickingNumbers(List<int> a)
    {
        CheckConstraints(a);

        int[] frequency = new int[100];

        foreach (int number in a)
        {
            frequency[number]++;
        }

        return Enumerable.Range(0, 99)
                         .Select(i => frequency[i] + frequency[i + 1])
                         .Max();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.PickingNumbers(a);

        Console.WriteLine(result);
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
