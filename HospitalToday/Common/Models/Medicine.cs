using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Common.Models
{
    abstract class Medicine
    {
        public int Id { get; set; }
        public string Name {get; set;}
    }
}
