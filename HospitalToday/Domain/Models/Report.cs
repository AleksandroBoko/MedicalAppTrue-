using HospitalToday.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Models
{
    class Report
    {
        static int counterId { get; set; } = 0;

        public int Id { get; private set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public List<Medicine> Medicines {get; set;}

        public Report()
        {
            Id = counterId++;
        }
    }
}
