using HospitalToday.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Models
{
    class Antiseptic : Medicine
    {
        public string TypeInjury { get; set; }
    }
}
