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

        double positiveRatio = (double)arr.Count(num => num > 0) / totalCount;
        double negativeRatio = (double)arr.Count(num => num < 0) / totalCount;
        double zeroRatio = (double)arr.Count(num => num == 0 ) / totalCount;

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
