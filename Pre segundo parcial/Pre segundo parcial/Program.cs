using System;
using System.Windows.Forms;
using Pre_segundo_parcial.Vista;

namespace Pre_segundo_parcial
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmInicioSesion());
        }
    }
}