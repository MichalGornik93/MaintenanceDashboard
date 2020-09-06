using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Data.Interfaces;
using MaintenanceDashboard.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class EmployeeViewModel : ViewModel
    {
        private readonly IEmployeeContext context;

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

        public EmployeeViewModel(IEmployeeContext context)
        {
            this.context = context;
            Employees = new ObservableCollection<Employee>();
        }

        public ActionCommand CreateEmployeeCommand
        {
            get
            {
                return new ActionCommand(p => CreateEmployee(),
                                         p => !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName));
            }
        }
        public ActionCommand SaveEmployeeCommand
        {
            get
            {
                return new ActionCommand(p => SaveEmployee(),
                                         p => IsValidEmployee);
            }
        }

        public ICommand DeleteEmployeeCommand
        {
            get
            {
                return new ActionCommand(p => DeleteEmployee());
            }
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

        private void CreateEmployee()
        {
            var employee = new Employee
            {
                FirstName = FirstName,
                LastName = LastName,
                UidCode = UidCode
            };

            context.CreateEmployee(employee);
            ConnectedSuccessfully = true;
        }

        public void GetEmployeeList()
        {
            Employees.Clear();
            SelectedEmployee = null;

            foreach (var item in context.GetEmployeeList())
                Employees.Add(item);
        }

        private void SaveEmployee()
        {
            if (SelectedEmployee != null)
                context.UpdateEmployee(SelectedEmployee);
        }

        private void DeleteEmployee()
        {
            if (SelectedEmployee != null)
            {
                context.DeleteEmployee(SelectedEmployee);
                Employees.Remove(SelectedEmployee);
                SelectedEmployee = null;
            }
        }

    }
}
