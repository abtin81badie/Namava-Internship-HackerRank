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
     * Complete the 'Birthday' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY s
     *  2. INTEGER d
     *  3. INTEGER m
     */
    public static int BirthdayLinq(List<int> s, int d, int m)
    {
        int waysToShare = 0;

        if (s.Count < m)
            return 0;

        for (int i = 0; i <= s.Count - m; i++) 
        {
            int chunksSum = s.Skip(i).Take(m).Sum();
            if (chunksSum == d)
                waysToShare++;
        }

        return waysToShare;
    }

    public static int Birthday(List<int> s, int d, int m)
    {
        int waysToShare = 0;

        int currentSum = s.GetRange(0, m).Sum();
        if (currentSum == d)
        {
            waysToShare++;
        }

        for (int i = m; i < s.Count; i++)
        {
            currentSum += s[i];
            currentSum -= s[i - m];

            if (currentSum == d)
                waysToShare++;
        }

        return waysToShare;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int d = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        int result = Result.Birthday(s, d, m);

        Console.WriteLine(result);
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
