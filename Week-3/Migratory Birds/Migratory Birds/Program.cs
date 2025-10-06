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
     * Complete the 'MigratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
    private static void CheckConstraints(List<int> arr)
    {
        if (arr.Count < 5 || arr.Count > 200000)
            throw new ArgumentException($"The number of elements must be between 5 and 200,000, but was {arr.Count}.", nameof(arr));

        if (!arr.All(birdType => birdType >= 1 && birdType <= 5))
            throw new ArgumentException("All bird types must be 1, 2, 3, 4, or 5.", nameof(arr));
    }
    public static int MigratoryBirdsByDictionary(List<int> arr)
    {
        var numberCounter = new Dictionary<int, int>();

        foreach (var item in arr) 
        {
            if (numberCounter.ContainsKey(item))
                numberCounter[item]++;
            else
                numberCounter.Add(item, 1);
        }

        var result = numberCounter
           .OrderByDescending(keyValuePair => keyValuePair.Value) 
           .ThenBy(kvp => kvp.Key)              
           .First()                             
           .Key;

        return result;

        //var result = numberCounter.FirstOrDefault().Key;

        //foreach (var item in numberCounter)
        //{
        //    if (numberCounter[result] <= item.Value)
        //        result = item.Key;
        //}

        //foreach (var item in numberCounter)
        //{
        //    if (numberCounter[result] == item.Value && result > item.Key)
        //        result = item.Key;
        //}

        //return result;
    }
    public static int MigratoryBirds(List<int> arr)
    {
        CheckConstraints(arr);

        var result = arr
            .GroupBy(birdType => birdType)
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key)
            .First()
            .Key;

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.MigratoryBirds(arr);

        Console.WriteLine(result);
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
