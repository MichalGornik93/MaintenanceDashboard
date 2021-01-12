using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class ManagerRetrievedEquipment : UserControl
    {
        public ManagerRetrievedEquipment()
        {
            InitializeComponent();
        }

        private void btnOpenManualRetreiveEquipment_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GridPrincipal != null)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new ReceiveManulRetreivedEquipmentControl());
            }
        }

        private void btnOpenOpenPerformedRetreiveEquipment_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GridPrincipal != null)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new HistoryRetrievedEquipment());
            }
        }
    }
}
