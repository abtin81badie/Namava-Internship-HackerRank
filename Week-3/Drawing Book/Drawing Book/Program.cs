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
     * Complete the 'PageCount' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER p
     */
    private static void CheckConstraints(int n, int p)
    {
        if (n < 1 || n > Math.Pow(10, 5))
            throw new ArgumentException("n must be greater or equal than 1 and smaller or equal than 10^5.");

        if (p > n || p < 1)
            throw new ArgumentException("p must be greater or equal than 1 and smaller or equal than n.");

    }

    public static int PageCount(int n, int p)
    {
        CheckConstraints(n, p);

        int turnsFromFront = p / 2;

        int totalTurns = n / 2;

        int turnsFromBack = totalTurns - turnsFromFront;

        int minimumTurns = Math.Min(turnsFromBack, turnsFromFront);

        return minimumTurns;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int p = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.PageCount(n, p);

        Console.WriteLine(result);
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}

