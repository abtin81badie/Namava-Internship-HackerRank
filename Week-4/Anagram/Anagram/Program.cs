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
     * Complete the 'Anagram' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */
    private static void CheckConstraints(string s)
    {
        if (s.Length < 1 || s.Length > 10000)
            throw new ArgumentOutOfRangeException(nameof(s), $"String length must be between 1 and 10000. Received: {s.Length}");
       
        if (!s.All(c => c >= 'a' && c <= 'z'))
            throw new ArgumentException("String must contain only lowercase letters (a-z).", nameof(s));
    }

    public static int Anagram(string s)
    {
        CheckConstraints(s);

        if (s.Length % 2 != 0)
            return -1;

        Dictionary<char, int> charCounts = new Dictionary<char, int>();

        int mid = s.Length / 2;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (!charCounts.ContainsKey(c))
                charCounts[c] = 0;

            if (i < mid)
                charCounts[c]++;
            else
                charCounts[c]--;
        }

        int changesNeeded = 0;
        foreach (int count in charCounts.Values)
        {
            if (count > 0)
                changesNeeded += count;
        }

        return changesNeeded;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = Result.Anagram(s);

            Console.WriteLine(result);
        }

        //textWriter.Flush();
        //textWriter.Close();
    }
}
