using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class EditEmployeeControl : UserControl
    {
        public EditEmployeeControl()
        {
            InitializeComponent();

            var _employeeViewModel = new EmployeeViewModel(new EmployeeContext());
           this.DataContext = _employeeViewModel;
            _employeeViewModel.GetEmployeeList();
        }
    }
}

