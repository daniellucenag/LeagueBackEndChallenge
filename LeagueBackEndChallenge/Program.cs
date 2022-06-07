using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                reader = new StreamReader(File.OpenRead(fileData.FilePath));

                IList<RowData> linesData = new List<RowData>();

                while (!reader.EndOfStream)
                {
                    var lineData = new RowData();
                    var lineString = reader.ReadLine();
                    var lineSplited = lineString.Split(',');
                    foreach (var item in lineSplited)
                    {
                        lineData.AddItem(int.Parse(item));
                    }
                    linesData.Add(lineData);
                }

                foreach (var dataToPrint in linesData)
                {
                    Console.WriteLine(dataToPrint.PrintRowData());
                }
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
        public List<RowData> Rows { protected set; get; }

        public FileData(string filePath)
        {
            FilePath = filePath;
            NumberOfColumns = 0;
            NumberOfRows = 0;
        }

        public void IncremmentRow() => NumberOfRows++;

        public void IncrementColumn() => NumberOfColumns++;

        public void AddRowData(RowData rowData)
        {
            Rows.Add(rowData);
        }
    }

    public class RowData
    {  
        public List<int> Items { protected set; get; }

        public RowData()
        {
            Items = new List<int>();
        }

        public string PrintRowData()
        {
            return string.Join(",", Items);
        }

        public void AddItem(int item)
        {
            this.Items.Add(item);
        }
    }

   
}
