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
    }
}
