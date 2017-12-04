using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.UI
{
    class MenuData
    {
        public MenuData()
        {
            InitMainMenuData();
            InitDoctorsMenuData();
            InitPatientsMenuData();
            InitMedicinesMenuData();
            InitReportsMenuData();
        }

        public List<string> MainMenuData;
        public List<string> DoctorsMenuData;
        public List<string> PatientsMenuData;
        public List<string> MedicinesMenuData;
        public List<string> ReportsMenuData;

        private void InitMainMenuData()
        {
            MainMenuData = new List<string>();
            MainMenuData.Add("Main menu");
            MainMenuData.Add("0 - Doctors");
            MainMenuData.Add("1 - Patients");
            MainMenuData.Add("2 - Medicines");
            MainMenuData.Add("3 - Reports");
            MainMenuData.Add("4 - Exit");
        }

        private void InitDoctorsMenuData()
        {
            DoctorsMenuData = new List<string>();
            DoctorsMenuData.Add("Doctor menu");
            DoctorsMenuData.Add("0 - Add");
            DoctorsMenuData.Add("1 - Remove");
            DoctorsMenuData.Add("2 - View doctor by id");
            DoctorsMenuData.Add("3 - View all doctors");
            DoctorsMenuData.Add("4 - Back to Main menu");
        }

        private void InitPatientsMenuData()
        {
            PatientsMenuData = new List<string>();
            PatientsMenuData.Add("Patient menu");
            PatientsMenuData.Add("0 - Add");
            PatientsMenuData.Add("1 - Remove");
            PatientsMenuData.Add("2 - View patient by id");
            PatientsMenuData.Add("3 - View all patients");
            PatientsMenuData.Add("4 - Back to Main menu");
        }

        private void InitMedicinesMenuData()
        {
            MedicinesMenuData = new List<string>();
            MedicinesMenuData.Add("Medicine menu");
            MedicinesMenuData.Add("0 - Add");
            MedicinesMenuData.Add("1 - Remove");
            MedicinesMenuData.Add("2 - View medicine by id");
            MedicinesMenuData.Add("3 - View all medicines");
            MedicinesMenuData.Add("4 - Back to Main menu");
        }

        private void InitReportsMenuData()
        {
            ReportsMenuData = new List<string>();
            ReportsMenuData.Add("Report menu");
            ReportsMenuData.Add("0 - Add");
            ReportsMenuData.Add("1 - Remove");
            ReportsMenuData.Add("2 - View report by id");
            ReportsMenuData.Add("3 - View total cost of the report");
            ReportsMenuData.Add("4 - View all reports");
            ReportsMenuData.Add("5 - Back to Main menu");
        }
    }
}
