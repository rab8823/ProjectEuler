using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ProjectEuler.src.utilities;
using ProjectEuler.src.collections;

namespace ProjectEuler
{
	public class Problem18 :ProblemBase
	{
		public Problem18 ()
		{
		}

		#region implemented abstract members of ProblemBase

		public override string Solve ()
		{
			var g = new Dictionary<Node<int>, List<Node<int>>>();
			var d = new List<string[]>();
			var data = LoadData();
			var lines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			var elements = new List<int[]>(lines.Length);
			for (int i = 0; i < lines.Length; i++)
			{
			    var splitLine = lines[i].Split(' ');
			    elements.Add(new int[splitLine.Length]);
			    for (int j = 0; j < splitLine.Length; j++)
			    {
			        elements[i][j] = int.Parse(splitLine[j]);
			    }
			}
			
			return Eval(elements);
		}

		private string LoadData ()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var line in FileUtilities.ReadLines(@"src\data\problem18.txt"))
			{
				sb.Append(line).AppendLine();
			}
			return sb.ToString();
		}

		private string Eval(List<int[]> data)
		{
			DateTime start = DateTime.Now;
			var weights = new Dictionary<Point, int>();
			//Expect root to be first in list
			weights.Add(new Point(0, 0), data[0][0]);
			for (int y = 1; y < data.Count; y++)
			{
				for (int x = 0; x < data[y].Length; x++)
				{
					var p = new Point(x, y);
					var parents = GenerateParents(p, data[y].Length);
					Debug.Assert(parents.Count > 0 && parents.Count < 3);
					int p1 = weights[parents[0]];
					int p2 = 0;
					if (parents.Count == 2)
					{
						p2 = weights[parents[1]];
					}
					weights.Add(p, data[y][x] + Math.Max(p1, p2));
				}
			}
			var duration = DateTime.Now - start;
			
			int max = 0;
			foreach (var kvp in weights)
			{
				if (kvp.Value > max)
				{
					max = kvp.Value;
				}
			}
			return max.ToString();
		}

		private static List<Point> GenerateParents(Point p, int rowLength)
		{
			var result = new List<Point>();
			var parentY = p.Y - 1;
			if (p.X > 0 && parentY >= 0)
			{
				result.Add(new Point(p.X - 1, parentY));
			}
			if (p.X < rowLength - 1 && parentY >= 0)
			{
				result.Add(new Point(p.X, parentY));
			}
			return result;
		}
		
		private static List<int> InitializeList(int length, int defaultValue)
		{
			var result = new List<int>(length);
			for (int i = 0; i < length; i++)
			{
				result.Add(defaultValue);
			}
			return result;
		}

		public override int ProblemNumber
		{
			get {
				return 18;
			}
		}

		#endregion
	}
}

