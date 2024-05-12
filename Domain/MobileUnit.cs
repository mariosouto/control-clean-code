using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("MobileUnit")]
    public class MobileUnit
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Plate { get; private set; }

        public String Description { get; set; }

        public bool Available { get; set; }

        public Location Location {get; set; }

        public MobileUnit()
        {
            Location = new Location();
            Available = true;
        }

        public MobileUnit(String name)
        {
            this.Name = name;
            Location = new Location();
            Available = true;
        }

        public MobileUnit(String name, String plate, String description)
        {
            this.Name = name;
            Location = new Location();
            Available = true;
            this.Description = description;
            this.SetPlate(plate);
        }

        public void SetPlate(String plate)
        {
            if (plate.Length != 7) { 
                throw new InvalidPlateException();
            }
            for (int i = 3; i < 7; i++)
            {
                char aux = plate[i];
                if (!Char.IsNumber(aux))
                {
                    throw new InvalidPlateException("It is not a valid plate, the format is three letters and four numbers");
                }

            }
            for (int i = 0; i < 3; i++)
            {
                char aux = plate[i];
                if (!Char.IsLetter(aux))
                {
                    throw new InvalidPlateException("It is not a valid plate, the format is three letters and four numbers");
                }

            }
            this.Plate = plate;
        }
    }
}
