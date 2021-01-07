 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using MaintenanceDashboard.Common;


namespace MaintenanceDashboard.Client.ViewModels
{
    public class EmployeeViewModel : ViewModel
    {
        private readonly EmployeeContext context;
        public ICollection<Employee> Employees { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UidCode { get; set; }

        private bool _connectedSuccessfully;
        public bool ConnectedSuccessfully
        {
            get { return _connectedSuccessfully; }
            set
            {
                _connectedSuccessfully = value;
                NotifyPropertyChanged();
            }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                NotifyPropertyChanged();
            }
        }

        private string test = "Usuń";

        public string Test
        {
            get { return test; }
            set 
            { 
                test = value;
                NotifyPropertyChanged();
            }
        }


        public EmployeeViewModel(EmployeeContext context)
        {
            this.context = context;
            Employees = new ObservableCollection<Employee>();
            GetAll();
        }

        public ActionCommand CreateCommand
        {
            get
            {
                return new ActionCommand(p => Create(),
                                         p => !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName));
            }
        }
        public ActionCommand UpdateCommand
        {
            get
            {
                return new ActionCommand(p => Update(),
                                         p => IsValidEmployee);
            }
        }

        public ActionCommand RemoveCommand
        {
            get
            {
                return new ActionCommand(p => Remove());
            }
        }

        private void Create()
        {
            var employee = new Employee
            {
                FirstName = FirstName,
                LastName = LastName
            };

            context.Create(employee);
            ConnectedSuccessfully = true;
        }

     
        private void Update()
        {
            if (SelectedEmployee != null)
                context.Update(SelectedEmployee);
        }

        private void Remove()
        {
            if (SelectedEmployee != null)
            {
                context.Remove(SelectedEmployee);
                Employees.Remove(SelectedEmployee);
                SelectedEmployee = null;
            }
        }

        public void GetAll()
        {
            Employees.Clear();
            SelectedEmployee = null;

            foreach (var item in context.GetAll())
                Employees.Add(item);
        }

        public bool IsValidEmployee
        {
            get
            {
                return SelectedEmployee == null ||
                (!String.IsNullOrWhiteSpace(SelectedEmployee.FirstName) &&
                !String.IsNullOrWhiteSpace(SelectedEmployee.LastName));
            }
        }
    }
}
