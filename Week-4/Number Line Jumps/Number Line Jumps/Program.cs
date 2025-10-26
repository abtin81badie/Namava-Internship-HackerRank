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
     * Complete the 'Kangaroo' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER x1
     *  2. INTEGER v1
     *  3. INTEGER x2
     *  4. INTEGER v2
     */
    public static void CheckConstraints(int x1, int v1, int x2, int v2)
    {
        if (x1 < 0 || x1 >= x2 || x2 > 10000)
            throw new ArgumentOutOfRangeException(nameof(x1),
                "Constraint violated: 0 <= x1 < x2 <= 10000.");

        if (v1 < 1 || v1 > 10000)
            throw new ArgumentOutOfRangeException(nameof(v1),
                "Constraint violated: 1 <= v1 <= 10000.");

        if (v2 < 1 || v2 > 10000)
            throw new ArgumentOutOfRangeException(nameof(v2),
                "Constraint violated: 1 <= v2 <= 10000.");
    }


    public static string Kangaroo(int x1, int v1, int x2, int v2)
    {
        CheckConstraints(x1, v1, x2, v2);

        if (x1 == x2)
            return "YES";

        if (v1 == v2)
            return "NO";

        int deltaHorizontalPosition = x2 - x1;
        int deltaVelocity = v1 - v2;

        //if (deltaVelocity == 0)
        //    return deltaHorizontalPosition == 0 ? "YES" : "NO";

        bool meet = (deltaHorizontalPosition % deltaVelocity == 0) && (deltaHorizontalPosition / deltaVelocity >= 0);
        string isPossible = meet ? "YES" : "NO";
        return isPossible;
    }


}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int x1 = Convert.ToInt32(firstMultipleInput[0]);

        int v1 = Convert.ToInt32(firstMultipleInput[1]);

        int x2 = Convert.ToInt32(firstMultipleInput[2]);

        int v2 = Convert.ToInt32(firstMultipleInput[3]);

        string result = Result.Kangaroo(x1, v1, x2, v2);

        Console.WriteLine(result);
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
