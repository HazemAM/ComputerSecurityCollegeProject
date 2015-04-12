using System;

namespace ComputerSecurity
{
	public static class Helpers
	{
		public static char[] alphabet = new char[] {
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
			'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
		};

		/// <summary>
		/// Finds the index of an alphabet character.
		/// </summary>
		public static int alphaIndex(char p)
		{
			int index = Array.IndexOf(alphabet, p);
			return index;
		}

		public static int mod(int num1, int num2)
		{
			int result = num1 % num2;
			if(result < 0) result += num2;

			return result;
		}
	}
}
