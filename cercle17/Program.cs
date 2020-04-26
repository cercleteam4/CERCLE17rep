using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace cercle17
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

            GloblaVar.gUTIL=new clase_UTILESdb();
            GloblaVar.gUTIL.Leer_CONFIG("C:\\OREMAPE\\OrelessCfg.txt");
            GloblaVar.gUTIL.AbreTraza();
            GloblaVar.gUTIL.Leer_CONFIG("C:\\OREMAPE\\OrelessCfg.txt");
            Application.Run(new frmPpal());
        }
        
    }
}
  