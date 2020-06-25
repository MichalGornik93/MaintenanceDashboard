using System.Windows;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class AddPaddleControl : UserControl
    {
        public AddPaddleControl()
        {
            InitializeComponent();
        }

        private void btnAddPaddle_Click(object sender, RoutedEventArgs e)
        {
            gridInfoAddToDataBase.Visibility = Visibility.Visible;
        }
    }
}
