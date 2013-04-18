using System;

namespace ProjectEuler
{
	public class Problem28 : ProblemBase
	{
		public Problem28 ()
		{
		}

		#region implemented abstract members of ProblemBase

		public override string Solve ()
		{
			ulong gap = 1;
			ulong sum = 0;
			ulong i = 1;
			while (gap <= 999)
			{
				for (int c = 0; c < 4; c++)
				{
					sum += i;
					i += gap + 1;
				}
				gap += 2;
			}
			sum += i;
			return sum.ToString();
		}

		public override int ProblemNumber
		{
			get {
				return 28;
			}
		}

		#endregion
	}
}

