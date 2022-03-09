using System;
using System.Collections.Generic;
using System.Text;

namespace BusProject
{
    public class Bus
    {
        public Dictionary<string, HashSet<string>> bus_stop;
        public Dictionary<string, HashSet<string>> stop_bus;

        public Bus()
        {
            bus_stop = new Dictionary<string, HashSet<string>>();
            stop_bus = new Dictionary<string, HashSet<string>>();
        }

        public bool AreBusStops(string bus, string stop)
        {
            return bus_stop.ContainsKey(bus) ? bus_stop[bus].Contains(stop) : false;
        }

        public bool AreStopBusses(string stop, string bus)
        {
            return stop_bus.ContainsKey(stop) ? stop_bus[stop].Contains(bus) : false;
        }

        public void AddNewBus(string[] command)
        {
            string nameBus = command[1];
            int stopCount = Convert.ToInt32(command[2]);
            string[] stops = new string[Convert.ToInt32(command[2])];

            for (int i = 0; i < command.Length - 3; i++)
            {
                stops[i] = command[3 + i];
            }

            if (stopCount != stops.Length || stopCount == 0 || bus_stop.ContainsKey(nameBus))
            {
                Console.WriteLine("Unable to add");
            }

            else
            {
                HashSet<string> stop = new HashSet<string>();
                foreach (var i in stops)
                {
                    stop.Add(i);
                    if (stop_bus.ContainsKey(i))
                        stop_bus[i].Add(nameBus);
                    else
                        stop_bus.Add(i, new HashSet<string> { nameBus });
                }
                bus_stop.Add(nameBus, stop);
            }
        }
    }
}
