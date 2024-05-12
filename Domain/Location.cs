using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Location")]
    public class Location
    {
        public int Id { get; set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public Location()
        {
            this.SetLatitude(0);
            this.SetLongitude(0);
        }

        public Location(double longitude, double latitude)
        {
            this.SetCoordinates(longitude, latitude);
        }

        public void SetCoordinates(double longitude, double latitude)
        {
            this.SetLongitude(longitude);
            this.SetLatitude(latitude);
        }        

        public void SetLatitude(double latitude)
        {
            if (latitude > 90 || latitude < -90)
            {
                throw new InvalidLatitudeException();
            }

            if (Utilities.NumberOfDecimalsGreatherThan(latitude, 5))
            {
                throw new InvalidLatitudeException("It is not a valid latitude, must not have more than 5 decimals.");
            }

            this.Latitude = latitude;
        }

        public void SetLongitude(double longitude)
        {
            if (longitude > 180 || longitude < -180)
            {
                throw new InvalidLongitudeException();
            }
            if (Utilities.NumberOfDecimalsGreatherThan(longitude, 5))
            {
                throw new InvalidLongitudeException("It is not a valid longitude, must not have more than 5 decimals.");
            }

            this.Longitude = longitude;
        }

        public double CalculateDistance(Location anotherLocation)
        {
            double squareOfX2MinusX1 = Math.Pow((anotherLocation.Longitude - this.Longitude),2);
            double squareOfY2MinusY1 = Math.Pow(anotherLocation.Latitude - this.Latitude, 2);
            return Math.Sqrt(squareOfX2MinusX1 + squareOfY2MinusY1);
        }

        public override bool Equals(object obj) 
        {
            Location newLocation = (Location)obj;
            if (this.Latitude == newLocation.Latitude && this.Longitude == newLocation.Longitude)
                return true;
            return false;
        }
    }
}
