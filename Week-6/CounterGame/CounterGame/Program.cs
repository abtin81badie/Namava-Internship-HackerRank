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
     * Complete the 'CounterGame' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts LONG_INTEGER n as parameter.
     */
    private static void CheckConstraints(long n)
    {
        if (n < 1 || n > Math.Pow(2, 64) - 1)
            throw new ArgumentException($"Input value {n} is out of range. It must be between 1 and 2^64 - 1.");
    }

    private static long GetLargestPowerOf2(long n)
    {
        long power = 1;

        while ((power << 1) <= n)
            power <<= 1;

        return power;
    }

    private static int PlayRecursively(long currentN)
    {
        if (currentN == 1)
            return 0;

        if ((currentN & (currentN - 1)) == 0)
            return 1 + PlayRecursively(currentN / 2);
        else
        {
            var nextLowerPower = GetLargestPowerOf2(currentN);
            return 1 + PlayRecursively(currentN - nextLowerPower);
        }

    }

    public static string CounterGame(long n)
    {
        CheckConstraints(n);

        var totalMoves = PlayRecursively(n);

        return (totalMoves % 2 == 0) ? "Richard" :  "Louise";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            long n = Convert.ToInt64(Console.ReadLine().Trim());

            string result = Result.CounterGame(n);

            Console.WriteLine(result);
        }
    }
}
