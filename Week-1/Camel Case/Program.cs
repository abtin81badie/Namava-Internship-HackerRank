using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
class Solution
{
    // Helpers and Parsers
    private enum Operation { Split, Combine }
    private enum IdentifierType { Method, Class, Variable }

    private static (string, string, string) ParseInput(string line)
    {
        string[] parts = line.Split(';');
        return (parts[0], parts[1], parts[2]);
    }

    private static Operation ParseOperation(string opStr) => opStr switch
    {
        "S" => Operation.Split,
        "C" => Operation.Combine,
        _ => throw new InvalidOperationException("Invalid Operation Type."),
    };

    private static IdentifierType ParseIdentifierType(string typeStr) => typeStr switch
    {
        "M" => IdentifierType.Method,
        "C" => IdentifierType.Class,
        "V" => IdentifierType.Variable,
        _ => throw new InvalidOperationException("Invalid Identifier Type."),
    };

    // Routes the request to the correct conversion methode.
    private static string Process(Operation operation, IdentifierType identifierType, string content)
    {
        return operation switch
        {
            Operation.Split => SplitIdentifier(identifierType, content),
            Operation.Combine => CombineIdentifier(identifierType, content),
            _ => throw new InvalidOperationException("Invalid  operation."),
        };
    }

    private static string SplitIdentifier(IdentifierType type, string input)
    {
        string cleanInput = type == IdentifierType.Method ? input.Replace("()", "") : input;

        string spaced = Regex.Replace(cleanInput, "(?<=[a-z])(?=[A-Z])", " ");

        return spaced.ToLower();
    }

    // Old Implementaion
    private static string SplitIdntifierWithLoop(IdentifierType type, string input)
    {
        string cleanInput = type == IdentifierType.Method ? input.Replace("()", "") : input;

        var builder = new StringBuilder();
        builder.Append(cleanInput[0]);

        for (int i = 1; i < cleanInput.Length; i++)
        {
            if (char.IsUpper(cleanInput[i]))
            {
                builder.Append(' ');
            }
            builder.Append(cleanInput[i]);
        }

        return builder.ToString().ToLower();
    }


    private static string CapitalizeFirstLetter(string input)
    {
        return string.IsNullOrEmpty(input) ? input : char.ToUpper(input[0]) + input.Substring(1);
    }

    private static string CombineIdentifier(IdentifierType type, string input)
    {
        var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var transformedWords = words.Select((word, index) =>
        {
            if (type == IdentifierType.Class)
            {
                return CapitalizeFirstLetter(word);
            }
            else
            {
                return index == 0 ? word.ToLower() : CapitalizeFirstLetter(word);
            }
        });

        var combined = string.Concat(transformedWords);

        var result = type == IdentifierType.Method ? $"{combined}()" : combined;

        return result;
    }

    // Old Implementaion 
    private static string CombineIdentifierWithLoop(IdentifierType type, string input)
    {
        string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var builder = new StringBuilder();

        for (int i = 0; i < words.Length; i++)
        {
            string currentWord = words[i];
            if (type == IdentifierType.Class)
            {
                builder.Append(CapitalizeFirstLetter(currentWord));
            }
            else
            {
                if (i == 0)
                {
                    builder.Append(currentWord.ToLower());
                }
                else
                {
                    builder.Append(CapitalizeFirstLetter(currentWord));
                }
            }
        }

        if (type == IdentifierType.Method)
        {
            builder.Append("()");
        }

        return builder.ToString();
    }
    static void Main(String[] args)
    {
        string line;
        while ((line = Console.ReadLine()) != null && !string.IsNullOrEmpty(line))
        {
            var (operationStr, typeStr, content) = ParseInput(line);

            var operation = ParseOperation(operationStr);
            var identifierType = ParseIdentifierType(typeStr);

            string result = Process(operation, identifierType, content);
            Console.WriteLine(result);
        }
    }
}