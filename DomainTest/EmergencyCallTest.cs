using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Exceptions;

namespace DomainTest
{
    [TestClass]
    public class EmergencyCallTest
    {
        [TestMethod]
        public void TestCreateEmergencyCallWithDescription()
        {
            EmergencyCall call = new EmergencyCall();
            call.Description = "nice call";
            Assert.AreEqual(call.Description, "nice call");
        }

        [TestMethod]
        public void TestCreateEmergencyCallWithDirection()
        {
            EmergencyCall call = new EmergencyCall();
            call.Address = "Rambla Republica Del Peru";
            Assert.AreEqual(call.Address, "Rambla Republica Del Peru");
        }

        [TestMethod]
        public void TestCreateEmergencyCallAndSetLocation()
        {
            EmergencyCall call = new EmergencyCall();
            call.Location.SetCoordinates(140.21, 56.023);
            Assert.AreEqual(call.Location.Latitude, 56.023);
            Assert.AreEqual(call.Location.Longitude, 140.21);
        }

        [TestMethod]
        public void TestCreateEmergencyCallWithLevelOfUrgencyHigh()
        {
            EmergencyCall call = new EmergencyCall();
            call.SetLevelOfUrgency(EmergencyCall.HIGH);
            Assert.AreEqual(call.LevelOfUrgency, EmergencyCall.HIGH);
        }

        [TestMethod]
        public void TestCreateEmergencyCallWithDate()
        {
            EmergencyCall call = new EmergencyCall();
            DateTime meetingAppt = new DateTime(2008, 9, 22, 14, 30, 0);
            call.CreationDate = meetingAppt;
            Assert.AreEqual(call.CreationDate, new DateTime(2008, 9, 22, 14, 30, 0));
        }

        [TestMethod]
        public void TestCreateEmergencyCallWithMobileUnit()
        {
            EmergencyCall call = new EmergencyCall();
            MobileUnit mobile = new MobileUnit();
            call.Mobile = mobile;
            Assert.AreEqual(mobile, call.Mobile);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLevelOfUrgencyException))]
        public void TestCreateEmergencyCallAndSetLevelOfUrgencyIncorrectFormat()
        {
            EmergencyCall call = new EmergencyCall();
            call.SetLevelOfUrgency(0);
        }

        [TestMethod]
        public void TestCreateEmergencyCallsAndSetAsSolved()
        {
            EmergencyCall call = new EmergencyCall();
            Assert.IsFalse(call.Solved);
            call.Solved = true;
            Assert.IsTrue(call.Solved);
        }
    }
}
