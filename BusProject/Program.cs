using BusProject.Classes;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Linq;
using System.IO;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace BusProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> Bus_Stop = new Dictionary<string, string>();

            List <Bus> bus = addBus();

            for (int i = 0; i < bus.Count; i++)
            {
                Console.WriteLine(bus[i].id_bus);
            }
        }

        static List<Bus> addBus()
        {
            List<Bus> buses = new List<Bus>();

            


            return buses;
        }
    }
}
