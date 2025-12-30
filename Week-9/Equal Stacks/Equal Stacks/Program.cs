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
     * Complete the 'equalStacks' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY h1
     *  2. INTEGER_ARRAY h2
     *  3. INTEGER_ARRAY h3
     */
    private static void CheckConstraints(List<int> h1, List<int> h2, List<int> h3)
    {
        if (h1.Count < 1 || h1.Count > Math.Pow(10, 5) ||
            h2.Count < 1 || h2.Count > Math.Pow(10, 5) ||
            h3.Count < 1 || h3.Count > Math.Pow(10, 5))
            throw new ArgumentException("each stack size must be in the range 1 to 100,000.");

        if (h1.Any(h => h <= 0 || h > 100) ||
        h2.Any(h => h <= 0 || h > 100) ||
        h3.Any(h => h <= 0 || h > 100))
            throw new ArgumentException("cylinder heights must be in the range 1 to 100.");

    }

    public static int EqualStacks(List<int> h1, List<int> h2, List<int> h3)
    {
        CheckConstraints(h1, h2, h3);

        var sum1 = h1.Sum();
        var sum2 = h2.Sum();
        var sum3 = h3.Sum();

        var index1 = 0;
        var index2 = 0;
        var index3 = 0;

        while (!(sum1 == sum2 && sum2 == sum3))
        {
            if (sum1 == 0
                || sum2 == 0
                || sum3 == 0)
                return 0;

            if (sum1 >= sum2 && sum1 >= sum3)
                sum1 -= h1[index1++];
            else if (sum2 >= sum1 && sum2 >= sum3)
                sum2 -= h2[index2++];
            else
                sum3 -= h3[index3++];
        }

        return sum1;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n1 = Convert.ToInt32(firstMultipleInput[0]);

        int n2 = Convert.ToInt32(firstMultipleInput[1]);

        int n3 = Convert.ToInt32(firstMultipleInput[2]);

        List<int> h1 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h1Temp => Convert.ToInt32(h1Temp)).ToList();

        List<int> h2 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h2Temp => Convert.ToInt32(h2Temp)).ToList();

        List<int> h3 = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(h3Temp => Convert.ToInt32(h3Temp)).ToList();

        int result = Result.EqualStacks(h1, h2, h3);

        Console.WriteLine(result);
    }
}
