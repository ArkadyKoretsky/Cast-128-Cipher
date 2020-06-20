using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cast128_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Cast_128 e = new Cast_128();
            string inputData = File.ReadAllText("Matih.txt");
            string strResult = e.RunCast128(inputData, "MatiArkadyShoham");
            Console.WriteLine(strResult);
            Console.WriteLine(e.RunCast128(strResult, "MatiArkadyShoham", true));

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());
        }
    }
}
