using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Data.Domain;
using System.Windows;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class ManagerPaddleControl : UserControl
    {
        public ManagerPaddleControl()
        {
            
            InitializeComponent();
        }

        private void btnOpenAcceptancePaddle_Checked(object sender, RoutedEventArgs e)
        {
            if (GridPrincipal != null)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new AcceptancePaddle());
            }
        }

        private void btnOpenReleasePaddle_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnOpenAddPaddle_Checked(object sender, RoutedEventArgs e)
        {
            if (GridPrincipal != null)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new AddPaddleControl());
            }
        }

        private void btnOpenEditPaddle_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnOpenAddPaddleAction_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnOpenEditPaddleAction_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
