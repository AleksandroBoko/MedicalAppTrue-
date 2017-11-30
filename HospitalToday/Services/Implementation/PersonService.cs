using HospitalToday.Common.Models;
using HospitalToday.DataAccess;
using HospitalToday.DataAccess.Implementation;
using HospitalToday.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Logic
{
    class PersonService : IService<Person>
    {
        private readonly IRepository<Person> personRep;

        public PersonService()
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
