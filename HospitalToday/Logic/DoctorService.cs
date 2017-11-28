using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.Domain
{
    class DoctorService:IDoctorService
    {
        IRepository<Person> PatientRep;

        public DoctorService()
        {
            PatientRep = new PersonRepository();
        }

        public void Add(Person person)
        {
            PatientRep.Create(person);    
        }

        public void Remove(Person person)
        {
            PatientRep.Delete(person.Id);
        }

    }
}
