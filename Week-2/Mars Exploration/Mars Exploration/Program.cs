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
    private static int countSosDeviations(string message)
    {
        const string sos = "SOS";

        int differenceCount = 0;

        // 'S'
        if (message[0] != sos[0])
        {
            differenceCount++;
        }

        // 'O'
        if (message[1] != sos[1])
        {
            differenceCount++;
        }

        // 'S'
        if (message[2] != sos[2])
        {
            differenceCount++;
        }

        return differenceCount;
    }

    public static int marsExploration(string s)
    {
        int stringLength = s.Length;
        string SosBuffer = "";
        int changedLettersNumber = 0;

        for (int i = 0; i < stringLength; i++) 
        {
            SosBuffer += s[i];
            if (i%3 == 2)
            {
                changedLettersNumber += countSosDeviations(SosBuffer); 
                SosBuffer = "";
            }
        }

        return changedLettersNumber;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int result = Result.marsExploration(s);

        Console.WriteLine(result);

        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
