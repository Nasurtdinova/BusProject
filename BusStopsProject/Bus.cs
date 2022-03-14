using System;
using System.Collections.Generic;
using System.Text;

namespace BusStopsProject
{ 
    using DictOfSet = Dictionary<string, HashSet<string>>;
    public class Bus
    {
        public DictOfSet bus_stop;
        public DictOfSet stop_bus;

        public Bus()
        {
            bus_stop = new DictOfSet();
            stop_bus = new DictOfSet();
        }

        public int GetBusCount(string stop)
        {
            return stop_bus.ContainsKey(stop) ? stop_bus[stop].Count : 0;
        }

        public int GetStopCount(string bus)
        {
            return bus_stop.ContainsKey(bus) ? bus_stop[bus].Count : 0;
        }

        public bool AreBusStops(string bus, string stop)
        {
            return bus_stop.ContainsKey(bus) ? bus_stop[bus].Contains(stop) : false;
        }

        public bool AreStopBusses(string stop, string bus)
        {
            return stop_bus.ContainsKey(stop) ? stop_bus[stop].Contains(bus) : false;
        }

        public void AddNewBus(string nameBus,int stopCount,string[] stops)
        {
            if (stopCount != stops.Length || stopCount == 0 || bus_stop.ContainsKey(nameBus))
            {
                throw new Exception("Unable to add");
            }
            else
            {
                HashSet<string> stop = new HashSet<string>();
                foreach (var i in stops)
                {
                    stop.Add(i);
                    if (stop_bus.ContainsKey(i))
                        stop_bus[i].Add(nameBus);
                    else
                        stop_bus.Add(i, new HashSet<string> { nameBus });
                }
                bus_stop.Add(nameBus, stop);
            }
        }
    }
}
