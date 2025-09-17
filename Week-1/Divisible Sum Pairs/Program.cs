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
using System.ComponentModel.DataAnnotations;

class Result
{
    public static int divisibleSumPairs(int n, int k, List<int> ar)
    {
        int[] remaindersCount = new int[k];

        foreach (var number in ar) 
        {
            int reamiainder = number % k;
            remaindersCount[reamiainder]++;
        }

        int pairCount = 0;

        // Case 1: Pairs of numbers with remainder 0.
        int zeroRemainderCount = remaindersCount[0];
        pairCount += (zeroRemainderCount * (zeroRemainderCount - 1)) / 2;

        // Case 2: Pairs of number with complementary numbers.
        for (int i = 1; i <= k / 2; i++) 
        {
            if (i != k - i)
            {
                pairCount += remaindersCount[i] * remaindersCount[k - i];
            } 
            else
            {
                // 'i' is its own complement.
                pairCount += (remaindersCount[i] * (remaindersCount[i] - 1)) / 2;
            }
        }

        return pairCount;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.divisibleSumPairs(n, k, ar);

        Console.WriteLine(result);

        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
