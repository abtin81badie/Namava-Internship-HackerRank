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
     * Complete the 'alternate' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */
    private static void CheckConstraints(string s)
    {
        if (s.Length < 1 || s.Length > Math.Pow(10, 3))
            throw new ArgumentException("The length of the string must be between 1 and 1000 characters, inclusive.");

        if (!s.All(character => char.IsAsciiLetterLower(character)))
            throw new ArgumentException("The string must contain only lowercase English letters (a to z).");
    }

    private static bool IsValid(List<char> filtered)
    {
        for (var i = 0; i < filtered.Count - 1; i++)
        {
            if (char.Equals(filtered[i], filtered[i + 1]))
                return false;
        }

        return true;
    }

    public static int Alternate(string s)
    {
        CheckConstraints(s);

        var uniqueCharacters = s.Distinct().ToList();
        var maxLength = 0;

        for (var i = 0; i < uniqueCharacters.Count; i++)
        {
            for (var j = i + 1; j < uniqueCharacters.Count; j++)
            {
                var filtered = s.Where(c => Char.Equals(c, uniqueCharacters[i]) || Char.Equals(c, uniqueCharacters[j]))
                                .ToList();

                if (IsValid(filtered))
                    maxLength = Math.Max(maxLength, filtered.Count);
            }
        }

        return maxLength;
    }

    public static int AlternateOptimized(string s)
    {
        CheckConstraints(s);

        var uniqueCharacters = s.Distinct().ToList();

        if (uniqueCharacters.Count < 2)
            return 0;

        var characterPairs = uniqueCharacters
            .SelectMany((first, index) => uniqueCharacters.Skip(index + 1)
            .Select(second => new { first, second }));

        var maxLength = 0;

        foreach (var pair in characterPairs)
        {
            var filtered = s.Where(c => c == pair.first || c == pair.second).ToList();

            if (IsValid(filtered))
                maxLength = Math.Max(maxLength, filtered.Count);
        }

        return maxLength;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int l = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int result = Result.Alternate(s);

        Console.WriteLine(result);
    }
}
