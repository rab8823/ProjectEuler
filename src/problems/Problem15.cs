using System;
using System.Collections.Generic;
using System.Globalization;
using ProjectEuler.src.utilities;
using System.Threading.Tasks;
using System.Threading;

namespace ProjectEuler
{
	public class Problem15 : ProblemBase
	{
		public Problem15 ()
		{
		}

		#region implemented abstract members of ProblemBase

		public override string Solve ()
		{
			// Moving only right and down, how many unique paths are there to in a 20x20 lattice?

//			var paths = FindPaths(13);
//			var numPaths = CountPaths(paths);
			ulong numPaths = FindPaths2 (20);
			return numPaths.ToString(CultureInfo.InvariantCulture);
		}

		private ulong FindPaths2 (int maxDepth)
		{
			Thread t1 = new Thread(FindPaths3);
			Thread t2 = new Thread(FindPaths3);
			t1.Start(new int[]{maxDepth, 1, 0});
			t2.Start(new int[]{maxDepth, 0, 1});
			t1.Join();
			t2.Join();
//			return FindPaths2(maxDepth, 0, 0);
			return 0;
		}

		private void FindPaths3 (object args)
		{
			int[] parameters = (int[])args;
			Console.WriteLine(FindPaths2 (parameters[0],parameters[1],parameters[2]));
		}

		private ulong FindPaths2 (int maxDepth, int x, int y)
		{
			ulong paths = 0;
			if (x < maxDepth)
			{
				paths += FindPaths2 (maxDepth, x + 1, y);
			}
			if (y < maxDepth)
			{
				paths += FindPaths2 (maxDepth, x, y + 1);
			}
			if (x == maxDepth && y == maxDepth)
			{
				return 1;
			}
			return paths;
		}

		private TreeNode<Point> FindPaths (int maxDepth)
		{
			int x = 0;
			int y = 0;

			return FindPaths(maxDepth, x, y);
		}

		private TreeNode<Point> FindPaths (int maxDepth, int x, int y)
		{
			var current = new TreeNode<Point> (default(Point));
			if (x < maxDepth)
			{
				current.Insert(FindPaths(maxDepth, x+1, y));
			}
			if (y < maxDepth)
			{
				current.Insert(FindPaths(maxDepth, x, y+1));				
			}
			return current;
		}

		private int CountPaths (TreeNode<Point> tree)
		{
			if (tree.Children.Count == 0)
			{
				return 1;
			} else
			{
				int sum = 0;
				for (int i = 0; i < tree.Children.Count; i++) {
					sum += CountPaths(tree.Children[i]);
				}
				return sum;
			}
		}

		public override int ProblemNumber
		{
			get {
				return 15;
			}
		}

		#endregion
	}
}

