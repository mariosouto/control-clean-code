using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Exceptions;
using Domain.Services;

namespace DomainTest
{
    [TestClass]
    public class ServicesTest
    {
        [TestMethod]
        public void TestAddMobileUnitByServiceAndGetItByName()
        {
            MobileUnit mobile = new MobileUnit("Mobile1");
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            Services.AddMobileUnit(mobile);
            Assert.AreEqual(mobile.Name, Services.GetMobileUnit("Mobile1").Name);
        }

        [TestMethod]
        public void TestAddMobileUnitToListAndThenDeleteItByNameWithService()
        {
            MobileUnit mobileToDelete = new MobileUnit("MobileToDelete");
            Services.AddMobileUnit(mobileToDelete);
            Services.DeleteMobileUnitByName("MobileToDelete");
            Assert.IsFalse(Services.ExistsMobileUnit("MobileToDelete"));
        }

        [TestMethod]
        public void TestAddThreeMobileUnitsWithServiceAndCount()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            MobileUnit mobileOne = new MobileUnit("MobileOne");
            MobileUnit mobileTwo = new MobileUnit("MobileTwo");
            MobileUnit mobileThree = new MobileUnit("MobileThree");
            Services.AddMobileUnit(mobileOne);
            Services.AddMobileUnit(mobileTwo);
            Services.AddMobileUnit(mobileThree);
            Assert.AreEqual(3, Services.CountMobileUnits());
        }

        [TestMethod]
        public void TestAddEmergencyCAllByService()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            EmergencyCall call = new EmergencyCall();
            call.CreationDate = DateTime.Now;
            call.AssignationDate = DateTime.Now; ;
            call.SolvedDate = DateTime.Now;
            call.AssignMode = EmergencyCall.AssignModes.Default;
            Services.AddEmergencyCall(call);
            Assert.AreEqual(1, Services.CountEmergencyCalls());
        }

        [TestMethod]
        public void TestCreateMobileUnitWithParametersAndAddToList()
        {
            Services.ClearMobileUnits();
            Services.AddMobileUnit("MobileToAdd", "ABC1234", "Description of the Mobile Unit");
            Assert.IsTrue(Services.ExistsMobileUnit("MobileToAdd"));
        }

        [TestMethod]
        public void TestReturnAnArrayOfNamesOfMobileUnits()
        {
            Services.ClearMobileUnits();
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.AddMobileUnit("Mobile2", "ABR1234", "Description of the Mobile Unit 2");
            Services.AddMobileUnit("Mobile3", "BBC1234", "Description of the Mobile Unit 3");
            String[] arrayOfMobileUnits = Services.GetNamesOfMobileUnits();
            Assert.IsTrue(Array.Exists(arrayOfMobileUnits, element => element == "Mobile1"));
            Assert.IsTrue(Array.Exists(arrayOfMobileUnits, element => element == "Mobile2"));
            Assert.IsTrue(Array.Exists(arrayOfMobileUnits, element => element == "Mobile2"));
        }

        [TestMethod]
        public void TestModifyByNameAMobileUnit()
        {
            Services.ClearMobileUnits();
            Services.AddMobileUnit("OldName", "Old1234", "OldDescrption");
            Services.ModifyMobileUnitByName("OldName", "NewName", "New1234", "NewDescription");
            Assert.IsFalse(Services.ExistsMobileUnit("OldName"));
            Assert.IsTrue(Services.ExistsMobileUnit("NewName"));
        }

        [TestMethod]
        public void TestSetCoordinatesToMobileUnit()
        {
            Services.ClearMobileUnits();
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.SetCoordinatesToMobile("Mobile1", -120.003, 43.2123);
            Assert.AreEqual(new Location(-120.003, 43.2123), Services.GetLocationOfMobileUnitByName("Mobile1"));
        }

        [TestMethod]
        public void TestAddEmergencyCallByServiceAndAsignItToTheNearestMobileAvailable()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            Services.SetAssignMode(EmergencyCall.AssignModes.Default);
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.AddMobileUnit("Mobile2", "SAD1234", "Description of the Mobile Unit 2");
            MobileUnit mobile3 = new MobileUnit();
            mobile3.Name = "Mobile3";
            mobile3.SetPlate("BAA1234");
            mobile3.Description = "Description of the Mobile Unit 3";
            mobile3.Available = false;
            Services.AddMobileUnit(mobile3);
            Services.SetCoordinatesToMobile("Mobile1", 5, 5);
            Services.SetCoordinatesToMobile("Mobile2", 10, 10);
            Services.SetCoordinatesToMobile("Mobile3", 1, 1);            
            EmergencyCall call = new EmergencyCall();
            Services.AddEmergencyCallAndAssignItToMobile(call);
            Assert.AreEqual(call.Mobile.Name, "Mobile1");
            Assert.IsFalse(Services.GetMobileUnit("Mobile1").Available);
            Assert.IsTrue(Services.GetMobileUnit("Mobile2").Available);
        }

        [TestMethod]
        public void TestMarkAsSolvedAnEmergencyCall()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();            
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.AddMobileUnit("Mobile2", "SAD1234", "Description of the Mobile Unit 2");
            MobileUnit mobile3 = new MobileUnit();
            mobile3.Name = "Mobile3";
            mobile3.SetPlate("BAA1234");
            mobile3.Description = "Description of the Mobile Unit 3";
            mobile3.Available = false;
            Services.AddMobileUnit(mobile3);
            Services.SetCoordinatesToMobile("Mobile1", 5, 5);
            Services.SetCoordinatesToMobile("Mobile2", 10, 10);
            Services.SetCoordinatesToMobile("Mobile3", 1, 1);
            EmergencyCall call = new EmergencyCall();
            Services.SetAssignMode(EmergencyCall.AssignModes.Default);
            Services.AddEmergencyCallAndAssignItToMobile(call);
            Services.EmergencyCallSolved(call.Id);
            Assert.IsTrue(Services.GetEmergencyCall(call.Id).Solved);
        }

        [TestMethod]
        public void TestMarkAsSolvedAnEmergencyCallAndAssignTheMobileThatGetsFreeToAnotherByDefaultMode()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            Services.SetAssignMode(EmergencyCall.AssignModes.Default);
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.AddMobileUnit("Mobile2", "SAD1234", "Description of the Mobile Unit 2");
            Services.AddMobileUnit("Mobile3", "BAA1234", "Description of the Mobile Unit 3");
            Services.SetCoordinatesToMobile("Mobile1", 5, 5);
            Services.SetCoordinatesToMobile("Mobile2", 10, 10);
            Services.SetCoordinatesToMobile("Mobile3", 1, 1);
            EmergencyCall call1 = new EmergencyCall("One description", "Cufre 1212", new Location(12.1234, 14.321), EmergencyCall.LOW,
                new DateTime(2019, 5, 3));
            EmergencyCall call2 = new EmergencyCall("Two description", "Gallinal 2312", new Location(11.111, -88.987), EmergencyCall.MEDIUM,
                new DateTime(2019, 5, 6));
            EmergencyCall call3 = new EmergencyCall("Three description", "Garibaldi 2134", new Location(54.11, 32.123), EmergencyCall.HIGH,
                new DateTime(2019, 4, 12));
            EmergencyCall call4 = new EmergencyCall("Four description", "Martinez 8732", new Location(67.98, -19.531), EmergencyCall.LOW,
                new DateTime(2019, 4, 23));
            EmergencyCall call5 = new EmergencyCall("Five description", "Joanico 921", new Location(-84.531, 76.234), EmergencyCall.MEDIUM,
                new DateTime(2019, 4, 30));
            EmergencyCall call6 = new EmergencyCall("Six description", "Fredo 874", new Location(87.1234, 45.214), EmergencyCall.MEDIUM,
                new DateTime(2019, 5, 1));
            Services.AddEmergencyCallAndAssignItToMobile(call1);
            Services.AddEmergencyCallAndAssignItToMobile(call2);
            Services.AddEmergencyCallAndAssignItToMobile(call3);
            Services.AddEmergencyCallAndAssignItToMobile(call4);
            Services.AddEmergencyCallAndAssignItToMobile(call5);
            Services.AddEmergencyCallAndAssignItToMobile(call6);
            Assert.IsFalse(Services.GetMobileUnit("Mobile1").Available);
            Assert.IsFalse(Services.GetMobileUnit("Mobile2").Available);
            Assert.IsFalse(Services.GetMobileUnit("Mobile3").Available);
            Services.EmergencyCallSolved(call2.Id);
            Assert.IsFalse(Services.GetEmergencyCall(call1.Id).Solved);
            Assert.IsFalse(Services.GetMobileUnit(Services.GetEmergencyCall(call2.Id).Mobile.Name).Available);
            Assert.AreEqual(Services.GetEmergencyCall(call2.Id).AssignMode, EmergencyCall.AssignModes.Default);
            Assert.AreEqual(Services.GetEmergencyCall(call5.Id).Mobile.Name, Services.GetMobileUnit(Services.GetEmergencyCall(call2.Id).Mobile.Name).Name);
        }

        [TestMethod]
        public void TestReturnAnArrayOfEmergencyCall()
        {
            Services.ClearEmergencyCalls();
            EmergencyCall call1 = new EmergencyCall("One description", "Cufre 1212", new Location(12.1234, 14.321), EmergencyCall.LOW,
                new DateTime(2019, 5, 3));
            EmergencyCall call2 = new EmergencyCall("Two description", "Gallinal 2312", new Location(11.111, -88.987), EmergencyCall.MEDIUM,
                new DateTime(2019, 5, 6));
            EmergencyCall call3 = new EmergencyCall("Three description", "Garibaldi 2134", new Location(54.11, 32.123), EmergencyCall.HIGH,
                new DateTime(2019, 4, 12));
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);
            Services.AddEmergencyCall(call3);
            EmergencyCall[] arrayOfEmergencyCall = Services.GetArrayOfEmergencyCalls();
            Assert.IsTrue(Array.Exists(arrayOfEmergencyCall, element => element.ToString() == call1.Id + ": One description"));
            Assert.IsTrue(Array.Exists(arrayOfEmergencyCall, element => element.ToString() == call2.Id + ": Two description"));
            Assert.IsTrue(Array.Exists(arrayOfEmergencyCall, element => element.ToString() == call3.Id + ": Three description"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDeleteMobileUnitException), "It's not possible to delete this Mobile Unit " +
            "because it is on an Emergency Call.")]
        public void TestAddMobileUnitToListAndThenDeleteItByNameWhileAssociatedToEmergencyCall()
        {
            Services.ClearMobileUnits();
            Services.ClearEmergencyCalls();
            MobileUnit mobileToDelete = new MobileUnit("MobileToDelete");
            Services.AddMobileUnit(mobileToDelete);
            EmergencyCall call1 = new EmergencyCall("One description", "Cufre 1212", new Location(12.1234, 14.321), EmergencyCall.LOW,
                new DateTime(2019, 5, 3));
            call1.Mobile = mobileToDelete;
            Services.AddEmergencyCall(call1);
            Services.DeleteMobileUnitByName("MobileToDelete");
        }

        [TestMethod]
        public void TestReturnAnArrayOfMobileUnits()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.AddMobileUnit("Mobile2", "ABR1234", "Description of the Mobile Unit 2");
            Services.AddMobileUnit("Mobile3", "BBC1234", "Description of the Mobile Unit 3");
            MobileUnit[] arrayOfMobileUnit = Services.GetMobileUnits();
            Assert.IsTrue(Array.Exists(arrayOfMobileUnit, element => element.Name == "Mobile1"));
            Assert.IsTrue(Array.Exists(arrayOfMobileUnit, element => element.Name == "Mobile2"));
            Assert.IsTrue(Array.Exists(arrayOfMobileUnit, element => element.Name == "Mobile3"));
        }

        [TestMethod]
        public void TestGetTheEmergencyCallActiveAssociatedToTheMobileUnit()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.AddMobileUnit("Mobile2", "ABR1234", "Description of the Mobile Unit 2");
            EmergencyCall call1 = new EmergencyCall("One description", "Cufre 1212", new Location(12.1234, 14.321), EmergencyCall.LOW,
                 new DateTime(2019, 5, 3));
            EmergencyCall call2 = new EmergencyCall("Two description", "Gallinal 2312", new Location(11.111, -88.987), EmergencyCall.MEDIUM,
                new DateTime(2019, 5, 6));
            EmergencyCall call3 = new EmergencyCall("Three description", "Garibaldi 2134", new Location(54.11, 32.123), EmergencyCall.HIGH,
                new DateTime(2019, 4, 12));
            call1.Mobile = Services.GetMobileUnit("Mobile1");
            call1.Solved = true;
            call2.Mobile = Services.GetMobileUnit("Mobile1");
            call3.Mobile = Services.GetMobileUnit("Mobile2");
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);
            Services.AddEmergencyCall(call3);
            Assert.AreEqual(call2.Id, Services.GetEmergencyCallUnsolvedAssignedToUnit("Mobile1").Id);
        }

        [TestMethod]
        public void TestSetEmergencyCallAsSolvedAndMobileUnitGetItsCoordinates()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.SetCoordinatesToMobile("Mobile1", 45.321, 32.333);
            EmergencyCall call1 = new EmergencyCall("One description", "Cufre 1212", new Location(12.1234, 14.321), EmergencyCall.LOW,
                 new DateTime(2019, 5, 3));
            call1.Mobile = Services.GetMobileUnit("Mobile1");
            Services.AddEmergencyCall(call1);
            Services.EmergencyCallSolved(call1.Id);
            Assert.AreEqual(Services.GetMobileUnit("Mobile1").Location, call1.Location);
        }

        [TestMethod]
        public void TestMarkAsSolvedAnEmergencyCallAndGetDateOfSolved()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();            
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.AddMobileUnit("Mobile2", "SAD1234", "Description of the Mobile Unit 2");
            Services.SetCoordinatesToMobile("Mobile1", 5, 5);
            Services.SetCoordinatesToMobile("Mobile2", 10, 10);
            MobileUnit mobile3 = new MobileUnit();
            mobile3.Name = "Mobile3";
            mobile3.SetPlate("BAA1234");
            mobile3.Description = "Description of the Mobile Unit 3";
            mobile3.Available = false;
            Services.AddMobileUnit(mobile3);
            Services.SetCoordinatesToMobile("Mobile3", 1, 1);
            EmergencyCall call = new EmergencyCall();
            Services.SetAssignMode(EmergencyCall.AssignModes.Default);
            Services.AddEmergencyCallAndAssignItToMobile(call);
            Services.EmergencyCallSolvedInDate(call.Id, new DateTime(2019, 6, 7, 15, 45, 0));
            Assert.IsTrue(Services.GetEmergencyCall(call.Id).Solved);
            Assert.AreEqual(Services.GetEmergencyCall(call.Id).SolvedDate, new DateTime(2019, 6, 7, 15, 45, 0));
        }

        [TestMethod]
        public void TestAddEmergencyCallByServiceAndAsignUsingWaitTimeAlgorithm()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            Services.SetAssignMode(EmergencyCall.AssignModes.WaitTime);
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.AddMobileUnit("Mobile2", "SAD1234", "Description of the Mobile Unit 2");
            Services.SetCoordinatesToMobile("Mobile1", 5, 5);
            Services.SetCoordinatesToMobile("Mobile2", 10, 10);            
            MobileUnit mobile3 = new MobileUnit();
            mobile3.Name = "Mobile3";
            mobile3.SetPlate("BAA1234");
            mobile3.Description = "Description of the Mobile Unit 3";
            mobile3.Available = false;
            Services.AddMobileUnit(mobile3);
            Services.SetCoordinatesToMobile("Mobile3", 1, 1);
            EmergencyCall call = new EmergencyCall();
            Services.AddEmergencyCallAndAssignItToMobile(call);
            Assert.AreEqual(call.Mobile.Name, "Mobile1");
            Assert.IsFalse(Services.GetMobileUnit("Mobile1").Available);
            Assert.IsTrue(Services.GetMobileUnit("Mobile2").Available);
        }

        [TestMethod]
        public void TestRegisterAnEmergencyCallAndAssignTheMobileThatGetsFreeToAnotherByNumberOfSolvedEmergencyCalls()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            Services.SetAssignMode(EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls);
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.AddMobileUnit("Mobile2", "SAD1234", "Description of the Mobile Unit 2");
            Services.AddMobileUnit("Mobile3", "BAA1234", "Description of the Mobile Unit 3");
            Services.AddMobileUnit("Mobile4", "BOY5678", "Description of the Mobile Unit 4");
            Services.SetCoordinatesToMobile("Mobile1", 5, 5);
            Services.SetCoordinatesToMobile("Mobile2", 10, 10);
            Services.SetCoordinatesToMobile("Mobile3", 1, 1);
            Services.SetCoordinatesToMobile("Mobile4", 12.123, 12.456);
            EmergencyCall call1 = new EmergencyCall("One description", "Cufre 1212", new Location(12.1234, 14.321), EmergencyCall.LOW,
               DateTime.Now);
            EmergencyCall call2 = new EmergencyCall("Two description", "Gallinal 2312", new Location(11.111, -88.987), EmergencyCall.MEDIUM,
                DateTime.Now);
            EmergencyCall call3 = new EmergencyCall("Three description", "Garibaldi 2134", new Location(54.11, 32.123), EmergencyCall.HIGH,
                DateTime.Now);
            EmergencyCall call4 = new EmergencyCall("Four description", "Martinez 8732", new Location(67.98, -19.531), EmergencyCall.LOW,
                DateTime.Now);
            EmergencyCall call5 = new EmergencyCall("Five description", "Joanico 921", new Location(67.0, -20.0), EmergencyCall.MEDIUM,
                DateTime.Now);
            Services.AddEmergencyCallAndAssignItToMobile(call1);
            Services.AddEmergencyCallAndAssignItToMobile(call2);
            Services.AddEmergencyCallAndAssignItToMobile(call3);
            Services.EmergencyCallSolved(call1.Id);
            Services.EmergencyCallSolved(call2.Id);
            Services.EmergencyCallSolved(call3.Id);
            Services.AddEmergencyCallAndAssignItToMobile(call4);
            Services.EmergencyCallSolved(call4.Id);
            Services.AddEmergencyCallAndAssignItToMobile(call5);
            Assert.AreEqual(Services.GetEmergencyCall(call1.Id).AssignMode, EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls);
            Assert.AreEqual(call4.Mobile.Name, Services.GetMobileUnit(Services.GetEmergencyCall(call5.Id).Mobile.Name).Name);
        }

        [TestMethod]
        public void Test2RegisterAnEmergencyCallAndAssignTheMobileThatGetsFreeToAnotherByNumberOfSolvedEmergencyCalls()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();            
            Services.SetAssignMode(EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls);
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.AddMobileUnit("Mobile2", "SAD1234", "Description of the Mobile Unit 2");
            Services.AddMobileUnit("Mobile3", "BAA1234", "Description of the Mobile Unit 3");
            Services.AddMobileUnit("Mobile4", "BOY5678", "Description of the Mobile Unit 4");
            Services.SetCoordinatesToMobile("Mobile1", 5, 5);
            Services.SetCoordinatesToMobile("Mobile2", 10, 10);
            Services.SetCoordinatesToMobile("Mobile3", 1, 1);
            Services.SetCoordinatesToMobile("Mobile4", 12.123, 12.456);
            EmergencyCall call1 = new EmergencyCall("One description", "Cufre 1212", new Location(12.1234, 14.321), EmergencyCall.LOW,
               new DateTime(2019, 5, 3));
            EmergencyCall call2 = new EmergencyCall("Two description", "Gallinal 2312", new Location(11.111, -88.987), EmergencyCall.MEDIUM,
                new DateTime(2019, 5, 6));
            EmergencyCall call3 = new EmergencyCall("Three description", "Garibaldi 2134", new Location(54.11, 32.123), EmergencyCall.HIGH,
                DateTime.Now);
            EmergencyCall call4 = new EmergencyCall("Four description", "Martinez 8732", new Location(67.98, -19.531), EmergencyCall.LOW,
                new DateTime(2019, 4, 23));
            EmergencyCall call5 = new EmergencyCall("Five description", "Joanico 921", new Location(-84.531, 76.234), EmergencyCall.MEDIUM,
                DateTime.Now);
            EmergencyCall call6 = new EmergencyCall("Six description", "Fredo 874", new Location(87.1234, 45.214), EmergencyCall.MEDIUM,
                new DateTime(2019, 5, 1));
            EmergencyCall call7 = new EmergencyCall("Seven description", "Rambla Peru 1519", new Location(-84.531, 76.234), EmergencyCall.MEDIUM,
                DateTime.Now);
            EmergencyCall call8 = new EmergencyCall("Eight description", "Echevarriarza 8744", new Location(87.1234, 45.214), EmergencyCall.MEDIUM,
                DateTime.Now);
            Services.AddEmergencyCallAndAssignItToMobile(call1);
            Services.AddEmergencyCallAndAssignItToMobile(call2);
            Services.AddEmergencyCallAndAssignItToMobile(call3);
            Services.EmergencyCallSolvedInDate(call1.Id, new DateTime(2019, 5, 3));
            Services.AddEmergencyCallAndAssignItToMobile(call4);
            Services.EmergencyCallSolvedInDate(call2.Id, new DateTime(2019, 5, 6));
            Services.AddEmergencyCallAndAssignItToMobile(call5);
            Services.EmergencyCallSolvedInDate(call3.Id, DateTime.Now);
            Services.EmergencyCallSolvedInDate(call4.Id, new DateTime(2019, 4, 23));
            Services.AddEmergencyCallAndAssignItToMobile(call6);
            Services.AddEmergencyCallAndAssignItToMobile(call7);
            Services.EmergencyCallSolvedInDate(call5.Id, DateTime.Now);
            Services.AddEmergencyCallAndAssignItToMobile(call8);
            Assert.AreEqual(Services.GetEmergencyCall(call1.Id).AssignMode, EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls);
            Assert.AreEqual(call8.Mobile.Name, Services.GetMobileUnit(Services.GetEmergencyCall(call3.Id).Mobile.Name).Name);
        }

        [TestMethod]
        public void TestMarkAsSolvedAnEmergencyCallAndAssignTheMobileThatGetsFreeToAnotherByWaitTime()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();            
            Services.SetAssignMode(EmergencyCall.AssignModes.WaitTime);
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.AddMobileUnit("Mobile2", "SAD1234", "Description of the Mobile Unit 2");
            Services.AddMobileUnit("Mobile3", "BAA1234", "Description of the Mobile Unit 3");
            Services.AddMobileUnit("Mobile4", "BOY5678", "Description of the Mobile Unit 4");
            Services.SetCoordinatesToMobile("Mobile1", 5, 5);
            Services.SetCoordinatesToMobile("Mobile2", 10, 10);
            Services.SetCoordinatesToMobile("Mobile3", 1, 1);
            Services.SetCoordinatesToMobile("Mobile4", 12.123, 12.456);
            EmergencyCall call1 = new EmergencyCall("One description", "Cufre 1212", new Location(12.1234, 14.321), EmergencyCall.LOW,
                new DateTime(2019, 5, 3));
            EmergencyCall call2 = new EmergencyCall("Two description", "Gallinal 2312", new Location(11.111, -88.987), EmergencyCall.MEDIUM,
                new DateTime(2019, 5, 6));
            EmergencyCall call3 = new EmergencyCall("Three description", "Garibaldi 2134", new Location(54.11, 32.123), EmergencyCall.HIGH,
                new DateTime(2019, 4, 12));
            EmergencyCall call4 = new EmergencyCall("Four description", "Martinez 8732", new Location(67.98, -19.531), EmergencyCall.LOW,
                new DateTime(2019, 4, 23));
            EmergencyCall call5 = new EmergencyCall("Five description", "Joanico 921", new Location(-84.531, 76.234), EmergencyCall.MEDIUM,
                new DateTime(2019, 4, 30));
            EmergencyCall call6 = new EmergencyCall("Six description", "Fredo 874", new Location(87.1234, 45.214), EmergencyCall.MEDIUM,
                new DateTime(2019, 5, 1));
            Services.AddEmergencyCallAndAssignItToMobile(call1);
            Services.AddEmergencyCallAndAssignItToMobile(call2);
            Services.AddEmergencyCallAndAssignItToMobile(call3);
            Services.AddEmergencyCallAndAssignItToMobile(call4);
            Services.AddEmergencyCallAndAssignItToMobile(call5);
            Services.AddEmergencyCallAndAssignItToMobile(call6);
            Assert.IsFalse(Services.GetMobileUnit("Mobile1").Available);
            Assert.IsFalse(Services.GetMobileUnit("Mobile2").Available);
            Assert.IsFalse(Services.GetMobileUnit("Mobile3").Available);
            Services.EmergencyCallSolved(call2.Id);
            Assert.AreEqual(Services.GetEmergencyCall(call2.Id).AssignMode, EmergencyCall.AssignModes.WaitTime);
            Assert.AreEqual(Services.GetEmergencyCall(call5.Id).Mobile.Name, Services.GetMobileUnit(Services.GetEmergencyCall(call2.Id).Mobile.Name).Name);
        }

        [TestMethod]
        public void TestMarkAsSolvedAnEmergencyCallAndAssignTheMobileThatGetsFreeToAnotherByWaitTimeWhenManyWithMostTime()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            Services.SetAssignMode(EmergencyCall.AssignModes.WaitTime);
            Services.AddMobileUnit("Mobile1", "ADS1234", "Description of the Mobile Unit 1");
            Services.AddMobileUnit("Mobile2", "SAD1234", "Description of the Mobile Unit 2");
            Services.AddMobileUnit("Mobile3", "BAA1234", "Description of the Mobile Unit 3");
            Services.AddMobileUnit("Mobile4", "BOY5678", "Description of the Mobile Unit 4");
            Services.SetCoordinatesToMobile("Mobile1", 5, 5);
            Services.SetCoordinatesToMobile("Mobile2", 10, 10);
            Services.SetCoordinatesToMobile("Mobile3", 1, 1);
            Services.SetCoordinatesToMobile("Mobile4", 12.123, 12.456);
            EmergencyCall call1 = new EmergencyCall("One description", "Cufre 1212", new Location(12.1234, 14.321), EmergencyCall.LOW,
                new DateTime(2019, 5, 3));
            EmergencyCall call2 = new EmergencyCall("Two description", "Gallinal 2312", new Location(30, 30), EmergencyCall.MEDIUM,
                new DateTime(2019, 5, 6));
            EmergencyCall call3 = new EmergencyCall("Three description", "Garibaldi 2134", new Location(54.11, 32.123), EmergencyCall.HIGH,
                new DateTime(2019, 4, 12));
            EmergencyCall call4 = new EmergencyCall("Four description", "Martinez 8732", new Location(67.98, -19.531), EmergencyCall.LOW,
                new DateTime(2019, 4, 23));
            EmergencyCall call5 = new EmergencyCall("Five description", "Joanico 921", new Location(-70, -70), EmergencyCall.HIGH,
                new DateTime(2019, 4, 30));
            EmergencyCall call6 = new EmergencyCall("Six description", "Fredo 874", new Location(87.1234, 45.214), EmergencyCall.MEDIUM,
                new DateTime(2019, 5, 1));
            EmergencyCall call7 = new EmergencyCall("Seven description", "8 de Octubre 921", new Location(35, 35), EmergencyCall.MEDIUM,
                new DateTime(2019, 4, 30));
            Services.AddEmergencyCallAndAssignItToMobile(call1);
            Services.AddEmergencyCallAndAssignItToMobile(call2);
            Services.AddEmergencyCallAndAssignItToMobile(call3);
            Services.AddEmergencyCallAndAssignItToMobile(call4);
            Services.AddEmergencyCallAndAssignItToMobile(call5);
            Services.AddEmergencyCallAndAssignItToMobile(call6);
            Services.AddEmergencyCallAndAssignItToMobile(call7);
            Assert.IsFalse(Services.GetMobileUnit("Mobile1").Available);
            Assert.IsFalse(Services.GetMobileUnit("Mobile2").Available);
            Assert.IsFalse(Services.GetMobileUnit("Mobile3").Available);
            Services.EmergencyCallSolved(call2.Id);
            Assert.AreEqual(Services.GetEmergencyCall(call2.Id).AssignMode, EmergencyCall.AssignModes.WaitTime);
            Assert.AreEqual(Services.GetEmergencyCall(call7.Id).Mobile.Name, Services.GetMobileUnit(Services.GetEmergencyCall(call2.Id).Mobile.Name).Name);
        }
    }
}
