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

            string line;
            Bus bus = new Bus();
            while ((line = Console.ReadLine()) != null)
            {
                string[] command = line.Split();
                switch (command[0].ToUpper())
                {
                    case "NEW_BUS":
                        string[] mas = new string[Convert.ToInt32(command[2])];
                        for (int i = 0; i < command.Length - 3; i++)
                        {
                            mas[i] = command[3 + i];
                        }
                        bus.AddNewBus(command[1], Convert.ToInt32(command[2]), mas);
                        break;
                    case "BUSES_FOR_STOP":
                        Bus_Stop busStop = new Bus_Stop(bus);
                        Console.WriteLine(busStop.Message(command[1]));
                        break;
                    case "STOPS_FOR_BUS":
                        Stop_Bus stopBus = new Stop_Bus(bus);
                        Console.WriteLine(stopBus.Message(command[1]));
                        break;
                    case "ALL_BUSES":
                        foreach (var i in bus.ALL_BUSES())
                        {
                            Console.WriteLine(i);
                        }
                        break;
                }
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
                    NameBus = forYach.Value2.ToString()
                };
                buses.Add(bus);
            }           
            return buses;
        }
    }
}
