using System;

namespace ComputerSecurity
{
	public static class Helpers
	{
		public static char[] alphabet = new char[] {
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
			'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
		};

		public static int alphaIndex(char p)
		{
			int index = Array.IndexOf(alphabet, p);
			return index;
		}
	}
}
