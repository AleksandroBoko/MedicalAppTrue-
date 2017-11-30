using HospitalToday.Common.Models;
using HospitalToday.DataAccess;
using HospitalToday.DataAccess.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Services.Implementation
{
    class DoctorService : IService<Person>
    {
        private readonly IRepository<Person> personRep;

        public DoctorService()
        {
            personRep = PersonRepository.GetRepository();
        }

        public void Add(Person item)
        {
            personRep.Create(item);
        }

        public void Remove(Person item)
        {
            personRep.Delete(item.Id);
        }

        public List<Person> GetList()
        {
            return personRep.GetList();
        }
    }

}
