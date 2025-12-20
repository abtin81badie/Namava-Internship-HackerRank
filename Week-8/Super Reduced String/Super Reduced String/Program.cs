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
     * Complete the 'superReducedString' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */
    private static void CheckConstraints(string s)
    {
        if (s.Length > 100 || s.Length < 1)
            throw new ArgumentException("Constraint violation: input length must be between 2 and 100 characters.");

        if (s.Any(character => !char.IsAsciiLetterLower(character)))
            throw new ArgumentException("Constraint violation: input must contain only lowercase English letters (a-z).");
    }

    public static string superReducedString(string s)
    {
        CheckConstraints(s);

        var stack = new Stack<char>();

        foreach (char character in s)
        {
            if (stack.TryPeek(out var top) && top == character)
                stack.Pop();
            else
                stack.Push(character);
        }

        return stack.Count == 0
            ? "Empty String"
            : string.Concat(stack.Reverse());
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string s = Console.ReadLine();

        string result = Result.superReducedString(s);

        Console.WriteLine(result);
    }
}
