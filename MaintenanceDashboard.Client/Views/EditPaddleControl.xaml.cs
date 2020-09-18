using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class EditPaddleControl : UserControl
    {
        public EditPaddleControl()
        {
            InitializeComponent();
            this.DataContext = new PaddleViewModel(new PaddleContext());
        }
    }
}
