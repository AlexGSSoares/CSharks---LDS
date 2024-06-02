using System;
using System.IO;
using SevenZip;

namespace SevenZipFrontend {
    // Model
    public class ArchiveManager {
        public class PasswordProtectedException : Exception {
            public PasswordProtectedException(string message) : base(message) { }
        }

        public bool CreateArchive(string archiveName, string[] filesToArchive, OutArchiveFormat format, CompressionLevel compressionLevel, string password = null) {
            try {
                if (File.Exists(archiveName)) {
                    return false; // Indicate that the archive already exists
                }
                // Logic to create an archive using SevenZipSharp API
                // This method would interact directly with SevenZipSharp API
                // Example:
                SevenZipCompressor.SetLibraryPath("7z64.dll");
                var compressor = new SevenZipCompressor();
                compressor.ArchiveFormat = format;
                compressor.CompressionLevel = compressionLevel;
                if (!string.IsNullOrEmpty(password)) {
                    compressor.EncryptHeaders = true;
                    compressor.ZipEncryptionMethod = ZipEncryptionMethod.Aes256;
                    compressor.CompressFilesEncrypted(archiveName, password, filesToArchive);
                }else{
                    compressor.CompressFiles(archiveName, filesToArchive);
                }
                return true; // Indicate that the archive was created successfully
            } catch {
                return false; // Indicate that the archive creation failed
            }
        }

        public bool ExtractArchive(string archiveName, string extractPath, string password = null) {
            try {
                // Logic to extract an archive using SevenZipSharp API
                // This method would interact directly with SevenZipSharp API
                // Example:
                SevenZipCompressor.SetLibraryPath("7z64.dll");
                var extractor = new SevenZipExtractor(archiveName, password);
                extractor.ExtractArchive(extractPath);
                return true; // Indicate that the archive was extracted successfully
            } catch (SevenZip.SevenZipException ex) {
                if (ex.Message.Contains("password")) {
                    throw new PasswordProtectedException("Archive is password protected.");
                }
                return false; // Indicate that the archive extraction failed
            } catch {
                return false; // Indicate that the archive extraction failed
            }
        }
    }
}