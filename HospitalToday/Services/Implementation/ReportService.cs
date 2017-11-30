using HospitalToday.DataAccess;
using HospitalToday.DataAccess.Implementation;
using HospitalToday.Domain;
using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Logic
{
    class ReportService : IService<Report>
    {
        private readonly IRepository<Report> reportRep;

        public ReportService()
        {
            reportRep = ReportRepository.GetRepository();
        }

        public void Add(Report item)
        {
            reportRep.Create(item);
        }

        public void Remove(Report item)
        {
            reportRep.Delete(item.Id);
        }

        public List<Report> GetList()
        {
            return reportRep.GetList();
        }
    }
}
