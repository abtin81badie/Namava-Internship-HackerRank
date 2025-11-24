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
     * Complete the 'FormingMagicSquare' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY s as parameter.
     */
    private static void CheckConstraints(List<List<int>> s)
    {
        if (s.Any(row => row.Any(element => element > 9 || element < 1)))
            throw new ArgumentException("All elements in the matrix must be between 1 and 9 inclusive.", nameof(s));
    }

    // First Solution
    private static readonly int[][] MagicSquares =
        {
        new[] {8, 1, 6, 3, 5, 7, 4, 9, 2},
        new[] {6, 1, 8, 7, 5, 3, 2, 9, 4},
        new[] {4, 9, 2, 3, 5, 7, 8, 1, 6},
        new[] {2, 9, 4, 7, 5, 3, 6, 1, 8},
        new[] {8, 3, 4, 1, 5, 9, 6, 7, 2},
        new[] {4, 3, 8, 9, 5, 1, 2, 7, 6},
        new[] {6, 7, 2, 1, 5, 9, 8, 3, 4},
        new[] {2, 7, 6, 9, 5, 1, 4, 3, 8}
    };

    public static int FormingMagicSquare(List<List<int>> s)
    {
        CheckConstraints(s);

        var flatInput = s.SelectMany(row => row).ToList();

        return MagicSquares.Min(square =>
        square.Select((
        val,
        index) => Math.Abs(val - flatInput[index])).Sum());
    }

    // Second Solution
    private static int[] RotateClockwise(int[] square)
    {
        return new int[]
        {
            square[6], square[3], square[0],
            square[7], square[4], square[1],
            square[8], square[5], square[2]
        };
    }

    private static int[] ReflectHorizontal(int[] square)
    {
        return new int[]
        {
            square[2], square[1], square[0],
            square[5], square[4], square[3],
            square[8], square[7], square[6]
        };
    }

    private static List<int[]> GenerateAllMagicSquares()
    {
        int[] baseSquare = { 8, 1, 6, 3, 5, 7, 4, 9, 2 };

        IEnumerable<int[]> GetRotations(int[] root)
        {
            var current = root;
            for (int i = 0; i < 4; i++)
            {
                yield return current;
                current = RotateClockwise(current);
            }
        }

        var originalRotations = GetRotations(baseSquare);

        var reflectedRotations = GetRotations(ReflectHorizontal(baseSquare));

        return originalRotations.Concat(reflectedRotations).ToList();
    }


    public static int FormingMagicSquareGenerative(List<List<int>> s) 
    {
        CheckConstraints(s);

        var flatInput = s.SelectMany(row => row).ToArray();

        var allMagicSquares = GenerateAllMagicSquares();

        return MagicSquares.Min(square =>
        square.Select((
        val,
        index) => Math.Abs(val - flatInput[index])).Sum());
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        List<List<int>> s = new List<List<int>>();

        for (int i = 0; i < 3; i++)
        {
            s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
        }

        int result = Result.FormingMagicSquareGenerative(s);

        Console.WriteLine(result);
    }
}
