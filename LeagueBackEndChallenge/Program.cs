using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

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
            Console.WriteLine("1) Load your file");
            Console.WriteLine("2) EchoRow");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    LoadFile();
                    return true;
                case "2":
                    //RemoveWhitespace();
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
            Console.Write("LoadFile");

            try
            {
                FileService.LoadFile(CaptureInput());
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }

        private static string CaptureInput()
        {
            Console.Write("Enter the entire filepath of your file ex: 'C://Users/YourName/Downloads/file.csv': ");
            return Console.ReadLine();
        }
    }
}
