using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSecurity
{
    class MonoAlpha
    {
        string input;
        string key;
        public MonoAlpha(string input,string key)
        {
            this.input = input.ToLower() ;
            this.key = key.ToLower();
            validateKey();
        }

        private void validateKey()
        {
            if (key.Length != 26 || key.Distinct().Count() != 26)
                throw new Exception("please use a valid key of 26 character with distinct characters");
        }

        public string Encrypt()
        {
            string res = "";
            foreach (char c in input)
            {
                int index = (int)(c - 'a');
                res += key[index];
            }
            return res;
        }
        public string Decrypt()
        {
            string res = "";
            foreach (char c in input)
            {
                int index = key.IndexOf(c);
                res += (char)('a'+index);
            }
            return res;
        }

    }
}
