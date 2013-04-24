using System;
using System.Collections.Generic;
using ProjectEuler.src.utilities;
using System.Linq;
using System.Diagnostics;

namespace ProjectEuler
{
	public class Problem12 : ProblemBase
	{
		public Problem12 ()
		{
		}

		private List<uint> _primes = new List<uint>();

		#region implemented abstract members of ProblemBase

		public override string Solve ()
		{
			//Find first triangular number to have 500 divisors
			var primes = FindPrimes ((uint)100000);

			uint gen = 8;
			uint divisors = 0;
			uint two = (uint)2;
			var factors1 = GetPrimeFactors (gen, primes);
			var factors2 = GetPrimeFactors (gen + 1, primes);
			var merged = MergePrimeFactors (factors1, factors2);
			if (merged.ContainsKey (two))
			{
				merged[two]--;
			}
			divisors = GetNumDivisors(merged);
			while (divisors <= 500)
			{

				gen++;
				factors1 = factors2;
				factors2 = GetPrimeFactors(gen+1, primes);

				merged = MergePrimeFactors(factors1,factors2);
				if(merged.ContainsKey(two)){
					merged[two]--;
				}
				divisors = GetNumDivisors(merged);
			}
			uint t = (uint)((gen*gen + gen)/2);
			return t.ToString();
		}

		private Dictionary<uint,uint> MergePrimeFactors (Dictionary<uint,uint> p1, Dictionary<uint,uint> p2)
		{
			var merged = new Dictionary<uint,uint>();
			foreach (var item in p1)
			{
				merged.Add(item.Key, item.Value);
			}
			foreach (var item in p2)
			{
				if(merged.ContainsKey(item.Key)) {
					merged[item.Key] += item.Value;
				}else {
					merged.Add (item.Key,item.Value);
				}
			}
			return merged;
		}

		private uint GetNumDivisors (Dictionary<uint,uint> primeFactors)
		{
			uint divisors = 1;
			foreach (var item in primeFactors)
			{
				divisors *= (item.Value + 1);
			}
			return divisors;
		}

		private Dictionary<uint,uint> GetPrimeFactors (uint n, bool[] primes)
		{
			var factors = new Dictionary<uint,uint> ();
			if (n < primes.Length)
			{
				uint end = n / 2;
				for (uint i = 2; i <= end; i++) {
					if(primes[i]){
						uint e = 0;
						uint temp = n;
						while(temp % i == 0){
							e++;
							temp = temp / i;
						}
						if(e>0){
							factors.Add (i, e);
						}
					}
				}
				if(primes[n]){
					factors.Add (n, (uint)1);
				}
			} else
			{
				throw new ArgumentOutOfRangeException("generate more primes");
			}
			return factors;
		}

		private bool[] FindPrimes (uint max)
		{
			bool[] isPrime = new bool[max];
			for (uint i = 0; i < max; i++)
			{
				isPrime[i] = true;
			}

			for (uint i = 2; i < max; i++)
			{
				if(isPrime[i])
				{
					uint start = i*i;
					for (uint j = start; j < max; j+=i) {
						isPrime[j] = false;
					}
				}
			}
			return isPrime;
		}

		public override int ProblemNumber
		{
			get {
				return 12;
			}
		}

		#endregion
	}
}

