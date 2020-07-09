using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Api;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{

    public partial class AcceptancePaddle : UserControl
    {
        public AcceptancePaddle()
        {
            InitializeComponent();

            var tamp = new EmployeeViewModel(new EmployeeContext());
            tamp.GetEmployeeList();
            this.DataContext = tamp;

        }
    }
}
