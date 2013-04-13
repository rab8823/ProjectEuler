using System;
using System.Collections.Generic;

namespace ProjectEuler.src.utilities
{
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Generates a sequence starting at start with the specified number of elements
		/// </summary>
		/// <param name='start'>
		/// Start.
		/// </param>
		/// <param name='count'>
		/// Count.
		/// </param>
		public static IEnumerable<ulong> Range (ulong start, ulong count)
		{
			for (ulong i = start; i <= count; i++)
			{
				yield return i;
			}
		}

		/// <summary>
		/// Sum the specified sequence.
		/// </summary>
		/// <param name='sequence'>
		/// Sequence.
		/// </param>
		public static ulong Sum(this IEnumerable<ulong> sequence)
		{
			ulong sum = 0UL;
			foreach (var element in sequence)
			{
				sum+=element;
			}
			return sum;
		}
	}
}

