using System;

namespace ComputerSecurity
{
	public static class Playfair
	{
		const int KEY_LENGTH = 5;

		public static string encrypt(string text, string key)
		{
			char[,] fullKey;
			text = text.ToUpper();

			/*
			 * Full-key formulation
			 */
			fullKey = formulateKey(key);

			/*
			 * Encrypting
			 */
			string encrypted = string.Empty;
			if(text.Length % 2 != 0) text += 'X'; //Making it even.

			Tuple<int,int> one, two;
			int x1, y1, x2, y2;
			for(int i=0; i < text.Length; i+=2)
			{
				one = Helpers.indexOf(fullKey, text[i]);
				two = Helpers.indexOf(fullKey, text[i+1]);
				x1 = one.Item1; x2 = two.Item1;
				y1 = one.Item2; y2 = two.Item2;

				if(x1 == x2){
					encrypted += fullKey[x1, Helpers.mod((y1+1), KEY_LENGTH)];
					encrypted += fullKey[x2, Helpers.mod((y2+1), KEY_LENGTH)];
				}
				else if(y1 == y2){
					encrypted += fullKey[Helpers.mod((x1+1), KEY_LENGTH), y1];
					encrypted += fullKey[Helpers.mod((x2+1), KEY_LENGTH), y2];
				}
				else{
					encrypted += fullKey[x1, y2];
					encrypted += fullKey[x2, y1];
				}
			}

			return encrypted;
		}

		public static string decrypt(string text, string key)
		{
			char[,] fullKey;
			text = text.ToUpper();

			/*
			 * Full-key formulation
			 */
			fullKey = formulateKey(key);

			/*
			 * Decrypting
			 */
			string decrypted = string.Empty;
			if(text.Length % 2 != 0) text += 'X'; //Making it even.

			Tuple<int,int> one, two;
			int x1, y1, x2, y2;
			for(int i=0; i < text.Length; i+=2)
			{
				one = Helpers.indexOf(fullKey, text[i]);
				two = Helpers.indexOf(fullKey, text[i+1]);
				x1 = one.Item1; x2 = two.Item1;
				y1 = one.Item2; y2 = two.Item2;

				if(x1 == x2){
					decrypted += fullKey[x1, Helpers.mod((y1-1), KEY_LENGTH)];
					decrypted += fullKey[x2, Helpers.mod((y2-1), KEY_LENGTH)];
				}
				else if(y1 == y2){
					decrypted += fullKey[Helpers.mod((x1-1), KEY_LENGTH), y1];
					decrypted += fullKey[Helpers.mod((x2-1), KEY_LENGTH), y2];
				}
				else{
					decrypted += fullKey[x1, y2];
					decrypted += fullKey[x2, y1];
				}
			}

			return decrypted;
		}

		private static char[,] formulateKey(string initKey)
		{
			char[,] fullKey = new char[KEY_LENGTH, KEY_LENGTH];
			int[] used = new int[26];

			initKey = initKey.ToUpper();

			//Assigning key:
			int index;
			for(int i=0, k=0; i < fullKey.GetLength(0) && k < initKey.Length; i++)
				for(int j=0; j < fullKey.GetLength(1) && k < initKey.Length; k++){
					index = Helpers.alphaIndex(initKey[k]);
					if(used[index] != 1){
						fullKey[i,j] = initKey[k];
						assignAsUsed(used, index);
						j++;
					}
				}

			//Assigning the rest of characters:
			for(int i=0; i < fullKey.GetLength(0); i++)
				for(int j=0; j < fullKey.GetLength(1); j++)
					if(fullKey[i,j] == '\0'){
						index = firstUnusedIndex(used);
						fullKey[i,j] = Helpers.alphabet[index];
						assignAsUsed(used, index);
					}

			return fullKey;
		}

		private static void assignAsUsed(int[] used, int index)
		{
			if(index == 8 || index == 9)
				used[8] = used[9] = 1; //Special case for I & J.
			else
				used[index] = 1;
		}

		private static int firstUnusedIndex(int[] used)
		{
			for(int i=0; i < used.Length; i++)
				if(used[i] != 1)
					return i;

			return -1;
		}
	}
}
