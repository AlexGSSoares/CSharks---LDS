// View.cs
using System;

namespace FileCompressor {
    class View {
        private Controller controller;

        public View(Controller controller) {
            this.controller = controller;
        }

        public void Display() {
            Console.WriteLine("Select 'compress' or 'decompress'");
            string operation = Console.ReadLine();
            Console.WriteLine("Enter files path separated by ';'");
            string[] files = Console.ReadLine().Split(';');
            Console.WriteLine("Enter destination path");
            string destination = Console.ReadLine();
            string format = null, password = null;
            if (operation == "compress") {
                Console.WriteLine("Enter format (zip, 7z, etc.)");
                format = Console.ReadLine();
                Console.WriteLine("Enter password (optional)");
                password = Console.ReadLine();
            }
            controller.StartProcess(operation, files, destination, format, password);
        }

        public void ShowProgress(int progress) {
            Console.WriteLine($"Progress: {progress}%");
        }

        public void ShowCompletionMessage() {
            Console.WriteLine("Operation completed successfully!");
        }
    }
}