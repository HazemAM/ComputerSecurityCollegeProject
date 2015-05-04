using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSecurity
{
    class RailFence
    {
        string inp;
        int n;
        public RailFence(string inp,int n)
        {
            this.inp = inp;
            this.n=n;
        }

        public string Encrypt()
        {
            string res = "";
            int numRow = n;
            int inpSize=inp.Length;
            int numColumn = inpSize % numRow == 0 ? inpSize / numRow : (inpSize / numRow) + 1;
            char[,] re = new char[numRow, numColumn];
            int count=0;
            for (int j = 0; j < numColumn; j++)
                for (int i = 0; i < numRow; i++)
                    if(count<inpSize)
                        re[i, j] = inp[count++];
            for (int i = 0; i < numRow; i++)
                for (int j = 0; j < numColumn; j++)
                    res += re[i, j];
            return res;
        }
        public string Decrypt()
        {
            string res = "";
            int numRow = n;
            int inpSize = inp.Length;
            int numColumn = inpSize % numRow == 0 ? inpSize / numRow : (inpSize / numRow) + 1;
            char[,] re = new char[numRow, numColumn];
            int count = 0;
            for (int i = 0; i < numRow; i++)
                for (int j = 0; j < numColumn; j++)
                    if(count<inpSize)
                        re[i,j]=  inp[count++];
            for (int j = 0; j < numColumn; j++)
                for (int i = 0; i < numRow; i++)
                    res += re[i, j];
            return res;
        }
    }
}
