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
     * Complete the 'BalancedSums' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    private static void CheckConstraints(List<int> arr)
    {
        if (arr.Count > Math.Pow(10, 5) || arr.Count < 1)
            throw new ArgumentOutOfRangeException(nameof(arr), "Array size 'n' is out of constraints.");

        if (arr.Any(element => element > 2*Math.Pow(10,4) || element < 0))
            throw new ArgumentOutOfRangeException(nameof(arr), "An element in 'arr' is out of constraints.");
    }

    public static string BalancedSums(List<int> arr)
    {
        CheckConstraints(arr);

        var totalSum = arr.Sum();

        // var totalSum

        //foreach (var val in arr)
        //    totalSum += val;

        var leftSum = 0;

        foreach (var currentElement in arr)
        {
            var rightSum = totalSum - leftSum - currentElement;

            if (leftSum == rightSum)
                return "YES";

            leftSum += currentElement;
        }

        return "NO";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            string result = Result.BalancedSums(arr);

            Console.WriteLine(result);
        }
    }
}
