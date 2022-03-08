## Random Number Shuffling
Using the language of your choice implement the following program named Shuffle:  
Input a single integer N. Output the integers 1..N in random order. Your algorithm should optimize for speed.  

## Solution
First, I approached the problem with basic non-optimal solution first and observed the behavior  
Finally, I rewrote some logic to come up with the optimal solution
Note: I have done performance testing and included the metrices to compare both approaches

## Algorithm (Optimal Solution)
The main logic is to pick the random number from the remaining array list, and put the picked item on right hand side of same array.
1. Loop n items
2. Pick a random index using Randomizer() method between 0(inclusive) to n (exclusive) 
3. Swap the element pointed by random index and current index
4. Set n=n-1
5. Repeat step t to 4

### Complexity
- Time: O(n) as we go through elements once from 0 to n
- Space: O(1) as we don't use extra and do our shuffling in-place


## Project Structure
The solution is provided in Console Application using .Net Framework 4.8  
The main solution is ` NumberGeneratorSolution.sln `
Solution contains two projects
- `NumberGenerator.csproj` which contains the main driver code and algorithm
- `ArrayShuffler.cs` is the main class that implements the algorithm
- `Utility.cs` is the static helper class providing some helper methods
- `ArrayShufflerStressTest.cs` contains two methods written to test performance and stress tests
    - `CompareRunTimeWithIncreasingN()` compares the basic and optimal solution runtime
    - `DoRandomnessTest()` tests the randomness behavior of the algorithm, when it is run for n repetitions
    - Besides there are some helper private methods

## Running the submitted solution
Clone the repo locally or download the zip folder.
- `git clone git@github.com:CodeWithSubash/NumberRandomizer.git`  
- Open the solution ` NumberGeneratorSolution.sln ` in main folder
- `NumberGenerator` project contains the main driver code with `Program.cs`
- main() method also includes driver code to run load-tests

## Running the tests
- Run the unit tests using VS Test Explorer from project: `NumberGenerator.Tests`

Note: The other performance and randomness tests are already part of main class driver codes
- `ArrayShufflerStressTest.CompareRunTimeWithIncreasingN()` compares the time do perform shuffling using basic and optimal solutions (described above)
- `ArrayShufflerStressTest.DoRandomnessTest()` tests for the randomness output for multiple repetitions for the same input number





