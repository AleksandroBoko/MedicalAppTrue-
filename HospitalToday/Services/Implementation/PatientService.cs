using HospitalToday.Common.Models;
using HospitalToday.DataAccess;
using HospitalToday.DataAccess.Implementation;
using HospitalToday.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Services.Implementation
{
    class PatientService : IService<Person>
    {
        private readonly IRepository<Person> personRep;

        public PatientService()
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
            var persons = personRep.GetList().Where(x => x is Patient);
            return persons != null ? persons.ToList() : null;
        }

        public Person GetItemById(int id)
        {
            return personRep.GetItem(id);
        }
    }
}
