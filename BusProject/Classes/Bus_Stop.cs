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

        private HashSet<string> BusesForStop(string stop)
        {
            if (stop_bus.ContainsKey(stop))
                return stop_bus[stop];
            else
                throw new Exception("No stop");
        }

        public string PrintBusesForStop(string stop)
        {
            string s = String.Empty;
            foreach (var i in BusesForStop(stop))
            {
                s = $"{s}{i} ";
            }
            return s;
        }
    }
}
