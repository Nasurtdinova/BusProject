using System;
using System.Collections.Generic;
using System.Text;

namespace BusProject.Classes
{
    public class Stop_Bus : Bus
    {
        public Stop_Bus(Bus bus)
        {
            this.bus_stop = bus.bus_stop;
        }

        public HashSet<string> StopsForBus(string bus)
        {
            if (bus_stop.ContainsKey(bus))
                return bus_stop[bus];
            else
                throw new Exception("No bus");
        }

        public string PrintStopsForBus(string bus)
        {
            string s = "";
            foreach (var i in StopsForBus(bus))
            {
                s = $"{s} {i}";
            }
            return s;
        }
    }
}
