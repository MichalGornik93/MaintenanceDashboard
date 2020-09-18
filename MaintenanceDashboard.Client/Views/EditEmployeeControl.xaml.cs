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
           this.DataContext = new EmployeeViewModel(new EmployeeContext());
        }
    }
}

