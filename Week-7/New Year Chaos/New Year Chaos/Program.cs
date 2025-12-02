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

        // Iterate backwards from the end of the line
        for (int i = q.Count - 1; i >= 0; i--)
        {
            // The value that *should* be at this position (1-based index)
            int expected = i + 1;

            // If the person currently at i is not the expected person
            if (q[i] != expected)
            {
                // Check if the expected person is 1 spot ahead (at i-1)
                if (i - 1 >= 0 && q[i - 1] == expected)
                {
                    bribes++;
                    Swap(q, i, i - 1);
                }
                // Check if the expected person is 2 spots ahead (at i-2)
                else if (i - 2 >= 0 && q[i - 2] == expected)
                {
                    bribes += 2;
                    // Move the person from i-2 to i requires two swaps:
                    // 1. Swap (i-2) with (i-1)
                    // 2. Swap (i-1) with (i)
                    Swap(q, i - 2, i - 1);
                    Swap(q, i - 1, i);
                }
                // If the expected person is not found in the previous 2 spots,
                // it means they moved more than 2 spots, which is impossible.
                else
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
            }
        }

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
