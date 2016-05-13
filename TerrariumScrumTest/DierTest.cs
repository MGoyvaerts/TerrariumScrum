using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerrariumScrum;

namespace TerrariumScrumTest
{
    [TestClass]
    public class DierTest
    {
        private Dier dier;
        [TestInitialize]
        public void Initialize()
        {
            dier = new Herbivoor();
        }
        [TestMethod]
        public void ElkDierMetEenLegePositieAanZijnRechterzijdeDoetWillekeurigÉénstap()
        {
            //dier.Verplaatsen();
        }
    }
}
