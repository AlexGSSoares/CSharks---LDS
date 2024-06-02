<<<<<<< HEAD
using System;
using System.IO;
using SevenZip;

namespace SevenZipFrontend {
    // Model
    public class ArchiveManager {
        public bool CreateArchive(string archiveName, string[] filesToArchive) {
            try {
                if (File.Exists(archiveName)) {
                    return false; // Indicate that the archive already exists
                }
                // Logic to create an archive using SevenZipSharp API
                // This method would interact directly with SevenZipSharp API
                // Example:
                SevenZipCompressor.SetLibraryPath("7z64.dll");
                var compressor = new SevenZipCompressor();
                compressor.CompressFiles(archiveName, filesToArchive);
                return true; // Indicate that the archive was created successfully
            } catch {
                return false; // Indicate that the archive creation failed
            }
        }

        public bool ExtractArchive(string archiveName, string extractPath) {
            try {
                // Logic to extract an archive using SevenZipSharp API
                // This method would interact directly with SevenZipSharp API
                // Example:
                SevenZipCompressor.SetLibraryPath("7z64.dll");
                var extractor = new SevenZipExtractor(archiveName);
                extractor.ExtractArchive(extractPath);
                return true; // Indicate that the archive was extracted successfully
            } catch {
                return false; // Indicate that the archive extraction failed
            }
        }
    }
=======
using SevenZip;

namespace SevenZipFrontend{
    // Model
    public class ArchiveManager {
        public bool CreateArchive(string archiveName, string[] filesToArchive) {
            try {
                // Check if the archive already exists
                if (File.Exists(archiveName)) {
                    return false; // Indicate that the archive already exists
                }
                // Logic to create an archive using SevenZipSharp API
                // This method would interact directly with SevenZipSharp API
                // Example:
                SevenZipCompressor.SetLibraryPath("7z64.dll");
                var compressor = new SevenZipCompressor();
                compressor.CompressFiles(archiveName, filesToArchive);
                return true; // Indicate that the archive was created successfully
            } catch {
                return false; // Indicate that the archive creation failed
            }
        }

        public bool ExtractArchive(string archiveName, string extractPath) {
            try {
                // Logic to extract an archive using SevenZipSharp API
                // This method would interact directly with SevenZipSharp API
                // Example:
                SevenZipCompressor.SetLibraryPath("7z64.dll");
                var extractor = new SevenZipExtractor(archiveName);
                extractor.ExtractArchive(extractPath);
                return true; // Indicate that the archive was extracted successfully
            } catch {
                return false; // Indicate that the archive extraction failed
            }
        }
    }
>>>>>>> origin/master
}