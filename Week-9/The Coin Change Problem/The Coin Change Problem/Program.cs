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
     * Complete the 'getWays' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. LONG_INTEGER_ARRAY c
     */

    private static void CheckConstraints(int n, List<long> c)
    {
        if (n < 1 || n > 250)
            throw new ArgumentException("The number of items (n) must be between 1 and 250, inclusive.");

        if (c.Any(coin => coin < 1 || coin > 50))
            throw new ArgumentException("The number of items (n) must be between 1 and 250, inclusive.");
    }

    public static long GetWays(int n, List<long> c)
    {
        CheckConstraints(n, c);

        var ways = new long[n + 1];

        ways[0] = 1;

        foreach (var coin in c)
        {
            for (var amount = coin; amount < n + 1; amount++)
            {
                ways[amount] += ways[amount - coin];
            }
        }

        return ways[n];
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<long> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt64(cTemp)).ToList();

        // Print the number of ways of making change for 'n' units using coins having the values given by 'c'

        long ways = Result.GetWays(n, c);

        Console.WriteLine(ways);

    }
}
