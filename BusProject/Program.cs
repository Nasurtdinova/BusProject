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

            _fileName = @"C:\Users\nasur\Desktop\КопияРпм.xlsx";

            Excel.Application ObjWorkExcel = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(_fileName);
            Excel.Worksheet ObjWorkSheet = ObjWorkBook.Sheets[1]; //получить 1-й лист
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку
            
            Excel.Range forYach;
            Excel.Range forYach2;

            int lastRow = (int)lastCell.Row;
            for (int i = 0; i < 161; i++)
            {
                HashSet<string> stop = new HashSet<string>();
                forYach = ObjWorkSheet.Cells[i + 1, 1] as Excel.Range;
                forYach2 = ObjWorkSheet.Cells[i + 1, 2] as Excel.Range;
                if (Bus_Stop.ContainsKey(forYach.Value2.ToString()))
                {
                    Bus_Stop[forYach.Value2.ToString()].Add(forYach2.Value2.ToString());
                }
                else
                {
                    stop.Add(forYach2.Value2.ToString());
                    Bus_Stop.Add(forYach.Value2.ToString(), stop);
                }               
            }
            foreach (var i in Bus_Stop)
            {
                Console.WriteLine(i.Key);
            }

            //Excel.Worksheet ObjWorkSheet2 = ObjWorkBook.Sheets[2]; //получить 2-й лист
            //for (int i = 0; i < 400; i++)
            //{
            //    HashSet<string> bus = new HashSet<string>();
            //    forYach = ObjWorkSheet2.Cells[i + 1, 1] as Excel.Range;
            //    forYach2 = ObjWorkSheet2.Cells[i + 1, 2] as Excel.Range;
            //    if (Stop_Bus.ContainsKey(forYach.Value2.ToString()))
            //    {
            //        Stop_Bus[forYach.Value2.ToString()].Add(forYach2.Value2.ToString());
            //    }
            //    else
            //    {
            //        bus.Add(forYach2.Value2.ToString());
            //        Stop_Bus.Add(forYach.Value2.ToString(), bus);
            //    }                
            //}
            //foreach (var i in Stop_Bus)
            //{
            //    Console.WriteLine(i.Key);
            //}
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
