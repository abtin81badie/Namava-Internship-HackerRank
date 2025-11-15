using System;
using System.IO;
using System.Linq;

class Solution
{

    private static int[] month = new int[15];

    private static void UpdateLeapYear(int year)
    {
        if (year % 400 == 0)
            month[2] = 29;
        else if (year % 100 == 0)
            month[2] = 28;
        else if (year % 4 == 0)
            month[2] = 29;
        else
            month[2] = 28;
    }

    /**
     * Initializes the month array with the number of days in each month (for a non-leap year).
     */
    private static void StoreMonth()
    {
        month[1] = 31;
        month[2] = 28;
        month[3] = 31;
        month[4] = 30;
        month[5] = 31;
        month[6] = 30;
        month[7] = 31;
        month[8] = 31;
        month[9] = 30;
        month[10] = 31;
        month[11] = 30;
        month[12] = 31;
    }

    private static void CheckConstraints(int d1, int m1, int y1, int d2, int m2, int y2)
    {
        if (d1 < 1 || d1 > 31 || d2 < 1 || d2 > 31)
            throw new ArgumentException("Constraint violation: Day (d1, d2) must be between 1 and 31.");

        if (m1 < 1 || m1 > 12 || m2 < 1 || m2 > 12)
            throw new ArgumentException("Constraint violation: Month (m1, m2) must be between 1 and 12.");

        if (y1 < 1000 || y1 > 9999 || y2 < 1000 || y2 > 9999)
            throw new ArgumentException("Constraint violation: Year (y1, y2) must be between 1000 and 9999.");

        if (y1 > y2)
            throw new ArgumentException("Constraint violation: Start year (y1) must be less than or equal to end year (y2).");
    }

    private static int FindLuckyDates(int d1, int m1, int y1, int d2, int m2, int y2)
    {
        CheckConstraints(d1, m1, y1, d2, m2, y2);

        StoreMonth();
        int result = 0;

        while (true)
        {
            long x = d1;
            x = x * 100 + m1;
            x = x * 10000 + y1;

            if (x % 4 == 0 || x % 7 == 0)
                result++;

            if (d1 == d2 && m1 == m2 && y1 == y2)
                break;

            UpdateLeapYear(y1);

            d1 = d1 + 1;
            if (d1 > month[m1])
            {
                m1 = m1 + 1;
                d1 = 1;
                if (m1 > 12)
                {
                    y1 = y1 + 1;
                    m1 = 1;
                }
            }
        }
        return result;
    }

    public static void Main(string[] args)
    {
        string str = Console.ReadLine();

        string[] parts = str.Replace('-', ' ').Split(' ');

        int d1 = Convert.ToInt32(parts[0]);
        int m1 = Convert.ToInt32(parts[1]);
        int y1 = Convert.ToInt32(parts[2]);
        int d2 = Convert.ToInt32(parts[3]);
        int m2 = Convert.ToInt32(parts[4]);
        int y2 = Convert.ToInt32(parts[5]);

        CheckConstraints(d1, m1, y1, d2, m2, y2);

        int result = FindLuckyDates(d1, m1, y1, d2, m2, y2);
        Console.WriteLine(result);
    }
}