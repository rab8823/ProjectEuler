using System;
using System.Text;

namespace ProjectEuler
{
	public static class StringUtilities
	{
		/// <summary>
		/// Reverse the specified string.
		/// </summary>
		/// <param name='s'></param>
		public static string Reverse (this string s)
		{
			if (string.IsNullOrEmpty (s)) {
				return s;
			}
			StringBuilder sb = new StringBuilder(s.Length);
			for (int i = s.Length - 1; i >= 0; i--) {
				sb.Append(s[i]);
			}
			return sb.ToString();
		}
	}
}

