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
        
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> Bus_Stop = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> Stop_Bus = new Dictionary<string, HashSet<string>>();

            //_fileName = @"C:\Users\nasur\Desktop\рпм.xlsx";

            //Excel.Application ObjWorkExcel = new Microsoft.Office.Interop.Excel.Application();
            //Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(_fileName);
            //Excel.Worksheet ObjWorkSheet = ObjWorkBook.Sheets[1]; //получить 1-й лист
            //var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку

            //Excel.Range forYach;

            //int lastColumn = (int)lastCell.Column;
            //int lastRow = (int)lastCell.Row;
            //string[,] bus_stop = new string[lastRow, lastColumn];
            //for (int j = 0; j < 2; j++)
            //{
            //    //по всем колонкам
            //    for (int i = 0; i < 161; i++)
            //    {
            //        // по всем строкам
            //        forYach = ObjWorkSheet.Cells[i + 1, j + 1] as Excel.Range;
            //        bus_stop[i, j] = forYach.Value2.ToString();
            //    }
            //}
            //foreach (var i in bus_stop)
            //{
            //    Console.WriteLine(i);
            //}


            //Excel.Worksheet ObjWorkSheet2 = ObjWorkBook.Sheets[2]; //получить 1-й лист
            //var lastCell2 = ObjWorkSheet2.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку

            //Excel.Range forYach2;

            //int lastColumn2 = (int)lastCell2.Column;
            //int lastRow2 = (int)lastCell2.Row;
            //string[,] stop_bus = new string[lastRow2, lastColumn2];
            //for (int j = 0; j < 2; j++)
            //{
            //    //по всем колонкам
            //    for (int i = 0; i < lastRow2; i++)
            //    {
            //        // по всем строкам
            //        forYach2 = ObjWorkSheet2.Cells[i + 1, j + 1] as Excel.Range;
            //        stop_bus[i, j] = forYach2.Value2.ToString();
            //    }
            //}

            //foreach (var i in stop_bus)
            //{
            //    Console.WriteLine(i);
            //}

            //List<Bus> buses = new List<Bus>();
            //buses = AddBus();
            //foreach(var i in buses)
            //{
            //    Console.WriteLine(i.id_bus);
            //}

            List<Stop> stops = new List<Stop>();
            stops = AddStop();
            foreach (var i in stops)
            {
                Console.Write($"{i.id_stop} {i.stopName}");
            }
        }

        static List<Stop> AddStop()
        {
            List<Stop> buses = new List<Stop>();
            _fileName = @"C:\Users\nasur\Desktop\КопияРпм.xlsx";

            Excel.Application ObjWorkExcel = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(_fileName);
            Excel.Worksheet ObjWorkSheet = ObjWorkBook.Sheets[4]; //получить 3-й лист
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку

            Excel.Range forYach;
            Excel.Range forYach2;
            int lastRow = (int)lastCell.Row;
            for (int i = 0; i < 621; i++)
            {
                forYach = ObjWorkSheet.Cells[i + 1, 1] as Excel.Range;
                forYach2 = ObjWorkSheet.Cells[i + 1, 2] as Excel.Range;
                Stop bus = new Stop()
                {
                    id_stop = Convert.ToInt32(forYach.Value2),
                    stopName = forYach2.Value2.ToString()
                };
                buses.Add(bus);
            }
            return buses;
        }

        static List<Bus> AddBus()
        {
            List<Bus> buses = new List<Bus>();
            _fileName = @"C:\Users\nasur\Desktop\КопияРпм.xlsx";

            Excel.Application ObjWorkExcel = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(_fileName);
            Excel.Worksheet ObjWorkSheet = ObjWorkBook.Sheets[3]; //получить 3-й лист
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку

            Excel.Range forYach;
            int lastRow = (int)lastCell.Row;

            for (int i = 0; i < lastRow; i++)
            {
                forYach = ObjWorkSheet.Cells[i + 1, 1] as Excel.Range;
                Bus bus = new Bus()
                {
                    id_bus = forYach.Value2.ToString()
                };
                buses.Add(bus);
            }
            
            return buses;
        }
    }
}
