using System;

namespace ComputerSecurity
{
	public static class Helpers
	{
		public static char[] alphabet = new char[] {
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
			'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '-'
		};

		/// <summary>
		/// Finds the index of an alphabet character.
		/// </summary>
		public static int alphaIndex(char p)
		{
			int index = Array.IndexOf(alphabet, p);
			return index;
		}

		/// <summary>
		/// Finds the index of a character in a 2D array.
		/// </summary>
		public static Tuple<int,int> indexOf<T>(this T[,] matrix, T value)
		{
			int x = matrix.GetLength(0); //Rows.
			int y = matrix.GetLength(1); //Columns.

			for(int i=0; i < x; ++i)
				for(int j=0; j < y; ++j)
					if(matrix[i, j].Equals(value))
						return Tuple.Create(i, j);

			return Tuple.Create(-1, -1);
		}

		/// <summary>
		/// Performs a real mod operation, that never returns a negative number.
		/// </summary>
		public static int mod(int num1, int num2)
		{
			int result = num1 % num2;
			while(result < 0) result += num2;

			return result;
		}

		public static double modBig(double num1, double num2)
		{
			double result = num1 % num2;
			while(result < 0) result += num2;

			return result;
		}

		/// <summary>
		/// Swaps two elements in an array of any type.
		/// </summary>
		public static void swap<T>(T[] arr, int i, int j)
		{
			T temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}

		public static uint leftRotate(uint x, int c)
		{
			return (x << c) | (x >> (32 - c));
		}

		public static uint reverseByte(uint num)
		{
			return (((num & 0x000000ff) << 24) | (num >> 24) | ((num & 0x00ff0000) >> 8) | ((num & 0x0000ff00) << 8));
		}
	}
}
