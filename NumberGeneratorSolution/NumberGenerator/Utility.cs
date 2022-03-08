using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGenerator
{
    public static class Utility
    {
        public static int[] GenerateData(int n)
        {
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = i + 1;
            }
            return result;
        }

        public static int[] DeepCopyArray(int[] numbers)
        {
            int[] result = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = numbers[i];
            }
            return result;
        }
    }
}
