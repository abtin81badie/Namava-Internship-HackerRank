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
     * Complete the 'bigSorting' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY unsorted as parameter.
     */
    private static void CheckConstraints(List<string> unsorted)
    {
        if (unsorted.Count < 1 || unsorted.Count > 2 * Math.Pow(10,5))
            throw new ArgumentException($"n is out of range. Must be between 1 and 200,000.");

        if (unsorted.Any(s => !s.All(char.IsDigit)))
            throw new ArgumentException("Found a string containing non-digit characters.");

        if (unsorted.Any(s => s.StartsWith("0")))
            throw new ArgumentException("Found a string with a leading zero.");

        long totalDigits = unsorted.Sum(s => (long)s.Length);
        if (totalDigits < 1 || totalDigits > Math.Pow(10,6))
            throw new ArgumentException($"Total digits ({totalDigits}) is out of range.");
    }

    public static List<string> bigSorting(List<string> unsorted)
    {
        CheckConstraints(unsorted);

        unsorted.Sort((a,b) =>
        {
            if (a.Length != b.Length)
                return a.Length.CompareTo(b.Length);

            return string.Compare(a, b);
        });

        return unsorted;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> unsorted = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string unsortedItem = Console.ReadLine();
            unsorted.Add(unsortedItem);
        }

        List<string> result = Result.bigSorting(unsorted);

        Console.WriteLine(String.Join("\n", result));

    }
}
