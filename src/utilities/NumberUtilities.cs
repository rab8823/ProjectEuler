using System;

namespace ProjectEuler
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
		public static bool IsPrime (this int number)
		{
			if (number < 2) {
				return false;
			}
			bool isPrime = true;
			int start = (int)Math.Ceiling (Math.Sqrt (number));
			for (int i = start; i>=2 && isPrime; i--) {
				isPrime = number % i == 0;
			}
			return isPrime;
		}
	}
}

