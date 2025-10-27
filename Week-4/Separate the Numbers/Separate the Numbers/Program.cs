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
     * Complete the 'SeparateNumbers' function below.
     *
     * The function accepts STRING s as parameter.
     */
    private static void CheckConstraints(string s)
    {
        if (s == null)
            throw new ArgumentNullException(nameof(s));

        if (s.Length < 1 || s.Length > 32)
            throw new ArgumentException($"Constraint violation: String length must be between 1 and 32. Got: {s.Length}", nameof(s));

        if (s.Any(c => !char.IsDigit(c)))
            throw new ArgumentException("Constraint violation: String must contain only digits.", nameof(s));
    }

    private static bool IsValidSequence(string originalString, string firstNumString)
    {
        long prev;
        if (!long.TryParse(firstNumString, out prev))
        {
            return false;
        }

        StringBuilder genStr = new StringBuilder(firstNumString);

        while (genStr.Length < originalString.Length)
        {
            long next = prev + 1;
            genStr.Append(next.ToString());
            prev = next;
        }

        return genStr.ToString() == originalString;
    }

    public static void SeparateNumbers(string s)
    {
        CheckConstraints(s);

        if (s.Length == 1)
        {
            Console.WriteLine("NO");
            return;
        }

        //var possibleLengths = Enumerable.Range(1, s.Length / 2);

        //var possibleFirstNumbers = possibleLengths.Select(i => s.Substring(0, i));

        //string firstMatch = possibleFirstNumbers.FirstOrDefault(firstNum =>
        //    IsValidSequence(
        //        s,
        //        firstNum)
        //);

        string firstMatch = null;
        for (int length = 1; length <= s.Length / 2; length++)
        {
            string firstNumString = s.Substring(0, length);

            if (IsValidSequence(s, firstNumString)) 
            {
                firstMatch = firstNumString;
                break;
            }
        }

        if (firstMatch != null)
            Console.WriteLine($"YES {firstMatch}");
        else
            Console.WriteLine("NO");
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

            Result.SeparateNumbers(s);
        }
    }
}
