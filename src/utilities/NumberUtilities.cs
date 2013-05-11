using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using utils = ProjectEuler.src.utilities;

namespace ProjectEuler.src.utilities
{
    public static class NumberUtilities
    {

        public static bool[] GetPrimes(int max){
            bool[] isPrime = new bool[max];
            for (int i = 0; i < max; i++) {
                isPrime[i] = true;
            }
            isPrime[0] = false;
            isPrime[1] = false;
            for (int i = 2; i < max; i++) {
                if(isPrime[i]){
                    int start = i*i;
                    for (int j = start; j>=0 && j < max; j+=i) {
                        isPrime[j] = false;
                    }
                }
            }
            return isPrime;
        }

//		public static IDictionary<int,int> GetPrimeFactors(int n, bool[] primes){
//			var factors = new Dictionary<uint,uint> ();
//			if (n < primes.Length)
//			{
//				uint end = n / 2;
//				for (uint i = 2; i <= end; i++) {
//					if(primes[i]){
//						uint e = 0;
//						uint temp = n;
//						while(temp % i == 0){
//							e++;
//							temp = temp / i;
//						}
//						if(e>0){
//							factors.Add (i, e);
//						}
//					}
//				}
//				if(primes[n]){
//					factors.Add (n, (uint)1);
//				}
//			} else
//			{
//				throw new ArgumentOutOfRangeException("generate more primes");
//			}
//			return factors;
//		}

        /// <summary>
        /// Determines if the specified number is prime (naively)
        /// </summary>
        /// <returns>
        /// <c>true</c> if the specified i is prime; otherwise, <c>false</c>.
        /// </returns>
        /// <param name='number'>
        /// The number.
        /// </param>
        public static bool IsPrime(this int number)
        {
            if (number == 2)
            {
                return true;
            }
            if (number % 2 == 0)
            {
                return false;
            }
            bool isPrime = true;
            int start = (int)Math.Ceiling(Math.Sqrt(number));
            for (int i = start; i>=2 && isPrime; i--)
            {
                isPrime = number % i == 0;
            }
            return isPrime;
        }

		#region Matrix math
		#endregion

		#region Sequences
        public static ulong GenerateNthTriangularNumber(uint n)
        {
            if (n < 1)
            {
                throw new ArgumentOutOfRangeException("n");
            }
            return EnumerableExtensions.Range(1UL, n).Sum();
        }
		#endregion

		#region BigInteger Utilities
        public static BigInteger Sum(this IEnumerable<BigInteger> numbers)
        {
            BigInteger sum = BigInteger.Zero;
            foreach (var num in numbers)
            {
                sum = BigInteger.Add(sum, num);
            }
            return sum;
        }
		#endregion

        public static bool IsEven(this int number)
        {
            return (number % 2) == 0;
        }

        public static bool IsEven(this uint number)
        {
            return (number % 2) == 0;
        }

        public static bool IsEven(this ulong number)
        {
            return (number % 2) == 0;
        }

		#region Exponentiation
		
		public static ulong ModExp(ulong n, ulong pow, ulong mod)
        {
			ulong eprime = 0;
			ulong c = 1;
            while (eprime < pow)
            {
				eprime++;
				c = (n * c) % mod;
            }
			return c;
        }
		#endregion
    }
}

