using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class HistorySpendedPaddleControl : UserControl
    {  
        public HistorySpendedPaddleControl()
        {
            this.DataContext = new SpendedPaddleViewModel(new SpendedPaddleContext());
            InitializeComponent();
        }
    }
}
