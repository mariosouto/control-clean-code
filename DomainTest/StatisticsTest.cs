using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTest
{
    [TestClass]
    public class StatisticsTest
    {
        [TestMethod]
        public void TestGetAverageAssignationTime()
        {
            IRepositoryEmergencyCall repositoryOfCalls = new RepositoryEmergencyCallWithList();
            MobileUnit oneMobile = new MobileUnit("oneMobile");
            EmergencyCall call1 = new EmergencyCall();
            call1.CreationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.Mobile = oneMobile;
            EmergencyCall call2 = new EmergencyCall();
            call2.CreationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.Mobile = oneMobile;
            repositoryOfCalls.Add(call1);
            repositoryOfCalls.Add(call2);
            Assert.AreEqual(new TimeSpan(1, 30, 0), Statistics.AverageAssignationTime(repositoryOfCalls));
        }

        [TestMethod]
        public void TestGetAverageSolvedTime()
        {
            IRepositoryEmergencyCall repositoryOfCalls = new RepositoryEmergencyCallWithList();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit oneMobile = new MobileUnit("oneMobile");
            call1.AssignationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.Solved = true;
            call1.Mobile = oneMobile;
            EmergencyCall call2 = new EmergencyCall();
            call2.AssignationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.Solved = true;
            call2.Mobile = oneMobile;
            repositoryOfCalls.Add(call1);
            repositoryOfCalls.Add(call2);
            Assert.AreEqual(new TimeSpan(1, 30, 0), Statistics.AverageSolvedTime(repositoryOfCalls));
        }

        [TestMethod]
        public void TestGetAverageTotalSolvedTime()
        {
            IRepositoryEmergencyCall repositoryOfCalls = new RepositoryEmergencyCallWithList();
            EmergencyCall call1 = new EmergencyCall();
            call1.CreationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.Solved = true;
            EmergencyCall call2 = new EmergencyCall();
            call2.CreationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.Solved = true;
            repositoryOfCalls.Add(call1);
            repositoryOfCalls.Add(call2);
            Assert.AreEqual(new TimeSpan(1, 30, 0), Statistics.AverageTotalSolvedTime(repositoryOfCalls));
        }

        [TestMethod]
        public void TestGetAverageAssignationTimeForOneMode()
        {
            IRepositoryEmergencyCall repositoryOfCalls = new RepositoryEmergencyCallWithList();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit oneMobile = new MobileUnit("oneMobile");
            call1.CreationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.AssignMode = EmergencyCall.AssignModes.WaitTime;
            call1.Mobile = oneMobile;
            EmergencyCall call2 = new EmergencyCall();
            call2.CreationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.AssignMode = EmergencyCall.AssignModes.WaitTime;
            call2.Mobile = oneMobile;
            EmergencyCall call3 = new EmergencyCall();
            call3.CreationDate = new DateTime(2019, 6, 10, 8, 30, 00);
            call3.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call3.AssignMode = EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls;
            call3.Mobile = oneMobile;
            repositoryOfCalls.Add(call1);
            repositoryOfCalls.Add(call2);
            repositoryOfCalls.Add(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), Statistics.AverageAssignationTime(repositoryOfCalls, EmergencyCall.AssignModes.WaitTime));
        }

        [TestMethod]
        public void TestGetAverageSolvedTimeForOneMode()
        {
            IRepositoryEmergencyCall repositoryOfCalls = new RepositoryEmergencyCallWithList();
            EmergencyCall call1 = new EmergencyCall();
            call1.AssignationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.AssignMode = EmergencyCall.AssignModes.WaitTime;
            call1.Solved = true;
            EmergencyCall call2 = new EmergencyCall();
            call2.AssignationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.AssignMode = EmergencyCall.AssignModes.WaitTime;
            call2.Solved = true;
            EmergencyCall call3 = new EmergencyCall();
            call3.AssignationDate = new DateTime(2019, 6, 10, 8, 30, 00);
            call3.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call3.AssignMode = EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls;
            call3.Solved = true;
            repositoryOfCalls.Add(call1);
            repositoryOfCalls.Add(call2);
            repositoryOfCalls.Add(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), Statistics.AverageSolvedTime(repositoryOfCalls, EmergencyCall.AssignModes.WaitTime));
        }

        [TestMethod]
        public void TestGetAverageTotalSolvedTimeForOneMode()
        {
            IRepositoryEmergencyCall repositoryOfCalls = new RepositoryEmergencyCallWithList();
            EmergencyCall call1 = new EmergencyCall();
            call1.CreationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.AssignMode = EmergencyCall.AssignModes.WaitTime;
            call1.Solved = true;
            EmergencyCall call2 = new EmergencyCall();
            call2.CreationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.AssignMode = EmergencyCall.AssignModes.WaitTime;
            call2.Solved = true;
            EmergencyCall call3 = new EmergencyCall();
            call3.CreationDate = new DateTime(2019, 6, 10, 8, 30, 00);
            call3.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call3.AssignMode = EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls;
            call3.Solved = true;
            repositoryOfCalls.Add(call1);
            repositoryOfCalls.Add(call2);
            repositoryOfCalls.Add(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), Statistics.AverageTotalSolvedTime(repositoryOfCalls, EmergencyCall.AssignModes.WaitTime));
        }

        [TestMethod]
        public void TestGetAverageAssignationTimeForMobileUnit()
        {
            IRepositoryEmergencyCall repositoryOfCalls = new RepositoryEmergencyCallWithList();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit mobile1 = new MobileUnit("Mobile1");
            MobileUnit mobile2 = new MobileUnit("Mobile2");
            call1.CreationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.Mobile = mobile1;
            EmergencyCall call2 = new EmergencyCall();
            call2.CreationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.Mobile = mobile1;
            EmergencyCall call3 = new EmergencyCall();
            call3.CreationDate = new DateTime(2019, 6, 10, 8, 30, 00);
            call3.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call3.Mobile = mobile2;
            repositoryOfCalls.Add(call1);
            repositoryOfCalls.Add(call2);
            repositoryOfCalls.Add(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), Statistics.AverageAssignationTime(repositoryOfCalls, EmergencyCall.AssignModes.None, mobile1.Name));
        }

        [TestMethod]
        public void TestGetAverageAssignationTimeForMobileUnitAndAssignMode()
        {
            IRepositoryEmergencyCall repositoryOfCalls = new RepositoryEmergencyCallWithList();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit mobile1 = new MobileUnit("Mobile1");
            MobileUnit mobile2 = new MobileUnit("Mobile2");
            call1.CreationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.Mobile = mobile1;
            call1.AssignMode = EmergencyCall.AssignModes.WaitTime;
            EmergencyCall call2 = new EmergencyCall();
            call2.CreationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.Mobile = mobile1;
            call2.AssignMode = EmergencyCall.AssignModes.WaitTime;
            EmergencyCall call3 = new EmergencyCall();
            call3.CreationDate = new DateTime(2019, 6, 10, 8, 30, 00);
            call3.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call3.Mobile = mobile1;
            call3.AssignMode = EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls;
            EmergencyCall call4 = new EmergencyCall();
            call4.CreationDate = new DateTime(2019, 6, 10, 7, 30, 00);
            call4.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call4.Mobile = mobile2;
            call4.AssignMode = EmergencyCall.AssignModes.WaitTime;
            repositoryOfCalls.Add(call1);
            repositoryOfCalls.Add(call2);
            repositoryOfCalls.Add(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), Statistics.AverageAssignationTime(repositoryOfCalls, EmergencyCall.AssignModes.WaitTime, mobile1.Name));
        }

        [TestMethod]
        public void TestGetAverageSolvedTimeForMobileUnit()
        {
            IRepositoryEmergencyCall repositoryOfCalls = new RepositoryEmergencyCallWithList();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit mobile1 = new MobileUnit("Mobile1");
            MobileUnit mobile2 = new MobileUnit("Mobile2");
            call1.AssignationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.Mobile = mobile1;
            call1.Solved = true;
            EmergencyCall call2 = new EmergencyCall();
            call2.AssignationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.Mobile = mobile1;
            call2.Solved = true;
            EmergencyCall call3 = new EmergencyCall();
            call3.AssignationDate = new DateTime(2019, 6, 10, 8, 30, 00);
            call3.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call3.Mobile = mobile2;
            call3.Solved = true;
            repositoryOfCalls.Add(call1);
            repositoryOfCalls.Add(call2);
            repositoryOfCalls.Add(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), Statistics.AverageSolvedTime(repositoryOfCalls, EmergencyCall.AssignModes.None, mobile1.Name));
        }

        [TestMethod]
        public void TestGetAverageSolvedTimeForMobileUnitAndAssignMode()
        {
            IRepositoryEmergencyCall repositoryOfCalls = new RepositoryEmergencyCallWithList();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit mobile1 = new MobileUnit("Mobile1");
            MobileUnit mobile2 = new MobileUnit("Mobile2");
            call1.AssignationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.Mobile = mobile1;
            call1.AssignMode = EmergencyCall.AssignModes.WaitTime;
            call1.Solved = true;
            EmergencyCall call2 = new EmergencyCall();
            call2.AssignationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.Mobile = mobile1;
            call2.AssignMode = EmergencyCall.AssignModes.WaitTime;
            call2.Solved = true;
            EmergencyCall call3 = new EmergencyCall();
            call3.AssignationDate = new DateTime(2019, 6, 10, 8, 30, 00);
            call3.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call3.Mobile = mobile1;
            call3.AssignMode = EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls;
            call3.Solved = true;
            EmergencyCall call4 = new EmergencyCall();
            call4.AssignationDate = new DateTime(2019, 6, 10, 7, 30, 00);
            call4.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call4.Mobile = mobile2;
            call4.AssignMode = EmergencyCall.AssignModes.WaitTime;
            repositoryOfCalls.Add(call1);
            repositoryOfCalls.Add(call2);
            repositoryOfCalls.Add(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), Statistics.AverageSolvedTime(repositoryOfCalls, EmergencyCall.AssignModes.WaitTime, mobile1.Name));
        }

        [TestMethod]
        public void TestGetAverageTotalSolvedTimeForMobileUnit()
        {
            IRepositoryEmergencyCall repositoryOfCalls = new RepositoryEmergencyCallWithList();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit mobile1 = new MobileUnit("Mobile1");
            MobileUnit mobile2 = new MobileUnit("Mobile2");
            call1.CreationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.Mobile = mobile1;
            call1.Solved = true;
            EmergencyCall call2 = new EmergencyCall();
            call2.CreationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.Mobile = mobile1;
            call2.Solved = true;
            EmergencyCall call3 = new EmergencyCall();
            call3.CreationDate = new DateTime(2019, 6, 10, 8, 30, 00);
            call3.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call3.Mobile = mobile2;
            call3.Solved = true;
            repositoryOfCalls.Add(call1);
            repositoryOfCalls.Add(call2);
            repositoryOfCalls.Add(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), Statistics.AverageTotalSolvedTime(repositoryOfCalls, EmergencyCall.AssignModes.None, mobile1.Name));
        }

        [TestMethod]
        public void TestGetAverageTotalSolvedTimeForMobileUnitAndAssignMode()
        {
            IRepositoryEmergencyCall repositoryOfCalls = new RepositoryEmergencyCallWithList();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit mobile1 = new MobileUnit("Mobile1");
            MobileUnit mobile2 = new MobileUnit("Mobile2");
            call1.CreationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.Mobile = mobile1;
            call1.AssignMode = EmergencyCall.AssignModes.WaitTime;
            call1.Solved = true;
            EmergencyCall call2 = new EmergencyCall();
            call2.CreationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.Mobile = mobile1;
            call2.AssignMode = EmergencyCall.AssignModes.WaitTime;
            call2.Solved = true;
            EmergencyCall call3 = new EmergencyCall();
            call3.CreationDate = new DateTime(2019, 6, 10, 8, 30, 00);
            call3.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call3.Mobile = mobile1;
            call3.AssignMode = EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls;
            call3.Solved = true;
            EmergencyCall call4 = new EmergencyCall();
            call4.CreationDate = new DateTime(2019, 6, 10, 7, 30, 00);
            call4.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call4.Mobile = mobile2;
            call4.AssignMode = EmergencyCall.AssignModes.WaitTime;
            call4.Solved = true;
            repositoryOfCalls.Add(call1);
            repositoryOfCalls.Add(call2);
            repositoryOfCalls.Add(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), Statistics.AverageTotalSolvedTime(repositoryOfCalls, EmergencyCall.AssignModes.WaitTime, mobile1.Name));
        }
    }
}
