using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class RepositoryEmergencyCallWithListTest
    {
        [TestMethod]
        public void TestAddEmergencyCallToList()
        {
            
            EmergencyCall call = new EmergencyCall();
            call.Description = "Interesting";
            RepositoryEmergencyCallWithList repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithList();
            repositoryOfEmergencyCalls.Add(call);
            Assert.AreEqual(repositoryOfEmergencyCalls.Count(), 1);
        }

        [TestMethod]
        public void TestGetEmergencyCallById()
        {
            RepositoryEmergencyCallWithList repository = new RepositoryEmergencyCallWithList();
            EmergencyCall call = new EmergencyCall("OneDescription","Address",new Location(),EmergencyCall.HIGH,DateTime.Now);
            repository.Add(call);
            Assert.AreEqual(call.Id, repository.GetEmergencyCall(call.Id).Id);
        }

        [TestMethod]
        public void TestClearEmergencyCalls()
        {
            RepositoryEmergencyCallWithList repository = new RepositoryEmergencyCallWithList();
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
            RepositoryEmergencyCallWithList repository = new RepositoryEmergencyCallWithList();
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
            RepositoryEmergencyCallWithList repository = new RepositoryEmergencyCallWithList();
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
            RepositoryEmergencyCallWithList repository = new RepositoryEmergencyCallWithList();
            EmergencyCall call1 = new EmergencyCall("OneDescription", "Address", new Location(), EmergencyCall.HIGH, DateTime.Now);
            EmergencyCall call2 = new EmergencyCall("TwoDescription", "Address", new Location(), EmergencyCall.MEDIUM, DateTime.Now);
            EmergencyCall call3 = new EmergencyCall("ThreeDescription", "Address", new Location(), EmergencyCall.LOW, DateTime.Now);
            MobileUnit mobile1 = new MobileUnit("OneName");
            call2.Solved = true;
            call3.Solved = true;
            repository.Add(call1);
            repository.Add(call2);
            repository.Add(call3);
            repository.SetMobileToAnEmergencyCall(call1.Id, mobile1);
            repository.SetMobileToAnEmergencyCall(call2.Id, mobile1);
            repository.SetMobileToAnEmergencyCall(call3.Id, mobile1);          
            Assert.IsTrue(repository.IsMobileUnitIsAssociatedToAny("OneName"));
            Assert.AreEqual(call1.Id, repository.GetEmergencyCallUnsolvedAssignedToUnit("OneName").Id);
        }

        [TestMethod]
        public void TestSetEmergencyCallAsSolved()
        {
            RepositoryEmergencyCallWithList repository = new RepositoryEmergencyCallWithList();
            EmergencyCall call1 = new EmergencyCall("OneDescription", "Address", new Location(), EmergencyCall.HIGH, DateTime.Now);
            EmergencyCall call2 = new EmergencyCall("TwoDescription", "Address", new Location(), EmergencyCall.MEDIUM, DateTime.Now);
            EmergencyCall call3 = new EmergencyCall("ThreeDescription", "Address", new Location(), EmergencyCall.LOW, DateTime.Now);
            repository.Add(call1);
            repository.Add(call2);
            repository.Add(call3);
            DateTime now = DateTime.Now;
            repository.SetEmergencyCallAsSolved(call1.Id, now);
            Assert.IsTrue(repository.GetEmergencyCall(call1.Id).Solved);
            Assert.AreEqual(now, repository.GetEmergencyCall(call1.Id).SolvedDate);
        }

        [TestMethod]
        public void TestSetAssignMode()
        {
            RepositoryEmergencyCallWithList repository = new RepositoryEmergencyCallWithList();
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
            RepositoryEmergencyCallWithList repository = new RepositoryEmergencyCallWithList();
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
            RepositoryEmergencyCallWithList repository = new RepositoryEmergencyCallWithList();
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
