using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Solution
{
    class Solution
    {
        public static String StringsXorOperator(String s, String t)
        {
            var result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                result.Append((s[i]) ^ (t[i]));
            }
            return result.ToString();
        }

        public static string StringsXor(string s, string t)
        {
            Func<char, char, char> characterXorLogic = (char1, char2) =>
            {
                if (char1 == char2)
                    return '0';
                else
                    return '1';
            };

            IEnumerable<char> xorResultSequence = s.Zip(t, characterXorLogic);

            string finalResult = string.Concat(xorResultSequence);

            return finalResult;
        }

        public static String StringsXorStringBuilder(String s, String t)
        {
            var result = new StringBuilder();

            int index = 0;

            foreach (var c in s)
            {
                if (c == t[index])
                    result.Append('0');
                else
                    result.Append('1');

                index++;
            }

            return result.ToString();
        }

        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            var s = Console.ReadLine();
            var t = Console.ReadLine();

            var xorResult = StringsXorOperator(s, t);

            Console.WriteLine(xorResult);
        }
    }
}