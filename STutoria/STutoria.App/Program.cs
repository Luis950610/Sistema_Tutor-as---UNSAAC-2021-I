using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STutoria.App
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login fnlogin = new Login();
            fnlogin.Show();
            Application.Run();
            /*if (fnlogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Padre.FormPadre());
            }*/

        }
    }
}
