using HospitalToday.Domain;
using HospitalToday.Domain.Person;
using HospitalToday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Logic
{
    class PersonService : IService<Person>
    {
        IRepository<Person> personRep;

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
    }
}
