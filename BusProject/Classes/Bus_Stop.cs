﻿using System;
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

        public HashSet<string> BUSES_FOR_STOP(string stop)
        {
            if (stop_bus.ContainsKey(stop))
                return stop_bus[stop];
            else
                throw new Exception();
        }

        public string Message(string stop)
        {
            string s = "";
            foreach (var i in BUSES_FOR_STOP(stop))
            {
                s = $"{s} {i}";
            }
            return s;
        }
    }
}
