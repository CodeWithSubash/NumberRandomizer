## Random Number Shuffling
Using the language of your choice implement the following program named Shuffle:  
Input a single integer N. Output the integers 1..N in random order. Your algorithm should optimize for speed.  

## Solution
First, I approached the problem with basic non-optimal solution first and observed the behavior  
Finally, I rewrote some logic to come up with the optimal solution
Note: I have done performance testing and included the metrices to compare both approaches

## Algorithms (Optimal Solution)
The main logic is to pick the random number from the remaining array list, and put the picked item on right hand side of same array.
1. Loop n items
2. Pick a random index using Randomizer() method between 0(inclusive) to n (exclusive) 
3. Swap the element pointed by random index and current index
4. Set n=n-1
5. Repeat step t to 4

Ref: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle

## Using the random method
### Approach1: Constructing random object inside tight loop
- When we are inside the tight loop, every time the random object is constructed with the same seed values (C# uses the ticks)  
- This results in not pure random number generation
- The regression tests shows the output not quiet satisfactory

### Approach2: Constructing random object outside tight loop and using next() inside loop
- When we only use next() method inside tight loop, then we get the good next random number
- This results in better  random number generation
- The regression tests shows the output are satisfactory

### Approach3: Constructing random object inside tight loop using Guid()
- Even we are inside tight loop, as we use Guid() instead of default tick, we get new random seed, and then it results in very good random number
- This results in best random number generation
- The regression tests shows the output are very satisfactory
- The caveat may be it is a little slower due to that Guid() generation

### Complexity
- Time: O(n) as we go through elements once from 0 to n
- Space: O(1) as we don't use extra and do our shuffling in-place


## Project Structure
The solution is provided in Console Application using .Net Framework 4.8  
The main solution is ` NumberGeneratorSolution.sln `
Solution contains two projects
- `NumberGenerator.csproj` which contains the main driver code and algorithm
- `ArrayShuffler.cs` is the main class that implements the algorithm
- `PrintUtility.cs` is the static helper class providing some helper methods
- `ArrayShufflerStressTest.cs` compares the performance between the basic and optimal solutions
- `ArrayShufflerRandomnessTests.cs`  tests the randomness behavior of the algorithm, when it is run for n repetitions

## Running the submitted solution
Clone the repo locally or download the zip folder.
- `git clone git@github.com:CodeWithSubash/NumberRandomizer.git`  
- Open the solution ` NumberGeneratorSolution.sln ` in main folder
- `NumberGenerator` project contains the main driver code with `Program.cs`
- main() method also includes driver code to run load-tests

## Running the tests
- Run the unit tests using VS Test Explorer from project: `NumberGenerator.Tests`

Note: To see the output of tests/histogram, I am calling the tests from driver class
- `PerformLoadTests()` compares the time do perform shuffling using basic and optimal solutions (described above)
- `PerformRandomnessTests()` tests for the randomness output for multiple repetitions for the same input number

## Assumptions
- We are assuming the defined number (n). this can be easily modified to take as user input
- We are only cosidering the randomness of the positive integers

## Challenges/Enhancements
- Handle the various input checks such as negative number, or very high integer number
- For high integer array such as Int32.MaxValue, there will be memory full exception, so to address such huge number, one possible approach would be split the array into subarrays and randomize them
- Explore behavior on other languages, as random() generator is very compiler  based
 




