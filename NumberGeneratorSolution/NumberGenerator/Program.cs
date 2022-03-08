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
            int n = 4;
            Console.WriteLine("-- Approach1: Use simple shuffling algorithm --");
            Console.WriteLine(string.Join(",", BasicAlgorithm(n)));

            Console.WriteLine("\n-- Approach2: Use optimal shuffling algorithm --");
            Console.WriteLine(string.Join(",", OptimalAlgorithm(n)));

            // Some Load Tests
            PerformLoadTests();

            // Perform randomness shuffling test
            PerformRandomnessTests();

            Console.WriteLine("End Of Program !!!");
            Console.ReadLine();
        }

        private static int[] OptimalAlgorithm(int n)
        {
            
            int[] data = Utility.GenerateData(n);
            new ArrayShuffler().DoOptimalShuffle(data);
            return data;
        }

        private static int[] BasicAlgorithm(int n)
        {
            
            int[] data = Utility.GenerateData(n);
            new ArrayShuffler().DoSimpleShuffle(data);
            return data;
        }

        private static void PerformRandomnessTests()
        {
            int n = 4;
            int repeat = 600000;
            Console.WriteLine("\n-- Randomness Test (Optimal Shuffling) --");
            ArrayShufflerStressTest.DoRandomnessTest(n, repeat);
        }

        private static void PerformLoadTests()
        {
            Console.WriteLine("\n-- Stress Test --");
            ArrayShufflerStressTest.CompareRunTimeWithIncreasingN(new int[]
                { 100, 1000, 10000, 100000, 1000000 });
        }
    }
}
