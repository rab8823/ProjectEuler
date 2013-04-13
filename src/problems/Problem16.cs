using System;
using System.Numerics;

namespace ProjectEuler
{
	public class Problem16 : ProblemBase
	{
		public Problem16 ()
		{
		}

		#region implemented abstract members of ProblemBase

		public override string Solve ()
		{
			//Sum of digits of 2^1000
			BigInteger two = new BigInteger(2.0);
			var result = BigInteger.Pow(two, 1000).ToString();
			int sum = 0;
			for (int i = 0; i < result.Length; i++)
			{
				int num = int.Parse(result[i] + "");
				sum += num;
			}
			return sum.ToString();
		}

		public override int ProblemNumber
		{
			get {
				return 16;
			}
		}

		#endregion
	}
}

