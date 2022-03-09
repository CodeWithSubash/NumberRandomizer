using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Driver Code
            // TODO Use command line to input the parameter and check for the validity
            int n = 4;
            Console.WriteLine("-- Approach1: Use simple shuffling algorithm --");
            Console.WriteLine(string.Join(",", BasicAlgorithm(n)));

            Console.WriteLine("\n-- Approach2: Use optimal shuffling algorithm --");
            Console.WriteLine(string.Join(",", OptimalAlgorithm(n)));

            // Some Load Tests
            Console.WriteLine("\n-- Stress Test Comparison Simple V/S Optimal Solution --");
            PerformLoadTests();

            // Some Randomness Tests
            Console.WriteLine("\n-- Randomness Test for high number of repetitions --");
            PerformRandomnessTests();

            Console.WriteLine("End Of Program !!!");
            Console.ReadLine();
        }

        private static int[] OptimalAlgorithm(int n)
        {
            int[] data = Enumerable.Range(1, n).ToArray();
            new ArrayShuffler().DoOptimalShuffle(data);
            return data;
        }

        private static int[] BasicAlgorithm(int n)
        {
            int[] data = Enumerable.Range(1, n).ToArray();
            new ArrayShuffler().DoSimpleShuffle(data);
            return data;
        }

        private static void PerformLoadTests()
        {
            var result = ArrayShufflerStressTest.CompareRunTime(new int[]
                { 100, 1000, 10000, 100000, 1000000 });

            // Print the comparative results
            PrintUtility.PrintResults(result);
        }

        private static void PerformRandomnessTests()
        {
            int n = 4;
            int[] data = Enumerable.Range(1, n).ToArray();
            int repetition = 60000;
            var result = ArrayShufflerRandomnessTest.DoRandomnessTest(data, repetition);

            // Print the comparative results
            PrintUtility.PrintResults(result);
        }
    }
}
