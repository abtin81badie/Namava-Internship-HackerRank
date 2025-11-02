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
     * Complete the 'CaesarCipher' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER k
     */
    private static void CheckConstraints(int n, string s, int k)
    {
        if (n < 1 || n > 100)
            throw new ArgumentOutOfRangeException(nameof(n), $"Length 'n' ({n}) must be between 1 and 100.");

        if (k < 0 || k > 100)
            throw new ArgumentOutOfRangeException(nameof(k), $"Rotation 'k' ({k}) must be between 0 and 100.");

        if (s == null)
            throw new ArgumentNullException(nameof(s));

        if (s.Length != n)
            throw new ArgumentException($"String 's' length ({s.Length}) does not match provided length 'n' ({n}).");

        if (s.Any(c => char.IsWhiteSpace(c)))
            throw new ArgumentException("String 's' must not contain spaces.");

        if (s.Any(c => c > 127))
            throw new ArgumentException("String 's' contains non-ASCII characters.");
    }

    public static string CaesarCipher(string s, int k)
    {
        CheckConstraints(s.Length, s, k);

        StringBuilder cipherText = new StringBuilder(s.Length);

        foreach (var character in s)
        {
            if (char.IsLetter(character))
            {
                char baseChar = char.IsUpper(character) ? 'A' : 'a';

                var shiftedLetter = (char)(baseChar + (character - baseChar + k) % 26);

                cipherText.Append(shiftedLetter);
            }
            else
                cipherText.Append(character);
        }

        return cipherText.ToString();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.CaesarCipher(s, k);

        Console.WriteLine(result);
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
