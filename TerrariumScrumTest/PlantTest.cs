using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TerrariumScrum;

namespace TerrariumScrumTest
{
    [TestClass]
    public class PlantTest
    {
        [TestMethod]
        public void ToStringvanPlantGeeftPterug()
        {
            var plant = new Plant(2,6,1);
            Assert.AreEqual("P", plant.Tostring());
        }
    }
}
