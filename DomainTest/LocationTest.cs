using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Exceptions;

namespace DomainTest
{
    [TestClass]
    public class LocationTest
    {
        [TestMethod]
        public void TestAssignLocationToMobileUnit()
        {
            MobileUnit mobile = new MobileUnit("mobile");
            mobile.Location.SetCoordinates(150.03, 69.02);
            Assert.AreEqual(69.02, mobile.Location.Latitude);
            Assert.AreEqual(150.03, mobile.Location.Longitude);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLatitudeException),"It is not a valid latitud, must not have more than 5 numbers after the .")]
        public void TestCreateLocationWithLatitudeIncorrectDecimal()
        {
            Location loc = new Location();
            loc.SetLatitude(1.123456);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLongitudeException), "It is not a valid longitude, must not have more than 5 numbers after the .")]
        public void TestCreateLocationWithLongitudeIncorrectDecimal()
        {
            Location loc = new Location();
            loc.SetLongitude(1.123456);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLatitudeException), "It is not a valid latitud, must not have more than 5 numbers after the .")]
        public void TestCreateLocationWithLatitudeNotValid()
        {
            Location loc = new Location();
            loc.SetLatitude(95.12);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLongitudeException), "It is not a valid longitude, must not have more than 5 numbers after the .")]
        public void TestCreateLocationWithLongitudeNotValid()
        {
            Location loc = new Location();
            loc.SetLongitude(191.56);
        }

        [TestMethod]
        public void TestCalculateDistanceToOtherLocation()
        {
            Location loc1 = new Location(-120, 45);
            Location loc2 = new Location(20, 35);
            Assert.AreEqual(loc1.CalculateDistance(loc2), 140.356688476182);
        }

        [TestMethod]
        public void TestGiveMeTheNearestMobileUnitAvailableFromARepository()
        {
            MobileUnit mobile1 = new MobileUnit("mobile1");
            MobileUnit mobile2 = new MobileUnit("mobile2");
            MobileUnit mobile3 = new MobileUnit("mobile3");
            MobileUnit mobile4 = new MobileUnit("mobile4"); 
            mobile1.Location.SetCoordinates(56.12, 35.89);
            mobile2.Location.SetCoordinates(133.666, 83.212);
            mobile3.Location.SetCoordinates(165, -65.212);
            mobile4.Location.SetCoordinates(-3.6543, -79.698);
            RepositoryMobileUnitWithList repo = new RepositoryMobileUnitWithList();
            repo.Add(mobile1);
            repo.Add(mobile2);
            repo.Add(mobile3);
            repo.Add(mobile4);
            Location location = new Location(43.212, 33.12);
            Assert.AreEqual(repo.GetNearestAvailable(location), mobile1);
        }

        [TestMethod]
        public void TestGiveMeTheNearestMobileUnitAvailableFromARepositoryWithOneNotAvailable()
        {
            MobileUnit mobile1 = new MobileUnit("mobile1");
            MobileUnit mobile2 = new MobileUnit("mobile2");
            MobileUnit mobile3 = new MobileUnit("mobile3");
            MobileUnit mobile4 = new MobileUnit("mobile4");
            mobile1.Location.SetCoordinates(56.12, 35.89);
            mobile2.Location.SetCoordinates(133.666, 83.212);
            mobile3.Location.SetCoordinates(165, -65.212);
            mobile4.Location.SetCoordinates(-3.6543, -79.698);
            RepositoryMobileUnitWithList repo = new RepositoryMobileUnitWithList();
            mobile1.Available = false;
            repo.Add(mobile1);
            repo.Add(mobile2);
            repo.Add(mobile3);
            repo.Add(mobile4);
            Location location = new Location(43.212, 33.12);
            Assert.AreEqual(repo.GetNearestAvailable(location), mobile2);
        }

        [TestMethod]
        public void TestTwoDifferentLocations()
        {
            Location oneLocation = new Location(12,13);
            Location anotherLocation = new Location(1, 3);
            Assert.IsFalse(oneLocation.Equals(anotherLocation));
        }
    }
}
