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
    private static void CheckConstraints(string s)
    {
        if (s.Length < 1 || s.Length > 99)
            throw new ArgumentException("String must between 1 and 99.");

        if (s.Length % 3 != 0)
            throw new ArgumentException("Sting must be multiple of 3.");

        if (s.Any(c => c < 'A' || c > 'Z'))
            throw new ArgumentException("String must contain only uppercase English letters [A-Z].");

    }

    public static int MarsExploration(string s)
    {
        CheckConstraints(s);

        const string expectedPattern = "SOS";
        int changedLettersCount = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != expectedPattern[i % 3])
                changedLettersCount++;
        }

        return changedLettersCount;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int result = Result.MarsExploration(s);

        Console.WriteLine(result);

        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
