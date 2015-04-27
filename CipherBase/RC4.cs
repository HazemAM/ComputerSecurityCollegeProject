using System;

namespace ComputerSecurity
{
	public static class RC4
	{
		public static string encrypt(string text, string key)
		{
			char[] S = getS(key);

			//ENCRYPTION
			string cipher = enc_dec(text, S);
			return cipher;
		}

		public static string decrypt(string cipher, string key)
		{
			char[] S = getS(key);

			//DECRYPTION
			string newText = enc_dec(cipher, S);
			return newText;
		}

		private static char[] getS(string key)
		{
			string T = string.Empty;
			char[] S = new char[256];

			int i;
			for(i=0; i < 256; i++){
				S[i] = (char)i;
				T += key[Helpers.mod(i, key.Length)];
			}
			
			int j=0;
			for(i=0; i < 256; i++){
				j = (j + S[i] + T[i]);
				j = Helpers.mod(j, 256);
				Helpers.swap(S, i, j);
			}

			return S;
		}

		private static string enc_dec(string text, char[] S)
		{
			string cipher = string.Empty;

			int t=0, i=0, j=0;
			foreach(char c in text){
				i = Helpers.mod((i + 1), 256);
				j = Helpers.mod((j + S[i]), 256);
				Helpers.swap(S, i, j);
				
				t = Helpers.mod((S[i] + S[j]), 256);
				cipher += (char)(c ^ S[t]); //c XOR S[t].
			}

			return cipher;
		}
	}
}
