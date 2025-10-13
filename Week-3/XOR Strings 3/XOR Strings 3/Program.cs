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
                result.Append((s[i] - '0') ^ (t[i] - '0'));
            }
            return result.ToString();
        }

        public static String StringsXor(String s, String t)
        {
            return string.Concat(s.Zip(t, (c1, c2) => c1 == c2 ? '0' : '1'));
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

            var xorResult = StringsXor(s, t);

            Console.WriteLine(xorResult);
        }
    }
}