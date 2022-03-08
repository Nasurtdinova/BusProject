using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusProject;
using BusProject.Classes;

namespace BusUnitTest
{
    [TestClass]
    public class BusTest
    {
        [TestMethod]
        public void TestAddingBus()
        {
            Bus bus = new Bus();
            string line = "NEW_BUS 32 3 Tolstopaltsevo Marushkino Vnukovo";
            string[] command = line.Split();
            bus.AddNewBus(command);
        }
    }
}
