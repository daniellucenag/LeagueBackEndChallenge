using System;

namespace LeagueBackEndChallenge
{
    internal class Program
    {
       
        public static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine(string.IsNullOrEmpty(FileService.FilePath) ? "1) Load your file" : $"1) - FILE LOADED - {FileService.FilePath} press 1 to load other file");
            Console.WriteLine("2) EchoRow");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    LoadFile();
                    return true;
                case "2":
                    EchoRow();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        public static void LoadFile()
        {
            Console.Clear();
            Console.WriteLine("LoadFile");

            try
            {
                FileService.LoadFile(CaptureInput());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }            
        }

        private static string CaptureInput()
        {
            Console.Write("Enter the entire filepath of your file ex: 'C://Users/YourName/Downloads/file.csv': ");
            return Console.ReadLine();
        }

        private static void EchoRow()
        {
            if (ValidateFile())
            {
                Console.WriteLine("EchoRow return the matrix as string in matrix format: ");
                Console.WriteLine(FileService.GetRow());
                Console.ReadLine();
            }
        }

        private static bool ValidateFile()
        {
            if (string.IsNullOrEmpty(FileService.FilePath))
            {
                Console.WriteLine("You must load a file before. Press enter to return to main menu.");
                Console.ReadLine();
                return false;
            }
            return true;
        }
    }
}
