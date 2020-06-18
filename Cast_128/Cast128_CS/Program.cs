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
           // KeysCreator key = new KeysCreator("60638470282");
            Cast_128 e = new Cast_128();
            e.RunCast128("Matih.txt", "60638470282");
        }
    }
}
