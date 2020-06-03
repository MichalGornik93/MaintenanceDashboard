using MaintenanceDashboard.Data.Domain;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MaintenanceDashboard.Client.Views
{

    public partial class RegisterToolControl : UserControl
    {      
        public RegisterToolControl()
        {
            InitializeComponent();
        }

        private void btnOpenWindowAddRegisterTool_Click(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new AddRegisterToolControl());
        }
    }
}
