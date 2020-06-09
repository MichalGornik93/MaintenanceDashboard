using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class MaintenanceDashboardViewModel : ViewModel
    {
        private readonly MaintenanceDashboardContext context;
        public ICollection<RegisterTool> RegisterTools { get; private set; }
        public ICollection<Employee> Employees { get; private set; }

        public string ToolName { get; set; }
        public string UidCodeRegisterTool { get; set; } 

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UidCodeEmployee { get; set; }


        private RegisterTool selectedRegisterTool;

        public RegisterTool SelectedRegisterTool
        {
            get { return selectedRegisterTool; }
            set
            {
                selectedRegisterTool = value;
                NotifyPropertyChanged();
            }
        }

        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                NotifyPropertyChanged();
            }
        }

        public MaintenanceDashboardViewModel() : this(new MaintenanceDashboardContext()) {}

        public MaintenanceDashboardViewModel(MaintenanceDashboardContext context)
        {
            this.context = context;
            RegisterTools = new ObservableCollection<RegisterTool>();
            Employees = new ObservableCollection<Employee>();
        }


        #region RegisterToolViewModel
        public ActionCommand AddRegisterToolCommand
        {
            get
            {
                return new ActionCommand(p => AddRegisterTool(ToolName, UidCodeRegisterTool),
                                         p => !String.IsNullOrWhiteSpace(ToolName));
            }
        }
        public ActionCommand SaveRegisterToolCommand
        {
            get
            {
                return new ActionCommand(p => SaveRegisterTool(),
                                         p => IsValidRegisterTool);
            }
        }

        public ICommand DeleteRegisterToolCommand
        {
            get
            {
                return new ActionCommand(p => DeleteRegisterTool(),
                    p => IsValidRegisterTool);
            }
        }


        public ICommand GetRegisterToolListCommand
        {
            get
            {
                return new ActionCommand(p => GetRegisterToolList());
            }
        }

        public bool IsValidRegisterTool
        {
            get
            {
                return SelectedRegisterTool == null ||
                !String.IsNullOrWhiteSpace(SelectedRegisterTool.ToolName);
            }
        }

        private void AddRegisterTool(string toolName, string uidCode)
        {
            using (var api = new MaintenanceDashboardContext())
            {
                var registerTool = new RegisterTool
                {
                    ToolName = toolName,
                    UidCode = uidCode
                };

                api.AddNewRegisterTool(registerTool);

                RegisterTools.Add(registerTool);
            }
        }

        private void GetRegisterToolList()
        {
            RegisterTools.Clear();
            SelectedRegisterTool = null;

            foreach (var item in context.GetRegisterToolList())
                RegisterTools.Add(item);
        }

        private void SaveRegisterTool()
        {
            if (SelectedRegisterTool != null)
            {
                context.UpdateRegisterTool(SelectedRegisterTool);
            }
        }

        private void DeleteRegisterTool()
        {
            if (SelectedRegisterTool != null)
            {
                context.DataContext.RegisterTools.Remove(SelectedRegisterTool);
                context.DataContext.SaveChanges();
                RegisterTools.Remove(SelectedRegisterTool);

            }
        }

        //public override 

        #endregion

        #region EmployeeViewModel
        public ActionCommand AddEmployeeCommand
        {
            get
            {
                return new ActionCommand(p => AddEmployee(FirstName, LastName, UidCodeEmployee),
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
                return new ActionCommand(p => DeleteEmployee(),
                   p => IsValidEmployee);
            }
        }


        public ICommand GetEmployeeListCommand
        {
            get
            {
                return new ActionCommand(p => GetEmployeeList());
            }
        }

        public bool IsValidEmployee //for refactoring
        {
            get
            {
                return SelectedEmployee == null ||
                (!String.IsNullOrWhiteSpace(SelectedEmployee.FirstName) && !String.IsNullOrWhiteSpace(SelectedEmployee.LastName));
            }
        }

        private void AddEmployee(string firstName, string lastName, string uidCodeEmployee) //for refactorning
        {
            using (var api = new MaintenanceDashboardContext())
            {
                var employee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UidCode = uidCodeEmployee
                };

                api.AddNewEmployee(employee);

                Employees.Add(employee);
            }
        }

        private void GetEmployeeList()
        {
            Employees.Clear();

            foreach (var item in context.GetEmployeeList())
                Employees.Add(item);
        }

        private void SaveEmployee()
        {
            if (SelectedEmployee != null)
            {
                context.UpdateEmployee(SelectedEmployee);
            }
        }

        private void DeleteEmployee()
        {
            if (SelectedEmployee != null)
            {
                context.DataContext.Employees.Remove(SelectedEmployee);
                context.DataContext.SaveChanges();
                Employees.Remove(SelectedEmployee);

            }
        }
        #endregion

    }
}
