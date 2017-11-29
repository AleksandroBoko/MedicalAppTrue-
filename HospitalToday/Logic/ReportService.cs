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
        IRepository<Report> reportRep;

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
    }
}
