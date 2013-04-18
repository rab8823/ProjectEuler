using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
	public class ProjectEuler
	{
		private static List<ProblemBase> _probTypes = new List<ProblemBase>();
		public static void Main ()
		{
			BuildTypeList();
			string input = string.Empty;
			do{
				var problem = ReadProblemToSolve();
				Console.WriteLine(problem.Profile());
			}while((input = Console.ReadLine()) != null);
		}

		private static void BuildTypeList ()
		{
			var baseType = typeof(ProblemBase);
			var x = from t in baseType.Assembly.GetTypes()
					where t.BaseType == baseType
					select t;
			foreach (var t in x)
			{
				_probTypes.Add ((ProblemBase)Activator.CreateInstance(t));
			}
		}

		private static ProblemBase ReadProblemToSolve ()
		{
			bool err = true;
			ProblemBase result = null;
			while (err)
			{
				Console.Write ("What problem would you like to solve? #");
				string input = Console.ReadLine ();
				int prob = 0;
				if (int.TryParse (input, out prob))
				{
					result = _probTypes.FirstOrDefault(pb => pb.ProblemNumber == prob);
					if(result != null){
						err = false;
					}else{
						Console.WriteLine();
						Console.WriteLine("That problem has not been solved yet. Please enter a different number.");
						err = true;
					}
				} else
				{
					Console.WriteLine ();
					Console.WriteLine ("Unrecognized problem number. Please try again.");
					err = true;
				}
			}
			return result;
		}
	}
}

