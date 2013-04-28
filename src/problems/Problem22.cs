using System;
using System.Linq;
using System.Collections.Generic;
using ProjectEuler.src.utilities;

namespace ProjectEuler
{
	public class Problem22 : ProblemBase
	{
		public Problem22 ()
		{
		}

		#region implemented abstract members of ProblemBase

		public override string Solve ()
		{
			// Read names from problem22.txt
			// Sort into alphabetical order
			// Score each name
			// 	Score = ASCII score * position
			List<string> names = new List<string>();
			foreach (var line in FileUtilities.ReadLines("src/data/problem22.txt")) {
				var split = line.Split (new string[]{","}, StringSplitOptions.RemoveEmptyEntries);
				foreach (var name in split) {
					names.Add(name.Replace("\"",string.Empty));
				}
			}
			names.Sort();
			int sum = 0;
			for (int i = 0; i < names.Count; i++) {
				int nameScore = 0;
				string name = names[i];
				for (int j = 0; j < name.Length; j++) {
					char c = name[j];
					nameScore += c - 'A' + 1;
				}
				sum += (nameScore * (i+1));
			}
			return sum.ToString();
		}

		public override int ProblemNumber {
			get {
				return 22;
			}
		}

		#endregion
	}
}

