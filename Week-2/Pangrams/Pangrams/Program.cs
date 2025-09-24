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
    private static void checkConstraints(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length > 1000)
        {
            throw new ArgumentException("String cannot be null, empty, or longer that 1000 characters.");
        }

        foreach (char c in s) 
        {
            if (!char.IsLetter(c) && c != ' ')
            {
                throw new ArgumentException("Only letters and spaces are allowed.");
            }
        }
    }

    // Solution 4
    public static string pangramsWithLINQ(string s) 
    {
        var uniquLettersCount = s.ToLower()
            .Where(char.IsLetter)
            .Distinct().Count();

        return uniquLettersCount == 26 ? "pangram" : "not pangram";
    }

    // Solution 3
    public static string pangramsWithContain(string s)
    {
        string lowerInput = s.ToLower();
        string alphabets = "abcdefgijklmnopqrstuvwxyz";

        foreach (char alphabat in alphabets) 
        {
            if (!lowerInput.Contains(alphabat))
            {
                return "not pangram";
            }
        }
            
        return "pangram";
    }

    // Solution 2
    public static string pangramsHashSolution (string s) 
    {
        var distincLetter = new HashSet<char>(s.ToLower().Where(char.IsLetter));

        return distincLetter.Count == 26 ? "pangram" : "not pangram"; 
    }

    // Solution 1
    public static string pangrams(string s)
    {
        checkConstraints(s);

        bool[] alphabetFound = new bool[26];
        int found = 0;

        foreach (char c in s.ToLower())
        {
            int index = c - 'a';
            if (index >= 0 && index <= 25)
            {
                alphabetFound[index] = true;
            }
        }

        bool isPangram = alphabetFound.Count(found => found) == 26;

        return isPangram ? "pangram" : "not pangram";

    }
}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.pangrams(s);

        Console.WriteLine(result);

        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}

