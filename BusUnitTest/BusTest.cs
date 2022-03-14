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

            string line = "Tolstopaltsevo Marushkino Vnukovo";
            string line2 = "Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo";
            bus.AddNewBus("32", 3, line.Split());
            bus.AddNewBus("32K", 6, line2.Split());
            AllBuses allBuses = new AllBuses(bus);
            
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

            // because HashSet objects will be compared with object.Equals and they are not same
            // https://stackoverflow.com/questions/5194966/mstest-collectionassert-areequivalent-failed-the-expected-collection-contains
            CollectionAssert.AreEqual(testDict, bus.bus_stop, new DictComparer());

            // compare each HashSet manually
            //foreach (var word in synonyms.Dict)
            //{
            //    CollectionAssert.AreEqual(testDict[word.Key], word.Value);
            //}
        }

        //Why CollectionAssert.AreEqual fails even when both lists contain the same items
        //https://softwareonastring.com/357/why-collectionassert-areequal-fails-even-when-both-lists-contain-the-same-items
        private class DictComparer : Comparer<KeyValuePair<string, HashSet<string>>>
        {
            public override int Compare(KeyValuePair<string, HashSet<string>> lhs, KeyValuePair<string, HashSet<string>> rhs)
            {
                // compare the two pais
                // for the purpose of this tests they are considered equal when their identifiers (names) match
                return lhs.Key.CompareTo(lhs.Key);
            }
        }
    }
}
