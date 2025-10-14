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
     * Complete the 'SockMerchant' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY ar
     */
    private static void CheckConstraint(int n, List<int> ar)
    {
        if (n < 1 || n > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "Constraint violated: The number of socks (n) must be between 1 and 100.");
        }

        if (ar == null || ar.Count != n)
        {
            throw new ArgumentException($"Constraint violated: The sock list must contain exactly {n} items.", nameof(ar));
        }

        if (ar.Any(sockColor => sockColor < 1 || sockColor > 100))
        {
            throw new ArgumentOutOfRangeException(nameof(ar), "Constraint violated: All sock colors must be between 1 and 100.");
        }
    }

    public static int SockMerchantLinq(int n, List<int> ar)
    {
        return ar.GroupBy(sockColor => sockColor)
            .Select(group => group.Count() / 2)
            .Sum();
    }

    public static int SockMerchantHashSet(int n, List<int> ar)
    {
        var unpairedSocks = new HashSet<int>();
        int totalPairs = 0;

        foreach (var sockColor in ar)
        {
            if (unpairedSocks.Contains(sockColor))
            {
                totalPairs++;
                unpairedSocks.Remove(sockColor);
            }
            else
                unpairedSocks.Add(sockColor);
        }

        return totalPairs;
    }

    public static int SockMerchant(int n, List<int> ar)
    {
        var sockCounts = new Dictionary<int, int>();

        foreach (var sockColor in ar)
        {
            if (sockCounts.ContainsKey(sockColor))
                sockCounts[sockColor]++;
            else
                sockCounts[sockColor] = 1;
        }

        int totalPairs = 0;

        foreach (var count in sockCounts.Values)
        {
            totalPairs += count / 2;
        }

        return totalPairs;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.SockMerchantHashSet(n, ar);

        Console.WriteLine(result);
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
