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

            Assert.AreEqual(bus.GetBusCount("Tolstopaltsevo"), 0);
            Assert.AreEqual(bus.GetBusCount("Tolstopaltsevo"), 0);
            Assert.AreEqual(bus.GetStopCount("32"), 0);
            Assert.AreEqual(bus.GetStopCount("32K"), 0);

            string line = "Tolstopaltsevo Marushkino Vnukovo";
            string line2 = "Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo";
            bus.AddNewBus("32", 3, line.Split());
            bus.AddNewBus("32K", 6, line2.Split());
            Assert.AreEqual(bus.GetBusCount("Tolstopaltsevo"), 2);
            Assert.AreEqual(bus.GetBusCount("Tolstopaltsevo"), 2);
            Assert.AreEqual(bus.GetStopCount("32"), 3);
            Assert.AreEqual(bus.GetStopCount("32K"), 6);
        }

        [TestMethod]
        public void TestAreBusStops()
        {
            Bus bus = new Bus();

            string line = "Tolstopaltsevo Marushkino Vnukovo";
            bus.AddNewBus("32", 3, line.Split());
            Assert.IsTrue(bus.AreBusStops("32", "Tolstopaltsevo"));
            Assert.IsTrue(bus.AreStopBusses("Tolstopaltsevo", "32"));

            string line2 = "Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo";
            bus.AddNewBus("32K", 6, line2.Split());
            Assert.IsFalse(bus.AreBusStops("32", "Solntsevo"));
            Assert.IsFalse(bus.AreStopBusses("Solntsevo", "32"));
        }

        [TestMethod]
        public void TestStopsForBus()
        {
            Bus bus = new Bus();
            Bus_Stop busStop = new Bus_Stop(bus, "Tolstopaltsevo");
            Stop_Bus stopBus = new Stop_Bus(bus, "32");

            Assert.AreEqual(stopBus.ToString(), "No bus");
            Assert.AreEqual(busStop.ToString(), "No stop");

            string line = "Tolstopaltsevo Marushkino Vnukovo";
            bus.AddNewBus("32", 3, line.Split());

            List<string> res = new List<string>() { "Stop Tolstopaltsevo: no interchange", "Stop Marushkino: no interchange", "Stop Vnukovo: no interchange" };
            CollectionAssert.AreEqual(stopBus.StopsForBus(), res);
            Assert.AreEqual(busStop.ToString(), "32");
        }

        [TestMethod]
        public void TestAllBusses()
        {
            Bus bus = new Bus();
            AllBuses allBuses = new AllBuses(bus);
            Assert.AreEqual(allBuses.ToString(), "No buses");

            string line = "Tolstopaltsevo Marushkino Vnukovo";
            string line2 = "Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo";
            bus.AddNewBus("32", 3, line.Split());
            bus.AddNewBus("32K", 6, line2.Split());
            
            List<string> allBussesCheck = new List<string>();
            allBussesCheck.Add("Bus 32: Tolstopaltsevo Marushkino Vnukovo");
            allBussesCheck.Add("Bus 32K: Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo");
            CollectionAssert.AreEqual(allBussesCheck, allBuses.ALL_BUSES());
        }

        [TestMethod]
        public void TestCollections()
        {
            Bus bus = new Bus();

            var testDict = new Dictionary<string, HashSet<string>>()
            {
                { "32", new HashSet<string>() { "Tolstopaltsevo Marushkino Vnukovo" } },
                { "32K", new HashSet<string>() { "Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo" } },
            };

            string line = "Tolstopaltsevo Marushkino Vnukovo";
            string line2 = "Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo";
            bus.AddNewBus("32", 3, line.Split());
            bus.AddNewBus("32K", 6, line2.Split());

            CollectionAssert.AreEqual(testDict, bus.bus_stop, new DictComparer());
        }

        private class DictComparer : Comparer<KeyValuePair<string, HashSet<string>>>
        {
            public override int Compare(KeyValuePair<string, HashSet<string>> lhs, KeyValuePair<string, HashSet<string>> rhs)
            {
                return lhs.Key.CompareTo(lhs.Key);
            }
        }
    }
}
