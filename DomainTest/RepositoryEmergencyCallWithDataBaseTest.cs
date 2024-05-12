using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class RepositoryEmergencyCallWithDatabaseTest
    {
        [TestMethod]
        public void TestAddEmergencyCallToList()
        {
            
            EmergencyCall call = new EmergencyCall();
            call.Description = "Interesting";
            RepositoryEmergencyCallWithDataBase repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
            repositoryOfEmergencyCalls.Clear();
            repositoryOfEmergencyCalls.Add(call);
            Assert.AreEqual(repositoryOfEmergencyCalls.Count(), 1);
        }

        [TestMethod]
        public void TestGetEmergencyCallById()
        {
            RepositoryEmergencyCallWithDataBase repository = new RepositoryEmergencyCallWithDataBase();
            EmergencyCall call = new EmergencyCall("OneDescription","Address",new Location(), EmergencyCall.HIGH, DateTime.Now);
            repository.Add(call);
            Assert.AreEqual(call.Id, repository.GetEmergencyCall(call.Id).Id);
        }

        [TestMethod]
        public void TestClearEmergencyCalls()
        {
            RepositoryEmergencyCallWithDataBase repository = new RepositoryEmergencyCallWithDataBase();
            EmergencyCall call1 = new EmergencyCall("OneDescription", "Address", new Location(), EmergencyCall.HIGH, DateTime.Now);
            EmergencyCall call2 = new EmergencyCall("TwoDescription", "Address", new Location(), EmergencyCall.HIGH, DateTime.Now);
            EmergencyCall call3 = new EmergencyCall("ThreeDescription", "Address", new Location(), EmergencyCall.HIGH, DateTime.Now);
            repository.Add(call1);
            repository.Add(call2);
            repository.Add(call3);
            repository.Clear();
            Assert.AreEqual(repository.Count(),0);
        }

        [TestMethod]
        public void TestLookForEmergencyCallMostPriorityToSolved()
        {
            RepositoryEmergencyCallWithDataBase repository = new RepositoryEmergencyCallWithDataBase();
            EmergencyCall call1 = new EmergencyCall("OneDescription", "Address", new Location(), EmergencyCall.HIGH, DateTime.Now);
            EmergencyCall call2 = new EmergencyCall("TwoDescription", "Address", new Location(), EmergencyCall.MEDIUM, DateTime.Now);
            EmergencyCall call3 = new EmergencyCall("ThreeDescription", "Address", new Location(), EmergencyCall.LOW, DateTime.Now);
            call1.Solved = true;
            call2.Solved = true;
            repository.Add(call1);
            repository.Add(call2);
            repository.Add(call3);
            Assert.AreEqual(call3.Id, repository.GetEmergencyCallWithMostPriorityToBeSolved().Id);
        }

        [TestMethod]
        public void TestGetArrayOfEmergencyCall()
        {
            RepositoryEmergencyCallWithDataBase repository = new RepositoryEmergencyCallWithDataBase();
            EmergencyCall call1 = new EmergencyCall("OneDescription", "Address", new Location(), EmergencyCall.HIGH, DateTime.Now);
            EmergencyCall call2 = new EmergencyCall("TwoDescription", "Address", new Location(), EmergencyCall.MEDIUM, DateTime.Now);
            EmergencyCall call3 = new EmergencyCall("ThreeDescription", "Address", new Location(), EmergencyCall.LOW, DateTime.Now);
            repository.Add(call1);
            repository.Add(call2);
            repository.Add(call3);
            EmergencyCall[] arrayCalls = repository.GetEmergencyCalls();
            Assert.IsTrue(Array.Exists(arrayCalls, element => element.Id == call1.Id));
            Assert.IsTrue(Array.Exists(arrayCalls, element => element.Id == call2.Id));
            Assert.IsTrue(Array.Exists(arrayCalls, element => element.Id == call3.Id));
        }

        [TestMethod]
        public void TestCheckIfEmergencyCallIsAssociatedToMobileUnit()
        {
            RepositoryEmergencyCallWithDataBase repositoryCalls = new RepositoryEmergencyCallWithDataBase();
            RepositoryMobileUnitWithDataBase repositoryMobiles = new RepositoryMobileUnitWithDataBase();
            repositoryCalls.Clear();
            repositoryMobiles.Clear();
            EmergencyCall call1 = new EmergencyCall("OneDescription", "Address", new Location(), EmergencyCall.HIGH, DateTime.Now);
            EmergencyCall call2 = new EmergencyCall("TwoDescription", "Address", new Location(), EmergencyCall.MEDIUM, DateTime.Now);
            EmergencyCall call3 = new EmergencyCall("ThreeDescription", "Address", new Location(), EmergencyCall.LOW, DateTime.Now);
            MobileUnit mobile1 = new MobileUnit("OneName");
            repositoryMobiles.Add(mobile1);
            call2.Solved = true;
            call3.Solved = true;
            repositoryCalls.Add(call1);
            repositoryCalls.Add(call2);
            repositoryCalls.Add(call3);
            repositoryCalls.SetMobileToAnEmergencyCall(call1.Id, mobile1);
            repositoryCalls.SetMobileToAnEmergencyCall(call2.Id, mobile1);
            repositoryCalls.SetMobileToAnEmergencyCall(call3.Id, mobile1);          
            Assert.IsTrue(repositoryCalls.IsMobileUnitIsAssociatedToAny("OneName"));
            Assert.AreEqual(call1.Id, repositoryCalls.GetEmergencyCallUnsolvedAssignedToUnit("OneName").Id);
        }

        [TestMethod]
        public void TestSetEmergencyCallAsSolved()
        {
            RepositoryEmergencyCallWithDataBase repository = new RepositoryEmergencyCallWithDataBase();
            repository.Clear();
            EmergencyCall call1 = new EmergencyCall("OneDescription", "Address", new Location(), EmergencyCall.HIGH, DateTime.Now);
            EmergencyCall call2 = new EmergencyCall("TwoDescription", "Address", new Location(), EmergencyCall.MEDIUM, DateTime.Now);
            EmergencyCall call3 = new EmergencyCall("ThreeDescription", "Address", new Location(), EmergencyCall.LOW, DateTime.Now);
            repository.Add(call1);
            repository.Add(call2);
            repository.Add(call3);
            DateTime now = DateTime.Now;
            repository.SetEmergencyCallAsSolved(call1.Id, now);
            Assert.IsTrue(repository.GetEmergencyCall(call1.Id).Solved);
        }

        [TestMethod]
        public void TestSetAssignMode()
        {
            RepositoryEmergencyCallWithDataBase repository = new RepositoryEmergencyCallWithDataBase();
            EmergencyCall call1 = new EmergencyCall("OneDescription", "Address", new Location(), EmergencyCall.HIGH, DateTime.Now);
            EmergencyCall call2 = new EmergencyCall("TwoDescription", "Address", new Location(), EmergencyCall.MEDIUM, DateTime.Now);
            EmergencyCall call3 = new EmergencyCall("ThreeDescription", "Address", new Location(), EmergencyCall.LOW, DateTime.Now);
            repository.Add(call1);
            repository.Add(call2);
            repository.Add(call3);
            repository.SetAssignModeToAnEmergencyCall(call1.Id, EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls);
            Assert.AreEqual(EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls, repository.GetEmergencyCall(call1.Id).AssignMode);
        }

        [TestMethod]
        public void TestGetEmergencyCallMostTime()
        {
            RepositoryEmergencyCallWithDataBase repository = new RepositoryEmergencyCallWithDataBase();
            EmergencyCall call1 = new EmergencyCall("OneDescription", "Address", new Location(), EmergencyCall.HIGH, DateTime.Now);
            EmergencyCall call2 = new EmergencyCall("TwoDescription", "Address", new Location(), EmergencyCall.MEDIUM, DateTime.Now);
            EmergencyCall call3 = new EmergencyCall("ThreeDescription", "Address", new Location(), EmergencyCall.LOW, DateTime.Now);
            call1.CreationDate = new DateTime(2019, 6, 12);
            call2.CreationDate = new DateTime(2019, 6, 6);
            call3.CreationDate = new DateTime(2019, 6, 1);
            repository.Add(call1);
            repository.Add(call2);
            repository.Add(call3);
            Assert.AreEqual(call3.Id, repository.GetEmergencyCallWithMostWaitTimeToBeSolved(new Location(1,1)).Id);
        }

        [TestMethod]
        public void TestGetEmergencyCallMostTimeWithTwoWithSameTime()
        {
            RepositoryEmergencyCallWithDataBase repository = new RepositoryEmergencyCallWithDataBase();
            repository.Clear();
            EmergencyCall call1 = new EmergencyCall("OneDescription", "Address", new Location(), EmergencyCall.HIGH, DateTime.Now);
            EmergencyCall call2 = new EmergencyCall("TwoDescription", "Address", new Location(), EmergencyCall.MEDIUM, DateTime.Now);
            EmergencyCall call3 = new EmergencyCall("ThreeDescription", "Address", new Location(), EmergencyCall.LOW, DateTime.Now);
            call1.CreationDate = new DateTime(2019, 6, 12);
            call2.CreationDate = new DateTime(2019, 6, 6);
            call3.CreationDate = new DateTime(2019, 6, 6);
            call2.Location = new Location(50, -50);
            call3.Location = new Location(11, 11);
            repository.Add(call1);
            repository.Add(call2);
            repository.Add(call3);
            Assert.AreEqual(call3.Id, repository.GetEmergencyCallWithMostWaitTimeToBeSolved(new Location(10, 10)).Id);
        }
    }
}
