using System.Reflection.Metadata;

class Result
{
    private const int NumberOfEnglishAlphabets = 26;
    private static void CheckConstraints(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length > 1000)
            throw new ArgumentException("String cannot be null, empty, or longer that 1000 characters.");

        if (s.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
            throw new ArgumentException("Only letters and spaces are allowed.");
    }

    // Solution 4
    public static string PangramsWithLINQ(string s)
    {
        var uniqueLettersCount = s.ToLower()
            .Where(char.IsLetter)
            .Distinct().Count();

        var result = uniqueLettersCount == NumberOfEnglishAlphabets ? "pangram" : "not pangram";

        return result;
    }

    // Solution 3
    public static string PangramsWithContain(string s)
    {
        var lowerInput = s.ToLower();
        var alphabets = "abcdefgijklmnopqrstuvwxyz";

        foreach (var alphabat in alphabets)
        {
            if (!lowerInput.Contains(alphabat))
                return "not pangram";
        }

        return "pangram";
    }

    // Solution 2
    public static string PangramsHashSolution(string s)
    {
        var distinctLetter = new HashSet<char>(s.ToLower().Where(char.IsLetter));

        var result = distinctLetter.Count == NumberOfEnglishAlphabets ? "pangram" : "not pangram";

        return result;
    }

    // Solution 1
    public static string Pangrams(string s)
    {
        CheckConstraints(s);

        var alphabetFound = new bool[26];

        foreach (var character in s.ToLower())
        {
            int index = character - 'a';
            if (index >= 0 && index <= 25)
                alphabetFound[index] = true;
        }

        bool isPangram = alphabetFound.Count(found => found) == NumberOfEnglishAlphabets;

        var result = isPangram ? "pangram" : "not pangram";

        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.Pangrams(s);

        Console.WriteLine(result);

        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}

