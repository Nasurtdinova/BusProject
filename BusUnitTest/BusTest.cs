using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusStopsProject;
using System;
using System.Collections.Generic;

namespace BusUnitTest
{
    [TestClass]
    public class BusTest
    {
        [TestMethod]
        public void TestAddingBus()
        {
            Bus bus = new Bus();
            Bus_Stop busStop = new Bus_Stop(bus);
            Stop_Bus stopBus = new Stop_Bus(bus);

            Assert.AreEqual(busStop.GetBusCount("Tolstopaltsevo"), 0);
            Assert.AreEqual(busStop.GetBusCount("Tolstopaltsevo"), 0);
            Assert.AreEqual(stopBus.GetStopCount("32"), 0);
            Assert.AreEqual(stopBus.GetStopCount("32K"), 0);

            string line = "NEW_BUS 32 3 Tolstopaltsevo Marushkino Vnukovo";
            string line2 = "NEW_BUS 32K 6 Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo";
            bus.AddNewBus(line.Split());
            bus.AddNewBus(line2.Split());
            Assert.AreEqual(busStop.GetBusCount("Tolstopaltsevo"), 2);
            Assert.AreEqual(busStop.GetBusCount("Tolstopaltsevo"), 2);
            Assert.AreEqual(stopBus.GetStopCount("32"), 3);
            Assert.AreEqual(stopBus.GetStopCount("32K"), 6);
        }

        [TestMethod]
        public void TestAreBusStops()
        {
            Bus bus = new Bus();

            string line = "NEW_BUS 32 3 Tolstopaltsevo Marushkino Vnukovo";
            bus.AddNewBus(line.Split());
            Assert.IsTrue(bus.AreBusStops("32", "Tolstopaltsevo"));
            Assert.IsTrue(bus.AreStopBusses("Tolstopaltsevo", "32"));

            string line2 = "NEW_BUS 32K 6 Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo";
            bus.AddNewBus(line2.Split());
            Assert.IsFalse(bus.AreBusStops("32", "Solntsevo"));
            Assert.IsFalse(bus.AreStopBusses("Solntsevo", "32"));
        }

        [TestMethod]
        public void TestStopsForBus()
        {
            Bus bus = new Bus();
            Bus_Stop busStop = new Bus_Stop(bus);
            Stop_Bus stopBus = new Stop_Bus(bus);

            Assert.AreEqual(stopBus.StopsForBus("32"), $"No bus{Environment.NewLine}");
            Assert.AreEqual(busStop.BusesForStop("Tolstopaltsevo"), "No stop");

            string line = "NEW_BUS 32 3 Tolstopaltsevo Marushkino Vnukovo";
            bus.AddNewBus(line.Split());
            Assert.AreEqual(stopBus.StopsForBus("32"), $"Stop Tolstopaltsevo: no interchange{Environment.NewLine}Stop Marushkino: no interchange{Environment.NewLine}Stop Vnukovo: no interchange{Environment.NewLine}");
            Assert.AreEqual(busStop.BusesForStop("Vnukovo"), "32 ");
        }

        [TestMethod]
        public void TestAllBusses()
        {
            Bus bus = new Bus();
            Bus_Stop busStop = new Bus_Stop(bus);
            Stop_Bus stopBus = new Stop_Bus(bus);
            string line = "NEW_BUS 32 3 Tolstopaltsevo Marushkino Vnukovo";
            string line2 = "NEW_BUS 32K 6 Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo";
            bus.AddNewBus(line.Split());
            bus.AddNewBus(line2.Split());
            AllBuses allBuses = new AllBuses(bus);

            
            List<string> allBussesCheck = new List<string>();
            allBussesCheck.Add("32");
            allBussesCheck.Add("32K");
            Assert.AreEqual(allBussesCheck.Count, allBuses.bus_stop.Count);
        }
    }
}
