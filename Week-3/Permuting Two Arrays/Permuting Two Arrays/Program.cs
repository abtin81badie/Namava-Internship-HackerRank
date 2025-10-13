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
     * Complete the 'TwoArrays' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY A
     *  3. INTEGER_ARRAY B
     */

    private static void CheckConstraints(int n, int k, List<int> A, List<int> B)
    {
        if (n < 1 || n > 1000)
        {
            throw new ArgumentException("n must be between 1 to 1000.");
        }

        if (k < 1 || k > 1_000_000_000)
        {
            throw new ArgumentOutOfRangeException("k must be between 1 and 10^9.");
        }

        if (A.Count != n || B.Count != n)
        {
            throw new ArgumentException($"Both lists A and B must have a size of n ({n}).");
        }

        if (A.Any(val => val < 0 || val > 1_000_000_000))
        {
            throw new ArgumentOutOfRangeException(nameof(A), "All elements in list A must be between 0 and 10^9.");
        }

        if (B.Any(val => val < 0 || val > 1_000_000_000))
        {
            throw new ArgumentOutOfRangeException(nameof(B), "All elements in list B must be between 0 and 10^9.");
        }
    }

    public static string TwoArrays(int k, List<int> A, List<int> B)
    {
        CheckConstraints(A.Count, k, A, B);

        A.Sort();

        B = B.OrderByDescending(value => value).ToList();

        for (int i = 0; i < A.Count; i++)
        {
            if (A[i] + B[i] < k)
                return "NO";
        }

        return "YES";

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

            List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

            string result = Result.TwoArrays(k, A, B);

            Console.WriteLine(result);  
            //textWriter.WriteLine(result);
        }

        //textWriter.Flush();
        //textWriter.Close();
    }
}
