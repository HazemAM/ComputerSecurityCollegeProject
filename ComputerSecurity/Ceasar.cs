using System;

namespace ComputerSecurity
{
	public static class Ceasar
	{
		public static string encrypt(string text, int key)
		{
			string encrypted = string.Empty;
			text = text.ToUpper();

			int newIndex;
			for(int i=0; i<text.Length; i++){
				newIndex = Helpers.mod( (Helpers.alphaIndex(text[i]) + key), 26);
				encrypted += Helpers.alphabet[newIndex];
			}

			return encrypted;
		}

		public static string decrypt(string text, int key)
		{
			string decrypted = string.Empty;
			text = text.ToUpper();

			int newIndex;
			for(int i=0; i<text.Length; i++){
				newIndex = Helpers.mod( (Helpers.alphaIndex(text[i]) - key), 26);
				decrypted += Helpers.alphabet[newIndex];
			}

			return decrypted.ToLower();
		}
	}
}
