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
    private static long SolveByXorOperator(long n)
    {
        return n ^ uint.MaxValue;
    }
    private static long solveByBitWiseOperator(long n)
    {
        return (uint) ~n;
    }

    private static long solveByManualConversion(long n)
    {
        string binaryString = Convert.ToString(n, 2).PadLeft(32, '0');
   
        StringBuilder flippedBinary = new StringBuilder(32);
        foreach (char bit in binaryString)
        {
            flippedBinary.Append(bit == '0' ? '1' : '0');
        }

        return Convert.ToUInt32(flippedBinary.ToString(), 2);
    }

    public static long flippingBits(long n)
    {

        // return solveByManualConversion(n);

        // return solveByBitWiseOperator(n);   
        
        return SolveByXorOperator(n);
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
            long n = Convert.ToInt64(Console.ReadLine().Trim());

            long result = Result.flippingBits(n);

            Console.WriteLine(result);
            //textWriter.WriteLine(result);
        }

        //textWriter.Flush();
        //textWriter.Close();
    }
}
