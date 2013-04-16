using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Diagnostics;

namespace ProjectEuler.src.utilities
{
	public class TreeNode<T>
	{
		private List<TreeNode<T>> _children;
		private T _data;

		public T Data
		{
			get { return _data; }
		}

		public ReadOnlyCollection<TreeNode<T>> Children
		{
			get;
			private set;
		}

		public TreeNode (T data)
		{
			_children = new List<TreeNode<T>> ();
			Children = new ReadOnlyCollection<TreeNode<T>>(_children);
			_data = data;
		}
		
		public void Insert (TreeNode<T> child)
		{
			if (child == null)
			{
				throw new ArgumentNullException ("child");
			}
			
			_children.Add(child);
		}
		
		public bool Delete (TreeNode<T> node)
		{
			if (node == null)
			{
				throw new ArgumentNullException ("node");
			}
			bool deleted = false;
			if (!(deleted = _children.Remove(node)))
			{
				if (_children.Count > 0) 
				{
					for (int i = 0; i < _children.Count && !deleted; i++) {
						deleted = node.Delete(node);
					}
				}
			}
			return deleted;
		}
		
		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="ProjectEuler.src.utilities.TreeNode`1"/>.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="ProjectEuler.src.utilities.TreeNode`1"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
		/// <see cref="ProjectEuler.src.utilities.TreeNode`1"/>; otherwise, <c>false</c>.</returns>
		public override bool Equals (object obj)
		{
			if (obj == null)
			{
				return false;
			}
			TreeNode<T> other = obj as TreeNode<T>;
			if (other == null)
			{
				return false;
			}
			bool result = this._data.Equals (other._data) && this._children.Count == other._children.Count;
			if (result)
			{
				for (int i = 0; i < this._children.Count && result; i++) {
					result = this._children[i].Equals(other._children[i]);
				}
			}
			return result;
		}

//		public override string ToString ()
//		{
//			StringBuilder sb = new StringBuilder();
//			sb.Append(_data);
//			sb.n
//		}
	}
}

