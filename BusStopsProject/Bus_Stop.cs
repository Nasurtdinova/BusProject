using System;
using System.Collections.Generic;
using System.Text;

namespace BusStopsProject
{
    public class Bus_Stop : Bus
    {
        private string Stop { get; set; }

        public Bus_Stop(Bus bus, string stop)
        {
            this.stop_bus = bus.stop_bus;
            Stop = stop;
        }

        public List<string> BusesForStop(string stop)
        {
            List<string> buses = new List<string>();
            if (stop_bus.ContainsKey(Stop))
                foreach (var i in stop_bus[stop])
                    buses.Add(i);
            else
                buses.Add("No stop");

            return buses;                       
        }

        public override string ToString()
        {
            return string.Join(" ", BusesForStop(Stop).ToArray());
        }
    }
}
