using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bike_Race.Classes;
using Bike_Race;

namespace BikeRaceUnitTest // comment for the name of bike race unit test //
{
    [TestClass]
    public class BikeRaceTest
    {
        [TestMethod]
        public void when_winnier_is_correct_returns_payout()
        {
            // Arrange
            var bet = new Bet();

            // Act
            var actual = bet.Payout("Valentino Rossi");

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void returns_nothing()
        {

        }
    }
}
