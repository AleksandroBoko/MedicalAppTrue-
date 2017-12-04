using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Common
{
    static class PatientExtension
    {
        public static string GetPatientInfo(this Patient patient)
        {
            return $"{patient.Id} {patient.FirstName} {patient.LastName} {patient.Age} {patient.DoctorId}";
        }
    }
}
