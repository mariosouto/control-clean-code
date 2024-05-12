using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("EmergencyCall")]
    public class EmergencyCall
    {
        public const int LOW = 1;

        public const int MEDIUM = 2;

        public const int HIGH = 3;

        public enum AssignModes { None, Default, WaitTime, NumberOfSolvedEmergencyCalls };

        public int Id { get; set; }

        public String Description { get; set; }

        public String Address { get; set; }

        public Location Location { get; set; }        

        public int LevelOfUrgency { get; private set; }

        public DateTime CreationDate { get; set; }

        public DateTime AssignationDate { get; set; }

        public DateTime SolvedDate { get; set; }

        public bool Solved { get; set; }

        public MobileUnit Mobile { get; set; }

        public AssignModes AssignMode { get; set; }

        public EmergencyCall()
        {
            Solved = false;
            Location = new Location();
            this.CreationDate = DateTime.Now;
            this.SolvedDate = DateTime.Now; //ver si se puede cambiar
            this.AssignationDate = DateTime.Now;
        }

        public void SetLevelOfUrgency(int level)
        {
            if (level != LOW && level != MEDIUM && level != HIGH)
            {
                throw new InvalidLevelOfUrgencyException();
            }
            this.LevelOfUrgency = level;
        }

        public EmergencyCall(String description, String address, Location location, int urgencyLevel, DateTime creationDate)
        {
            this.Description = description;
            this.Address = address;
            this.SetLevelOfUrgency(urgencyLevel);
            this.CreationDate = creationDate;
            Solved = false;
            this.Location = location;
            this.SolvedDate = DateTime.Now;
            this.AssignationDate = DateTime.Now;
        }

        public override string ToString()
        {
            return Id + ": " + Description;
        }
    }
}
