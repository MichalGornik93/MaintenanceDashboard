using System.Windows;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    /// <summary>
    /// Logika interakcji dla klasy PaddleControl.xaml
    /// </summary>
    public partial class ManagerPaddleControl : UserControl
    {
        public ManagerPaddleControl()
        {
            InitializeComponent();
        }

        private void btnOpenGetPaddle_Checked(object sender, RoutedEventArgs e)
        {
            if (GridPrincipal != null)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new GetPaddleControl());
            }
        }

        private void btnOpenPutPaddle_Checked(object sender, RoutedEventArgs e)
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
