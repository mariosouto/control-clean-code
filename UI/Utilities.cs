using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services;

namespace UI
{
    public static class Utilities
    {
        public static String printAllInfoEmergencyCall(int idOfEmergencyCall)
        {
            String message;
            EmergencyCall selected = Services.GetEmergencyCall(idOfEmergencyCall);
            message = selected.ToString();
            message = message + "\n Direccion: " + selected.Address + "\n Latitud: " + selected.Location.Latitude +
                "\n Longitud: " + selected.Location.Longitude + "\n Nivel de urgencia: ";                 
            switch (selected.LevelOfUrgency)
            {
                case EmergencyCall.LOW:
                    message = message +  "baja.";
                    break;
                case EmergencyCall.MEDIUM:
                    message = message + "media.";
                    break;
                case EmergencyCall.HIGH:
                    message = message + "alta.";
                    break;
                default:
                    break;
            }
            message = message + "\n Fecha de creación: " + selected.CreationDate;
            if (selected.Mobile != null)
            {
                message = message + "\n Movil asignado: " + selected.Mobile.Name;
                message = message + "\n Fecha de asignación: " + selected.AssignationDate;
                message = message + "\n Método de asignación: ";
                switch (selected.AssignMode)
                {
                    case EmergencyCall.AssignModes.Default:
                        message = message + "por defecto.";
                        break;
                    case EmergencyCall.AssignModes.WaitTime:
                        message = message + "tiempo de espera.";
                        break;
                    case EmergencyCall.AssignModes.NumberOfSolvedEmergencyCalls:
                        message = message + "cantidad de casos atendidos.";
                        break;
                    default:
                        break;
                }
                if (selected.Solved)
                    message = message + "\n Fecha de resolución: " + selected.SolvedDate;
            }            
            else
                message = message + "\n Movil asignado: no tiene";
            return message;
        }

        public static String printAllInfoMobileUnit(String nameOfMobileUnit)
        {
            String message;
            MobileUnit mobileSelected = Services.GetMobileUnit(nameOfMobileUnit);
            message = "Unidad movil: " + mobileSelected.Name + "\nMatricula: " + mobileSelected.Plate +
                "\nDescripcion: " + mobileSelected.Description + "\nLatitud: " + mobileSelected.Location.Latitude + " Longitud: " +
                mobileSelected.Location.Longitude;
            if (mobileSelected.Available)
            {
                message = message + "\nDisponible.";
            }
            else
            {
                message = message + "\nNo disponible. Asignada a llamada: " +
                    Services.GetEmergencyCallUnsolvedAssignedToUnit(mobileSelected.Name);
            }
            return message;
        }

        public static String printTimeSpan(TimeSpan oneTime)
        {
            String result = "";
            if(oneTime.Days != 0)
            {
                result = result + "Días: " + oneTime.Days;
            }
            if (oneTime.Hours != 0)
            {
                result = result + " Horas: " + oneTime.Hours;
            }
            if (oneTime.Minutes != 0)
            {
                result = result + " Minutos: " + oneTime.Minutes;
            }
            if (oneTime.Seconds != 0)
            {
                result = result + " Segundos: " + oneTime.Seconds;
            }
            if(result == "" && oneTime.TotalMilliseconds != 0)
            {
                result = "Milisegundos: " + oneTime.TotalMilliseconds;
            }
            return result;
        }
    }
}
