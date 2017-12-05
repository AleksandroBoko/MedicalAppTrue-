using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Common
{
    static class FebrifugeExtension
    {
        public static string GetFebrifugeInfo(this Febrifuge febrifuge)
        {
            return $"{febrifuge.Id} {febrifuge.Name} {febrifuge.Temperature} {febrifuge.UsingMethod} {febrifuge.Cost}";
        }
    }
}
