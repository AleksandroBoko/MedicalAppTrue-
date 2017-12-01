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
            var reports = reportRep.GetList();
            return reports.Select(x => x.Id).ToList();
        }
    }
}
