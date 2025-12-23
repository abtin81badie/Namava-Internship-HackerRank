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
     * Complete the 'IsBalanced' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */
    private static void CheckConstraints(string s)
    {
        if (s.All(charachter => char.Equals(charachter, "{}()[]")))
            throw new ArgumentException("Input contains invalid characters. Only {}, (), and [] are allowed.");

        if (s.Length < 1 || s.Length > Math.Pow(10, 3))
            throw new AggregateException("Input length must be between 1 and 1000 characters.");
    }

    public static string IsBalanced(string s)
    {
        CheckConstraints(s);

        var stack = new Stack<char>();

        foreach (char character in s)
        {

            stack.TryPeek(out var top);

            if (char.Equals(top, '{') && char.Equals(character, '}'))
                stack.Pop();
            else if (char.Equals(top, '(') && char.Equals(character, ')'))
                stack.Pop();
            else if (char.Equals(top, '[') && char.Equals(character, ']'))
                stack.Pop();
            else
                stack.Push(character);
        }

        return stack.Count
               == 0 ? "YES" : "NO";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string s = Console.ReadLine();

            string result = Result.IsBalanced(s);

            Console.WriteLine(result);
        }
    }
}
