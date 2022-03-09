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
    public static class ArrayShufflerStressTest
    {
        public static Dictionary<int, (long, long)> CompareRunTime(int[] nArray)
        {
            Dictionary<int, (long, long)> dict = new Dictionary<int, (long, long)>();
            foreach (int x in nArray)
            {
                // Get runtime for simple algorithm
                int[] data = Enumerable.Range(1, x).ToArray();
                Stopwatch timer1 = new Stopwatch();
                timer1.Start();
                new ArrayShuffler().DoSimpleShuffle(data);
                timer1.Stop();

                // Get runtime for optimal algorithm
                data = Enumerable.Range(1, x).ToArray();
                Stopwatch timer2 = new Stopwatch();
                timer2.Start();
                new ArrayShuffler().DoOptimalShuffle(data);
                timer2.Stop();

                dict.Add(x, (timer1.ElapsedMilliseconds, timer2.ElapsedMilliseconds));
            }
            return dict;
        }
    }
}
