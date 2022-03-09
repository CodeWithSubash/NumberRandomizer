using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGenerator
{
    public static class PrintUtility
    {

        public static void PrintResults(Dictionary<int, (long, long)> dict)
        {
            const int OFFSET = -10;
            Console.WriteLine($"{"Count",OFFSET} | {"Simple (ms)",OFFSET} | {"Optimal (ms)",OFFSET}");
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key,OFFSET} | {item.Value.Item1,OFFSET} | {item.Value.Item2,OFFSET}");
            }
        }

        public static void PrintResults(Dictionary<string, long> dict)
        {
            const int OFFSET = -8;
            Console.WriteLine($"{"Pattern",OFFSET} | {"Repetitions",OFFSET}");
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key,OFFSET} | {item.Value,OFFSET}");
            }
        }
    }
}
