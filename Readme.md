![image](https://github.com/AlexGSSoares/CSharks---LDS/assets/168682727/ad66d665-66a4-42a4-9ca2-e0d5f314e482)

      
      =========================================
      ## README - CSharks 7z Management Tool ##
      =========================================
Our tool that uses the 7z library to compress and decompress files, providing an efficient way to manage compressed files.

## INSTALLATION ##


-- Download Git --
- **Windows:** 

	Download Git via [official link](https://git-scm.com/download/win).

- **Linux (via PowerShell):**

  	apt install git
  	(* Type "y" when prompted.)

  
## CLONE REPOSITORY ##

To clone the programme on your computer, follow the steps below:

1. Make sure you are in a safe directory where you want to clone the repository. Use the `cd` command to navigate between folders and `mkdir` to create a new folder if necessary.

2. Clone the repository. Powershell commands:
   - git clone https://github.com/AlexGSSoares/CSharks---LDS
   - cd CSharks---LDS

## EXECUTION AND COMPILATION ##

After cloning the repository and navigating to the programme directory, build and run the programme using the following commands in PowerShell:

- dotnet build # Compile the programme
- dotnet run # Run the programme

## PROGRAMME FEATURES ##

**CSharks** has an interactive menu with three main options:

1. **Create Archive
   - Requests a name for the archive (must end with ".7z"). Example: CSharks.7z
   - Requests the files you want to compress, including their extensions.

2. **Extract Archive
   - Requests the name of the archive you want to extract (don't forget to include the extension). Example: CSharks.7z
   - Requests the path where the extracted file will be placed.

3. **Exit
   - Exits the programme.
