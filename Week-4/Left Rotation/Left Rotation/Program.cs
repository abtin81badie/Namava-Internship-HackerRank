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
     * Complete the 'RotateLeft' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER d
     *  2. INTEGER_ARRAY arr
     */
    private static void CheckConstraints(int d, List<int> arr)
    {
        if (arr.Count < 1 || arr.Count > Math.Pow(10, 5))
            throw new Exception("The size of array must between 1 to 100000.");

        if (d > arr.Count || d < 1)
            throw new Exception("Steps of rotation muse between 1 to n");

        if (arr.Any(element => element > Math.Pow(10, 6) || element < 1))
            throw new Exception("Elements of array must between 1 to 1000000");
           
    }

    public static List<int> RotateLeft(int d, List<int> arr)
    {
        CheckConstraints(d, arr);
        int shiftLeft = (d % arr.Count);
        
        if (shiftLeft == 0)
            return arr;

        var leftSegment = arr.Take(shiftLeft);
        var rightSegment = arr.Skip(shiftLeft);

        return rightSegment.Concat(leftSegment).ToList();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.RotateLeft(d, arr);

        Console.WriteLine(string.Join(" ", result));
        //textWriter.WriteLine(String.Join(" ", result));

        //textWriter.Flush();
        //textWriter.Close();
    }
}
