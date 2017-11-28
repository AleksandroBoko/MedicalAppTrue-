using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Repository
{
    interface IRepository<T> where T:class
    {
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        List<T> GetList();
        T GetItem(int id);
        void Save();
    }
}
