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
            this.stop_bus = bus.stop_bus;
        }

        public string StopsForBus(string bus)
        {
            if (bus_stop.ContainsKey(bus))
            {
                string s = String.Empty;
                foreach (var i in bus_stop[bus])
                {
                    string k = String.Empty;
                    foreach (var j in stop_bus[i])
                    {
                        if (stop_bus[i].Count == 1 && j == bus)
                            k = "no interchange";
                        else if (j == bus)
                            continue;
                        else
                            k = $"{k}{j} ";
                    }
                    s = $"{s}Stop {i}: {k}{Environment.NewLine}";
                }
                return s;
            }
                
            else
                return $"No bus{Environment.NewLine}";
        }
    }
}
