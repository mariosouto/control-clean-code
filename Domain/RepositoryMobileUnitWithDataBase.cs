using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RepositoryMobileUnitWithDataBase : IRepositoryMobileUnit
    {
       public void Add(MobileUnit mobileUnit)
        {
            using (var context = new MyContext())
            {
                if(Exists(mobileUnit.Name))
                    throw new InvalidAddMobileUnitException();
                context.MobileUnits.Add(mobileUnit);
                context.SaveChanges();
            }
        }

        public void Clear()
        {
            using (var context = new MyContext())
            {
                context.MobileUnits.RemoveRange(context.MobileUnits);
                context.SaveChanges();
            }
        }

        public void Delete(string name)
        {
            using (var context = new MyContext())
            {
                var mobileUnitToDelete = context.MobileUnits.FirstOrDefault(theMobile => theMobile.Name == name);
                if (mobileUnitToDelete != null)
                {
                    context.MobileUnits.Attach(mobileUnitToDelete);
                    context.MobileUnits.Remove(mobileUnitToDelete);
                    context.SaveChanges();
                }                
            }
        }

        public bool Exists(string name)
        {
            bool result = false;
            using (var context = new MyContext())
            {
                if (context.MobileUnits.Any(mobile => mobile.Name == name))
                {
                    result = true;
                }
            }
            return result;
        }

        public MobileUnit[] GetMobileUnits()
        {
            using (var context = new MyContext())
            {
                return context.MobileUnits.ToArray();
            }
        }

        public string[] GetNames()
        {
            MobileUnit[] arrayOfMobileUnits = this.GetMobileUnits();
            String[] arrayOfNames = new String[arrayOfMobileUnits.Count()];
            int i = 0;
            foreach (var mobile in arrayOfMobileUnits)
            {
                arrayOfNames[i] = mobile.Name;
                i++;
            }
            return arrayOfNames;
        }

        public Location GetLocation(string name)
        {
            return this.GetMobile(name).Location;
        }

        public MobileUnit GetMobile(string name)
        {
            using (var context = new MyContext())
            {
                return context.MobileUnits.Include(b => b.Location).FirstOrDefault(theMobile => theMobile.Name == name);
            }
        }

        public MobileUnit GetFewestEmergencyCallsSolved(Location location, EmergencyCall[] listOfEmergencyCalls, MobileUnit[] listOfMobileUnits)
        {
            List<MobileUnit> list = new List<MobileUnit>();
            int min = Int32.MaxValue;
            using (var context = new MyContext())
            {
                foreach (var mob in context.MobileUnits.Include(a => a.Location).ToList())
                {
                    int number = 0;
                    if (mob.Available)
                    {
                        foreach (var call in context.EmergencyCalls.ToList())
                        {
                            if (call.Mobile.Name.Equals(mob.Name) && call.Solved)
                            {
                                TimeSpan result = DateTime.Now.Subtract(call.SolvedDate);
                                double hours = result.TotalHours;
                                if (hours <= 12)
                                {
                                    number++;
                                }
                            }
                        }
                        if (number < min)
                        {
                            list.Clear();
                            list.Add(mob);
                            min = number;
                        }
                        else if (number == min)
                        {
                            list.Add(mob);
                        }
                    }
                }
            }
            if (list.Count == 1)
            {
                return list.First();
            }
            return GetNearestAvailable(location, list);
        }

        public MobileUnit GetNearestAvailable(Location location, List<MobileUnit> list = null)
        {
            if(list == null)
            {
                using (var context = new MyContext())
                {
                    list = context.MobileUnits.Include(b => b.Location).ToList();
                }
            }
            MobileUnit nearestMobile = null;
            using (var context = new MyContext())
            {
                double distance = Double.MaxValue;
                foreach (var mob in list)
                {
                    if (mob.Available)
                    {
                        double thisDistance = location.CalculateDistance(mob.Location);
                        if (thisDistance < distance)
                        {
                            distance = thisDistance;
                            nearestMobile = mob;
                        }
                    }
                }
            }
            return nearestMobile;
        }

        public void ModifyMobileUnitByName(string oldName, string newName, string newPlate, string newDescription)
        {
            using (var context = new MyContext())
            {
                var mobile = context.MobileUnits.Include(b => b.Location).First(theMobile => theMobile.Name == oldName);
                mobile.Name = newName;
                mobile.SetPlate(newPlate);
                mobile.Description = newDescription;
                context.SaveChanges();
            }
        }

        public void SetCoordinatesToMobile(string name, double longitude, double latitude)
        { 
            using (var context = new MyContext())
            {
                var mobile = context.MobileUnits.Include(a => a.Location).First(theMobile => theMobile.Name == name);
                Location newLocation = new Location(longitude, latitude);
                mobile.Location = newLocation;
                context.SaveChanges();
            }
        }

        public int Count()
        {
            using (var context = new MyContext())
            {
                return context.MobileUnits.Count();
            }
        }

        public void SetMobileAvailable(String nameOfMobile)
        {
            using (var context = new MyContext())
            {
                var mobile = context.MobileUnits.Include(b => b.Location).First(theMobile => theMobile.Name == nameOfMobile);
                mobile.Available = true;
                context.SaveChanges();
            }
        }

        public void SetMobileNotAvailable(String nameOfMobile)
        {
            using (var context = new MyContext())
            {
                var mobile = context.MobileUnits.Include(b => b.Location).First(theMobile => theMobile.Name == nameOfMobile);
                mobile.Available = false;
                context.SaveChanges();
            }
        }

        public bool IsMoreThanOneAvailable()
        {
            int number = 0;
            using (var context = new MyContext())
            {
                foreach (var mob in context.MobileUnits.ToList())
                {
                    if (mob.Available)
                    {
                        number++;
                    }
                }
            }
            return number > 1;
        }
    }
}
