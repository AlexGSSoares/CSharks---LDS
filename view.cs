namespace SevenZipFrontend{
    // View
    public class ConsoleView {
        public void DisplayMenu() {
            Console.WriteLine("1. Create Archive");
            Console.WriteLine("2. Extract Archive");
            Console.WriteLine("3. Exit");
        }

        public string GetUserInput(string message) {
            Console.Write(message + ": ");
            try {
                string input = Console.ReadLine();
                if (input == null) {
                    return ""; // Return an empty string if input is null
                }
                return input;
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred while reading input: {ex.Message}");
                return ""; // Return an empty string in case of an exception
            }
        }
        public void ShowMessage(string message) {
            Console.WriteLine(message);
        }
    }
}