using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSecurity
{
    class TripleDes
    {
        string input;
        string[] keys;
        int mode;
        public TripleDes(string input,string[] keys,int mode)
        {
            this.input = input;
            this.keys = keys;
            this.mode = mode;
        }
        public string encrypt()
        {
            Des D1 = new Des(keys[0], input,mode);
            Des D2 = new Des(keys[1], D1.Encode().Replace("-",""), mode);
            Des D3 = new Des(keys[2], D2.decode().Replace("-",""), mode);
            return D3.Encode();
        }
        public string decrypt()
        {
            Des D3 = new Des(keys[2], input, mode);
            Des D2 = new Des(keys[1], D3.decode().Replace("-",""), mode);
            Des D1 = new Des(keys[0], D2.Encode().Replace("-", ""), mode);
            return D1.decode();
        }
    }
}
