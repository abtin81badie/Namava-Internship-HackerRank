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
     * Complete the 'SuperDigit' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING n
     *  2. INTEGER k
     */
    private static void CheckConstraints(string n, int k)
    {
        if (n.Length > Math.Pow(10, 100_000) || n.Length < 1)
            throw new ArgumentException($"Constraint violation: The length of 'n' must be between 1 and 10^(10^5). Actual length: {n?.Length ?? 0}", nameof(n));

        if (k > Math.Pow(10, 5) || k < 1)
            throw new ArgumentException($"Constraint violation: 'k' must be between 1 and 10^5. Actual value: {k}", nameof(k));
    }

    private static int CalculateRecursiveSuperDigit(long num)
    {
        if (num < 10)
            return (int)num;

        var sum = num.ToString().Sum(c => (long)(char.GetNumericValue(c)));

        return CalculateRecursiveSuperDigit(sum);
    }

    public static int SuperDigit(string n, int k)
    {
        CheckConstraints(n, k);

        var initialSum = n.Sum(c => (long)(char.GetNumericValue(c)));

        var totalSum = initialSum * k;

        return CalculateRecursiveSuperDigit(totalSum);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        string n = firstMultipleInput[0];

        int k = Convert.ToInt32(firstMultipleInput[1]);

        int result = Result.SuperDigit(n, k);

        Console.WriteLine(result);
    }
}
