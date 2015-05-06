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
        public static Tuple<int, int> indexOf<T>(this T[,] matrix, T value)
        {
            int x = matrix.GetLength(0); //Rows.
            int y = matrix.GetLength(1); //Columns.

            for (int i = 0; i < x; ++i)
                for (int j = 0; j < y; ++j)
                    if (matrix[i, j].Equals(value))
                        return Tuple.Create(i, j);

            return Tuple.Create(-1, -1);
        }

        /// <summary>
        /// Performs a real mod operation, that never returns a negative number.
        /// </summary>
        public static int mod(int num1, int num2)
        {
            int result = num1 % num2;
            while (result < 0) result += num2;

            return result;
        }

        public static double modBig(double num1, double num2)
        {
            double result = num1 % num2;
            while (result < 0) result += num2;

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
        public static int calculateEludianMod(int m, int n)
        {
            m = mod(m, n);
            int Q = -1;
            int A1 = 1;
            int A2 = 0;
            int A3 = n;
            int B1 = 0;
            int B2 = 1;
            int B3 = m;
            int OA1 = 1;
            int OA2 = 0;
            int OA3 = n;
            int OB1 = 0;
            int OB2 = 1;
            int OB3 = m;
            while (B3 != 1)
            {
                if (B3 == 0)
                    throw new Exception("cant find an inverse for det of the key");
                Q = OA3 / OB3;
                A1 = OB1;
                A2 = OB2;
                A3 = OB3;
                B1 = OA1 - Q * OB1;
                B2 = OA2 - Q * OB2;
                B3 = OA3 - Q * OB3;
                OA1 = A1;
                OA2 = A2;
                OA3 = A3;
                OB1 = B1;
                OB2 = B2;
                OB3 = B3;
            }
            if (B2 < 0)
                return mod(B2, n);
            return B2;
        }
    }
}
