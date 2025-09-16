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

    public static void miniMaxSum(List<int> arr)
    {
        arr.Sort();
        double maxSum = 0;
        double minSum = 0;

        for (int i = 0; i < arr.Count; i++) 
        {
            if (i == 0) {
                minSum += arr[i];
            } else if (i == arr.Count - 1)
            {
                maxSum += arr[i];
            }
            else
            {
                maxSum += arr[i];
                minSum += arr[i];
            }
        }

        Console.WriteLine($"{minSum} {maxSum}");
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.miniMaxSum(arr);
    }
}
