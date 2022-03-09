using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberGenerator.Tests
{
    [TestClass]
    public class ArrayShufflerRandomnessTests
    {
        [TestMethod]
        public void ShuffledResult_InitializeRandomInsideLoop_ResultsLessRandomness()
        {
            //Assign
            int[] data = Enumerable.Range(1, 4).ToArray();

            //Act
            int repeat = 600000;
            var dictionary = ArrayShufflerRandomnessTest.DoRandomnessTest(data, repeat, 1);

            //Assert (View the randomness results)
            int expectedRandomness = repeat / (4 * 3 * 2 * 1);
            double allowedOffset = 0.1 * expectedRandomness;
            int counter=0;
            foreach (var ele in dictionary)
            {
                if(Math.Abs(expectedRandomness - ele.Value) > allowedOffset)
                {
                    counter++;
                }
            }
            Assert.IsTrue(counter > 0);
        }


        [TestMethod]
        public void ShuffledResult_InitializeRandomWithGuid_MatchesBelowTenPercentOffset()
        {
            //Assign
            int[] data = Enumerable.Range(1, 4).ToArray();

            //Act
            int repeat = 600000;
            var dictionary = ArrayShufflerRandomnessTest.DoRandomnessTest(data, repeat, 2);

            //Assert (View the randomness results)
            int expectedRandomness = repeat / (4 * 3 * 2 * 1);
            double allowedOffset = 0.1 * expectedRandomness;
            foreach(var ele in dictionary)
            {
                Assert.AreEqual(expectedRandomness, ele.Value, allowedOffset);
            }
        }

        private bool NearlyEqual(int x, int y, double epsilon)
        {
            float diff = Math.Abs(x - y);
            return diff / (x + y) < epsilon;
        }
    }
}
