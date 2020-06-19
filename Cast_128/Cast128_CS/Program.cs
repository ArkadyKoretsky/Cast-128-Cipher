using System;
using System.Collections;
using System.Collections.Generic;
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
            //Cast_128 e = new Cast_128();
            //string[] strResult=e.RunCast128("Matih.txt","MatiArkadyShoham");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
