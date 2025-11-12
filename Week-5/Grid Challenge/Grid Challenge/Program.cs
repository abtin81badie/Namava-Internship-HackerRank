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
     * Complete the 'GridChallenge' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING_ARRAY grid as parameter.
     */

    private static void CheckConstraints(List<string> grid)
    {
        if (grid.Count < 1 || grid.Count > 100)
            throw new ArgumentOutOfRangeException($"Number of rows n is out of range [1, 100].");


        if (grid.Select(row => row.Any(c => char.IsLower(c)))
                .Any(result => result == false))
            throw new ArgumentException(
                "At least one row contains an invalid character. Only lowercase letters 'a'-'z' are allowed.");
    }

    public static string GridChallenge(List<string> grid)
    {
        CheckConstraints(grid);

        var sortedRows = grid
            .Select(row => new string(row.OrderBy(c => c).ToArray()))
            .ToList();

        for (int col = 0; col < sortedRows[0].Length; col++)
        {
            for (int row = 1; row < sortedRows.Count; row++)
            {
                if (sortedRows[row][col] < sortedRows[row - 1][col])
                    return "NO";
            }
        }

        return "YES";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> grid = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid.Add(gridItem);
            }

            string result = Result.GridChallenge(grid);
            Console.WriteLine(result);

            //textWriter.WriteLine(result);
        }

        //textWriter.Flush();
        //textWriter.Close();
    }
}
