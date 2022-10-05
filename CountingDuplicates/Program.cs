using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountingDuplicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DuplicateCount("aAbcde"));
            Console.ReadKey();
        }


        public static int DuplicateCount(string str)
        {
            var strDownRegistor = str.ToLower();
            var strDuplicate = strDownRegistor.ToCharArray().Distinct().ToArray();
            if (strDuplicate.Length == str.Length)
            {
                return 0;
            }
            int count = 0;

            var res = strDownRegistor.GroupBy(x => x).Any(x => x.Count() > 1);
            var res1 = strDownRegistor.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x);
            foreach (var item in res1.Select(y=>y.Key))
                Console.WriteLine(item);
            return res1.Select(z=>z.Key).Count();
        }

        public static int DuplicateCount1(string str)
        {
            return str.ToLower().GroupBy(c => c).Where(g => g.Count() > 1).Count();
        }

        public static int DuplicateCount2(string str)
        {
            return str.ToLower().GroupBy(c => c).Count(c => c.Count() > 1);
        }

        public static int DuplicateCount3(string str)
        {
            return str.GroupBy(char.ToLower).Count(x => x.Count() > 1);
        }
    }
}
