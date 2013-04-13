using System;
using System.Linq;
using System.Numerics;
using ProjectEuler.src.utilities;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectEuler
{
	public class Problem13 : ProblemBase
	{
		public Problem13 ()
		{

		}

		#region implemented abstract members of ProblemBase

		public override string Solve ()
		{
			List<BigInteger> values = new List<BigInteger>();
			foreach (var line in FileUtilities.ReadLines(@"src\data\problem13.txt"))
			{
				values.Add(BigInteger.Parse(line, CultureInfo.InvariantCulture));
			}
			BigInteger sum = values.Sum();
			return sum.ToString().Substring(0,10);
		}

		public override int ProblemNumber
		{
			get {
				return 13;
			}
		}

		#endregion
	}
}

