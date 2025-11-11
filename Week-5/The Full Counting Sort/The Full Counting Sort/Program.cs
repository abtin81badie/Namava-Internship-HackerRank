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
     * Complete the 'countSort' function below.
     *
     * The function accepts 2D_STRING_ARRAY arr as parameter.
     */
    private const int maxKey = 100;

    private static void CheckConstraints(List<List<string>> arr)
    {
        if (arr.Count < 1 || arr.Count > Math.Pow(10, 6))
            throw new ArgumentOutOfRangeException(nameof(arr), $"Number of rows n is out of allowed range [1, 1_000_000].");

        if (arr.Count % 2 != 0)
            throw new ArgumentException($"Constraint violated: n must be even.");

        for (int i = 0; i < arr.Count; i++)
        {
            var row = arr[i];
            if (row == null)
                throw new ArgumentNullException(nameof(arr), $"Row {i} is null.");

            if (row.Count != 2)
                throw new ArgumentException($"Row {i} must contain exactly 2 elements: an integer and a string.");

            if (!int.TryParse(row[0], out int key))
                throw new ArgumentException($"Row {i}: '{row[0]}' is not a valid integer key.");

            if (key < 0 || key > 99)
                throw new ArgumentOutOfRangeException(nameof(arr),
                    $"Row {i}: key={key} is out of allowed range [0, 99].");

            string s = row[1] ?? string.Empty;

            if (s.Any(c => c < 'a' || c > 'z'))
                throw new ArgumentException(
                    $"Row {i}: string '{s}' contains invalid characters. Only 'a'-'z' allowed.");
        }


    }

    public static void countSort(List<List<string>> arr)
    {
        CheckConstraints(arr);

        var buckets = Enumerable.Range(0, maxKey)
                            .Select(_ => new List<string>())
                            .ToList();

        for (int i = 0; i < arr.Count; i++)
        {
            int.TryParse(arr[i][0], out var key);

            string value = (i < arr.Count / 2) ? "-" : arr[i][1];

            buckets[key].Add(value);
        }

        var output = string.Join(' ', buckets.SelectMany(bucket => bucket));

        Console.WriteLine(output);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<string>> arr = new List<List<string>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
        }

        Result.countSort(arr);
    }
}
