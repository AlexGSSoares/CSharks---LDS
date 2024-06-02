using System;
using System.Windows.Forms;

namespace SevenZipFrontend {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = new MainForm();
            var archiveController = new ArchiveController(new ArchiveManager(), mainForm);
            mainForm.SetController(archiveController);
            Application.Run(mainForm);
        }
    }
}