using System.Windows;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class CreateEmployeeControl : UserControl
    {
        public CreateEmployeeControl()
        {
            InitializeComponent();
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            gridInfoAddToDataBase.Visibility = Visibility.Visible;
        }
    }
}
