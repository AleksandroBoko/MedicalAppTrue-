using HospitalToday.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Services
{
    interface IDoctorService:IService<Person>
    {
        int CreateReport(Person doctor, Person patient, List<Medicine> medicines, DateTime? date);
    }
}
