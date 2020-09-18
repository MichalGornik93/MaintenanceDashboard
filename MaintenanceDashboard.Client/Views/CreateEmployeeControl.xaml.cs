using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class CreateEmployeeControl : UserControl
    {
        public CreateEmployeeControl()
        {
            this.DataContext = new EmployeeViewModel(new EmployeeContext());
            InitializeComponent();
        }
    }
}
