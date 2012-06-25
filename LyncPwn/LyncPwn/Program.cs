using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace LyncPwn
{
    static class Program
    {
        public const string AppName = "...";
        private static readonly Mutex mutex = new Mutex(true, Program.AppName);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            try
            {
                if (!mutex.WaitOne(TimeSpan.Zero, true))
                    throw new ApplicationException("Another instance already running");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + Environment.NewLine +
                    e.InnerException + Environment.NewLine +
                    e.StackTrace);
            }
        }
    }
}
