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
     * Complete the 'maxSubarray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    private static void CheckConstraints(List<int> arr)
    {
        if (arr.Count < 1 || arr.Count > Math.Pow(10, 5))
            throw new ArgumentException("Array size must be between 1 and 10^5.");

        if (arr.Any(value => value < -Math.Pow(10, 4)
            || value > Math.Pow(10, 4)))
            throw new ArgumentException("Array elements must be between -10^4 and 10^4.");
    }

    public static List<int> maxSubarray(List<int> arr)
    {
        CheckConstraints(arr);

        //var maxSubArraySum = arr[0];
        //var maxEnding = arr[0];

        //for (var i = 1; i < arr.Count; i++) 
        //{
        //    maxEnding = Math.Max(maxEnding + arr[i], arr[i]);

        //    maxSubArraySum = Math.Max(maxSubArraySum, maxEnding);
        //}

        //var maxSubSequenceSum = 0;
        //var maxElement = arr[0];

        //foreach (var value in arr)
        //{
        //    if (value > 0)
        //        maxSubSequenceSum += value;

        //    maxElement = Math.Max(maxElement,value);
        //}

        //if (maxSubSequenceSum == 0)
        //    maxSubSequenceSum = maxElement;

        //return new List<int> { maxSubArraySum, maxSubSequenceSum };

        var currentSubArray = arr[0];
        var maxSubArray = arr[0];

        var maxSubSequence = (arr[0] > 0) ? arr[0] : 0;
        var maxElement = arr[0];

        for (int i = 1; i < arr.Count; i++)
        {
            int num = arr[i];

            currentSubArray = Math.Max(num, currentSubArray + num);
            maxSubArray = Math.Max(maxSubArray, currentSubArray);

            if (num > 0)
                maxSubSequence += num;

            maxElement = Math.Max(maxElement, num);
        }

        if (maxSubSequence == 0
            && maxElement < 0)
            maxSubSequence = maxElement;

        return new List<int> { maxSubArray, maxSubSequence };
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Result.maxSubarray(arr);

            Console.WriteLine(String.Join(" ", result));
        }

    }
}
