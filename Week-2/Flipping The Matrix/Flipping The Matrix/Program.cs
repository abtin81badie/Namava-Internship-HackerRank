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
     * Complete the 'flippingMatrix' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
     */

    public static int flippingMatrix(List<List<int>> matrix)
    {
        int n = matrix.Count / 2;
        int totalSum = 0;
        int fullDimension = 2 * n;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int topLeft = matrix[i][j];

                int topRight = matrix[i][fullDimension - 1 - j];

                int bottomLeft = matrix[fullDimension - 1 - i][j];

                int bottomRight = matrix[fullDimension - 1 - i][fullDimension - 1 - j];

                int maxOfFour = Math.Max(topLeft, Math.Max(topRight, Math.Max(bottomLeft, bottomRight)));


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

            int result = Result.flippingMatrix(matrix);

            Console.WriteLine(result);  
            //textWriter.WriteLine(result);
        }

        //textWriter.Flush();
        //textWriter.Close();
    }
}
