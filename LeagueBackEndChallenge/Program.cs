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
            Console.WriteLine("3) EchoInvert");
            Console.WriteLine("4) EchoFlatten");
            Console.WriteLine("5) Sum");
            Console.WriteLine("6) Multiply");
            Console.WriteLine("7) Exit");
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
                    EchoInvert();
                    return true;
                case "4":
                    EchoFlatten();
                    return true;
                case "5":
                    EchoSum();
                    return true;
                case "6":
                    EchoMultiply();
                    return true;
                case "7":
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
                PressEnterMessage();
                Console.ReadLine();
            }
        }

        private static void EchoInvert()
        {
            if (ValidateFile())
            {
                Console.WriteLine("EchoInvert Return the matrix as a string in matrix format where the columns and rows are inverted: ");
                Console.WriteLine(FileService.GetInvert());
                PressEnterMessage();
                Console.ReadLine();
            }
        }

        private static void EchoFlatten()
        {
            if (ValidateFile())
            {
                Console.WriteLine("EchoFlatten Return the matrix as a 1 line string, with values separated by commas: ");
                Console.WriteLine(FileService.GetFlatten());
                PressEnterMessage();
                Console.ReadLine();
            }
        }

        private static void EchoSum()
        {
            if (ValidateFile())
            {
                Console.WriteLine("EchoSum Return the sum of the integers in the matrix: ");
                Console.WriteLine(FileService.GetSum());
                PressEnterMessage();
                Console.ReadLine();
            }
        }

        private static void EchoMultiply()
        {
            if (ValidateFile())
            {
                Console.WriteLine("EchoMultiply Return the product of the integers in the matrix: ");
                Console.WriteLine(FileService.GetFlatten());
                PressEnterMessage();
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

        private static void PressEnterMessage()
        {
            Console.WriteLine("Press enter to return mainmenu.");
        }
    }
}
