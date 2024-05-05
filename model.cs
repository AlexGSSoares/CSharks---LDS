using System;
using SevenZip;

namespace SevenZipFrontend {
    // Model
    public class ArchiveManager {
        public void CreateArchive(string archiveName, string[] filesToArchive) {
            // Logic to create an archive using SevenZipSharp API
            // This method would interact directly with SevenZipSharp API
            // Example:
            SevenZipCompressor.SetLibraryPath("7z64.dll");
            var compressor = new SevenZipCompressor();
            compressor.CompressFiles(archiveName, filesToArchive);
            Console.WriteLine("Archive created successfully!");
        }

        public void ExtractArchive(string archiveName, string extractPath) {
            // Logic to extract an archive using SevenZipSharp API
            // This method would interact directly with SevenZipSharp API
            // Example:
            SevenZipCompressor.SetLibraryPath("7z64.dll");
            var extractor = new SevenZipExtractor(archiveName);
            extractor.ExtractArchive(extractPath);
            Console.WriteLine("Archive extracted successfully!");
        }
    }
}