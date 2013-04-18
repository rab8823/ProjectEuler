using System;
using System.Numerics;

namespace ProjectEuler
{
	public class Problem20 : ProblemBase
	{
		public Problem20 ()
		{
		}

		#region implemented abstract members of ProblemBase

		public override string Solve ()
		{
			return SumDigits(Factorial(100));
		}

		public string SumDigits (BigInteger number)
		{
			int sum = 0;
			string s = number.ToString();
			for (int i = 0; i < s.Length; i++)
			{
				string digit = s[i] + string.Empty;
				sum += int.Parse(digit);
			}
			return sum.ToString();
		}

		public BigInteger Factorial (int n)
		{
			BigInteger bi = new BigInteger(n--);
			while(n>1)
			{
				bi = BigInteger.Multiply(bi, new BigInteger(n--));
			}
			return bi;
		}

		public override int ProblemNumber
		{
			get {
				return 20;
			}
		}

		#endregion
	}
}

