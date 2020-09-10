using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
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
                GridPrincipal.Children.Add(new AcceptancePaddleControl());
            }
        }

        private void btnOpenSpendPaddle_Checked(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new SpendPaddle());
        }

        private void btnOpenAddPaddle_Checked(object sender, RoutedEventArgs e)
        {
            if (GridPrincipal != null)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new CreatePaddleControl());
            }
        }

        private void btnOpenEditPaddle_Checked(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new EditPaddleControl());
        }

        private void btnOpenPerformedActivitiesList_Checked(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new HistorySpendedPaddle());
        }

        private void btnOpenGetPaddle_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnOpenPutPaddle_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
