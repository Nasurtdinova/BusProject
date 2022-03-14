using System;
using System.Collections.Generic;
using System.Text;

namespace BusStopsProject
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
            var sorted = new SortedDictionary<string, HashSet<string>>(bus_stop);
            if (bus_stop.Count != 0)
            {
                foreach (var i in sorted)
                {
                    foreach (var j in i.Value)
                    {
                        line = $"{line} {j.ToString()}";
                    }
                    str.Add($"Bus {i.Key}:{line}");
                    line = String.Empty;
                }
            }
            else
                str.Add("No buses");

            return str;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, ALL_BUSES().ToArray());
        }
    }
}
