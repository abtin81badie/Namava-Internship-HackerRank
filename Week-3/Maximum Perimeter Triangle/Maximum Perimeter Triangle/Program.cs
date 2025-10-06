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
     * Complete the 'maximumPerimeterTriangle' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY sticks as parameter.
     */
    private static void CheckConstraints(List<int> sticks)
    {
        if (sticks.Count < 3 || sticks.Count > 50)
            throw new ArgumentException($"The number of elements must be between 3 and 50, but was {sticks.Count}.", nameof(sticks));

        if (sticks.Any(stick => stick < 1 || stick > Math.Pow(10,9)))
            throw new ArgumentOutOfRangeException(nameof(sticks), "Constraint violated: All sticks must be between 1 and 1_000_000_000.");
    }

    private static bool IsValidTriangle(int a, int b, int c)
    {
        return b + c > a;
    }

    public static List<int> maximumPerimeterTriangle(List<int> sticks)
    {
        CheckConstraints(sticks);

        sticks.Sort();
        sticks.Reverse();

        for (int i = 0; i < sticks.Count - 2; i++)
        {
            int sideA = sticks[i];      
            int sideB = sticks[i + 1];
            int sideC = sticks[i + 2];  

            if (IsValidTriangle(sideA, sideB, sideC))
            {
                return new List<int> { sideC, sideB, sideA };
            }
        }

        return new List<int> { -1 };
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> sticks = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sticksTemp => Convert.ToInt32(sticksTemp)).ToList();

        List<int> result = Result.maximumPerimeterTriangle(sticks);

        Console.WriteLine(String.Join(" ", result));
        //textWriter.WriteLine(String.Join(" ", result));

        //textWriter.Flush();
        //textWriter.Close();
    }
}
