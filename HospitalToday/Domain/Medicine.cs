using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain
{
    abstract class Medicine
    {
        public int Id { get; set; }
        public string Name {get; set;}
    }
}
