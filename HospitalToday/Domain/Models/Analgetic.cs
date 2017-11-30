using HospitalToday.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Models
{
    class Analgetic : Medicine
    {
        public string TypePain { get; set; }
    }
}
