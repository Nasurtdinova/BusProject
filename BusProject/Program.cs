using BusProject.Classes;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Linq;
using System.IO;
using System.Data;
using ExcelDataReader;

namespace BusProject
{
    class Program
    {
        private static string _fileName = string.Empty;
        private static DataTableCollection tableCollection = null;
        
        static void Main(string[] args)
        {
            Dictionary<string, string> Bus_Stop = new Dictionary<string, string>();

            List <Bus> bus = addBus();
            

            _fileName = @"C:\Users\nasur\Downloads\2_5231411608390997991.xlsx";

            Excel.Application ObjWorkExcel = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(_fileName);
            Excel.Worksheet ObjWorkSheet = ObjWorkBook.Sheets[1]; //получить 1-й лист
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку

            Excel.Range forYach;

            int lastColumn = (int)lastCell.Column;
            int lastRow = (int)lastCell.Row;
            string[,] list = new string[lastRow+1, lastColumn+1];
            for (int j = 0; j < 2; j++)
            {
                //по всем колонкам
                for (int i = 0; i < lastRow; i++)
                {
                    // по всем строкам
                    forYach = ObjWorkSheet.Cells[i + 1, j + 1] as Excel.Range;
                    list[i, j] = forYach.Value2.ToString();
                    //Bus_Stop.Add(forYach.Value2.ToString(), forYach.Value2.ToString());
                }
            }
            foreach(var i in list)
            {
                Console.WriteLine(i);
            }
            
        }

        private static void OpenExcelFile(string FilePath)
        {
            FileStream stream = File.Open(FilePath, FileMode.Open, FileAccess.Read);

            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);

            DataSet db = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = false
                }
            }) ;

            tableCollection = db.Tables;
        }

        static List<Bus> addBus()
        {
            List<Bus> buses = new List<Bus>();
            return buses;
        }
    }
}
