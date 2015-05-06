using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSecurity
{
    class HillCipher
    {
        string input;
        string key;
        int[,] Key;
        int[] inp;
       public HillCipher(string input,string key)
        {
            this.input = input;
            this.key = key;
            validateInpit();
        }

        private void validateInpit()
        {
            key=key.ToLower();
            input=input.ToLower();
            if (key.Length == 4)
            {
                Key = new int[2, 2];
                int index = 0;
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 2; j++)
                    {
                        Key[i, j] = (int)(key[index] - 'a');
                        index++;
                    }
                int len = input.Length;
                int size = len % 4 == 0 ? len/4 : (int)(len/4) + 1;
                inp=new int[4*size];
                for (int i = 0; i < 4 * size; i++)
                    if (i < len)
                        inp[i] = (int)(input[i] - 'a');
                    else
                        inp[i] = (int)('x' - 'a');
            }
                else
                    throw new Exception("invalid key length please re-input the key(4)");
        }
        public string Encrypt()
        {
            string res="";
            int index = 0;
            int size = inp.Length;
            while(index<size)
            {
                int res1 = Key[0, 0] * inp[index] + Key[0, 1] * inp[index + 1];
                int res2 = Key[1, 0] * inp[index] + Key[1, 1] * inp[index + 1];
                res1 = Helpers.mod(res1, 26);
                res2 = Helpers.mod(res2, 26);
                res += (char)(res1 + 'a');
                res += (char)(res2 + 'a');
                index += 2;
            }
            return res;
        }
        public string Decrypt()
        {
            int[,] Key = computeKeyInverse();
            string res = "";
            int index = 0;
            int size = inp.Length;
            while (index < size)
            {
                int res1 = Key[0, 0] * inp[index] + Key[0, 1] * inp[index + 1];
                int res2 = Key[1, 0] * inp[index] + Key[1, 1] * inp[index + 1];
                res1 = Helpers.mod(res1, 26);
                res2 = Helpers.mod(res2, 26);
                res += (char)(res1 + 'a');
                res += (char)(res2 + 'a');
                index += 2;
            }
            return res;
        }

        private int[,] computeKeyInverse()
        {
            int[,] res= new int [2,2];
            int det = Key[0, 0] * Key[1, 1] - Key[0, 1] * Key[1, 0];

            det = Helpers.calculateEludianMod(det, 26);
            if (det == 0)
                throw new Exception("the key matrix det = 0");
            //calculating inverse mat
            res[0,0]=Key[1,1];
            res[0,1]=Helpers.mod(-1*Key[0,1],26);
            res[1,0]=Helpers.mod(-1*Key[1,0],26);
            res[1,1]=Key[0,0];
            //multiplying by det and getting key inverse
            res[0, 0] = Helpers.mod(det * res[0, 0], 26);
            res[0, 1] = Helpers.mod(det * res[0, 1], 26);
            res[1, 0] = Helpers.mod(det * res[1, 0], 26);
            res[1, 1] = Helpers.mod(det * res[1, 1], 26);
            return res;
        }
    }
}
