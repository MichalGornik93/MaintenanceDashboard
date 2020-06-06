using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class ManagerRegisterToolControl : UserControl
    {
        public ManagerRegisterToolControl()
        {
            InitializeComponent();
            
        }

        private void btnOpenAddRegisterTool_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GridPrincipal != null)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new AddRegisterToolControl());
            }
        }

        private void btnOpenEditRegisterTool_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GridPrincipal != null)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new EditRegisterToolControl());
            }
        }
    }
}
