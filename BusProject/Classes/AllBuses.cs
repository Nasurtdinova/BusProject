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
            string line = String.Empty;
            List<string> str = new List<string>();
            foreach (var i in bus_stop)
            {
                foreach (var j in i.Value)
                {
                    line = $"{line} {j.ToString()}";
                }
                str.Add($"{i.Key}:{line}");
                line = String.Empty;
            }
            return str;
        }

        public override string ToString()
        {
            if (bus_stop.Count == 0)
            {
                return "No buses";
            }
            else
            {
                string s = String.Empty;
                foreach (var i in ALL_BUSES())
                {
                    s = $"{s}Bus {i}{Environment.NewLine}";
                }
                return s;
            }
        }
    }
}
