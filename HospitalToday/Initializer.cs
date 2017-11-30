﻿using HospitalToday.Common.Models;
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
        static int personCounter = 1;
        static int personId { get { return personCounter++; } }

        static IService<Medicine> medService;
        static IService<Person> doctors;
        static IService<Person> patients;
        static IService<Report> reports;

        public static void InitServices()
        {
            medService = new MedicineService();
            patients = new PatientService();
            doctors = new DoctorService();
            reports = new ReportService();
        }

        public static void AddingPersons()
        {
            PersonFactory doctorFactory = new DoctorFactory();
            PersonFactory patientFactory = new PatientFactory();

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
            if (doctors == null)
                return;

            foreach(var person in doctors.GetList())
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
            if (patients == null)
                return;

            foreach (var person in patients.GetList())
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
    }
}
