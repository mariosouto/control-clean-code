using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Services;

namespace DomainTest
{
    [TestClass]
    public class ServiceStatisticsTest
    {
        [TestMethod]
        public void TestGetAverageAssignationTimeByService()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            MobileUnit oneMobile = new MobileUnit("oneMobile");
            Services.AddMobileUnit(oneMobile);
            EmergencyCall call1 = new EmergencyCall();
            call1.CreationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.Mobile = oneMobile;
            EmergencyCall call2 = new EmergencyCall();
            call2.CreationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.AssignationDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.Mobile = oneMobile;
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);            
            Assert.AreEqual(new TimeSpan(1, 30, 0), ServicesStatistics.AverageAssignationTime(Services.GetRepositoryEmergencyCalls()));
        }

        [TestMethod]
        public void TestGetAverageSolvedTime()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit oneMobile = new MobileUnit("oneMobile");
            Services.AddMobileUnit(oneMobile);
            call1.AssignationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.Solved = true;
            call1.Mobile = oneMobile;
            EmergencyCall call2 = new EmergencyCall();
            call2.AssignationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.Solved = true;
            call2.Mobile = oneMobile;
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);            
            Assert.AreEqual(new TimeSpan(1, 30, 0), ServicesStatistics.AverageSolvedTime(Services.GetRepositoryEmergencyCalls()));
        }

        [TestMethod]
        public void TestGetAverageTotalSolvedTime()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            EmergencyCall call1 = new EmergencyCall();
            call1.CreationDate = new DateTime(2019, 6, 10, 10, 30, 00);
            call1.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call1.Solved = true;
            EmergencyCall call2 = new EmergencyCall();
            call2.CreationDate = new DateTime(2019, 6, 10, 9, 30, 00);
            call2.SolvedDate = new DateTime(2019, 6, 10, 11, 30, 00);
            call2.Solved = true;
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);
            Assert.AreEqual(new TimeSpan(1, 30, 0), ServicesStatistics.AverageTotalSolvedTime(Services.GetRepositoryEmergencyCalls()));
        }

        [TestMethod]
        public void TestGetAverageAssignationTimeForOneMode()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit oneMobile = new MobileUnit("oneMobile");
            Services.AddMobileUnit(oneMobile);
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
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);
            Services.AddEmergencyCall(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), ServicesStatistics.AverageAssignationTime(Services.GetRepositoryEmergencyCalls(), EmergencyCall.AssignModes.WaitTime));
        }

        [TestMethod]
        public void TestGetAverageSolvedTimeForOneMode()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
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
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);
            Services.AddEmergencyCall(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), ServicesStatistics.AverageSolvedTime(Services.GetRepositoryEmergencyCalls(), EmergencyCall.AssignModes.WaitTime));
        }

        [TestMethod]
        public void TestGetAverageTotalSolvedTimeForOneMode()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
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
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);
            Services.AddEmergencyCall(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), ServicesStatistics.AverageTotalSolvedTime(Services.GetRepositoryEmergencyCalls(), EmergencyCall.AssignModes.WaitTime));
        }

        [TestMethod]
        public void TestGetAverageAssignationTimeForMobileUnit()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit mobile1 = new MobileUnit("Mobile1");
            MobileUnit mobile2 = new MobileUnit("Mobile2");
            Services.AddMobileUnit(mobile1);
            Services.AddMobileUnit(mobile2);
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
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);
            Services.AddEmergencyCall(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), ServicesStatistics.AverageAssignationTime(Services.GetRepositoryEmergencyCalls(), EmergencyCall.AssignModes.None, mobile1.Name));
        }

        [TestMethod]
        public void TestGetAverageAssignationTimeForMobileUnitAndAssignMode()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit mobile1 = new MobileUnit("Mobile1");
            MobileUnit mobile2 = new MobileUnit("Mobile2");
            Services.AddMobileUnit(mobile1);
            Services.AddMobileUnit(mobile2);
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
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);
            Services.AddEmergencyCall(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), ServicesStatistics.AverageAssignationTime(Services.GetRepositoryEmergencyCalls(), EmergencyCall.AssignModes.WaitTime, mobile1.Name));
        }

        [TestMethod]
        public void TestGetAverageSolvedTimeForMobileUnit()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit mobile1 = new MobileUnit("Mobile1");
            MobileUnit mobile2 = new MobileUnit("Mobile2");
            Services.AddMobileUnit(mobile1);
            Services.AddMobileUnit(mobile2);
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
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);
            Services.AddEmergencyCall(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), ServicesStatistics.AverageSolvedTime(Services.GetRepositoryEmergencyCalls(), EmergencyCall.AssignModes.None, mobile1.Name));
        }

        [TestMethod]
        public void TestGetAverageSolvedTimeForMobileUnitAndAssignMode()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit mobile1 = new MobileUnit("Mobile1");
            MobileUnit mobile2 = new MobileUnit("Mobile2");
            Services.AddMobileUnit(mobile1);
            Services.AddMobileUnit(mobile2);
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
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);
            Services.AddEmergencyCall(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), ServicesStatistics.AverageSolvedTime(Services.GetRepositoryEmergencyCalls(), EmergencyCall.AssignModes.WaitTime, mobile1.Name));
        }

        [TestMethod]
        public void TestGetAverageTotalSolvedTimeForMobileUnit()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit mobile1 = new MobileUnit("Mobile1");
            MobileUnit mobile2 = new MobileUnit("Mobile2");
            Services.AddMobileUnit(mobile1);
            Services.AddMobileUnit(mobile2);
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
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);
            Services.AddEmergencyCall(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), ServicesStatistics.AverageTotalSolvedTime(Services.GetRepositoryEmergencyCalls(), EmergencyCall.AssignModes.None, mobile1.Name));
        }

        [TestMethod]
        public void TestGetAverageTotalSolvedTimeForMobileUnitAndAssignMode()
        {
            Services.ClearEmergencyCalls();
            Services.ClearMobileUnits();
            EmergencyCall call1 = new EmergencyCall();
            MobileUnit mobile1 = new MobileUnit("Mobile1");
            MobileUnit mobile2 = new MobileUnit("Mobile2");
            Services.AddMobileUnit(mobile1);
            Services.AddMobileUnit(mobile2);
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
            Services.AddEmergencyCall(call1);
            Services.AddEmergencyCall(call2);
            Services.AddEmergencyCall(call3);
            Assert.AreEqual(new TimeSpan(1, 30, 0), ServicesStatistics.AverageTotalSolvedTime(Services.GetRepositoryEmergencyCalls(), EmergencyCall.AssignModes.WaitTime, mobile1.Name));
        }
    }
}
