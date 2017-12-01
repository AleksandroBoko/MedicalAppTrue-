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
        private static int personCounter = 1;
        private static int personId { get { return personCounter++; } }

        public static IService<Medicine> Medicines { get; set; }
        public static IService<Person> Doctors { get; set; }
        public static IService<Person> Patients { get; set; }
        public static IService<Report> Reports { get; set; }

        public static void InitServices()
        {
            Medicines = new MedicineService();
            Patients = new PatientService();
            Doctors = new DoctorService();
            Reports = new ReportService();
        }

        public static void AddingPersons()
        {
            PersonFactory doctorFactory = new DoctorFactory();
            PersonFactory patientFactory = new PatientFactory();

            var docDantist = doctorFactory.GetPerson();
            InitDoctor(docDantist, personId, "Ivan", "Bo", "Junior");
            Doctors.Add(docDantist);

            var docSurgeon = doctorFactory.GetPerson();
            InitDoctor(docSurgeon, personId, "Alex", "Tor", "Middle");
            Doctors.Add(docSurgeon);

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

                Patients.Add(patient);
            }
        }

        public static void ShowDoctors()
        {
            if (Doctors == null)
                return;

            foreach (var person in Doctors.GetList())
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
            if (Patients == null)
                return;

            foreach (var person in Patients.GetList())
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
            var analgeticFactory = new AnalgeticFactory();
            var antisepticFactory = new AntisepticFactory();
            var febrifugeFactory = new FebrifugeFactory();

            var n = 10;
            for (int i = 0; i < n; i++)
            {
                Medicine med;
                if (i % 3 == 0)
                {
                    med = analgeticFactory.GetMedicine();
                }
                else if (i % 2 == 0)
                {
                    med = antisepticFactory.GetMedicine();
                }
                else
                {
                    med = febrifugeFactory.GetMedicine();
                }

                InitMedicine(med, i);
                Medicines.Add(med);
            }
        }

        private static void InitMedicine(Medicine medicine, int id)
        {
            medicine.Id = id;
            medicine.Name = medicine.ToString() + " " + id;
            if (medicine is Analgetic)
            {
                ((Analgetic)medicine).TypePain = "Hard";
            }
            else if (medicine is Antiseptic)
            {
                ((Antiseptic)medicine).TypeInjury = "Cut";
            }
            else if (medicine is Febrifuge)
            {
                ((Febrifuge)medicine).Temperature = 39.1f;
            }
        }

        public static void ShowMedicine()
        {
            if (Medicines == null)
                return;

            foreach (var med in Medicines.GetList())
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
