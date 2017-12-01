using HospitalToday.DataAccess;
using HospitalToday.DataAccess.Implementation;
using HospitalToday.Domain;
using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Services.Implementation
{
    class ReportService : IReportService
    {
        public ReportService()
        {
            reportRep = ReportRepository.GetRepository();
        }

        private readonly IRepository<Report> reportRep;

        public void Add(Report item)
        {
            reportRep.Create(item);
        }

        public void Remove(Report item)
        {
            reportRep.Delete(item.Id);
        }

        public IList<Report> GetList()
        {
            return reportRep.GetList();
        }

        public Report GetItemById(int id)
        {
            return reportRep.GetItem(id);
        }

        public IList<int> GetListId()
        {
            return reportRep.GetList().Select(x => x.Id).ToList();
        }

        public double GetReportTotalCost(int id)
        {
            var report = reportRep.GetItem(id);
            if (report != null && report.Medicines != null)
            {
                return report.Medicines.Sum(x => x.Cost);
            }
            else
            {
                return -1;
            }
        }
    }
}
