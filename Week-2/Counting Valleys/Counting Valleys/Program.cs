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
    private static void checkConstraints(int steps, string path)
    {
        if (steps < 0 || steps > Math.Pow(10, 6))
            throw new ArgumentOutOfRangeException("Invalid steps input.");

        if (path is null)
            throw new ArgumentNullException("path");

        if (path.Length != steps)
            throw new ArgumentException("The length of the path is not equal to number of steps.");

        var invalidChar = path.FirstOrDefault(step => step != 'U' && step != 'D');

        if (invalidChar != default(char))
            throw new ArgumentException($"Invalid character '{invalidChar}' found in path. Only 'U' and 'D' are allowed.", nameof(path));
    }

    public static int countingValleys(int steps, string path)
    {
        checkConstraints(steps, path);

        int altitude = 0;
        int valleysCount = 0;

        foreach (var chracter in path)
        {
            bool wasInValley = altitude < 0;

            if (chracter == 'U')
            {
                altitude++;

                if (wasInValley && altitude == 0)
                    valleysCount++;
            }
            else if (chracter == 'D')
                altitude--;
            else
                throw new ArgumentException("Invalid Char.");
        }

        return valleysCount;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int steps = Convert.ToInt32(Console.ReadLine().Trim());

        string path = Console.ReadLine();

        int result = Result.countingValleys(steps, path);

        Console.WriteLine(result);
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
