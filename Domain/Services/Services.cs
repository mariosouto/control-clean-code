using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain.Services
{
    public static class Services
    {
        private static IRepositoryMobileUnit repositoryOfMobileUnits;

        private static IRepositoryEmergencyCall repositoryOfEmergencyCalls;

        private static EmergencyCall.AssignModes actualAssignMode = EmergencyCall.AssignModes.Default;

        static Services()
        {
            //repositoryOfMobileUnits = new RepositoryMobileUnitWithList();
            //repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithList();
            repositoryOfMobileUnits = new RepositoryMobileUnitWithDataBase();
            repositoryOfEmergencyCalls = new RepositoryEmergencyCallWithDataBase();
        }

        public static void AddMobileUnit(MobileUnit mobileUnit)
        {
            repositoryOfMobileUnits.Add(mobileUnit);
            checkIfEmergencyCallNeedAttendance(mobileUnit);
        }

        public static void AddMobileUnit(String name, String plate, String description)
        {
            repositoryOfMobileUnits.Add(new MobileUnit(name, plate, description));
            MobileUnit mobileUnit = repositoryOfMobileUnits.GetMobile(name);
            checkIfEmergencyCallNeedAttendance(mobileUnit);
        }


        public static void checkIfEmergencyCallNeedAttendance(MobileUnit mobileUnit)
        {
            EmergencyCall callToAssign = null;
            switch (Services.actualAssignMode)
            {
                case EmergencyCall.AssignModes.Default:
                    callToAssign = repositoryOfEmergencyCalls.GetEmergencyCallWithMostPriorityToBeSolved();
                    if (callToAssign != null)
                    {
                        callToAssign.AssignMode = EmergencyCall.AssignModes.Default;
                        callToAssign.AssignationDate = DateTime.Now;
                    }
                    break;
                case EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls:
                    callToAssign = repositoryOfEmergencyCalls.GetEmergencyCallWithMostPriorityToBeSolved();
                    if (callToAssign != null)
                    {
                        callToAssign.AssignMode = EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls;
                        callToAssign.AssignationDate = DateTime.Now;
                    }
                    break;
                case EmergencyCall.AssignModes.WaitTime:
                    callToAssign = repositoryOfEmergencyCalls.GetEmergencyCallWithMostWaitTimeToBeSolved(mobileUnit.Location);
                    if (callToAssign != null)
                    {
                        callToAssign.AssignMode = EmergencyCall.AssignModes.WaitTime;
                        callToAssign.AssignationDate = DateTime.Now;
                    }
                    break;
                default:
                    break;
            }
            if (callToAssign != null)
            {
                repositoryOfMobileUnits.SetMobileNotAvailable(mobileUnit.Name);
                repositoryOfEmergencyCalls.SetMobileToAnEmergencyCall(callToAssign.Id, mobileUnit);
                repositoryOfEmergencyCalls.SetAssignModeToAnEmergencyCall(callToAssign.Id, callToAssign.AssignMode);
            }
        }

        public static MobileUnit GetMobileUnit(String nameOfMobileUnit)
        {
            return repositoryOfMobileUnits.GetMobile(nameOfMobileUnit);
        }

        public static void DeleteMobileUnitByName(String nameOfMobileUnit)
        {
            if (repositoryOfEmergencyCalls.IsMobileUnitIsAssociatedToAny(nameOfMobileUnit))
            {
                throw new InvalidDeleteMobileUnitException("It's not possible to delete this Mobile Unit " +
            "because it is on an Emergency Call.");
            }
            repositoryOfMobileUnits.Delete(nameOfMobileUnit);
        }

        public static bool ExistsMobileUnit(String nameOfMobileUnit)
        {
            return repositoryOfMobileUnits.Exists(nameOfMobileUnit);
        }

        public static int CountMobileUnits()
        {
            return repositoryOfMobileUnits.Count();
        }

        public static void ClearMobileUnits()
        {
            repositoryOfMobileUnits.Clear();
        }

        public static void AddEmergencyCall(EmergencyCall oneEmergencyCall)
        {
            repositoryOfEmergencyCalls.Add(oneEmergencyCall);
        }

        public static int CountEmergencyCalls()
        {
            return repositoryOfEmergencyCalls.Count();
        }

        public static String[] GetNamesOfMobileUnits()
        {
            return repositoryOfMobileUnits.GetNames();
        }

        public static void ModifyMobileUnitByName(String oldName, String newName, String newPlate, String newDescription)
        {
            repositoryOfMobileUnits.ModifyMobileUnitByName(oldName, newName, newPlate, newDescription);
        }

        public static void SetCoordinatesToMobile(String name, double longitude, double latitude)
        {
            repositoryOfMobileUnits.SetCoordinatesToMobile(name, longitude, latitude);
        }

        public static Location GetLocationOfMobileUnitByName(String name)
        {
            return repositoryOfMobileUnits.GetLocation(name);
        }

        public static EmergencyCall GetEmergencyCall(int idOfEmergencyCall)
        {
            return repositoryOfEmergencyCalls.GetEmergencyCall(idOfEmergencyCall);
        }

        public static void EmergencyCallSolved(int idOfEmergencyCall)
        {
            if (!Services.GetEmergencyCall(idOfEmergencyCall).Solved)
            {
                MobileUnit mobileNowFree = repositoryOfMobileUnits.GetMobile(repositoryOfEmergencyCalls.GetEmergencyCall(idOfEmergencyCall).Mobile.Name);
                EmergencyCall emergencyCallSolved = Services.GetEmergencyCall(idOfEmergencyCall);
                repositoryOfMobileUnits.SetMobileAvailable(emergencyCallSolved.Mobile.Name);
                repositoryOfMobileUnits.SetCoordinatesToMobile(mobileNowFree.Name, emergencyCallSolved.Location.Longitude, emergencyCallSolved.Location.Latitude);
                repositoryOfEmergencyCalls.SetEmergencyCallAsSolved(idOfEmergencyCall, DateTime.Now);
                EmergencyCall callToAssign = null;
                switch (Services.actualAssignMode)
                {
                    case EmergencyCall.AssignModes.Default:
                        callToAssign = repositoryOfEmergencyCalls.GetEmergencyCallWithMostPriorityToBeSolved();
                        if (callToAssign != null)
                        {
                            callToAssign.AssignMode = EmergencyCall.AssignModes.Default;
                            callToAssign.AssignationDate = DateTime.Now;
                        }
                        break;
                    case EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls:
                        callToAssign = repositoryOfEmergencyCalls.GetEmergencyCallWithMostPriorityToBeSolved();
                        if (callToAssign != null)
                        {
                            callToAssign.AssignMode = EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls;
                            callToAssign.AssignationDate = DateTime.Now;
                        }
                        break;
                    case EmergencyCall.AssignModes.WaitTime:
                        callToAssign = repositoryOfEmergencyCalls.GetEmergencyCallWithMostWaitTimeToBeSolved(emergencyCallSolved.Location);
                        if (callToAssign != null)
                        {
                            callToAssign.AssignMode = EmergencyCall.AssignModes.WaitTime;
                            callToAssign.AssignationDate = DateTime.Now;
                        }
                        break;
                    default:
                        break;
                }
                if (callToAssign != null)
                {
                    repositoryOfMobileUnits.SetMobileNotAvailable(emergencyCallSolved.Mobile.Name);
                    repositoryOfEmergencyCalls.SetMobileToAnEmergencyCall(callToAssign.Id, mobileNowFree);
                    repositoryOfEmergencyCalls.SetAssignModeToAnEmergencyCall(callToAssign.Id, callToAssign.AssignMode);
                }
            }
        }

        public static void EmergencyCallSolvedInDate(int idOfEmergencyCall, DateTime dateOfSolved)
        {
            repositoryOfEmergencyCalls.SetEmergencyCallAsSolved(idOfEmergencyCall, dateOfSolved);
            repositoryOfMobileUnits.SetMobileAvailable(repositoryOfEmergencyCalls.GetEmergencyCall(idOfEmergencyCall).Mobile.Name);
            repositoryOfMobileUnits.SetCoordinatesToMobile(repositoryOfEmergencyCalls.GetEmergencyCall(idOfEmergencyCall).Mobile.Name, repositoryOfEmergencyCalls.GetEmergencyCall(idOfEmergencyCall).Location.Longitude, repositoryOfEmergencyCalls.GetEmergencyCall(idOfEmergencyCall).Location.Latitude);
        }

        public static void ClearEmergencyCalls()
        {
            repositoryOfEmergencyCalls.Clear();
        }

        public static EmergencyCall[] GetArrayOfEmergencyCalls()
        {
            return repositoryOfEmergencyCalls.GetEmergencyCalls();
        }

        public static MobileUnit[] GetMobileUnits()
        {
            return repositoryOfMobileUnits.GetMobileUnits();
        }

        public static EmergencyCall GetEmergencyCallUnsolvedAssignedToUnit(String nameOfMobileUnit)
        {
            return repositoryOfEmergencyCalls.GetEmergencyCallUnsolvedAssignedToUnit(nameOfMobileUnit);
        }

        public static void SetAssignMode(EmergencyCall.AssignModes oneMode)
        {
            actualAssignMode = oneMode;
        }

        public static void AddEmergencyCallAndAssignItToMobile(EmergencyCall call)
        {
            switch (actualAssignMode)
            {
                case EmergencyCall.AssignModes.Default:
                    Services.AddEmergencyCallAndAssignItByDefaultMode(call);
                    repositoryOfEmergencyCalls.SetAssignModeToAnEmergencyCall(call.Id, EmergencyCall.AssignModes.Default);
                    break;
                case EmergencyCall.AssignModes.WaitTime:
                    Services.AddEmergencyCallAndAssignItByWaitTimeMode(call);
                    repositoryOfEmergencyCalls.SetAssignModeToAnEmergencyCall(call.Id, EmergencyCall.AssignModes.WaitTime);
                    break;
                case EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls:
                    Services.AddEmergencyCallAndAssignItByNumberOfSolvedEmergencyCallsMode(call);
                    repositoryOfEmergencyCalls.SetAssignModeToAnEmergencyCall(call.Id, EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls);
                    break;
                default:
                    break;
            }
        }

        private static void AddEmergencyCallAndAssignItByDefaultMode(EmergencyCall call)
        {
            MobileUnit nearestMobileUnit = repositoryOfMobileUnits.GetNearestAvailable(call.Location);
            if (nearestMobileUnit != null)
            {
                call.Mobile = nearestMobileUnit;
                call.AssignMode = EmergencyCall.AssignModes.Default;
                call.AssignationDate = DateTime.Now;
                nearestMobileUnit.Available = false;
            }
            repositoryOfEmergencyCalls.Add(call);
        }

        private static void AddEmergencyCallAndAssignItByNumberOfSolvedEmergencyCallsMode(EmergencyCall call)
        {
            if (!(repositoryOfMobileUnits.IsMoreThanOneAvailable()))
            {
                MobileUnit nearestMobileUnit = repositoryOfMobileUnits.GetNearestAvailable(call.Location);
                if (nearestMobileUnit != null)
                {
                    call.Mobile = nearestMobileUnit;
                    call.AssignMode = EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls;
                    call.AssignationDate = DateTime.Now;
                    nearestMobileUnit.Available = false;
                }
                repositoryOfEmergencyCalls.Add(call); ;
            }
            else
            {
                MobileUnit mobileToAssign = repositoryOfMobileUnits.GetFewestEmergencyCallsSolved(call.Location, repositoryOfEmergencyCalls.GetEmergencyCalls(), repositoryOfMobileUnits.GetMobileUnits());
                if (mobileToAssign != null)
                {
                    call.Mobile = mobileToAssign;
                    call.AssignMode = EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls;
                    call.AssignationDate = DateTime.Now;
                    mobileToAssign.Available = false;
                }
                repositoryOfEmergencyCalls.Add(call);
            }
        }

        private static void AddEmergencyCallAndAssignItByWaitTimeMode(EmergencyCall call)
        {
            MobileUnit nearestMobileUnit = repositoryOfMobileUnits.GetNearestAvailable(call.Location);
            if (nearestMobileUnit != null)
            {
                call.Mobile = nearestMobileUnit;
                call.AssignMode = EmergencyCall.AssignModes.WaitTime;
                call.AssignationDate = DateTime.Now;
                nearestMobileUnit.Available = false;
            }
            repositoryOfEmergencyCalls.Add(call);
        }

        public static IRepositoryEmergencyCall GetRepositoryEmergencyCalls()
        {
            return repositoryOfEmergencyCalls;
        }
    }
}