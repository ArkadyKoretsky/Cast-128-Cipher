using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast128_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Encryption e = new Encryption();
            e.Encrypt("Matih.txt");
        }
    }
}
