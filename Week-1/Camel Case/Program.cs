using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static string SplitCamelCase(string type, string input)
    {
        List<string> list = new List<string>();

        if (type == "M")
        {
            string temp = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                {
                    list.Add(temp.ToLower());
                    temp = "";
                }

                if (input[i] == '(')
                {
                    list.Add(temp.ToLower());
                    break;
                }

                temp += input[i];
            }
        }

        if (type == "C")
        {
            string temp = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                {
                    list.Add(temp.ToLower());
                    temp = "";
                }

                if (i == input.Length - 1)
                {
                    temp += input[i];
                    list.Add(temp.ToLower());
                    break;
                }

                temp += input[i];
            }
        }

        if (type == "V")
        {
            string temp = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                {
                    temp += input[i];
                }

                if (char.IsUpper(input[i]))
                {
                    list.Add(temp.ToLower());
                    temp = "";
                }

                if (i == input.Length - 1)
                {
                    temp += input[i];
                    list.Add(temp.ToLower());
                    break;
                }
                
                if (i != 0)
                {
                    temp += input[i];
                }
               
            }
        }

        return string.Join(" ",list).TrimStart();
    }

    static string ToUpperFirst(string input)
    {
        return char.ToUpper(input[0]) + input.Substring(1);
    }

    static string CombineCamelCase(string type, string input)
    {
        string[] strings = input.Split(' ');
        string result = "";
        if (type == "M")
        {
            result += strings[0];
            for (int i = 1; i < strings.Length; i++) 
            {
                result += ToUpperFirst(strings[i]);
            }
            result += "()";
        }

        if (type == "C")
        {
            for (int i = 0; i < strings.Length; i++) 
            {
                result += ToUpperFirst(strings[i]);
            }
        }

        if (type == "V")
        {
            result += strings[0];
            for (int i = 1; i < strings.Length; i++)
            {
                result += ToUpperFirst(strings[i]);
            }
        }

        return result;
    }
    static void Main(String[] args)
    {
        string line;
        while ((line = Console.ReadLine()) != null && !string.IsNullOrEmpty(line))
        {
            string[] parts = line.Split(';');
            string operation = parts[0];
            string type = parts[1];
            string content = parts[2];

            string result = "";
            if (operation == "S")
            {
                result = SplitCamelCase(type, content); 
            }
            else if (operation == "C") 
            {
                result = CombineCamelCase(type, content);   
            }

            Console.WriteLine(result);
        }
    }
}