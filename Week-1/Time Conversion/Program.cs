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
    public static string timeConversion(string s)
    {
        string amPm = s.Substring(8, 2);

        int hours = int.Parse(s.Substring(0, 2));

        if (amPm == "PM")
        {
            if (hours != 12)
            {
                hours += 12;
            }
        }

        else 
        {
            if (hours == 12)
            {
                hours = 0;
            }
        }

        StringBuilder resultBuilder = new StringBuilder();

        resultBuilder.Append(hours.ToString("D2"));
        resultBuilder.Append(s.Substring(2,6));

        return resultBuilder.ToString();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.timeConversion(s);
        Console.WriteLine(result);
        //textwriter.writeline(result);

        //textwriter.flush();
        //textwriter.close();
    }
}
