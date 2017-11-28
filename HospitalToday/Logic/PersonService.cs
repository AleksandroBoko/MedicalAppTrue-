using HospitalToday.Domain;
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
        IRepository<Person> PersonRep;

        public PersonService()
        {
            PersonRep = new PersonRepository();
        }

        public void Add(Person item)
        {
            PersonRep.Create(item);
        }

        public void Remove(Person item)
        {
            PersonRep.Delete(item.Id);
        }
    }
}
