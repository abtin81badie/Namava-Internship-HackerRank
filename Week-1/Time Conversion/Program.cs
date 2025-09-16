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
        string[] strings = s.Split(':');
        bool flag = strings[2].Contains("AM");

        string hh = null;
        string mm = null;
        string ss = null;

        if (flag)
        {
            ss = strings[2].Split('A')[0];
            mm = strings[1];
            hh = strings[0];
            if (hh == "12")
            {
                hh = "00";
            }
        }
        else 
        {
            ss = strings[2].Split('P')[0];
            mm = strings[1];
            hh = strings[0];
            if (hh != "12")
            {
                hh = (int.Parse(strings[0]) + 12).ToString();
            }
        }

        return $"{hh:D2}:{mm}:{ss}";
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
