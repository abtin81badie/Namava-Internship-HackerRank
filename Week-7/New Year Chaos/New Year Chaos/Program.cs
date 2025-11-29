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
     * Complete the 'minimumBribes' function below.
     *
     * The function accepts INTEGER_ARRAY q as parameter.
     */
    private static void CheckConstraints(List<int> q)
    {
        if (q.Count() > Math.Pow(10, 5) || q.Count() < 1)
            throw new ArgumentException("Value does not fall within the expected range."); 
    }

    public static void MinimumBribes(List<int> q)
    {
        CheckConstraints(q);

        var bribes = 0;

        for (int i = 0; i < q.Count; i++) 
        {
            if (q[i] - (i + 1) > 2)
            {
                Console.WriteLine("Too chaotic");
                return;
            }

            var start = Math.Max(0, q[i] - 2);

            bribes += q.Skip(start)
                .Take(i - start)
                .Count(val => val > q[i]);
        }

        Console.WriteLine(bribes);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();

            Result.MinimumBribes(q);
        }
    }
}
