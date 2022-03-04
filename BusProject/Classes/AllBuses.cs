using System;
using System.Collections.Generic;
using System.Text;

namespace BusProject.Classes
{
    public class AllBuses : Bus
    {
        public AllBuses(Bus bus)
        {
            this.bus_stop = bus.bus_stop;
        }

        public List<string> ALL_BUSES()
        {
            List<string> str = new List<string>();
            string line = "";
            foreach (var i in bus_stop)
            {
                foreach (var j in bus_stop.Values)
                {
                    line = line + " " + j.ToString();
                }
                str.Add($"{i.Key} {line}");
                line = " ";
            }
            return str;
        }
    }
}
