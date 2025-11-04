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
     * Complete the 'dynamicArray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     * 1. INTEGER n
     * 2. 2D_INTEGER_ARRAY queries
     */

    private static void CheckConstraints(int n, List<List<int>> queries)
    {
        if (n < 1 || n > Math.Pow(10, 5))
            throw new ArgumentOutOfRangeException(nameof(n),
                $"Constraint violation: n must be between 1 and {Math.Pow(10, 5)}.");

        if (queries.Count < 1 || queries.Count > Math.Pow(10, 5))
            throw new ArgumentOutOfRangeException(nameof(queries),
                $"Constraint violation: q must be between 1 and {Math.Pow(10, 5)}.");

        if (queries.Any(query => query[1] < 0 || query[1] > Math.Pow(10, 9)))
            throw new ArgumentOutOfRangeException("x",
                $"Constraint violation: x must be between 0 and {Math.Pow(10, 9)}.");

        if (queries.Any(query => query[2] < 0 || query[2] > Math.Pow(10, 9)))
            throw new ArgumentOutOfRangeException("y",
                $"Constraint violation: y must be between 0 and {Math.Pow(10, 9)}.");
    }

    public static List<int> dynamicArray(int n, List<List<int>> queries)
    {
        CheckConstraints(n, queries);

        var arr = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = new List<int>();
        }

        int lastAnswer = 0;

        List<int> answers = new List<int>();

        foreach (var query in queries)
        {
            int queryType = query[0];
            int x = query[1];
            int y = query[2];

            int idx = (x ^ lastAnswer) % n;

            if (queryType == 1)
                arr[idx].Add(y);
            else if (queryType == 2)
            {
                int size = arr[idx].Count;

                int value = arr[idx][y % size];

                lastAnswer = value;

                answers.Add(lastAnswer);
            }
        }

        return answers;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int q = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> result = Result.dynamicArray(n, queries);
        
        Console.WriteLine(String.Join("\n", result));
    }
}