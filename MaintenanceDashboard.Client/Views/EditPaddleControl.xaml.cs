using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Api;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class EditPaddleControl : UserControl
    {
        public EditPaddleControl()
        {
            InitializeComponent();
            var _paddleViewModel = new PaddleViewModel(new PaddleContext());
            this.DataContext = _paddleViewModel;
            _paddleViewModel.GetPaddleList();
        }
    }
}
