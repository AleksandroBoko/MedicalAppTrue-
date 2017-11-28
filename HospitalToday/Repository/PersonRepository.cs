using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain
{
    class PersonRepository : IRepository<Person>
    {
        List<Person> Persons;

        public PersonRepository()
        {
            Persons = new List<Person>();
        }

        public void Create(Person item)
        {
            Persons.Add(item);
        }

        public void Delete(int id)
        {
            Persons.Remove(Persons.Where(p => p.Id == id).First());
        }

        public Person GetItem(int id)
        {
            return Persons.Where(p => p.Id == id).First();
        }

        public List<Person> GetList()
        {
            return Persons;
        }

        public void Save()
        {
            //TODO: Need to add code
        }

        public void Update(Person item)
        {
            //TODO: Need to add code
        }
    }
}
