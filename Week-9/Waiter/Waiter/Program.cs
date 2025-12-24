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
     * Complete the 'waiter' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     * 1. INTEGER_ARRAY number
     * 2. INTEGER q
     */

    private static void CheckConstraints(List<int> numbers, int q)
    {
        if (q < 1 || q > 1200)
            throw new ArgumentException("The number of queries must be between 1 and 1200.");

        if (numbers.Count < 1 || numbers.Count > Math.Pow(10,5))
            throw new ArgumentException("The count of numbers must be between 1 and 10^5.");

        if (numbers.Any(number => number < 2 || number > Math.Pow(10,4)))
            throw new ArgumentException("Each individual number in the list must be between 2 and 10^4.");

    }

    private static bool IsPrime(int n)
    {
        if (n <= 1) 
            return false;
        if (n == 2) 
            return true;
        if (n % 2 == 0) 
            return false;

        for (int i = 3; i * i <= n; i += 2)
        {
            if (n % i == 0) return false;
        }

        return true;
    }

    private static List<int> GetPrimes(int q)
    {
        var primes = new List<int>();
        var number = 2;

        while (primes.Count < q)
        {
            if (IsPrime(number))
            {
                primes.Add(number);
            }
            number++;
        }

        return primes;
    }

    public static List<int> Waiter(List<int> number, int q)
    {
        CheckConstraints(number, q); 

        var primeNumbers = GetPrimes(q);

        var currentPile = new Stack<int>(number);
        var finalResults = new List<int>();

        foreach (var primeNumber in primeNumbers)
        {
            var divisiblePile = new Stack<int>();
            var nonDivisiblePile = new Stack<int>();

            foreach (var plate in currentPile)
            {
                if (plate % primeNumber == 0)
                    divisiblePile.Push(plate);
                else
                    nonDivisiblePile.Push(plate);
            }

            finalResults.AddRange(divisiblePile);

            currentPile = nonDivisiblePile;
        }

        finalResults.AddRange(currentPile);

        return finalResults;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int q = Convert.ToInt32(firstMultipleInput[1]);

        List<int> number = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(numberTemp => Convert.ToInt32(numberTemp)).ToList();

        List<int> result = Result.Waiter(number, q);

        Console.WriteLine(String.Join("\n", result));
    }
}
