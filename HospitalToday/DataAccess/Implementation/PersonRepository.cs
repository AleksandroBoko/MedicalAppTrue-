﻿using HospitalToday.Common.Models;
using HospitalToday.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.DataAccess.Implementation
{
    class PersonRepository : IRepository<Person>
    {
        private static IRepository<Person> personRep;
        private readonly List<Person> persons;

        private PersonRepository()
        {
            persons = new List<Person>();
        }

        public static IRepository<Person> GetRepository()
        {
            if (personRep == null)
            {
                personRep = new PersonRepository();
            }

            return personRep;
        }

        public void Create(Person item)
        {
            persons.Add(item);
        }

        public void Delete(int id)
        {
            if (persons.Any(x => x.Id == id))
            {
                persons.Remove(persons.FirstOrDefault(x => x.Id == id));
            }
        }

        public Person GetItem(int id)
        {
            return persons.FirstOrDefault(x => x.Id == id);
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
