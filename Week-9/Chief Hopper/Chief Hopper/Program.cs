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
     * Complete the 'chiefHopper' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    private static void CheckConstrants(List<int> arr)
    {
        if (arr.Count < 1 || arr.Count > Math.Pow(10, 5))
            throw new ArgumentException();

        if (arr.Any(height => height < 1 || height > Math.Pow(10,5)))
            throw new ArgumentException();
    }

    public static int ChiefHopper(List<int> arr)
    {
        CheckConstrants(arr);

        var energy = 0;

        for (var i = arr.Count - 1; i >= 0; i--)
        {
            energy = (energy + arr[i] + 1) / 2;
        }
    
        return energy;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.ChiefHopper(arr);

        Console.WriteLine(result);
    }
}
