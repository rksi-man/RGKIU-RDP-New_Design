using RGKIU_VCH;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace RDP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main(string[] args)
        {
            bool oneonly;
            Mutex m = new Mutex(true, "VPN+RDP", out oneonly);
            if (oneonly)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new VPN());
            }
            else
            {
                MessageBox.Show("ƒругой экземпл€р этой программы уже запущен", "ќшибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}