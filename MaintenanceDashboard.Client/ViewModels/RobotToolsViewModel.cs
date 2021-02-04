using MaintenanceDashboard.Common;
using MaintenanceDashboard.Common.Properties;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class RobotToolsViewModel:ViewModel
    {
        private readonly RobotToolsContext context;
        public ICollection<SpendedRobotTool> SpendedRobotTools { get; private set; }
        public EmployeeViewModel EmployeeViewModel { get; }
        public string Number { get; set; }
        public string Name { get; set; }
        public bool IsDoubler { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string SpendingEmployee { get; set; }
        public RobotToolsViewModel(RobotToolsContext context)
        {
            this.context = context;
            SpendedRobotTools = new ObservableCollection<SpendedRobotTool>();
            EmployeeViewModel = new EmployeeViewModel(new EmployeeContext());

            EmployeeViewModel.GetAll();
        }

        public ActionCommand GetAllCommand
        {
            get
            {
                return new ActionCommand(p => GetAll());
            }
        }
        public ActionCommand GetFiltredListCommand
        {
            get
            {
                return new ActionCommand(p => GetFiltredList());
            }
        }

        public ActionCommand SpendCommand
        {
            get
            {
                return new ActionCommand(p => Spend(),
                    p => 
                    IsValidRobotTools());
            }
        }

        private bool IsValidRobotTools()
        {
            if ( EmployeeViewModel.SelectedEmployee != null
                 && Date != null
                 && Number != null
                 && !String.IsNullOrWhiteSpace(Name))
                return true;
            return false;
        }

        private void Spend()
        {
            var spendedRobotTool = new SpendedRobotTool
            {
                Number = Int32.Parse(Number),
                Name = Name,
                Date = Date,
                IsDoubler = IsDoubler,
                SpendingEmployee = String.Format("{0} {1}", EmployeeViewModel.SelectedEmployee.FirstName, EmployeeViewModel.SelectedEmployee.LastName),
            };
            context.Create(spendedRobotTool);
            PrintLabel("192.168.1.4", Int32.Parse(Number), Name);
        }

        public void GetAll()
        {
            SpendedRobotTools.Clear();

            foreach (var item in context.GetAll())
                SpendedRobotTools.Add(item);
        }

        private void GetFiltredList()
        {
            SpendedRobotTools.Clear();

            foreach (var item in context.GetFiltredList(Int32.Parse(Number)))
                SpendedRobotTools.Add(item);
        }
        public void PrintLabel(string IpAddress, int number, string name)
        {
            string ZPL_STRING = Resources.HeadBarcode + "^FS^FO250,50^A0,25,25^FD" + "Baza narzedzi robotow" + "^FS^FO200,100^A0,25,25^FDNarzedzie numer:" + number + " ^FS^FO200,150^A0,25,25^FDNazwa narzedzia:" + name + " ^FS^FO200,200^A0,25,25^FDData przegladu:" + DateTime.Now.ToString("MM/dd/yyyy") + " ^FS^XZ";

            ZebraPrinter zebraPrinter = ZebraPrintHelper.Connect(new TcpConnection(IpAddress, TcpConnection.DEFAULT_ZPL_TCP_PORT), PrinterLanguage.ZPL);

            if (ZebraPrintHelper.CheckStatus(zebraPrinter))
            {
                ZebraPrintHelper.Print(zebraPrinter, ZPL_STRING);

                if (ZebraPrintHelper.CheckStatusAfter(zebraPrinter))
                {
                    Console.WriteLine($"Label Printed");
                }
            }
            zebraPrinter = ZebraPrintHelper.Disconnect(zebraPrinter);
        }
    }
}
