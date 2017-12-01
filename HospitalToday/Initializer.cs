using HospitalToday.Common.Models;
using HospitalToday.Domain.Factory;
using HospitalToday.Domain.Factory.Implementation;
using HospitalToday.Domain.Models;
using HospitalToday.Services;
using HospitalToday.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday
{
    static class Initializer
    {
        static Initializer()
        {
            doctorFactory = new DoctorFactory();
            patientFactory = new PatientFactory();
            analgeticFactory = new AnalgeticFactory();
            antisepticFactory = new AntisepticFactory();
            febrifugeFactory = new FebrifugeFactory();
        }

        private static int personCounter = 1;
        private static int personId { get { return personCounter++; } }

        private static IService<Medicine> medicines;
        private static IService<Person> doctors;
        private static IService<Person> patients;
        private static IService<Report> reports;

        private static PersonFactory doctorFactory;
        private static PersonFactory patientFactory;
        private static MedicineFactory analgeticFactory;
        private static MedicineFactory antisepticFactory;
        private static MedicineFactory febrifugeFactory;

        public static void InitServices(IService<Medicine> medicines, IService<Person> doctors,
                                        IService<Person> patients, IService<Report> reports)
        {
            Initializer.medicines = medicines ?? new MedicineService();
            Initializer.patients = doctors ?? new PatientService();
            Initializer.doctors = patients ?? new DoctorService();
            Initializer.reports = reports ?? new ReportService();
        }

        public static void AddingPersons()
        {
            var docDantist = doctorFactory.GetPerson();
            InitDoctor(docDantist, personId, "Ivan", "Bo", "Junior");
            doctors.Add(docDantist);

            var docSurgeon = doctorFactory.GetPerson();
            InitDoctor(docSurgeon, personId, "Alex", "Tor", "Middle");
            doctors.Add(docSurgeon);

            var n = 10;
            for (var i = 0; i < 10; i++)
            {
                var patient = patientFactory.GetPerson();
                if (i > n / 2)
                {
                    InitPatient(patient, personId, "Name" + i, "LastName" + i, docDantist.Id, i + 10);
                }
                else
                {
                    InitPatient(patient, personId, "Name" + i, "LastName" + i, docSurgeon.Id, i + 10);
                }

                patients.Add(patient);
            }
        }

        public static void ShowDoctors()
        {
            if (Initializer.doctors == null)
                return;

            var doctors = Initializer.doctors.GetList();

            if (doctors == null)
                return;

            foreach (var person in doctors)
            {
                var doctor = person as Doctor;
                if (doctor != null)
                {
                    Console.WriteLine($"Doctor: {doctor.Id} {doctor.FirstName} {doctor.LastName} {doctor.Qualification}");
                }
            }
        }

        public static void ShowPatients()
        {
            if (Initializer.patients == null)
                return;

            var patients = Initializer.patients.GetList();

            if (patients == null)
                return;

            foreach (var person in Initializer.patients.GetList())
            {
                var patient = person as Patient;
                if (patient != null)
                {
                    Console.WriteLine($"Patient: {patient.Id} {patient.FirstName} {patient.LastName} {patient.Age} Doctor: {patient.DoctorId}");
                }
            }
        }

        private static void InitDoctor(Person person, int id, string firstName, string lastName, string qualification)
        {
            var curPerson = person as Doctor;
            if (curPerson == null)
                return;

            curPerson.Id = id;
            curPerson.FirstName = firstName;
            curPerson.LastName = lastName;
            curPerson.Qualification = qualification;
        }

        private static void InitPatient(Person person, int id, string firstName, string lastName, int doctorId, int age)
        {
            var curPerson = person as Patient;
            if (curPerson == null)
                return;

            curPerson.Id = id;
            curPerson.FirstName = firstName;
            curPerson.LastName = lastName;
            curPerson.DoctorId = doctorId;
            curPerson.Age = age;
        }

        public static void AddingMedicine()
        {
            var n = 10;
            for (int id = 0; id < n; id++)
            {
                Medicine med;
                if (id % 3 == 0)
                {
                    med = analgeticFactory.GetMedicine();
                }
                else if (id % 2 == 0)
                {
                    med = antisepticFactory.GetMedicine();
                }
                else
                {
                    med = febrifugeFactory.GetMedicine();
                }

                InitMedicine(id, med);
                medicines.Add(med);
            }
        }

        private static void InitMedicine(int id, Medicine medicine)
        {
            medicine.Id = id;
            medicine.Name = medicine.ToString() + " " + id;
            if (medicine is Analgetic)
            {
                var curMed = medicine as Analgetic;
                curMed.TypePain = "Hard";
            }
            else if (medicine is Antiseptic)
            {
                var curMed = medicine as Antiseptic;
                curMed.TypeInjury = "Cut";
            }
            else if (medicine is Febrifuge)
            {
                var curMed = medicine as Febrifuge;
                curMed.Temperature = 39.1f;
            }
        }

        public static void ShowMedicine()
        {
            if (medicines == null)
                return;

            foreach (var med in medicines.GetList())
            {
                if (med is Analgetic)
                {
                    var curMed = med as Analgetic;
                    Console.WriteLine($"{curMed.Id} - {curMed.Name} - {curMed.TypePain}");
                }
                else if (med is Antiseptic)
                {
                    var curMed = med as Antiseptic;
                    Console.WriteLine($"{curMed.Id} - {curMed.Name} - {curMed.TypeInjury}");
                }
                else if (med is Febrifuge)
                {
                    var curMed = med as Febrifuge;
                    Console.WriteLine($"{curMed.Id} - {curMed.Name} - {curMed.Temperature}");
                }
            }
        }
    }
}
