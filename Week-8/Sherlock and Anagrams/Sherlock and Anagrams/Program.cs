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
     * Complete the 'sherlockAndAnagrams' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */
    private static void CheckConstraints(string s)
    {
        if (s.Length > 100 || s.Length < 2)
            throw new ArgumentException("Constraint violation: input length must be between 2 and 100 characters.");

        if (s.Any(character => !char.IsAsciiLetterLower(character)))
            throw new ArgumentException("Constraint violation: input must contain only lowercase English letters (a-z).");
    }

    public static int SherlockAndAnagramsDictionarySolution(string s)
    {
        CheckConstraints(s);

        var signatureFrequencyMap = new Dictionary<string, int>();
        var totalAnagramPairs = 0;

        for (var startIndex = 0; startIndex < s.Length; startIndex++)
        {
            var characterFrequency = new int[26];
            for (var currentIndex = startIndex; currentIndex < s.Length; currentIndex++)
            {
                characterFrequency[s[currentIndex] - 'a']++;

                var key = string.Join('#', characterFrequency);

                totalAnagramPairs += signatureFrequencyMap.GetValueOrDefault(key);
                signatureFrequencyMap[key] = signatureFrequencyMap.GetValueOrDefault(key) + 1;
            }
        }

        return totalAnagramPairs;
    }

    public static int SherlockAndAnagrams(string s)
    {
        CheckConstraints(s);

        var normalizedStrings = new List<string>();

        for (var startIndex = 0; startIndex < s.Length; startIndex++)
        {
            for (var subStringLength = 1; subStringLength <= s.Length - startIndex; subStringLength++)
            {
                var normalizedSubstring = new string(
                        s
                         .Substring(startIndex, subStringLength)
                         .OrderBy(character => character)
                         .ToArray()
                );

                normalizedStrings.Add(normalizedSubstring);
            }
        }

        return normalizedStrings
            .GroupBy(substring => substring)
            .Sum(group =>
                group.Count() * (group.Count() - 1) / 2
            );

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = Result.SherlockAndAnagramsDictionarySolution(s);

            Console.WriteLine(result);
        }

    }
}
