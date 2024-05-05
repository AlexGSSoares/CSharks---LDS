using System;

namespace SevenZipFrontend {
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
            string archiveName = view.GetUserInput("Enter the name of the archive");
            string files = view.GetUserInput("Enter the files to be archived (comma-separated)");
            string[] filesToArchive = files.Split(',');
            if (archiveManager.CreateArchive(archiveName, filesToArchive)) {
                view.ShowMessage("Archive created successfully!");
            } else {
                view.ShowMessage("Failed to create archive. Archive may already exist.");
            }
        }

        private void ExtractArchive() {
            string archiveName = view.GetUserInput("Enter the name of the archive to extract");
            string extractPath = view.GetUserInput("Enter the extraction path");
            if (archiveManager.ExtractArchive(archiveName, extractPath)) {
                view.ShowMessage("Archive extracted successfully!");
            } else {
                view.ShowMessage("Failed to extract archive. Archive may not exist or extraction failed.");
            }
        }
    }
}