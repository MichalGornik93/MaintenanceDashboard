using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Api;
using System.Windows;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class CreatePaddleControl : UserControl
    {
        public CreatePaddleControl()
        {
            InitializeComponent();
            this.DataContext = new PaddleViewModel(new PaddleContext());
        }

        private void btnAddPaddle_Click(object sender, RoutedEventArgs e)
        {
            gridInfoAddToDataBase.Visibility = Visibility.Visible;
            gridPrincipal.Visibility = Visibility.Collapsed;
        }
    }
}
