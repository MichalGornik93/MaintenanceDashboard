using System.Windows.Controls;
using System.Windows;

namespace MaintenanceDashboard.Client.Views
{

    public partial class AddRegisterToolControl : UserControl
    {
        public AddRegisterToolControl()
        {
            InitializeComponent();
        }

        private void btnAddRegisterTool_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            gridInfoAddToDataBase.Visibility = Visibility.Visible;
        }
    }
}
