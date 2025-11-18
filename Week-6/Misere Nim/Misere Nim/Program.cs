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
     * Complete the 'MisereNim' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY s as parameter.
     */
    private static void CheckConstraints(List<int> s)
    {
        if (s.Count < 1 || s.Count > 100)
            throw new ArgumentException("Constraint violation: Number of piles (n) must be between 1 and 100.");


        if (s.Any(element => element < 1 || element > Math.Pow(10,9)))
            throw new ArgumentException("Constraint violation: Pile size s[i] must be between 1 and 10^9.");
    }

    public static string MisereNim(List<int> s)
    {
        CheckConstraints(s);

        var allOnes = s.All(x => x == 1);

        if (allOnes)
            return (s.Count % 2 == 0) ? "First" : "Second";
        else 
        {
            var xorSum = s.Aggregate(0, (acc, element) => acc ^ element);
            return (xorSum != 0) ? "First" : "Second";
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

            string result = Result.MisereNim(s);

            Console.WriteLine(result);
        }

    }
}
