using System;

namespace ComputerSecurity
{
	public static class MD5
	{
		public static string getHash(string text)
		{
			/*
			 * INITIALIZATIONS
			 */
			const int CHUNCK_SIZE = 64,
					  WORD_SIZE   = 4;

			int originalLength = text.Length;

			//Initial A, B, C, and D values:
			uint a0 = 0x67452301,
				 b0 = 0xefcdab89,
				 c0 = 0x98badcfe,
				 d0 = 0x10325476;

			//Shift amounts for each round:
			int[] s = new int[CHUNCK_SIZE]{
				7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22,
				5, 9, 14, 20, 5, 9, 14, 20, 5, 9, 14, 20, 5, 9, 14, 20,
				4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23,
				6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21
			};

			//Constants table:
			uint[] K = new uint[CHUNCK_SIZE]{ 
				0xd76aa478, 0xe8c7b756, 0x242070db, 0xc1bdceee,
				0xf57c0faf, 0x4787c62a, 0xa8304613, 0xfd469501,
				0x698098d8, 0x8b44f7af, 0xffff5bb1, 0x895cd7be,
				0x6b901122, 0xfd987193, 0xa679438e, 0x49b40821,
				0xf61e2562, 0xc040b340, 0x265e5a51, 0xe9b6c7aa,
				0xd62f105d, 0x02441453, 0xd8a1e681, 0xe7d3fbc8,
				0x21e1cde6, 0xc33707d6, 0xf4d50d87, 0x455a14ed,
				0xa9e3e905, 0xfcefa3f8, 0x676f02d9, 0x8d2a4c8a,
				0xfffa3942, 0x8771f681, 0x6d9d6122, 0xfde5380c,
				0xa4beea44, 0x4bdecfa9, 0xf6bb4b60, 0xbebfbc70,
				0x289b7ec6, 0xeaa127fa, 0xd4ef3085, 0x04881d05,
				0xd9d4d039, 0xe6db99e5, 0x1fa27cf8, 0xc4ac5665,
				0xf4292244, 0x432aff97, 0xab9423a7, 0xfc93a039,
				0x655b59c3, 0x8f0ccc92, 0xffeff47d, 0x85845dd1,
				0x6fa87e4f, 0xfe2ce6e0, 0xa3014314, 0x4e0811a1,
				0xf7537e82, 0xbd3af235, 0x2ad7d2bb, 0xeb86d391
			};


			/*
			 * REAL WORK
			 */
			//Buffer initis:
			byte[] byteText;

			int padding = 448 - Helpers.mod(originalLength * 8, 512);
			padding = (padding == 0) ? 512 : padding; //Enforce padding when mod result is exact 0.

			ulong messageByteSize = (ulong)originalLength * 8; //The message size in bytes' universe.
			uint messageBufferLength = (uint)(originalLength + (padding/8) + 8); //Required buffer to deal with message.

			byteText = new byte[messageBufferLength];

			//Add original text to buffer:
			for(int i=0; i < originalLength; i++)
				byteText[i] = (byte)text[i];

			//Append one:
			byteText[originalLength] |= 0x80;
			
			//Append message length:
			for(int i=8; i > 0; i--)
				byteText[messageBufferLength - i] = (byte)(messageByteSize >> ((8 - i) * 8) & 0x00000000000000ff);

			//Chunks' loop:
			uint dTemp;
			byte[] chunk = new byte[CHUNCK_SIZE];
			for(int i=0; i < byteText.Length / CHUNCK_SIZE; i++)
			{
				//Making a chunk:
				Array.Copy(byteText, i * CHUNCK_SIZE, chunk, 0, CHUNCK_SIZE);

				//Making words from the chunk:
				byte[][] word = new byte[16][];
				for(int j=0; j < chunk.Length / WORD_SIZE; j++){
					word[j] = new byte[WORD_SIZE];
					Array.Copy(chunk, j * WORD_SIZE, word[j], 0, WORD_SIZE);
				}

				//Initializing A, B, C, and D for this chunk:
				uint A = a0,
					 B = b0,
					 C = c0,
					 D = d0;

				//MAIN LOOP:
				uint F=0;
				int g=0;
				for(int k=0; k < CHUNCK_SIZE; k++)
				{
					if(k >= 0 && k <= 15){
						F = (B & C) | ((~B) & D);
						g = k;
					}
					else if(k >= 16 && k <= 31){
						F = (D & B) | ((~D) & C);
						g = Helpers.mod(((5*k) + 1), 16);
					}
					else if(k >= 32 && k <= 47){
						F = B ^ C ^ D;
						g = Helpers.mod(((3*k) + 5), 16);
					}
					else if(k >= 48 && k <= 63){
						F = C ^ (B | (~D));
						g = Helpers.mod((7*k), 16);
					}

					//Converting the current word for upcoming integer addition:
					uint wordUint = BitConverter.ToUInt32(word[g], 0);

					dTemp = D;
					D = C;
					C = B;
					B = B + Helpers.leftRotate((A + F + K[k] + wordUint), s[k]);
					A = dTemp;
				}

				//Add this chunk's hash to the result:
				a0 = a0 + A;
				b0 = b0 + B;
				c0 = c0 + C;
				d0 = d0 + D;
			}

			return formulateHashString(a0, b0, c0, d0);
		}

		private static string formulateHashString(uint a0, uint b0, uint c0, uint d0)
		{
			return Helpers.reverseByte(a0).ToString("X8") + Helpers.reverseByte(b0).ToString("X8")
					+ Helpers.reverseByte(c0).ToString("X8") + Helpers.reverseByte(d0).ToString("X8");
		}
	}
}
