using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Domain
{
    class MyContext : DbContext
    {
        public DbSet<MobileUnit> MobileUnits { get; set; }
        public DbSet<EmergencyCall> EmergencyCalls { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
