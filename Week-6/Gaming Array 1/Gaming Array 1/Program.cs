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
     * Complete the 'GamingArray' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    private static void CheckConstraints(List<int> arr)
    {
        if (arr.Count < 1 || arr.Count > Math.Pow(10, 5))
            throw new ArgumentException("Array size must be between 1 and 10^5.", nameof(arr));

        if (arr.Any(item => item < 1 || item > Math.Pow(10, 9)))
            throw new ArgumentException("All array elements must be between 1 and 10^9.", nameof(arr));
    }

    public static string GamingArray(List<int> arr)
    {
        CheckConstraints(arr);

        var currentMax = int.MinValue;
        var moves = 0;

        foreach (var item in arr)
        {
            if (item > currentMax)
            {
                currentMax = item;
                moves++;
            }
        }

        return moves % 2 == 0 ? "ANDY" : "BOB";
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        int g = Convert.ToInt32(Console.ReadLine().Trim());

        for (int gItr = 0; gItr < g; gItr++)
        {
            int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            string result = Result.GamingArray(arr);

            Console.WriteLine(result);
        }

    }
}
