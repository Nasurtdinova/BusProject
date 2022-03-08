using System;
using System.Collections.Generic;
using System.Text;

namespace BusProject.Classes
{
    public class Bus_Stop : Bus
    {
        public Bus_Stop(Bus bus) 
        {
            this.stop_bus = bus.stop_bus;
        }

        public int GetBusCount(string stop)
        {
            return stop_bus.ContainsKey(stop) ? stop_bus[stop].Count : 0;
        }

        public string BusesForStop(string stop)
        {
            string s = String.Empty;
            if (stop_bus.ContainsKey(stop))
            {
                foreach (var i in stop_bus[stop])
                {
                    s = $"{s}{i} ";
                }
                return s;
            }
            else
                return "No stop";
        }
    }
}
