using System;
using System.Collections.Generic;
using System.Text;

namespace BusStopsProject
{
    public class Stop_Bus : Bus
    {
        public Stop_Bus(Bus bus)
        {
            this.bus_stop = bus.bus_stop;
            this.stop_bus = bus.stop_bus;
        }

        public int GetStopCount(string bus)
        {
            return bus_stop.ContainsKey(bus) ? bus_stop[bus].Count : 0;
        }

        public string StopsForBus(string bus)
        {
            if (bus_stop.ContainsKey(bus))
            {
                string s = String.Empty;
                foreach (var stops in bus_stop[bus])
                {
                    string k = String.Empty;
                    foreach (var buses in stop_bus[stops])
                    {
                        if (stop_bus[stops].Count == 1 && buses == bus)
                            k = "no interchange";
                        else if (buses == bus)
                            continue;
                        else
                            k = $"{k}{buses} ";
                    }
                    s = $"{s}Stop {stops}: {k}{Environment.NewLine}";
                }
                return s;
            }

            else
                return $"No bus{Environment.NewLine}";
        }
    }
}
