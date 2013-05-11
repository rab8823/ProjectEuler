using System;
using System.Collections.Generic;
using ProjectEuler.src.utilities;

namespace ProjectEuler
{
	public class Problem29 : ProblemBase
	{
		public Problem29 ()
		{
		}

		#region implemented abstract members of ProblemBase

		public override string Solve ()
		{
			bool[] primes = NumberUtilities.GetPrimes(1000);
			HashSet<string> vals = new HashSet<string>();
			for (int a = 2; a <= 100; a++) {
				for (int b = 2; b <= 100; b++) {
					vals.Add(string.Format("{0}^{1}",a,b));
				}
			}
			Console.WriteLine(vals.Count);
			return string.Empty;
		}

		public override int ProblemNumber {
			get {
				return 29;
			}
		}

		#endregion
	}
}

