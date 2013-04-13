using System;

namespace ProjectEuler
{
	public abstract class ProblemBase : IProblem
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectEuler.ProblemBase"/> class.
		/// </summary>
		public ProblemBase ()
		{
		}

		#region IProblem implementation

		/// <summary>
		/// Gets the problem number.
		/// </summary>
		/// <value>
		/// The problem number.
		/// </value>
		public abstract int ProblemNumber
		{
			get;
		}

		/// <summary>
		/// Solve this instance.
		/// </summary>
		public abstract string Solve ();

		#endregion

		/// <summary>
		/// Profile this instance.
		/// </summary>
		protected internal string Profile ()
		{
			DateTime start = DateTime.Now;
			string result = Solve ();
			var duration = DateTime.Now - start;
			Console.WriteLine (string.Format ("Solved problem {0} in {1} milliseconds", ProblemNumber, duration.TotalMilliseconds));
			return result;
		}
	}
}

