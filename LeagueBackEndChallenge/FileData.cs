﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeagueBackEndChallenge
{
    public class FileData
    {
        public string FilePath { protected set; get; }
        public int NumberOfColumns { protected set; get; }
        public int NumberOfRows { protected set; get; }
        public List<int> LineList { protected set; get; }
        public int[][] Rows { protected set; get; }

        public FileData(string filePath)
        {
            FilePath = filePath;
            NumberOfColumns = 0;
            NumberOfRows = 0;
            LineList = new List<int>();
        }

        public void IncrementRow() => NumberOfRows++;

        public void SetNumberOfColumns(int numberOfColumns)
        {
            NumberOfColumns = numberOfColumns;
        }

        public void StartRowData(int size)
        {
            Rows = new int[size][];
        }

        public void AddRowData(int position, int[] data)
        {
            Rows[position] = data;
            IncrementRow();
        }

        private void FillLineList()
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

        public string EchoRow()
        {
            var stringToPrint = new StringBuilder();
            for (int row = 0; row < Rows.Length; row++)
            {
                stringToPrint.Append(string.Join(",", Rows[row]) + "\n");
            }
            return stringToPrint.ToString();
        }

        public string EchoInvert()
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

        public string EchoFlatten()
        {
            if (!LineList.Any())
                FillLineList();

            var stringToPrint = new StringBuilder();
            return stringToPrint.Append(string.Join(",", LineList)).ToString();
        }

        public int EchoSum()
        {
            if (!LineList.Any())
                FillLineList();

            return LineList.Sum();
        }

        public double EchoMultiPly()
        {
            if (!LineList.Any())
                FillLineList();

            return LineList.Aggregate((a, x) => a * x);
        }
    }
}
