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
                        bus.AddNewBus(command);
                        break;
                    case "BUSES_FOR_STOP":
                        Bus_Stop busStop = new Bus_Stop(bus);
                        Console.WriteLine(busStop.BusesForStop(command[1]));
                        break;
                    case "STOPS_FOR_BUS":
                        Stop_Bus stopBus = new Stop_Bus(bus);
                        Console.Write(stopBus.StopsForBus(command[1]));
                        break;
                    case "ALL_BUSES":
                        AllBuses allBuses = new AllBuses(bus);
                        Console.Write(allBuses.ToString());
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
