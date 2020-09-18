using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;
using System.Windows;

namespace MaintenanceDashboard.Client.Views
{
    public partial class AcceptancePaddleControl : UserControl
    {
        public AcceptancePaddleControl()
        {
            this.DataContext = new ReceivedPaddleViewModel(new ReceivedPaddleContext());
            InitializeComponent();
        }
    }
}
