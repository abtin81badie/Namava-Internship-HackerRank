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
     * Complete the 'stockmax' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts INTEGER_ARRAY prices as parameter.
     */
    private static void CheckConstraints(List<int> prices)
    {
        if (prices.Count < 1 || prices.Count > 5 * Math.Pow(10, 4))
            throw new ArgumentException("The number of prices must be between 1 and 50,000.");

        if (prices.Any(price => price < 1 || price > Math.Pow(10,5)))
            throw new ArgumentException("Each stock price must be betwenn 1 and 100,000. One or more values fall outside this range.");
    }

    public static long Stockmax(List<int> prices)
    {
        CheckConstraints(prices);

        long profit = 0;
        var currentMax = 0;

        for (var i = prices.Count - 1; i >= 0; i--)
        {
            if (prices[i] > currentMax)
                currentMax = prices[i];
            else
                profit += currentMax - prices[i];
        }

        return profit;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> prices = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(pricesTemp => Convert.ToInt32(pricesTemp)).ToList();

            long result = Result.Stockmax(prices);

            Console.WriteLine(result);
        }
    }
}
