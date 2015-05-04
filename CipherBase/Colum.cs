using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace ComputerSecurity

{
    class Colum
    {
        int[] n;
        string inp;
        //n 0 based
        public Colum(int[] n,string inp)
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
                for (int j = 0; i < numCol; j++)
                    if (count < inputsize)
                        re[i, j] = inp[count++];
                    else
                        re[i, j] = 'x';
            for (int i = 0; i < numCol;i++ )
            {
                int index = n[i];
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
            for (int i = 0; i < numCol;i++ )
            {
                int index = n[i];
                index *=numRows;
                for(int j=0;j<numRows;j++)
                {
                    re[j, i] = inp[index++];
                }
            }
            for (int i = 0; i < numRows; i++)
                for (int j = 0; j < numCol; j++)
                    res += re[i, j];
            return res;
        }
    }
}
