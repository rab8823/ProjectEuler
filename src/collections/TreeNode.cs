using System;
using System.Collections.Generic;

namespace ProjectEuler
{
	public class TreeNode<T>
	{
		public T Value {
			get;
			private set;
		}

		private IList<TreeNode<T>> _children = new List<TreeNode<T>>();

		public TreeNode (T value)
		{
			Value = value;

		}

		public void AddNode (T value)
		{
			_children.Add(new TreeNode<T>(value));
		}
	}
}

