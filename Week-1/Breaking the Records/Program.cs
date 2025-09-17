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
    public static List<int> breakingRecords(List<int> scores)
    {
        int highScore = scores[0];
        int lowScore = scores[0];

        int timeBrokeHighestRecord = 0;
        int timeBrokeLowestRecord = 0;

        foreach (var currentScore in scores)
        {
            if (currentScore > highScore) 
            {
                highScore = currentScore;
                timeBrokeHighestRecord++;
            }

            if (currentScore < lowScore) 
            {
                lowScore = currentScore;
                timeBrokeLowestRecord++;
            }
        }

        return new List<int> { timeBrokeHighestRecord, timeBrokeLowestRecord };
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> scores = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(scoresTemp => Convert.ToInt32(scoresTemp)).ToList();

        List<int> result = Result.breakingRecords(scores);

        Console.WriteLine($"{result[0]}, {result[1]}");
        //textWriter.WriteLine(String.Join(" ", result));

        //textWriter.Flush();
        //textWriter.Close();
    }
}
