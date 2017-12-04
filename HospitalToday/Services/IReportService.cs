using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Services
{
    interface IReportService : IService<Report>
    {
        IList<int> GetListId();
        double GetReportTotalCost(int id);
    }
}
