using System;
using ProjectEuler.src.utilities;

namespace ProjectEuler
{
	public class Problem14 : ProblemBase
	{
		public Problem14 ()
		{
		}

		#region implemented abstract members of ProblemBase

		public override string Solve ()
		{
			int max = int.MinValue;
			uint maxNum = 2;
			for (uint i = 2; i < 1000000; i++)
			{
				int temp = GetSequenceCount(i);
				if(temp>max)
				{
					//Console.WriteLine(string.Format("{0}: {1} elements", i, temp));
					max = temp;
					maxNum = i;
				}
			}
			return maxNum.ToString();
		}

		private int GetSequenceCount (uint start)
		{
			ulong current = start;
			int count = 1;
			while (current != 1)
			{
				current = GetNextInSequence(current);
				count++;
			}
			return count;
		}

		private ulong GetNextInSequence (ulong current)
		{
			if (current < 1)
			{
				throw new InvalidOperationException ("WTF");
			}
			if (current.IsEven ())
			{
				return current / 2;
			}
			else
			{
				return ((3*current) + 1);
			}
		}

		public override int ProblemNumber
		{
			get {
				return 14;
			}
		}

		#endregion
	}
}

