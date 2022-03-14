using System;
using System.Collections.Generic;
using System.Text;

namespace BusStopsProject
{
    public class Stop_Bus : Bus
    {
        private string NameBus { get; set; }

        public Stop_Bus(Bus bus,string nameBus)
        {
            this.bus_stop = bus.bus_stop;
            this.stop_bus = bus.stop_bus;
            NameBus = nameBus;
        }

        public List<string> StopsForBus()
        {
            List<string> result = new List<string>();

            if (bus_stop.ContainsKey(NameBus))
            {
                string s = String.Empty;
                foreach (var stops in bus_stop[NameBus])
                {
                    string k = String.Empty;
                    foreach (var buses in stop_bus[stops])
                    {
                        if (stop_bus[stops].Count == 1 && buses == NameBus)
                            k = "no interchange";
                        else if (buses == NameBus)
                            continue;
                        else
                            k = $"{k}{buses} ";
                    }
                    s = $"Stop {stops}: {k}";
                    result.Add(s);
                }
            }
            else
                result.Add("No bus");

            return result;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, StopsForBus().ToArray());
        }
    }
}
