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
     * Complete the 'TowerBreakers' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER m
     */
    private static void CheckConstraints(int n, int m)
    {
        if (n < 1 || n > Math.Pow(10, 6))
            throw new ArgumentOutOfRangeException(nameof(n), n, $"Parameter '{nameof(n)}' must be between 1 and 10^6.");

        if (m < 1 || m > Math.Pow(10, 6))
            throw new ArgumentOutOfRangeException(nameof(m), m, $"Parameter '{nameof(m)}' must be between 1 and 10^6.");
    }

    public static int TowerBreakers(int n, int m)
    {
        CheckConstraints(n, m);

        if (m == 1 || n % 2 == 0)
            return 2;

        return 1;
    }

    public static int TowerBreakersSimulation(int n, int m)
    {
        CheckConstraints(n, m);

        if (m == 1)
            return 2;

        int towersLeft = n;
        int currentPlayer = 1; 

        while (towersLeft > 0)
        {
            towersLeft--; 

            if (towersLeft == 0)
                return currentPlayer;

            currentPlayer = currentPlayer == 1 ? 2 : 1;
        }

        return 2;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.TowerBreakersSimulation(n, m);

            Console.WriteLine(result);
        }

        //textWriter.Flush();
        //textWriter.Close();
    }
}
