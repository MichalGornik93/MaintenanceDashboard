using System.Windows.Controls;
using System.Windows;
using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Api;

namespace MaintenanceDashboard.Client.Views
{

    public partial class AddRegisterToolControl : UserControl
    {
        public AddRegisterToolControl()
        {
            InitializeComponent();
            var _registerToolViewModel = new RegisterToolViewModel(new RegisterToolContext());
            this.DataContext = _registerToolViewModel;
        }

        private void btnAddRegisterTool_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            gridInfoAddToDataBase.Visibility = Visibility.Visible;
            gridPrincipal.Visibility = Visibility.Collapsed;
        }
    }
}
