﻿using HospitalToday.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Services
{
    interface IService<T> where T : class
    {
        void Add(T item);
        void Remove(T item);
        IList<T> GetList();
        T GetItemById(int id);
    }
}
