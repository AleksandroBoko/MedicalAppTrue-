using HospitalToday.Domain;
using HospitalToday.Domain.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Repository
{
    class PersonRepository : IRepository<Person>
    {
        private static IRepository<Person> personRep;
        private List<Person> persons;

        private PersonRepository()
        {
            persons = new List<Person>();
        }

        public static IRepository<Person> GetRepository()
        {
            if (personRep == null)
                personRep = new PersonRepository();

            return personRep;
        }

        public void Create(Person item)
        {
            persons.Add(item);
        }

        public void Delete(int id)
        {
            persons.Remove(persons.FirstOrDefault(p => p.Id == id));
        }

        public Person GetItem(int id)
        {
            return persons.FirstOrDefault(p => p.Id == id);
        }

        public List<Person> GetList()
        {
            return persons;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
