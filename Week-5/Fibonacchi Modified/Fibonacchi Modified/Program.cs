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
using System.Numerics; // 1. Added this namespace

class Result
{

    /*
     * Complete the 'FibonacciModified' function below.
     *
     * The function is expected to return an INTEGER. // Note: HackerRank comment is misleading
     * The function accepts following parameters:
     * 1. INTEGER t1
     * 2. INTEGER t2
     * 3. INTEGER n
     */
    private static void CheckConstraints(int t1, int t2, int n)
    {
        if (t1 < 0 || t1 > 2)
            throw new ArgumentException($"Input constraint violation: t1 must be between 0 and 2 (inclusive). Received: {t1}", nameof(t1));

        if (t2 < 0 || t2 > 2)
            throw new ArgumentException($"Input constraint violation: t2 must be between 0 and 2 (inclusive). Received: {t2}", nameof(t2));

        if (n < 3 || n > 20)
            throw new ArgumentException($"Input constraint violation: n must be between 3 and 20 (inclusive). Received: {n}", nameof(n));
    }

    public static BigInteger FibonacciModified(int t1, int t2, int n)
    {
        CheckConstraints(t1, t2, n);

        var fibonacciModifiedArray = new BigInteger[n];

        fibonacciModifiedArray[0] = (BigInteger)t1;
        fibonacciModifiedArray[1] = (BigInteger)t2;

        for (int i = 2; i < n; i++)
        {
            fibonacciModifiedArray[i] = fibonacciModifiedArray[i - 2] + BigInteger.Pow(fibonacciModifiedArray[i - 1], 2);
        }

        return fibonacciModifiedArray[n - 1];
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int t1 = Convert.ToInt32(firstMultipleInput[0]);

        int t2 = Convert.ToInt32(firstMultipleInput[1]);

        int n = Convert.ToInt32(firstMultipleInput[2]);

        BigInteger result = Result.FibonacciModified(t1, t2, n);

        Console.WriteLine(result);
    }
}