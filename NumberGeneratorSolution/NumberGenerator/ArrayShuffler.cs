using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGenerator
{
    public class ArrayShuffler
    {
        /// <summary>
        /// Here, an array element can change its value only once
        /// Start loop with an initial data
        /// Swap the items from randomly chosen position and current index (from entire array)
        /// Then swap number from randomly chosen position and current index (from remaining array excluding lastly swapped position)
        /// This way, every time we swap with random number generated from remaining array only 
        /// </summary>
        public void DoOptimalShuffle(int[] data, int option = 3)
        {
            var random = new Random();
            for (int index = data.Length - 1; index > 0; index--)
            {
                if (option != 3)
                {
                    random = ConstructRandom(option);
                }
                int randomPosition = random.Next(index + 1);
                (data[index], data[randomPosition]) = (data[randomPosition], data[index]);
            }
        }

        private Random ConstructRandom(int option)
        {
            switch (option)
            {
                // Approach 1: Using random ctor inside tight loop
                // Issue: Each time it uses the same seed (i.e. ticks) so the random will not be pure
                case 1:
                    return new Random();
                //Approach 2: Initialize Random outside tight loop, and only use next()
                // Better: Each time next() is called there will be newer random output
                case 2:
                    return new Random(Guid.NewGuid().GetHashCode());
                //Approach 3: Initialize the random() number using the Guid inside loop
                // Best: provides the perfect output (caveat: as some delay is added)
                default:
                    return null;
            }
        }

        /// <summary>
        /// Here, an array element can change its value many times
        /// Loop through each number in the data
        /// Swap the number in randomly chosen position in entire current array with current index number
        /// </summary>
        public void DoSimpleShuffle(int[] data)
        {
            for (int index = data.Length - 1; index > 0; index--)
            {
                int randomPosition = new Random().Next(data.Length);
                (data[randomPosition], data[index]) = (data[index], data[randomPosition]);
            }
        }
    }
}
