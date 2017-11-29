using HospitalToday.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Repository
{
    class ReportRepository : IRepository<Report>
    {
        private List<Report> reports;
        private static IRepository<Report> reportRep;

        private ReportRepository()
        {
            reports = new List<Report>();
        }

        public static IRepository<Report> GetRepository()
        {
            if (reportRep == null)
            {
                reportRep = new ReportRepository();
            }

            return reportRep;
        }

        public void Create(Report item)
        {
            reports.Add(item);
        }

        public void Delete(int id)
        {
            reports.Remove(reports.FirstOrDefault(n => n.Id == id));
        }

        public Report GetItem(int id)
        {
            return reports.FirstOrDefault(n => n.Id == id);
        }

        public List<Report> GetList()
        {
            return reports;
        }

        public void Update(Report item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
