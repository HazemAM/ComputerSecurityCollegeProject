using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSecurity
{
    public class Des
    {
        string input;
        string key;
        string cipherText;
        string plainText;
        int Mode;
        byte[] inputData;
        byte[] keyData;
        
        
        int NumRounds = 16;
        //mode 0 is text mode 1 is hex (hex is the tested one "el mfrood")
        public Des(string key,string input,int mode)
        {
            this.key = key;
            this.input = input;
            this.Mode = mode;
            ValidateKey();
        }
        public static byte[] HexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        private void ValidateKey()
        {
            if (Mode == 0)
                keyData = Encoding.ASCII.GetBytes(key);
            else
                keyData = HexToByteArray(key);
            if (keyData.Length != 8)
                throw new Exception("Not a valid key");
            else
            {
                byte[] inp;
                if (Mode == 0)
                    inp = Encoding.ASCII.GetBytes(input);
                else
                    inp = HexToByteArray(input);


                if (inp.Length % 8 == 0)
                    inputData = inp;
                else
                {
                    inputData = new byte[(int)((inp.Length / 8) + 1) * 8];
                    inp.CopyTo(inputData, 0);
                }
            }
        }
        public string Encode()
        {
            int index = 0;
            int len=inputData.Length;
            plainText = Encoding.ASCII.GetString(inputData);
            BitArray[] keys = GenKeys();
            while(index<len)
            {
                byte[] current=new byte[8];
                Array.Copy(inputData,index,current,0,8);
                BitArray Bits=new BitArray(current);
                Bits = reverse(Bits);
                BitArray[]data = PermutateData(Bits);
                doRounds(data, keys,EncType.Encyrpt);
                index += 8;
            }
            return cipherText;
        }
        public string decode()
        {
            plainText = "";
            int index = 0;
            int len = inputData.Length;
            BitArray[] keys = GenKeys();
            while (index < len)
            {
                byte[] current = new byte[8];
                Array.Copy(inputData, index, current, 0, 8);
                BitArray Bits = new BitArray(current);
                Bits = reverse(Bits);
                BitArray[] data = PermutateData(Bits);
                doRounds(data, keys,EncType.Decrypt);
                index += 8;
            }
            return plainText;
        }

        private void doRounds(BitArray[] data, BitArray[] Keys,EncType mode)
        {
            BitArray[] L = new BitArray[NumRounds+1];
            BitArray[] R = new BitArray[NumRounds+1];
            if (mode.Equals(EncType.Decrypt))
            {
                Keys = Keys.Reverse().ToArray();
                L[0] = data[0];
                R[0] = data[1];
                for (int i = 1; i < NumRounds + 1; i++)
                {
                    L[i] = new BitArray(R[i - 1]);
                    BitArray E = Expand(R[i - 1]);
                    E = E.Xor(Keys[i - 1]);
                    E = getChoice(E);
                    E = getPerm(E);
                    R[i] = L[i - 1].Xor(E);
                }
                BitArray Cipher = getInverseP(R[16], L[16]);
                Cipher = reverse(Cipher);
                byte[] text = BitArrayToByteArray(Cipher);
                if (Mode == 1)
                    plainText += BitConverter.ToString(text);
                else
                    plainText += Encoding.ASCII.GetString(text);
            }
            else
            {
                L[0] = data[0];
                R[0] = data[1];
                for (int i = 1; i < NumRounds + 1; i++)
                {
                    L[i] = new BitArray(R[i - 1]);
                    BitArray E = Expand(R[i - 1]);
                    E = E.Xor(Keys[i - 1]);
                    E = getChoice(E);
                    E = getPerm(E);
                    R[i] = L[i - 1].Xor(E);
                }
                BitArray Cipher = getInverseP(R[16], L[16]);
                Cipher = reverse(Cipher);
                byte[] text = BitArrayToByteArray(Cipher);
                if (Mode == 1)
                    cipherText += BitConverter.ToString(text);
                else
                    cipherText += Encoding.ASCII.GetString(text);
            }
        }
        private  byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
           // bits = reverse(bits);
            bits.CopyTo(ret, 0);
            return ret;
        }
        private BitArray getInverseP(BitArray L, BitArray R)
        {
            BitArray res = new BitArray(64);
            res[0]=R[7];
            res[1]=L[7];
            res[2]=R[15];
            res[3]=L[15];
            res[4]=R[23];
            res[5]=L[23];
            res[6]=R[31];
            res[7]=L[31];
            res[8]=R[6];
            res[9]=L[6];
            //-----------------------------
            res[10]=R[14];
            res[11]=L[14];
            res[12]=R[22];
            res[13]=L[22];
            res[14]=R[30];
            res[15]=L[30];
            res[16]=R[5];
            res[17]=L[5];
            res[18]=R[13];
            res[19]=L[13];
            //-----------------------------
            res[20]=R[21];
            res[21]=L[21];
            res[22]=R[29];
            res[23]=L[29];
            res[24]=R[4];
            res[25]=L[4];
            res[26]=R[12];
            res[27]=L[12];
            res[28]=R[20];
            res[29]=L[20];
            //-----------------------------
            res[30]=R[28];
            res[31]=L[28];
            res[32]=R[3];
            res[33]=L[3];
            res[34]=R[11];
            res[35]=L[11];
            res[36]=R[19];
            res[37]=L[19];
            res[38]=R[27];
            res[39]=L[27];
            //-----------------------------
            res[40]=R[2];
            res[41]=L[2];
            res[42]=R[10];
            res[43]=L[10];
            res[44]=R[18];
            res[45]=L[18];
            res[46]=R[26];
            res[47]=L[26];
            res[48]=R[1];
            res[49]=L[1];
            //-----------------------------
            res[50]=R[9];
            res[51]=L[9];
            res[52]=R[17];
            res[53]=L[17];
            res[54]=R[25];
            res[55]=L[25];
            res[56]=R[0];
            res[57]=L[0];
            res[58]=R[8];
            res[59]=L[8];
            //-----------------------------
            res[60]=R[16];
            res[61]=L[16];
            res[62]=R[24];
            res[63]=L[24];

            return res;
        }

        private BitArray getPerm(BitArray E)
        {
            BitArray res = new BitArray(32);
            res[0]=E[15];
            res[1]=E[6];
            res[2]=E[19];
            res[3]=E[20];
            res[4]=E[28];
            res[5]=E[11];
            res[6]=E[27];
            res[7]=E[16];
            res[8]=E[0];
            res[9]=E[14];
            //-----------------------------------
            res[10]=E[22];
            res[11]=E[25];
            res[12]=E[4];
            res[13]=E[17];
            res[14]=E[30];
            res[15]=E[9];
            res[16]=E[1];
            res[17]=E[7];
            res[18]=E[23];
            res[19]=E[13];
            //-----------------------------------
            res[20]=E[31];
            res[21]=E[26];
            res[22]=E[2];
            res[23]=E[8];
            res[24]=E[18];
            res[25]=E[12];
            res[26]=E[29];
            res[27]=E[5];
            res[28]=E[21];
            res[29]=E[10];
            //-----------------------------------
            res[30]=E[3];
            res[31] = E[24];

            return res;
        }

        private BitArray getChoice(BitArray E)
        {
            string[, ,] S = {{
                       { "14", "4", "13", "1", "2", "15", "11", "8", "3", "10", "6", "12", "5", "9", "0", "7" },
                       { "0", "15", "7", "4", "14", "2", "13", "1", "10", "6", "12", "11", "9", "5", "3", "8" },
                       { "4", "1", "14", "8", "13", "6", "2", "11", "15", "12", "9", "7", "3", "10", "5", "0" },
                       { "15", "12", "8", "2", "4", "9", "1", "7", "5", "11", "3", "14", "10", "0", "6", "13" } 
                       },
                       {
                       { "15", "1", "8", "14", "6", "11", "3", "4", "9", "7", "2", "13", "12", "0", "5", "10" },
                       { "3", "13", "4", "7", "15", "2", "8", "14", "12", "0", "1", "10", "6", "9", "11", "5" },
                       { "0", "14", "7", "11", "10", "4", "13", "1", "5", "8", "12", "5", "9", "3", "2", "15" },
                       { "13", "8", "10", "1", "3", "15", "4", "2", "11", "6", "7", "12", "0", "5", "14", "9" } 
                       },
                       {
                       { "10" ,"0" ,"9" ,"14" ,"6" ,"3" ,"15" ,"5" ,"1" ,"13" ,"12" ,"7" ,"11" ,"4" ,"2" ,"8" },
                       { "13","7" ,"0" ,"9" ,"3" ,"4" ,"6" ,"10" ,"2" ,"8" ,"5" ,"14" ,"12" ,"11" ,"15" ,"1" },
                       { "13","6" ,"4" ,"9" ,"8" ,"15" ,"3" ,"0" ,"11" ,"1" ,"2" ,"12" ,"5" ,"10" ,"14" ,"7" },
                       { "1" ,"10" ,"13" ,"0" ,"6" ,"9" ,"8" ,"7","4" ,"15" ,"14" ,"3" ,"11" ,"5" ,"2" ,"12" }
                       },
                       { 
                       { "7" ,"13" ,"14" ,"3" ,"0" ,"6" ,"9" ,"10" ,"1" ,"2" ,"8" ,"5" ,"11" ,"12" ,"4" ,"15" },
                       { "13" ,"8" ,"11" ,"5" ,"6" ,"15" ,"0" ,"3" ,"4" ,"7" ,"2" ,"12" ,"1" ,"10" ,"14" ,"9" },
                       { "10" ,"6" ,"9" ,"0" ,"12" ,"11" ,"7" ,"13" ,"15" ,"1" ,"3" ,"14" ,"5" ,"2" ,"8" ,"4" },
                       { "3" ,"15" ,"0" ,"6" ,"10" ,"1" ,"13" ,"8" ,"9" ,"4" ,"5" ,"11" ,"12" ,"7" ,"2" ,"14" }
                       },
                       {
                       { "2" ,"12" ,"4" ,"1" ,"7" ,"10" ,"11" ,"6" ,"8" ,"5" ,"3" ,"15" ,"13" ,"0" ,"14" ,"9" },
                       { "14" ,"11","2" ,"12" ,"4" ,"7" ,"13" ,"1" ,"5" ,"0" ,"15" ,"10" ,"3" ,"9" ,"8" ,"6" },
                       { "4"  ,"2" ,"1"  ,"11" ,"10" ,"13" ,"7" ,"8" ,"15" ,"9" ,"12" ,"5" ,"6" ,"3" ,"0" ,"14" },
                       { "11" ,"8" ,"12" ,"7" ,"1" ,"14" ,"2" ,"13" ,"6" ,"15" ,"0" ,"9" ,"10" ,"4" ,"5" ,"3" } 
                       },
                       { 
                       { "12" ,"1" ,"10" ,"15" ,"9" ,"2" ,"6" ,"8" ,"0" ,"13" ,"3" ,"4" ,"14" ,"7" ,"5" ,"11" },
                       { "10" ,"15" ,"4" ,"2" ,"7" ,"12" ,"9" ,"5" ,"6" ,"1" ,"13" ,"14" ,"0" ,"11" ,"3" ,"8" },
                       { "9" ,"14" ,"15" ,"5" ,"2" ,"8" ,"12" ,"3" ,"7" ,"0" ,"4" ,"10" ,"1" ,"13" ,"11" ,"6" },
                       { "4" ,"3" ,"2" ,"12" ,"9" ,"5" ,"15" ,"10" ,"11" ,"14" ,"1" ,"7" ,"6" ,"0" ,"8" ,"13"} 
                       },
                       {
                       { "4" ,"11" ,"2" ,"14" ,"15" ,"0" ,"8" ,"13" ,"3" ,"12" ,"9" ,"7" ,"5" ,"10" ,"6" ,"1" },
                       { "13" ,"0" ,"11" ,"7" ,"4" ,"9" ,"1" ,"10" ,"14" ,"3" ,"5" ,"12" ,"2" ,"15" ,"8" ,"6" },
                       { "1" ,"4" ,"11" ,"13" ,"12" ,"3" ,"7" ,"14" ,"10" ,"15" ,"6" ,"8" ,"0" ,"5" ,"9" ,"2" },
                       { "6" ,"11" ,"13" ,"8" ,"1" ,"4" ,"10" ,"7" ,"9" ,"5" ,"0" ,"15" ,"14" ,"2" ,"3" ,"12" } 
                       },
                       {
                       { "13" ,"2" ,"8" ,"4" ,"6" ,"15" ,"11" ,"1" ,"10" ,"9" ,"3" ,"14" ,"5" ,"0" ,"12" ,"7" },
                       { "1" ,"15" ,"13" ,"8" ,"10" ,"3" ,"7" ,"4" ,"12" ,"5" ,"6" ,"11" ,"0" ,"14" ,"9" ,"2" },
                       { "7" ,"11" ,"4" ,"1" ,"9" ,"12" ,"14" ,"2" ,"0" ,"6" ,"10" ,"13" ,"15" ,"3" ,"5" ,"8" },
                       { "2" ,"1" ,"14" ,"7" ,"4" ,"10" ,"8" ,"13" ,"15" ,"12" ,"9" ,"0" ,"3" ,"5" ,"6" ,"11" } 
                       }
                       };
            BitArray choice;
            BitArray[] Boxes = getBoxes(E);
            byte[] byteChoice=new byte[8];
            int[] row=new int[8];
            int[] coloumn=new int[8];
            int count = 0;
            for (int i = 0; i < 8;i++ )
            {
                if (Boxes[i][0] == true)
                    row[i] += 2;
                if (Boxes[i][5] == true)
                    row[i] += 1;
                if (Boxes[i][1] == true)
                    coloumn[i] += 8;
                if (Boxes[i][2] == true)
                    coloumn[i] += 4;
                if (Boxes[i][3] == true)
                    coloumn[i] += 2;
                if (Boxes[i][4] == true)
                    coloumn[i] += 1;
                string val = S[i, row[i], coloumn[i]];
                int hex=int.Parse(val);
                byte[] temp = BitConverter.GetBytes(hex);
                //if(BitConverter.IsLittleEndian)
                //    temp = temp.Reverse().ToArray();
                Array.Copy(temp, 0, byteChoice, i, 1);
                count += 4;
            }
            byte[] res = new byte[4];
            byte t =(byte) (byteChoice[1] >> 4);
            for(int i=0;i<4;i++)
                res[i]=(byte)(byteChoice[i*2]<<4|byteChoice[i*2+1]);
            choice = new BitArray(res);
            choice = reverse(choice);
            return choice;
        }

        private BitArray[] getBoxes(BitArray E)
        {
            BitArray m = new BitArray(E);
            BitArray[] boxes = new BitArray[8];
            int count=0;
            for(int i=0;i<8;i++)
            {
                boxes[i] = new BitArray(6);
                for(int j=0;j<6;j++)
                {
                    boxes[i][j] = m[count];
                    count++;
                }
            }
            return boxes;
        }

        private BitArray Expand(BitArray Re)
        {
            BitArray R = new BitArray(Re);
            BitArray res = new BitArray(48);
            res[0]=R[31];
            res[1]=R[0];
            res[2]=R[1];
            res[3]=R[2];
            res[4]=R[3];
            res[5]=R[4];
            res[6]=R[3];
            res[7]=R[4];
            res[8]=R[5];
            res[9]=R[6];
            //--------------------------------------
            res[10]=R[7];
            res[11]=R[8];
            res[12]=R[7];
            res[13]=R[8];
            res[14]=R[9];
            res[15]=R[10];
            res[16]=R[11];
            res[17]=R[12];
            res[18]=R[11];
            res[19]=R[12];
            //--------------------------------------
            res[20]=R[13];
            res[21]=R[14];
            res[22]=R[15];
            res[23]=R[16];
            res[24]=R[15];
            res[25]=R[16];
            res[26]=R[17];
            res[27]=R[18];
            res[28]=R[19];
            res[29]=R[20];
            //--------------------------------------
            res[30]=R[19];
            res[31]=R[20];
            res[32]=R[21];
            res[33]=R[22];
            res[34]=R[23];
            res[35]=R[24];
            res[36]=R[23];
            res[37]=R[24];
            res[38]=R[25];
            res[39]=R[26];
            //--------------------------------------
            res[40]=R[27];
            res[41]=R[28];
            res[42]=R[27];
            res[43]=R[28];
            res[44]=R[29];
            res[45]=R[30];
            res[46]=R[31];
            res[47] = R[0];
            return res;
        }

        private BitArray[] PermutateData(BitArray dat)
        {
            BitArray data = new BitArray(dat);
            BitArray[] res = new BitArray[2];
            for (int i = 0; i < 2;i++ )
                res[i] = new BitArray(32);

            res[0][0]=data[57];
            res[0][1]=data[49];
            res[0][2]=data[41];
            res[0][3]=data[33];
            res[0][4]=data[25];
            res[0][5]=data[17];
            res[0][6]=data[9];
            res[0][7]=data[1];
            res[0][8]=data[59];
            res[0][9]=data[51];
            //-----------------------------------------
            res[0][10]=data[43];
            res[0][11]=data[35];
            res[0][12]=data[27];
            res[0][13]=data[19];
            res[0][14]=data[11];
            res[0][15]=data[3];
            res[0][16]=data[61];
            res[0][17]=data[53];
            res[0][18]=data[45];
            res[0][19]=data[37];
            //-----------------------------------------
            res[0][20]=data[29];
            res[0][21]=data[21];
            res[0][22]=data[13];
            res[0][23]=data[5];
            res[0][24]=data[63];
            res[0][25]=data[55];
            res[0][26]=data[47];
            res[0][27]=data[39];
            res[0][28]=data[31];
            res[0][29]=data[23];
            //-----------------------------------------
            res[0][30]=data[15];
            res[0][31]=data[7];
            //------------------------------------------
            res[1][0]=data[56];
            res[1][1]=data[48];
            res[1][2]=data[40];
            res[1][3]=data[32];
            res[1][4]=data[24];
            res[1][5]=data[16];
            res[1][6]=data[8];
            res[1][7]=data[0];
            res[1][8]=data[58];
            res[1][9]=data[50];
            //-----------------------------------------
            res[1][10]=data[42];
            res[1][11]=data[34];
            res[1][12]=data[26];
            res[1][13]=data[18];
            res[1][14]=data[10];
            res[1][15]=data[2];
            res[1][16]=data[60];
            res[1][17]=data[52];
            res[1][18]=data[44];
            res[1][19]=data[36];
            //-----------------------------------------
            res[1][20]=data[28];
            res[1][21]=data[20];
            res[1][22]=data[12];
            res[1][23]=data[4];
            res[1][24]=data[62];
            res[1][25]=data[54];
            res[1][26]=data[46];
            res[1][27]=data[38];
            res[1][28]=data[30];
            res[1][29]=data[22];
            //-----------------------------------------
            res[1][30]=data[14];
            res[1][31] = data[6];
            return res;
        }

        private BitArray[] GenKeys()
        {
            int[] rotSched = { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };
            BitArray[] k = getfirstPermKey();
            BitArray[][] rotKeys = new BitArray[NumRounds][];
            rotKeys[0] = getRotKeys(k, rotSched[0]);
            
            for(int i=1;i<NumRounds;i++)
            {
                rotKeys[i] = getRotKeys(rotKeys[i - 1], rotSched[i]);
            }
            return getKeys(rotKeys);
        }

        private BitArray[] getKeys(BitArray[][] rotKeys)
        {
            BitArray[] keys= new BitArray[NumRounds];
            for (int i = 0; i < NumRounds;i++ )
            {
                keys[i] = getPermChoice2(rotKeys[i]);
            }
            return keys;
        }

        private BitArray getPermChoice2(BitArray[] rotKey)
        {
            BitArray key = new BitArray(48);
            key[0] = rotKey[0][13];
            key[1] = rotKey[0][16];
            key[2] = rotKey[0][10];
            key[3] = rotKey[0][23];
            key[4] = rotKey[0][0];
            key[5] = rotKey[0][4];
            key[6] = rotKey[0][2];
            key[7] = rotKey[0][27];
            key[8] = rotKey[0][14];
            key[9] = rotKey[0][5];
            //-------------------------------------------------
            key[10] = rotKey[0][20];
            key[11] = rotKey[0][9];
            key[12] = rotKey[0][22];
            key[13] = rotKey[0][18];
            key[14] = rotKey[0][11];
            key[15] = rotKey[0][3];
            key[16] = rotKey[0][25];
            key[17] = rotKey[0][7];
            key[18] = rotKey[0][15];
            key[19] = rotKey[0][6];
            //-------------------------------------------------
            key[20] = rotKey[0][26];
            key[21] = rotKey[0][19];
            key[22] = rotKey[0][12];
            key[23] = rotKey[0][1];
            key[24] = rotKey[1][12];
            key[25] = rotKey[1][23];
            key[26] = rotKey[1][2];
            key[27] = rotKey[1][8];
            key[28] = rotKey[1][18];
            key[29] = rotKey[1][26];
            //-------------------------------------------------
            key[30] = rotKey[1][1];
            key[31] = rotKey[1][11];
            key[32] = rotKey[1][22];
            key[33] = rotKey[1][16];
            key[34] = rotKey[1][4];
            key[35] = rotKey[1][19];
            key[36] = rotKey[1][15];
            key[37] = rotKey[1][20];
            key[38] = rotKey[1][10];
            key[39] = rotKey[1][27];
            //-------------------------------------------------
            key[40] = rotKey[1][5];
            key[41] = rotKey[1][24];
            key[42] = rotKey[1][17];
            key[43] = rotKey[1][13];
            key[44] = rotKey[1][21];
            key[45] = rotKey[1][7];
            key[46] = rotKey[1][0];
            key[47] = rotKey[1][3];
            //-------------------------------------------------
            return key;
        }

        private BitArray[] getRotKeys(BitArray[] key, int rotations)
        {
            int size=28;
            BitArray[] res=new BitArray[2];
            res[0] = new BitArray(key[0]);
            res[1] = new BitArray(key[1]);
            for(int i=0;i<rotations;i++)
            {
                bool C1 = res[0][0];
                bool D1 = res[1][0];
                for(int j=0;j<size-1;j++)
                {
                    res[0][j] = res[0][j + 1];
                    res[1][j] = res[1][j + 1];
                }
                res[0][size-1]=C1;
                res[1][size-1]=D1;
            }
            return res;
        }

        private BitArray[] getfirstPermKey()
        {
            BitArray[] keys = new BitArray[2];
            BitArray initKey = new BitArray(keyData);
            initKey = reverse(initKey);
            keys[0] = new BitArray(28);
            keys[1] = new BitArray(28);
            keys[0].Set(0, initKey.Get(56));
            keys[0].Set(1, initKey.Get(48));
            keys[0].Set(2, initKey.Get(40));
            keys[0].Set(3, initKey.Get(32));
            keys[0].Set(4, initKey.Get(24));
            keys[0].Set(5, initKey.Get(16));
            keys[0].Set(6, initKey.Get(8));
            keys[0].Set(7, initKey.Get(0));
            keys[0].Set(8, initKey.Get(57));
            keys[0].Set(9, initKey.Get(49));
            //----------------------------------------
            keys[0].Set(10, initKey.Get(41));
            keys[0].Set(11, initKey.Get(33));
            keys[0].Set(12, initKey.Get(25));
            keys[0].Set(13, initKey.Get(17));
            keys[0].Set(14, initKey.Get(9));
            keys[0].Set(15, initKey.Get(1));
            keys[0].Set(16, initKey.Get(58));
            keys[0].Set(17, initKey.Get(50));
            keys[0].Set(18, initKey.Get(42));
            keys[0].Set(19, initKey.Get(34));
            //----------------------------------------
            keys[0].Set(20, initKey.Get(26));
            keys[0].Set(21, initKey.Get(18));
            keys[0].Set(22, initKey.Get(10));
            keys[0].Set(23, initKey.Get(2));
            keys[0].Set(24, initKey.Get(59));
            keys[0].Set(25, initKey.Get(51));
            keys[0].Set(26, initKey.Get(43));
            keys[0].Set(27, initKey.Get(35));
           //-------------------------------------------
            keys[1].Set(0, initKey.Get(62));
            keys[1].Set(1, initKey.Get(54));
            keys[1].Set(2, initKey.Get(46));
            keys[1].Set(3, initKey.Get(38));
            keys[1].Set(4, initKey.Get(30));
            keys[1].Set(5, initKey.Get(22));
            keys[1].Set(6, initKey.Get(14));
            keys[1].Set(7, initKey.Get(6));
            keys[1].Set(8, initKey.Get(61));
            keys[1].Set(9, initKey.Get(53));
            //----------------------------------------
            keys[1].Set(10, initKey.Get(45));
            keys[1].Set(11, initKey.Get(37));
            keys[1].Set(12, initKey.Get(29));
            keys[1].Set(13, initKey.Get(21));
            keys[1].Set(14, initKey.Get(13));
            keys[1].Set(15, initKey.Get(5));
            keys[1].Set(16, initKey.Get(60));
            keys[1].Set(17, initKey.Get(52));
            keys[1].Set(18, initKey.Get(44));
            keys[1].Set(19, initKey.Get(36));
            //----------------------------------------
            keys[1].Set(20, initKey.Get(28));
            keys[1].Set(21, initKey.Get(20));
            keys[1].Set(22, initKey.Get(12));
            keys[1].Set(23, initKey.Get(4));
            keys[1].Set(24, initKey.Get(27));
            keys[1].Set(25, initKey.Get(19));
            keys[1].Set(26, initKey.Get(11));
            keys[1].Set(27, initKey.Get(3));
            return keys;
        }

        private BitArray reverse(BitArray arr)
        {
            int size = arr.Length;
            BitArray res = new BitArray(size);
            int numGroups = size / 8;
            for(int i=0;i<numGroups;i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    res[(i * 8) + j] = arr[(i * 8) + 7 - j];
                    res[(i * 8) + 7 - j] = arr[(i * 8) + j];
                }
            }
            return res;
        }

    }
}
