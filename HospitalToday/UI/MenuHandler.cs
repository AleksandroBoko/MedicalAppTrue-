using HospitalToday.Common;
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
        public MenuHandler(IMedicineService medicines, IDoctorService doctors,
                           IPatientService patients, IReportService reports)
        {
            menuBuilder = new MenuBuilder();
            this.medicines = medicines;
            this.doctors = doctors;
            this.patients = patients;
            this.reports = reports;
        }

        private IMedicineService medicines;
        private IDoctorService doctors;
        private IPatientService patients;
        private IReportService reports;

        private MenuBuilder menuBuilder;

        public void MainMenuHandler()
        {
            int result = menuBuilder.MainMenu();
            switch (result)
            {
                case 0: DoctorMenuHandler(menuBuilder.DoctorMenu()); break;
                case 1: PatientMenuHandler(menuBuilder.PatientMenu()); break;
                case 2: MedicineMenuHandler(menuBuilder.MedicineMenu()); break;
                case 3: ReportMenuHandler(menuBuilder.ReportMenu()); break;
                default: Console.WriteLine("Bye!"); break;
            }
        }

        private void DoctorMenuHandler(int req)
        {
            switch (req)
            {
                case 0: AddDoctor(); break;
                case 1: RemoveDoctor(); break;
                case 2: GetDoctorById(); break;
                case 3: GetAllDoctors(); break;
            }

            BackToMainMenu();
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

            doctors.Add(new Doctor() { FirstName = firtsName, LastName = lastName, Id = doctors.GetMaxId()+1, Qualification = qualification });
        }

        private void RemoveDoctor()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Id:");
            int id;
            var answer = Console.ReadLine();
            var result = int.TryParse(answer, out id);
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
            var result = int.TryParse(answer, out id);
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
                case 0: AddPatient(); break;
                case 1: RemovePatient(); break;
                case 2: GetPatientById(); break;
                case 3: GetAllPatients(); break;
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
            var result = int.TryParse(answer, out age);
            if (result)
            {
                Console.WriteLine("Doctor:");
                answer = Console.ReadLine();
                int id;
                result = int.TryParse(answer, out id);
                if (result)
                {
                    patients.Add(new Patient() { FirstName = firtsName, LastName = lastName, Id = patients.GetMaxId()+1, Age = age, DoctorId = id });
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
            Console.WriteLine();
            Console.WriteLine("Id:");
            int id;
            var answer = Console.ReadLine();
            var result = int.TryParse(answer, out id);
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
            Console.WriteLine();
            Console.WriteLine("Id:");
            int id;
            var answer = Console.ReadLine();
            var result = int.TryParse(answer, out id);
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
                case 0: AddMedicine(); break;
                case 1: RemoveMedicine(); break;
                case 2: GetMedicineById(); break;
                case 3: GetAllMedicines(); break;
            }

            BackToMainMenu();
        }

        private void AddMedicine()
        {
            Console.Clear();
            Console.WriteLine("Type: Analgetic - 0, Antiseptic - 1, Febrifuge - 2");
            var typeMedic = Console.ReadLine();
            var med = InitConcreteMedicine(typeMedic);
            if(med != null)
            {
                var meds = medicines.GetList();
                med.Id = meds.Max(x => x.Id) + 1;

                Console.WriteLine("Name:");
                med.Name = Console.ReadLine();

                Console.WriteLine("Cost");
                double cost;
                var answer = Console.ReadLine();
                var result = double.TryParse(answer, out cost);
                med.Cost = result ? cost : 0;

                Console.WriteLine("Method of using:");
                med.UsingMethod = Console.ReadLine();

                medicines.Add(med);
            }
        }

        private Medicine InitConcreteMedicine(string TypeMedicine)
        {
            Medicine med = null;
            switch(TypeMedicine)
            {
                case "0":
                    {
                        Console.WriteLine("Type of pain:");
                        var answer = Console.ReadLine();
                        med = new Analgetic() {TypePain = answer };
                        break;
                    }
                case "1":
                    {
                        Console.WriteLine("Type of injury:");
                        var answer = Console.ReadLine();
                        med = new Antiseptic() { TypeInjury = answer};
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Temperature:");
                        var answer = Console.ReadLine();
                        float temp;
                        var result = float.TryParse(answer, out temp);
                        if (result)
                        {
                            med = new Febrifuge() { Temperature = temp };
                        }
                        break;
                    }
                default: Console.WriteLine("Incorrect input"); break;
            }

            return med; 
        }

        private void RemoveMedicine()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Id:");
            int id;
            var answer = Console.ReadLine();
            var result = int.TryParse(answer, out id);
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
            Console.WriteLine();
            Console.WriteLine("Id:");
            int id;
            var answer = Console.ReadLine();
            var result = int.TryParse(answer, out id);
            if (result)
            {
                var medicine = medicines.GetItemById(id);
                if (medicine != null)
                {
                    if(medicine is Analgetic)
                    {
                        var med = medicine as Analgetic;
                        Console.WriteLine(med.GetAnalgeticInfo());
                    }
                    else if(medicine is Antiseptic)
                    {
                        var med = medicine as Antiseptic;
                        Console.WriteLine(med.GetAntisepticInfo());
                    }
                    else if(medicine is Febrifuge)
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
                case 0: AddReport(); break;
                case 1: RemoveReport(); break;
                case 2: GetReportById(); break;
                case 3: GetReportTotalCost(); break;
                case 4: GetAllReports(); break;
            }

            BackToMainMenu();
        }

        private void GetReportTotalCost()
        {
            Console.Clear();
            Console.WriteLine("Id:");
            int id;
            var answer = Console.ReadLine();
            var result = int.TryParse(answer, out id);
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
            var result = int.TryParse(answer, out docId);
            if (!result)
            {
                Console.WriteLine("Incorrect input!");
            }
            Person doctor = doctors.GetItemById(docId);

            answer = Console.ReadLine();
            int patId;
            result = int.TryParse(answer, out patId);
            if (!result)
            {
                Console.WriteLine("Incorrect input!");
            }
            Person patient = patients.GetItemById(patId);

            var reportMedicines = GetListMedicines();

            doctors.CreateReport(doctor, patient, reportMedicines, DateTime.Now);

        }

        private List<Medicine> GetListMedicines()
        {
            List<Medicine> meds = new List<Medicine>();
            while (true)
            {
                Console.WriteLine("Medicine id:");
                var answer = Console.ReadLine();
                int id;
                var result = int.TryParse(answer, out id);
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
                if(answer != "0")
                {
                    break;
                }
            }
            return meds;
        }

        private void RemoveReport()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Id:");
            int id;
            var answer = Console.ReadLine();
            var result = int.TryParse(answer, out id);
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
            var result = int.TryParse(answer, out id);
            if (result)
            {
                var report = reports.GetItemById(id);
                if (report != null)
                {
                    var doctor = doctors.GetItemById(report.DoctorId);
                    var patient = patients.GetItemById(report.PatientId);
                    if (doctor == null || patient == null)
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
                    if (doctor == null || patient == null)
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
            if(answer.Equals("0"))
            {
                MainMenuHandler();
            }
        }
    }
}
