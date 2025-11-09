using System;
class Result
{
    private static void CheckConstraints(int number)
    {
        if (number < 1 || number > Math.Pow(10, 5))
            throw new ArgumentOutOfRangeException(nameof(number),
                $"The number must be between 1 and 10_000. Provided value: {number}");

    }

    public static bool IsSmartNumber(int number)
    {
        CheckConstraints(number);

        int val = (int)Math.Sqrt(number);
        return val * val == number;
    }

}


class Solution
{
    public static void Main()
    {
        // Read the number of test cases
        int testCases = int.Parse(Console.ReadLine());

        // Process each test case
        for (int i = 0; i < testCases; i++)
        {
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(Result.IsSmartNumber(num) ? "YES" : "NO");
        }
    }
}