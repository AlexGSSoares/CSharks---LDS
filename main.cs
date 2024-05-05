using System;

namespace SevenZipFrontend {
    class Program {
        static void Main(string[] args) {
            ArchiveController controller = new ArchiveController();
            controller.ProcessUserInput();
        }
    }
}