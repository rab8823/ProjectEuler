using System;

namespace ProjectEuler
{
	/// <summary>
	/// Interface for Project Euler problems
	/// </summary>
	public interface IProblem
	{
		/// <summary>
		/// Gets the problem number.
		/// </summary>
		/// <value>
		/// The problem number.
		/// </value>
		int ProblemNumber{ get; }

		/// <summary>
		/// Solve this instance.
		/// </summary>
		string Solve();
	}
}

