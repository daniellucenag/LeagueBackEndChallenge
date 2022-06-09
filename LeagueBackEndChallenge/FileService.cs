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

        /// <summary>
        /// load the file 
        /// </summary>
        /// <param name="path">the path of the file</param>
        /// <exception cref="Exception">basic exception handle</exception>
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

        /// <summary>
        /// matrix in string format as given
        /// </summary>
        /// <returns>string</returns>
        public static string GetRow()
        {
            var stringToPrint = new StringBuilder();
            for (int row = 0; row < Rows.Length; row++)
            {
                stringToPrint.Append(string.Join(",", Rows[row]) + "\n");
            }
            return stringToPrint.ToString();
        }

        /// <summary>
        /// return columns and rows of the matrix inverted
        /// </summary>
        /// <returns>string</returns>
        public static string GetInvert()
        {
            string[] elementsForPrint = new string[NumberOfRows];
            int[] lineArray;

            for (int row = 0; row < NumberOfRows; row++)
            {
                lineArray = new int[NumberOfColumns];
                for (int column = 0; column < NumberOfColumns; column++)
                {
                    lineArray[column] = Rows[column][row];
                }
                elementsForPrint[row] = string.Join(",", lineArray);
            }

            var stringToPrint = new StringBuilder();
            for (int row = 0; row < elementsForPrint.Length; row++)
            {
                stringToPrint.Append(string.Join(",", elementsForPrint[row]) + "\n");

            }
            return stringToPrint.ToString();
        }

        /// <summary>
        /// return the matrix as 1 line
        /// </summary>
        /// <returns>string</returns>
        public static string GetFlatten()
        {
            if (!LineList.Any())
                FillLineList();

            var stringToPrint = new StringBuilder();
            return stringToPrint.Append(string.Join(",", LineList)).ToString();
        }

        /// <summary>
        /// get the product of all elements of the matrix
        /// </summary>
        /// <returns>double</returns>
        public static double GetMultiply()
        {
            if (!LineList.Any())
                FillLineList();

            return LineList.Aggregate((a, x) => a * x);
        }

        /// <summary>
        /// sum all elements of the matrix
        /// </summary>
        /// <returns>double</returns>
        public static double GetSum()
        {
            if (!LineList.Any())
                FillLineList();

            return LineList.Sum();
        }

        /// <summary>
        /// Fill the LineList with all numbers of the matrix
        /// </summary>
        private static void FillLineList()
        {
            LineList = new List<int>();
            for (int row = 0; row < Rows.Length; row++)
            {
                for (int i = 0; i < Rows[row].Length; i++)
                {
                    LineList.Add(Rows[row][i]);
                }
            }
        }
    }
}