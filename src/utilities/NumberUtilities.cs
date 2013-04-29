using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using utils = ProjectEuler.src.utilities;

namespace ProjectEuler.src.utilities
{
    public static class NumberUtilities
    {
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

        public static bool IsPrime(this BigInteger number)
        {
            if (number == 2)
            {
                return true;
            }
            if (number.IsEven)
            {
                return false;
            }
            bool isPrime = true;
            //number.
            return false;
        }

        //TODO: add get next/previous prime methods
        public static BigInteger GetNthPrime(ulong nth)
        {
            if (nth < 1)
            {
                throw new ArgumentOutOfRangeException("nth");
            }
            BigInteger nthPrime = new BigInteger(2);
            ulong n = 1;
            while (n<nth)
            {
                while (!nthPrime.IsPrime())
                {
                    nthPrime++;
                }
                n++;
            }
            return nthPrime;
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

