using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepositoryEmergencyCall
    {
        void Add(EmergencyCall call);

        void SetEmergencyCallAsSolved(int idOfEmergencyCall, DateTime dateOfSolved);

        void SetMobileToAnEmergencyCall(int idOfEmergencyCall, MobileUnit mobile);

        void SetAssignModeToAnEmergencyCall(int idOfEmergencyCall, EmergencyCall.AssignModes oneMode);

        EmergencyCall GetEmergencyCall(int idOfEmergencyCall);

        EmergencyCall GetEmergencyCallWithMostPriorityToBeSolved();

        EmergencyCall[] GetEmergencyCalls();

        EmergencyCall GetEmergencyCallUnsolvedAssignedToUnit(String nameOfMobileUnit);

        EmergencyCall GetEmergencyCallWithMostWaitTimeToBeSolved(Location mobileLocation);

        int Count();

        void Clear();       

        bool IsMobileUnitIsAssociatedToAny(String nameOfMobileUnit);
    }
}
