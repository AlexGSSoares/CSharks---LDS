// Controller.cs
using System;

namespace FileCompressor {
    class Controller {
        private Model model;
        private View view;

        public Controller() {
            model = new Model();
            view = new View(this);
            view.Display();
        }

        public void StartProcess(string operation, string[] files, string destination, string format = null, string password = null) {
            if (operation == "compress") {
                model.Compress(files, destination, format, password);
            } else if (operation == "decompress") {
                model.Decompress(files, destination);
            }
        }

        public void UpdateProgress(int progress) {
            view.ShowProgress(progress);
        }

        public void FinishProcess() {
            view.ShowCompletionMessage();
            view.Display();
        }
    }
}