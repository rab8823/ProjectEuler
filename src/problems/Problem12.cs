using System;
using ProjectEuler.src.utilities;

namespace ProjectEuler
{
	public class Problem12 : ProblemBase
	{
		public Problem12 ()
		{
		}

		#region implemented abstract members of ProblemBase

		public override string Solve ()
		{
			//Find first triangular number to have 500 divisors
			Console.WriteLine(NumberUtilities.GenerateNthTriangularNumber(8u));
			return string.Empty;
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

