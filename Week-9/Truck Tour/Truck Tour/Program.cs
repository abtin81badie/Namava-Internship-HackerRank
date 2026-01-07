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
     * Complete the 'truckTour' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY petrolpumps as parameter.
     */
    private static void CheckConstraints(List<List<int>> petrolpumps)
    {
        if (petrolpumps.Count < 1 || petrolpumps.Count > Math.Pow(10, 5))
            throw new ArgumentException("N is out of range");

        if (petrolpumps.Any(petrolpump =>
        petrolpump[0] < 1 || petrolpump[0] > Math.Pow(10, 9) ||
        petrolpump[1] < 1 || petrolpump[1] > Math.Pow(10, 9)))
        {
            throw new ArgumentException("Petrol or Distance values are out of range");
        }
    }

    public static int TruckTour(List<List<int>> petrolpumps)
    {
        CheckConstraints(petrolpumps);

        var start = 0;
        var currentFuel = 0;

        for (var i = 0; i < petrolpumps.Count; i++)
        {
            var petrol = petrolpumps[i].First();
            var distance = petrolpumps[i].Last();

            currentFuel += petrol - distance;

            if (currentFuel < 0)
            {
                start = i + 1;
                currentFuel = 0;
            }

        }

        return start;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> petrolpumps = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            petrolpumps.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(petrolpumpsTemp => Convert.ToInt32(petrolpumpsTemp)).ToList());
        }

        int result = Result.TruckTour(petrolpumps);

        Console.WriteLine(result);
    }
}
