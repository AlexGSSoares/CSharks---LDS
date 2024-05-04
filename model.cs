// Model.cs
using System;
using SevenZip;

namespace FileCompressor {
    class Model {
        public void Compress(string[] files, string destination, string format, string password) {
            SevenZipCompressor compressor = new SevenZipCompressor();
            compressor.ArchiveFormat = (OutArchiveFormat)Enum.Parse(typeof(OutArchiveFormat), format);
            compressor.CompressionMode = CompressionMode.Create;
            if (!string.IsNullOrEmpty(password)) {
                compressor.ZipEncryptionMethod = ZipEncryptionMethod.ZipCrypto;
                compressor.EncryptHeaders = true;
            }
            compressor.CompressFilesEncrypted(destination, password, files);
            // Suponha algum mecanismo para notificar o progresso aqui
        }

        public void Decompress(string[] files, string destination) {
            SevenZipExtractor extractor = new SevenZipExtractor(files[0]);
            extractor.ExtractArchive(destination);
            // Suponha algum mecanismo para notificar o progresso aqui
        }
    }
}