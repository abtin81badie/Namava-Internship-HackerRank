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

    public static int diagonalDifference(List<List<int>> arr)
    {
        int matrixSize = arr.Count;
        int primaryDiagonalSum = 0;
        int secondaryDiagonalSum = 0;
        int i = 0;

        foreach (var row in arr)
        {
            primaryDiagonalSum += row[i];
            secondaryDiagonalSum += arr[matrixSize - 1 - i][i];
            i++;
        }

        //for (int i = 0; i < matrixSize; i++)
        //{
        //    primaryDiagonalSum += arr[i][i];
        //    secondaryDiagonalSum += arr[matrixSize - 1 - i][i];
        //}

        int absoluteDifference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

        return absoluteDifference;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.diagonalDifference(arr);
        Console.WriteLine(result);
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
