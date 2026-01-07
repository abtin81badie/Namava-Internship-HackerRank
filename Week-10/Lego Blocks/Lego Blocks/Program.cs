using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

class Result
{

    /*
    * Complete the 'LegoBlocks' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts following parameters:
    *  1. INTEGER n
    *  2. INTEGER m
    */
    private const long MOD = 1000000007;

    private static void CheckConstraints(int n, int m)
    {
        if (n < 1 || n > 1000)
            throw new ArgumentOutOfRangeException(
                nameof(n),
                $"n must be between 1 and 1000. Value was: {n}");

        if (m < 1 || m > 1000)
            throw new ArgumentOutOfRangeException(
                nameof(m),
                $"m must be between 1 and 1000. Value was: {m}");
    }

    private static long[] SingleRowWays(int m)
    {
        var rowWays = new long[m + 1];
        rowWays[0] = 1;

        for (var w = 1; w <= m; w++)
        {
            long sum = 0;
            for (var brick = 1; brick <= 4; brick++)
            {
                if (w - brick >= 0)
                    sum = (sum + rowWays[w - brick]) % MOD;
            }

            rowWays[w] = sum;
        }

        return rowWays;
    }

    public static int LegoBlocks(int n, int m)
    {
        // Validate inputs first
        CheckConstraints(n, m);

        // Step 1: Single Row Permutations
        var rowWays = SingleRowWays(m);

        // Step 2: Total Walls
        var totalWays = new long[m + 1];
        for (var w = 1; w <= m; w++)
        {
            totalWays[w] = (long)BigInteger.ModPow(rowWays[w], n, MOD);
        }

        // Step 3: Solid Walls
        var solid = new long[m + 1];
        solid[0] = 1;

        for (var w = 1; w <= m; w++)
        {
            long ways = totalWays[w];

            for (var j = 1; j < w; j++)
            {
                long invalid = (solid[j] * totalWays[w - j]) % MOD;

                ways = (ways - invalid + MOD) % MOD;
            }

            solid[w] = ways;
        }

        return (int)solid[m];
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.LegoBlocks(n, m);

            Console.WriteLine(result);
        }
    }
}
