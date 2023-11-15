using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Collections;

namespace CompresorHuffman
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Incializacion del programa y renderización de la ventana
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
