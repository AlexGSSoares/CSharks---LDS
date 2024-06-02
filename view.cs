using System;
using System.Threading;
using System.Windows.Forms;
using SevenZip;

namespace SevenZipFrontend {
    // View
    public interface IConsoleView {
        void ShowMessage(string message);
        (string, OutArchiveFormat) GetArchiveName();
        CompressionLevel GetCompressionLevel();
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

        public CompressionLevel GetCompressionLevel() {
            
            // Get the selected item from the ComboBox
            string selectedOption = compressionLevelComboBox.SelectedItem.ToString();

            // Return the corresponding CompressionLevel
            switch (selectedOption) {
                case "None": return CompressionLevel.None;
                case "Fast": return CompressionLevel.Fast;
                case "Normal": return CompressionLevel.Normal;
                case "Ultra": return CompressionLevel.Ultra;
                default: return CompressionLevel.Normal; // Default to Normal if invalid input
            }
        }

        public (string, OutArchiveFormat) GetArchiveName() {
            string archiveName = null;
            OutArchiveFormat format = OutArchiveFormat.SevenZip; // default format
            var t = new Thread((ThreadStart)(() => {
                using (var saveFileDialog = new SaveFileDialog()) {
                    saveFileDialog.Filter = "7ZIP files (*.7z)|*.7z|ZIP files (*.zip)|*.zip|GZip files (*.gz)|*.gz|BZip2 files (*.bz2)|*.bz2|Tar files (*.tar)|*.tar";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                        archiveName = saveFileDialog.FileName;
                        switch (Path.GetExtension(archiveName).ToLower()) {
                            case ".zip":
                                format = OutArchiveFormat.Zip;
                                break;
                            case ".gz":
                                format = OutArchiveFormat.GZip;
                                break;
                            case ".bz2":
                                format = OutArchiveFormat.BZip2;
                                break;
                            case ".tar":
                                format = OutArchiveFormat.Tar;
                                break;
                            case ".7z":
                            default:
                                format = OutArchiveFormat.SevenZip;
                                break;
                        }
                    }
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            return (archiveName, format);
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
                    openFileDialog.Filter = "Compressed files (*.7z;*.zip;*.gz;*.bz2;*.tar)|*.7z;*.zip;*.gz;*.bz2;*.tar";
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
}