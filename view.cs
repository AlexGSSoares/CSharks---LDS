<<<<<<< HEAD
using System;
using System.Threading;
using System.Windows.Forms;

namespace SevenZipFrontend {
    // View
    public interface IConsoleView {
        void ShowMessage(string message);
        string GetArchiveName();
        string[] GetFilesToArchive();
        string GetExtractPath();
        string GetArchiveToExtract();        
    }
    public partial class MainForm : Form, IConsoleView {
        public MainForm() {
            InitializeComponent();
        }

        private ArchiveController controller;
        public void SetController(ArchiveController controller) {
            this.controller = controller;
        }
        private void btnCreateArchive_Click(object sender, EventArgs e) {
            controller.CreateArchive();
        }
        private void btnExtractArchive_Click(object sender, EventArgs e) {
            controller.ExtractArchive();
        }

        public string GetArchiveName() {
            string archiveName = null;
            var t = new Thread((ThreadStart)(() => {
                using (var saveFileDialog = new SaveFileDialog()) {
                    saveFileDialog.Filter = "7ZIP files (*.7z)|*.7z|ZIP files (*.zip)|*.zip|All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                        archiveName = saveFileDialog.FileName;
                    }
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            return archiveName;
        }

        public string[] GetFilesToArchive() {
            string[] filesToArchive = null;
            var t = new Thread((ThreadStart)(() => {
                using (var openFileDialog = new OpenFileDialog()) {
                    openFileDialog.Multiselect = true;
                    openFileDialog.Filter = "All files (*.*)|*.*";
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    if (openFileDialog.ShowDialog() == DialogResult.OK) {
                        filesToArchive = openFileDialog.FileNames;
                    }
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            return filesToArchive;
        }

        public string GetArchiveToExtract() {
            string archiveName = null;
            var t = new Thread((ThreadStart)(() => {
                using (var openFileDialog = new OpenFileDialog()) {
                    openFileDialog.Filter = "7ZIP files (*.7z)|*.7z|ZIP files (*.zip)|*.zip|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK) {
                        archiveName = openFileDialog.FileName;
                    }
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            return archiveName;
        }

        public string GetExtractPath() {
            string extractPath = null;
            var t = new Thread((ThreadStart)(() => {
                using (var folderBrowserDialog = new FolderBrowserDialog()) {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                        extractPath = folderBrowserDialog.SelectedPath;
                    }
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            return extractPath;
        }
        public void ShowMessage(string message) {
            MessageBox.Show(message);
        }
    }
=======
namespace SevenZipFrontend{
    // View
    public class ConsoleView {
        public void DisplayMenu() {
            Console.WriteLine("1. Create Archive");
            Console.WriteLine("2. Extract Archive");
            Console.WriteLine("3. Exit");
        }

        public string GetUserInput(string message) {
            Console.Write(message + ": ");
            try {
                string input = Console.ReadLine();
                if (input == null) {
                    return ""; // Return an empty string if input is null
                }
                return input;
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred while reading input: {ex.Message}");
                return ""; // Return an empty string in case of an exception
            }
        }
        public void ShowMessage(string message) {
            Console.WriteLine(message);
        }
    }
>>>>>>> origin/master
}