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
     * Complete the 'FlippingMatrix' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
     */
    private static void CheckConstraints(List<List<int>> matrix)
    {
        if (matrix == null || matrix.Count == 0)
            throw new ArgumentException("Matrix cannot be null or empty.");

        int fullDimension = matrix.Count;
        if (fullDimension % 2 != 0)
            throw new ArgumentException("Matrix dimension must be an even number.");

        int n = fullDimension / 2;
        if (n < 1 || n > 128)
            throw new ArgumentOutOfRangeException(nameof(n), $"n must be between 1 and 128, but was {n}.");

        if (matrix.Any(row => row.Count != fullDimension))
            throw new ArgumentException("Matrix must be square.");

        if (matrix.Any(row => row.Any(value => value < 0 || value > 4096)))
            throw new ArgumentOutOfRangeException("matrix", "All matrix elements must be between 0 and 4096.");
    }

    private static int GetMax(params int[] values)
    {
        return values.Max();
    }

    public static int FlippingMatrix(List<List<int>> matrix)
    {
        CheckConstraints(matrix);

        int n = matrix.Count / 2;
        int totalSum = 0;
        int fullDimension = matrix.Count();

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                int topLeft = matrix[row][col];
                int topRight = matrix[row][fullDimension - 1 - col];
                int bottomLeft = matrix[fullDimension - 1 - row][col];
                int bottomRight = matrix[fullDimension - 1 - row][fullDimension - 1 - col];

                int maxOfFour = GetMax(topLeft, topRight, bottomLeft, bottomRight);

                totalSum += maxOfFour;
            }
        }

        return totalSum;
    }

}
class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < 2 * n; i++)
            {
                matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            }

            int result = Result.FlippingMatrix(matrix);

            Console.WriteLine(result);  
            //textWriter.WriteLine(result);
        }

        //textWriter.Flush();
        //textWriter.Close();
    }
}
