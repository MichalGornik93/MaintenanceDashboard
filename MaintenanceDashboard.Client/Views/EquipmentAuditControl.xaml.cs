using MaintenanceDashboard.Client.ViewModels;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class EquipmentAuditControl : UserControl
    {
        public EquipmentAuditControl()
        {
            this.DataContext = new EquipmentAuditViewModel();
            InitializeComponent();
        }
    }
}