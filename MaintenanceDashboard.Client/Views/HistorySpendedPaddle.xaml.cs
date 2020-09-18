using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class HistorySpendedPaddle : UserControl
    {  
        public HistorySpendedPaddle()
        {
            this.DataContext = new SpendedPaddleViewModel(new SpendedPaddleContext());
            InitializeComponent();
        }
    }
}
