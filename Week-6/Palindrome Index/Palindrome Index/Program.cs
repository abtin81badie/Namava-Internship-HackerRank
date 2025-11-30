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
     * Complete the 'palindromeIndex' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */
    private static void CheckConstraints(string s)
    {
        if (s.Length < 1 || s.Length > 5 + Math.Pow(10, 5))
            throw new ArgumentException(
                $"Input string length must be between 1 and 5 + 10^5 characters, inclusive. Current length is {s.Length}.",
                nameof(s));

        if (s.Any(c => !Char.IsLower(c)))
            throw new ArgumentException("Input string must contain only lowercase English alphabet characters (a to z)"); 

    }

    private static bool IsPalindrome(string s, int start, int end)
    {
        while (start < end)
        {
            if (s[start] != s[end])
                return false;

            start++;
            end--;
        }
        return true;
    }

    public static int palindromeIndex(string s)
    {
        CheckConstraints(s);

        var left = 0;
        var right = s.Length - 1;

        while (left < right && s[left] == s[right])
        {
            left++;
            right--;
        }

        if (left >= right)
            return -1;

        if (IsPalindrome(s, left + 1, right))
            return left;

        if (IsPalindrome(s, left, right - 1))
            return right;

        return -1;

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

            int result = Result.palindromeIndex(s);

            Console.WriteLine(result);
        }

    }
}
