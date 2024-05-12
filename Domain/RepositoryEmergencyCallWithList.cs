using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RepositoryEmergencyCallWithList : IRepositoryEmergencyCall
    {

        private List<EmergencyCall> listOfEmergencyCalls;

        public RepositoryEmergencyCallWithList()
        {
            listOfEmergencyCalls = new List<EmergencyCall>();
        }

        public void Add(EmergencyCall call)
        {
            call.Id = listOfEmergencyCalls.Count + 1;
            listOfEmergencyCalls.Add(call);
        }

        public int Count()
        {
            return listOfEmergencyCalls.Count;
        }

        public EmergencyCall GetEmergencyCall(int idOfEmergencyCall)
        {
            return listOfEmergencyCalls.FirstOrDefault(call => call.Id == idOfEmergencyCall);
        }

        public void Clear()
        {
            listOfEmergencyCalls.Clear();
        }

        public EmergencyCall GetEmergencyCallWithMostPriorityToBeSolved()
        {
            EmergencyCall priorityCall = LookEmergencyCallNotSolvedWithPriority(EmergencyCall.HIGH);
            if (priorityCall == null)
                priorityCall = LookEmergencyCallNotSolvedWithPriority(EmergencyCall.MEDIUM);
            if (priorityCall == null)
                priorityCall = LookEmergencyCallNotSolvedWithPriority(EmergencyCall.LOW);
            return priorityCall;
        }

        private EmergencyCall LookEmergencyCallNotSolvedWithPriority(int priority)
        {
            EmergencyCall priorityCall = listOfEmergencyCalls.FirstOrDefault(x => !x.Solved && x.LevelOfUrgency == priority
            && x.Mobile == null);
            foreach (var emergencyCall in this.listOfEmergencyCalls)
            {
                if (emergencyCall.LevelOfUrgency == priority && !emergencyCall.Solved && emergencyCall.Mobile == null)
                {
                    if (emergencyCall.CreationDate < priorityCall.CreationDate)
                    {
                        priorityCall = emergencyCall;
                    }
                }
            }
            return priorityCall;
        }

        public EmergencyCall[] GetEmergencyCalls()
        {
            return listOfEmergencyCalls.ToArray();
        }

        public bool IsMobileUnitIsAssociatedToAny(String nameOfMobileUnit)
        {
            return listOfEmergencyCalls.Any(call => call.Mobile.Name == nameOfMobileUnit);
        }

        public EmergencyCall GetEmergencyCallUnsolvedAssignedToUnit(String nameOfMobileUnit)
        {
            EmergencyCall call = null;
            foreach (EmergencyCall thisCall in listOfEmergencyCalls)
            {
                if (thisCall.Mobile != null)
                {
                    if (!thisCall.Solved && thisCall.Mobile.Name == nameOfMobileUnit)
                        call = thisCall;
                }
            }
            return call;
        }

        public EmergencyCall GetEmergencyCallWithMostWaitTimeToBeSolved(Location mobileLocation)
        {
            EmergencyCall nearestEmergencyCall = null;
            List<EmergencyCall> unSolvedEmergencyCalls = listOfEmergencyCalls.Where(x => !x.Solved && x.Mobile == null).ToList();
            List<EmergencyCall> sortedByDateEmergencyCalls = unSolvedEmergencyCalls.OrderBy(x => x.CreationDate).ToList();
            if (sortedByDateEmergencyCalls.Count != 0)
            {
                DateTime oldDateTime = sortedByDateEmergencyCalls.FirstOrDefault().CreationDate;
                List<EmergencyCall> mostWaiting = sortedByDateEmergencyCalls.Where(x => x.CreationDate == oldDateTime).ToList();
                if (mostWaiting.Count == 1)
                    return mostWaiting.FirstOrDefault();
                else
                {
                    double distance = Double.MaxValue;
                    foreach (var aCall in mostWaiting)
                    {
                        double thisDistance = mobileLocation.CalculateDistance(aCall.Location);
                        if (thisDistance < distance)
                        {
                            distance = thisDistance;
                            nearestEmergencyCall = aCall;
                        }
                    }
                }
            }
            return nearestEmergencyCall;
        }

        public void SetEmergencyCallAsSolved(int idOfEmergencyCall, DateTime dateOfSolved)
        {
            GetEmergencyCall(idOfEmergencyCall).Solved = true;
            GetEmergencyCall(idOfEmergencyCall).SolvedDate = dateOfSolved;
        }

        public void SetMobileToAnEmergencyCall(int idOfEmergencyCall, MobileUnit mobile)
        {
            GetEmergencyCall(idOfEmergencyCall).Mobile = mobile;
            GetEmergencyCall(idOfEmergencyCall).AssignationDate = DateTime.Now;
        }

        public void SetAssignModeToAnEmergencyCall(int idOfEmergencyCall, EmergencyCall.AssignModes oneMode)
        {
            GetEmergencyCall(idOfEmergencyCall).AssignMode = oneMode;
        }
    }
}
