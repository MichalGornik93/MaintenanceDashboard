using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Api;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class EditEmployeeControl : UserControl
    {
        public EditEmployeeControl()
        {
            var _employeeViewModel= new EmployeeViewModel(new EmployeeContext());
            this.DataContext = _employeeViewModel;
            _employeeViewModel.GetEmployeeList();
            InitializeComponent();
        }
    }
}

