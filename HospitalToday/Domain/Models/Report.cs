using HospitalToday.Common.Models;
using System;
using System.Collections.Generic;

namespace HospitalToday.Domain.Models
{
    class Report
    {
        private static int counterId;

        public int Id { get; private set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public List<Medicine> Medicines { get; set; }

        public Report()
        {
            Id = counterId++;
        }
    }
}
