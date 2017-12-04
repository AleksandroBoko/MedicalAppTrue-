using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Common
{
    static class DoctorExtension
    {
        public static string GetDoctorInfo(this Doctor doctor)
        {
            return $"{doctor.Id} {doctor.FirstName} {doctor.LastName} {doctor.Qualification}";
        } 
    }
}
