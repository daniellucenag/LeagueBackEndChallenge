using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeagueBackEndChallenge
{
    public static class FileService
    {
        public static string FilePath { get; private set; }
        public static int NumberOfColumns { get; private set; }
        public static int NumberOfRows { get; private set; }
        public static List<int> LineList { get; private set; }
        public static int[][] Rows { get; private set; }
        public static bool ValidFile => NumberOfColumns == NumberOfRows;

        static FileService()
        {
            NumberOfColumns = 0;
            NumberOfRows = 0;
            LineList = new List<int>();
        }

        public static void LoadFile(string path)
        {
            //TODO: Remove this line
            //var fileData = new FileData(@"C:\Users\Daniel\Downloads\matrix.csv");

            if (!File.Exists(path))
                throw new Exception("File doesn't exist, press enter to return to main menu.");
                        
            try
            {
                SetFilePath(path);
                string[] rows = File.ReadAllLines(FilePath);
                StartRowData(rows.Length);

                for (int i = 0; i < rows.Length; i++)
                {
                    string[] strArray = rows[i].Split(',');

                    var stringline = rows[i];

                    if (!stringline.Replace(",","").All(char.IsDigit))
                        throw new Exception("Not all elements of the file are numbers, must be csv with only numbers.");
                                        
                    int[] intArray = Array.ConvertAll(strArray, int.Parse);
                    AddRowData(i, intArray);

                    SetNumberOfColumns(strArray.Length);
                    SetNumberOfRows(rows.Length);
                }

                if (!ValidFile)
                    throw new Exception("File is not valid, must be a csv with same number of columns and rows.");                
            }
            catch (Exception)
            {
                ClearFilePath();
                throw;
            }
        }
        private static void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }

        private static void ClearFilePath()
        {
            FilePath = null;
        }
        public static void StartRowData(int size)
        {
            Rows = new int[size][];
        }
        private static void SetNumberOfColumns(int numberOfColumns)
        {
            NumberOfColumns = numberOfColumns;
        }

        private static void SetNumberOfRows(int numberOfRows)
        {
            NumberOfRows = numberOfRows;
        }

        public static void AddRowData(int position, int[] data)
        {
            Rows[position] = data;            
        }

        public static string GetRow()
        {
            var stringToPrint = new StringBuilder();
            for (int row = 0; row < Rows.Length; row++)
            {
                stringToPrint.Append(string.Join(",", Rows[row]) + "\n");
            }
            return stringToPrint.ToString();
        }
        public static string GetFlatten()
        {
            throw new NotImplementedException();
        }

        public static string GetInvert()
        {
            throw new NotImplementedException();
        }

        public static string GetMultiply()
        {
            throw new NotImplementedException();
        }

        public static string GetSum()
        {
            throw new NotImplementedException();
        }
    }
}