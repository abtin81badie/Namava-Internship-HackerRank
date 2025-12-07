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
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */
    private static void CheckConstraints(List<int> ranked, List<int> player)
    {
        if (ranked.Count < 1 || ranked.Count > 2 * Math.Pow(10,5))
            throw new ArgumentException($"Ranked count (n) is {ranked.Count}. Must be between 1 and 200,000.");

        if (player.Count < 1 || player.Count > 2 * Math.Pow(10, 5))
            throw new ArgumentException($"Player count (m) is {player.Count}. Must be between 1 and 200,000.");

        if (ranked.Any(r => r < 0 || r > Math.Pow(10, 9)))
            throw new ArgumentException("Ranked contains values out of range 0 to 10^9.");

        if (player.Any(p => p < 0 || p > Math.Pow(10, 9)))
            throw new ArgumentException("player contains values out of range 0 to 10^9.");
        
        if (ranked.Where((r, i) => i > 0 && r > ranked[i - 1]).Any())
            throw new ArgumentException("Ranked leaderboard is not in descending order.");

        if (player.Where((p, i) => i > 0 && p < player[i - 1]).Any())
            throw new ArgumentException("Player scores are not in ascending order.");
    }

    public static List<int> ClimbingLeaderboard(List<int> ranked, List<int> player)
    {
        CheckConstraints(ranked, player);   

        var distinctRanker = ranked.Distinct().ToList();

        var result = new List<int>();
        var index = distinctRanker.Count - 1 ;

        foreach (var score in player) 
        {
            while (index >= 0
                   && score >= distinctRanker[index])
                index--;

            result.Add(index + 2);
        }

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.ClimbingLeaderboard(ranked, player);

        Console.WriteLine(String.Join("\n", result));
    }
}
