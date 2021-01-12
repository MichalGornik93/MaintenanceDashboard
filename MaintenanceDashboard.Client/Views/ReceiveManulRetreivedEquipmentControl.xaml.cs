using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class ReceiveManulRetreivedEquipmentControl : UserControl
    {
        public ReceiveManulRetreivedEquipmentControl()
        {
            this.DataContext = new RetrievedEquipmentViewModel(new RetrievedEquipmentContext());
            InitializeComponent();
        }
    }
}
