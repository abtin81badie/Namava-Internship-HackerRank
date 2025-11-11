using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

class Result
{

    /*
     * Complete the 'SansaXor' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    private static void CheckConstraints(List<int> arr)
    {
        if (arr.Count > Math.Pow(10, 5) || arr.Count < 2)
            throw new ArgumentException("Constraint violation: Array length must be between 2 and 10^5.");

        if (arr.Any(element => element < 1 || element > Math.Pow(10, 8)))
            throw new ArgumentException("Constraint violation: Array elements must be between 1 and 10^8");
    }

    public static int SansaXor(List<int> arr)
    {
        CheckConstraints(arr);

        if (arr.Count % 2 == 0)
            return 0;

        var result = 0;
        for (var i = 0; i < arr.Count; i += 2)
            result ^= arr[i];

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            int result = Result.SansaXor(arr);

            Console.WriteLine(result);
        }

        //textWriter.Flush();
        //textWriter.Close();
    }
}
