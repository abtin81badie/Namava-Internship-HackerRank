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
    public static void plusMinus(List<int> arr)
    {
        int totalCount = arr.Count;

        int positiveCount = 0;
        int negativeCount = 0;
        int zeroCount = 0;

        foreach (var number in arr) 
        {
            if (number < 0)
            {
                negativeCount++;
            }
            else if (number > 0)
            {
                positiveCount++;
            }
            else 
            {
                zeroCount++;
            }
        }

        double positiveRatio = (double)positiveCount / totalCount;
        double negativeRatio = (double)negativeCount / totalCount;
        double zeroRatio = (double)zeroCount / totalCount;

        Console.WriteLine($"{positiveRatio:F6}\n{negativeRatio:F6}\n{zeroRatio:F6}");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}
