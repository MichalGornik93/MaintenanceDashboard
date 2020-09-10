using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class ManagerEmployeeControl : UserControl
    {
        public ManagerEmployeeControl()
        {
            InitializeComponent();
        }

        private void btnOpenAddEmployee_Checked(object sender, RoutedEventArgs e)
        {
            if (GridPrincipal != null)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new CreateEmployeeControl());
            }
        }

        private void btnOpenEditEmployee_Checked(object sender, RoutedEventArgs e)
        {
            if (GridPrincipal != null)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new EditEmployeeControl());
            }
        }
    }
}
