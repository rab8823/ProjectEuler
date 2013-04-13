using System;
using System.Text;

namespace ProjectEuler.src.collections
{
	public class Matrix
	{
		private int[,] _data = new int[1, 1];

		/// <summary>
		/// Gets the number rows.
		/// </summary>
		/// <value>
		/// The number rows.
		/// </value>
		public int NumRows{ get; private set; }
		/// <summary>
		/// Gets the number columns.
		/// </summary>
		/// <value>
		/// The number cols.
		/// </value>
		public int NumCols{ get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectEuler.src.collections.Matrix"/> class.
		/// </summary>
		/// <param name='numRows'>
		/// Number rows.
		/// </param>
		/// <param name='numColumns'>
		/// Number columns.
		/// </param>
		public Matrix (int numRows, int numColumns)
		{
			_data = new int[numColumns, numRows];
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectEuler.Matrix"/> class.
		/// </summary>
		/// <param name='data'>
		/// Data.
		/// </param>
		/// <param name='rowStart'>
		/// Row start.
		/// </param>
		/// <param name='numRows'>
		/// Number rows.
		/// </param>
		/// <param name='columnStart'>
		/// Column start.
		/// </param>
		/// <param name='numColumns'>
		/// Number columns.
		/// </param>
		public Matrix (object objData, int rowStart, int numRows, int columnStart, int numColumns)
		{
			int[,] data = (int[,])objData;
			int rowLength = data.GetLength (1);
			int colLength = data.GetLength (0);
			if (colLength == 0 || rowLength == 0)
			{
				throw new ArgumentException ("data");
			}
			if (rowStart < 0 || rowStart >= rowLength)
			{
				throw new ArgumentOutOfRangeException ("rowStart");
			} else if (numRows < 0 || numRows + rowStart >= rowLength)
			{
				throw new ArgumentOutOfRangeException ("numRows");
			} else if (columnStart < 0 || columnStart >= colLength)
			{
				throw new ArgumentOutOfRangeException ("columnStart");
			} else if (numColumns < 0 || numColumns + columnStart >= colLength)
			{
				throw new ArgumentOutOfRangeException ("numColumns");
			}
			this.NumCols = numColumns;
			this.NumRows = numRows;

			_data = new int[numRows, numColumns];
			for (int c = 0; c< numColumns; c++)
			{
				int offsetC = c + columnStart;
				for (int r = 0; r<numRows; r++)
				{
					int offsetR = r + rowStart;
					_data [c, r] = data [offsetC, offsetR];
				}
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectEuler.src.collections.Matrix"/> class.
		/// </summary>
		/// <param name='objData'>
		/// Object data.
		/// </param>
		public Matrix (object objData)
		{
			_data = (int[,])objData;
			NumCols = _data.GetLength(0);
			NumRows = _data.GetLength(1);
		}

		public int Sum ()
		{
			int sum = 0;
			for (int c =0; c<NumCols; c++)
			{
				for(int r = 0; r<NumRows; r++){
					sum+=_data[c,r];
				}
			}
			return sum;
		}

		public int Product ()
		{
			int product = 0;
			for (int c =0; c<NumCols; c++)
			{
				for(int r = 0; r<NumRows; r++){
					product *= _data[c,r];
				}
			}
			return product;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ProjectEuler.src.collections.Matrix"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current <see cref="ProjectEuler.src.collections.Matrix"/>.
		/// </returns>
		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder ();
			for (int c = 0; c< this.NumCols; c++)
			{
				for (int r=0; r<this.NumRows; r++)
				{
					sb.Append (_data [c, r]).Append (",");
				}
				sb.Remove (sb.Length - 1, 1).AppendLine ();
			}
			return sb.ToString ();
		}

		public int this [int row, int col]
		{
			get {
				return _data[row,col];
			}
		}

		/// <summary>Matrix multiplication</summary>
		/// <param name='a'></param>
		/// <param name='b'></param>
		public static Matrix operator * (Matrix a, Matrix b)
		{
			if (a == null)
			{
				throw new ArgumentNullException ("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException ("b");
			}
			if (a.NumRows != b.NumCols)
			{
				throw new InvalidOperationException ("Cannot multiply matrices with different row/column counts");
			}
			int[,] results = new int[a.NumCols, b.NumRows];
			for (int i = 0; i < a.NumCols; i++)
			{
				for (int j = 0; j < b.NumRows; j++)
				{
					int cell = 0;
					for (int c = 0; c < a.NumRows; c++)
					{
						cell += a[i,c]*b[c,j];
					}
					results[i,j] = cell;
				}
			}
			return new Matrix(results);
		}

		/// <summary>
		/// Euclideans the multiply.
		/// </summary>
		/// <returns>
		/// The multiply.
		/// </returns>
		/// <param name='a'>
		/// The alpha component.
		/// </param>
		/// <param name='b'>
		/// The blue component.
		/// </param>
		public static Matrix EuclideanMultiply(Matrix a, Matrix b)
		{
			if (a == null)
			{
				throw new ArgumentNullException ("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException ("b");
			}
			if (a.NumRows != b.NumRows || a.NumCols != b.NumCols)
			{
				throw new InvalidOperationException ("Cannot multiply matrices with different row/column counts");
			}
			int[,] results = new int[a.NumCols, b.NumRows];
			for (int i = 0; i < a.NumCols; i++)
			{
				for (int j = 0; j < b.NumRows; j++)
				{
					results[i,j] = a[i,j]*b[i,j];
				}
			}
			return new Matrix(results);
		}
	}
}

