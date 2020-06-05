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
using System.Text;
using System.Threading.Tasks;


namespace Cast128_CS
{

    class Encryption
    {
        public const uint MOD2_32 = 2 << 31;
        public const int KEYLENGTH = 128;
        public const int BLOCKLENGTH = 64;
        public const int KEYSCOUNT = 32;
        public const int ROUNDCOUNT = 16;

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
            throw new NotImplementedException();
        }

        private BitArray f2(BitArray prev_R, BitArray km, BitArray kr)
        {
            throw new NotImplementedException();
        }

        private BitArray f1(BitArray prev_R, BitArray km, BitArray kr)
        {
            BitArray I = myAdd(km, prev_R, 1);
            throw new NotImplementedException();
        }
        uint myAdd(BitArray a, BitArray b, int operation)
        {
            byte[] tmpbytes = new byte[4];
            a.CopyTo(tmpbytes, 0);
            uint a2 = BitConverter.ToUInt32(tmpbytes, 0);
            b.CopyTo(tmpbytes, 0);
            uint b2 = BitConverter.ToUInt32(tmpbytes, 0);
            uint ret = 0;
            switch (operation)
            {
                case 1:
                    ret = (a2 + b2) % MOD2_32;
                    break;
                case 2:
                    ret = (a2 ^ b2);
                    break;
                case 3:
                    ret = (a2 - b2) % MOD2_32;
                    break;
                default:
                    break;
            }

            return ret;
        }
        private void WriteToUser(string v)
        {
            Console.WriteLine(v);
        }
    }
}
