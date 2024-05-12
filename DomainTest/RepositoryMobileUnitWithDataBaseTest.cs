using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Exceptions;
using System.Collections.Generic;

namespace DomainTest
{
    [TestClass]
    public class RepositoryMobileUnitWithDataBaseTest
    {
        [TestMethod]
        public void TestAddMobileUnitToList()
        {
            MobileUnit mobile = new MobileUnit();
            mobile.Name = "aMobileToBeAdded";
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase();
            repositoryOfMobileUnits.Clear();
            repositoryOfMobileUnits.Add(mobile);
            Assert.AreEqual(mobile.Name, repositoryOfMobileUnits.GetMobile("aMobileToBeAdded").Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAddMobileUnitException))]
        public void TestAddTwoMobileUnitsWithSameName()
        {
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase();
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            repositoryOfMobileUnits.Clear();
            MobileUnit mobile1 = new MobileUnit();
            mobile1.Name = "mobile";
            MobileUnit mobile2 = new MobileUnit();
            mobile2.Name = "mobile";
            repositoryOfMobileUnits.Add(mobile1);
            repositoryOfMobileUnits.Add(mobile2);
        }

        [TestMethod]
        public void TestGetMobileUnitFromListByName()
        {
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase();
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            repositoryOfMobileUnits.Clear();
            String name = "mobile";
            MobileUnit mobile1 = new MobileUnit(name);
            repositoryOfMobileUnits.Add(mobile1);
            Assert.AreEqual(name, repositoryOfMobileUnits.GetMobile(name).Name);
        }

        [TestMethod]
        public void TestAddMobileUnitToListAndThenDeleteItByName()
        {
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase();
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            repositoryOfMobileUnits.Clear();
            String name = "mobile";
            MobileUnit mobile1 = new MobileUnit(name);
            repositoryOfMobileUnits.Add(mobile1);
            repositoryOfMobileUnits.Delete("mobile");
            Assert.IsFalse(repositoryOfMobileUnits.Exists("mobile"));
        }

        [TestMethod]
        public void TestAddThreeMobileUnitsToTheRepositoryAndGetSize()
        {
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase();
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            repositoryOfMobileUnits.Clear();
            MobileUnit mobile1 = new MobileUnit("mobile1");
            MobileUnit mobile2 = new MobileUnit("mobile2");
            MobileUnit mobile3 = new MobileUnit("mobile3");
            repositoryOfMobileUnits.Add(mobile1);
            repositoryOfMobileUnits.Add(mobile2);
            repositoryOfMobileUnits.Add(mobile3);
            Assert.AreEqual(3, repositoryOfMobileUnits.Count());
        }

        [TestMethod]
        public void TestLookForTheNearestMobileOfAList()
        {
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase(); ;
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            repositoryOfMobileUnits.Clear();
            MobileUnit mobile1 = new MobileUnit("mobile1");
            MobileUnit mobile2 = new MobileUnit("mobile2");
            MobileUnit mobile3 = new MobileUnit("mobile3");
            mobile1.Location.SetCoordinates(1, 1);
            mobile2.Location.SetCoordinates(10, 10);
            mobile3.Location.SetCoordinates(30, 30);
            repositoryOfMobileUnits.Add(mobile1);
            repositoryOfMobileUnits.Add(mobile2);
            repositoryOfMobileUnits.Add(mobile3);
            List<MobileUnit> aListOfMobileUnits = new List<MobileUnit>();
            foreach (var mob in repositoryOfMobileUnits.GetMobileUnits())
            {
                aListOfMobileUnits.Add(mob);
            }
            String nameNearest = repositoryOfMobileUnits.GetNearestAvailable(new Location(3, 3), aListOfMobileUnits).Name;
            Assert.AreEqual(nameNearest, mobile1.Name);
        }

        [TestMethod]
        public void TestExistsByName()
        {
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase(); ;
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            repositoryOfMobileUnits.Clear();
            MobileUnit mobile1 = new MobileUnit("mobile1");
            MobileUnit mobile2 = new MobileUnit("mobile2");
            MobileUnit mobile3 = new MobileUnit("mobile3");
            repositoryOfMobileUnits.Add(mobile1);
            repositoryOfMobileUnits.Add(mobile2);
            repositoryOfMobileUnits.Add(mobile3);
            Assert.IsTrue(repositoryOfMobileUnits.Exists("mobile1"));
        }

        [TestMethod]
        public void TestClear()
        {
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase(); ;
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            repositoryOfMobileUnits.Clear();
            MobileUnit mobile1 = new MobileUnit("mobile1");
            MobileUnit mobile2 = new MobileUnit("mobile2");
            MobileUnit mobile3 = new MobileUnit("mobile3");
            repositoryOfMobileUnits.Add(mobile1);
            repositoryOfMobileUnits.Add(mobile2);
            repositoryOfMobileUnits.Add(mobile3);
            repositoryOfMobileUnits.Clear();
            Assert.IsTrue(repositoryOfMobileUnits.Count() == 0);
        }

        [TestMethod]
        public void TestReturnAnArrayOfNamesOfMobileUnits()
        {
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase();
            repositoryOfMobileUnits.Clear();
            MobileUnit mobile1 = new MobileUnit("Mobile1");
            MobileUnit mobile2 = new MobileUnit("Mobile2");
            MobileUnit mobile3 = new MobileUnit("Mobile3");
            repositoryOfMobileUnits.Add(mobile1);
            repositoryOfMobileUnits.Add(mobile2);
            repositoryOfMobileUnits.Add(mobile3);
            String[] arrayOfMobileUnits = repositoryOfMobileUnits.GetNames();
            Assert.IsTrue(Array.Exists(arrayOfMobileUnits, element => element == "Mobile1"));
            Assert.IsTrue(Array.Exists(arrayOfMobileUnits, element => element == "Mobile2"));
            Assert.IsTrue(Array.Exists(arrayOfMobileUnits, element => element == "Mobile2"));
        }

        [TestMethod]
        public void TestModifyByNameAMobileUnit()
        {
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase();
            MobileUnit mobile1 = new MobileUnit("OldName", "Old1234", "OldDescrption");
            repositoryOfMobileUnits.Add(mobile1);
            repositoryOfMobileUnits.ModifyMobileUnitByName("OldName", "NewName", "New1234", "NewDescription");
            Assert.IsFalse(repositoryOfMobileUnits.Exists("OldName"));
            Assert.IsTrue(repositoryOfMobileUnits.Exists("NewName"));
        }

        [TestMethod]
        public void TestSetCoordinatesToMobileUnit()
        {
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase();
            repositoryOfMobileUnits.Clear();
            MobileUnit mobile1 = new MobileUnit("Name", "AAA1234", "Descrption");
            repositoryOfMobileUnits.Add(mobile1);
            repositoryOfMobileUnits.SetCoordinatesToMobile("Name", -120.003, 43.2123);
            Assert.AreEqual(new Location(-120.003, 43.2123), repositoryOfMobileUnits.GetLocation("Name"));
        }

        [TestMethod]
        public void TestMoreThanOneAvailable()
        {
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase();
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            repositoryOfMobileUnits.Clear();
            MobileUnit mobile1 = new MobileUnit("Name1", "ACA1234", "Descrption");
            MobileUnit mobile2 = new MobileUnit("Name2", "ABA1234", "Descrption");
            MobileUnit mobile3 = new MobileUnit("Name3", "AAA1234", "Descrption");
            repositoryOfMobileUnits.Add(mobile1);
            repositoryOfMobileUnits.Add(mobile2);
            repositoryOfMobileUnits.Add(mobile3);
            Assert.IsTrue(repositoryOfMobileUnits.IsMoreThanOneAvailable());
        }

        [TestMethod]
        public void TestSetMobileAvailable()
        {
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase();
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            repositoryOfMobileUnits.Clear();
            MobileUnit mobile1 = new MobileUnit("Name1", "AAA1234", "Descrption");
            mobile1.Available = false;
            repositoryOfMobileUnits.Add(mobile1);
            repositoryOfMobileUnits.SetMobileAvailable("Name1");
            Assert.IsTrue(repositoryOfMobileUnits.GetMobile("Name1").Available);
        }

        [TestMethod]
        public void TestSetMobileNotAvailable()
        {
            RepositoryMobileUnitWithDataBase repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase();
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            repositoryOfMobileUnits.Clear();
            MobileUnit mobile1 = new MobileUnit("Name1", "AAA1234", "Descrption");
            repositoryOfMobileUnits.Add(mobile1);
            repositoryOfMobileUnits.SetMobileNotAvailable("Name1");
            Assert.IsFalse(repositoryOfMobileUnits.GetMobile("Name1").Available);
        }

        [TestMethod]
        public void TestFewestEmergencyCallSolved()
        {
            RepositoryMobileUnitWithDataBase repo = new RepositoryMobileUnitWithDataBase();
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            repo.Clear();
            MobileUnit mobile1 = new MobileUnit("Mobile1", "AAA1234", "OneDescription");
            MobileUnit mobile2 = new MobileUnit("Mobile2", "AAA1234", "OneDescription");
            MobileUnit mobile3 = new MobileUnit("Mobile3", "AAA1234", "OneDescription");
            EmergencyCall call1 = new EmergencyCall();
            EmergencyCall call2 = new EmergencyCall();
            EmergencyCall call3 = new EmergencyCall();
            call1.Mobile = mobile1;
            call2.Mobile = mobile1;
            call3.Mobile = mobile2;
            call1.Solved = true;
            call2.Solved = true;
            call3.Solved = true;
            List<MobileUnit> listOfMobileUnits = new List<MobileUnit>();
            List<EmergencyCall> listOfEmergencyCalls = new List<EmergencyCall>();
            listOfMobileUnits.Add(mobile1);
            listOfMobileUnits.Add(mobile2);
            listOfMobileUnits.Add(mobile3);
            listOfEmergencyCalls.Add(call1);
            listOfEmergencyCalls.Add(call2);
            listOfEmergencyCalls.Add(call3);
            repo.Add(mobile1);
            repo.Add(mobile2);
            repo.Add(mobile3);
            repositoryOfEmergencyCalls.Add(call1);
            repositoryOfEmergencyCalls.Add(call2);
            repositoryOfEmergencyCalls.Add(call3);
            Location loc = new Location();
            String nameResult = repo.GetFewestEmergencyCallsSolved(loc, listOfEmergencyCalls.ToArray(), listOfMobileUnits.ToArray()).Name;
            Assert.AreEqual(mobile3.Name, nameResult);
        }

        [TestMethod]
        public void Test2FewestEmergencyCallSolved()
        {
            RepositoryMobileUnitWithDataBase repo = new RepositoryMobileUnitWithDataBase();            
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            repo.Clear();
            MobileUnit mobile1 = new MobileUnit("Mobile1", "AAA1234", "OneDescription");
            MobileUnit mobile2 = new MobileUnit("Mobile2", "AAA1234", "OneDescription");
            MobileUnit mobile3 = new MobileUnit("Mobile3", "AAA1234", "OneDescription");
            mobile1.Location = new Location(12, 12);
            mobile2.Location = new Location(-42, -42);
            mobile3.Location = new Location(-42, 42);
            EmergencyCall call1 = new EmergencyCall();
            EmergencyCall call2 = new EmergencyCall();
            EmergencyCall call3 = new EmergencyCall();
            call1.Location = new Location(12, 12);
            call2.Location = new Location(42, 42);
            call3.Location = new Location(62, 62);
            call1.Mobile = mobile1;
            call2.Mobile = mobile2;
            call3.Mobile = mobile3;
            call1.Solved = true;
            call2.Solved = true;
            call3.Solved = true;
            List<MobileUnit> listOfMobileUnits = new List<MobileUnit>();
            List<EmergencyCall> listOfEmergencyCalls = new List<EmergencyCall>();
            listOfMobileUnits.Add(mobile1);
            listOfMobileUnits.Add(mobile2);
            listOfMobileUnits.Add(mobile3);
            listOfEmergencyCalls.Add(call1);
            listOfEmergencyCalls.Add(call2);
            listOfEmergencyCalls.Add(call3);
            repo.Add(mobile1);
            repo.Add(mobile2);
            repo.Add(mobile3);
            repositoryOfEmergencyCalls.Add(call1);
            repositoryOfEmergencyCalls.Add(call2);
            repositoryOfEmergencyCalls.Add(call3);
            Location loc = new Location(13,13);
            String nameResult = repo.GetFewestEmergencyCallsSolved(loc, listOfEmergencyCalls.ToArray(), listOfMobileUnits.ToArray()).Name;
            Assert.AreEqual(mobile1.Name, nameResult);
        }
    }
}
