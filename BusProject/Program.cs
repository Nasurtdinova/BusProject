using BusProject.Classes;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Linq;
using System.IO;
using System.Data;
using Microsoft.Office.Interop.Excel;

using ExcelDataReader;

namespace BusProject
{
    
    class Program
    {
        private static string _fileName = string.Empty;

        private static DataTableCollection tableCollection = null;

        static string[,] list = new string[50, 5];
        static void Main(string[] args)
        {
            Dictionary<string, string> Bus_Stop = new Dictionary<string, string>();

            List <Bus> bus = addBus();

            try
            {
                _fileName = @"C:\Users\secon\Desktop\Bus.xlsx";

                OpenExcelFile(_fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //for (int i = 0; i < bus.Count; i++)
            //{
            //    Console.WriteLine(bus[i].id_bus);
            //}
            
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
