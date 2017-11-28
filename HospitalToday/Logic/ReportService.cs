using HospitalToday.Domain;
using HospitalToday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Logic
{
    class ReportService : IService<Report>
    {
        IRepository<Report> ReportRep;

        public ReportService()
        {
            ReportRep = new ReportRepository();
        }

        public void Add(Report item)
        {
            ReportRep.Create(item);
        }

        public void Remove(Report item)
        {
            ReportRep.Delete(item.Id);
        }
    }
}
