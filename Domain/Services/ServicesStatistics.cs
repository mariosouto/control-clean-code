using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public static class ServicesStatistics
    {
        public static TimeSpan AverageAssignationTime(IRepositoryEmergencyCall oneRepositoryOfEmergencyCalls, EmergencyCall.AssignModes oneMode = EmergencyCall.AssignModes.None, String nameOfMobile = null)
            {
            return Statistics.AverageAssignationTime(oneRepositoryOfEmergencyCalls, oneMode, nameOfMobile);
        }

        public static TimeSpan AverageSolvedTime(IRepositoryEmergencyCall oneRepositoryOfEmergencyCalls, EmergencyCall.AssignModes oneMode = EmergencyCall.AssignModes.None, String nameOfMobile = null)
        {
            return Statistics.AverageSolvedTime(oneRepositoryOfEmergencyCalls, oneMode, nameOfMobile);
        }

        public static TimeSpan AverageTotalSolvedTime(IRepositoryEmergencyCall oneRepositoryOfEmergencyCalls, EmergencyCall.AssignModes oneMode = EmergencyCall.AssignModes.None, String nameOfMobile = null)
        {
            return Statistics.AverageTotalSolvedTime(oneRepositoryOfEmergencyCalls, oneMode, nameOfMobile);
        }
    }
}
