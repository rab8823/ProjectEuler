using System;
using System.Collections.Generic;
using ProjectEuler.src.utilities;

namespace ProjectEuler
{
    public class Problem50 : ProblemBase
    {
        public Problem50()
        {
        }

        #region implemented abstract members of ProblemBase

        public override string Solve()
        {
            // Find largest sequence of primes whose sum < 1000000

            // Primes < 1000000
            var isPrime = NumberUtilities.GetPrimes(1000000);
            return FindMaxPrime(isPrime).ToString();

        }

        /// <summary>
        /// Finds the max prime. DOES NOT WORK YET
        /// </summary>
        /// <returns>The max prime.</returns>
        /// <param name="isPrime">Is prime.</param>
        private int FindMaxPrime(bool[] isPrime){
            int max = 1000000;
            int maxSum = 0;
            for (int i = 0; i < isPrime.Length; i++) {
                int currentSum = 0;
                if(isPrime[i]){
                    currentSum += i;
                    for (int j = i+1; j < isPrime.Length; j++) {
                        if(currentSum + j >= max){break;}
                        if(isPrime[j]){
                            currentSum += j;
                            if(isPrime[currentSum] && currentSum > maxSum){
                                maxSum = currentSum;
                            }
                        }
                    }
                }
            }
            return maxSum;
        }

        /// <summary>
        /// Finds the max prime sum of primes. WORKS but is SLOW
        /// </summary>
        /// <returns>The max prime sum of primes.</returns>
        /// <param name="primeNumbers">Prime numbers.</param>
        /// <param name="isPrime">Is prime.</param>
        private int FindMaxPrimeSumOfPrimes(IList<int> primeNumbers, bool[] isPrime)
        {
            int maxSum = primeNumbers[0];
            int sumSoFar = primeNumbers[0];
            var maxRange = new Range(){Start = primeNumbers[0], End = primeNumbers[0], Length = 1, Sum = primeNumbers[0]};

            for (int i = 0; i < primeNumbers.Count; i++)
            {
                var currentRange = new Range(){Start = primeNumbers[i], End = primeNumbers[i], Length = 1, Sum = primeNumbers[i]};
                for (int j = i + 1; j < primeNumbers.Count; j++)
                {
                    int current = primeNumbers[j];
                    currentRange.Length++;
                    currentRange.End = current;
                    currentRange.Sum += current;
                    if (currentRange.Sum > 1000000)
                    {
                        currentRange = new Range(){Start = current, End = current, Length = 1, Sum = current};
                    }
                    if (currentRange.Sum >= 0 && currentRange.Sum < 1000000 && currentRange.Sum < isPrime.Length && isPrime[currentRange.Sum] && currentRange.Length > maxRange.Length)
                    {
                        maxRange = new Range(){
                            Start = currentRange.Start,
                            End = currentRange.End,
                            Sum = currentRange.Sum,
                            Length = currentRange.Length
                        };
                    }
                       
                }
            }
            return maxRange.Sum;
        }

        private class Range
        {
            protected internal int Start{ get; set; }

            protected internal int End{ get; set; }

            protected internal int Length{ get; set; }

            protected internal int Sum{ get; set; }
        }

        private int FindMaxSequence(IList<int> numbers, bool[] isPrime)
        {
            int consecutivePrimes = 1;
            int mostConsecutivePrimes = 1;
            int maxSum = numbers[0];
            int sumSoFar = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                int temp = sumSoFar + numbers[i];
                if (temp < isPrime.Length && isPrime[temp])
                {
                    consecutivePrimes++;
                    sumSoFar = temp;
                } else
                {
                    consecutivePrimes = 1;
                    sumSoFar = numbers[i];
                }
                if (consecutivePrimes > mostConsecutivePrimes)
                {
                    mostConsecutivePrimes = consecutivePrimes;
                    maxSum = sumSoFar;
                }

            }
            return mostConsecutivePrimes;
        }

        public override int ProblemNumber
        {
            get
            {
                return 50;
            }
        }

        #endregion
    }
}

