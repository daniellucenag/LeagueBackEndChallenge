using System;
using System.Collections.Generic;
using System.IO;

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
            //var fileData = new FileData(@"C:\Users\Daniel\Downloads\matrix.csv");

            if (!File.Exists(path))
                throw new Exception("File doesn't exist");
                        
            try
            {
                SetFilePath(path);
                string[] rows = File.ReadAllLines(FilePath);
                StartRowData(rows.Length);

                for (int i = 0; i < rows.Length; i++)
                {
                    string[] strArray = rows[i].Split(',');
                    SetNumberOfColumns(strArray.Length);
                    int[] intArray = Array.ConvertAll(strArray, int.Parse);
                    AddRowData(i, intArray);
                }

                if (!ValidFile)
                    throw new Exception("File is not valid, must be a csv with same number of columns and rows.");                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private static void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }
        public static void StartRowData(int size)
        {
            Rows = new int[size][];
        }
        private static void SetNumberOfColumns(int numberOfColumns)
        {
            NumberOfColumns = numberOfColumns;
        }
        public static void AddRowData(int position, int[] data)
        {
            Rows[position] = data;
            IncrementRow();
        }

        private static void IncrementRow() => NumberOfRows++;

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

        public static string GetRow()
        {
            throw new NotImplementedException();
        }

        public static string GetSum()
        {
            throw new NotImplementedException();
        }

               
    }
}
