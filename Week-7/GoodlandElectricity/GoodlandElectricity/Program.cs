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
     * Complete the 'pylons' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY arr
     */
    private struct LineSegment
    {
        public int StartPoint;
        public int EndPoint;

        public LineSegment(int startPoint, int endPoint)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }

    }

    public static int Pylons(int k, List<int> arr)
    {
        var lineSegments = new List<LineSegment>();

        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] == 1)
            {
                int startPoint = Math.Max(0, i - k + 1);
                int endPoint = Math.Min(arr.Count - 1, i + k - 1);

                lineSegments.Add(new LineSegment(startPoint, endPoint));
            }
        }

        lineSegments.Sort((a, b) =>
        {
            int result = a.StartPoint.CompareTo(b.StartPoint);
            return result;
        });

        var pylonsCount = 0;
        var currentUncoveredIndex = 0;
        var segmentIndex = 0;

        while (currentUncoveredIndex < arr.Count)
        {
            var bestReach = -1;

            while (segmentIndex < lineSegments.Count &&
                    lineSegments[segmentIndex].StartPoint <= currentUncoveredIndex)
            {
                if (lineSegments[segmentIndex].EndPoint > bestReach)
                    bestReach = lineSegments[segmentIndex].EndPoint;

                segmentIndex++;
            }

            if (bestReach < currentUncoveredIndex)
                return -1;

            pylonsCount++;

            currentUncoveredIndex = bestReach + 1;
        }

        return pylonsCount;
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.Pylons(k, arr);

        Console.WriteLine(result);

    }
}
