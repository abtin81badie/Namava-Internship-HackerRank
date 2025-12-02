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

    private static void Swap(List<int> q, int a, int b)
    {
        int temp = q[a];
        q[a] = q[b];
        q[b] = temp;
    }

    public static void MinimumBribesBackwardsSolution(List<int> q)
    {
        CheckConstraints(q);

        int bribes = 0;

        for (int i = q.Count - 1; i >= 0; i--)
        {
            if (q[i] == i + 1)
                continue;
            if (i - 1 >= 0 && q[i - 1] == i + 1)
            {
                bribes++;
                Swap(q, i, i - 1);
            }
            else if (i - 2 >= 0 && q[i - 2] == i + 1)
            {
                bribes += 2;

                Swap(q, i - 2, i - 1);
                Swap(q, i - 1, i);
            }
            else
            {
                Console.WriteLine("Too chaotic");
                return;
            }
        }

        Console.WriteLine(bribes);
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

            // We only need to check from [q[i] - 2] up to [i]. 
            // This is because if a number greater than q[i] is in front of it, 
            // it must be within that small window because numbers can't move more than 2 spots forward.
            for (int j = start; j < i; j++)
            {
                if (q[j] > q[i])
                    bribes++;
            }
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

            Result.MinimumBribesBackwardsSolution(q);
        }
    }
}
