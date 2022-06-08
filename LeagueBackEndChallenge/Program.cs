using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeagueBackEndChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileData = new FileData(@"C:\Users\Daniel\Downloads\matrix.csv");

            StreamReader reader = null;
            if (File.Exists(fileData.FilePath))
            {
                string[] rows = File.ReadAllLines(fileData.FilePath);
                fileData.StartRowData(rows.Length);
               // int[][] jaggedArray = new int[rows.Length][];

                for (int i = 0; i < rows.Length; i++)
                {


                    string[] strArray = rows[i].Split(',');
                    fileData.SetNumberOfColumns(strArray.Length);
                    int[] intArray = Array.ConvertAll(strArray, int.Parse);
                    fileData.AddRowData(i,intArray);
                    //jaggedArray[i] = intArray;

                    /*
                    var lineData = new RowData();
                    var lineString = reader.ReadLine();
                    var lineSplited = lineString.Split(',');
                    fileData.SetNumberOfColumns(lineSplited.Length);
                    foreach (var item in lineSplited)
                    {
                        lineData.AddItem(int.Parse(item));
                    }
                    fileData.AddRowData(lineData);
                    */
                }
                //string result = string.Join(", ", jaggedArray[0]);
                //Console.WriteLine(result);//0,1,2,3
                Console.WriteLine(fileData.EchoRow());
                Console.WriteLine(fileData.EchoInvert());
            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }
            Console.ReadLine();
        }
    }

    class FileData
    {
        public string FilePath { protected set; get; }
        public int NumberOfColumns { protected set; get; }
        public int NumberOfRows { protected set; get; }
        public int[][] Rows { protected set; get; }

        public FileData(string filePath)
        {
            FilePath = filePath;
            NumberOfColumns = 0;
            NumberOfRows = 0;
            //Rows = new List<RowData>();
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

        public string EchoRow()
        {
            var stringToPrint = new StringBuilder();
            for (int row = 0; row < Rows.Length; row++)
            {
                stringToPrint.Append(string.Join(",", Rows[row])+"\n");
            }
            return stringToPrint.ToString();
        }

        public string EchoInvert()
        {
            string[] elementsForPrint = new string[NumberOfRows];
            int[] arrayTest;

            for (int row = 0; row <  NumberOfRows; row++)
            {
                arrayTest = new int[NumberOfColumns];
                for(int column = 0; column < NumberOfColumns; column++)
                {
                    arrayTest[column] = Rows[column][row];
                }
                elementsForPrint[row] = string.Join(",", arrayTest);
            }

            var stringToPrint = new StringBuilder();
            for (int row = 0; row < elementsForPrint.Length; row++)
            {
                stringToPrint.Append(string.Join(",", elementsForPrint[row]) + "\n");

            }
            return stringToPrint.ToString();
        }
    }  
}
