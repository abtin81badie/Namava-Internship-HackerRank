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
     * Complete the 'MaxMin' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY arr
     */
    private static void CheckConstraints(int n, int k, List<int> arr)
    {
        if (n < 2 || n > Math.Pow(10, 5))
            throw new ArgumentException($"Constraint violated: 2 <= n <= 10^5. Received n = {n}");

        if (k < 2 || k > n)
            throw new ArgumentException($"Constraint violated: 2 <= k <= n. Received k = {k}, n = {n}");

        if (arr.Any(element => element > Math.Pow(10,9) || element < 0))
            throw new ArgumentException($"Constraint violated: 0 <= arr[i] <= 10^9.");
    }

    public static int MaxMin(int k, List<int> arr)
    {
        CheckConstraints(arr.Count, k, arr);

        arr.Sort();

        int result = int.MaxValue;

        for (int i = 0; i <= arr.Count - k; i++)
        {
            int currentUnfairness = arr[i + k - 1] - arr[i];

            if (result > currentUnfairness)
                result = currentUnfairness;
        }

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
            arr.Add(arrItem);
        }

        int result = Result.MaxMin(k, arr);

        Console.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
