using System;
using System.Diagnostics;

namespace ProjectEuler.src.utilities
{
	[DebuggerDisplay("X={X},Y={Y}")]
	public struct Point
	{
		public int X;
		public int Y;

		public Point (int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}

