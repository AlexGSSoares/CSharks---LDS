using System;
using System.Threading;
using System.Windows.Forms;
using SevenZip;

namespace SevenZipFrontend {
    // Controller
    public class ArchiveController {
        private ArchiveManager archiveManager;
        private IConsoleView view;

        public ArchiveController(ArchiveManager manager, IConsoleView view) {
            this.archiveManager = manager;
            this.view = view;
        }

        public void CreateArchive() {
            var (archiveName, format) = view.GetArchiveName();
            if (archiveName == null) {
                // User cancelled, return without creating archive
                return;
            }
            CompressionLevel compressionLevel = view.GetCompressionLevel();

            string[] filesToArchive = view.GetFilesToArchive();
            if (filesToArchive == null || filesToArchive.Length == 0) {
                // User cancelled, return without creating archive
                return;
            }

            string password = null;
            if (view.IsPasswordProtected()) {
                password = view.GetPassword();
                if (password == null) {
                    // User cancelled, return without creating archive
                    return;
                }
            }

            if (archiveManager.CreateArchive(archiveName, filesToArchive, format, compressionLevel, password)) {
                view.ShowMessage("Archive created successfully!");
            } else {
                view.ShowMessage("Failed to create archive. Archive may already exist.");
            }
        }

        public void ExtractArchive() {
            string archiveName = view.GetArchiveToExtract();
            if (archiveName == null) {
                // User cancelled, return without extracting archive
                return;
            }

            string extractPath = view.GetExtractPath();
            if (extractPath == null) {
                // User cancelled, return without extracting archive
                return;
            }

            try {
                if (archiveManager.ExtractArchive(archiveName, extractPath)) {
                    view.ShowMessage("Archive extracted successfully!");
                } else {
                    view.ShowMessage("Failed to extract archive. Archive may not exist or extraction failed.");
                }
            } catch (ArchiveManager.PasswordProtectedException) {
                string password = view.GetPassword();
                if (password == null) {
                    // User cancelled, return without extracting archive
                    return;
                }
                if (archiveManager.ExtractArchive(archiveName, extractPath, password)) {
                    view.ShowMessage("Archive extracted successfully!");
                } else {
                    view.ShowMessage("Failed to extract archive. Password may be incorrect or extraction failed.");
                }
            }
        }
    }
}