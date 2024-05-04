using System;

namespace FileCompressor {
    class Program {
        static void Main(string[] args) {
            try {
                Controller controller = new Controller();
                bool continueRunning = true;

                // Loop para permitir múltiplas operações sem reiniciar o programa.
                while (continueRunning) {
                    controller.Start();
                    
                    // Pergunta ao usuário se deseja realizar outra operação.
                    Console.WriteLine("Deseja realizar outra operação? (yes/no)");
                    string answer = Console.ReadLine().Trim().ToLower();
                    if (answer != "yes") {
                        continueRunning = false;
                    }
                }
            } catch (Exception e) {
                Console.WriteLine("Ocorreu um erro: " + e.Message);
            } finally {
                Console.WriteLine("Aplicação encerrada.");
            }
        }
    }
}
