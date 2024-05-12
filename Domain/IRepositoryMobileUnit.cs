using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepositoryMobileUnit
    {
        void Add(MobileUnit mobileUnit);

        void SetMobileAvailable(String nameOfMobile);

        void SetMobileNotAvailable(String nameOfMobile);

        MobileUnit GetMobile(String name);

        MobileUnit GetNearestAvailable(Location location, List<MobileUnit> list = null);

        MobileUnit GetFewestEmergencyCallsSolved(Location location, EmergencyCall[] listOfEmergencyCalls, MobileUnit[] listOfMobileUnits);

        String[] GetNames();

        Location GetLocation(String nameOfMobileUnit);

        MobileUnit[] GetMobileUnits();

        void Delete(String name);

        bool Exists(String name);    
      
        int Count();

        void Clear();

        void ModifyMobileUnitByName(String oldName, String newName, String newPlate, String newDescription);

        void SetCoordinatesToMobile(String name, double longitude, double latitude);     

        bool IsMoreThanOneAvailable();
    }
}
