/*
 * Encryption - 
 * Class for encryption process  
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Remoting;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Cast128_CS
{

    class Encryption
    {
        public const uint MOD2_32 = 2 << 31;
        public const int BLOCKLENGTH = 64;
        public const int KMLENGTH = 32;
        public const int ROUNDCOUNT = 16;
        public const int Ia = 0;
        public const int Ib = 1;
        public const int Ic = 2;
        public const int Id = 3;

        public struct Block
        {
            public BitArray bitArray;
        }

        /// <summary>
        /// key - 128 bit
        /// </summary>
        KeysCreator key;

        BitArray current_L;
        BitArray prev_L;
        BitArray current_R;
        BitArray prev_R;

        int[] type1 = { 1, 4, 7, 10, 13, 16 };
        int[] type2 = { 2, 5, 8, 11, 14 };
        int[] type3 = { 3, 6, 9, 12, 15 };

        public Encryption()
        {
            current_L = new BitArray(32);
            prev_L = new BitArray(32);
            current_R = new BitArray(32);
            prev_R = new BitArray(32);
        }
        public string Encrypt(string fileName)
        {
            try
            {
                #region Read File And Convert To char Array
                string fileText = File.ReadAllText(fileName);
                int fileTextMod8 = fileText.Length % 8;
                char[] fileText_charArray;

                if (fileTextMod8 != 0)
                {
                    fileText_charArray = new char[fileText.Length + 8 - fileTextMod8];
                }
                else
                {
                    fileText_charArray = new char[fileText.Length];
                }
                fileText.ToCharArray().CopyTo(fileText_charArray, 0);
                #endregion

                List<Block> blocks = DivideToBlocks(fileText_charArray);

                foreach (Block block in blocks)
                {
                    MakeAllRounds(block);
                }

            }
            catch (Exception e)
            {
                WriteToUser("Error e---> " + e.Message);
                return null;
            }
            return "";
        }
        private List<Block> DivideToBlocks(char[] fileText)
        {
            // blocks to return
            //Block[] retBlocks = new Block[fileText.Length / 64+1];
            List<Block> retBlocks = new List<Block>();

            byte[] textbytes = fileText.Select(c => (byte)c).ToArray();
            byte[] tmpbytes = new byte[8];

            for (int i = 0; i < fileText.Length / 64 + 1; ++i)
            {
                Block block = new Block();
                for (int j = 0; j < 8; j++)
                {
                    tmpbytes[j] = (textbytes[i * 8 + j]);
                }
                block.bitArray = new BitArray(tmpbytes);
                retBlocks.Add(block);
            }

            return retBlocks;
        }
        private void MakeAllRounds(Block block)
        {
            for (int i = 0; i < 32; i++)
            {
                prev_L.Set(i, block.bitArray.Get(i));
                prev_R.Set(i, block.bitArray.Get(i + 32));
            }

            //if (key.size==80bits)
            //{
            //  for (int i = 0; i < 12; i++)
            //}

            for (int i = 0; i < 16; i++)
            {
                MakeRound(i);
            }
        }
        private void MakeRound(int i)
        {
            current_L = prev_R;
            if (type1.Contains(i))
            {
                BitArray retF1 = f1(prev_R, key.km[i], key.kr[i]);
                current_R = prev_L.Xor(retF1);
            }
            else if (type2.Contains(i))
            {
                BitArray retF2 = f2(prev_R, key.km[i], key.kr[i]);
                current_R = prev_L.Xor(retF2);
            }
            else
            {
                BitArray retF3 = f3(prev_R, key.km[i], key.kr[i]);
                current_R = prev_L.Xor(retF3);
            }
        }
        private BitArray f3(BitArray prev_R, BitArray km, BitArray kr)
        {
            //Type 3:  I = ((Kmi - D) <<< Kri)
            //    f = ((S1[Ia] + S2[Ib]) ^ S3[Ic]) - S4[Id]

            throw new NotImplementedException();
        }
        private BitArray f2(BitArray prev_R, BitArray km, BitArray kr)
        {
            //Type 2:  I = ((Kmi ^ D) <<< Kri)
            //    f = ((S1[Ia] - S2[Ib]) + S3[Ic]) ^ S4[Id]

            throw new NotImplementedException();
        }
        private BitArray f1(BitArray prev_R, BitArray km, BitArray kr)
        {
            //Type 1:  I = ((Kmi + D) <<< Kri)
            //         f = ((S1[Ia] ^ S2[Ib]) - S3[Ic]) + S4[Id]


            BitArray I = ShiftLeftBitArray(addBits(km,prev_R),kr);
            BitArray[] Is = CreateIBits(I);
            int[] bitValues = new int[1];
            bitValues[0]= S1[Convert.ToInt32(ConvertBitarrayToByteArray(Is[Ia]))] ^ S2[Convert.ToInt32(ConvertBitarrayToByteArray(Is[Ib]))];
            BitArray forXor = new BitArray(bitValues);

           // return ();

            throw new NotImplementedException();

        }

        private BitArray[] CreateIBits(BitArray I)
        {
            BitArray[] bitArrays = new BitArray[4];
            bitArrays[Ia] = new BitArray(8);
            bitArrays[Ib] = new BitArray(8);
            bitArrays[Ic] = new BitArray(8);
            bitArrays[Id] = new BitArray(8);

            for (int i = 0; i < 8; i++)
            {
                bitArrays[Ia][i] = I[i];
                bitArrays[Ib][i] = I[i + 8];
                bitArrays[Ic][i] = I[i + 16];
                bitArrays[Id][i] = I[i + 24];
            }
            return bitArrays;
        }
        private BitArray addBits(BitArray x, BitArray y)
        {
            int[] one = new int[1];
            one[0] = 1;
            BitArray oneInBit = new BitArray(one);
            
            // Iterate till there is no carry 
            while (Convert.ToInt32(ConvertBitarrayToByteArray(y)) != 0)
            {
                // carry now contains common 
                // set bits of x and y 
                BitArray carry = x.And(y);

                // Sum of bits of x and  
                // y where at least one  
                // of the bits is not set 
                x = x.Xor(y);

                // Carry is shifted by  
                // one so that adding it  
                // to x gives the required sum 
                y = ShiftLeftBitArray(carry, oneInBit);
            }
            return x;

        }
        private BitArray subBits(BitArray x, BitArray y)
        {
            int[] one = new int[1];
            one[0] = 1;
            BitArray oneInBit = new BitArray(one);
            // Iterate till there 
            // is no carry 
            while (Convert.ToInt32(ConvertBitarrayToByteArray(y)) != 0)
            {

                // borrow contains common  
                // set bits of y and unset 
                // bits of x 
                BitArray borrow = x.Not().And(y);

                // Subtraction of bits of x  
                // and y where at least one 
                // of the bits is not set 
                x = x.Xor(y);

                // Borrow is shifted by one  
                // so that subtracting it from  
                // x gives the required sum 
                y = ShiftLeftBitArray(borrow, oneInBit);
            }

            return x;
        }
        private BitArray ShiftLeftBitArray(BitArray bits, BitArray kr)
        {
            BitArray retBitarray = new BitArray(bits);
            BitArray forKeep = new BitArray(Convert.ToInt32(kr));

            for (int i = 0; i < forKeep.Length; i++)
            {
                forKeep[i] = retBitarray[i];

                for (int j = 1; j < retBitarray.Count; j++)
                {
                    retBitarray[j - 1] = retBitarray[j];
                }
            }
            for (int k = retBitarray.Count - forKeep.Length; k < retBitarray.Count; k++)
            {
                retBitarray[k] = forKeep[k - (retBitarray.Count - forKeep.Length)];
            }
            return retBitarray;
        }
        private byte[] ConvertBitarrayToByteArray(BitArray bit)
        {
            byte[] v = new byte[bit.Length];
            for (int i = 0; i < bit.Length; i++)
            {
                v[i] = Convert.ToByte(bit[i]);
            }
            return v;
        }
        private void WriteToUser(string v)
        {
            Console.WriteLine(v);
        }
    }
}
