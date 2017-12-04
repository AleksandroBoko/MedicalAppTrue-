using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Common
{
    static class AnalgeticExtension
    {
        public static string GetAnalgeticInfo(this Analgetic analgetic)
        {
            return $"{analgetic.Id} {analgetic.Name} {analgetic.TypePain} {analgetic.UsingMethod} {analgetic.Cost}";
        }
    }
}
