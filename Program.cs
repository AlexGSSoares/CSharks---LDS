using System;
using SevenZip;

namespace SevenZipFrontend
{
    // Model
    public class ArchiveManager
    {
        public void CreateArchive(string archiveName, string[] filesToArchive)
        {
            // Logic to create an archive using SevenZipSharp API
            // This method would interact directly with SevenZipSharp API
            // Example:
            // SevenZipCompressor.SetLibraryPath("/usr/lib/p7zip/7z.so");
            SevenZipCompressor.SetLibraryPath("7z64.dll");
            var compressor = new SevenZipCompressor();
            compressor.CompressFiles(archiveName, filesToArchive);
            Console.WriteLine("Archive created successfully!");
        }

        public void ExtractArchive(string archiveName, string extractPath)
        {
            // Logic to extract an archive using SevenZipSharp API
            // This method would interact directly with SevenZipSharp API
            // Example:
            var extractor = new SevenZipExtractor(archiveName);
            extractor.ExtractArchive(extractPath);
            Console.WriteLine("Archive extracted successfully!");
        }
    }

    // View
    public class ConsoleView
    {
        public void DisplayMenu()
        {
            Console.WriteLine("1. Create Archive");
            Console.WriteLine("2. Extract Archive");
            Console.WriteLine("3. Exit");
        }

        public string GetUserInput(string message)
        {
            Console.Write(message + ": ");
            return Console.ReadLine();
        }
    }

    // Controller
    public class ArchiveController
    {
        private ArchiveManager archiveManager;
        private ConsoleView view;

        public ArchiveController()
        {
            archiveManager = new ArchiveManager();
            view = new ConsoleView();
        }

        public void ProcessUserInput()
        {
            while (true)
            {
                view.DisplayMenu();
                string choice = view.GetUserInput("Enter your choice");

                switch (choice)
                {
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

        private void CreateArchive()
        {
            string archiveName = view.GetUserInput("Enter the name of the archive");
            string files = view.GetUserInput("Enter the files to be archived (comma-separated)");
            string[] filesToArchive = files.Split(',');
            archiveManager.CreateArchive(archiveName, filesToArchive);
        }

        private void ExtractArchive()
        {
            string archiveName = view.GetUserInput("Enter the name of the archive to extract");
            string extractPath = view.GetUserInput("Enter the extraction path");
            archiveManager.ExtractArchive(archiveName, extractPath);
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            ArchiveController controller = new ArchiveController();
            controller.ProcessUserInput();
        }
    }
}