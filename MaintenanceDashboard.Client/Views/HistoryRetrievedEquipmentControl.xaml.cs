using MaintenanceDashboard.Client.ViewModels;
using System.Windows.Controls;
using MaintenanceDashboard.Data.API;

namespace MaintenanceDashboard.Client.Views
{
    public partial class HistoryRetrievedEquipmentControl : UserControl
    {
        public HistoryRetrievedEquipmentControl()
        {
            this.DataContext = new RetrievedEquipmentViewModel(new RetrievedEquipmentContext());
            InitializeComponent();
        }
    }
}
