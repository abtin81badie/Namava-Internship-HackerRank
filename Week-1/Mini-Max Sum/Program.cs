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
        long totalSum = 0;

        long minElement = arr[0];
        long maxElement = arr[0];

        foreach (int number in arr)
        {
            totalSum += number;

            if (number < minElement)
            {
                minElement = number;
            }
            else if (number > maxElement) 
            {
                maxElement = number;
            }
        }

        long minSum = totalSum - maxElement;
        long maxSum = totalSum - minElement;

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
