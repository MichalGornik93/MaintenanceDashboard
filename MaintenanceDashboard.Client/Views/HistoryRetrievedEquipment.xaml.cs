using MaintenanceDashboard.Client.ViewModels;
using System.Windows.Controls;
using MaintenanceDashboard.Data.API;

namespace MaintenanceDashboard.Client.Views
{
    public partial class HistoryRetrievedEquipment : UserControl
    {
        public HistoryRetrievedEquipment()
        {
            this.DataContext = new RetrievedEquipmentViewModel(new RetrievedEquipmentContext());
            InitializeComponent();
        }
    }
}
