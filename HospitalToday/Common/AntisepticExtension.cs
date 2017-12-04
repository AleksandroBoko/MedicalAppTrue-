using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Common
{
    static class AntisepticExtension
    {
        public static string GetAntisepticInfo(this Antiseptic antiseptic)
        {
            return $"{antiseptic.Id} {antiseptic.Name} {antiseptic.TypeInjury} {antiseptic.UsingMethod} {antiseptic.Cost}";
        }
    }
}
