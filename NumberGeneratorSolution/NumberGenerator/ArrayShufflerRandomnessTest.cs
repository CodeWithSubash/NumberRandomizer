using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGenerator
{
    public static class ArrayShufflerRandomnessTest
    {
        public static Dictionary<string, long> DoRandomnessTest(int[] data, int repetitions, int option = 3)
        {
            Dictionary<string, long> dict = new Dictionary<string, long>();

            int i = 0;
            while (i++ < repetitions)
            {
                new ArrayShuffler().DoOptimalShuffle(data, option);
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
            return dict;
        }
    }
}
