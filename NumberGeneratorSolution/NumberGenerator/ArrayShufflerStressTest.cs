using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGenerator
{
    /// <summary>
    /// We are trying to shuffle the array multiple times and count the unique outcomes
    /// Comparison done using simple v/s optimal approach
    /// </summary>
    static class ArrayShufflerStressTest
    {
        public static void CompareRunTimeWithIncreasingN(int[] nArray)
        {
            Dictionary<int, (long, long)> dict = new Dictionary<int, (long, long)>();
            foreach (int x in nArray)
            {
                // Get runtime for simple algorithm
                int[] data = Utility.GenerateData(x);
                int[] clonedData = Utility.DeepCopyArray(data);
                Stopwatch timer1 = new Stopwatch();
                timer1.Start();
                new ArrayShuffler().DoSimpleShuffle(clonedData);
                timer1.Stop();

                // Get runtime for optimal algorithm
                Stopwatch timer2 = new Stopwatch();
                timer2.Start();
                new ArrayShuffler().DoOptimalShuffle(data);
                timer2.Stop();

                dict.Add(x, (timer1.ElapsedMilliseconds, timer2.ElapsedMilliseconds));
            }

            // Print the comparative results
            PrintResults(dict);
        }


        public static void DoRandomnessTest(int number, int repetitions = 1000)
        {
            Dictionary<string, long> dict = new Dictionary<string, long>();

            int i = 0;
            while (i++ < repetitions)
            {
                int[] data = Utility.GenerateData(number);
                new ArrayShuffler().DoOptimalShuffle(data);
                string key = string.Join("", data);
                if (dict.TryGetValue(key, out long counter))
                {
                    dict[key] = counter + 1;
                }
                else
                {
                    dict.Add(key, 1);
                }
            }

            PrintResults(dict);
        }

        #region private helper methods
        private static void PrintResults(Dictionary<string, long> dict)
        {
            const int OFFSET = -8;
            Console.WriteLine($"{"Pattern",OFFSET} | {"Repetitions",OFFSET}");
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key,OFFSET} | {item.Value,OFFSET}");
            }
        }

        private static void PrintResults(Dictionary<int, (long, long)> dict)
        {
            const int OFFSET = -10;
            Console.WriteLine($"{"Count",OFFSET} | {"Simple (ms)",OFFSET} | {"Optimal (ms)",OFFSET}");
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key,OFFSET} | {item.Value.Item1,OFFSET} | {item.Value.Item2,OFFSET}");
            }
        }

        #endregion
    }
}
