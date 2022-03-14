using System;

namespace BusStopsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            Bus bus = new Bus();
            while ((line = Console.ReadLine()) != null)
            {
                string[] command = line.Split();
                switch (command[0].ToUpper())
                {
                    case "NEW_BUS":
                        string nameBus = command[1];
                        int stopCount = Convert.ToInt32(command[2]);
                        string[] stops = new string[Convert.ToInt32(command[2])];
                        for (int i = 0; i < command.Length - 3; i++)
                        {
                            stops[i] = command[3 + i];
                        }
                        bus.AddNewBus(nameBus,stopCount,stops);
                        break;

                    case "BUSES_FOR_STOP":
                        Bus_Stop busStop = new Bus_Stop(bus,command[1]);
                        Console.WriteLine(busStop.ToString());
                        break;

                    case "STOPS_FOR_BUS":
                        Stop_Bus stopBus = new Stop_Bus(bus, command[1]);
                        Console.WriteLine(stopBus.ToString());
                        break;

                    case "ALL_BUSES":
                        AllBuses allBuses = new AllBuses(bus);
                        Console.WriteLine(allBuses.ToString());
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
