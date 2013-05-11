using System;
using System.Collections.Generic;

namespace ProjectEuler
{
	public class Problem39 : ProblemBase
	{
		public Problem39 ()
		{
		}

		#region implemented abstract members of ProblemBase

		public override string Solve ()
		{
			// a^2 + b^2 = c^2
			// if p = a+b+c, for which value of p<=1000, is the number of integral soluations to the above formula maximized?
			Dictionary<int,int> solutions = new Dictionary<int,int> ();
			for(int i = 1; i<=1000; i++){
				solutions.Add (i, 0);
			}
			for (int a = 1; a <= 1000; a++) {
				int a2 = a * a;
				for (int b = 1; b <= 1000 - a - 1; b++) {
					int b2 = b * b;
					int a2b2 = a2 + b2;
					for (int c = 1; c <= 1000 - a - b; c++) {
						if (a2b2 == c * c) {
							solutions [a+b+c]++;
						}
					}
				}
			}
			int pmax = 0;
			int max = 0;
			for (int i = 1; i <= 1000; i++) {
				if (solutions [i] > max) {
					pmax = i;
					max = solutions [i];
				}
			}
			return pmax.ToString ();
		}

		public override int ProblemNumber {
			get {
				return 39;
			}
		}

		#endregion
	}
}

