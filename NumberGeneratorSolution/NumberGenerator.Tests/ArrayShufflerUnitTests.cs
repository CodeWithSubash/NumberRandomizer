using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberGenerator.Tests
{
    /// <summary>
    /// Checking randomness is challenging because in unit test we usually test the expected value
    /// But, here we don't have expected value for random output
    /// </summary>
    [TestClass]
    public class ArrayShufflerUnitTests
    {

        [TestMethod]
        public void ShuffledResult_ShouldContainExactSameLength()
        {
            //Assign
            int[] data = new int[] { 1, 2, 3, 4 };

            //Act
            new ArrayShuffler().DoOptimalShuffle(data);

            //Assert
            Assert.AreEqual(4, data.Length);
        }

        [TestMethod]
        public void ShuffledResult_ShouldContainAllElements()
        {
            //Assign
            int[] data = new int[] { 1, 2, 3, 4 };

            //Act
            new ArrayShuffler().DoOptimalShuffle(data);

            //Assert
            int[] org = new int[] { 1, 2, 3, 4 };
            foreach (int x in org)
            {
                Assert.IsTrue(data.ToList().Contains(x));
            }
        }

        [TestMethod]
        public void ShuffledResult_ShufflingWithSameSeed_ShouldBeEqual()
        {
            //Assign & Act1
            int[] data1 = new int[] { 1, 2, 3, 4 };
            new ArrayShuffler().DoOptimalShuffle(data1);

            //Assign & Act2
            int[] data2 = new int[] { 1, 2, 3, 4 };
            new ArrayShuffler().DoOptimalShuffle(data2);

            //Assert
            Assert.IsTrue(data1.ToList().SequenceEqual(data2));
        }
    }
}
