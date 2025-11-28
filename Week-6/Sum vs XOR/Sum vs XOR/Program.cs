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
     * Complete the 'sumXor' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts LONG_INTEGER n as parameter.
     */
    private static void CheckConstraints(long n)
    {
        if (n < 0 || n > Math.Pow(10, 15))
            throw new ArgumentException("The value of 'n' must be a non-negative integer. It must be between 0 and 10^15.");
    }

    public static long sumXor(long n)
    {
        CheckConstraints(n);

        if (n == 0)
            return 1;

        var binaryString = Convert.ToString(n, 2);

        var countOfZeros = binaryString.Count(c => c == '0');

        return (long)Math.Pow(2, countOfZeros);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.sumXor(n);

        Console.WriteLine(result);
    }
}
