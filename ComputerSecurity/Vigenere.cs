using System;
using System.Collections.Generic;

namespace ComputerSecurity
{
	public static class Vigenere
	{
		public static string encrypt(string text, string key)
		{
			Dictionary<KeyValuePair<char,char>,char> map = new Dictionary<KeyValuePair<char,char>,char>();

			text = text.ToUpper();
			key = key.ToUpper();
			map = formulateMap();

			if(key.Length < text.Length)
				throw new ArgumentException("Key must have length equal to the text to encrypt (use formulateKey method)");

			/**
			 * Encryption
			 */
			string encrypted = string.Empty;

			KeyValuePair<char,char> pair;
			for(int i=0; i < text.Length; i++){
				pair = new KeyValuePair<char,char>(text[i], key[i]);
				encrypted += map[pair];
			}

			return encrypted;
		}

		public static string decrypt(string text, string key)
		{
			Dictionary<KeyValuePair<char,char>,char> map = new Dictionary<KeyValuePair<char,char>,char>();

			text = text.ToUpper();
			key = key.ToUpper();
			map = formulateMap();

			if(key.Length < text.Length)
				throw new ArgumentException("Key must have length equal to the text to decrypt (use formulateKey method)");

			/**
			 * Decryption
			 */
			string decrypted = string.Empty;

			int j;
			KeyValuePair<char,char> pair;
			char[] a = Helpers.alphabet;
			for(int i=0; i < text.Length; i++){
				for(j=0; j < a.Length; j++){
					pair = new KeyValuePair<char,char>(a[j], key[i]);
					if(map[pair] == text[i])
						break;
				}

				decrypted += a[j];
			}

			return decrypted;
		}

		public static string formulateKey(string text, string initKey, VigenereType type)
		{
			string key = initKey;

			if(type == VigenereType.REPEATING_KEY && key.Length == 0)
				throw new ArgumentOutOfRangeException("Provided keyword is empty, and hence can't be repeated.");

			string filler = (type == VigenereType.REPEATING_KEY)
				? key : text;

			int left;
			for(int i = key.Length; i < text.Length; i+=left){
				left = text.Length - key.Length;
				left = left > filler.Length ? filler.Length : left;
				if(left > 0)
					key += filler.Substring(0, left);
			}

			return key;
		}

		private static Dictionary<KeyValuePair<char,char>,char> formulateMap()
		{
			Dictionary<KeyValuePair<char,char>,char> map = new Dictionary<KeyValuePair<char,char>,char>();
			char[] a = Helpers.alphabet;

			KeyValuePair<char,char> key;
			int index;
			for(int i=0; i < a.Length; i++)
				for(int j=0; j < a.Length; j++)
				{
					key = new KeyValuePair<char,char>(a[i], a[j]);
					index = Helpers.mod(i+j, a.Length);
					map.Add(key, a[index]);
				}

			return map;
		}
	}

	public enum VigenereType
	{
		REPEATING_KEY,
		AUTO_KEY
	}
}
