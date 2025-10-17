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
     * Complete the 'GetTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */
    private static void CheckConstraints(List<int> a, List<int> b)
    {
        int n = a.Count;
        int m = b.Count;

        if (n < 1 || n > 10 || m < 1 || m > 10)
            throw new Exception("Error: Array sizes must be between 1 and 10.");

        if (a.Any(element => element < 1 || element > 100))
            throw new Exception("Error: All elements in the first array must be between 1 and 100.");

        if (b.Any(element => element < 1 || element > 100))
            throw new Exception("Error: All elements in the second array must be between 1 and 100.");
    }

    public static int GetTotalX(List<int> a, List<int> b)
    {
        CheckConstraints(a, b);

        int count = 0;

        int startRange = a.Max();
        int endRange = b.Min();

        for (int i = startRange; i <= endRange; i++)
        {
            bool isMultipleOfAllInA = a.All(element => i % element == 0);
            bool  isFactorOfAllInB = b.All(element => element % i == 0);

            if (isMultipleOfAllInA & isFactorOfAllInB)
                count++;
        }

        return count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.GetTotalX(arr, brr);

        Console.WriteLine(total);
        //textWriter.WriteLine(total);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
