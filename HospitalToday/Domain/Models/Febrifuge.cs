﻿using HospitalToday.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain.Models
{
    class Febrifuge : Medicine
    {
        public float Temperature { get; set; }
    }
}
