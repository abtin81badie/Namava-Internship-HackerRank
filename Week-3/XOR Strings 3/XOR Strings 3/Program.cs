using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Solution
{
    class Solution
    {
        public static String strings_xor(String s, String t)
        {
            return string.Concat(s.Zip(t, (c1, c2) => c1 == c2 ? '0' : '1'));
        }

        public static String stringsXorStringBuilder(String s, String t)
        {
            var result = new StringBuilder();

            int i = 0;

            foreach (var c in s)
            {
                if (c == t[i])
                    result.Append('0');
                else
                    result.Append('1');
            }

            return result.ToString();
        }

        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            var s = Console.ReadLine();
            var t = Console.ReadLine();

            var xorResult = strings_xor(s, t);

            Console.WriteLine(xorResult);
        }
    }
}