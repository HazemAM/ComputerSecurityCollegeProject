using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace ComputerSecurity

{
    public class Colum
    {
        int[] n;
        string inp;
        //n 0 based
        public Colum(string inp, int[] n)
        {
            this.n = n;
            this.inp = inp;
        }
        public string Encrypt()
        {
            int numCol = n.Length;
            int inputsize=inp.Length;
            int numRows=inputsize % numCol == 0 ? inputsize / numCol : (inputsize / numCol) +1;
            string res = "";
            int count = 0;
            char[,] re = new char[numRows, numCol];
            for (int i = 0; i < numRows; i++)
                for (int j = 0; j < numCol; j++)
                    if (count < inputsize)
                        re[i, j] = inp[count++];
                    else
                        re[i, j] = 'x';
            for (int i = 0; i < numCol;i++ )
            {
                int index = n[i]-1;
                for (int j = 0; j < numRows; j++)
                    res += re[j, index];
            }
                return res;
        }
        public string Decrypt()
        {
            int numCol = n.Length;
            int inputsize = inp.Length;
            int numRows = inputsize % numCol == 0 ? inputsize / numCol : (inputsize / numCol) + 1;
            char[,] re = new char[numRows, numCol];
            string res = "";
            int count = 0;
            for (int i = 0; i < numCol;i++ )
            {
                int index = n[i]-1;
                for(int j=0;j<numRows;j++)
                {
                    re[j, index] = inp[count++];
                }
            }
            for (int i = 0; i < numRows; i++)
                for (int j = 0; j < numCol; j++)
                    res += re[i, j];
            return res;
        }
    }
}
