using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler.src.utilities
{
	/// <summary>
	/// File utilities.
	/// </summary>
	public static class FileUtilities
	{
		/// <summary>
		/// Reads the lines.
		/// </summary>
		/// <returns>The lines.</returns>
		/// <param name="fileName">File name.</param>
		public static IEnumerable<string> ReadLines (string fileName)
		{
			FileInfo file = new FileInfo (fileName);
			if (!file.Exists)
			{
				throw new InvalidOperationException ("File cannot be found: " + fileName);
			}
			//List<string> lines = new List<string>();
			using(var stream = file.OpenRead())
			using(var reader = new StreamReader(stream))
			{
				while(!reader.EndOfStream)
				{
					yield return reader.ReadLine();
				}
			}
			//return lines;
		}
	}
}

