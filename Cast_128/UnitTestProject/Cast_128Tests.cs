using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cast128_CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast128_CS.Tests
{
    [TestClass()]
    public class Cast_128Tests
    {
        [TestMethod()]
        public void DivideToBlocksTest()
        {
            string str = "str1" +
                "str2" +
                "str3" +
                "str4";
            char[] strCharArray = str.ToCharArray();
            List<Cast_128.Block> b = Cast_128.DivideToBlocks(strCharArray);
           
            string substring = "str1";
            char[] substringCharArray = substring.ToCharArray();
            byte[] substringByteArray = substringCharArray.Select(s => (byte)s).ToArray();
            Assert.AreEqual(b[0].msg[0], BitConverter.ToUInt32(substringByteArray, 0)); 
            
            substring = "str2";
            substringCharArray = substring.ToCharArray();
            substringByteArray = substringCharArray.Select(s => (byte)s).ToArray();
            Assert.AreEqual(b[0].msg[1], BitConverter.ToUInt32(substringByteArray, 0));

            substring = "str3";
            substringCharArray = substring.ToCharArray();
            substringByteArray = substringCharArray.Select(s => (byte)s).ToArray();
            Assert.AreEqual(b[1].msg[0], BitConverter.ToUInt32(substringByteArray, 0));
            
            substring = "str4";
            substringCharArray = substring.ToCharArray();
            substringByteArray = substringCharArray.Select(s => (byte)s).ToArray();
            Assert.AreEqual(b[1].msg[1], BitConverter.ToUInt32(substringByteArray, 0));
        }

        [TestMethod()]
        public void encryptTest()
        {

            Assert.Fail();
        }

        [TestMethod()]
        public void decryptTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Cast128_OnTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MakeRoundTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void f1Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void f2Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void f3Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void splitITest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void cyclicShiftTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void sumMod2_32Test()
        {
            uint x = (2<<31);
            uint y = 1;
            Assert.AreEqual(Cast_128.sumMod2_32(x, y), 1);
        }

        [TestMethod()]
        public void subtractMod2_32Test()
        {
            Assert.Fail();
        }
    }
}