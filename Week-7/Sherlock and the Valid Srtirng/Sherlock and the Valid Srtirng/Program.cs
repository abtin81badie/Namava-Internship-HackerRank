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
     * Complete the 'isValid' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */
    private static void CheckConstraints(string s)
    {
        if (s.Length < 1 || s.Length > Math.Pow(10, 5))
            throw new ArgumentException("String length must be between 1 and 10^5 characters.", nameof(s));

        if (s.Any(c => !char.IsLower(c)))
            throw new ArgumentException("String must contain only lowercase English characters (a to z).", nameof(s));
    }

    public static string isValid(string s)
    {
        CheckConstraints(s);

        var frequencyMap = s.GroupBy(c => c)
                         .Select(g => g.Count())
                         .GroupBy(f => f)
                         .ToDictionary(g => g.Key, g => g.Count());

        if (frequencyMap.Count == 1)
            return "YES";

        if (frequencyMap.Count > 2)
            return "NO";

        bool canRemoveOneFrequencyOne = frequencyMap.Keys.Min() == 1
                                        && frequencyMap[frequencyMap.Keys.Min()] == 1;

        bool canReduceMaxFrequency = frequencyMap.Keys.Max() == frequencyMap.Keys.Min() + 1
                                     && frequencyMap[frequencyMap.Keys.Max()] == 1;

        return canRemoveOneFrequencyOne
            || canReduceMaxFrequency ? "YES" : "NO";
    }


}

class Solution
{
    public static void Main(string[] args)
    {
        string s = Console.ReadLine();

        string result = Result.isValid(s);

        Console.WriteLine(result);
    }
}
