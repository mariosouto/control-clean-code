using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RepositoryEmergencyCallWithDataBase : IRepositoryEmergencyCall
    {
        public void Add(EmergencyCall call)
        {
            using (var context = new MyContext())
            {
                if (call.Mobile != null)
                {
                    context.MobileUnits.Attach(call.Mobile);
                    context.Entry(call.Mobile).State = EntityState.Modified;
                }
                context.EmergencyCalls.Add(call);
                context.SaveChanges();
            }
        }

        public bool IsMobileUnitIsAssociatedToAny(string nameOfMobileUnit)
        {
            bool result = false;
            using (var context = new MyContext())
            {
                result = context.EmergencyCalls.Any(call => call.Mobile.Name == nameOfMobileUnit);
            }
            return result;
        }

        public void Clear()
        {
            using (var context = new MyContext())
            {
                context.EmergencyCalls.RemoveRange(context.EmergencyCalls);
                context.SaveChanges();
            }
        }

        public EmergencyCall[] GetEmergencyCalls()
        {
            using (var context = new MyContext())
            {
                return context.EmergencyCalls.Include(a => a.Location).Include(b => b.Mobile).ToArray();
            }
        }

        public EmergencyCall GetEmergencyCall(int idOfEmergencyCall)
        {
            using (var context = new MyContext())
            {
                return context.EmergencyCalls.Include(b => b.Mobile).Include(a => a.Location).FirstOrDefault(call => call.Id == idOfEmergencyCall);
            }
        }

        public EmergencyCall GetEmergencyCallUnsolvedAssignedToUnit(string nameOfMobileUnit)
        {
            EmergencyCall call = null;
            using (var context = new MyContext())
            {
                List<EmergencyCall> listOfEmergencyCalls = context.EmergencyCalls.Include(b => b.Location).Include(a => a.Mobile).ToList();
                foreach (EmergencyCall thisCall in listOfEmergencyCalls)
                {
                    if (thisCall.Mobile != null)
                    {
                        if (!thisCall.Solved && thisCall.Mobile.Name == nameOfMobileUnit)
                            call = thisCall;
                    }
                }
            }
            return call;
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
            using (var context = new MyContext())
            {
                List<EmergencyCall> listOfEmergencyCalls = context.EmergencyCalls.Include(b => b.Location).Include(a => a.Mobile).ToList();
                EmergencyCall priorityCall = listOfEmergencyCalls.FirstOrDefault(x => !x.Solved && x.LevelOfUrgency == priority
            && x.Mobile == null);
                foreach (var emergencyCall in listOfEmergencyCalls)
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
        }

        public EmergencyCall GetEmergencyCallWithMostWaitTimeToBeSolved(Location mobileLocation)
        {
            EmergencyCall nearestEmergencyCall = null;
            using (var context = new MyContext())
            {
                List<EmergencyCall> unSolvedEmergencyCalls = context.EmergencyCalls.Include(b => b.Location).Where(x => !x.Solved && x.Mobile == null).ToList();
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
        }

        public int Count()
        {
            using (var context = new MyContext())
            {
                return context.EmergencyCalls.Count();
            }
        }

        public void SetEmergencyCallAsSolved(int idOfEmergencyCall, DateTime dateOfSolved)
        {
            using (var context = new MyContext())
            {
                var callToModify = context.EmergencyCalls.Include(b => b.Location).Include(a => a.Mobile).Include(c => c.Mobile.Location).FirstOrDefault(aCall => aCall.Id == idOfEmergencyCall);
                callToModify.Solved = true;
                callToModify.SolvedDate = dateOfSolved;
                context.SaveChanges();
            }
        }

        public void SetMobileToAnEmergencyCall(int idOfEmergencyCall, MobileUnit mobile)
        {
            using (var context = new MyContext())
            {
                EmergencyCall callToModify = context.EmergencyCalls.Include(b => b.Location).Include(a => a.Mobile).FirstOrDefault(aCall => aCall.Id == idOfEmergencyCall);
                MobileUnit mobileToAssign = context.MobileUnits.FirstOrDefault(aMobile => aMobile.Id == mobile.Id);
                callToModify.Mobile = mobileToAssign;
                callToModify.AssignationDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void SetAssignModeToAnEmergencyCall(int idOfEmergencyCall, EmergencyCall.AssignModes oneMode)
        {
            using (var context = new MyContext())
            {
                var callToModify = context.EmergencyCalls.Include(b => b.Location).Include(a => a.Mobile).Include(c => c.Mobile.Location).FirstOrDefault(aCall => aCall.Id == idOfEmergencyCall);
                callToModify.AssignMode = oneMode;
                context.SaveChanges();
            }
        }
    }
}
