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
     * Complete the 'missingNumbers' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY arr
     *  2. INTEGER_ARRAY brr
     */
    private static void CheckConstraints(List<int> arr,List<int> brr)
    {
        if (arr.Count < 1 || arr.Count > 2 * Math.Pow(10, 5))
            throw new ArgumentOutOfRangeException(nameof(arr), $"Array 'arr' size is out of range [1, 200000].");

        if (brr.Count < 1 || brr.Count > 2 * Math.Pow(10, 5))
            throw new ArgumentOutOfRangeException(nameof(arr), $"Array 'brr' size is out of range [1, 200000].");

        if (arr.Count > brr.Count)
            throw new InvalidOperationException($"Constraint violated: n must be <= m.");

        if (brr.Any(x => x < 1 || x > Math.Pow(10, 5)))
            throw new ArgumentOutOfRangeException(nameof(brr), "All elements in 'brr' must be in range [1, 10000].");

        if (brr.Max() - brr.Min() > 100)
            throw new InvalidOperationException($"Constraint violated: 'max(brr) - min(brr)' exceeds 100.");


    }

    public static List<int> missingNumbers(List<int> arr, List<int> brr)
    {
        CheckConstraints(arr, brr);

        var counts = new Dictionary<int, int>();

        foreach (var value in arr)
        {
            if (counts.TryGetValue(value, out var count))
                counts[value] = count + 1;
            else
                counts[value] = 1;
        }

        var missing = new HashSet<int>();

        foreach(var value in brr)
        {
            if (counts.TryGetValue(value, out var count) && count > 0)
                counts[value] = count - 1;
            else
                missing.Add(value);
        }

        var result = missing.ToList();
        result.Sort();
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

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        List<int> result = Result.missingNumbers(arr, brr);

        Console.WriteLine(String.Join(" ", result));

        //textWriter.Flush();
        //textWriter.Close();
    }
}
