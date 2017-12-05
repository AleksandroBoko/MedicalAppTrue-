﻿using HospitalToday.Common;
using HospitalToday.Common.Models;
using HospitalToday.Domain.Models;
using HospitalToday.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.UI
{
    class MenuHandler
    {
        public MenuHandler
        (
            IMedicineService medicines,
            IDoctorService doctors,
            IPatientService patients,
            IReportService reports
        )
        {
            menuBuilder = new MenuBuilder();
            this.medicines = medicines;
            this.doctors = doctors;
            this.patients = patients;
            this.reports = reports;
        }

        private readonly IMedicineService medicines;
        private readonly IDoctorService doctors;
        private readonly IPatientService patients;
        private readonly IReportService reports;

        private readonly MenuBuilder menuBuilder;

        public void MainMenuHandler()
        {
            var result = menuBuilder.MainMenu();
            switch (result)
            {
                case 0:
                    DoctorMenuHandler(menuBuilder.DoctorMenu());
                    break;
                case 1:
                    PatientMenuHandler(menuBuilder.PatientMenu());
                    break;
                case 2:
                    MedicineMenuHandler(menuBuilder.MedicineMenu());
                    break;
                case 3:
                    ReportMenuHandler(menuBuilder.ReportMenu());
                    break;
                case 4:
                    Console.WriteLine("Bye!");
                    break;
                default:
                    Console.WriteLine("Incorrect point of the menu");
                    BackToMainMenu();
                    break;
            }
        }

        private void DoctorMenuHandler(int req)
        {
            switch (req)
            {
                case 0:
                    AddDoctor();
                    break;
                case 1:
                    RemoveDoctor();
                    break;
                case 2:
                    GetDoctorById();
                    break;
                case 3:
                    GetAllDoctors();
                    break;
                case 4:
                    MainMenuHandler();
                    break;
                default:
                    Console.WriteLine("Incorrect point of the menu");
                    BackToMainMenu();
                    break;
            }
        }

        private void AddDoctor()
        {
            Console.Clear();
            Console.WriteLine("First Name:");
            var firtsName = Console.ReadLine();

            Console.WriteLine("Last Name:");
            var lastName = Console.ReadLine();

            Console.WriteLine("Qualification:");
            var qualification = Console.ReadLine();

            var id = doctors.GetMaxId() + 1;
            doctors.Add(new Doctor()
            {
                FirstName = firtsName,
                LastName = lastName,
                Id = id, 
                Qualification = qualification
            });
        }

        private void RemoveDoctor()
        {
            Console.Clear();
            Console.WriteLine("Id:");

            int id;
            var answer = Console.ReadLine();
            var result = Int32.TryParse(answer, out id);
            if (result)
            {
                var doctor = doctors.GetItemById(id);
                if (doctor != null)
                {
                    doctors.Remove(doctor);
                }
            }
        }

        private void GetDoctorById()
        {
            Console.Clear();
            Console.WriteLine("Id:");

            int id;
            var answer = Console.ReadLine();
            var result = Int32.TryParse(answer, out id);
            if (result)
            {
                var person = doctors.GetItemById(id);
                if (person != null && person is Doctor)
                {
                    var doctor = person as Doctor;
                    Console.Clear();
                    Console.WriteLine(doctor.GetDoctorInfo());
                }
            }
            else
            {
                Console.WriteLine("Incorrect input!");
            }
        }

        private void GetAllDoctors()
        {
            Console.Clear();
            var persons = doctors.GetList();
            foreach (var person in persons)
            {
                var doctor = person as Doctor;
                if (doctor != null)
                {
                    Console.WriteLine(doctor.GetDoctorInfo());
                }
            }
        }

        private void PatientMenuHandler(int req)
        {
            switch (req)
            {
                case 0:
                    AddPatient();
                    break;
                case 1:
                    RemovePatient();
                    break;
                case 2:
                    GetPatientById();
                    break;
                case 3:
                    GetAllPatients();
                    break;
                case 4:
                    MainMenuHandler();
                    break;
                default:
                    Console.WriteLine("Incorrect point of the menu");
                    BackToMainMenu();
                    break;
            }

            BackToMainMenu();
        }

        private void AddPatient()
        {
            Console.Clear();
            Console.WriteLine("First Name:");
            var firtsName = Console.ReadLine();

            Console.WriteLine("Last Name:");
            var lastName = Console.ReadLine();

            Console.WriteLine("Age:");
            var answer = Console.ReadLine();

            int age;
            var result = Int32.TryParse(answer, out age);
            if (result)
            {
                Console.WriteLine("Doctor:");
                answer = Console.ReadLine();

                int id;
                result = Int32.TryParse(answer, out id);
                if (result)
                {
                    var patientId = patients.GetMaxId() + 1;
                    patients.Add(new Patient()
                    {
                        FirstName = firtsName,
                        LastName = lastName,
                        Id = patientId,
                        Age = age,
                        DoctorId = id
                    });
                }
                else
                {
                    Console.WriteLine("Incorrect input of doctor's identificator!");
                }
            }
            else
            {
                Console.WriteLine("Incorrect input of age!");
            }
        }

        private void RemovePatient()
        {
            Console.Clear();
            Console.WriteLine("Id:");

            int id;
            var answer = Console.ReadLine();
            var result = Int32.TryParse(answer, out id);
            if (result)
            {
                var petient = patients.GetItemById(id);
                if (petient != null)
                {
                    patients.Remove(petient);
                }
            }
        }

        private void GetPatientById()
        {
            Console.Clear();
            Console.WriteLine("Id:");

            int id;
            var answer = Console.ReadLine();
            var result = Int32.TryParse(answer, out id);
            if (result)
            {
                var person = patients.GetItemById(id);
                if (person != null && person is Patient)
                {
                    var patient = person as Patient;
                    Console.WriteLine(patient.GetPatientInfo());
                }
            }
        }

        private void GetAllPatients()
        {
            Console.Clear();
            var persons = patients.GetList();
            foreach (var person in persons)
            {
                var patient = person as Patient;
                if (patient != null)
                {
                    Console.WriteLine(patient.GetPatientInfo());
                }
            }
        }

        private void MedicineMenuHandler(int req)
        {
            switch (req)
            {
                case 0:
                    AddMedicine();
                    break;
                case 1:
                    RemoveMedicine();
                    break;
                case 2:
                    GetMedicineById();
                    break;
                case 3:
                    GetAllMedicines();
                    break;
                case 4:
                    MainMenuHandler();
                    break;
                default:
                    Console.WriteLine("Incorrect point of the menu");
                    BackToMainMenu();
                    break;
            }
        }

        private void AddMedicine()
        {
            Console.Clear();
            Console.WriteLine("Type: Analgetic - 0, Antiseptic - 1, Febrifuge - 2");

            var typeMedic = Console.ReadLine();
            var med = InitConcreteMedicine(typeMedic);
            if (med != null)
            {
                var meds = medicines.GetList();
                med.Id = meds.Max(x => x.Id) + 1;

                Console.WriteLine("Name:");
                med.Name = Console.ReadLine();

                Console.WriteLine("Cost");
                double cost;
                var answer = Console.ReadLine();
                var result = Double.TryParse(answer, out cost);
                med.Cost = result ? cost : 0;

                Console.WriteLine("Method of using:");
                med.UsingMethod = Console.ReadLine();

                medicines.Add(med);
            }
        }

        private Medicine InitConcreteMedicine(string TypeMedicine)
        {
            Medicine med = null;
            switch (TypeMedicine)
            {
                case "0":
                    {
                        Console.WriteLine("Type of pain:");
                        med = CreateAnalgetic();
                        break;
                    }
                case "1":
                    {
                        Console.WriteLine("Type of injury:");
                        med = CreateAntiseptic();
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Temperature:");
                        med = CreateFebrifuge(med);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Incorrect input");
                        break;
                    }
            }

            return med;
        }

        private Medicine CreateFebrifuge(Medicine med)
        {
            var answer = Console.ReadLine();
            float temp;
            var result = Single.TryParse(answer, out temp);

            if (result)
            {
                return new Febrifuge() { Temperature = temp };
            }
            else
            {
                Console.WriteLine("Incorrect input!");
                return null;
            }
        }

        private Medicine CreateAntiseptic()
        {
            var answer = Console.ReadLine();
            return new Antiseptic()
            {
                TypeInjury = answer
            };
        }

        private Medicine CreateAnalgetic()
        {
            var answer = Console.ReadLine();
            return new Analgetic()
            {
                TypePain = answer
            };
        }

        private void RemoveMedicine()
        {
            Console.Clear();           
            Console.WriteLine("Id:");

            int id;
            var answer = Console.ReadLine();
            var result = Int32.TryParse(answer, out id);
            if (result)
            {
                var medicine = medicines.GetItemById(id);
                if (medicine != null)
                {
                    medicines.Remove(medicine);
                }
            }
            else
            {
                Console.WriteLine("Incorrect input!");
            }
        }

        private void GetMedicineById()
        {
            Console.Clear();            
            Console.WriteLine("Id:");

            int id;
            var answer = Console.ReadLine();
            var result = Int32.TryParse(answer, out id);
            if (result)
            {
                var medicine = medicines.GetItemById(id);
                if (medicine != null)
                {
                    if (medicine is Analgetic)
                    {
                        var med = medicine as Analgetic;
                        Console.WriteLine(med.GetAnalgeticInfo());
                    }
                    else if (medicine is Antiseptic)
                    {
                        var med = medicine as Antiseptic;
                        Console.WriteLine(med.GetAntisepticInfo());
                    }
                    else if (medicine is Febrifuge)
                    {
                        var med = medicine as Febrifuge;
                        Console.WriteLine(med.GetFebrifugeInfo());
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect input!");
            }
        }

        private void GetAllMedicines()
        {
            Console.Clear();
            var meds = medicines.GetList();
            foreach (var medicine in meds)
            {
                if (medicine is Analgetic)
                {
                    var med = medicine as Analgetic;
                    Console.WriteLine(med.GetAnalgeticInfo());
                }
                else if (medicine is Antiseptic)
                {
                    var med = medicine as Antiseptic;
                    Console.WriteLine(med.GetAntisepticInfo());
                }
                else if (medicine is Febrifuge)
                {
                    var med = medicine as Febrifuge;
                    Console.WriteLine(med.GetFebrifugeInfo());
                }
            }
        }

        private void ReportMenuHandler(int req)
        {
            switch (req)
            {
                case 0:
                    AddReport();
                    break;
                case 1:
                    RemoveReport();
                    break;
                case 2:
                    GetReportById();
                    break;
                case 3:
                    GetReportTotalCost();
                    break;
                case 4:
                    GetAllReports();
                    break;
                case 5:
                    MainMenuHandler();
                    break;
                default:
                    Console.WriteLine("Incorrect point of the menu");
                    BackToMainMenu();
                    break;
            }
        }

        private void GetReportTotalCost()
        {
            Console.Clear();
            Console.WriteLine("Id:");

            int id;
            var answer = Console.ReadLine();
            var result = Int32.TryParse(answer, out id);
            if (result)
            {
                var report = reports.GetItemById(id);
                if (report != null)
                {
                    Console.WriteLine($"{report.Id} {report.Date}");
                    Console.WriteLine("The list of the medicines:");

                    report.Medicines.ForEach(x => Console.WriteLine($"{x.Name} - { x.Cost}"));

                    Console.WriteLine("Total cost:");
                    Console.WriteLine(reports.GetReportTotalCost(id));
                }
            }
            else
            {
                Console.WriteLine("Incorrect input!");
            }
        }

        private void AddReport()
        {
            Console.Clear();
            Console.WriteLine("Doctor's id:");

            var answer = Console.ReadLine();
            int docId;
            var result = Int32.TryParse(answer, out docId);
            if (!result)
            {
                Console.WriteLine("Incorrect input!");
            }

            Person doctor = doctors.GetItemById(docId);

            Console.WriteLine("Patient's id:");
            answer = Console.ReadLine();
            int patId;
            result = Int32.TryParse(answer, out patId);
            if (!result)
            {
                Console.WriteLine("Incorrect input!");
            }

            Person patient = patients.GetItemById(patId);

            var reportMedicines = GetListMedicines();

            try
            {
                doctors.CreateReport(doctor, patient, reportMedicines, DateTime.Now);
            }
            catch
            {
                Console.WriteLine("The patient or doctor wasn't set!");
            }

        }

        private List<Medicine> GetListMedicines()
        {
            var meds = new List<Medicine>();
            while (true)
            {
                Console.WriteLine("Medicine id:");
                var answer = Console.ReadLine();
                int id;
                var result = Int32.TryParse(answer, out id);
                if (!result)
                {
                    Console.WriteLine("Incorrect input!");
                    break;
                }

                var medicine = medicines.GetItemById(id);
                if (medicine != null)
                {
                    meds.Add(medicine);
                }

                Console.WriteLine("Add one more Item? - press 0");
                answer = Console.ReadLine();
                if (answer != "0")
                {
                    break;
                }
            }
            return meds;
        }

        private void RemoveReport()
        {
            Console.Clear();
            Console.WriteLine("Id:");

            int id;
            var answer = Console.ReadLine();
            var result = Int32.TryParse(answer, out id);
            if (result)
            {
                var report = reports.GetItemById(id);
                if (report != null)
                {
                    reports.Remove(report);
                }
            }
        }

        private void GetReportById()
        {
            Console.Clear();
            Console.WriteLine("Id:");
            int id;
            var answer = Console.ReadLine();
            var result = Int32.TryParse(answer, out id);
            if (result)
            {
                var report = reports.GetItemById(id);
                if (report != null)
                {
                    var doctor = doctors.GetItemById(report.DoctorId);
                    var patient = patients.GetItemById(report.PatientId);
                    if (doctor != null && patient != null)
                    {
                        Console.WriteLine($"{report.Id} {report.Date}");
                        Console.WriteLine($"{doctor.FirstName} {doctor.LastName}");
                        Console.WriteLine($"{patient.FirstName} {patient.LastName}");
                        Console.WriteLine("The list of the medicines:");
                        report.Medicines.ForEach(x => Console.WriteLine(x));
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect input!");
            }
        }

        private void GetAllReports()
        {
            Console.Clear();
            var curReports = reports.GetList();
            if (curReports.Any())
            {
                foreach (var report in curReports)
                {
                    var doctor = doctors.GetItemById(report.DoctorId);
                    var patient = patients.GetItemById(report.PatientId);
                    if (doctor != null && patient != null)
                    {
                        Console.WriteLine($"{report.Id} {report.Date}");
                        Console.WriteLine($"{doctor.FirstName} {doctor.LastName}");
                        Console.WriteLine($"{patient.FirstName} {patient.LastName}");
                        Console.WriteLine("The list of the medicines:");
                        report.Medicines.ForEach(x => Console.WriteLine($"{x.Name} - {x.Cost}"));
                        Console.WriteLine();
                    }
                }
            }
        }

        private void BackToMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Back to main menu - press 0");
            var answer = Console.ReadLine();
            if (answer.Equals("0"))
            {
                MainMenuHandler();
            }
        }
    }
}
