namespace SevenZipFrontend{
    // Controller
    public class ArchiveController {
        private ArchiveManager archiveManager;
        private ConsoleView view;

        public ArchiveController() {
            archiveManager = new ArchiveManager();
            view = new ConsoleView();
        }

        public void ProcessUserInput() {
            while (true) {
                view.DisplayMenu();
                string choice = view.GetUserInput("Enter your choice");

                switch (choice) {
                    case "1":
                        CreateArchive();
                        break;
                    case "2":
                        ExtractArchive();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        private void CreateArchive() {
            string archiveName = null;
            var t1 = new Thread((ThreadStart)(() => {
                using (var saveFileDialog = new SaveFileDialog()) {
                    saveFileDialog.Filter = "7ZIP files (*.7z)|*.7z|ZIP files (*.zip)|*.zip|All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                        archiveName = saveFileDialog.FileName;
                    }
                }
            }));

            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
            t1.Join();

            if (archiveName == null) {
                // User cancelled, return without creating archive
                return;
            }

            string[] filesToArchive = null;
            var t2 = new Thread((ThreadStart)(() => {
                using (var openFileDialog = new OpenFileDialog()) {
                    openFileDialog.Multiselect = true;
                    openFileDialog.Filter = "All files (*.*)|*.*";
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    if (openFileDialog.ShowDialog() == DialogResult.OK) {
                        filesToArchive = openFileDialog.FileNames;
                    }
                }
            }));

            t2.SetApartmentState(ApartmentState.STA);
            t2.Start();
            t2.Join();

            if (filesToArchive == null || filesToArchive.Length == 0) {
                // User cancelled, return without creating archive
                return;
            }

            if (archiveManager.CreateArchive(archiveName, filesToArchive)) {
                view.ShowMessage("Archive created successfully!");
            } else {
                view.ShowMessage("Failed to create archive. Archive may already exist.");
            }
        }

        private void ExtractArchive() {
            string archiveName = null;
            var t1 = new Thread((ThreadStart)(() => {
                using (var openFileDialog = new OpenFileDialog()) {
                    openFileDialog.Filter = "7ZIP files (*.7z)|*.7z|ZIP files (*.zip)|*.zip|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK) {
                        archiveName = openFileDialog.FileName;
                    }
                }
            }));

            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
            t1.Join();

            if (archiveName == null) {
                // User cancelled, return without extracting archive
                return;
            }

            string extractPath = null;
            var t2 = new Thread((ThreadStart)(() => {
                using (var folderBrowserDialog = new FolderBrowserDialog()) {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                        extractPath = folderBrowserDialog.SelectedPath;
                    }
                }
            }));

            t2.SetApartmentState(ApartmentState.STA);
            t2.Start();
            t2.Join();

            if (extractPath == null) {
                // User cancelled, return without extracting archive
                return;
            }

            if (archiveManager.ExtractArchive(archiveName, extractPath)) {
                view.ShowMessage("Archive extracted successfully!");
            } else {
                view.ShowMessage("Failed to extract archive. Archive may not exist or extraction failed.");
            }
        }
    }
}