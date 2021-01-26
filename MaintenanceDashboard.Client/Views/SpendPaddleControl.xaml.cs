using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;
using System.Windows;

namespace MaintenanceDashboard.Client.Views
{
    public partial class SpendPaddleControl : UserControl
    {
        public SpendPaddleControl()
        {
            this.DataContext = new ReceivedPaddleViewModel(new ReceivedPaddleContext());
            InitializeComponent();
        }

        private void btnRefreash_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new ReceivedPaddleViewModel(new ReceivedPaddleContext());
            InitializeComponent();
        }
    }
}
