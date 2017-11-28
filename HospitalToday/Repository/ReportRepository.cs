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
        List<Report> Reports;

        public void Create(Report item)
        {
            Reports.Add(item);
        }

        public void Delete(int id)
        {
            Reports.Remove(Reports.Where(n => n.Id == id).First());
        }

        public Report GetItem(int id)
        {
            return Reports.Where(n => n.Id == id).First();
        }

        public List<Report> GetList()
        {
            return Reports;
        }

        public void Save()
        {
            // TODO: add code
        }

        public void Update(Report item)
        {
            // TODO: add code
        }
    }
}
