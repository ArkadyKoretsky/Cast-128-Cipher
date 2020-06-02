/*
 * Encryption - 
 * Class for encryption process  
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

//string key;
//List<string> keys_km = new List<string>(16);
//List<string> keys_kr = new List<string>(16);

namespace Cast128_CS
{
    class Encryption
    {
        string fileName;
        /// <summary>
        /// plainText - 64 bit
        /// </summary>
        string plainText;

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




        public Encryption(string plainText)
        {
            this.plainText = plainText;
            /*
             * (L0,R0) <-- (m1...m64).
             * (Split the plaintext into left and
             * right 32-bit halves 
             * L0 = m1...m32 and 
             * R0 = m33...m64.)
             */
            prev_L = new BitArray(Encoding.ASCII.GetBytes(this.plainText.Substring(0, 31)));
            prev_R = new BitArray(Encoding.ASCII.GetBytes(this.plainText.Substring(32, 63)));
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
                BitArray retF2 = f1(prev_R, key.km[i], key.kr[i]);
                current_R = prev_L.Xor(retF2);
            }
            else
            {
                BitArray retF3 = f1(prev_R, key.km[i], key.kr[i]);
                current_R = prev_L.Xor(retF3);
            }
        }

        private BitArray f1(BitArray prev_R, BitArray p1, BitArray p2)
        {
            throw new NotImplementedException();
        }
    }
}
