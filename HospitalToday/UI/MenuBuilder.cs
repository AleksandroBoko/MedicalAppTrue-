using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalToday.UI
{
    class MenuBuilder
    {
        public MenuBuilder()
        {
            menuBuilder = new StringBuilder();
            menuData = new MenuData();
        }

        private StringBuilder menuBuilder;
        private MenuData menuData;

        public int MainMenu()
        {
            Clear();
            menuData.MainMenuData.ForEach(x => menuBuilder.AppendLine(x));
            Console.WriteLine(menuBuilder);
            int req;
            Console.WriteLine("Answer:");
            var answer = Console.ReadLine();
            var result = int.TryParse(answer, out req);
            
            return result ? req : -1;
        }

        public int DoctorMenu()
        {
            Clear();
            menuData.DoctorsMenuData.ForEach(x => menuBuilder.AppendLine(x));
            Console.WriteLine(menuBuilder);
            int req;
            Console.WriteLine("Answer:");
            var answer = Console.ReadLine();
            var result = int.TryParse(answer, out req);

            return result ? req : -1;
        }

        public int PatientMenu()
        {
            Clear();
            menuData.PatientsMenuData.ForEach(x => menuBuilder.AppendLine(x));
            Console.WriteLine(menuBuilder);
            int req;
            Console.WriteLine("Answer:");
            var answer = Console.ReadLine();
            var result = int.TryParse(answer, out req);

            return result ? req : -1;
        }

        public int MedicineMenu()
        {
            Clear();
            menuData.MedicinesMenuData.ForEach(x => menuBuilder.AppendLine(x));
            Console.WriteLine(menuBuilder);
            int req;
            Console.WriteLine("Answer:");
            var answer = Console.ReadLine();
            var result = int.TryParse(answer, out req);

            return result ? req : -1;
        }

        public int ReportMenu()
        {
            Clear();
            menuData.ReportsMenuData.ForEach(x => menuBuilder.AppendLine(x));
            Console.WriteLine(menuBuilder);
            int req;
            Console.WriteLine("Answer:");
            var answer = Console.ReadLine();
            var result = int.TryParse(answer, out req);

            return result ? req : -1;
        }

        private void Clear()
        {
            Console.Clear();
            menuBuilder.Clear();
        }
    }
}
