using System.Diagnostics;

namespace ProjectEuler.src.collections
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("{Data}")]
	public class Node<T>
	{
		public T Data
		{
			get;
			private set;
		}
		
		private int _x;
		private int _y;
		
		public Node(T data, int x, int y)
		{
			this.Data = data;
			this._x = x;
			this._y = y;
		}
		
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return Data != null ? Data.ToString() : "{null}";
		}
		
		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns>
		/// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			if (obj == null) { return false; }
			Node<T> other = obj as Node<T>;
			if (other == null) { return false; }
			return this.Data.Equals(other.Data) &&
				this._x == other._x &&
					this._y == other._y;
		}
		
		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			unchecked
			{
				return Data.GetHashCode() ^ _x ^ _y;
			}
		}
	}
}
