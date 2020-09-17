using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class HistorySpendedPaddle : UserControl
    {
        private readonly SpendedPaddleViewModel _spendedPaddleViewModel;
        
        public HistorySpendedPaddle()
        {
            _spendedPaddleViewModel = new SpendedPaddleViewModel(new SpendedPaddleContext());
            this.DataContext = _spendedPaddleViewModel;
            InitializeComponent();
        }
    }
}
